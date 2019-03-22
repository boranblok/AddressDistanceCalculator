using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mono.Data.Sqlite;

namespace AdressDistance
{
    class DBHandler
    {
        private static Object lockObject = new Object();
        private static DBHandler _instance;
        public static DBHandler Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(lockObject)
                    {
                        if (_instance == null)
                            _instance = new DBHandler();
                    }
                }
                return _instance;
            }
        }

        private String _connectionString;
        private Int32 _cacheSeconds;

        private DBHandler()
        {
            var CacheSecondsString = ConfigurationManager.AppSettings["CacheSeconds"];
            if(!Int32.TryParse(CacheSecondsString, out _cacheSeconds))
            {
                _cacheSeconds = 600; //10 minute cache by default.
            }
            DetermineConnectionString();
            InitializeDatabase();
        }

        private void DetermineConnectionString()
        {
            String codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            String path = Uri.UnescapeDataString(uri.Path);
            String assemblyDirectory = Path.GetDirectoryName(path);

            String dbFilePath = Path.Combine(assemblyDirectory, "addressDistance.Sqlite3.db");
            _connectionString = String.Format("URI=file:{0},version=3", dbFilePath);
        }

        private void InitializeDatabase()
        {
            List<DBScript> dbScripts = LoadDbScripts();
            Int64 highestScriptVersion = (Int64)Math.Floor(
                dbScripts.OrderByDescending(s => s.ScriptNumber).First().ScriptNumber);

            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();

                Int64 dbVersion;

                using(SqliteCommand versionCmd = conn.CreateCommand())
                {
                    versionCmd.CommandText = "PRAGMA user_version";
                    dbVersion = (Int64) versionCmd.ExecuteScalar();
                }

                if (dbVersion >= highestScriptVersion)
                    return;

                var scriptsToApply = dbScripts.Where(s => s.ScriptNumber >= dbVersion + 1).OrderBy(s => s.ScriptNumber);

                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand ddlCmd = conn.CreateCommand())
                    {
                        ddlCmd.Transaction = trans;
                        foreach(var script in scriptsToApply)
                        {
                            ddlCmd.CommandText = script.DdlStatement;
                            ddlCmd.ExecuteNonQuery();
                        }
                        ddlCmd.CommandText = "PRAGMA user_version = " + highestScriptVersion;
                        ddlCmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }

        private List<DBScript> LoadDbScripts()
        {
            List<DBScript> scripts = new List<DBScript>();
            DirectoryInfo scriptFolder = new DirectoryInfo("dbScripts");
            if (!scriptFolder.Exists)
                return scripts;

            foreach (FileInfo scriptFile in scriptFolder.GetFileSystemInfos("*.sql"))
            {
                Decimal scriptNumber;
                if (Decimal.TryParse(scriptFile.NameWithoutExtension(), 
                    NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out scriptNumber))
                {
                    using(StreamReader reader = scriptFile.OpenText())
                    {
                        String ddl = reader.ReadToEnd();
                        scripts.Add(new DBScript{
                            ScriptNumber = scriptNumber,
                            DdlStatement = ddl
                        });
                    }
                }
            }

            return scripts;
        }

        public List<DestinationAddress> GetDestinationAdresses()
        {
            var adresses = new List<DestinationAddress>();

            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ROWID, * from Destinations";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adresses.Add(GetDestinationAddressFromReader(reader));
                        }
                    }
                }
            }
            return adresses;
        }

        private DestinationAddress GetDestinationAddressFromReader(SqliteDataReader reader)
        {
            var destAddr = new DestinationAddress();

            destAddr.ExistingItem = true;
            destAddr.RowNum = (Int64)reader["ROWID"];
            destAddr.Address = reader["Addr"] as String;
            destAddr.Alias = reader["Alias"] as String;
            destAddr.CoordLat = GetDecimal(reader["CoordLat"]);
            destAddr.CoordLon = GetDecimal(reader["CoordLon"]);

            return destAddr;
        }

        public List<DepartureAddress> GetDepartureAdresses()
        {
            var adresses = new List<DepartureAddress>();

            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ROWID, * from Departures";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            adresses.Add(GetDepartureAddressFromReader(reader));
                        }
                    }
                }
            }
            return adresses;
        }

        private DepartureAddress GetDepartureAddressFromReader(SqliteDataReader reader)
        {
            var depAddr = new DepartureAddress();

            depAddr.ExistingItem = true;
            depAddr.RowNum = (Int64)reader["ROWID"];
            depAddr.Address = reader["Addr"] as String;
            depAddr.CoordLat = GetDecimal(reader["CoordLat"]);
            depAddr.CoordLon = GetDecimal(reader["CoordLon"]);

            return depAddr;
        }

        public void SaveAddress(DestinationAddress destAddr)
        {
            if (destAddr.ExistingItem)
                UpdateAddress(destAddr);
            else
                InsertAddress(destAddr);
        }

        public void SaveAddress(DepartureAddress depAddr)
        {
            if (depAddr.ExistingItem)
                UpdateAddress(depAddr);
            else
                InsertAddress(depAddr);
        }

        private void InsertAddress(DestinationAddress destAddr)
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"INSERT INTO Destinations(
                                                            Alias, 
                                                            Addr,
                                                            CoordLat,
                                                            CoordLon)
                                                    VALUES(
                                                            @alias,
                                                            @addr,
                                                            @coordLat,
                                                            @coordLon)";
                        cmd.Parameters.Add(new SqliteParameter("@alias", destAddr.Alias));
                        cmd.Parameters.Add(new SqliteParameter("@addr", destAddr.Address));
                        cmd.Parameters.Add(new SqliteParameter("@coordLat", GetDbValue(destAddr.CoordLat)));
                        cmd.Parameters.Add(new SqliteParameter("@coordLon", GetDbValue(destAddr.CoordLon)));
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "select last_insert_rowid()";
                        cmd.Parameters.Clear();
                        destAddr.RowNum = (Int64)cmd.ExecuteScalar();                        
                    }
                    trans.Commit();
                    destAddr.ExistingItem = true;
                }
            }
        }

        private void InsertAddress(DepartureAddress depAddr)
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"INSERT INTO Departures(
                                                            Addr,
                                                            CoordLat,
                                                            CoordLon)
                                                    VALUES(
                                                            @addr,
                                                            @coordLat,
                                                            @coordLon)";
                        cmd.Parameters.Add(new SqliteParameter("@addr", depAddr.Address));
                        cmd.Parameters.Add(new SqliteParameter("@coordLat", GetDbValue(depAddr.CoordLat)));
                        cmd.Parameters.Add(new SqliteParameter("@coordLon", GetDbValue(depAddr.CoordLon)));
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "select last_insert_rowid()";
                        cmd.Parameters.Clear();
                        depAddr.RowNum = (Int64)cmd.ExecuteScalar();
                    }
                    trans.Commit();
                    depAddr.ExistingItem = true;
                }
            }
        }

        private void UpdateAddress(DestinationAddress destAddr)
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Destinations SET 
                                            Alias = @alias,
                                            Addr = @addr,
                                            CoordLat = @coordLat,
                                            CoordLon = @coordLon
                                        WHERE ROWID = @rowId";
                    cmd.Parameters.Add(new SqliteParameter("@alias", destAddr.Alias));
                    cmd.Parameters.Add(new SqliteParameter("@addr", destAddr.Address));
                    cmd.Parameters.Add(new SqliteParameter("@coordLat", GetDbValue(destAddr.CoordLat)));
                    cmd.Parameters.Add(new SqliteParameter("@coordLon", GetDbValue(destAddr.CoordLon)));
                    cmd.Parameters.Add(new SqliteParameter("@rowId", destAddr.RowNum));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateAddress(DepartureAddress depAddr)
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Departures SET 
                                            Addr = @addr,
                                            CoordLat = @coordLat,
                                            CoordLon = @coordLon
                                        WHERE ROWID = @rowId";
                    cmd.Parameters.Add(new SqliteParameter("@addr", depAddr.Address));
                    cmd.Parameters.Add(new SqliteParameter("@coordLat", GetDbValue(depAddr.CoordLat)));
                    cmd.Parameters.Add(new SqliteParameter("@coordLon", GetDbValue(depAddr.CoordLon)));
                    cmd.Parameters.Add(new SqliteParameter("@rowId", depAddr.RowNum));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAddress(DestinationAddress destAddr)
        {
            if (!destAddr.ExistingItem)
                return;

            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"DELETE FROM Destinations WHERE ROWID = @rowId";
                        cmd.Parameters.Add(new SqliteParameter("@rowId", destAddr.RowNum));
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }

        public void DeleteAddress(DepartureAddress deptAddr)
        {
            if (!deptAddr.ExistingItem)
                return;

            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"DELETE FROM Departures WHERE ROWID = @rowId";
                        cmd.Parameters.Add(new SqliteParameter("@rowId", deptAddr.RowNum));
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }

        public String GetCachedResponse(String request)
        {
            CleanupCache();
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT response from GoogleAPICache WHERE request = @request";
                    cmd.Parameters.Add(new SqliteParameter("@request", request));
                    return cmd.ExecuteScalar() as String;
                }
            }
        }

        public void StoreResponseInCache(String request, String response)
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"INSERT INTO GoogleAPICache(
                                                            request,
                                                            response,
                                                            storedTime)
                                                    VALUES(
                                                            @request,
                                                            @response,
                                                            @storedTime)";
                        cmd.Parameters.Add(new SqliteParameter("@request", request));
                        cmd.Parameters.Add(new SqliteParameter("@response", response));
                        cmd.Parameters.Add(new SqliteParameter("@storedTime", DateTime.Now.Ticks));
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();                    
                }
            }
        }

        public void CleanupCache()
        {
            Int64 filterTicks = DateTime.Now.AddSeconds(_cacheSeconds * -1).Ticks;
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                using (SqliteTransaction trans = conn.BeginTransaction())
                {
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = @"DELETE FROM GoogleAPICache WHERE storedTime < @storedTime";
                        cmd.Parameters.Add(new SqliteParameter("@storedTime", filterTicks));
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
            }
        }

        private static Object GetDbValue(Boolean boolean)
        {
            return boolean ? 1 : 0;
        }

        private static Object GetDbValue(Nullable<DateTime> dateTime)
        {
            if (!dateTime.HasValue)
                return DBNull.Value;
            return dateTime.Value.ToString("o");
        }

        private static Object GetDbValue(Decimal number)
        {
            Int64 dbVal = (Int64)(number * 1000000000);
            return dbVal;
        }

        private static Boolean GetBoolean(Object dbValue)
        {
            Int64 boolValue = (Int64)dbValue;
            return boolValue == 1;
        }

        private static DateTime GetDateTime(Object dbValue)
        {
            String dateTimeStr = dbValue as String;
            return DateTime.Parse(dateTimeStr, null, DateTimeStyles.RoundtripKind);
        }

        private static Nullable<DateTime> GetNullableDateTime(Object dbValue)
        {
            String dateTimeStr = dbValue as String;
            DateTime result;
            if (dateTimeStr != null && DateTime.TryParse(dateTimeStr, null, DateTimeStyles.RoundtripKind, out result))
                return result;

            return null;
        }

        private static Decimal GetDecimal(Object dbValue)
        {
            Int64 intValue = (Int64)dbValue;
            return ((Decimal)intValue) / 1000000000;
        }
    }
}

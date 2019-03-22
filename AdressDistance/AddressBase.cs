using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressDistance
{
    public abstract class AddressBase :  SQLiteBase
    {
        private String _address;
        public String Address
        {
            get { return _address; }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }

        private Decimal _coordLat;
        public Decimal CoordLat
        {
            get { return _coordLat; }
            set
            {
                if (value != _coordLat)
                {
                    _coordLat = value;
                    OnPropertyChanged();
                }
            }
        }

        private Decimal _coordLon;
        public Decimal CoordLon
        {
            get { return _coordLon; }
            set
            {
                if (value != _coordLon)
                {
                    _coordLon = value;
                    OnPropertyChanged();
                }
            }
        }

        public void GetCoordinatesFromGoogle()
        {
            GoogleAPIWrapper.GeoCodeResponse response = GoogleAPIWrapper.GetAddressLocation(Address);
            if(response.HasValue)
            {
                CoordLat = response.Latitute;
                CoordLon = response.Longtitude;
            }
        }

        public String GetCoordinatesAsString()
        {
            return CoordLat.ToString(CultureInfo.InvariantCulture) + ',' + CoordLon.ToString(CultureInfo.InvariantCulture);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdressDistance
{
    public abstract class SQLiteBase : INotifyPropertyChanged
    {
        public Boolean ExistingItem { get; set; }

        private Int64 _rowNum;
        public Int64 RowNum
        {
            get { return _rowNum; }
            set
            {
                if (value != _rowNum)
                {
                    _rowNum = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

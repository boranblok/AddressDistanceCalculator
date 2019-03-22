using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressDistance
{
    public class DestinationAddress : AddressBase
    {
        private String _alias;

        public String Alias
        {
            get { return _alias; }
            set
            {
                if (value != _alias)
                {
                    _alias = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

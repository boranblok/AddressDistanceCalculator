using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressDistance
{
    public partial class DepartureForm : Form
    {
        ObservableCollection<DepartureAddress> addresses;
        List<DepartureAddress> addressesToDelete;
        public DepartureForm()
        {
            InitializeComponent();

            addressesToDelete = new List<DepartureAddress>();
            addresses = new ObservableCollection<DepartureAddress>(DBHandler.Instance.GetDepartureAdresses());
            departureAddressBindingSource.DataSource = addresses;
        }

        private void grvDepartures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = sender as DataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var address = senderGrid.Rows[e.RowIndex].DataBoundItem as AddressBase;
                address.GetCoordinatesFromGoogle();
                ShowTravelTimesForCurrentDeparture();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (var delAddr in addressesToDelete)
            {
                DBHandler.Instance.DeleteAddress(delAddr);
            }
            addressesToDelete.Clear();
            foreach (var depAddr in addresses)
            {
                DBHandler.Instance.SaveAddress(depAddr);
            }
        }

        private void btnAddDestinations_Click(object sender, EventArgs e)
        {
            using (DestinationForm frmdestinations = new DestinationForm())
            {
                var result = frmdestinations.ShowDialog();
                if (result == DialogResult.OK)
                    ShowTravelTimesForCurrentDeparture();
            }
        }

        private void grvDepartures_SelectionChanged(object sender, EventArgs e)
        {
            ShowTravelTimesForCurrentDeparture();
        }

        private void ShowTravelTimesForCurrentDeparture()
        {
            DepartureAddress selectedAddress = grvDepartures.CurrentRow.DataBoundItem as DepartureAddress;
            if (selectedAddress != null && selectedAddress.CoordLat != 0 && selectedAddress.CoordLon != 0)
            {
                List<TravelTime> travelTimes = GoogleAPIWrapper.GetTravelTimes(selectedAddress, DBHandler.Instance.GetDestinationAdresses());
                travelTimeBindingSource.DataSource = travelTimes;
            }
        }

        private void grvDepartures_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            addressesToDelete.Add(e.Row.DataBoundItem as DepartureAddress);
        }
    }
}

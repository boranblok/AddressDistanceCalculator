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
    public partial class DestinationForm : Form
    {
        ObservableCollection<DestinationAddress> adresses;
        List<DestinationAddress> addressesToDelete;
        public DestinationForm()
        {
            InitializeComponent();
            addressesToDelete = new List<DestinationAddress>();
            adresses = new ObservableCollection<DestinationAddress>(DBHandler.Instance.GetDestinationAdresses());
            destinationAddressBindingSource.DataSource = adresses;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach(var delAddr in addressesToDelete)
            {
                DBHandler.Instance.DeleteAddress(delAddr);
            }
            foreach(var destAddr in adresses)
            {
                DBHandler.Instance.SaveAddress(destAddr);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void grvDestinations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = sender as DataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var address = senderGrid.Rows[e.RowIndex].DataBoundItem as AddressBase;
                address.GetCoordinatesFromGoogle();
            }
        }

        private void btnCancel_click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();            
        }

        private void grvDestinations_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            addressesToDelete.Add(e.Row.DataBoundItem as DestinationAddress);
        }
    }
}

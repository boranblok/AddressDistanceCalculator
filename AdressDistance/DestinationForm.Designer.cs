namespace AdressDistance
{
    partial class DestinationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grvDestinations = new System.Windows.Forms.DataGridView();
            this.FetchCoords = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.aliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordLatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordLonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvDestinations)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.destinationAddressBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grvDestinations
            // 
            this.grvDestinations.AutoGenerateColumns = false;
            this.grvDestinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvDestinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDestinations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aliasDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.FetchCoords,
            this.coordLatDataGridViewTextBoxColumn,
            this.coordLonDataGridViewTextBoxColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.grvDestinations, 3);
            this.grvDestinations.DataSource = this.destinationAddressBindingSource;
            this.grvDestinations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDestinations.Location = new System.Drawing.Point(3, 3);
            this.grvDestinations.Name = "grvDestinations";
            this.grvDestinations.Size = new System.Drawing.Size(608, 426);
            this.grvDestinations.TabIndex = 0;
            this.grvDestinations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDestinations_CellContentClick);
            this.grvDestinations.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grvDestinations_UserDeletingRow);
            // 
            // FetchCoords
            // 
            this.FetchCoords.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FetchCoords.HeaderText = "";
            this.FetchCoords.Name = "FetchCoords";
            this.FetchCoords.Text = "Get Coord";
            this.FetchCoords.ToolTipText = "Get The coordinates matching the address";
            this.FetchCoords.UseColumnTextForButtonValue = true;
            this.FetchCoords.Width = 80;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.grvDestinations, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(614, 461);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(536, 435);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(455, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_click);
            // 
            // aliasDataGridViewTextBoxColumn
            // 
            this.aliasDataGridViewTextBoxColumn.DataPropertyName = "Alias";
            this.aliasDataGridViewTextBoxColumn.FillWeight = 50F;
            this.aliasDataGridViewTextBoxColumn.HeaderText = "Alias";
            this.aliasDataGridViewTextBoxColumn.Name = "aliasDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // coordLatDataGridViewTextBoxColumn
            // 
            this.coordLatDataGridViewTextBoxColumn.DataPropertyName = "CoordLat";
            this.coordLatDataGridViewTextBoxColumn.FillWeight = 50F;
            this.coordLatDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.coordLatDataGridViewTextBoxColumn.Name = "coordLatDataGridViewTextBoxColumn";
            // 
            // coordLonDataGridViewTextBoxColumn
            // 
            this.coordLonDataGridViewTextBoxColumn.DataPropertyName = "CoordLon";
            this.coordLonDataGridViewTextBoxColumn.FillWeight = 50F;
            this.coordLonDataGridViewTextBoxColumn.HeaderText = "Longtitude";
            this.coordLonDataGridViewTextBoxColumn.Name = "coordLonDataGridViewTextBoxColumn";
            // 
            // destinationAddressBindingSource
            // 
            this.destinationAddressBindingSource.DataSource = typeof(AdressDistance.DestinationAddress);
            // 
            // DestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DestinationForm";
            this.Text = "Destinations";
            ((System.ComponentModel.ISupportInitialize)(this.grvDestinations)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.destinationAddressBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvDestinations;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn FetchCoords;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordLatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordLonDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource destinationAddressBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
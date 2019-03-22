namespace AdressDistance
{
    partial class DepartureForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grvTravelTimes = new System.Windows.Forms.DataGridView();
            this.destinationAliasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.travelTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grvDepartures = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetCoords = new System.Windows.Forms.DataGridViewButtonColumn();
            this.coordLatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordLonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departureAddressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddDestinations = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvTravelTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureAddressBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvTravelTimes
            // 
            this.grvTravelTimes.AllowUserToAddRows = false;
            this.grvTravelTimes.AllowUserToDeleteRows = false;
            this.grvTravelTimes.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvTravelTimes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grvTravelTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTravelTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.destinationAliasDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.Distance});
            this.grvTravelTimes.DataSource = this.travelTimeBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvTravelTimes.DefaultCellStyle = dataGridViewCellStyle2;
            this.grvTravelTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvTravelTimes.Location = new System.Drawing.Point(492, 3);
            this.grvTravelTimes.Name = "grvTravelTimes";
            this.grvTravelTimes.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvTravelTimes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvTravelTimes.Size = new System.Drawing.Size(320, 466);
            this.grvTravelTimes.TabIndex = 0;
            // 
            // destinationAliasDataGridViewTextBoxColumn
            // 
            this.destinationAliasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.destinationAliasDataGridViewTextBoxColumn.DataPropertyName = "DestinationAlias";
            this.destinationAliasDataGridViewTextBoxColumn.HeaderText = "DestinationAlias";
            this.destinationAliasDataGridViewTextBoxColumn.Name = "destinationAliasDataGridViewTextBoxColumn";
            this.destinationAliasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Distance
            // 
            this.Distance.DataPropertyName = "Distance";
            this.Distance.HeaderText = "Distance";
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            // 
            // travelTimeBindingSource
            // 
            this.travelTimeBindingSource.DataSource = typeof(AdressDistance.TravelTime);
            // 
            // grvDepartures
            // 
            this.grvDepartures.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvDepartures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvDepartures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDepartures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.GetCoords,
            this.coordLatDataGridViewTextBoxColumn,
            this.coordLonDataGridViewTextBoxColumn});
            this.grvDepartures.DataSource = this.departureAddressBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvDepartures.DefaultCellStyle = dataGridViewCellStyle5;
            this.grvDepartures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDepartures.Location = new System.Drawing.Point(3, 3);
            this.grvDepartures.Name = "grvDepartures";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvDepartures.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grvDepartures.Size = new System.Drawing.Size(483, 466);
            this.grvDepartures.TabIndex = 1;
            this.grvDepartures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDepartures_CellContentClick);
            this.grvDepartures.SelectionChanged += new System.EventHandler(this.grvDepartures_SelectionChanged);
            this.grvDepartures.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grvDepartures_UserDeletingRow);
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // GetCoords
            // 
            this.GetCoords.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GetCoords.HeaderText = "";
            this.GetCoords.Name = "GetCoords";
            this.GetCoords.Text = "Get Coords.";
            this.GetCoords.UseColumnTextForButtonValue = true;
            this.GetCoords.Width = 80;
            // 
            // coordLatDataGridViewTextBoxColumn
            // 
            this.coordLatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coordLatDataGridViewTextBoxColumn.DataPropertyName = "CoordLat";
            this.coordLatDataGridViewTextBoxColumn.FillWeight = 40F;
            this.coordLatDataGridViewTextBoxColumn.HeaderText = "CoordLat";
            this.coordLatDataGridViewTextBoxColumn.Name = "coordLatDataGridViewTextBoxColumn";
            // 
            // coordLonDataGridViewTextBoxColumn
            // 
            this.coordLonDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coordLonDataGridViewTextBoxColumn.DataPropertyName = "CoordLon";
            this.coordLonDataGridViewTextBoxColumn.FillWeight = 40F;
            this.coordLonDataGridViewTextBoxColumn.HeaderText = "CoordLon";
            this.coordLonDataGridViewTextBoxColumn.Name = "coordLonDataGridViewTextBoxColumn";
            // 
            // departureAddressBindingSource
            // 
            this.departureAddressBindingSource.DataSource = typeof(AdressDistance.DepartureAddress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.grvDepartures, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grvTravelTimes, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 507);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnAddDestinations);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 475);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(809, 29);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnAddDestinations
            // 
            this.btnAddDestinations.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddDestinations.AutoSize = true;
            this.btnAddDestinations.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDestinations.Location = new System.Drawing.Point(709, 3);
            this.btnAddDestinations.Name = "btnAddDestinations";
            this.btnAddDestinations.Size = new System.Drawing.Size(97, 23);
            this.btnAddDestinations.TabIndex = 2;
            this.btnAddDestinations.Text = "Add Destinations";
            this.btnAddDestinations.UseVisualStyleBackColor = true;
            this.btnAddDestinations.Click += new System.EventHandler(this.btnAddDestinations_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(628, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DepartureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DepartureForm";
            this.Text = "DepartureForm";
            ((System.ComponentModel.ISupportInitialize)(this.grvTravelTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.travelTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departureAddressBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvTravelTimes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView grvDepartures;
        private System.Windows.Forms.BindingSource departureAddressBindingSource;
        private System.Windows.Forms.BindingSource travelTimeBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddDestinations;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordLonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordLatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn GetCoords;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationAliasDataGridViewTextBoxColumn;
    }
}
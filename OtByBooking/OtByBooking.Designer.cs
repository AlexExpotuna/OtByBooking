namespace OtByBooking
{
    partial class OtByBooking
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            bookingTextField = new TextBox();
            label2 = new Label();
            otDataGridView = new DataGridView();
            OtCell = new DataGridViewTextBoxColumn();
            StateColumn = new DataGridViewTextBoxColumn();
            Details = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)otDataGridView).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(311, 25);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += searchOT_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 29);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Booking";
            // 
            // bookingTextField
            // 
            bookingTextField.Location = new Point(143, 25);
            bookingTextField.Name = "bookingTextField";
            bookingTextField.Size = new Size(143, 23);
            bookingTextField.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 3;
            label2.Text = "Orden de trabajo";
            // 
            // otDataGridView
            // 
            otDataGridView.AllowUserToAddRows = false;
            otDataGridView.AllowUserToDeleteRows = false;
            otDataGridView.AllowUserToOrderColumns = true;
            otDataGridView.AllowUserToResizeRows = false;
            otDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            otDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            otDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            otDataGridView.Columns.AddRange(new DataGridViewColumn[] { OtCell, StateColumn, Details });
            otDataGridView.Location = new Point(12, 116);
            otDataGridView.Name = "otDataGridView";
            otDataGridView.ReadOnly = true;
            otDataGridView.Size = new Size(376, 150);
            otDataGridView.TabIndex = 7;
            otDataGridView.CellClick += otDataGridView_CellContentClick;
            // 
            // OtCell
            // 
            OtCell.Frozen = true;
            OtCell.HeaderText = "OT";
            OtCell.Name = "OtCell";
            OtCell.ReadOnly = true;
            OtCell.Width = 46;
            // 
            // StateColumn
            // 
            StateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StateColumn.HeaderText = "Estado";
            StateColumn.Name = "StateColumn";
            StateColumn.ReadOnly = true;
            // 
            // Details
            // 
            Details.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Details.HeaderText = "Ver detalles";
            Details.Name = "Details";
            Details.ReadOnly = true;
            Details.Width = 72;
            // 
            // OtByBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(400, 478);
            Controls.Add(otDataGridView);
            Controls.Add(label2);
            Controls.Add(bookingTextField);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "OtByBooking";
            Text = "OT By Booking";
            ((System.ComponentModel.ISupportInitialize)otDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox bookingTextField;
        private Label label2;
        private DataGridView otDataGridView;
        private DataGridViewTextBoxColumn OtCell;
        private DataGridViewTextBoxColumn StateColumn;
        private DataGridViewButtonColumn Details;
    }
}

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
            otTextField = new Label();
            message = new Label();
            buttonCopy = new Button();
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
            // otTextField
            // 
            otTextField.AutoSize = true;
            otTextField.Location = new Point(146, 81);
            otTextField.Name = "otTextField";
            otTextField.Size = new Size(24, 15);
            otTextField.TabIndex = 4;
            otTextField.Text = "NA";
            // 
            // message
            // 
            message.AutoSize = true;
            message.Location = new Point(12, 141);
            message.Name = "message";
            message.Size = new Size(24, 15);
            message.TabIndex = 5;
            message.Text = "NA";
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(312, 83);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(75, 23);
            buttonCopy.TabIndex = 6;
            buttonCopy.Text = "Copiar";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // OtByBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 180);
            Controls.Add(buttonCopy);
            Controls.Add(message);
            Controls.Add(otTextField);
            Controls.Add(label2);
            Controls.Add(bookingTextField);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "OtByBooking";
            Text = "OT By Booking";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox bookingTextField;
        private Label label2;
        private Label otTextField;
        private Label message;
        private Button buttonCopy;
    }
}

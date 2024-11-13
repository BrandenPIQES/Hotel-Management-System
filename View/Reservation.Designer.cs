namespace Reservations
{
    partial class ReservationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservationForm));
            this.Fromlabel = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.Tolabel = new System.Windows.Forms.Label();
            this.makeReservationbtn = new System.Windows.Forms.Button();
            this.roomsAvailableLabel = new System.Windows.Forms.Label();
            this.ToddlerLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.roomsAvailableTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Fromlabel
            // 
            this.Fromlabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fromlabel.AutoSize = true;
            this.Fromlabel.BackColor = System.Drawing.Color.Transparent;
            this.Fromlabel.CausesValidation = false;
            this.Fromlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fromlabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Fromlabel.Location = new System.Drawing.Point(177, 117);
            this.Fromlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Fromlabel.Name = "Fromlabel";
            this.Fromlabel.Size = new System.Drawing.Size(52, 20);
            this.Fromlabel.TabIndex = 2;
            this.Fromlabel.Text = "From";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerFrom.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(237, 119);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.MaxDate = new System.DateTime(2024, 12, 30, 0, 0, 0, 0);
            this.dateTimePickerFrom.MinDate = new System.DateTime(2024, 9, 29, 0, 0, 0, 0);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerFrom.TabIndex = 3;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerTo.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePickerTo.Location = new System.Drawing.Point(572, 119);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerTo.MinDate = new System.DateTime(2024, 9, 29, 0, 0, 0, 0);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(265, 22);
            this.dateTimePickerTo.TabIndex = 4;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // Tolabel
            // 
            this.Tolabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tolabel.AutoSize = true;
            this.Tolabel.BackColor = System.Drawing.Color.Transparent;
            this.Tolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tolabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Tolabel.Location = new System.Drawing.Point(534, 121);
            this.Tolabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Tolabel.Name = "Tolabel";
            this.Tolabel.Size = new System.Drawing.Size(30, 20);
            this.Tolabel.TabIndex = 5;
            this.Tolabel.Text = "To";
            // 
            // makeReservationbtn
            // 
            this.makeReservationbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.makeReservationbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(204)))));
            this.makeReservationbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makeReservationbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.makeReservationbtn.Location = new System.Drawing.Point(800, 572);
            this.makeReservationbtn.Margin = new System.Windows.Forms.Padding(4);
            this.makeReservationbtn.Name = "makeReservationbtn";
            this.makeReservationbtn.Size = new System.Drawing.Size(297, 58);
            this.makeReservationbtn.TabIndex = 7;
            this.makeReservationbtn.Text = "Book";
            this.makeReservationbtn.UseVisualStyleBackColor = false;
            this.makeReservationbtn.Click += new System.EventHandler(this.makeReservationbtn_Click);
            // 
            // roomsAvailableLabel
            // 
            this.roomsAvailableLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomsAvailableLabel.AutoSize = true;
            this.roomsAvailableLabel.BackColor = System.Drawing.Color.Transparent;
            this.roomsAvailableLabel.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsAvailableLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomsAvailableLabel.Location = new System.Drawing.Point(174, 287);
            this.roomsAvailableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomsAvailableLabel.Name = "roomsAvailableLabel";
            this.roomsAvailableLabel.Size = new System.Drawing.Size(269, 40);
            this.roomsAvailableLabel.TabIndex = 13;
            this.roomsAvailableLabel.Text = "Rooms available";
            // 
            // ToddlerLabel
            // 
            this.ToddlerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToddlerLabel.AutoSize = true;
            this.ToddlerLabel.BackColor = System.Drawing.Color.Transparent;
            this.ToddlerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToddlerLabel.ForeColor = System.Drawing.Color.White;
            this.ToddlerLabel.Location = new System.Drawing.Point(649, 170);
            this.ToddlerLabel.Name = "ToddlerLabel";
            this.ToddlerLabel.Size = new System.Drawing.Size(0, 22);
            this.ToddlerLabel.TabIndex = 16;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.searchButton.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(906, 117);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(191, 37);
            this.searchButton.TabIndex = 24;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // roomsAvailableTextBox
            // 
            this.roomsAvailableTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomsAvailableTextBox.Enabled = false;
            this.roomsAvailableTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsAvailableTextBox.Location = new System.Drawing.Point(181, 331);
            this.roomsAvailableTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomsAvailableTextBox.Multiline = true;
            this.roomsAvailableTextBox.Name = "roomsAvailableTextBox";
            this.roomsAvailableTextBox.Size = new System.Drawing.Size(916, 187);
            this.roomsAvailableTextBox.TabIndex = 11;
            this.roomsAvailableTextBox.TextChanged += new System.EventHandler(this.roomsAvailableTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(181, 576);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 57);
            this.button1.TabIndex = 25;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1326, 735);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.ToddlerLabel);
            this.Controls.Add(this.roomsAvailableLabel);
            this.Controls.Add(this.roomsAvailableTextBox);
            this.Controls.Add(this.makeReservationbtn);
            this.Controls.Add(this.Tolabel);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.Fromlabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Availability";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Fromlabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label Tolabel;
        private System.Windows.Forms.Button makeReservationbtn;
        private System.Windows.Forms.Label roomsAvailableLabel;
        private System.Windows.Forms.Label ToddlerLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox roomsAvailableTextBox;
        private System.Windows.Forms.Button button1;
    }
}


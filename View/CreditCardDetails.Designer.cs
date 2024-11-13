namespace Reservations
{
    partial class CreditCardDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditCardDetailsForm));
            this.CreditCardNumberTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CreditCardNumberLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.expTextBox = new System.Windows.Forms.TextBox();
            this.CVVLabel = new System.Windows.Forms.Label();
            this.CVVTextBox = new System.Windows.Forms.TextBox();
            this.CreditCardLabel = new System.Windows.Forms.Label();
            this.paybutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreditCardNumberTextBox
            // 
            this.CreditCardNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreditCardNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditCardNumberTextBox.Location = new System.Drawing.Point(215, 129);
            this.CreditCardNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CreditCardNumberTextBox.Multiline = true;
            this.CreditCardNumberTextBox.Name = "CreditCardNumberTextBox";
            this.CreditCardNumberTextBox.Size = new System.Drawing.Size(372, 34);
            this.CreditCardNumberTextBox.TabIndex = 13;
            this.CreditCardNumberTextBox.TextChanged += new System.EventHandler(this.CreditCardNumberTextBox_TextChanged);
            this.CreditCardNumberTextBox.Enter += new System.EventHandler(this.CreditCardNumberTextBox_Enter);
            this.CreditCardNumberTextBox.Leave += new System.EventHandler(this.CreditCardNumberTextBox_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(211, 189);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Expiration Date:";
            // 
            // CreditCardNumberLabel
            // 
            this.CreditCardNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreditCardNumberLabel.AutoSize = true;
            this.CreditCardNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreditCardNumberLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditCardNumberLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CreditCardNumberLabel.Location = new System.Drawing.Point(216, 101);
            this.CreditCardNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CreditCardNumberLabel.Name = "CreditCardNumberLabel";
            this.CreditCardNumberLabel.Size = new System.Drawing.Size(169, 24);
            this.CreditCardNumberLabel.TabIndex = 10;
            this.CreditCardNumberLabel.Text = "Credit Card Number:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 22;
            // 
            // expTextBox
            // 
            this.expTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.expTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expTextBox.Location = new System.Drawing.Point(215, 217);
            this.expTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.expTextBox.Multiline = true;
            this.expTextBox.Name = "expTextBox";
            this.expTextBox.Size = new System.Drawing.Size(170, 34);
            this.expTextBox.TabIndex = 24;
            this.expTextBox.Enter += new System.EventHandler(this.MonthTextBox_Enter);
            this.expTextBox.Leave += new System.EventHandler(this.MonthTextBox_Leave);
            // 
            // CVVLabel
            // 
            this.CVVLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CVVLabel.AutoSize = true;
            this.CVVLabel.BackColor = System.Drawing.Color.Transparent;
            this.CVVLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVVLabel.ForeColor = System.Drawing.Color.Transparent;
            this.CVVLabel.Location = new System.Drawing.Point(425, 189);
            this.CVVLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CVVLabel.Name = "CVVLabel";
            this.CVVLabel.Size = new System.Drawing.Size(42, 24);
            this.CVVLabel.TabIndex = 26;
            this.CVVLabel.Text = "cvv:";
            // 
            // CVVTextBox
            // 
            this.CVVTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CVVTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVVTextBox.Location = new System.Drawing.Point(429, 217);
            this.CVVTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CVVTextBox.Multiline = true;
            this.CVVTextBox.Name = "CVVTextBox";
            this.CVVTextBox.Size = new System.Drawing.Size(158, 34);
            this.CVVTextBox.TabIndex = 27;
            this.CVVTextBox.Enter += new System.EventHandler(this.CVVTextBox_Enter);
            this.CVVTextBox.Leave += new System.EventHandler(this.CVVTextBox_Leave);
            // 
            // CreditCardLabel
            // 
            this.CreditCardLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreditCardLabel.AutoSize = true;
            this.CreditCardLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreditCardLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditCardLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CreditCardLabel.Location = new System.Drawing.Point(296, 47);
            this.CreditCardLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CreditCardLabel.Name = "CreditCardLabel";
            this.CreditCardLabel.Size = new System.Drawing.Size(141, 31);
            this.CreditCardLabel.TabIndex = 28;
            this.CreditCardLabel.Text = "Credit Card ";
            // 
            // paybutton
            // 
            this.paybutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.paybutton.BackColor = System.Drawing.Color.LawnGreen;
            this.paybutton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paybutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paybutton.Location = new System.Drawing.Point(215, 304);
            this.paybutton.Margin = new System.Windows.Forms.Padding(4);
            this.paybutton.Name = "paybutton";
            this.paybutton.Size = new System.Drawing.Size(372, 44);
            this.paybutton.TabIndex = 29;
            this.paybutton.Text = "PAY";
            this.paybutton.UseVisualStyleBackColor = false;
            this.paybutton.Click += new System.EventHandler(this.paybutton_Click);
            // 
            // CreditCardDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(770, 463);
            this.Controls.Add(this.paybutton);
            this.Controls.Add(this.CreditCardLabel);
            this.Controls.Add(this.CVVTextBox);
            this.Controls.Add(this.CVVLabel);
            this.Controls.Add(this.expTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreditCardNumberTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CreditCardNumberLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreditCardDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreditCardDetails";
            this.Load += new System.EventHandler(this.CreditCardDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CreditCardNumberTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CreditCardNumberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox expTextBox;
        private System.Windows.Forms.Label CVVLabel;
        private System.Windows.Forms.TextBox CVVTextBox;
        private System.Windows.Forms.Label CreditCardLabel;
        private System.Windows.Forms.Button paybutton;
    }
}
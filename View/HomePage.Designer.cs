using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.guestButton = new System.Windows.Forms.Button();
            this.roomButton = new System.Windows.Forms.Button();
            this.reservationButton = new System.Windows.Forms.Button();
            this.bookingsButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLabel = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.searchBarPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.signOutButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.viewReportbutton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.searchBarPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // guestButton
            // 
            this.guestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.guestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.guestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guestButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestButton.ForeColor = System.Drawing.Color.White;
            this.guestButton.Image = ((System.Drawing.Image)(resources.GetObject("guestButton.Image")));
            this.guestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guestButton.Location = new System.Drawing.Point(0, 154);
            this.guestButton.Margin = new System.Windows.Forms.Padding(0);
            this.guestButton.MaximumSize = new System.Drawing.Size(605, 86);
            this.guestButton.Name = "guestButton";
            this.guestButton.Size = new System.Drawing.Size(516, 77);
            this.guestButton.TabIndex = 11;
            this.guestButton.Text = "Guests";
            this.guestButton.UseVisualStyleBackColor = false;
            this.guestButton.Click += new System.EventHandler(this.guestButton_Click_2);
            // 
            // roomButton
            // 
            this.roomButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.roomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomButton.ForeColor = System.Drawing.Color.White;
            this.roomButton.Image = ((System.Drawing.Image)(resources.GetObject("roomButton.Image")));
            this.roomButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roomButton.Location = new System.Drawing.Point(0, 77);
            this.roomButton.Margin = new System.Windows.Forms.Padding(0);
            this.roomButton.MaximumSize = new System.Drawing.Size(605, 86);
            this.roomButton.Name = "roomButton";
            this.roomButton.Size = new System.Drawing.Size(516, 77);
            this.roomButton.TabIndex = 12;
            this.roomButton.Text = "Rooms";
            this.roomButton.UseVisualStyleBackColor = false;
            this.roomButton.Click += new System.EventHandler(this.roomButton_Click_2);
            // 
            // reservationButton
            // 
            this.reservationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reservationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.reservationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reservationButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservationButton.ForeColor = System.Drawing.Color.White;
            this.reservationButton.Image = ((System.Drawing.Image)(resources.GetObject("reservationButton.Image")));
            this.reservationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reservationButton.Location = new System.Drawing.Point(0, 231);
            this.reservationButton.Margin = new System.Windows.Forms.Padding(0);
            this.reservationButton.MaximumSize = new System.Drawing.Size(605, 86);
            this.reservationButton.Name = "reservationButton";
            this.reservationButton.Size = new System.Drawing.Size(516, 80);
            this.reservationButton.TabIndex = 14;
            this.reservationButton.Text = "Create New Reservation";
            this.reservationButton.UseVisualStyleBackColor = false;
            this.reservationButton.Click += new System.EventHandler(this.reservationButton_Click);
            // 
            // bookingsButton
            // 
            this.bookingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.bookingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookingsButton.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingsButton.ForeColor = System.Drawing.Color.White;
            this.bookingsButton.Image = ((System.Drawing.Image)(resources.GetObject("bookingsButton.Image")));
            this.bookingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookingsButton.Location = new System.Drawing.Point(0, 0);
            this.bookingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.bookingsButton.MaximumSize = new System.Drawing.Size(605, 86);
            this.bookingsButton.Name = "bookingsButton";
            this.bookingsButton.Size = new System.Drawing.Size(516, 77);
            this.bookingsButton.TabIndex = 15;
            this.bookingsButton.Text = "Bookings";
            this.bookingsButton.UseVisualStyleBackColor = false;
            this.bookingsButton.Click += new System.EventHandler(this.bookingsButton_Click_2);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(204)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.ForeColor = System.Drawing.Color.White;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(158, 640);
            this.editButton.Margin = new System.Windows.Forms.Padding(0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(544, 58);
            this.editButton.TabIndex = 16;
            this.editButton.Text = "Edit Reservation";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Phumpla_Kamnandi.Properties.Resources.profile;
            this.pictureBox1.Location = new System.Drawing.Point(27, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchTextBox.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(3, 2);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(406, 32);
            this.searchTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "General";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(71, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name, Position";
            // 
            // tableLabel
            // 
            this.tableLabel.AutoSize = true;
            this.tableLabel.BackColor = System.Drawing.Color.Transparent;
            this.tableLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLabel.ForeColor = System.Drawing.Color.Transparent;
            this.tableLabel.Location = new System.Drawing.Point(52, 130);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(142, 32);
            this.tableLabel.TabIndex = 7;
            this.tableLabel.Text = "Bookings";
            this.tableLabel.Click += new System.EventHandler(this.tableLabel_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.leftPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftPanel.Controls.Add(this.searchBarPanel);
            this.leftPanel.Controls.Add(this.tableLayoutPanel2);
            this.leftPanel.Controls.Add(this.label1);
            this.leftPanel.Controls.Add(this.pictureBox1);
            this.leftPanel.Controls.Add(this.label3);
            this.leftPanel.Controls.Add(this.signOutButton);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(570, 735);
            this.leftPanel.TabIndex = 17;
            // 
            // searchBarPanel
            // 
            this.searchBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBarPanel.BackColor = System.Drawing.Color.Transparent;
            this.searchBarPanel.ColumnCount = 2;
            this.searchBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.86577F));
            this.searchBarPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.13423F));
            this.searchBarPanel.Controls.Add(this.SearchButton, 1, 0);
            this.searchBarPanel.Controls.Add(this.searchTextBox, 0, 0);
            this.searchBarPanel.Location = new System.Drawing.Point(27, 175);
            this.searchBarPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchBarPanel.Name = "searchBarPanel";
            this.searchBarPanel.RowCount = 1;
            this.searchBarPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.searchBarPanel.Size = new System.Drawing.Size(516, 27);
            this.searchBarPanel.TabIndex = 20;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.SearchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SearchButton.BackgroundImage")));
            this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Location = new System.Drawing.Point(412, 0);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(104, 27);
            this.SearchButton.TabIndex = 21;
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.bookingsButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.roomButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.guestButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.reservationButton, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(27, 241);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(516, 311);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // signOutButton
            // 
            this.signOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(204)))));
            this.signOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signOutButton.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signOutButton.ForeColor = System.Drawing.Color.White;
            this.signOutButton.Image = ((System.Drawing.Image)(resources.GetObject("signOutButton.Image")));
            this.signOutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signOutButton.Location = new System.Drawing.Point(27, 640);
            this.signOutButton.Margin = new System.Windows.Forms.Padding(0);
            this.signOutButton.MaximumSize = new System.Drawing.Size(610, 98);
            this.signOutButton.Name = "signOutButton";
            this.signOutButton.Size = new System.Drawing.Size(516, 58);
            this.signOutButton.TabIndex = 16;
            this.signOutButton.Text = "Sign Out";
            this.signOutButton.UseVisualStyleBackColor = false;
            this.signOutButton.Click += new System.EventHandler(this.signOutButton_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(58, 178);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(698, 452);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.rightPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightPanel.Controls.Add(this.viewReportbutton);
            this.rightPanel.Controls.Add(this.tableLabel);
            this.rightPanel.Controls.Add(this.listView);
            this.rightPanel.Controls.Add(this.editButton);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(570, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(795, 735);
            this.rightPanel.TabIndex = 18;
            // 
            // viewReportbutton
            // 
            this.viewReportbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewReportbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewReportbutton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.viewReportbutton.Location = new System.Drawing.Point(607, 23);
            this.viewReportbutton.Name = "viewReportbutton";
            this.viewReportbutton.Size = new System.Drawing.Size(149, 31);
            this.viewReportbutton.TabIndex = 18;
            this.viewReportbutton.Text = "View Reports";
            this.viewReportbutton.UseVisualStyleBackColor = true;
            this.viewReportbutton.Click += new System.EventHandler(this.viewReportbutton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.78482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.21518F));
            this.tableLayoutPanel1.Controls.Add(this.leftPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rightPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 735F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1365, 735);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1365, 735);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load_2);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.searchBarPanel.ResumeLayout(false);
            this.searchBarPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private Button guestButton;
        private Button roomButton;
        private Button reservationButton;
        private Button bookingsButton;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox searchTextBox;
        private Label label3;
        private Label tableLabel;
        private Button editButton;
        private Button signOutButton;
        private Panel leftPanel;
        private ListView listView;
        private Panel rightPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel searchBarPanel;
        private Button SearchButton;
        private ContextMenuStrip contextMenuStrip2;
        private Button viewReportbutton;
    }
}
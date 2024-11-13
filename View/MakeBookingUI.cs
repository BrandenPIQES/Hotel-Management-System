using Phumla_Kamnandi;
using Phumpla_Kamnandi.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumpla_Kamnandi.View
{
    public partial class MakeBookingUI : Form
    {
        #region Variable Declaration
        private int childFormNumber = 0;
        signInForm signInForm;
        HomePage homePage;
        EmployeeController employeeController;
        #endregion

        public MakeBookingUI()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;   
            employeeController = new EmployeeController();

            fileMenu.Visible = false;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {

        }

        private void OpenFile(object sender, EventArgs e)
        {

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MakeBookingUI_Load(object sender, EventArgs e)
        {
            // Create an instance of the login form
            signInForm signIn = new signInForm();

            signIn.MdiParent = this;
            signIn.WindowState = FormWindowState.Normal; 
            signIn.Show();

            signIn.LoginSuccessful += OnLoginSuccessful;

        }

        private void OnLoginSuccessful(object sender, EventArgs e)
        {
            // Enable or show the combo box once the user is logged in
            fileMenu.Visible = true; // or menucomboBox.Visible = true;
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            // If no instance of HomePage is found, create and show a new one
            HomePage homePage = new HomePage();
            homePage.MdiParent = this.MdiParent;
            homePage.WindowState = FormWindowState.Normal;
            homePage.Show();
        }
    }
}

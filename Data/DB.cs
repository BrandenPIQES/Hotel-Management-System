/*
 * This class includes basic methods for connecting
 * ti the database, filling the dataset, and updating
 * the dataset
 */


using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Phumpla_Kamnandi.Properties;

namespace Phumpla_Kamnandi.Data
{
    public class DB
    {
        #region Variable Declaration
        private string strConn = Settings.Default.PhumlaKamndaniDatabaseConnectionString;
        //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\mickey\\Downloads\\Group_35_Semester_Project\\Phumpla Kamnandi\\PhumlaKamndaniDatabase.mdf\";Integrated Security=True;Connect Timeout=30";

        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        public enum DBOperation { 
            Add = 0,
            Edit = 1,
            Delete = 2,
        }
        #endregion


        #region Constructor
        public DB() {
            try
            {
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
                daMain = new SqlDataAdapter();
            }
            catch (Exception e) {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
                return;
            }
        }
        #endregion

        #region Fill Dataset
        public void FillDataSet(string sqlQuery, string table)
        {
            // Fill the dataset from the database using a SQL query for a specific table
            try
            {
                daMain = new SqlDataAdapter(sqlQuery, cnMain);
                
                dsMain.Clear();
                cnMain.Open();

                daMain.Fill(dsMain, table);
                cnMain.Close();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message + "  " + e.StackTrace);
            }
        }
        #endregion

        #region Update the data source
        protected bool UpdateDataSource(string sqlLocal, string table) {
            bool success;
            try {
                //open the connection
                cnMain.Open();
                //***update the database table via the data adapter
                Console.WriteLine(daMain.InsertCommand.CommandText);
                daMain.Update(dsMain, table);
                //---close the connection
                cnMain.Close();
                //refresh the dataset
                FillDataSet(sqlLocal, table);
                success = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "  " + e.StackTrace);
                success = false;
            }
            return success;
        }
        #endregion


    }


}

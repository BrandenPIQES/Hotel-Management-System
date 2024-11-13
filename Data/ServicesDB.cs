using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumpla_Kamnandi.Application;

namespace Phumpla_Kamnandi.Data
{
    public class ServicesDB : DB
    {
        #region Data Members
        private string table = "Services";
        private string sqlLocal = "SELECT * FROM Services";
        private Collection<Service> services;
        #endregion

        #region Property Methods
        public Collection<Service> AllServices
        {
            get { return services; }
        }
        #endregion

        #region Constructor
        public ServicesDB() : base()
        {
            services = new Collection<Service>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }
        #endregion

        #region Utility Methods
        private void Add2Collection()
        {
            DataRow myRow = null;
            Service aService;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    aService = new Service();
                    aService.ServiceId = Convert.ToInt32(myRow["ServiceId"]);
                    aService.ServiceName = Convert.ToString(myRow["ServiceName"]).Trim();
                    aService.ServiceCost = Convert.ToDecimal(myRow["ServiceCost"]);

                    services.Add(aService);
                }
            }
        }

        private void FillRow(DataRow row, Service aService, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                row["ServiceId"] = aService.ServiceId;
            }
            row["ServiceName"] = aService.ServiceName;
            row["ServiceCost"] = aService.ServiceCost;
        }

        private int FindRow(Service aService, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
            {
                myRow = myRow_;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (aService.ServiceId == Convert.ToInt32(dsMain.Tables[table].Rows[rowIndex]["ServiceId"]))
                    {
                        returnValue = rowIndex;
                        break;
                    }
                }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Service aService, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[table].NewRow();
                    FillRow(aRow, aService, operation);
                    dsMain.Tables[table].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[table].Rows[FindRow(aService, table)];
                    FillRow(aRow, aService, operation);
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        public bool UpdateDataSource(Service aService)
        {
            bool success = true;
            Create_INSERT_Command(aService);
            Create_UPDATE_Command(aService);
            success = UpdateDataSource(sqlLocal, table);
            return success;
        }

        private void Build_INSERT_Parameters(Service aService)
        {
            SqlParameter param = new SqlParameter("@ServiceId", SqlDbType.Int, 0, "ServiceId");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceName", SqlDbType.NVarChar, 100, "ServiceName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceCost", SqlDbType.Money, 0, "ServiceCost");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Service aService)
        {
            daMain.InsertCommand = new SqlCommand(
                "INSERT INTO Services (ServiceId, ServiceName, ServiceCost) " +
                "VALUES (@ServiceId, @ServiceName, @ServiceCost)", cnMain);
            Build_INSERT_Parameters(aService);
        }

        private void Build_UPDATE_Parameters(Service aService)
        {
            SqlParameter param = new SqlParameter("@ServiceName", SqlDbType.NVarChar, 100, "ServiceName");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceCost", SqlDbType.Money, 0, "ServiceCost");
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceId", SqlDbType.Int, 0, "ServiceId");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Command(Service aService)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE Services SET ServiceName = @ServiceName, ServiceCost = @ServiceCost " +
                "WHERE ServiceId = @ServiceId", cnMain);
            Build_UPDATE_Parameters(aService);
        }
        #endregion
    }
}

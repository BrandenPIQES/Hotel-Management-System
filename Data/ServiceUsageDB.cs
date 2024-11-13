using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumpla_Kamnandi.Application;

namespace Phumpla_Kamnandi.Data
{
    public class ServiceUsageDB : DB
    {
        #region Data Members
        private string table = "ServiceUsage";
        private string sqlLocal = "SELECT * FROM ServiceUsage";
        private Collection<ServiceUsage> serviceUsages;
        #endregion

        #region Property Methods
        public Collection<ServiceUsage> AllServiceUsages
        {
            get { return serviceUsages; }
        }
        #endregion

        #region Constructor
        public ServiceUsageDB() : base()
        {
            serviceUsages = new Collection<ServiceUsage>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }
        #endregion

        #region Utility Methods
        private void Add2Collection()
        {
            DataRow myRow = null;
            ServiceUsage aUsage;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    aUsage = new ServiceUsage();
                    aUsage.ServiceUsageId = Convert.ToString(myRow["ServiceUsageId"]).Trim();
                    aUsage.ReservationId = Convert.ToString(myRow["ReservationId"]).Trim();
                    aUsage.ServiceId = Convert.ToInt32(myRow["ServiceId"]);
                    aUsage.Quantity = Convert.ToInt32(myRow["Quantity"]);
                    aUsage.UsageDate = Convert.ToDateTime(myRow["UsageDate"]);
                    aUsage.TotalCost = Convert.ToDecimal(myRow["TotalCost"]);

                    serviceUsages.Add(aUsage);
                }
            }
        }

        private void FillRow(DataRow row, ServiceUsage aUsage, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                row["ServiceUsageId"] = aUsage.ServiceUsageId;
            }
            row["ReservationId"] = aUsage.ReservationId;
            row["ServiceId"] = aUsage.ServiceId;
            row["Quantity"] = aUsage.Quantity;
            row["UsageDate"] = aUsage.UsageDate;
            row["TotalCost"] = aUsage.TotalCost;
        }

        private int FindRow(ServiceUsage aUsage, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
            {
                myRow = myRow_;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (aUsage.ServiceUsageId == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ServiceUsageId"]))
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
        public void DataSetChange(ServiceUsage aUsage, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[table].NewRow();
                    FillRow(aRow, aUsage, operation);
                    dsMain.Tables[table].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[table].Rows[FindRow(aUsage, table)];
                    FillRow(aRow, aUsage, operation);
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        public bool UpdateDataSource(ServiceUsage aUsage)
        {
            bool success = true;
            Create_INSERT_Command(aUsage);
            Create_UPDATE_Command(aUsage);
            success = UpdateDataSource(sqlLocal, table);
            return success;
        }

        private void Build_INSERT_Parameters(ServiceUsage aUsage)
        {
            SqlParameter param = new SqlParameter("@ServiceUsageId", SqlDbType.NChar, 5, "ServiceUsageId");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationId", SqlDbType.NChar, 5, "ReservationId");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceId", SqlDbType.Int, 0, "ServiceId");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int, 0, "Quantity");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@UsageDate", SqlDbType.DateTime, 0, "UsageDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@TotalCost", SqlDbType.Money, 0, "TotalCost");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(ServiceUsage aUsage)
        {
            daMain.InsertCommand = new SqlCommand(
                "INSERT INTO ServiceUsage (ServiceUsageId, ReservationId, ServiceId, Quantity, UsageDate, TotalCost) " +
                "VALUES (@ServiceUsageId, @ReservationId, @ServiceId, @Quantity, @UsageDate, @TotalCost)", cnMain);
            Build_INSERT_Parameters(aUsage);
        }

        private void Build_UPDATE_Parameters(ServiceUsage aUsage)
        {
            SqlParameter param = new SqlParameter("@ReservationId", SqlDbType.NChar, 5, "ReservationId");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceId", SqlDbType.Int, 0, "ServiceId");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Quantity", SqlDbType.Int, 0, "Quantity");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@UsageDate", SqlDbType.DateTime, 0, "UsageDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@TotalCost", SqlDbType.Money, 0, "TotalCost");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ServiceUsageId", SqlDbType.NChar, 5, "ServiceUsageId");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Command(ServiceUsage aUsage)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE ServiceUsage SET ReservationId = @ReservationId, ServiceId = @ServiceId, Quantity = @Quantity, " +
                "UsageDate = @UsageDate, TotalCost = @TotalCost WHERE ServiceUsageId = @ServiceUsageId", cnMain);
            Build_UPDATE_Parameters(aUsage);
        }
        #endregion
    }
}

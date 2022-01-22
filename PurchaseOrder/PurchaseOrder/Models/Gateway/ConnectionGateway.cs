using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PurchaseOrder.Models.Gateway
{
    public class ConnectionGateway
    {
        private static readonly SqlConnectionStringBuilder DBConnection =
            new SqlConnectionStringBuilder
            {
                DataSource = "PurchaseOrderAppDb.mssql.somee.com",
                InitialCatalog = "PurchaseOrderAppDb",
                IntegratedSecurity = false,
                UserID = "nabilYunusco_SQLLogin_1",
                Password = "m8d2e4cf69",
                PersistSecurityInfo = false,
                Pooling = true,
                MultipleActiveResultSets = true


            };

        public static IDbConnection DbConnection = new SqlConnection(DBConnection.ConnectionString);
    }
}
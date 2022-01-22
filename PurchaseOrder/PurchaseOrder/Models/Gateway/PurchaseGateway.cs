using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Threading.Tasks;
using System.Data;

namespace PurchaseOrder.Models.Gateway
{
    public class PurchaseGateway : ConnectionGateway
    {
        public static async Task<int> SavePurchaseRequest(PurchaseRequestBodyModel requestBody)
        {
            try
            {
                DbConnection.Open();
                

                PurchaseGateway purchaseGateway = new PurchaseGateway();
                DataTable dtTable = ConvertListToDataTable.ConvertToDataTable(requestBody.Item);
               
                int rows = 0;
                var message = await DbConnection.QueryAsync<int>(
                          sql: @"[dbo].[USP_SaveRequisitionRequest]",
                           new
                           {
                               PurchaseCode = requestBody.PurchaseCode,
                               PurchaseDate = requestBody.PurchaseDate,
                               Supplier = requestBody.Supplier,
                               ItemList = dtTable.AsTableValuedParameter("[dbo].[ItemListTVP] ")
                               
                           },
                          commandType: CommandType.StoredProcedure
                          );
                if (message.FirstOrDefault() == 1)
                {
                    rows = 1;
                }
                return rows;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                DbConnection.Close();

            }
        }
    }
}
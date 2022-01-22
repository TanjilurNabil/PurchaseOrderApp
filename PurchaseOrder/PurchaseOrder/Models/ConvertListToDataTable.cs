using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PurchaseOrder.Models
{
    public class ConvertListToDataTable
    {
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> listToConvert)
        {
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dataTable = new DataTable();
            foreach (var eachPropertyInfo in propertyInfo)
            {
                dataTable.Columns.Add(eachPropertyInfo.Name);
            }
            foreach (var eachObject in listToConvert)
            {
                var dataRow = dataTable.NewRow();
                try
                {
                    foreach (var eachPropertyInfo in propertyInfo)
                    {
                        dataRow[eachPropertyInfo.Name] = eachPropertyInfo.GetValue(eachObject, null);
                    }
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
    }
}
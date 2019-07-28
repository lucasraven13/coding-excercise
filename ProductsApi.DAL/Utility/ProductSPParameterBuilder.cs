using System;
using System.Data.SqlClient;

namespace ProductsApi.DAL.Utility
{
    public static class ProductSPParameterBuilder
    {
        public static SqlParameter GetSelectAllParameters()
        {
            return new SqlParameter("@Action", "SelectAll");
        }

        public static SqlParameter[] GetSelectOneParameters(int productId)
        {
            return new SqlParameter[]{
                new SqlParameter("@Action", "SelectOne"),
                new SqlParameter("@ProductID", productId)
            };
        }
        public static SqlParameter GetSelectActiveParameters()
        {
            return new SqlParameter("@Action", "SelectActive");
        }

        public static SqlParameter[] GetAddNewParameters(string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@Action", "AddNew"),
                new SqlParameter{
                    ParameterName = "@ProductID",
                    DbType = System.Data.DbType.Int32,
                    Value = 0
                },
                new SqlParameter("@ProductName", productName),
                new SqlParameter("@SupplierID", supplierId),
                new SqlParameter("@CategoryID", categoryId),
                new SqlParameter("@QuantityPerUnit", quantityPerUnit),
                new SqlParameter("@UnitPrice", unitPrice),
                new SqlParameter("@UnitsInStock", (short)unitsInStock),
                new SqlParameter("@UnitsOnOrder", (short)unitsOnOrder),
                new SqlParameter("@ReorderLevel", (short)reorderLevel),
                new SqlParameter("@Discontinued", (short)(discontinued ? 1 : 0)),
                new SqlParameter{
                    ParameterName = "@returnVal",
                    DbType = System.Data.DbType.Int32,
                    Direction = System.Data.ParameterDirection.Output
                }
            };
            return parameters;
        }

        public static SqlParameter[] GetUpdateParameters(int productId,
            string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued)
        {
            return new SqlParameter[]{
                 new SqlParameter("@Action", "Update"),
                 new SqlParameter("@ProductID", productId),
                 new SqlParameter("@ProductName", productName),
                 new SqlParameter("@SupplierID", supplierId),
                 new SqlParameter("@CategoryID", categoryId),
                 new SqlParameter("@QuantityPerUnit", quantityPerUnit),
                 new SqlParameter("@UnitPrice", unitPrice),
                 new SqlParameter("@UnitsInStock", (short)unitsInStock),
                 new SqlParameter("@UnitsOnOrder", (short)unitsOnOrder),
                 new SqlParameter("@ReorderLevel", (short)reorderLevel),
                 new SqlParameter("@Discontinued", discontinued ? 1 : 0)
            };
        }

        public static SqlParameter[] GetDeleteParameters(int productId)
        {
            return new SqlParameter[] {
                new SqlParameter("@Action", "Delete"),
                new SqlParameter("@ProductID", productId)
            };
        }
    }
}
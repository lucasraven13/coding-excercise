using System;
using ProductsApi.DAL.Intrefaces;
using ProductsApi.DAL.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProductsApi.DAL.Utility;
using System.Data.Common;
using System.Data;

namespace ProductsApi.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Product>> SelectAllAsync()
        {
            return await _dataContext.SP_Products
                .FromSql(ProductSPCommands.SELECT_ALL_COMMAND,
                        ProductSPParameterBuilder.GetSelectAllParameters())
                .ToListAsync();
        }
        public async Task<Product> SelectProductByIdAsync(int id)
        {
            return await _dataContext.SP_Products
                .FromSql(ProductSPCommands.SELECT_ONE_COMMAND,
                        ProductSPParameterBuilder.GetSelectOneParameters(id))
                .SingleOrDefaultAsync();
        }
        public async Task<List<Product>> SelectActiveAsync()
        {
            return await _dataContext.SP_Products
               .FromSql(ProductSPCommands.SELECT_ACTIVE_COMMAND,
                       ProductSPParameterBuilder.GetSelectActiveParameters())
               .ToListAsync();
        }
        public async Task<int> AddNewAsync(string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            decimal unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued)
        {

            DbConnection connection = _dataContext.Database.GetDbConnection();
            using (DbCommand cmd = connection.CreateCommand())
            {

                cmd.CommandText = ProductSPCommands.ADD_NEW_COMMAND;
                var sqlparameters = ProductSPParameterBuilder.GetAddNewParameters(productName, supplierId, categoryId, quantityPerUnit,
                               unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                foreach (var parameter in sqlparameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                if (connection.State.Equals(ConnectionState.Closed)) { connection.Open(); }

                return Decimal.ToInt32((decimal)await cmd.ExecuteScalarAsync());
            }
        }
        public async Task<int> UpdateAsync(int productId,
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
            return await _dataContext.Database
                .ExecuteSqlCommandAsync(ProductSPCommands.UPDATE_COMMAND,
                ProductSPParameterBuilder.GetUpdateParameters(productId, productName, supplierId, categoryId, quantityPerUnit,
                   unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued));
        }
        public async Task DeleteAsync(int productId)
        {
            DbConnection connection = _dataContext.Database.GetDbConnection();
            using (DbCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = ProductSPCommands.DELETE_COMMAND;
                var sqlparameters = ProductSPParameterBuilder.GetDeleteParameters(productId);
                foreach (var parameter in sqlparameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                if (connection.State.Equals(ConnectionState.Closed)) { connection.Open(); }

                await cmd.ExecuteScalarAsync();
            }
        }
    }
}
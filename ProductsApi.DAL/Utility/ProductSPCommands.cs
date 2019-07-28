namespace ProductsApi.DAL.Utility
{

    public static class ProductSPCommands
    {
        const string STORED_PROCEDURE_NAME = "sp_Products";
        public static readonly string SELECT_ALL_COMMAND = $"EXECUTE {STORED_PROCEDURE_NAME} @Action";
        public static readonly string SELECT_ONE_COMMAND = $"EXECUTE {STORED_PROCEDURE_NAME} @Action, @ProductId";
        public static readonly string SELECT_ACTIVE_COMMAND = $"EXECUTE {STORED_PROCEDURE_NAME} @Action";
        public static readonly string ADD_NEW_COMMAND = $"EXECUTE @returnVal = {STORED_PROCEDURE_NAME} @Action,  @ProductID, @ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued";
        public static readonly string UPDATE_COMMAND =  $"EXECUTE {STORED_PROCEDURE_NAME} @Action, @ProductID, @ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued";
        public static readonly string DELETE_COMMAND = $"EXECUTE {STORED_PROCEDURE_NAME} @Action, @ProductId";
    }
}
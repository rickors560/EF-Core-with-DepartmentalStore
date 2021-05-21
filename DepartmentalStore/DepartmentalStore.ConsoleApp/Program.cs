using System;

namespace DepartmentalStore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextManager contextManager = new ContextManager();

            //AddingData
            //contextManager.AddGenders();
            //contextManager.AddMultipleStaffWithRoleAndAddress();
            //contextManager.AddMultipleCategories();
            //contextManager.AddMultipleProducts();
            //contextManager.AddProductsToCategories();
            //contextManager.AddPricesToProducts();
            //contextManager.AddInventoryQuantities();
            //contextManager.AddSuppliersWithAddress();
            //contextManager.AddOrdersWithDetails();


            //Query Staff
            //contextManager.QueryStaffWithFirstName("Chris");
            //contextManager.QueryStaffWithPhoneNumber("9456517812");
            //contextManager.QueryStaffWithRole("Gaurd");

            //Query Product
            //contextManager.QueryProductWithName("Pen");
            //contextManager.QueryProductWithCategory("Stationary");
            //contextManager.QueryProductWithInStock(false);
            //contextManager.QueryProductWithSellipnPrice(100);

            //Number of Products out of stock
            //contextManager.QueryNumberOfOutofStockProducts();

            //Number of Products WithIn a Category
            //contextManager.QueryNumberOfProductsInCategory();

            //Query Supplier
            //contextManager.QuerySupplierWithFirstName("Ross");
            //contextManager.QuerySupplierWithPhone("6789451752");
            //contextManager.QuerySupplierWithAddress("Arizona", "New York");

            //Query Product Order with Supplier
            //contextManager.QueryProductOrderWithSupplier();
            //contextManager.QueryProductOrderWithSupplierWithProductName("Pen");
            //contextManager.QueryProductOrderWithSupplierWithSupplierFirstName("Ross");
            //contextManager.QueryProductOrderWithSupplierWithProductShortCode("MKR");
            //contextManager.QueryProductOrderWithSupplierWithOrderDate(2021, 01, 10);
            //contextManager.QueryProductOrderWithSupplierLessThanInventoryQuantity();
        }
    }
}
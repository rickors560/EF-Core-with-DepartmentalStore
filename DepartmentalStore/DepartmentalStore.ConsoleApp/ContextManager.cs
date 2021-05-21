using DepartmentalStore.Context;
using DepartmentalStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DepartmentalStore.ConsoleApp
{
    public class ContextManager
    {
        private DepartmentalStoreContext _context;
        public void AddGenders()
        {
            var male = new Gender { Name = "Male" };
            var female = new Gender { Name = "Female" };
            using (_context = new DepartmentalStoreContext())
            {
                _context.Gender.AddRange(male, female);
                _context.SaveChanges();
            }
        }
        public void AddMultipleStaffWithRoleAndAddress()
        {
            var staffs = new List<Staff> {
                new Staff{
                    FirstName = "Bryant", LastName = "Miller", PhoneNumber = "9456517812", Email = "bryant.miller@gmail.com", GenderId = 1 , Salary = 25000,
                    Address = new Address{ AddressLine1 = "140 Werninger Street", City = "Houston", State = "Texas", Pincode = "77032" },
                    Role = new Role { Name = "Cashier", Description = "Manages bills and cash" }
                },
                new Staff{
                    FirstName = "Chris", LastName = "Badman", PhoneNumber = "7845912634", Email = "chris.badman@gmail.com", GenderId = 1 ,  Salary = 50000,
                    Address = new Address{ AddressLine1 = "1440 Eagle Drive", City = "Detroit", State = "Michigan", Pincode = "48226" },
                    Role = new Role { Name = "Store Manager", Description = "Manager of the store" }
                },
                new Staff{
                    FirstName = "Georgie", LastName = "Nguyen", PhoneNumber = "6578412937", Email = "georgie.nguyen@gmail.com", GenderId = 2 , Salary = 18000,
                    Address = new Address{ AddressLine1 = "706 Flint Street", AddressLine2 = "Near St. Cruiz Church", City = "Atlanta", State = "Georgia", Pincode = "30303" },
                    Role = new Role { Name = "Inventory Controller", Description = "Controls the inventory" }
                },
                new Staff{
                    FirstName = "Stewart", LastName = "Dittman", PhoneNumber = "8789456123", Email = "stewart.dittman@gmail.com", GenderId = 1 , Salary = 30000,
                    Address = new Address{ AddressLine1 = "3459 Zappia Drive", City = "Lakeside Park", State = "Kentucky", Pincode = "41017" },
                    Role = new Role { Name = "Sales Associate", Description = "Makes sure sales must go high" }
                },
                new Staff{
                    FirstName = "Christine", LastName = "Malone", PhoneNumber = "9247561438", Email = "christine.malone@gmail.com", GenderId = 2 , Salary = 12000,
                    Address = new Address{ AddressLine1 = "28 Ross Street", City = "Belleville", State = "Illinois", Pincode = "62220" },
                    Role = new Role { Name = "Gaurd", Description = "For security of the store" }
                },
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Staff.AddRange(staffs);
                _context.SaveChanges();
            }
        }
        public void AddMultipleCategories()
        {
            var categories = new List<Category> {
                new Category { Name = "Dairy", ShortCode = "DRY" },
                new Category { Name = "Cosmetics", ShortCode = "COMS"},
                new Category { Name = "Electronics", ShortCode = "ECTR"},
                new Category { Name = "Furniture", ShortCode = "FRNT"},
                new Category { Name = "Stationary", ShortCode = "STNY"}
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Category.AddRange(categories);
                _context.SaveChanges();
            }
        }
        public void AddMultipleProducts()
        {
            var products = new List<Product>{
                new Product { Name = "Milk", ShortCode = "MLK", Manufacturer = "Amul", Quantity = 12 },
                new Product { Name = "Eyeliner", ShortCode = "EYLN", Manufacturer = "Nyka", Quantity = 2 },
                new Product { Name = "Pen", ShortCode = "PEN", Manufacturer = "Cello", Quantity = 50 },
                new Product { Name = "Pencil", ShortCode = "PNCL", Manufacturer = "Natraj", Quantity = 15 },
                new Product { Name = "Table", ShortCode = "TBL", Manufacturer = "'My Furniture.com", Quantity = 4 },
                new Product { Name = "Chair", ShortCode = "CH", Manufacturer = "Furnitures@99", Quantity = 10 },
                new Product { Name = "Fan", ShortCode = "FAN", Manufacturer = "Philips", Quantity = 3 },
                new Product { Name = "Motor", ShortCode = "MTR", Manufacturer = "Crompton", Quantity = 8 },
                new Product { Name = "LED", ShortCode = "LED", Manufacturer = "Bajaj", Quantity = 25 },
                new Product { Name = "Marker", ShortCode = "MKR", Manufacturer = "Reynolds", Quantity = 45 }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Product.AddRange(products);
                _context.SaveChanges();
            }
        }
        public void AddProductsToCategories()
        {
            var productCategories = new List<ProductCategory> {
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 2 },
                new ProductCategory { ProductId = 3, CategoryId = 5 },
                new ProductCategory { ProductId = 4, CategoryId = 5 },
                new ProductCategory { ProductId = 5, CategoryId = 4 },
                new ProductCategory { ProductId = 6, CategoryId = 4 },
                new ProductCategory { ProductId = 7, CategoryId = 3 },
                new ProductCategory { ProductId = 8, CategoryId = 3 },
                new ProductCategory { ProductId = 9, CategoryId = 3 },
                new ProductCategory { ProductId = 10, CategoryId = 5 }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.ProductCategory.AddRange(productCategories);
                _context.SaveChanges();
            }
        }
        public void AddPricesToProducts()
        {
            var prices = new List<Price>{
                new Price { ProductId = 1, CostPrice = 18, SellingPrice = 22, EffectiveDate = new DateTime(2015, 04, 01) },
                new Price { ProductId = 1, CostPrice = 20, SellingPrice = 24, EffectiveDate = new DateTime(2020, 01, 01) },
                new Price { ProductId = 2, CostPrice = 100, SellingPrice = 120, EffectiveDate = new DateTime(2021, 01, 01) },
                new Price { ProductId = 3, CostPrice = 15, SellingPrice = 15, EffectiveDate = new DateTime(2021, 01, 01) },
                new Price { ProductId = 4, CostPrice = 2, SellingPrice = 5, EffectiveDate = new DateTime(2010, 01, 01) },
                new Price { ProductId = 5, CostPrice = 5000, SellingPrice = 5700, EffectiveDate = new DateTime(2021, 03, 01) },
                new Price { ProductId = 6, CostPrice = 1600, SellingPrice = 2000, EffectiveDate = new DateTime(2021, 02, 01) },
                new Price { ProductId = 7, CostPrice = 700, SellingPrice = 950, EffectiveDate = new DateTime(2020, 12, 01) },
                new Price { ProductId = 8, CostPrice = 1800, SellingPrice = 2000, EffectiveDate = new DateTime(2020, 09, 01) },
                new Price { ProductId = 9, CostPrice = 25000, SellingPrice = 27000, EffectiveDate = new DateTime(2021, 02, 01) },
                new Price { ProductId = 10, CostPrice = 25, SellingPrice = 25, EffectiveDate = new DateTime(2015, 08, 01) }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Price.AddRange(prices);
                _context.SaveChanges();
            }
        }
        public void AddInventoryQuantities()
        {
            var inventory = new List<Inventory>{
                new Inventory { ProductId = 1, InventoryQuantity = 24 },
                new Inventory { ProductId = 2, InventoryQuantity = 20 },
                new Inventory { ProductId = 3, InventoryQuantity = 100 },
                new Inventory { ProductId = 4, InventoryQuantity = 41 },
                new Inventory { ProductId = 5, InventoryQuantity = 39 },
                new Inventory { ProductId = 6, InventoryQuantity = 72 },
                new Inventory { ProductId = 7, InventoryQuantity = 30 },
                new Inventory { ProductId = 8, InventoryQuantity = 65 },
                new Inventory { ProductId = 9, InventoryQuantity = 80 },
                new Inventory { ProductId = 10, InventoryQuantity = 25 }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Inventory.AddRange(inventory);
                _context.SaveChanges();
            }
        }
        public void AddSuppliersWithAddress()
        {
            var suppliers = new List<Supplier> {
                new Supplier{ FirstName = "Celeste", LastName = "Gilbert", PhoneNumber = "7475913258", Email = "celeste.gilbert@amazon.com", GenderId = 1,
                    Address = new  Address { AddressLine1 = "3492 Elmwood Avenue", City = "Scottsdale", State = "Arizona", Pincode = "85251" } },
                new Supplier{ FirstName = "Ross", LastName = "Matthews", PhoneNumber = "9147539286", Email = "ross.matthews@flipkart.com", GenderId = 1,
                    Address = new  Address { AddressLine1 = "4835 Crim Lane", City = "Medway", State = "Ohio", Pincode = "45341" } },
                new Supplier{ FirstName = "Nina", LastName = "Wells", PhoneNumber = "6789451752", Email = "nina.wells@wallmart.com", GenderId = 2,
                    Address = new  Address { AddressLine1 = "3637 Clover Drive", City = "Colorado Springs", State = "Colorado", Pincode = "45341" } }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Supplier.AddRange(suppliers);
                _context.SaveChanges();
            }
        }
        public void AddOrdersWithDetails()
        {
            var orders = new List<Order>{
                new Order{ SupplierId = 2, OrderDate = new DateTime(2021, 05, 13),
                    OrderDetails = new List<OrderDetail>{
                        new OrderDetail { OrderId = 1, ProductId = 10, Quantity = 3 },
                        new OrderDetail { OrderId = 1, ProductId = 3, Quantity = 10 },
                        new OrderDetail { OrderId = 1, ProductId = 4, Quantity = 1 }
                    }
                },
                new Order{ SupplierId = 3, OrderDate = new DateTime(2020, 12, 25),
                    OrderDetails = new List<OrderDetail>{
                        new OrderDetail { OrderId = 2, ProductId = 5, Quantity = 1 },
                        new OrderDetail { OrderId = 2, ProductId = 6, Quantity = 2 }
                    }
                },
                new Order{ SupplierId = 1, OrderDate = new DateTime(2021, 01, 14),
                    OrderDetails = new List<OrderDetail>{
                        new OrderDetail { OrderId = 3, ProductId = 9, Quantity = 2 },
                        new OrderDetail { OrderId = 3, ProductId = 1, Quantity = 30 },
                    }
                },
                new Order{ SupplierId = 2, OrderDate = new DateTime(2021, 02, 04),
                    OrderDetails = new List<OrderDetail>{
                        new OrderDetail { OrderId = 4, ProductId = 1, Quantity = 2 },
                        new OrderDetail { OrderId = 4, ProductId = 3, Quantity = 2 },
                        new OrderDetail { OrderId = 4, ProductId = 8, Quantity = 1 },
                        new OrderDetail { OrderId = 4, ProductId = 10, Quantity = 2 }
                    }
                }
            };

            using (_context = new DepartmentalStoreContext())
            {
                _context.Order.AddRange(orders);
                _context.SaveChanges();
            }
        }


        public void QueryStaffWithFirstName(string firstname)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var staff = _context.Staff.Where(s => s.FirstName == firstname).FirstOrDefault();
            }
        }
        public void QueryStaffWithPhoneNumber(string phone)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var staff = _context.Staff.Where(s => s.FirstName == phone).FirstOrDefault();
            }
        }
        public void QueryStaffWithRole(string role)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var staff = _context.Staff.Include(s => s.Role).Where(p => p.Role.Name.ToLower() == role.ToLower()).ToList();
            }
        }

        public void QueryProductWithName(string name)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var product = _context.Product.Where(p => p.Name == name).FirstOrDefault();
            }
        }
        public void QueryProductWithCategory(string category)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var products = _context.Product
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .Where(x => x.ProductCategories.Any(y => y.Category.Name.ToLower() == category.ToLower()))
                    .ToList();
            }
        }
        public void QueryProductWithInStock(bool stock)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var products = _context.Inventory
                    .Include(x => x.Product)
                    .Select(x => new { x.Product, x.InStock })
                    .ToList()
                    .Where(x => x.InStock == stock)
                    .ToList();
            }
        }
        public void QueryProductWithSellipnPrice(int sp)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var products = _context.Product
                    .Include(x => x.Prices)
                    .ToList()
                    .Where(x => x.Prices
                        .Any(
                            p => p.EffectiveDate == x.Prices.OrderBy(e => e.EffectiveDate).LastOrDefault().EffectiveDate
                        )
                    )
                    .ToList();
            }
        }

        public void QueryNumberOfOutofStockProducts()
        {
            using (_context = new DepartmentalStoreContext())
            {
                var products = _context.Inventory
                    .Include(x => x.Product)
                    .Select(x => new { x.Product, x.InStock })
                    .ToList()
                    .Where(x => x.InStock == false)
                    .ToList();
            }
        }

        public void QueryNumberOfProductsInCategory()
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Category
                    .Include(x => x.ProductCategories)
                    .Select(x => new { x, x.ProductCategories.Count })
                    .ToList();
            }
        }

        public void QuerySupplierWithFirstName(string firstname)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Supplier.Where(s => s.FirstName == firstname).FirstOrDefault();
            }
        }
        public void QuerySupplierWithPhone(string phone)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Supplier.Where(s => s.PhoneNumber == phone).FirstOrDefault();
            }
        }
        public void QuerySupplierWithAddress(string state, string city)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Supplier
                    .Include(s => s.Address)
                    .Where(s => s.Address.State == state || s.Address.City == city)
                    .ToList();
            }
        }

        public void QueryProductOrderWithSupplier()
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Include(o => o.Supplier)
                    .ToList();
            }
        }
        public void QueryProductOrderWithSupplierWithProductName(string name)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Include(o => o.Supplier)
                    .Where(x => x.OrderDetails.Any(o => o.Product.Name == name)).ToList();
            }
        }
        public void QueryProductOrderWithSupplierWithSupplierFirstName(string firstname)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Include(o => o.Supplier)
                    .Where(o => o.Supplier.FirstName == firstname)
                    .ToList();
            }
        }
        public void QueryProductOrderWithSupplierWithProductShortCode(string shortcode)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Include(o => o.Supplier)
                    .Where(o => o.OrderDetails.Any(x => x.Product.ShortCode == shortcode))
                    .ToList();
            }
        }
        public void QueryProductOrderWithSupplierWithOrderDate(int year, int month, int date)
        {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .Include(o => o.Supplier)
                    .Where(o => o.OrderDate < (new DateTime(year, month, date)))
                    .ToList();
            }
        }
        public void QueryProductOrderWithSupplierLessThanInventoryQuantity() {
            using (_context = new DepartmentalStoreContext())
            {
                var result = _context.Order
                    .Include(o => o.OrderDetails)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.Inventory)
                    .Include(o => o.Supplier)
                    .Where(x => x.OrderDetails.Any(o => o.Quantity > o.Product.Inventory.InventoryQuantity))
                    .ToList();
            }
        }
    }
}
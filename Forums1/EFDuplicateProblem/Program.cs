using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace EFDuplicateProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new OrdersContext())
            {
                try
                {
                    Database.SetInitializer(new CreateDatabaseIfNotExists<OrdersContext>());
                    context.Database.Initialize(false);
                    MoveAnItem(context);
                }
                catch (DataException ex)
                {
                    if (ex.InnerException == null)
                        Console.WriteLine("DataException: " + ex.Message);
                    else
                        Console.WriteLine(string.Format("DataException: {0}, inner {1}: {2}",
                            ex.Message, ex.InnerException.GetType().FullName,
                            ex.InnerException.Message));
                    return;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SqlException: " + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName + ": " + ex.Message);
                    return;
                }
            }
        }

        private static void MoveAnItem(OrdersContext db)
        {
            if (db.OrderItems.Count<OrderItem>() <= 2)
            {
                Console.WriteLine("No data");
                return;
            }
            try
            {
                OrderItem ItemMoving = db.OrderItems.OrderByDescending(p => p.ListIndex).FirstOrDefault();
                Console.WriteLine($"Moving Id: {ItemMoving.Id}, ListIndex: {ItemMoving.ListIndex}, Name: {ItemMoving.Name}");
                IEnumerable<OrderItem> items =
                    from s in db.OrderItems
                    orderby s.ListIndex
                    select s;
                Console.WriteLine("\tData before resequence");
                foreach (OrderItem item in items)
                    Console.WriteLine($"{item.Id} {item.ListIndex} {item.Name}");
                int newx = 1;
                ItemMoving.ListIndex = newx;
                foreach (OrderItem s in items)
                {
                    if (s.Id != ItemMoving.Id)
                        s.ListIndex = ++newx;
                }
                Console.WriteLine("\tData before SaveChanges");
                IEnumerable<DbEntityEntry> TrackEntries = db.ChangeTracker.Entries();
                foreach (DbEntityEntry e in TrackEntries)
                {
                    OrderItem s;
                    if ((s = e.Entity as OrderItem) is OrderItem)
                        Console.WriteLine($"{s.Id} {s.ListIndex} {e.State} {s.Name}");
                    else
                        Console.WriteLine($"Type {e.GetType().Name} is not OrderItem");
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WalkExceptions(ex);
            }
        }

        private static void WalkExceptions(Exception ex)
        {
            Console.WriteLine("\tException tree:");
            Console.WriteLine(ex.GetType().FullName + ": " + ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                Console.WriteLine(ex.GetType().FullName + ": " + ex.Message);
            }
        }
    }
}

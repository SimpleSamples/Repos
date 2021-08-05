using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDuplicateProblem
{
    class OrdersContext : DbContext
    {
        public OrdersContext() : base(Properties.Settings.Default.ConnectionStringSetting) { }
        public DbSet<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public OrderItem()
        {
            this.ListIndex = 0;
            this.Name = string.Empty;
        }
        public OrderItem(int ListIndex, string Name)
        {
            this.ListIndex = ListIndex;
            this.Name = Name;
        }
        public int Id { get; set; }
        [Required, Index(IsUnique = true)]
        public int ListIndex { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

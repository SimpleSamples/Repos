namespace AddMobilePark1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelPark : DbContext
    {
        public ModelPark()
            : base("name=ModelPark")
        {
        }

        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<MobilePark> MobileParks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MobilePark>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<MobilePark>()
                .Property(e => e.ParkName)
                .IsUnicode(false);

            modelBuilder.Entity<MobilePark>()
                .Property(e => e.Comments)
                .IsUnicode(false);
        }
    }
}

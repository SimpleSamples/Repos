    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class ModelTutorials : DbContext
    {
        public ModelTutorials() : base("name=ModelTutorials") { }

        public DbSet<AJAX> AJAXes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AJAX>()
                .Property(e => e._char)
                .HasMaxLength(1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<AJAX>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }

    [Table("AJAX")]
    public partial class AJAX
    {
        public int id { get; set; }

        [Column("char")]
        [StringLength(1)]
        public string _char { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        public int position { get; set; }
    }

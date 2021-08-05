namespace AddMobilePark1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MobilePark")]
    public partial class MobilePark
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Fee { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public int? FromLA { get; set; }

        public int? CountyId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string ParkName { get; set; }

        [StringLength(1)]
        public string Comments { get; set; }
    }
}

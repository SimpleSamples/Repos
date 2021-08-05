namespace AddMobilePark1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class County
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string CountyName { get; set; }
    }
}

namespace ORMBenchmark.Models.EF6 {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Entities")]
    public partial class EF6Entity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public Nullable<long> Value { get; set; }
    }
}

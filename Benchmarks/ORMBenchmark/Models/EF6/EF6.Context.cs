namespace ORMBenchmark.Models.EF6 {
    using System;
    using System.Data.Entity;
    using System.Configuration;

    public partial class EF6Context : DbContext {
        public EF6Context()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString) {
            Database.SetInitializer<EF6Context>(null);
        }

        public virtual DbSet<EF6Entity> Entities { get; set; }
    }
}

namespace ADO.NET_Module_04_CreateTables.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<PMChecklistPart> PMChecklistParts { get; set; }
        public virtual DbSet<TrackComponent> TrackComponents { get; set; }
        public virtual DbSet<TrackEvaluationPart> TrackEvaluationParts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

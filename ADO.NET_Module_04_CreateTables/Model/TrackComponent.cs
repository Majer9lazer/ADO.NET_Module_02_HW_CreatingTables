namespace ADO.NET_Module_04_CreateTables.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrackComponent")]
    public partial class TrackComponent
    {
        [Key]
        public int intComponentId { get; set; }

        [StringLength(12)]
        public string strComponentId { get; set; }

        [StringLength(10)]
        public string strUntil { get; set; }

        public int? intComponentTypeID { get; set; }

        [Column(TypeName = "date")]
        public DateTime dInstalledOnMCS { get; set; }

        public int intEstimatedLife { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dInitCycleDate { get; set; }

        public int? intInitCycleUnits { get; set; }

        public int? intInitTotalUnits { get; set; }

        public int? intEquipmentID { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastDate { get; set; }

        public double intLastMetered { get; set; }

        public double? intTotalMetered { get; set; }

        public int? intSMCSComponentID { get; set; }

        public int? intModelID { get; set; }

        public int? intLocationId { get; set; }

        public bool? isRemoved { get; set; }

        public int? intStatusComponent { get; set; }

        public int? intModifierId { get; set; }
    }
}

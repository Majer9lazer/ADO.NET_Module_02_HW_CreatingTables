namespace ADO.NET_Module_04_CreateTables.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PMChecklistPart")]
    public partial class PMChecklistPart
    {
        [Key]
        public int intPMChecklistPartID { get; set; }

        public int intPMChecklistStepID { get; set; }

        [StringLength(20)]
        public string strPartNo { get; set; }

        public int intQuantity { get; set; }

        public int? intlExtendedCost { get; set; }

        public bool? bitOptional { get; set; }

        public int? intOriginalPartID { get; set; }

        [StringLength(550)]
        public string strPartDescription { get; set; }

        public int intMasterPartId { get; set; }

        public int? intPMChecklistID { get; set; }
    }
}

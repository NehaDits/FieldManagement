using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class Stakeholder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StakeholderId { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string StakeholderName { get; set; }        
        public int StakeholderType { get; set; }
        public Reference Reference { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FieldMgt.Core.DomainModels
{
    public class ExceptionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExceptionLogId { get; set; }
        public string Browser { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ErrorCode { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ExceptionId { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ExceptionBy { get; set; }
        [ForeignKey("ID")]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime? ExceptionOn { get; set; } = DateTime.Now;
    }
}

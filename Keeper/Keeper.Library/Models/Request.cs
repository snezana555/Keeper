namespace Keeper.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            Visitors = new HashSet<Visitor>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        [Required]
        [StringLength(100)]
        public string TargetVisit { get; set; }

        [Required]
        public string AdditionalFiles { get; set; }

        public int EmployeeId { get; set; }

        [StringLength(30)]
        public string Status { get; set; }

        [Required]
        [StringLength(100)]
        public string StatusDescription { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}

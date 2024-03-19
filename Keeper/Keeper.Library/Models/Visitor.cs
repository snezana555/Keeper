namespace Keeper.Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visitor()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Patronymic { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Remark { get; set; }

        [StringLength(30)]
        public string Company { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateBoth { get; set; }

        public int Number { get; set; }

        public int Series { get; set; }

        [Required]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}

namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            HOADONs = new HashSet<HOADON>();
            NHANXETs = new HashSet<NHANXET>();
        }

        [Key]
        public int IDUSER { get; set; }

        [StringLength(50)]
        public string TEN { get; set; }

        [StringLength(50)]
        public string MATKHAU { get; set; }

        public string EMAIL { get; set; }

        [StringLength(50)]
        public string REPASS { get; set; }

        public bool? TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANXET> NHANXETs { get; set; }
    }
}

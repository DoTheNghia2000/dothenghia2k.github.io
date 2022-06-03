namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            HOADONs = new HashSet<HOADON>();
            NHANXETs = new HashSet<NHANXET>();
        }

        [Key]
        public int IDSANPHAM { get; set; }

        [StringLength(100)]
        public string TENSANPHAM { get; set; }

        public string HINHANH { get; set; }

        [StringLength(50)]
        public string HANGSANXUAT { get; set; }

        public decimal? GIATIEN { get; set; }

        [StringLength(50)]
        public string SIZE { get; set; }

        [StringLength(50)]
        public string MAUSAC { get; set; }

        public string MOTA { get; set; }

        [StringLength(10)]
        public string TOPHOT { get; set; }

        public int? SALE { get; set; }

        public double? DANHGIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANXET> NHANXETs { get; set; }
    }
}

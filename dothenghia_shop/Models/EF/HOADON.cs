namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int IDHOADON { get; set; }

        public int? IDSANPHAM { get; set; }

        public int? IDUSER { get; set; }

        public int? SOLUONG { get; set; }

        public decimal? THANHTIEN { get; set; }

        public virtual CHITIETHOADON CHITIETHOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual USER USER { get; set; }
    }
}

namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANXET")]
    public partial class NHANXET
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDUSER { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDSANPHAM { get; set; }

        public string BINHLUAN { get; set; }

        public DateTime? NGAY { get; set; }

        public int? DANHGIA { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual USER USER { get; set; }
    }
}

namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHOADON { get; set; }

        public DateTime? NGAYMUA { get; set; }

        public string DIACHI { get; set; }

        public int? SDT { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}

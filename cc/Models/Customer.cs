namespace cc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string 客戶名稱 { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime 訂購日期 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 所屬代理 { get; set; }

        [StringLength(60)]
        public string 送貨地址 { get; set; }

        public int? 區域 { get; set; }

        public int? 城市 { get; set; }

        public int? 省府 { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string 相關圖片 { get; set; }

        public string 備註 { get; set; }
    }
}

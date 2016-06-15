namespace cc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Details")]
    public partial class Order_Detail
    {
        [Key]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime 訂購日期 { get; set; }

        public int 訂購代理 { get; set; }

        public int 訂購貨品 { get; set; }

        [Column(TypeName = "money")]
        public decimal 價格 { get; set; }

        public short 件數 { get; set; }

        public float? Discount { get; set; }

        public int? 支付方式 { get; set; }

        [StringLength(50)]
        public string 相關客戶 { get; set; }

        public int? 貨品狀況 { get; set; }

        public string More { get; set; }

        public virtual Category Category { get; set; }

        public virtual Endded Endded { get; set; }

        public virtual Pay Pay { get; set; }

        public virtual 代理表 代理表 { get; set; }

        public virtual Order Order { get; set; }
    }
}

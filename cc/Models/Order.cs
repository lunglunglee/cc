namespace cc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? 代理 { get; set; }

        [StringLength(50)]
        public string 客戶 { get; set; }

        public DateTime? 訂購日期 { get; set; }

        public DateTime? 發貨日期 { get; set; }

        public int? 送貨地址 { get; set; }

        public int? 省府 { get; set; }

        public int? 城市 { get; set; }

        public int? 區域 { get; set; }

        [StringLength(15)]
        public string 運送方式 { get; set; }

        public string 備註 { get; set; }

        public int? ShipVia { get; set; }

        public virtual Data_Area Data_Area { get; set; }

        public virtual Data_City Data_City { get; set; }

        public virtual Data_Province Data_Province { get; set; }

        public virtual Order_Detail Order_Details { get; set; }
    }
}

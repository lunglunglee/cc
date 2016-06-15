namespace cc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Categories = new HashSet<Category>();
        }

        public int SupplierID { get; set; }

        [Required]
        [StringLength(15)]
        public string 產品名稱 { get; set; }

        [Column(TypeName = "date")]
        public DateTime 採購日期 { get; set; }

        [StringLength(10)]
        public string 採購項目 { get; set; }

        [StringLength(40)]
        public string 供應商 { get; set; }

        [StringLength(30)]
        public string 聯絡人 { get; set; }

        [Column(TypeName = "money")]
        public decimal 原材價錢 { get; set; }

        [Required]
        [StringLength(10)]
        public string 購入數量 { get; set; }

        [StringLength(10)]
        public string 單件產品耗量 { get; set; }

        [StringLength(10)]
        public string 已使用數量 { get; set; }

        [StringLength(24)]
        public string 圖片 { get; set; }

        public string 備註 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }
    }
}

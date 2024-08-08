namespace bandienthoai.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIPPER")]
    public partial class SHIPPER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHIPPER()
        {
            HOADONs = new HashSet<HOADON>();
        }

        public int ID { get; set; }

        public int ORDERID { get; set; }

        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [StringLength(250)]
        public string GHICHU { get; set; }

        public bool IS_DELETE { get; set; }

        [StringLength(50)]
        public string CREATEBY { get; set; }

        public DateTime? CREATEDATE { get; set; }

        [StringLength(50)]
        public string MODIFLIEDBY { get; set; }

        public DateTime? MODIFILEDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}

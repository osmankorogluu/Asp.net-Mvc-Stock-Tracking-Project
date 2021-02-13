//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUrunler()
        {
            this.TblSatıslar = new HashSet<TblSatıslar>();
        }
    
        public int id { get; set; }
        public string Ad { get; set; }
        public string Marka { get; set; }
        public Nullable<short> Stok { get; set; }
        public Nullable<decimal> AlisFiyat { get; set; }
        public Nullable<decimal> SatisFiyat { get; set; }
        public Nullable<int> Kategori { get; set; }
        public Nullable<bool> urun { get; set; }
    
        public virtual TblKategoriler TblKategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatıslar> TblSatıslar { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Domain.Entities
{
    [DataContract]
    public class Sale : BaseEntity
    {
        [DataMember(Name = "purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [DataMember(Name = "value")] 
        public double Value { get; set; }


        [DataMember(Name = "enable_sale" )]
        public Boolean EnableSale { get; set; }
        
        #region
        [DataMember(Name = "crediario_id")]
        public int? CreadiarioId { get; set; }

        [DataMember(Name = "crediario")]
        public virtual Crediario Crediario { get; set; }
        #endregion
    }
}

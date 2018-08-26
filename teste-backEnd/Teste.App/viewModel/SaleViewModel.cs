using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.App.viewModel
{
    public class SaleViewModel
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [DataMember(Name = "value")]
        public double Value { get; set; }

        [DataMember(Name = "enable_sale")]
        public Boolean EnableSale { get; set; }

        #region crediario
        [DataMember(Name = "crediario_id")]
        public int CreadiarioId { get; set; }

        [DataMember(Name = "crediario")]
        public Crediario Crediario { get; set; }

        #endregion
    }
}

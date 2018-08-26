using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Teste.Domain.Entities;

namespace Teste.App.viewModel
{
    [DataContract]
    public class CrediarioViewModel
    {
        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "finalValue")]
        public double FinalValue { get; set; }

        [DataMember(Name = "scheduling_payment")]
        public DateTime SchedulingPayment { get; set; }

        [DataMember(Name = "rate")]
        public int Rate { get; set; }

        [DataMember(Name = "person")]
        public Person Person { get; set; }

        [DataMember(Name = "person_id")]

        public int PersonId { get; set; }

        [DataMember(Name = "user_id")]
        public int UserId { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "sales")]
        public ICollection<Sale> Sales { get; set; }
    }
}

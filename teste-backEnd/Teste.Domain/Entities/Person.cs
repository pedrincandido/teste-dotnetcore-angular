using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Domain.Entities
{
    [DataContract]
    public class Person : BaseEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "birth_date")]
        public DateTime BirthDate { get; set; }

        [DataMember(Name = "cpf")]
        public string Cpf { get; set; }

        [DataMember(Name = "gender_id")]
        public int GenderId { get; set; }

        [DataMember(Name = "gender")]

        public Gender Gender { get; set; }
    }
}

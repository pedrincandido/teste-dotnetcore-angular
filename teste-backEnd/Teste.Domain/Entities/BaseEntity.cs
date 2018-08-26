using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Domain.Entities
{
    [DataContract]
    public class BaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}

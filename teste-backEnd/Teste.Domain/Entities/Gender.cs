using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Teste.Domain.Entities
{
    public class Gender : BaseEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OnpayApi.Models
{
    [DataContract]
    public class PayResponse
    {
        [DataMember(Name = "status")]
        public bool Status { get; set; }
        [DataMember(Name = "pay_for")]
        public string PayFor { get; set; }

        [DataMember(Name = "signature")]
        public string Signature { get; set; }
    }
}

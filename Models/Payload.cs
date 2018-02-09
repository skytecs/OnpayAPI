using System;
using System.Runtime.Serialization;

namespace OnpayApi.Models
{
    [DataContract]
    public class Payload
    {

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "pay_for")]
        public string PayFor { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "way")]
        public string Way { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        [DataMember(Name = "user_email")]
        public string UserEmail { get; set; }

        [DataMember(Name = "signature")]
        public string Signature { get; set; }

        [DataMember(Name="user")]
        public User User { get; set; }

        [DataMember(Name="payment")]
        public Payment Payment { get; set; }

        [DataMember(Name="balance")]
        public Balance Balance { get; set; }

        [DataMember(Name = "order")]
        public Order Order { get; set; }

        [DataMember(Name = "additional_params")]
        public dynamic AdditionalParams { get; set; }

    }

    [DataContract]
    public class User
    {

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }
    }

    [DataContract]
    public class Payment
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "date_time")]
        public DateTime DateTime { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "way")]
        public string Way { get; set; }

        [DataMember(Name = "rate")]
        public decimal Rate { get; set; }

        [DataMember(Name = "release_at")]
        public object ReleaseAt { get; set; }
    }

    [DataContract]
    public class Balance
    {

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "way")]
        public string Way { get; set; }
    }

    [DataContract]
    public class Order
    {

        [DataMember(Name = "from_amount")]
        public decimal FromAmount { get; set; }

        [DataMember(Name = "from_way")]
        public string FromWay { get; set; }

        [DataMember(Name = "to_amount")]
        public decimal ToAmount { get; set; }

        [DataMember(Name = "to_way")]
        public string ToWay { get; set; }
    }
}

using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using OnpayApi.Models;

namespace OnpayApi.Services
{
    public class OnpayService
    {
        private readonly IOptions<OnpaySettings> _onpaySettings;

        public OnpayService(IOptions<OnpaySettings> onpaySettings)
        {
            _onpaySettings = onpaySettings;
        }
        //«check;pay_for;amount;way;mode;secret_key» 
        public bool ValidCheckSignature(Payload payload)
        {
            var string2Sign = $"check;{payload.PayFor};{payload.Amount};{payload.Way};{payload.Mode};{_onpaySettings.Value.ApiSecret}";
            return Hash(string2Sign).Equals(payload.Signature);
        }

        //«pay;pay_for;payment.amount;payment.way;balance.amount;balance.way;secret_key»
        public bool ValidPaySignature(Payload payload)
        {
            var string2Sign = $"pay;{payload.PayFor};{payload.Payment.Amount};{payload.Payment.Way};{payload.Balance.Amount};{payload.Balance.Way};{_onpaySettings.Value.ApiSecret}";
            return Hash(string2Sign).Equals(payload.Signature);
        }

        //«check;status;pay_for;secret_key»
        public CheckResponse GetCheckResponse(Payload payload, bool allowed)
        {
            var stringToSign = $"check;{allowed.ToString().ToLower()};{payload.PayFor};{_onpaySettings.Value.ApiSecret}";
            var signature = Hash(stringToSign);
            return new CheckResponse{PayFor = payload.PayFor, Signature = signature, Status = allowed};
        }


        // «pay;status;pay_for;secret_key» 
        public PayResponse GetPayResponse(Payload payload, bool allowed)
        {

            var signature = Hash($"pay;{allowed.ToString().ToLower()};{payload.PayFor};{_onpaySettings.Value.ApiSecret}");
            return new PayResponse{ PayFor = payload.PayFor, Signature = signature, Status = allowed };
        }


        //https://stackoverflow.com/questions/17292366/hashing-with-sha1-algorithm-in-c-sharp
        private static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}

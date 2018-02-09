using OnpayApi.Models;

namespace OnpayApi.Services
{
    public interface IOnpayProcessor
    {
        bool ProcessCheck(Payload payload);
        bool ProcessPay(Payload payload);

    }
}

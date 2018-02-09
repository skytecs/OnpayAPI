using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnpayApi.Models;

namespace OnpayApi.Services
{
    public class DemoOnpayProcessor : IOnpayProcessor
    {
        public bool ProcessCheck(Payload payload)
        {
            return true;
        }

        public bool ProcessPay(Payload payload)
        {
            return true;
        }
    };
}

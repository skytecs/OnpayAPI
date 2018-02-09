using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnpayApi.Models;
using OnpayApi.Services;

namespace OnpayApi.Controllers
{
    [Produces("application/json")]
    [Route("api/onpay")]
    public class OnpayController : Controller
    {
        private readonly IOnpayProcessor _onpayProcessor;
        private readonly OnpayService _service;
        public OnpayController(IOnpayProcessor processor, OnpayService service)
        {
            _onpayProcessor = processor;
            _service = service;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Payload payload)
        {
            switch (payload.Type)
            {
                case "check":
           //         if (!_service.ValidCheckSignature(payload)) return StatusCode(403);

                    return new JsonResult(_service.GetCheckResponse(payload,
                        _onpayProcessor.ProcessCheck(payload)));

                case "pay":
                    if (!_service.ValidPaySignature(payload)) return StatusCode(403);

                    return new JsonResult(_service.GetPayResponse(payload,
                        _onpayProcessor.ProcessPay(payload)));
            }

            return StatusCode(404); ;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clients.Model;
using clients.Services;

namespace clients.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public ClientsController(ClientServices clientServices)
        {
            ClientServices = clientServices;
        }

        public ClientServices ClientServices { get; }

        [HttpGet]
        public IEnumerable<ClientProfile> Get()
        {
            return ClientServices.GetClient();
        }


    }
}

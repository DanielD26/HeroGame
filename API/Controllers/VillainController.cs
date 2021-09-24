using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class VillainController : ControllerBase {

        static List<Villain> villains = new List<Villain>(){
            new Villain(1, "Facebook"),
            new Villain(2, "Instagram")
        };


        private readonly ILogger<VillainController> _logger;

        public VillainController(ILogger<VillainController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public List<Villain> Get(){
            return villains;
        }

        [HttpPost]
        public Villain Post([FromBody]Villain v) {
            villains.Add(v);
            return v;
        }

        [HttpPut]
        
    }
}

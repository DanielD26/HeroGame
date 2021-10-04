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

        [HttpGet]
        public List<Villain> Get(){
            return VillainDatabaseHandler.GetVillains();
        }

        [HttpPost]
        public string Post([FromBody]Villain newVillain) {
            return VillainDatabaseHandler.AddVillain(newVillain);
        }

        [HttpPut]
        public string Put([FromBody]Villain villain) {
            return VillainDatabaseHandler.UpdateVillain(villain);
        }
        
        [HttpDelete]
        public string Delete([FromBody]Villain villain) {
            return VillainDatabaseHandler.DeleteVillain(villain);
        }
    }
}

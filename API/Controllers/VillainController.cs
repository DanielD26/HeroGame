﻿using System;
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
        
    }
}

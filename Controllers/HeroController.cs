using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase {

        static List<Hero> heroes = new List<Hero>() {
            new Hero("Bob", 1, 6, 3),
            new Hero("Frank", 1, 10, 5),
            new Hero("Billy", 5, 15, 10)
        };

        [HttpGet]
        public List<Hero> Get(){
            return heroes;
        }

        [HttpPost]
        public Hero Post([FromBody]Hero h) {
            heroes.Add(h);
            return h;
        }
    }
}

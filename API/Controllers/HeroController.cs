using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase {

        [HttpGet]
        public IEnumerable<Hero> Get(){
            return HeroDatabaseHandler.GetHeroes();
        }

        [HttpGet]
        [Route("{id}")]
        public Hero Get(int id){
            return HeroDatabaseHandler.GetHero(id);
        }

        [HttpPost]
        public string Post([FromBody]Hero newHero) {
            return HeroDatabaseHandler.AddHero(newHero);
        }

        [HttpPut]
        public string Put([FromBody]Hero hero) {
            return HeroDatabaseHandler.UpdateHero(hero);
        }

        [HttpDelete]
        public string Delete([FromBody]Hero hero) {
            return HeroDatabaseHandler.DeleteHero(hero);
        }
    }
}

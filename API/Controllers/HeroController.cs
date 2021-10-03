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

//         [HttpPost]
//         public Hero Post([FromBody]Hero h) {
//             heroes.Add(h);
//             return h;
//         }

//         [HttpPut]
//         public int Put([FromBody]Hero NewHero) {
//             int count = 0;

            
//             foreach (Hero h in heroes) {
//                 if (h.heroID == NewHero.heroID) {
//                     count++;
//                 }
//             }
//             return count;
//         }


//         [HttpDelete]
//         [Route("{id}")]
//         public string Delete(int id) {
//             heroes.Where(x => x.heroID == id).Count();
//             return heroes.RemoveAll(x => x.heroID == id) + " Heroes deleted.";
//         }
    }
}

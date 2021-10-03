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

        // static List<Hero> heroes = new List<Hero>() {
        //     new Hero(1, "Bob", 1, 6, 3),
        //     new Hero(2, "Frank", 1, 10, 5),
        //     new Hero(3, "Billy", 5, 15, 10)
        // };

        [HttpGet]
        public IEnumerable<Hero> Get(){
            return DatabaseHandler.GetHeroes();
        }

//         [HttpGet]
//         [Route("{id}")]
//         public Hero Get(int id){
//             Hero retHero = heroes.Where(x => x.heroID == id).First();
//             if (retHero != null) {
//                 return retHero;
//             } else {
//                 return retHero = new Hero(-1, "Hero not found", 0, 0, 0);
//             }
//         }

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

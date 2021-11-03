using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase {

        [HttpGet]
        public List<Game> Get(){
            return GameDatabaseHandler.GetGames();
        }

        [HttpPost]
        public string Post([FromBody]Game newGame) {
            return GameDatabaseHandler.AddResult(newGame);
        }
    }
}

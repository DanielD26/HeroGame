using System;

namespace API {
    public class Game {
        public int roundNum { get; set; }

        public Game(int roundNum) {
            this.roundNum = roundNum;
        }
    }
}
using System;

namespace API {
    public class Hero {
        public int heroID { get; set; }
        public string Name { get; set; }
        public int minDice { get; set; }
        public int maxDice { get; set; }
        public int Uses { get; set; }
    }
}
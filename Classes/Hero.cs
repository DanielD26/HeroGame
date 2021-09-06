using System;

namespace Project {
    public class Hero {
        public string Name { get; set; }
        public int diceMin { get; set; }
        public int diceMax { get; set; }
        public int Uses { get; set; }

        public Hero(string Name, int diceMin, int diceMax, int Uses) {
            this.Name = Name;
            this.diceMin = diceMin;
            this.diceMin = diceMax;
            this.Uses = Uses;
        }
    }
}
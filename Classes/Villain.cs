using System;

namespace Project {
    public class Villain {
        public string Name { get; set; }
        public int hitPoints { get; set; }

        public Villain(string Name, int hitPoints) {
            this.Name = Name;
            this.hitPoints = hitPoints;
        }
    }
}
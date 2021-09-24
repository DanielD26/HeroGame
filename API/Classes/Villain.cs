using System;

namespace API {
    public class Villain {
        public int villainID { get; set; }
        public string Name { get; set; }


        public Villain(int villainID, string Name) {
            this.villainID = villainID;
            this.Name = Name;
        }
    }
}
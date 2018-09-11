using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.Entity
{
    public class PetEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime Solddate { get; set; }

        public string PreviousOwner { get; set; }

        public double Price { get; set; }
    }
}

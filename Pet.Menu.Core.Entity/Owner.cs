using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.Entity
{
    public class Owner
    {
        public int OwnerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public List<PetEntity> pets { get; set; }
    }
}

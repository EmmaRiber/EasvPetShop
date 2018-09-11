using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Infratructure.Data
{
    public static class FakeDB
    {
        public static int PetId = 1;
        public static IEnumerable<PetEntity> Pets;
        
        //Hej

        public static void InitData()
        {
            var pet1 = new PetEntity()
            {
                Id = PetId++,
                Name = "Findus",
                Type = "Cat",
                Color = "Orange/Red",
                Birthdate = new DateTime(2018, 05, 07),
                Solddate = new DateTime(2018,08,31),
                PreviousOwner = "Tom Lassen",
                Price = 2300
            };

            var pet2 = new PetEntity()
            {
                Id = PetId++,
                Name = "Lamse",
                Type = "Pig",
                Color = "Brown",
                Birthdate = new DateTime(2008,12,24),
                Solddate = new DateTime(2018, 10, 29),
                PreviousOwner = "Karen Bøvs",
                Price = 4500
            };

            var pet3 = new PetEntity()
            {
                Id = PetId++,
                Name = "Blob",
                Type = "Fish",
                Color = "Green",
                Birthdate = new DateTime(2015, 12, 1),
                Solddate = new DateTime(2018, 12, 23),
                PreviousOwner = "Irene Hilde",
                Price = 180
            };

            var pet4 = new PetEntity()
            {
                Id = PetId++,
                Name = "Jumbo",
                Type = "Dog",
                Color = "Black/White",
                Birthdate = new DateTime(2018, 08, 30),
                Solddate = new DateTime(2019, 01, 05),
                PreviousOwner = "Sigurt Olsen",
                Price = 8000
            };

            var pet5 = new PetEntity()
            {
                Id = PetId++,
                Name = "Sofus",
                Type = "Cat",
                Color = "White",
                Birthdate = new DateTime(2017, 01, 13),
                Solddate = new DateTime(2018, 10, 1),
                PreviousOwner = "Åse Mikkelsen",
                Price = 1800
            };

            var pet6 = new PetEntity()
            {
                Id = PetId++,
                Name = "Mickey",
                Type = "Mouse",
                Color = "Gray",
                Birthdate = new DateTime(2018, 02, 24),
                Solddate = new DateTime(2019, 02, 01),
                PreviousOwner = "Stine Damsen",
                Price = 120
            };
            Pets = new List<PetEntity> { pet1, pet2, pet3, pet4, pet5, pet6 };
        }
    }
}

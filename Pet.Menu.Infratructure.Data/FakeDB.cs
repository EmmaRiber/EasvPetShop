﻿using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Infratructure.Data
{
    public static class FakeDB
    {
        public static int PetId = 1;
        public static IEnumerable<PetEntity> Pets;

        public static int OwnerId = 1;
        public static IEnumerable<Owner> Owners;

        public static void InitData()
        {
            //FakeDB Pets
            var pet1 = new PetEntity()
            {
                Id = PetId++,
                Name = "Findus",
                Type = "Cat",
                Color = "Orange/Red",
                Birthdate = new DateTime(2018, 05, 07),
                Solddate = new DateTime(2018,08,31),
                PreviousOwner = "Sus find",
                Price = 2300,
                Owner = new Owner()
                { OwnerId = 1}
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
                Price = 4500,
                Owner = new Owner()
                { OwnerId = 1 }
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
                Price = 180,
                Owner = new Owner()
                { OwnerId = 2 }
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
                Price = 8000,
                Owner = new Owner()
                { OwnerId = 1 }
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
                Price = 1800,
                Owner = new Owner()
                { OwnerId = 1 }
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
                Price = 120,
                Owner = new Owner()
                { OwnerId = 3 }
            };

            Pets = new List<PetEntity> { pet1, pet2, pet3, pet4, pet5, pet6 };

            //FakeDB Owners
            var owner1 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Sune",
                LastName = "Strand",
                Adress = "Roligvej 3"
            };

            var owner2 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Ulla",
                LastName = "Badulla",
                Adress = "BubbiVej 103"
            };

            var owner3 = new Owner()
            {
                OwnerId = OwnerId++,
                FirstName = "Finn",
                LastName = "Pind",
                Adress = "PølseVej 154"
            };

            Owners = new List<Owner> { owner1, owner2, owner3 };
        }
    }
}

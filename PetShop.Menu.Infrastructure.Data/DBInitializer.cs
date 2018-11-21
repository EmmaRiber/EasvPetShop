using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Menu.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetAppContext PActx)
        {
            PActx.Database.EnsureDeleted();
            PActx.Database.EnsureCreated();

            //Lavet to users Admin og User
            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);
            
            //Users
                var user1 = PActx.Users.Add(new User()
                {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                }).Entity;

            var user2 = PActx.Users.Add(new User()
            {
                Username = "AdminAnn",
                PasswordHash = passwordHashAnn,
                PasswordSalt = passwordSaltAnn,
                IsAdmin = true
            }).Entity;

        //Owners
        var owner1 = PActx.Owners.Add(new Owner()
            {
                FirstName = "Sune",
                LastName = "Strand",
                Adress = "Roligvej 3"
            }).Entity;

            var owner2 = PActx.Owners.Add(new Owner()
            {
                FirstName = "Ulla",
                LastName = "Badulla",
                Adress = "BubbiVej 103"
            }).Entity;

            var owner3 = PActx.Owners.Add(new Owner()
            {
                FirstName = "Finn",
                LastName = "Pind",
                Adress = "PølseVej 154"

            }).Entity;


            //Pets
            var pet1 = PActx.pets.Add(new PetEntity()
            {
                Name = "Findus",
                Type = "Cat",
                Color = "Orange/Red",
                Birthdate = new DateTime(2018, 05, 07),
                Solddate = new DateTime(2018, 08, 31),
                PreviousOwner = "Sus find",
                Price = 2300,
                Owner = owner2
            }).Entity;

            var pet2 = PActx.pets.Add(new PetEntity()
            {
                Name = "Lamse",
                Type = "Pig",
                Color = "Brown",
                Birthdate = new DateTime(2008, 12, 24),
                Solddate = new DateTime(2018, 10, 29),
                PreviousOwner = "Karen Bøvs",
                Price = 4500,
                Owner = owner1
            }).Entity;

            var pet3 = PActx.pets.Add(new PetEntity()
            {
                Name = "Blob",
                Type = "Fish",
                Color = "Green",
                Birthdate = new DateTime(2015, 12, 1),
                Solddate = new DateTime(2018, 12, 23),
                PreviousOwner = "Irene Hilde",
                Price = 180,
                Owner = owner3
            }).Entity;

            var pet4 = PActx.pets.Add(new PetEntity()
            {
                Name = "Jumbo",
                Type = "Dog",
                Color = "Black/White",
                Birthdate = new DateTime(2018, 08, 30),
                Solddate = new DateTime(2019, 01, 05),
                PreviousOwner = "Sigurt Olsen",
                Price = 8000,
                Owner = owner2
            }).Entity;

            var pet5 = PActx.pets.Add(new PetEntity()
            {
                Name = "Sofus",
                Type = "Cat",
                Color = "White",
                Birthdate = new DateTime(2017, 01, 13),
                Solddate = new DateTime(2018, 10, 1),
                PreviousOwner = "Åse Mikkelsen",
                Price = 1800,
                Owner = owner1
            }).Entity;

            var pet6 = PActx.pets.Add(new PetEntity()
            {
                Name = "Mickey",
                Type = "Mouse",
                Color = "Gray",
                Birthdate = new DateTime(2018, 02, 24),
                Solddate = new DateTime(2019, 02, 01),
                PreviousOwner = "Stine Damsen",
                Price = 120,
                Owner = owner1
            }).Entity;
            
            PActx.SaveChanges();
        }


        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using 
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}


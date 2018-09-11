using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pet.Menu.Infratructure.Data.Repositories
{
    public class PetRepository: IPetRepository
    {
        public IEnumerable<PetEntity> ReadAll()
        {
            return FakeDB.Pets;
        }

        public PetEntity Create(PetEntity pet)
        {
            pet.Id = FakeDB.PetId++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }
        
        public PetEntity ReadById(int id)
        {
            foreach (var pet in FakeDB.Pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }
        
        //Updaterer pet sidste step 
        public PetEntity Update(PetEntity petUpdate)
        {
            var petFromDB = this.ReadById(petUpdate.Id);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Type = petUpdate.Type;
                petFromDB.Color = petUpdate.Color;
                petFromDB.Birthdate = petUpdate.Birthdate;
                petFromDB.Solddate = petUpdate.Solddate;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;

                return petFromDB;
            }
            return null;
        }

        //Sletter pet sidste step.
        public PetEntity Delete(int Id)
        {
            var pets = FakeDB.Pets.ToList();
            var petsToDelete = pets.FirstOrDefault(Pet => Pet.Id == Id);
            pets.Remove(petsToDelete);
            FakeDB.Pets = pets;
            return petsToDelete;
        }
    }
}

using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Menu.Core.ApplicationService
{
    public interface IPetService
    {
        //PetService Interface
        PetEntity NewPet(string name, string type, string color, DateTime birthDate, DateTime soldDate, string previousOwner, double price);
        //Create
        PetEntity CreatePets(PetEntity petNew);
        //Read
        PetEntity FindPetById(int id);
        List<PetEntity> FindPetByType(string searchValue);
        List<PetEntity> SortByPrice();
        List<PetEntity> GetFiveCheapestPets();
        List<PetEntity> GetAllPets();
        //Update
        PetEntity UpdatePet(PetEntity petUpdate);
        //Delete
        PetEntity DeletePet(int idForDeletePet);
        
        //CRUD
    }
}

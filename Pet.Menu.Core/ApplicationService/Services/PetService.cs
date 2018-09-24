using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;

namespace Pet.Menu.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;

        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }

        //Ny pet
        public PetEntity NewPet(string name, string type, string color,
                                DateTime birthDate, DateTime soldDate,
                                string previousOwner, double price)
        {
            var petNew = new PetEntity()
            {
                Name = name,
                Type = type,
                Color = color,
                Birthdate = birthDate,
                Solddate = soldDate,
                PreviousOwner = previousOwner,
                Price = price
            };
            return petNew;
        }

        //Laver pet om
        public PetEntity CreatePets(PetEntity petNew)
        {
            return _petRepo.Create(petNew);
        }

        //Finder pet via. id
        public PetEntity FindPetById(int id)
        {
            return _petRepo.ReadById(id);
        }

        //Får alle pets
        public List<PetEntity> GetAllPets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public PetEntity FindPetByIdIncludeOwner(int id)
        {
            var pet = _petRepo.ReadByIdIncludeOwner(id);
            return pet;
        }

        //Updater pet
        public PetEntity UpdatePet(PetEntity petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.Color = petUpdate.Color;
            pet.Birthdate = petUpdate.Birthdate;
            pet.Solddate = petUpdate.Solddate;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;

            return pet;
        }

        //Sletter pet 
        public PetEntity DeletePet(int idForDeletePet)
        {
            return _petRepo.Delete(idForDeletePet);
        }

        //Søger efter Type pet - f.eks. Cat 
        public List<PetEntity> FindPetByType(string searchValue)
        {
            var list = _petRepo.ReadAll();
            var query = list.Where(PetEntity => PetEntity.Type.Equals(searchValue));
            query.OrderBy(PetEntity => PetEntity.Type);
            return query.ToList();
        }

        //Sorterer efter pris
        public List<PetEntity> SortByPrice()
        {
            var list = _petRepo.ReadAll();
            var query = list.OrderBy(PetEntity => PetEntity.Price);
            return query.ToList();
        }

        //Tager de fem billigste pets
        public List<PetEntity> GetFiveCheapestPets()
        {
            return _petRepo.ReadAll().OrderBy(PetEntity => PetEntity.Price).Take(5).ToList();
        }

        
    }
}

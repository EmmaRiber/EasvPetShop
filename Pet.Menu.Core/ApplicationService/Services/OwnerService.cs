using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pet.Menu.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository repository, 
            IPetRepository petRepository)
        {
            _ownerRepo = repository;
            _petRepo = petRepository;
        }

        public Owner New(string first_name, string last_name, string adress, int pets)
        {
            var owner = new Owner
            {
                FirstName = first_name,
                LastName = last_name,
                Adress = adress
            };
            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadById(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _ownerRepo.Update(ownerUpdate);
        }

        public Owner DeleteOwner(int id)
        {
            if(id < 1)
            {
                throw new InvalidOperationException("Id must be bigger than 0");
            }
            return _ownerRepo.Delete(id);
        }
    }
}

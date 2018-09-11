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
        private IOwnerRepository _repository;

        public OwnerService(IOwnerRepository repository)
        {
            _repository = repository;
        }

        public Owner New()
        {
            return new Owner();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _repository.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _repository.ReadById(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _repository.ReadAll().ToList();
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            return _repository.Update(ownerUpdate);
        }

        public Owner DeleteOwner(int id)
        {
            return _repository.Delete(id);
        }
    }
}

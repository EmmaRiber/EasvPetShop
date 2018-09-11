using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pet.Menu.Infratructure.Data.Repositories
{
    class OwnerRepository : IOwnerRepository
    {
        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners;
        }

        public Owner Create(Owner owner)
        {
            owner.OwnerId = FakeDB.OwnerId++;
            var owners = FakeDB.Owners.ToList();
            owners.Add(owner);
            FakeDB.Owners = owners;
            return owner;
        }

        public Owner ReadById(int id)
        {
            foreach (var owner in FakeDB.Owners)
            {
                if (owner.OwnerId == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = this.ReadById(ownerUpdate.OwnerId);
            if (ownerFromDB != null)
            {
                ownerFromDB.FirstName = ownerUpdate.FirstName;
                ownerFromDB.LastName = ownerUpdate.LastName;
                ownerFromDB.Adress = ownerUpdate.Adress;

                return ownerFromDB;
            }
            return null;
        }

        public Owner Delete(int id)
        {
            var owners = FakeDB.Owners.ToList();
            var ownersToDelete = owners.FirstOrDefault(Owner => Owner.OwnerId == id);
            owners.Remove(ownersToDelete);
            FakeDB.Owners = owners;
            return ownersToDelete;
        }
    }
}

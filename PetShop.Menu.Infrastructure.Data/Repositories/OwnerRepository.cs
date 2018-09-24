using Microsoft.EntityFrameworkCore;
using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Menu.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        readonly PetAppContext _PActx;

        public OwnerRepository(PetAppContext PActx)
        {
            _PActx = PActx;
        }

        public Owner Create(Owner owner)
        {
            var o = _PActx.Owners.Add(owner).Entity;
            _PActx.SaveChanges();
            return o;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _PActx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _PActx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.OwnerId == id);
        }

        public Owner Update(Owner OwnerUpdate)
        {
            var oUpdate = _PActx.Update(OwnerUpdate).Entity;
            var change = _PActx.ChangeTracker.Entries();
            _PActx.SaveChanges();
            return oUpdate;
        }

        public Owner Delete(int id)
        {
            var ownersRemoved = _PActx
                .Remove(new Owner { OwnerId = id }).Entity;
            _PActx.SaveChanges();
            return ownersRemoved;
        }
    }
}

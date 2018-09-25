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
            _PActx.Attach(owner).State = EntityState.Added;
            _PActx.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _PActx.Owners;
        }

        public Owner ReadById(int id)
        {
            return _PActx.Owners
                .Include(o => o.pets)
                .FirstOrDefault(o => o.OwnerId == id);
        }

        public Owner Update(Owner OwnerUpdate)
        {
            _PActx.Attach(OwnerUpdate).State = EntityState.Modified;
            _PActx.Entry(OwnerUpdate).Reference(o => o.pets).IsModified = true;
            _PActx.SaveChanges();
            return OwnerUpdate;
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

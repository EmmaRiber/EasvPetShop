using Microsoft.EntityFrameworkCore;
using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Menu.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetAppContext _PActx;

        public PetRepository(PetAppContext PActx)
        {
            _PActx = PActx;
        }

        public PetEntity Create(PetEntity pet)
        {
            if (pet.Owner != null)
            {
                pet.Owner = _PActx.Owners.FirstOrDefault
                    (o => o.OwnerId == pet.Owner.OwnerId);
            }
            var p = _PActx.pets.Add(pet).Entity;
            _PActx.SaveChanges();
            return p;
        }

        public IEnumerable<PetEntity> ReadAll()
        {
            return _PActx.pets;
        }

        public PetEntity ReadById(int Id)
        {
            return _PActx.pets
                .Include(p => p.Owner)
                .FirstOrDefault(Pet => Pet.Id == Id);
        }

        public PetEntity ReadByIdIncludeOwner(int id)
        {
            return _PActx.pets
                .Include(p => p.Owner)
                .FirstOrDefault(p => p.Id == id);
        }


        public PetEntity Update(PetEntity petUpdate)
        {
            var pUpdate = _PActx.Update(petUpdate).Entity;
            var change = _PActx.ChangeTracker.Entries();
            _PActx.SaveChanges();
            return pUpdate;
        }

        public PetEntity Delete(int Id)
        {
            var petsRemoved = _PActx
              .Remove(new PetEntity { Id = Id }).Entity;
            _PActx.SaveChanges();
            return petsRemoved;
        }
    }
}

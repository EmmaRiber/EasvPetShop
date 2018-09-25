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
            var pets = _PActx.pets.Add(pet).Entity;
            _PActx.SaveChanges();
            return pets;
        }

        public IEnumerable<PetEntity> ReadAll()
        {
            return _PActx.pets;
        }

        public PetEntity ReadById(int Id)
        {
            return _PActx.pets
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
            _PActx.Attach(petUpdate).State = EntityState.Modified;
            _PActx.Entry(petUpdate).Reference(p => p.Owner).IsModified = true;
            _PActx.SaveChanges();
            return petUpdate;
            
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

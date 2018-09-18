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
            var PetEntity = _PActx.pets.Add(pet).Entity;
            _PActx.SaveChanges();
            return pet;
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

        public PetEntity Update(PetEntity petUpdate)
        {
            var pUpdate = _PActx.Update(petUpdate).Entity;
            var change = _PActx.ChangeTracker.Entries();
            _PActx.SaveChanges();
            return pUpdate;
        }

        public PetEntity Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

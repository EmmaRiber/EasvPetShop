using Microsoft.EntityFrameworkCore;
using Pet.Menu.Core.DomainService;
using Pet.Menu.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Menu.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly PetAppContext _PActx;
       
        public UserRepository(PetAppContext PActx)
        {
            _PActx = PActx;
        }

        public void Add(User entity)
        {
            _PActx.Users.Add(entity);
            _PActx.SaveChanges();
        }

        public void Edit(User entity)
        {
            _PActx.Entry(entity).State = EntityState.Modified;
            _PActx.SaveChanges();
        }

        public User Get(long id)
        {
            return _PActx.Users.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _PActx.Users.ToList();
        }

        public void Remove(long id)
        {
            var item = _PActx.Users.FirstOrDefault(b => b.Id == id);
            _PActx.Users.Remove(item);
            _PActx.SaveChanges();
        }
    }
}

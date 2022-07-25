using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositeries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class AdminRepositories : IRepositories<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {
            id++;
            entity.Id = id;
            DbContext.Admins.Add(entity);
            return entity;
        }

        public void Delete(Admin entity)
        {
            DbContext.Admins.Remove(entity);
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Admins[0];
            }
            else
            {
                return DbContext.Admins.Find(filter);
            }

        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Admins;
            }
            else
            {
                return DbContext.Admins.FindAll(filter);
            }
        }

        public void Update(Admin entity)
        {
            var admin = DbContext.Admins.Find(g => g.Id == entity.Id);
            if (admin != null)
            {
                admin.UserName = entity.UserName;
                admin.Password = entity.Password;
            }
        }
    }
}

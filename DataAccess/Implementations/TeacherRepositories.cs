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
    public class TeacherRepositories : IRepositories<Teacher>
    {
        private static int id;
        public Teacher Create(Teacher entity)
        {
            id++;
            entity.Id = id;
            try
            {
            DbContext.Teachers.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
            
        }

        public void Delete(Teacher entity)
        {
            try
            {
            DbContext.Teachers.Remove(entity);  

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Teacher Get(Predicate<Teacher> filter = null)
        {
            try
            {
            if (filter==null)
            {
                return DbContext.Teachers[0];
            }
            else
            {
                return DbContext.Teachers.Find(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Teacher> GetAll(Predicate<Teacher> filter = null)
        {
            try
            {
            if (filter==null)
            {
                return DbContext.Teachers;
            }
            else
            {
                return DbContext.Teachers.FindAll(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Update(Teacher entity)
        {
            try
            {
            var teacher=DbContext.Teachers.Find(t=> t.Id==entity.Id);
            if (teacher!=null)
            {
                teacher.Name=entity.Name;   
                teacher.Surname=entity.Surname;
                teacher.Age = entity.Age;
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
          
        }
    }
}

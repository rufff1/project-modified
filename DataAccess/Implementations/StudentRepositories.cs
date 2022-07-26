﻿using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositeries.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class StudentRepositories : IRepositories<Student>
    {
        private static int id;
        public Student Create(Student entity)
        {
            id++;
            entity.Id = id;
            try
            {
            DbContext.Students.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Student entity)
        {
            try
            {
            DbContext.Students.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Student Get(Predicate<Student> filter = null)
        {
            try
            {
            if (filter == null)
            {
                return DbContext.Students[0];
            }
            else
            {
                return DbContext.Students.Find(filter);
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
         
        
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {

            try
            {
            if (filter==null)
            {
                return DbContext.Students;
            }
            else
            {
                return DbContext.Students.FindAll(filter);  
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Update(Student entity)
        {
            try
            {
            if (entity !=null)
            {
            var student = DbContext.Students.Find(g => g.Id == entity.Id);
                student.Name = entity.Name;
                student.Surname = entity.Surname;
                student.Age = entity.Age;

            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }


}

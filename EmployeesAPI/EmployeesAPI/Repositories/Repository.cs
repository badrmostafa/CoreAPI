using EmployeesAPI.DataContext;
using EmployeesAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CourseContext context;
        private readonly DbSet<T> entity;
        public Repository(CourseContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }
        public int Add(T t)
        {
            entity.Add(t);
            return context.SaveChanges();
        }

        public int Delete(int? id)
        {
            T t = GetById(id);
            entity.Remove(t);
            return context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return entity.ToList();
        }

        public T GetById(int? id)
        {
            return entity.Find(id);
        }

        public void Update(T t)
        {
            entity.Update(t);
            context.SaveChanges();
        }
    }
}

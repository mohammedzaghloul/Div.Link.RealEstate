using Div.Link.RealEstate.DAL.Data;
using Div.Link.RealEstate.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Repository.BaseRepo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;

        public DbSet<T> DbSetT { get; set; }

        public BaseRepository(ApplicationDbContext dbContext)
        {

            DbSetT = dbContext.Set<T>();
            this.dbContext = dbContext;
        }
        public void Add(T entity)
        {
            DbSetT.Add(entity);
        }

        public void Delete(int Id)
        {
            var studentFromDb = dbContext.Set<T>().FirstOrDefault(s => s.Id == Id);
            if (studentFromDb != null)
                DbSetT.Remove(studentFromDb);

        }

        public IEnumerable<T> Getall()
        {
            return DbSetT.ToList();
        }

        public T GetById(int Id)
        {
            var studentFromDb = DbSetT.FirstOrDefault(s => s.Id == Id);

            return studentFromDb;
        }

        public void Update(T entity)
        {
            DbSetT.Update(entity);
        }
    }
}

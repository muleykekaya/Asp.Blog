using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Asp.MvcBlog.Islem
{
    public class Repository<T> : RepositoryBase where T : class
    {
        public DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = context.Set<T>();
        }

        public List<T> Listele()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public List<T> Listele(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Ekle(T obj)
        {
            _objectSet.Add(obj);



            return Kaydet();
        }

        public int Güncelle(T obj)
        {

            return Kaydet();
        }

        public int Sil(T obj)
        {

            _objectSet.Remove(obj);
            return Kaydet();
        }

        public int Kaydet()
        {
            return context.SaveChanges();
        }

        public T Bul(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
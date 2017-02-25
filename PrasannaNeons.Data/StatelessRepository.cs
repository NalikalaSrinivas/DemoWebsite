using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace PrasannaNeons.Data
{
    public interface IStatelessRepository
    {
        object Get<T1>(int id);
        void Create<T1>(object obj);
        void Update(object obj);
        void Delete(object obj);
        IList<T1>LoadAll<T1>();
        IEnumerable<T1> QueryOver<T1>(Expression<Func<T1, bool>> predicate) where T1 : class;
        bool Exist<T1>(Expression<Func<T1, bool>> predicate) where T1 : class;
    }

    public class StatelessRepository : IStatelessRepository
    {
        // Create an entity
        public void Create<T1>(object obj)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(obj);
                    transaction.Commit();
                }
            }
        }

        // Load an entity by its Id
        public object Get<T1>(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = session.Get<T1>(id);
                    transaction.Commit();
                    return result;
                }
            }
        }

        // Save or Update an Entity
        public void Update(object obj)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(obj);
                    session.Flush();
                    transaction.Commit();
                }
            }
        }

        // Delete an Entity
        public void Delete(object obj)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }

        // Retrieve all entities from the database
        public IList<T1> LoadAll<T1>()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<T1>().ToList();
            }
        }

        // Query using expression
        public IEnumerable<T1> QueryOver<T1>(Expression<Func<T1, bool>> predicate) where T1 : class
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<T1>()
                    .Where(predicate).List();
            }
        }


        // Does an entity exist or not
        public bool Exist<T1>(Expression<Func<T1, bool>> predicate) where T1 : class
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<T1>()
                    .Any(predicate);
            }
        }


    }
}

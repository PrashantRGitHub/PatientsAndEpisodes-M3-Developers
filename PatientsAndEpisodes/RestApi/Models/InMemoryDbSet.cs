using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace RestApi.Models
{
    public class InMemoryDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        private readonly List<TEntity> _collection = new List<TEntity>();

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _collection.AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return _collection.AsQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return _collection.AsQueryable().ElementType; }
        }

        public IQueryProvider Provider
        {
            get
            {
                var provider = _collection.AsQueryable().Provider;
                return provider;
            }
        }

        public TEntity Find(params object[] keyValues)
        {
            return this.SingleOrDefault(e => (e as IDBEntity).PatientId == (int)keyValues.Single());
        }

        public TEntity Add(TEntity entity)
        {
            _collection.Add(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            _collection.Remove(entity);
            return entity;
        }

      

        public TEntity Attach(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            throw new NotImplementedException();
        }
        
        public ObservableCollection<TEntity> Local { get; private set; }
    }
}
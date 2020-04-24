using System;
using System.Collections.Generic;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public abstract class BaseManager<T>
    {
        public abstract IRepository<T> Repository { get; }

        public bool Add(T data)
        {
            return Repository.Add(data);
        }

        public bool Delete(int[] id, string name)
        {
            return Repository.Delete(id, name);
        }

        public List<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T GetById(int id, string name)
        {
            return Repository.GetById(id, name);
        }

        public List<T> GetAllById(int id, string name)
        {
            return Repository.GetAllById(id, name);
        }

        public bool Update(T data)
        {
            return Repository.Update(data);
        }
    }
}

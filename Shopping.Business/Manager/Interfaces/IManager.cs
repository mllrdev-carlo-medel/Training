using System;
using System.Collections.Generic;

namespace ShoppingCart.Business.Manager.Interfaces
{
    public interface IManager<T>
    {
        List<T> GetAll();
        bool Add(T data);
        T GetById(int id, string name);
        List<T> GetAllById(int id, string name);
        bool Update(T data);
        bool Delete(int[] id, string name);
    }
}

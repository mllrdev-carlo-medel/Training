using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Transactions;
using Dapper;
using ShoppingCart.Business.Log;


namespace ShoppingCart.Business.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected IDbConnection Connection { get; }

        public abstract string Table { get; }

        public BaseRepository()
        {
            Connection = new SqlConnection(ConfigurationManager.AppSettings["GroceryDB"]);
        }

        public List<T> GetAll()
        {
            string query = $"SELECT * FROM {Table}";

            try
            {
                return Connection.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return new List<T>();
            }
        }

        public bool Add(T data)
        {
            try
            {
                List<string> filedList = new List<string>();
                List<string> valueList = new List<string>();
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    filedList.Add(property.Name);
                    valueList.Add("@" + property.Name);
                }

                string field = string.Join(", ", filedList);
                string value = string.Join(", ", valueList);

                string query = $"INSERT INTO {Table} ({field}) VALUES ({value})";

                int count = Connection.Execute(query, data);
                return count == 1;
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return false;
            }
        }

        public T GetById(int id, string name)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string condition = $"{name}=@Id";

                string query = $"SELECT * FROM {Table} WHERE {condition}";

                return Connection.Query<T>(query, new { Id = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return null;
            }
        }

        public List<T> GetAllById(int id, string name)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                string condition = $"{name}=@Id";

                string query = $"SELECT * FROM {Table} WHERE {condition}";

                return Connection.Query<T>(query, new { Id = id }).ToList();
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return null;
            }
        }

        public bool Update(T data)
        {
            try
            {
                List<string> fieldList = new List<string>();
                PropertyInfo[] properties = typeof(T).GetProperties();

                string condition = $"{properties[0].Name}=@{properties[0].Name}";

                foreach (PropertyInfo property in properties)
                {
                    fieldList.Add($"{property.Name} = @{property.Name}");
                }

                string field = string.Join(", ", fieldList);

                string query = $"UPDATE {Table} SET {field} WHERE {condition}";
                int count = Connection.Execute(query, data);
                return count == 1;
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return false;
            }
        }

        public bool Delete(int[] ids, string name)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (int id in ids)
                    {
                        PropertyInfo[] properties = typeof(T).GetProperties();
                        string condition = $"{name}=@Id";

                        string query = $"DELETE FROM {Table} WHERE {condition}";

                        int count = Connection.Execute(query, new { Id = id });

                        if (count != 1)
                        {
                            return false;
                        }
                    }

                    scope.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.StackTrace);
                return false;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public override string Table => "Customer";

    }
}

using System.Collections.Generic;
using ShoppingCart.Business.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ShoppingCart.Business.Entity;
using System;
using System.Configuration;

namespace ShoppingCart.Business.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public override string Table => "Purchase";
    }
}

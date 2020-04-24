using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ShoppingCart.Business.Repository.Interfaces;
using ShoppingCart.Business.Entity;


namespace ShoppingCart.Business.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public override string Table => "Item";
    }
}

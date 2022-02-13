using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.DAL.Repository
{
    public class TransactionsRepository : BaseRepository
    {
        private ShopDBEntities db;
        public TransactionsRepository(ShopDBEntities context)
        {
            db = context;
        }

        public List<TransactionsMapper> GetAllTransactionMapper()
        {
            return db.TransactionsMapper.Where(x =>  x.IsActive == true).ToList();
        }
        public TransactionsMapper GetByIdTransactionMapper(long id)
        {
            return db.TransactionsMapper.FirstOrDefault(x=>x.TMapperID== id && x.IsActive == true);
        }

        public TransactionsMapper GetByTransactionName(string name)
        {
            return db.TransactionsMapper.FirstOrDefault(x => x.TransactionName == name && x.IsActive==true);
        }

        public void InsertTransaction(Transactions tran)
        {
            try
            {
                db.Transactions.Add(tran);   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

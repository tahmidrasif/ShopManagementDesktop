using System.Data.Entity.Infrastructure;
using ShopManagement.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShopManagement.DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ShopDBEntities context;
        private bool _disposed = false;
        private TransactionScope Transaction;


        //private OrderRepository _repoOrder;
        //private ProductRepository _repoProduct;
        //private StockRepository _repoStock;
        //private UnitRepository _repoUnit;
        //private PaymentRepository _repoPayment;
        //private EnumarationRepository _repoEnum;
        //private CategoryRepository _repoCategory;
        //private BaseSPRepository _repoBaseSp;
        //private VendorRepository _repoVendor;
        public OrderRepository repoOrder
        {
            get
            {
                return new OrderRepository(context);
            }
        }

        public ProductRepository repoProduct
        {
            get
            {
                return new ProductRepository(context) ;
            }
        }

        public StockRepository repoStock
        {
            get
            {
                return  new StockRepository(context);
            }
        }

        public UnitRepository repoUnit
        {
            get
            {
                return new UnitRepository(context);
            }
        }

        public PaymentRepository repoPayment
        {
            get
            {
                return  new PaymentRepository(context);
            }
        }

        public EnumarationRepository repoEnum
        {
            get
            {
                return new EnumarationRepository(context);
            }
        }

        public CategoryRepository repoCategory
        {
            get
            {
                return new CategoryRepository(context) ;
            }
        }

        public BaseSPRepository repoBaseSp
        {
            get
            {
                return new BaseSPRepository(context);
            }
        }

        public VendorRepository repoVendor
        {
            get
            {
                return  new VendorRepository(context);
            }
        }

        public PurchaseOrderRepository repoPurchaseOrder
        {
            get
            {
                return new PurchaseOrderRepository(context);
            }
        }

        public UnitOfWork()
        {
            context = new ShopDBEntities();
           
        }
        public void BeginTrnsaction()
        {
            if(Transaction==null)
            Transaction = new TransactionScope();
        }
        public void  CommitTransaction()
        {
            if(Transaction!=null)
            {
                Transaction.Complete();
                this.Transaction.Dispose();
                this.Transaction = null;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void SaveWithConcurrencyCheck()
        {
            bool saved = false;
            do
            {
                try
                {
                    if (context.SaveChanges() > 0)
                    {
                        saved = true;
                    }
                    // Attempt to save changes to the database


                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        //if (entry.Entity is CustomerBalance)
                        //{
                        //    var databaseEntry = entry.GetDatabaseValues();
                        //    var databaseValue = (CustomerBalance)databaseEntry.ToObject();

                        //    databaseValue.Balance += amount;
                        //    entry.OriginalValues.SetValues(databaseEntry);
                        //    entry.CurrentValues.SetValues(databaseValue);
                        //}

                    }
                }
            }
            while (!saved);
        }

        public void RollbackTransaction()
        {
            if (Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                context.Dispose();
            }

            _disposed = true;
        }

        
    }
}

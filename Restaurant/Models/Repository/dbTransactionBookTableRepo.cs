
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbTransactionBookTableRepo : IRepository<TransactionBookTable>
    {
        private readonly AppDbContext db;

        public dbTransactionBookTableRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionBookTable entity)
        {
            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, TransactionBookTable entity)
        {
            TransactionBookTable data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public TransactionBookTable Find(int id)
        {
            return db.TransactionBookTables.SingleOrDefault(x => x.TransactionBookTableId == id);
        }

        public void Update(int id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionBookTable> View()
        {
            return db.TransactionBookTables.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionBookTable> ViewFromClient()
        {
            return db.TransactionBookTables.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

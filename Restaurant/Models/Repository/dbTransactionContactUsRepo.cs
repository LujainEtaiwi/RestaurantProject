
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbTransactionContactUsRepo : IRepository<TransactionContactUs>
    {
        private readonly AppDbContext db;

        public dbTransactionContactUsRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionContactUs entity)
        {
            db.TransactionContactUs.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, TransactionContactUs entity)
        {
            TransactionContactUs data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public TransactionContactUs Find(int id)
        {
            return db.TransactionContactUs.SingleOrDefault(x => x.TransactionContactUsId == id);
        }

        public void Update(int id, TransactionContactUs entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionContactUs> View()
        {
            return db.TransactionContactUs.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionContactUs> ViewFromClient()
        {
            return db.TransactionContactUs.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

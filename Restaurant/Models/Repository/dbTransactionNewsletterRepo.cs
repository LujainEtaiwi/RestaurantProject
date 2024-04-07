using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbTransactionNewsletterRepo:IRepository<TransactionNewsletter>
    {
        private readonly AppDbContext db;

        public dbTransactionNewsletterRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionNewsletter entity)
        {
            db.TransactionNewsletters.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, TransactionNewsletter entity)
        {
            TransactionNewsletter data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public TransactionNewsletter Find(int id)
        {
            return db.TransactionNewsletters.SingleOrDefault(x => x.TransactionNewsletterId == id);
        }

        public void Update(int id, TransactionNewsletter entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionNewsletter> View()
        {
            return db.TransactionNewsletters.Where(x => x.IsDelete == false).ToList();
        }

        public List<TransactionNewsletter> ViewFromClient()
        {
            return db.TransactionNewsletters.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}


using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbReviewRepo : IRepository<Review>
    {
        private readonly AppDbContext db;

        public dbReviewRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, Review entity)
        {
            Review data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(Review entity)
        {
            db.Reviews.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, Review entity)
        {
            Review data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public Review Find(int id)
        {
            return db.Reviews.SingleOrDefault(x => x.ReviewId == id);
        }

        public void Update(int id, Review entity)
        {
            db.Reviews.Update(entity);
            db.SaveChanges();
        }

        public List<Review> View()
        {
            return db.Reviews.Where(x => x.IsDelete == false).ToList();
        }

        public List<Review> ViewFromClient()
        {
            return db.Reviews.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

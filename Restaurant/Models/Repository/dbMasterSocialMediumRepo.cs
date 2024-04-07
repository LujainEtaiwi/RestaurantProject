
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterSocialMediumRepo : IRepository<MasterSocialMedium>
    {
        private readonly AppDbContext db;

        public dbMasterSocialMediumRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterSocialMedium entity)
        {
            MasterSocialMedium data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterSocialMedium entity)
        {
            db.MasterSocialMedium.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterSocialMedium entity)
        {
            MasterSocialMedium data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterSocialMedium Find(int id)
        {
            return db.MasterSocialMedium.SingleOrDefault(x => x.MasterSocialMediumId == id);
        }

        public void Update(int id, MasterSocialMedium entity)
        {
            db.MasterSocialMedium.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSocialMedium> View()
        {
            return db.MasterSocialMedium.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSocialMedium> ViewFromClient()
        {
            return db.MasterSocialMedium.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}


using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterServicesRepo : IRepository<MasterServices>
    {
        private readonly AppDbContext db;

        public dbMasterServicesRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterServices entity)
        {
            MasterServices data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterServices entity)
        {
            db.MasterServices.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterServices entity)
        {
            MasterServices data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterServices Find(int id)
        {
            return db.MasterServices.SingleOrDefault(x => x.MasterServicesId == id);
        }

        public void Update(int id, MasterServices entity)
        {
            db.MasterServices.Update(entity);
            db.SaveChanges();
        }

        public List<MasterServices> View()
        {
            return db.MasterServices.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterServices> ViewFromClient()
        {
            return db.MasterServices.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

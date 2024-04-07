
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterWorkingHoursRepo : IRepository<MasterWorkingHours>
    {
        private readonly AppDbContext db;

        public dbMasterWorkingHoursRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterWorkingHours entity)
        {
            MasterWorkingHours data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterWorkingHours entity)
        {
            db.MasterWorkingHours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterWorkingHours entity)
        {
            MasterWorkingHours data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterWorkingHours Find(int id)
        {
            return db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHoursId == id);
        }

        public void Update(int id, MasterWorkingHours entity)
        {
            db.MasterWorkingHours.Update(entity);
            db.SaveChanges();
        }

        public List<MasterWorkingHours> View()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHours> ViewFromClient()
        {
            return db.MasterWorkingHours.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

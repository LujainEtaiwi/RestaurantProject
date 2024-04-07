
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbSystemSettingRepo : IRepository<SystemSetting>
    {
        private readonly AppDbContext db;

        public dbSystemSettingRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, SystemSetting entity)
        {
            SystemSetting data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(SystemSetting entity)
        {
            db.SystemSettings.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, SystemSetting entity)
        {
            SystemSetting data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public SystemSetting Find(int id)
        {
            return db.SystemSettings.SingleOrDefault(x => x.SystemSettingId == id);
        }

        public void Update(int id, SystemSetting entity)
        {
            db.SystemSettings.Update(entity);
            db.SaveChanges();
        }

        public List<SystemSetting> View()
        {
            return db.SystemSettings.Where(x => x.IsDelete == false).ToList();
        }

        public List<SystemSetting> ViewFromClient()
        {
            return db.SystemSettings.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

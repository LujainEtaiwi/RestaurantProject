
using Microsoft.AspNetCore.Identity;
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterMenuRepo : IRepository<MasterMenu>
    {
        private readonly AppDbContext db;

        public dbMasterMenuRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterMenu entity)
        {
            db.MasterMenus.Add(entity);
            db.SaveChanges();
        }
        public void Delete(int id, MasterMenu entity)
        {
            MasterMenu data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterMenu Find(int id)
        {
            return db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == id);
        }

        public void Update(int id, MasterMenu entity)
        {
            db.MasterMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterMenu> View()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewFromClient()
        {
            return db.MasterMenus.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

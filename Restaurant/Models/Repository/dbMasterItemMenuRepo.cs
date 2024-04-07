
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterItemMenuRepo : IRepository<MasterItemMenu>
    {
        private readonly AppDbContext db;

        public dbMasterItemMenuRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterItemMenu entity)
        {
            MasterItemMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterItemMenu entity)
        {
            db.MasterItemMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterItemMenu entity)
        {
            MasterItemMenu data=Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterItemMenu Find(int id)
        {
            return db.MasterItemMenus.Include(x => x.MasterCategoryMenu).SingleOrDefault(y => y.MasterItemMenuId == id);
        }

        public void Update(int id, MasterItemMenu entity)
        {
            db.MasterItemMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterItemMenu> View()
        {
            return db.MasterItemMenus.Include(x=>x.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewFromClient()
        {
            return db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x=>x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

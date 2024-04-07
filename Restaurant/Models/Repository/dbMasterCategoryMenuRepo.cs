
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterCategoryMenuRepo : IRepository<MasterCategoryMenu>
    {
        private readonly AppDbContext db;

        public dbMasterCategoryMenuRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Add(MasterCategoryMenu entity)
        {
            db.MasterCategoryMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterCategoryMenu Find(int id)
        {
            return db.MasterCategoryMenus.SingleOrDefault(x=>x.MasterCategoryMenuId == id);
        }

        public void Active(int id, MasterCategoryMenu entity)
        {
            MasterCategoryMenu data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Update(int id, MasterCategoryMenu entity)
        {
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
        }

        public List<MasterCategoryMenu> View()
        {
            return db.MasterCategoryMenus.Where(x=>x.IsDelete==false).ToList();
        }

        public List<MasterCategoryMenu> ViewFromClient()
        {
            return db.MasterCategoryMenus.Where(x=>x.IsActive && x.IsDelete==false).ToList();
        }
    }
}

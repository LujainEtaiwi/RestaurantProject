
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterSliderRepo : IRepository<MasterSlider>
    {
        private readonly AppDbContext db;

        public dbMasterSliderRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterSlider entity)
        {
            db.MasterSliders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterSlider entity)
        {
            MasterSlider data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterSlider Find(int id)
        {
            return db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == id);
        }

        public void Update(int id, MasterSlider entity)
        {
            db.MasterSliders.Update(entity);
            db.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewFromClient()
        {
            return db.MasterSliders.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

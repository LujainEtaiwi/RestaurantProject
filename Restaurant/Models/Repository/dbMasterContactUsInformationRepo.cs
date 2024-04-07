
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterContactUsInformationRepo : IRepository<MasterContactUsInformation>
    {
        private readonly AppDbContext db;

        public dbMasterContactUsInformationRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public void Add(MasterContactUsInformation entity)
        {
            db.MasterContactUsInformations.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterContactUsInformation entity)
        {
            MasterContactUsInformation data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterContactUsInformation Find(int id)
        {
            return db.MasterContactUsInformations.SingleOrDefault(x=>x.MasterContactUsInformationId == id);
        }

        public void Update(int id, MasterContactUsInformation entity)
        {
            db.MasterContactUsInformations.Update(entity);
            db.SaveChanges();
        }

        public List<MasterContactUsInformation> View()
        {
            return db.MasterContactUsInformations.Where(x=>x.IsDelete==false).ToList();
        }

        public List<MasterContactUsInformation> ViewFromClient()
        {
            return db.MasterContactUsInformations.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

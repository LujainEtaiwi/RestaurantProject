
using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterPartnerRepo : IRepository<MasterPartner>
    {
        private readonly AppDbContext db;

        public dbMasterPartnerRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterPartner entity)
        {
            db.MasterPartners.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterPartner entity)
        {
            MasterPartner data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public MasterPartner Find(int id)
        {
            return db.MasterPartners.SingleOrDefault(x => x.MasterPartnerId == id);
        }

        public void Update(int id, MasterPartner entity)
        {
            db.MasterPartners.Update(entity);
            db.SaveChanges();
        }

        public List<MasterPartner> View()
        {
            return db.MasterPartners.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterPartner> ViewFromClient()
        {
            return db.MasterPartners.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}


using Restaurant.Data;

namespace Restaurant.Models.Repository
{
    public class dbMasterOfferRepo : IRepository<MasterOffer>
    {
        private readonly AppDbContext db;

        public dbMasterOfferRepo(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(MasterOffer entity)
        {
            db.MasterOffers.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id, MasterOffer entity)
        {
            MasterOffer data = Find(id);
            data.IsActive = false;
            data.IsDelete = true;
            data.EditDate = entity.EditDate;
            data.EditUser = entity.EditUser;
            Update(id, data);
        }

        public MasterOffer Find(int id)
        {
            return db.MasterOffers.SingleOrDefault(x => x.MasterOfferId == id);
        }

        public void Update(int id, MasterOffer entity)
        {
            db.MasterOffers.Update(entity);
            db.SaveChanges();
        }

        public List<MasterOffer> View()
        {
            return db.MasterOffers.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterOffer> ViewFromClient()
        {
            return db.MasterOffers.Where(x => x.IsActive && x.IsDelete == false).ToList();
        }
    }
}

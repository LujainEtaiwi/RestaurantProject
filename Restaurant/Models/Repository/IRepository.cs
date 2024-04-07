namespace Restaurant.Models.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id, T entity);
        T Find(int id);
        List<T> View();
        void Active(int id, T entity);
        List<T> ViewFromClient();
    }
}

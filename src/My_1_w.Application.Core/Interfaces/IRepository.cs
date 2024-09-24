namespace My_1_w.Application.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? GetbyId (int id);
        void Update(T entity);
        List<T> GetAll();

        Task<List<T>> GetAllAsync();
    }
}

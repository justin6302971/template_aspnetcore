namespace SP.Data.Repository.Interface
{
   /// <summary>
   /// handle repositories and saving mechanism
   /// </summary>
    public interface IUnitOfWork
    {
        void SaveChanges();

        IGenericRepository<T> Repository<T>() where T : class;
    }
}
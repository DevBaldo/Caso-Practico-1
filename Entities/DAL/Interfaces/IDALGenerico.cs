
namespace DAL.Interfaces
{
    public interface IDALGenerico<TEntity> where TEntity : class
    {

        

        bool Add(TEntity entity);


        bool Update(TEntity entity);
        bool Remove(TEntity entity);


        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

    }
}

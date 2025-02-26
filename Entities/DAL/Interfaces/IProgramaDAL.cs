using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IProgramaDAL : IDALGenerico<Programa>
    {
        
        List<Programa> GetAllProgramas();


    }
}

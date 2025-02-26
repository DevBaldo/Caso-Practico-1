
namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        IProgramaDAL ProgramaDAL { get; }

        bool Complete();
    }
}

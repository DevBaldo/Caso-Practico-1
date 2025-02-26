
using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IProgramaService
    {

        void AddPrograma(ProgramaDTO Programa);
        void UpdatePrograma(ProgramaDTO Programa);
        void DeletePrograma(int id);
        List<ProgramaDTO> GetProgramas();
        ProgramaDTO GetProgramaById(int id);
    }
}

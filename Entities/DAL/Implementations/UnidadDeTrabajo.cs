using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IProgramaDAL ProgramaDAL { get; set; }

        private PeliculasContext _peliculasContext;

        public UnidadDeTrabajo(PeliculasContext peliculasContext, IProgramaDAL peliculaDAL)

        {
            this._peliculasContext = peliculasContext;
            this.ProgramaDAL = peliculaDAL;
        }


        public bool Complete()
        {
            try
            {
                _peliculasContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._peliculasContext.Dispose();
        }
    }
}

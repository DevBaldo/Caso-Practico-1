using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class ProgramaDAL : DALGenericoImpl<Programa>, IProgramaDAL
    {
        private PeliculasContext _context;

        public ProgramaDAL(PeliculasContext context) : base(context)
        {
            _context = context;
        }

        public List<Programa> GetAllProgramas()
        {
            string query = "EXEC sp_GetAllProgramas";
            return _context.Programas.FromSqlRaw(query).ToList();
        }

        public Programa GetProgramaById(int programaId)
        {
            string query = "EXEC sp_GetProgramaById @ProgramaId";
            var param = new SqlParameter("@ProgramaId", programaId);
            return _context.Programas.FromSqlRaw(query, param).FirstOrDefault();
        }

        public bool Add(Programa entity)
        {
            try
            {
                string sql = "EXEC sp_CreatePrograma @Nombre, @Tipo, @Categoria";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", entity.Nombre),
                    new SqlParameter("@Tipo", entity.Tipo),
                    new SqlParameter("@Categoria", entity.Categoria)
                };
                _context.Database.ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Programa entity)
        {
            try
            {
                string sql = "EXEC sp_UpdatePrograma @ProgramaId, @Nombre, @Tipo, @Categoria";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ProgramaId", entity.ProgramaId),
                    new SqlParameter("@Nombre", entity.Nombre),
                    new SqlParameter("@Tipo", entity.Tipo),
                    new SqlParameter("@Categoria", entity.Categoria)
                };
                _context.Database.ExecuteSqlRaw(sql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(int programaId)
        {
            try
            {
                string sql = "EXEC sp_DeletePrograma @ProgramaId";
                var param = new SqlParameter("@ProgramaId", programaId);
                _context.Database.ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
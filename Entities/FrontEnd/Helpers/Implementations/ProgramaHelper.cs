using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class ProgramaHelper : IProgramaHelper
    {
        IServiceRepository _ServiceRepository;

        ProgramaViewModel Convertir(ProgramaAPI programa)
        {
            return new ProgramaViewModel
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                TipoNombre = programa.TipoNombre,
                Categoria = programa.Categoria,
                CategoriaNombre = programa.CategoriaNombre
            };
        }

        ProgramaAPI Convertir(ProgramaViewModel programa)
        {
            return new ProgramaAPI
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                TipoNombre = programa.TipoNombre,
                Categoria = programa.Categoria,
                CategoriaNombre = programa.CategoriaNombre
            };
        }


        public ProgramaHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public ProgramaViewModel Add(ProgramaViewModel programa)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Programa", Convertir(programa));
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync().Result;
            }
            return programa;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Programa/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public List<ProgramaViewModel> GetProgramas()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Programa");
            List<ProgramaAPI> programas = new List<ProgramaAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programas = JsonConvert.DeserializeObject<List<ProgramaAPI>>(content);
            }
            List<ProgramaViewModel> lista = new List<ProgramaViewModel>();
            foreach (var programa in programas)
            {
                lista.Add(Convertir(programa));
            }
            return lista;
        }

        public ProgramaViewModel GetPrograma(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Programa/" + id.ToString());
            ProgramaAPI programa = new ProgramaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programa = JsonConvert.DeserializeObject<ProgramaAPI>(content);
            }

            ProgramaViewModel resultado = Convertir(programa);


            return resultado;
        }

        public ProgramaViewModel Update(ProgramaViewModel programa)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Programa", Convertir(programa));
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content;
            }
            return programa;
        }
    }
}

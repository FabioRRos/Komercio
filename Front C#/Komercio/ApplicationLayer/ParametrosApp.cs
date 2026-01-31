using Komercio.Models;
using Komercio.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Komercio.ApplicationLayer
{
    public class ParametrosApp
    {
        private readonly ParametrosService _parametrosService;

        private List<ParametroDTO> _parametros;

        public ParametrosApp(ParametrosService parametrosService)
        {
            _parametrosService = parametrosService;
        }
        

        public async Task InicializarAsync()
        {
            _parametros = await RetornarListaDeParametros();
        }

        public async Task<List<ParametroDTO>> RetornarListaDeParametros()
        {
            return await _parametrosService.GetParametros();
        }

        public async Task<List<ParametroDTO>> AtualizaStatusDaListaDeParametros(
            List<ParametroDTO> listaDeParametros)
        {
            _parametros = await _parametrosService.PutParametros(listaDeParametros);
            return _parametros;
        }
        //APÓS O TERMINO, REFATORAR ESTA PARTE!!!! NÃO DEIXAR CONSULTA TODA VEZ
        //ISSO PODE CAUSAR LENTIDÃO NAS VERIFICAÇÕES
        //SALVAR EM CACHE FUTURAMENTE (PERSISTENCIA).
        public async Task<bool> ConsultaStatusParametro(int id)
        {
            var parametros = await RetornarListaDeParametros();

            if (parametros == null)
                return false;

            foreach (var item in parametros)
            {
                if (item.Parametro_Id == id)
                    return item.Parametro_status;
            }

            return false;
        }
    }
}

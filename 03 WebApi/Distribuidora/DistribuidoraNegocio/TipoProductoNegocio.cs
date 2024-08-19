using DistribuidoraAcesoDatos.Configuracion;
using DistribuidoraAcesoDatos.Interfaces;
using DistribuidoraEntities.Entidades;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraNegocio
{
    public class TipoProductoNegocio
    {
        private readonly ITipoProducto _tipoProducto;
        public TipoProductoNegocio(ITipoProducto options)
        {
            _tipoProducto = options;
            
        }

        public  async Task<List<TipoProducto>> ObtenerTipoProducto()
        {
            return await _tipoProducto.ObtenerTipoProducto();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistribuidoraEntities.Entidades;

namespace DistribuidoraAcesoDatos.Interfaces
{
    public interface ITipoProducto
    {
        Task<List<TipoProducto>> ObtenerTipoProducto();
        int GuardarTipoProducto(TipoProducto tipoProducto);
    }
}

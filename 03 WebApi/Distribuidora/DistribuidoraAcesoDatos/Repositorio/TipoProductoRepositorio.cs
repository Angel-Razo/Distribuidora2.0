using DistribuidoraAcesoDatos.Configuracion;
using DistribuidoraAcesoDatos.Interfaces;
using DistribuidoraEntities.Diccionarios;
using DistribuidoraEntities.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraAcesoDatos.Repositorio
{
    public class TipoProductoRepositorio : ITipoProducto
    {
        private readonly ConfiguracionConexion _SQlServer;
        public TipoProductoRepositorio(IOptions<ConfiguracionConexion> SQlServer)
        {
            _SQlServer = SQlServer.Value;
            
        }

        

        public async Task<List<TipoProducto>> ObtenerTipoProducto()
        {
            List<TipoProducto> tipoProductos = new List<TipoProducto>();

            using (var sqlServer=new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand command = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_TipoProducto_Obt, sqlServer);
                command.CommandType = CommandType.StoredProcedure;

                using (var dr= await command.ExecuteReaderAsync())
                {
                    while( await dr.ReadAsync() ) {
                        tipoProductos.Add(new TipoProducto()
                        {
                            Id = Convert.ToInt32(dr[nameof(TipoProducto.Id)])
                            , Descripcion = dr[nameof(TipoProducto.Descripcion)].ToString()
                            , Estatus = Convert.ToBoolean( dr[nameof(TipoProducto.Estatus)])
                        }); 
                    }

                }

            }

            return tipoProductos;
        }
        public  int GuardarTipoProducto(TipoProducto tipoProducto)
        {

            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_TipoProducto_Ins, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(TipoProducto.Descripcion), tipoProducto.Descripcion);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            }

            
        }
    }
}

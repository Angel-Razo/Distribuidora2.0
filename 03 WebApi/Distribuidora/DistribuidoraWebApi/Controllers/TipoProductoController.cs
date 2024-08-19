using DistribuidoraEntities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DistribuidoraAcesoDatos.Repositorio;
using DistribuidoraAcesoDatos.Interfaces;
using DistribuidoraEntities.Entidades;
using System.Collections.Generic;
using DistribuidoraNegocio;

namespace DistribuidoraWebApi.Controllers
{
    public class TipoProductoController : ControllerBase
    {
        private readonly ITipoProducto _tipoProducto;
       // private readonly TipoProductoNegocio tipoProductoNegocio;

        public TipoProductoController(ITipoProducto repositorio)
        {
            _tipoProducto = repositorio;
           
        }
        [HttpGet("ObtenerTodo")]
        public async Task<BaseDto<List<TipoProducto>>>  GetAll() 
        {
            BaseDto<List<TipoProducto>> response = new BaseDto<List<TipoProducto>>();
            try
            {

                response.completado = true;
                response.Mensaje = "Si Jalo";
                response.Datos = await _tipoProducto.ObtenerTipoProducto();
            }
            catch (Exception ex)
            {
                
                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }
            return response;
        }

        // GET: TipoProductoController/Details/5
        [HttpGet("TipoProducto")]
        public BaseDto<int> Details(int id)
        {
            BaseDto<int> response = new BaseDto<int>();

            try
            {

                response.completado = true;
                response.Mensaje = "Si Jalo";
                response.Datos = 1;
            }
            catch (Exception ex)
            {
                response.completado = false;
                response.Mensaje = "Trono";
                throw ex;
            }

            return response;
        }

       
        [HttpPost("Crear")]
        public  BaseDto<int> Post(TipoProducto tipoProducto)
        {
            BaseDto<int> response = new BaseDto<int>();

            try
            {
                if (_tipoProducto.GuardarTipoProducto(tipoProducto) > 0)
                {
                    response.completado = true;
                    response.Mensaje = "Guardado";
                    response.Datos = 1;
                }
                else
                {
                    response.completado = false;
                    response.Mensaje = "No se guardado";
                    response.Datos = 0;
                }
                  
            }
            catch (Exception ex)
            {
                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }

            return  response;
        }

        // POST: TipoProductoController/Create
        //[HttpPost]
      
        //public BaseDto<string> Create()
        //{
        //    try
        //    {
        //       // return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return new BaseDto<string>();
        //    }
        //}

        //// GET: TipoProductoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TipoProductoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TipoProductoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TipoProductoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

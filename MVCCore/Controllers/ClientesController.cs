using BussinesLogic.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IService<Clientes> service;
        public ClientesController(IService<Clientes> service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await service.List();
            return View(lista);
        }

        public async Task<IActionResult> Listado()
        {
            var lista = await service.List();
            return View(lista);
        }

        public IActionResult ListadoView()
        {
            ViewData["Controller"] = "Clientes";
            return View();
        }

        public async Task<List<Clientes>> ListadoAjax()
        {
            var lista = await service.List();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(int id)
        {
            var result = await service.SearchById(id);
            return result;
        }


        public async Task<ActionResult> AddEdit(int id)
        {
            var model = new Clientes();
            if(id !=0)//Actualización
            {
                model = await service.SearchById(id);

            }

            return PartialView("_AddEdit", model);
        }
        [HttpPost]
        public async Task<ActionResult<Clientes>> Save(Clientes model)
        {
            if (model.IdCliente == 0)//Add
            {
                model = await service.Add(model);

            }
            else
            {
                await service.Update(model);
            }

            return CreatedAtAction("Get", new { id = model.IdCliente }, model);//Regresa lo que regresa una acción
        }

        [HttpPost]
        public async Task<ActionResult<Clientes>> Delete(int id)
        {
            try
            {
                var entity = await service.SearchById(id);
                if (entity == null)
                {
                    return NotFound();
                }

                await service.Delete(id);

                return Ok(entity);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

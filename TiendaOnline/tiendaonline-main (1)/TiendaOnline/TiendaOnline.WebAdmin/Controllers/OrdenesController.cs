using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.WebAdmin.Controllers;

namespace TiendaOnline.WebAdmin.Controllers
{
    public class OrdenesController : Controller
    {

        OrdenesBL _ordenesBL;
        ClienteBL _clientesBL;
        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            _clientesBL = new ClienteBL();
            
        }

            // GET: Ordenes

        public ActionResult Index()

        {
            var ListadeOrdenes = _ordenesBL.ObtenerOrdenes();

            return View(ListadeOrdenes );
        }
        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            var cliente = ClienteBL.ObtenerClientes();

            ViewBag.clienteId = new SelectList(cliente, "Id", "Nombre");


            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden Orden)
        {
            if (ModelState .IsValid)
            {
                if (Orden.ClienteId ==0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(Orden);
                }

                _ordenesBL.GuardarOrden();

                return RedirectToAction("Index");
            }

            var cliente = ClienteBL.ObtenerClientes(Orden );

            ViewBag.clienteId = new SelectList(cliente, "Id", "Nombre");


            return View(orden);
        }
    }

 
   
    }

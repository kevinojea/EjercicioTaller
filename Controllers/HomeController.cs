using EjercicioTaller.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioTaller.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context db;
        public HomeController(Context context)
        {
            this.db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Auto()
        {
            return View();
        }

        public IActionResult Moto()
        {
            return View();
        }

        public IActionResult Desp()
        {
            return View();
        }

        public IActionResult Rep()
        {
            return View();
        }

        public async Task<IActionResult> CrearAuto (string Marca, string Modelo, string Patente, string Tipo, int CantidadPuertas)
        {
            if (ModelState.IsValid)
            {
                Automovil automovil = new Automovil
                {
                    Marca = Marca,
                    Modelo = Modelo,
                    Patente = Patente,
                    Tipo = Tipo,
                    CantidadPuertas = CantidadPuertas,
                };
                db.Add(automovil);
                await db.SaveChangesAsync();
                return RedirectToAction("Auto");
            }
            return View();
        }

        public async Task<IActionResult> CrearMoto(string Marca, string Modelo, string Patente, int Cilindrada)
        {
            if (ModelState.IsValid)
            {
                Moto moto = new Moto
                {
                    Marca = Marca,
                    Modelo = Modelo,
                    Patente = Patente,
                    Cilindrada = Cilindrada,
                };
                db.Add(moto);
                await db.SaveChangesAsync();
                return RedirectToAction("Moto");
            }
            return View();
        }

        public async Task<IActionResult> CrearDesperfecto(int VehiculoRefID, string Descripcion, int ManoDeObra, int Tiempo)
        {
            if (ModelState.IsValid)
            {
                Desperfecto desperfecto = new Desperfecto
                {
                    VehiculoRefID = VehiculoRefID,
                    Descripcion = Descripcion,
                    ManoDeObra = ManoDeObra,
                    Tiempo = Tiempo,
                };
                db.Add(desperfecto);
                await db.SaveChangesAsync();
                return RedirectToAction("Desp");
            }
            return View();
        }

        public async Task<IActionResult> CrearRepuesto (int DesperfectoRefID, string Nombre, int Precio)
        {
            if (ModelState.IsValid)
            {
                Repuesto repuesto = new Repuesto
                {
                    DesperfectoRefID = DesperfectoRefID,
                    Nombre = Nombre,
                    Precio = Precio,
                };
                db.Add(repuesto);
                await db.SaveChangesAsync();
                return RedirectToAction("Rep");
            }
            return View();
        }

        public IActionResult CalcPresupuesto (int VehiculoID, string porcTipo, int porcCant)
        {
            int manodeObra = 0, repuesto = 0, estacionamiento = 0, total = 0;

            foreach (var desp in db.Desperfecto.Where (d => d.VehiculoRefID == VehiculoID).ToList() )
            {
                manodeObra += desp.ManoDeObra;
                estacionamiento += desp.Tiempo;
                foreach (var rep in db.Repuesto.Where (r => r.DesperfectoRefID == desp.ID) )
                {
                    repuesto += rep.Precio;
                }
            }

            total = manodeObra + repuesto + (estacionamiento * 30) ;

            switch (porcTipo)
            {
                case "descuento":
                    //total -= ( (porcCant - 10) * total) / 100;
                    total -= ( (porcCant) * total) / 100 ;
                    break;

                case "recargo":
                    //total += ( (porcCant + 10) * total) / 100;
                    total += ( (porcCant) * total) / 100;
                    break;
            }

            total += ( 10 * total) / 100;

            return Json(total);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using ALUMNO_PIA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ALUMNO_PIA.Servicios;

namespace ALUMNO_PIA.Controllers
{
    public class HomeController : Controller
    {
        private readonly Registrar_Alumno_API _servicioApi;

        public HomeController(Registrar_Alumno_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Alumno> Lista = await _servicioApi.Lista();
            return View(Lista);
        }

        public async Task<IActionResult> Alumno(int IdMatricula)
        {
            Alumno modelo_alumno = new Alumno();
            ViewBag.Accion = "Nuevo Alumno";

            if (IdMatricula != 0)
            {
                modelo_alumno = await _servicioApi.Obtener(IdMatricula);
                ViewBag.Accion = "Editar Alumno";
            }

            return View(modelo_alumno);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Alumno ob_alumno)
        {
            bool respuesta;

            if (ob_alumno.IdMatricula == 0)
            {
                respuesta = await _servicioApi.Guardar(ob_alumno);

            }
            else
            {
                respuesta = await _servicioApi.Editar(ob_alumno);
            }
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int IdMatricula)
        {
            var respuesta = await _servicioApi.Eliminar(IdMatricula);
            if (respuesta)
                return RedirectToAction("Index");
            else
                return NoContent();

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

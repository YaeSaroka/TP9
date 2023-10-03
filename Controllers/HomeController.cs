using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP9.Models;

namespace TP9.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Registro()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
     public IActionResult Olvido()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Account(string Username, string Contraseña)
    {
        Usuario Usuario = BD.LoginUsuario(Username, Contraseña);
        Usuario userr = BD.Login_VerificarExistencia(Contraseña);
        if (Usuario == null )
        {
            ViewBag.MensajeError = "Usuario inexistente";
            return View("Login");
        }
        else if(userr ==null)
        {
            ViewBag.MensajeError2 = " Contraseña incorrecta";
            return View("Login");
        }
        else
        {
            ViewBag.Usuario = Usuario;
            return View("Bienvenida");
        }
    }
[HttpPost]
    public IActionResult RegistrarUsuario(Usuario user){
        Usuario userr = BD.Registro_VerificarExistencia(user.Username);
        if(userr == null){
            BD.Registro(user);
            return View("Index");
        }
        else{
            ViewBag.MSJError= "El usuario ya existe !";
            return View("Registro");
        }
    }
    public IActionResult OlvidarContraseña(string Mail)
    {
        string contraseña = BD.GetBy(Mail);
        if(contraseña == null || contraseña == "") {
            ViewBag.MensajeInexistente = "No existe el mail ingresado en la base de datos. . . ";
            return View("Olvido");
        }
        else
        {
            ViewBag.ContraseñaRecordada = contraseña;
            return View("Olvido");
        }
   
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

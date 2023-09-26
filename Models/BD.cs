using System.Data.SqlClient;
using Dapper;
namespace TP9.Models;
public static class BD
{
    private static string ConnectionString { get; set; } = @"Server=.;DataBase=Registro;Trusted_Connection=True;";

    public static Usuario LoginUsuario(string Username, string Contraseña)
    {
        Usuario usuario = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Usuario WHERE Username = @pUsername AND Contraseña= @pContraseña";
            usuario = db.QueryFirstOrDefault<Usuario>(sql, new { pUsername = Username, pContraseña = Contraseña });
        }
        return usuario;
    }

    public static void Registro(Usuario user)
    {
        string SQL = "INSERT INTO Usuario(Username, Contraseña, Mail, DNI, Nombre) VALUES (@pUsername, @pContraseña, @pMail, @pDNI, @pNombre)";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            db.Execute(SQL, new { pUsername = user.Username, pContraseña = user.Contraseña, pMail = user.Mail, pDNI = user.DNI, pNombre = user.Nombre });
        }
    }

    public static string GetBy(string Mail)
    {
        string Contraseña_recuperada = "";
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT Contraseña FROM Usuario WHERE Mail = @pMail";
            Contraseña_recuperada = db.QueryFirstOrDefault<string>(sql, new { pMail = Mail });
        }
        return Contraseña_recuperada;
    }
}

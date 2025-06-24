using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    // Utilizamos el principio de inversión de dependencias que dice 
    // que las clases deben depender de abstracciones y no de tipos concretos

    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tipoCuenta);
    }

    public class RepositorioTiposCuenta:IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositorioTiposCuenta(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);

            //QuerySingle lo que hace es traer un solo resultado
            var id = await connection.QuerySingleAsync<int>
                                                ($@"INSERT INTO TipoCuenta (Nombre, UsuarioId, Orden)
                                                 VALUES (@Nombre, @UsuarioId, 0);SELECT SCOPE_IDENTITY();", tipoCuenta);

            tipoCuenta.IdTipoCuenta = id;
        }
    }
}

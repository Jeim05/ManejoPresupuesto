using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManejoPresupuesto.Servicios
{
    // Utilizamos el principio de inversión de dependencias que dice 
    // que las clases deben depender de abstracciones y no de tipos concretos

    public interface IRepositorioTiposCuentas
    {
        Task Actualizar(TipoCuenta tipoCuenta);
        Task Borrar(int Id);
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(string nombre, int usuarioId);
        Task<IEnumerable<TipoCuenta>> Obtener(int UsuarioId);
        Task<TipoCuenta> ObtenerPorId(int Id, int UsuarioId);
        Task Ordenar(IEnumerable<TipoCuenta> tiposCuentasOrdenados);
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

        public async Task<bool> Existe(string nombre, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                                                                        $@"SELECT 1 
                                                                           FROM TipoCuenta 
                                                                           WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;",
                                                                        new {nombre,usuarioId});
            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int UsuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoCuenta>(@"SELECT IdTipoCuenta, Nombre, Orden
                                                           FROM TipoCuenta
                                                           WHERE UsuarioId = @UsuarioId
                                                           ORDER BY Orden",
                                                           new { UsuarioId });
        }

        public async Task Actualizar(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            // con Excute vamos a ejecuatr un query que no va a retornar nada
            await connection.ExecuteAsync(@"UPDATE TipoCuenta 
                                          SET Nombre = @Nombre
                                          WHERE IdTipoCuenta = @IdTipoCuenta ", tipoCuenta);
        }

        public async Task<TipoCuenta> ObtenerPorId(int Id, int UsuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>(@"
                                                                    SELECT IdTipoCuenta, Nombre, Orden 
                                                                    FROM TipoCuenta
                                                                    WHERE IdTipoCuenta = @Id AND UsuarioId = @UsuarioId",
                                                                     new {Id, UsuarioId});
        }

        public async Task Borrar(int IdTipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync("DELETE TipoCuenta WHERE IdTipoCuenta = @IdTipoCuenta", new { IdTipoCuenta });
        }

        public async Task Ordenar(IEnumerable<TipoCuenta> tiposCuentasOrdenados)
        {
            var query = "UPDATE TipoCuenta SET Orden = @Orden WHERE IdTipoCuenta = @IdTipoCuenta;";
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, tiposCuentasOrdenados);
        }
        
    }
}

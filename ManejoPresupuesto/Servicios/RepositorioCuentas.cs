﻿using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public interface IRepositorioCuentas
    {
        Task Crear(Cuenta cuenta);
    }

    public class RepositorioCuentas: IRepositorioCuentas
    {
        private readonly string connectionString;

        public RepositorioCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Cuenta cuenta) {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync(
                @"INSERT INTO Cuentas (Nombre, TipoCuentaId, Descripcion, Balance)
                    VALUES (@Nombre, @TipoCuentaId, @Descripcion, @Balance);

                    SELECT SCOPE_IDENTITY();", cuenta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using Npgsql;
using System.Data;
using sgi_app;
using sgi_app.infrastructure.postgreSQL;
using sgi_app.application.services;


namespace sgi_app.infrastructure.repositories
{
    public class ImpEmpleadoRepository : IGenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ConexionPostgresSingleton _conexion;

        public ImpEmpleadoRepository(string connectionString)
        {
            _conexion = ConexionPostgresSingleton.Instancia(connectionString);
        }
        public void Actualizar(Empleado entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "update empleado set salario_base =@salario_base,  id_eps=@id_eps, id_arl=@id_arl";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
            cmd.Parameters.AddWithValue("@id_eps", entity.IdEps);
            cmd.Parameters.AddWithValue("@id_arl", entity.IdArl);
            cmd.ExecuteNonQuery();
        }

        public void Crear(Empleado entity)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO empleado(fecha_ingreso, salario_base, id_tercero, id_eps, id_arl) VALUES(@fecha_ingreso, @salario_base, @id_tercero, @id_eps, @id_arl)";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@fecha_ingreso", entity.FechaIngreso);
            cmd.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
            cmd.Parameters.AddWithValue("@id_tercero", entity.Id);
            cmd.Parameters.AddWithValue("@id_eps", entity.IdEps);
            cmd.Parameters.AddWithValue("@id_arl", entity.IdArl);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(string var)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "Delete from empleado where id_tercero=@var";
            using var cmd = new NpgsqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@var", var);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int var)
        {
            
        }

        public List<Empleado> ObtenerTodos()
        {
            
            var EmpleadoList = new List <Empleado>();
            
            var connection = _conexion.ObtenerConexion();
            string query = "SELECT e.Id, e.fecha_ingreso,  e.salario_base, e.id_tercero, e.Id_eps, e.Id_arl, t.nombre, t.apellido, t.email, t.Id_tipo_documento, t.Id_tipo_tercero, t.Id_ciudad FROM empleado AS e INNER JOIN tercero AS t on e.id_tercero = t.id;";
            using var cmd = new NpgsqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();
            while(reader.Read()){
                EmpleadoList.Add(new Empleado(reader.GetString("Id_tercero"), reader.GetString("nombre"), reader.GetString("apellido"), reader.GetString("email"), reader.GetInt32("Id_tipo_documento"), reader.GetInt32("Id_tipo_tercero"), reader.GetDateTime("fecha_ingreso"), reader.GetDouble("salario_base"), reader.GetInt32("Id_eps"), reader.GetInt32("Id_arl"), reader.GetInt32("Id_ciudad")  ));
            }
            return EmpleadoList;
        }
    }
}
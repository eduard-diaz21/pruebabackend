using APIPacientes.Connection;
using APIPacientes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPacientes.Repositories
{
    public class PacienteRepository
    {
        #region LISTAR PACIENTES
        public static List<Paciente> listarPacientes()
        {
            List<Paciente> _Lpaciente = new List<Paciente>();
            using (SqlConnection _conn = new SqlConnection(DevConnection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ListarPacientes", _conn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    _conn.Open();

                    using (SqlDataReader sqldr = cmd.ExecuteReader())
                    {
                        while (sqldr.Read())
                        {
                            _Lpaciente.Add(new Paciente()
                            {
                                IdPaciente = Convert.ToInt32(sqldr["IdPaciente"]),
                                nombreCompletoPaciente = sqldr["nombreCompletoPaciente"].ToString(),
                                apellidoPaciente = sqldr["apellidoPaciente"].ToString(),
                                sexoPaciente = sqldr["sexoPaciente"].ToString(),
                                edadPaciente = Convert.ToInt32(sqldr["edadPaciente"]),
                                correoPaciente = sqldr["correoPaciente"].ToString(),
                                tipoDocumentoPaciente = sqldr["tipoDocumentoPaciente"].ToString(),
                                documentoPaciente = sqldr["documentoPaciente"].ToString(),
                                direccionPaciente = sqldr["direccionPaciente"].ToString()
                            });
                        }
                    }
                    return _Lpaciente;

                }
                catch (Exception ex)
                {

                    return _Lpaciente;
                }
            }
        }
        #endregion

        #region LISTAR PACIENTE POR ID
        public static Paciente listarPacienteId(int IdPaciente)
        {
            Paciente _paciente = new Paciente();
            using (SqlConnection _conn = new SqlConnection(DevConnection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ListarPacientePorId", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaciente", IdPaciente);
                try
                {
                    _conn.Open();
                    using (SqlDataReader sqldr = cmd.ExecuteReader()) 
                    {
                        while (sqldr.Read())
                        {
                            _paciente = new Paciente()
                            {
                                IdPaciente = Convert.ToInt32(sqldr["IdPaciente"]),
                                nombreCompletoPaciente = sqldr["nombreCompletoPaciente"].ToString(),
                                apellidoPaciente = sqldr["apellidoPaciente"].ToString(),
                                sexoPaciente = sqldr["sexoPaciente"].ToString(),
                                edadPaciente = Convert.ToInt32(sqldr["edadPaciente"]),
                                correoPaciente = sqldr["correoPaciente"].ToString(),
                                tipoDocumentoPaciente = sqldr["tipoDocumentoPaciente"].ToString(),
                                documentoPaciente = sqldr["documentoPaciente"].ToString(),
                                direccionPaciente = sqldr["direccionPaciente"].ToString()
                            };
                        }
                    }
                    return _paciente;
                }
                catch (Exception ex)
                {
                    return _paciente;
                }
            }
        }
        #endregion

        #region CREAR PACIENTE
        public static bool crearPaciente(Paciente _paciente)
        {
            using (SqlConnection _conn = new SqlConnection(DevConnection.connectionString)) 
            {
                SqlCommand cmd = new SqlCommand("SP_CrearPaciente", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCompletoPaciente", _paciente.nombreCompletoPaciente);
                cmd.Parameters.AddWithValue("@apellidoPaciente", _paciente.apellidoPaciente);
                cmd.Parameters.AddWithValue("@sexoPaciente", _paciente.sexoPaciente);
                cmd.Parameters.AddWithValue("@edadPaciente", _paciente.edadPaciente);
                cmd.Parameters.AddWithValue("@correoPaciente", _paciente.correoPaciente);
                cmd.Parameters.AddWithValue("@tipoDocumentoPaciente", _paciente.tipoDocumentoPaciente);
                cmd.Parameters.AddWithValue("@documentoPaciente", _paciente.documentoPaciente);
                cmd.Parameters.AddWithValue("@direccionPaciente", _paciente.direccionPaciente);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region ACTUALIZAR PACIENTE
        public static bool actualizarPaciente(Paciente _paciente)
        {
            using (SqlConnection _conn = new SqlConnection(DevConnection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarPaciente", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaciente", _paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@nombreCompletoPaciente", _paciente.nombreCompletoPaciente);
                cmd.Parameters.AddWithValue("@apellidoPaciente", _paciente.apellidoPaciente);
                cmd.Parameters.AddWithValue("@sexoPaciente", _paciente.sexoPaciente);
                cmd.Parameters.AddWithValue("@edadPaciente", _paciente.edadPaciente);
                cmd.Parameters.AddWithValue("@correoPaciente", _paciente.correoPaciente);
                cmd.Parameters.AddWithValue("@tipoDocumentoPaciente", _paciente.tipoDocumentoPaciente);
                cmd.Parameters.AddWithValue("@documentoPaciente", _paciente.documentoPaciente);
                cmd.Parameters.AddWithValue("@direccionPaciente", _paciente.direccionPaciente);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion

        #region ELIMINAR PACIENTE
        public static bool eliminarPaciente(int idPaciente)
        {
            using (SqlConnection _conn = new SqlConnection(DevConnection.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_BorrarPaciente", _conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        #endregion
    }
}

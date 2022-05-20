using APIPacientes.Models;
using APIPacientes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPacientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        // GET: LISTAR PACIENTES
        [HttpGet]
        public List<Paciente> Get()
        {
            return PacienteRepository.listarPacientes();
        }

        // GET LISTAR PACIENTE POR ID
        [HttpGet("{id}")]
        public Paciente Get(int id)
        {
            return PacienteRepository.listarPacienteId(id);
        }

        // POST CREAR PACIENTE
        [HttpPost]
        public bool Post([FromBody] Paciente _paciente)
        {
            return PacienteRepository.crearPaciente(_paciente);
        }

        // PUT ACTUALIZAR PACIENTE
        [HttpPut]
        public bool Put([FromBody] Paciente _paciente)
        {
            return PacienteRepository.actualizarPaciente(_paciente);
        }

        // DELETE ELIMINAR PACIENTE
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return PacienteRepository.eliminarPaciente(id);
        }
    }
}

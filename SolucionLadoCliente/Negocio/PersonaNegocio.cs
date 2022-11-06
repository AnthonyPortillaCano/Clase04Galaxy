using Datos.dto;
using Datos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonaNegocio: IPersonaNegocio
    {
        protected IPersonaRepository _personaRepository;
        protected readonly string _connectionString;

        public PersonaNegocio(string connectionString)
        {
            _connectionString = connectionString;
            _personaRepository = new PersonaRepository(_connectionString);
        }
        public async Task<List<PersonaDto>> ListarPersona()
        {
            return await _personaRepository.ListarPersona();
        }
    }
}

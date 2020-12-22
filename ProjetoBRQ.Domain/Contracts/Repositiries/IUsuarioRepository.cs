using ProjetoBRQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
        : IBaseRepository<Usuario>
    {
        List<Usuario> GetByNome(string nome);
    }
}

using ProjetoBRQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(Usuario usuario);

        List<Usuario> Consultar ();
        List<Usuario> Consultar (string nome);
        Usuario ObterPorId(Guid id);
    }
}

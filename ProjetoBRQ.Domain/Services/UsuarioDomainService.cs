using ProjetoBRQ.Domain.Contracts.Repositories;
using ProjetoBRQ.Domain.Contracts.Services;
using ProjetoBRQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributo..
        private readonly IUsuarioRepository usuarioRepository;

        //construtor para injeção de dependencia (inicialização)
        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public void Cadastrar(Usuario usuario)
        {
            usuarioRepository.Create(usuario);

        }

        public void Atualizar(Usuario usuario)
        {
            usuarioRepository.Update(usuario);

        }

        public void Excluir(Usuario usuario)
        {
            usuarioRepository.Delete(usuario);
        }

        public List<Usuario> Consultar ()
        {
            return usuarioRepository.GetAll();
        }

        public List<Usuario> Consultar(string nome)
        {
            return usuarioRepository.GetByNome(nome);
        }

        public Usuario ObterPorId(Guid id)
        {
            return usuarioRepository.GetById(id);
        }

    }
}

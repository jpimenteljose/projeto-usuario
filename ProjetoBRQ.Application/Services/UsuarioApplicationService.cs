using ProjetoBRQ.Application.Contracts;
using ProjetoBRQ.Application.Models;
using ProjetoBRQ.Domain.Contracts.Services;
using ProjetoBRQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        //atributo
        private readonly IUsuarioDomainService usuarioDomainService;

        //construtor para inicialização do atributo..
        public UsuarioApplicationService (IUsuarioDomainService usuarioDomainService)
        {
            this.usuarioDomainService = usuarioDomainService;
        }

        public void Cadastrar(UsuariosCadastroModel model)
        {
            var usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = model.NomeUsuario,
                Sobrenome = model.SobrenomeUsuario,
                Cpf = model.CpfUsuario,
                DataNascimento = DateTime.Parse(model.DataNascimentoUsuario),
                Cep = model.CepUsuario,
                Endereco = model.EnderecoUsuario,
                Numero = model.NumeroUsuario,
                Complemento = model.ComplementoUsuario,
                Cidade = model.CidadeUsuario,
                Estado = model.EstadoUsuario

            };

            usuarioDomainService.Cadastrar(usuario);
        }

        public void Atualizar(UsuariosEdicaoModel model)
        {
            var usuario = new Usuario
            {
                Id = model.IdUsuario,
                Nome = model.NomeUsuario,
                Sobrenome = model.SobrenomeUsuario,
                Cpf = model.CepUsuario,
                DataNascimento = DateTime.Parse(model.DataNascimentoUsuario),
                Cep = model.CepUsuario,
                Endereco = model.EnderecoUsuario,
                Numero = model.NumeroUsuario,
                Complemento = model.ComplementoUsuario,
                Cidade = model.CidadeUsuario,
                Estado = model.EstadoUsuario
            };

            usuarioDomainService.Atualizar(usuario);
        }

        public void Excluir(Guid id)
        {
            var usuario = usuarioDomainService.ObterPorId(id);
            usuarioDomainService.Excluir(usuario); 
        }

        public List<UsuariosResultadoModel> Consultar(UsuariosConsultaModel model)
        {
            var lista = new List<UsuariosResultadoModel>();

            foreach (var item in usuarioDomainService.Consultar(model.NomeUsuario))
            {
                lista.Add(

                    new UsuariosResultadoModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Sobrenome = item.Sobrenome,
                        Cpf = item.Cep,
                        DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy"),
                        Cep = item.Cep,
                        Endereco = item.Endereco,
                        Numero = item.Numero,
                        Complemento = item.Complemento,
                        Cidade = item.Cidade,
                        Estado = item.Estado
                    }
                    );
            }

            return lista;
        }

        public List<UsuariosResultadoModel> Consultar()
        {
            var lista = new List<UsuariosResultadoModel>();

            foreach (var item in usuarioDomainService.Consultar())
            {
                lista.Add(

                    new UsuariosResultadoModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Sobrenome = item.Sobrenome,
                        Cpf = item.Cep,
                        DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy"),
                        Cep = item.Cep,
                        Endereco = item.Endereco,
                        Numero = item.Numero,
                        Complemento = item.Complemento,
                        Cidade = item.Cidade,
                        Estado = item.Estado
                    }
                    );
            }

            return lista;
        }

        public UsuariosResultadoModel ObterPorId(Guid id)
        {
            var item = usuarioDomainService.ObterPorId(id);

            return new UsuariosResultadoModel
            {
                Id = item.Id,
                Nome = item.Nome,
                Sobrenome = item.Sobrenome,
                Cpf = item.Cep,
                DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy"),
                Cep = item.Cep,
                Endereco = item.Endereco,
                Numero = item.Numero,
                Complemento = item.Complemento,
                Cidade = item.Cidade,
                Estado = item.Estado
            };
        }
    }
}

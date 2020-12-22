using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoBRQ.Application.Contracts;
using ProjetoBRQ.Application.Models;

namespace ProjetoBRQ.Presentation.Controllers
{
    public class UsuariosController : Controller
    {
        //atributo
        private readonly IUsuarioApplicationService usuarioApplicationService;

        //construtor para injeção de dependência (inicialização)
        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(UsuariosCadastroModel model)
        {
            //verificar se todos os campos passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    usuarioApplicationService.Cadastrar(model);

                    TempData["MensagemSucesso"] = $"Usuário '{model.NomeUsuario}', cadastrada com sucesso.";
                    ModelState.Clear(); //limpa o conteudo do formulário
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Consulta()
        {
            try
            {
                //pesquisando as movimentações por datas..
                var resultado = usuarioApplicationService.Consultar();

                //enviando o resultado da pesquisa para a página
                TempData["Resultado"] = resultado;
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Consulta(UsuariosConsultaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //pesquisando as movimentações por datas..
                    var resultado = usuarioApplicationService.Consultar(model);
                    
                    //enviando o resultado da pesquisa para a página
                    TempData["Resultado"] = resultado;

                    if (resultado.Count == 0)
                        TempData["MensagemAlerta"] = "Nenhum Usuário foi encontrado.";

                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Edicao(Guid id)
        {
            var model = new UsuariosEdicaoModel();

            try
            {
                //buscar o registro da movimentação pelo id..
                var resultado = usuarioApplicationService.ObterPorId(id);

                //transferindo as informações
                model.IdUsuario = resultado.Id;
                model.NomeUsuario = resultado.Nome;
                model.SobrenomeUsuario = resultado.Sobrenome;
                model.CpfUsuario = resultado.Cpf;
                model.DataNascimentoUsuario = resultado.DataNascimento;
                model.CepUsuario = resultado.Cep;
                model.EnderecoUsuario = resultado.Endereco;
                model.NumeroUsuario = resultado.Numero;
                model.ComplementoUsuario = resultado.Complemento;
                model.CidadeUsuario = resultado.Cidade;
                model.EstadoUsuario = resultado.Estado;

            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(UsuariosEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    usuarioApplicationService.Atualizar(model);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso.";

                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Excluir(Guid id)
        {
            try
            {
                //excluindo o usuário
                usuarioApplicationService.Excluir(id);

                TempData["MensagemSucesso"] = "Usuário excluído com sucesso.";
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }

            //redirecionamento
            return RedirectToAction("Consulta");
        }

    }

}

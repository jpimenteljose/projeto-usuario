using ProjetoBRQ.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBRQ.Application.Contracts
{
    public interface IUsuarioApplicationService
    {                
        void Cadastrar(UsuariosCadastroModel model);
        void Atualizar(UsuariosEdicaoModel model);
        void Excluir(Guid id);

        List<UsuariosResultadoModel> Consultar();
        List<UsuariosResultadoModel> Consultar (UsuariosConsultaModel model);
        UsuariosResultadoModel ObterPorId(Guid id);
    }
}

using ProjetoBRQ.Domain.Contracts.Repositories;
using ProjetoBRQ.Domain.Entities;
using ProjetoBRQ.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoBRQ.Infra.Data.Repositories
{
    public class UsuarioRepository
        : BaseRepository<Usuario>, IUsuarioRepository
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor para inicialização do atributo
        public UsuarioRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        //public List<Usuario> GetAll() 
        public List<Usuario> GetByNome(string nome)
        {
            //SQL ->    select * from MovimentacaoFinanceira
            //          where Data >= @dataMin && Data <= @dataMax
            //          order by Data desc

            return dataContext.Usuario
                    .Where(m => m.Nome.Contains(nome))
                    .OrderBy(m => m.Nome)
                    .ToList();
        }
    }
}

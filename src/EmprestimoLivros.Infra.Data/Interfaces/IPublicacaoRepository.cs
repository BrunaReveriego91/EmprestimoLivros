﻿using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Interfaces
{
    public interface IPublicacaoRepository
    {
        Task<IEnumerable<Publicacao>> ListarPublicacao();
        Task CadastrarPublicacao(Publicacao publicacao);
        Task<Publicacao> BuscarPublicacao(int id);

        Task RemoverPublicacao(int id);
    }
}

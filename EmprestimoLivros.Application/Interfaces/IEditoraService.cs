﻿using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IEditoraService
    {
        Task<IEnumerable<Editora>> ListarEditoras();
        Task CadastrarEditora(Editora editora);
    }
}

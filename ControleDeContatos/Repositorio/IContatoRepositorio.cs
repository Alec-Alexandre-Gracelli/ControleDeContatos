﻿using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> BuscarTodos(Guid usuarioId);
        Contato BuscarPorId(Guid id);
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        bool Apagar(Guid id);
    }
}

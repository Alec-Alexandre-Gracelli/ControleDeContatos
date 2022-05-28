using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> BuscarTodos();
        Contato Adicionar(Contato contato);
    }
}

using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        Contato ListarPorId(int id);
        List<Contato> BuscarTodos();
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);
        bool Apagar(int id);
    }
}

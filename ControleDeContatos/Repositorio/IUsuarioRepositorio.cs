using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        Usuario BuscaPorEmailELogin(string email, string login);
        List<Usuario> BuscarTodos();
        Usuario BuscarPorId(Guid id);
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
        bool Apagar(Guid id);
    }
}
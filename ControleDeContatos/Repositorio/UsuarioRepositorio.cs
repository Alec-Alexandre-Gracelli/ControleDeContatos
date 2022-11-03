using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscaPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.UsuarioId == id);
        }

        public List<Usuario> BuscarTodos()
        {
            return _context.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDB = BuscarPorId(usuario.UsuarioId);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do contato!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;

        }

        public Usuario AlterarSenha(AlterarSenha alterarSenha)
        {
            Usuario usuarioDB = BuscarPorId(alterarSenha.AlterarSenhaId);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(Guid id)
        {
            Usuario usuarioDB = BuscarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}

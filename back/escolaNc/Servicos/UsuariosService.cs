using System;
using escolaNc.Data;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System.Collections.Generic;
using System.Linq;
using escolaNc.Excecao;

namespace escolaNc.Servicos
{
    public class UsuariosService : IUsuariosService
    {
        private EscolaContext _context;
        public UsuariosService(EscolaContext context)
        {
            _context = context;
        }

        public List<Usuario> RetornaUsuarios()
        {
            try
            {
                return _context.USUARIOS.ToList();
            }
            catch (Exception)
            {
                throw new Excecoes("Não foi possível acessar a base de dados");
            }
        }

        public Usuario AtualizaUsuario(Usuario usuario)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == usuario.cpf))
                throw new Excecoes("Usuário não encontrado no banco de dados");

            try
            {
                _context.USUARIOS.Update(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (Exception)
            {
                throw new Excecoes("Não foi possível atualizar o usuário na base de dados");
            }
        }

        public Usuario InsereUsuario(Usuario usuario)
        {
            try
            {
                _context.USUARIOS.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (Exception)
            {

                throw new Excecoes($"O usuário com o cpf {usuario.cpf} já existe na base de dados");
            }

        }

        public bool RemoveUsuario(string cpf)
        {
            if (!_context.USUARIOS.Any(u => u.cpf == cpf))
                throw new Excecoes("Usuário não encontrado no banco de dados");

            try
            {
                var usuario = _context.USUARIOS.Find(cpf);

                _context.USUARIOS.Remove(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Excecoes($"Não foi possível remover o usuário de cpf: {cpf} da base de dados");
            }
        }

    }
}

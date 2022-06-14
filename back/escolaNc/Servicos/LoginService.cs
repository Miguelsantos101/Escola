using escolaNc.Data;
using escolaNc.Excecao;
using escolaNc.Interfaces;
using escolaNc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace escolaNc.Servicos
{
    public class LoginService : ILoginService
    {
        private readonly EscolaContext _context;

        public LoginService(EscolaContext context)
        {
            _context = context;
        }


        public Registro Registrar(Registro cadastro)
        {
            try
            {
                cadastro.hash_senha = criptografar(cadastro.hash_senha);
                _context.USER_LOGIN.Add(cadastro);
                _context.SaveChanges();
                return cadastro;
            }
            catch (Exception)
            {
                throw new Excecoes($"O usuário com o cpf {cadastro.cpf} já existe");
            }
        }

        public bool Logar(Login dados)
        {
            if(!_context.USER_LOGIN.Any(u => u.cpf == dados.cpf))
            {
                throw new Exception("CPF não encontrado");
            }
            else
            {
                var user = new Login();
                try
                {
                    var query = from c in _context.USER_LOGIN
                                where c.cpf == dados.cpf
                                select new
                                {
                                    c.nome,
                                    c.cpf,
                                    c.hash_senha,
                                };

                    foreach (var c in query)
                    {
                        user.cpf = c.cpf;
                        user.hash_senha = c.hash_senha;
                    }
                    return (user.hash_senha == criptografar(dados.hash_senha));
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }



        private string criptografar(string hash_senha)
        {
            var _stringHash = "";
            try
            {
                UnicodeEncoding _encode = new UnicodeEncoding();
                byte[] _hashBytes, _messageBytes = _encode.GetBytes(hash_senha);

                SHA256Managed _sha256Manager = new SHA256Managed();

                _hashBytes = _sha256Manager.ComputeHash(_messageBytes);

                foreach (byte b in _hashBytes)
                {
                    _stringHash += String.Format("{0:x2}", b);
                }

                return _stringHash;
            }
            catch (Exception)
            {
                throw new Excecoes("Não foi possível criptografar a senha");
            }
        }

    }
}

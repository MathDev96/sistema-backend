using PrimeiraAPI.Common;
using PrimeiraAPI.Entities;
using PrimeiraAPI.models;
using PrimeiraAPI.Repositories;
using System;

namespace PrimeiraAPI.Services
{
    public class UsuarioServices
    {
        private string _connectionString;
        public UsuarioServices(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //Usuario existe
                if (usuario.Senha == senha)
                {
                    //login sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid; 
                }
                else
                {
                    // senha invalida
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senhas inválidos";
                }
            }
            else
            {
                // Usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }
            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();
            var usuarioRepository = new UsuarioRepository(_connectionString);
            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);
            
            if (usuario != null)
            {
                //usuario já existente
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                //usuario não existente
                usuario = new Usuario();

                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);

                if (insertResult > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }

                else
                {
                    // erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente.";
                }
            }
            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            
            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.mensagem = "Usuário não existe";

            }
            else
            {
                var emailSender = new EmailSender();

                var assunto = "Recuprar senha";
                var corpo = "Sua senha é " + usuario.Senha;

                emailSender.Enviar(assunto, corpo, usuario.Email);

                result.sucesso = true;
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;

        }
    }
}

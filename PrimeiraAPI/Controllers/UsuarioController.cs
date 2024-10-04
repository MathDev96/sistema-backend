using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Security;
using PrimeiraAPI.models;
using PrimeiraAPI.Services;
using System;

namespace PrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parametro request nulo";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "E-mail obrigatório";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "Senha obrigatório";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("primeiraApiDb");

                var usuarioServices = new UsuarioServices(connectionString);

                result = usuarioServices.Login(request.email, request.senha);

            }
            
            return result;

        }

        [Route("cadastro")]
        [HttpPost]

        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha))
            {

                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios";
                
            }
             
            else
            {
                var connectionString = _configuration.GetConnectionString("primeiraApiDb");
                
                var usuarioServices = new UsuarioServices(connectionString);

                result = usuarioServices.Cadastro(request.nome, request.sobrenome, 
                    request.telefone, request.email, request.genero, request.senha);

            }
                return result;
            
        }

        [Route("EsqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null || 
                string.IsNullOrWhiteSpace(request.email))
            {
                result.mensagem = "E-mail não pode estar vazio";
               
                return result;
            }

            var connectionString = _configuration.GetConnectionString("primeiraApiDb");

            result = new UsuarioServices(connectionString).EsqueceuSenha(request.email);

            return result;
        }


        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Guid vazio";

            }
            else
            {
                var connectionString = _configuration.GetConnectionString("primeiraApiDb");
               
                var usuario = new UsuarioServices(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }
            return result;
        }
    }
}

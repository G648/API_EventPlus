using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi_eventplus_manha.Domains;
using webapi_eventplus_manha.Interfaces;
using webapi_eventplus_manha.Repositories;
using webapi_eventplus_manha.ViewModels;

namespace webapi_eventplus_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para realizar o login do usuáro
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Token do uuário logado</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscadoLogin = _usuarioRepository.BuscarPorEmailESenha(usuario.EmailUser, usuario.Senhauser);

                if (usuarioBuscadoLogin == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                //Caso encontre o usuário , prossegue para a criação do token

                //1º - Definir as informações(Claims) que serão fornecidos no token (PAYLOAD)
                var claims = new[]
                {
                    //formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscadoLogin.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscadoLogin.EmailUser!),
                    new Claim(ClaimTypes.Role,usuarioBuscadoLogin.TiposUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscadoLogin.TiposUsuario.TituloTipoUsuario!)

                    //existe a possibilidade de criar uma claim personalizada
                    //new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                //2º - Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi-codeFirst"));

                //3º - Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º - Gerar token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi_eventplus_manha",

                    //destinatário do token
                    audience: "webapi_eventplus_manha",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //5º - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

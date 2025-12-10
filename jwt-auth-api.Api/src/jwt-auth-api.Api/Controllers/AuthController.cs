using jwt_auth_api.Api.ViewModel.Login;
using jwt_auth_api.Application.Service;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginRequest request)
        {
            try
            {
                string retorno = _authService.Login(request.Email, request.Password);
                AuthLoginResponse response = new AuthLoginResponse();
                response.Token = retorno;
                response.Message = "Login realizado com sucesso";
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return Unauthorized(new { Message = ex.Message });
            }       
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            string result = _authService.Logout();
            return Ok(result);
        }
    }
}

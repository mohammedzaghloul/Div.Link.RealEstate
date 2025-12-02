using Div.Link.RealEstate.BLL.DTO.Account;
using Div.Link.RealEstate.BLL.DTO.User;
using Div.Link.RealEstate.DAL.Model.ApplicationUser.Div.Link.RealEstate.DAL.Model.ApplicationUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Div.Link.RealEstate.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        [HttpPost("Regsiter")]
        public async Task<IActionResult> Regsiter(RegsiterDto UserFromRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = new User
            {
                UserName = UserFromRequest.UserName,
                //PasswordHash=LoginDto.Password
            };
            IdentityResult result = await userManager.CreateAsync(user, UserFromRequest.Password);

            if (result.Succeeded)
            {
                return Created("", new { user.UserName, user.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto userloginDto)
        {
            if (ModelState.IsValid)
            {
                //Check
                User UserfromDb = await userManager.FindByNameAsync(userloginDto.UserName);
                if (UserfromDb != null)
                {
                    bool Found = await userManager.CheckPasswordAsync(UserfromDb, userloginDto.Password);
                    if (Found == true)
                    {
                        //Gererate Token
                        List<Claim> claims = new List<Claim>();
                        //Token 
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        claims.Add(new Claim(ClaimTypes.NameIdentifier, UserfromDb.Id));
                        claims.Add(new Claim(ClaimTypes.Name, UserfromDb.UserName));
                        var UserRoles = await userManager.GetRolesAsync(UserfromDb);
                        foreach (var rolename in UserRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, rolename));
                        }
                        var siginkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecritKey"]));
                        SigningCredentials signingCredentials = new SigningCredentials(siginkey, SecurityAlgorithms.HmacSha256);
                        JwtSecurityToken mytoken = new JwtSecurityToken
                            (
                            //audience.configuration["JWT:Audience"]
                            //issuer

                            expires: DateTime.Now.AddDays(2),
                            claims: claims,
                            signingCredentials: signingCredentials
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            exception = DateTime.Now.AddDays(1)
                        });
                    }
                }
                ModelState.AddModelError("UserName", "UserName OR Password Invalid ");
            }

            return BadRequest(ModelState);
        }
    }
}
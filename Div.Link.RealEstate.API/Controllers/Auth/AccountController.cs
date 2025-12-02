using Div.Link.RealEstate.BLL.DTO.Account;
using Div.Link.RealEstate.DAL.Model.ApplicationUser;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager,
                                RoleManager<IdentityRole> roleManager,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // التحقق من وجود المستخدم
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError("UserName", "اسم المستخدم موجود بالفعل");
                return BadRequest(ModelState);
            }

            // التحقق من البريد الإلكتروني
            existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "البريد الإلكتروني موجود بالفعل");
                return BadRequest(ModelState);
            }

            // إنشاء المستخدم الجديد
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                ProfileImage = model.ProfileImage,
                EmailConfirmed = true // لأغراض الاختبار
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");

                // إنشاء الرد الناجح
                var response = new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    Message = "تم التسجيل بنجاح"
                };

                return Ok(response);
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

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "اسم المستخدم أو كلمة المرور غير صحيحة");
                return BadRequest(ModelState);
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!isValidPassword)
            {
                ModelState.AddModelError("Password", "اسم المستخدم أو كلمة المرور غير صحيحة");
                return BadRequest(ModelState);
            }

            // إنشاء التوكن
            var token = await GenerateJwtToken(user);

            var response = new
            {
                Token = token,
                User = new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber
                },
                ExpiresIn = DateTime.Now.AddDays(7)
            };

            return Ok(response);
        }

      

       // Create Token
        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Profile Get info
        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("المستخدم غير موجود");

            var profile = new UserProfileDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                ProfileImage = user.ProfileImage
            };

            return Ok(profile);
        }

        // Profile Post info Update
        [HttpPut("profile/{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] UpdateProfileDto model)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("المستخدم غير موجود");

            // تحديث البيانات
            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;
            user.Address = model.Address ?? user.Address;
            user.DateOfBirth = model.DateOfBirth ?? user.DateOfBirth;
            user.ProfileImage = model.ProfileImage ?? user.ProfileImage;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return Ok(new { Message = "تم تحديث الملف الشخصي بنجاح" });

            return BadRequest(result.Errors);
        }
    }
}
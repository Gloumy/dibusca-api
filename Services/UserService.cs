using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using dibusca_api.Entities;
using dibusca_api.Helpers;
using dibusca_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace dibusca_api.Services
{
  public interface IUserService
  {
    AuthenticateResponse Authenticate(UserCredentials model);
    // IEnumerable<User> GetAll();
  }

  public class UserService : IUserService
  {
    private readonly AppSettings _appSettings;
    private readonly AppDbContext _context;

    public UserService(IOptions<AppSettings> appSettings, AppDbContext context)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public AuthenticateResponse Authenticate(UserCredentials model)
    {
      var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

      if (user == null || !PasswordMatches(user, user.Password, model.Password))
      {
        return null;
      }

      var token = generateJwtToken(user);

      return new AuthenticateResponse(user, token);
    }

    private bool PasswordMatches(User user, string hashedPassword, string password)
    {
      var passwordHasher = new PasswordHasher<User>();
      bool verified = false;
      var result = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
      if (result == PasswordVerificationResult.Success) verified = true;
      else if (result == PasswordVerificationResult.SuccessRehashNeeded) verified = true;
      else if (result == PasswordVerificationResult.Failed) verified = false;

      return verified;
    }

    private string generateJwtToken(User user)
    {
      // generate token that is valid for 7 days
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
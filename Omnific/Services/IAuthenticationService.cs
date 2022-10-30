using Omnific.Model;
namespace Omnific.Services
{
    public interface IAuthenticationService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public string Login(User user);
        public bool VerifyPasswordHash(User user, string password);
    }
}

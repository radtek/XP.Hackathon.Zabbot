using XP.Hackathon.Zabbot.Interface.Repository;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Interface.Service;
using XP.Hackathon.Zabbot.Model;
using System;
using System.Threading.Tasks;

namespace XP.Hackathon.Zabbot.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogService _logService;

        public UserService(IUserRepository repository, ILogService logService) : base(repository, logService)
        {
            this._repository = repository;
        }        

        public async Task<Result<User>> Authenticate(string login, string passw)
        {
            var result = new Result<User>();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(passw))
            {
                result.Success = false;
                result.FriendlyMessage = "Username or password incorret.";

                return result;
            }

            try
            {
                var user = await _repository.GetByLoginAsync(login);
                if (user == null || string.IsNullOrEmpty(user.Login))
                {
                    result.Success = false;
                    result.FriendlyMessage = "Username or password incorret.";

                    return result;
                }


                if (!VerifyPasswordHash(passw, user.Password, user.Salt))
                {
                    result.Success = false;
                    result.FriendlyMessage = "Username or password incorret.";

                    return result;
                }

                result.Success = true;
                result.Objects.Add(user);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to authenticate the user.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }

        public async Task<ResultBase> Register(User model)
        {
            var result = new Result<User>();

            if (string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.PasswordStr))
            {
                result.Success = false;
                result.FriendlyMessage = "Username or password can´t be null.";

                return result;
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                result.Success = false;
                result.FriendlyMessage = "The Name can´t be null.";

                return result;
            }

            try
            {
                var user = await _repository.GetByLoginAsync(model.Login);
                if (user != null && !string.IsNullOrEmpty(user.Login))
                {
                    result.Success = false;
                    result.FriendlyMessage = "This email already exist in the plataform.";

                    return result;
                }

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(model.PasswordStr, out passwordHash, out passwordSalt);

                model.Password = passwordHash;
                model.Salt = passwordSalt;

                result = await _repository.SaveAsync(model);
            }
            catch (Exception ex)
            {
                // Falha.
                result.Success = false;
                result.FriendlyMessage = "Failed to complete save.";
                result.Error = ex;

                _logService.Insert(ex, "ModelService.Update");
            }

            return result;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            try
            {
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
                if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != storedHash[i])
                            return false;
                    }
                }
            }
            catch 
            {
                return false;
            }

            return true;
        }

    }
}



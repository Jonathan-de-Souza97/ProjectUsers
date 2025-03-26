

using core.Entity;
using Dapper;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Result;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextBase _context;

        public UserRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task<Result<User>> AddAsync(User user)
        {
            string sql = $@"INSERT INTO users 
                                (Name, Email, Password, DDD, PhoneNumber, CreationDate) 
                            VALUES 
                                (@Name, @Email, @Password, @DDD, @PhoneNumber, @CreationDate)";
            
            try
            {
                var connection = await _context.CreateOpenConnectionAsync();
                await connection.ExecuteAsync(sql, new 
                { 
                    user.Name, user.Email, user.Password, user.Telephone.DDD, user.Telephone.PhoneNumber, user.CreationDate 
                }, commandTimeout:1000);

                return Result<User>.Sucess(user);
            }
            catch (Exception ex)
            {
                return Result<User>.Error("Error to add user: " + ex.Message);
            }           

        }

        public async Task<Result<User>> GetByEmail(string email)
        {
            var sql = $@"SELECT * FROM users
                         WHERE Email = @email";

            try
            {
                var connection = await _context.CreateOpenConnectionAsync();
                var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new {email}, commandTimeout:1000);

                return Result<User>.Sucess(user);
            }
            catch (Exception ex)
            {
                return Result<User>.Error("Error to get user: " + ex.Message);
            }
        }
    }
}
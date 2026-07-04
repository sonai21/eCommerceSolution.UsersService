
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositroyContacts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        //sql query
        string query = "INSERT INTO public. \"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";
      int rowCountAffected = await  _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0) {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

        var parametersObj = new { Email = email, Password = password };
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parametersObj);

        return user;
        //return new ApplicationUser()
        //{
        //    UserId = Guid.NewGuid(),
        //    Email = email,
        //    Password = password,
        //    PersonName = "Dummy",
        //    Gender = GenderOptions.Female.ToString(),
        //};
    }

    public async Task<ApplicationUser?> GetUserByUserId(Guid? userId)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"UserId\"=@UserId";
        var parametersObj = new { UserId=userId };
        var result = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parametersObj);
        return result;
    }
}

using Crud.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.Infrastructure.Migrations;

public static class DataBaseMigration {

    public static async Task MigrateDatabase(IServiceProvider serviceProvider){
        var dbContext = serviceProvider.GetRequiredService<CrudDbContext>();
       await dbContext.Database.MigrateAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Personal_Library;
using System.IO;

public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDB>
{
    public LibraryDB CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<LibraryDB>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("LibraryDB"));

        return new LibraryDB(optionsBuilder.Options);
    }
}
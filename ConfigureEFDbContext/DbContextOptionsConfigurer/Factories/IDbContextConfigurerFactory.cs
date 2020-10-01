namespace ConfigureEFDbContext
{
    public interface IDbContextConfigurerFactory
    {
        IDbContextConfigurer GetConfigurer(string migrationsAssembly = null);
    }
}

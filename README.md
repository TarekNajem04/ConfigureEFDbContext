# ConfigureEFDbContext
Scalable scenario to configuring Entity Framework DbContext(ASP.Net Core 3.x &amp; MSTest) and creating a flexible Startup class
We will show different ways to configure your application using the ASP.NET CORE 3.x

[_**The Original post on TarekNajem04@Medium**_](https://medium.com/@tareknajem04/scalable-scenario-to-configuring-entity-framework-dbcontext-409ee3b4e502?source=friends_link&sk=f91f7bac050d93225d479360b459376b)

We will show different ways to configure our application using the ASP.NET CORE 3.x and creating a flexible Startup class.

## Background

When we are configuring the  [**DbContext**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1)  in an  **_ASP.NET Core_**  web application, we typically use  **_AddDbContext_** extension method as follows:

    services.AddDbContext<xxxDbContext>(dbContextOptionsBuilder =>
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("The name of the connection string in the configuration file.")
        ));
    // Or
    services.AddDbContext<xxxDbContext>((serviceProvider, dbContextOptionsBuilder) =>
    {
        var service = serviceProvider.GetService<xxx>();
        dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("The name of the connection string in the configuration file.");
    });

If we take a closer look at the parameter of the  **_AddDbContext_** extension method, we’ll find that is an action, and through un  [**_Action_**](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=netcore-3.1), we can encapsulate a method , delegate, in-line delegate, lambda or etc.  
In this case, the  [**_Action_**](https://docs.microsoft.com/en-us/dotnet/api/system.action?view=netcore-3.1)  must construct the  [**DbContext**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1)  options.  
What interests us most is configuring the  [**DbContext**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1)  according to the our configuration ‘**{environment}settings.json’**.

**How** do we implement this scenario and  **why**?

The answer to the question  **why** would we do this:  
We want to dramatically simplify and improve the experience for configuring  [**DbContext**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1)  and make them truly composable, where we can try to create a flexible scenario that automatically configures  [**DbContext**](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1)  so that it can encapsulate a complete feature and provide an instant utility without having to go through various steps on how to manually configure it in different places in the  **_Startup_**  configuration class.

using System.Reflection;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension
{
    // Extension method
    // Metodun ve barındığı class'ın static olması gerekiyor
    // İlk parametere genişleteceğimiz tip olmalı ve başında this keyword'ü olmalı.
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services//Brand
            .AddScoped<IBrandService, BrandManager>()
            .AddScoped<IBrandDal, EfBrandDal>()
            .AddScoped<BrandBusinessRules>();
        // Fluent
        // Singleton: Tek bir nesne oluşturur ve herkese onu verir.
        // Ek ödev diğer yöntemleri araştırınız.

        services//Fuel
           .AddScoped<IFuelService, FuelManager>()
           .AddScoped<IFuelDal, EfFuelDal>()
           .AddScoped<FuelBusinessRules>();
    
        services//Transmission
          .AddScoped<ITransmissionService,TransmissionManager>()
          .AddScoped<ITransmissionDal, EfTransmissionDal>()
          .AddScoped<TransmissionBusinessRules>();

        services//Car
          .AddScoped<ICarService, CarManager>()
          .AddScoped<ICarDal, EfCarDal>()
          .AddScoped<CarBusinessRules>();

        services//Users
         .AddScoped<IUsersService, UsersManager>()
         .AddScoped<IUsersDal, EfUsersDal>()
         .AddScoped<UsersBusinessRules>();

        services//Customers
        .AddScoped<ICustomersService, CustomersManager>()
        .AddScoped<ICustomersDal, EfCustomersDal>()
        .AddScoped<CustomersBusinessRules>();

        services//IndividualCustomer
        .AddScoped<IIndividualCustomerService, IndividualCustomerManager>()
        .AddScoped<IIndividualCustomerDal, EfIndividualCustomerDal>()
        .AddScoped<IndividualCustomerBusinessRules>();


        services//CorporateCustomer
        .AddScoped<ICorporateCustomerService, CorporateCustomerManager>()
        .AddScoped<ICorporateCustomerDal, EfCorporateCustomerDal>()
        .AddScoped<CorporateCustomerBusinessRules>();

        services//Model  EfModelDal sınıfından alsın
            .AddScoped<IModelService, ModelManager>()
            .AddScoped<IModelDal, EfModelDal>()
            .AddScoped<ModelBusinessRules>(); // Fluent

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper.Extensions.Microsoft.DependencyInjection NuGet Paketi
        // Reflection yöntemi Profile class'ını kalıtım alan tüm class'ları bulur ve AutoMapper'a ekler.

        services.AddDbContext<RentACarContext>( // Scoped 
            options => options.UseSqlServer(configuration.GetConnectionString("RentACarMSSQL22"))
        );

        return services;
    }
}

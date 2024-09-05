#pragma warning disable CS8604

using System.Reflection;

namespace Awc.Dapr.Services.Company.API.Infrastructure;

public class CompanyDbContext(DbContextOptions options) : DbContext(options)
{
    public virtual DbSet<Address>? Address { get; set; }
    public virtual DbSet<AddressType>? AddressType { get; set; }
    public virtual DbSet<BusinessEntity>? BusinessEntity { get; set; }
    public virtual DbSet<BusinessEntityAddress>? BusinessEntityAddress { get; set; }
    public virtual DbSet<BusinessEntityContact>? BusinessEntityContact { get; set; }    
    public virtual DbSet<ContactType>? ContactType { get; set; }
    public virtual DbSet<CountryRegion>? CountryRegion { get; set; }
    public virtual DbSet<EmailAddress>? EmailAddress { get; set; }  
    public virtual DbSet<Password>? Password { get; set; }
    public virtual DbSet<Person>? Person { get; set; }
    public virtual DbSet<PersonPhone>? PersonPhone { get; set; }
    public virtual DbSet<PhoneNumberType>? PhoneNumberType { get; set; }
    public virtual DbSet<StateProvince>? StateProvince { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        => await base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

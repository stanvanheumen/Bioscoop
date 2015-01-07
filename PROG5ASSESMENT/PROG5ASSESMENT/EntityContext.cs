using DomainModel.Models;
using System.Data.Entity;

public class EntityContext : DbContext {

    public EntityContext() : base("name=EntityContext") {
    }

    public DbSet<Film>          Films           { get; set; }
    public DbSet<Gast>          Gasten          { get; set; }
    public DbSet<Korting>       Kortingen       { get; set; }
    public DbSet<Reservering>   Reserveringen   { get; set; }
    public DbSet<Zaal>          Zalen           { get; set; }
    
}
using Data.Repository.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data.Repository
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoEntity> Todos { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "TodosDb.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedWhen = DateTime.UtcNow;
                        // entry.Entity.CreateBy
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedWhen = DateTime.UtcNow;
                        //entry.Entity.ModifiedBy
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

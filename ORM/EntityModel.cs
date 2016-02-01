using System.Data.Entity;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        #region Constructors
        public EntityModel()
            :base("FilesStoreDB") { }

        public EntityModel(string connection)
            : base(connection) { }

        static EntityModel()
        {
            Database.SetInitializer<EntityModel>(new DbInitializer());
        }
        #endregion

        #region Properties
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(c => c.Users)
                .WithMany(s => s.Roles)
                .Map(t => t.MapLeftKey("RoleId")
                .MapRightKey("UserId")
                .ToTable("RoleUser"));

            modelBuilder.Entity<File>()
                .Property(it => it.DateAdded)
                .HasColumnType("datetime2");
        }

        public void Dispose()
        {
            base.Dispose();
        }
        #endregion
    }
}

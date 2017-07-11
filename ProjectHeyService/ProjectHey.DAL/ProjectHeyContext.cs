using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectHey.DOMAIN;
using System;
//using System.Data;
using System.Linq;

namespace ProjectHey.DAL
{
    public class ProjectHeyContext : DbContext
    {
        public static string LocalConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjectHeyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string OnlineConnectionString { get; set; } = @"Data Source=projectheydb.ccrocawufdfn.eu-west-2.rds.amazonaws.com,1433;Initial Catalog=projectheydb;Integrated Security=False;User ID=ProjectHeyDBA;Password=projecthey5;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private DbMigrationsConfiguration _configuration;

        public ProjectHeyContext(DbContextOptions<ProjectHeyContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }
        public ProjectHeyContext() : this(new DbContextOptions<ProjectHeyContext>())
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(LocalConnectionString);
            optionsBuilder.UseSqlServer(OnlineConnectionString);
            //optionsBuilder.EnableSensitiveDataLogging(true);

        }
        public DbSet<User> User { get; set; }
        public DbSet<UserProvider> UserProvider { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AppSetting> AppSetting { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<AdvertisementCategory> AdvertisementCategory { get; set; }
        public DbSet<Blocked> Blocked { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        //<<<<<Special Intersection Tables>>>>>

        //Reports (User_User)
        public DbSet<Reported> Reported { get; set; }

        //Connection (User_User)
        public DbSet<Connection> Connection { get; set; }

        //UserAdvertisements (User_Advertisements)
        public DbSet<UserAdvertisement> UserAdvertisement { get; set; }

        //<<<<<END Special Intersection Tables>>>>>


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Ignored Properties
            modelBuilder.Entity<User>().Ignore(x => x.Location);
            modelBuilder.Entity<Advertisement>().Ignore(x => x.Location); 
            #endregion

            #region Getters Mapping
            modelBuilder.Entity<User>().Property(x => x.Username).HasColumnName("Username");
            #endregion

            #region Primary Keys (Excl. One-One & Many-Many)
            //<<<<PRIMARY KEYS (Excl. ONE-ONE & MANY-MANY)>>>>
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Provider>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Message>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Feedback>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Report>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Advertisement>()
                .HasKey(x => x.Id);
            //<<<<END PRIMARY KEYS>>>> 
            #endregion
            
            #region One-To-One Relationships
            //<<<<One-To-One Relationships>>>>
            modelBuilder.Entity<User>()
                .HasOne(x => x.Appsetting)
                .WithOne(z => z.User)
                .HasForeignKey<AppSetting>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            //<<<<One-To-One Relationships>>>> 
            #endregion

            #region UNIQUE KEYS
            //<<<<UNIQUE>>>>
            modelBuilder.Entity<Role>()
                .HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Provider>()
                .HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Category>()
                .HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<UserProvider>()
                .HasIndex(x => x.ProviderUserId).IsUnique();
            //<<<<END UNIQUE>>>> 
            #endregion

            #region Generated Values
            //<<<<GENERATED VALUES>>>>
            modelBuilder.Entity<UserAdvertisement>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            //<<<<END GENERATED VALUES>>>> 
            #endregion

            #region Many-To-Many Relationships
            //<<<<<Many-To-Many relationships>>>>>
            //Blocked
            modelBuilder.Entity<Blocked>()
                .HasKey(x => new { x.UserId, x.BlockedUserId });

            modelBuilder.Entity<Blocked>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.BlockedUsers)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Blocked>()
                .HasOne(pt => pt.BlockedUser)
                .WithMany()
                .HasForeignKey(pt => pt.BlockedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Reported
            modelBuilder.Entity<Reported>()
                .HasKey(x => new { x.ReporterUserId, x.ReportedUserId });

            modelBuilder.Entity<Reported>()
                .HasOne(pt => pt.ReporterUser)
                .WithMany(p => p.ReportedUsers)
                .HasForeignKey(pt => pt.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reported>()
                .HasOne(pt => pt.ReportedUser)
                .WithMany()
                .HasForeignKey(pt => pt.ReportedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Connection
            modelBuilder.Entity<Connection>()
                .HasKey(x => new { x.UserOneId, x.UserTwoId });

            modelBuilder.Entity<Connection>()
                .HasOne(pt => pt.UserOne)
                .WithMany(p => p.Connections)
                .HasForeignKey(pt => pt.UserOneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Connection>()
                .HasOne(pt => pt.UserTwo)
                .WithMany()
                .HasForeignKey(pt => pt.UserTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            //Messages
            modelBuilder.Entity<Message>()
                .HasOne(pt => pt.UserSender)
                .WithMany(p => p.Messages)
                .HasForeignKey(pt => pt.UserSenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(pt => pt.UserReceiver)
                .WithMany()
                .HasForeignKey(pt => pt.UserReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            //Roles
            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserRole)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.UserRole)
                .HasForeignKey(pt => pt.RoleId);

            //User Categories
            modelBuilder.Entity<UserCategory>()
                .HasKey(x => new { x.UserId, x.CategoryId });

            modelBuilder.Entity<UserCategory>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserCategory)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.UserCategory)
                .HasForeignKey(pt => pt.CategoryId);

            //Advertisement Categories
            modelBuilder.Entity<AdvertisementCategory>()
                .HasKey(x => new { x.AdvertisementId, x.CategoryId });

            modelBuilder.Entity<AdvertisementCategory>()
                .HasOne(pt => pt.Advertisement)
                .WithMany(p => p.AdvertisementCategory)
                .HasForeignKey(pt => pt.AdvertisementId);

            modelBuilder.Entity<AdvertisementCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.AdvertisementCategory)
                .HasForeignKey(pt => pt.CategoryId);

            //User Providers
            modelBuilder.Entity<UserProvider>()
                .HasKey(x => new { x.UserId, x.ProviderId });

            modelBuilder.Entity<UserProvider>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserProvider)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserProvider>()
                .HasOne(pt => pt.Provider)
                .WithMany(t => t.UserProvider)
                .HasForeignKey(pt => pt.ProviderId);

            //User advertisements
            modelBuilder.Entity<UserAdvertisement>()
                .HasKey(x => new { x.Id, x.UserId, x.AdvertisementId });

            modelBuilder.Entity<UserAdvertisement>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.WatchedAdvertisement)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserAdvertisement>()
                .HasOne(pt => pt.Advertisement)
                .WithMany(p => p.WatchedAdvertisement)
                .HasForeignKey(pt => pt.AdvertisementId)
                .OnDelete(DeleteBehavior.Restrict);

            //<<<<<END Many-To-Many relationships>>>>>> 
            #endregion

            #region REQUIRED AND/OR MAXLENGTH
            //<<<<REQUIRED AND/OR MAXLENGTH>>>>
            #region Advertisement
            modelBuilder.Entity<Advertisement>()
                    .Property(x => x.PictureURL)
                    .IsRequired()
                    .HasMaxLength(2000);
            modelBuilder.Entity<Advertisement>()
                    .Property(x => x.AdvertisementURL)
                    .HasMaxLength(2000);
            modelBuilder.Entity<Advertisement>()
                    .Property(x => x.AdvertisementType)
                    .IsRequired();
            modelBuilder.Entity<Advertisement>()
                   .Property(x => x.AmountRemaining)
                   .IsRequired();
            modelBuilder.Entity<Advertisement>()
                    .Property(x => x.UserId)
                    .IsRequired();
            #endregion
            #region AppSetting
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.Radius)
                    .IsRequired();
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.MaximumNotifications)
                    .IsRequired();
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.MaximumConversations)
                    .IsRequired();
            modelBuilder.Entity<AppSetting>()
                   .Property(x => x.Language)
                   .IsRequired();
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.Sound)
                    .IsRequired();
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.Vibrate)
                    .IsRequired();
            modelBuilder.Entity<AppSetting>()
                    .Property(x => x.UserId)
                    .IsRequired();
            #endregion
            #region Category
            modelBuilder.Entity<Category>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            #endregion
            #region Connection
            modelBuilder.Entity<Connection>()
                    .Property(x => x.Progress)
                    .IsRequired();
            #endregion
            #region Feedback
            modelBuilder.Entity<Feedback>()
                    .Property(x => x.Rating)
                    .IsRequired();
            modelBuilder.Entity<Feedback>()
                    .Property(x => x.FeedbackType)
                    .IsRequired();
            modelBuilder.Entity<Feedback>()
                    .Property(x => x.Message)
                    .HasMaxLength(500);
            modelBuilder.Entity<Feedback>()
                    .Property(x => x.CreationDate)
                    .HasColumnType("datetime2")
                    .IsRequired();
            modelBuilder.Entity<Feedback>()
                    .Property(x => x.UserId)
                    .IsRequired();
            #endregion
            #region Message
            modelBuilder.Entity<Message>()
                    .Property(x => x.Body)
                    .IsRequired()
                    .HasMaxLength(500);
            modelBuilder.Entity<Message>()
                    .Property(x => x.CreationDate)
                    .HasColumnType("datetime2")
                    .IsRequired();
            #endregion
            #region Provider
            modelBuilder.Entity<Provider>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            #endregion
            #region Report
            modelBuilder.Entity<Report>()
                    .Property(x => x.Message)
                    .IsRequired()
                    .HasMaxLength(500);
            modelBuilder.Entity<Report>()
                    .Property(x => x.ReportType)
                    .IsRequired();
            #endregion
            #region Reported
            modelBuilder.Entity<Reported>()
                    .Property(x => x.ReporterUserId)
                    .IsRequired();
            #endregion
            #region Role
            modelBuilder.Entity<Role>()
                    .Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            #endregion
            #region User
            modelBuilder.Entity<User>()
                    .Property(x => x.Username)
                    .IsRequired()
                    .HasMaxLength(32);
            modelBuilder.Entity<User>()
                    .Property(x => x.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);
            modelBuilder.Entity<User>()
                    .Property(x => x.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
            modelBuilder.Entity<User>()
                    .Property(x => x.CreationDate)
                    .HasColumnType("datetime2")
                    .IsRequired();
            modelBuilder.Entity<User>()
                    .Property(x => x.ActivityDate)
                    .HasColumnType("datetime2")
                    .IsRequired();
            modelBuilder.Entity<User>()
                    .Property(x => x.ProfilePictureURL)
                    .HasMaxLength(2000);
            modelBuilder.Entity<User>()
                    .Property(x => x.Gender)
                    .IsRequired();
            modelBuilder.Entity<User>()
                    .Property(x => x.Email)
                    .HasMaxLength(320);
            modelBuilder.Entity<User>()
                    .Property(x => x.IsHidden)
                    .IsRequired();
            modelBuilder.Entity<User>()
                    .Property(x => x.IsBanned)
                    .IsRequired();
            #endregion
            #region UserAdvertisement
            modelBuilder.Entity<UserAdvertisement>()
                    .Property(x => x.ViewDate)
                    .HasColumnType("datetime2")
                    .IsRequired();
            modelBuilder.Entity<UserAdvertisement>()
                    .Property(x => x.IsClicked)
                    .IsRequired();
            #endregion
            #region UserProvider
            modelBuilder.Entity<UserProvider>()
                    .Property(x => x.ProviderUserId)
                    .IsRequired();
            #endregion
            //<<<<END REQUIRED AND/OR MAXLENGTH>>>> 
            #endregion

            #region Special No Cascade
            //<<<<<SPECIAL NO CASCADE>>>>>
            modelBuilder.Entity<User>()
                .HasMany(x => x.Advertisement)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);

            //INDIEN FEEDBACK VERWIJDEREN OOK DE USER VERWIJDERT!
            //modelBuilder.Entity<User>()
            //    .HasMany(x => x.Feedback)
            //    .WithOne(x => x.User)
            //    .OnDelete(DeleteBehavior.Restrict);

            //<<<<<END SPECIAL NO CASCADE>>>>> 
            #endregion
        }
    }
}

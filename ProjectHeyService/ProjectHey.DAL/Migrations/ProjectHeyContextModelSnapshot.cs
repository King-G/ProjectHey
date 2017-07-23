using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectHey.DAL;
using ProjectHey.DOMAIN.Enums;

namespace ProjectHey.DAL.Migrations
{
    [DbContext(typeof(ProjectHeyContext))]
    partial class ProjectHeyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectHey.DOMAIN.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvertisementType");

                    b.Property<string>("AdvertisementURL")
                        .HasMaxLength(2000);

                    b.Property<int>("AmountRemaining");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.AdvertisementCategory", b =>
                {
                    b.Property<int>("AdvertisementId");

                    b.Property<int>("CategoryId");

                    b.HasKey("AdvertisementId", "CategoryId");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AdvertisementCategory");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.AppSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Language");

                    b.Property<int>("MaximumConnections");

                    b.Property<int>("Radius");

                    b.Property<bool>("Sound");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AppSetting");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Blocked", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BlockedUserId");

                    b.Property<bool>("IsHidden");

                    b.HasKey("UserId", "BlockedUserId");

                    b.HasIndex("BlockedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Blocked");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Connection", b =>
                {
                    b.Property<int>("UserOneId");

                    b.Property<int>("UserTwoId");

                    b.Property<string>("CustomUsername");

                    b.Property<double>("Progress");

                    b.HasKey("UserOneId", "UserTwoId");

                    b.HasIndex("UserOneId");

                    b.HasIndex("UserTwoId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FeedbackType");

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<int>("Rating");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("ReportType");

                    b.HasKey("Id");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Reported", b =>
                {
                    b.Property<int>("ReporterUserId");

                    b.Property<int>("ReportedUserId");

                    b.Property<int>("ReportId");

                    b.HasKey("ReporterUserId", "ReportedUserId");

                    b.HasIndex("ReportId");

                    b.HasIndex("ReportedUserId");

                    b.HasIndex("ReporterUserId");

                    b.ToTable("Reported");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Connected");

                    b.Property<int>("SignalRUserId");

                    b.Property<string>("UserAgent");

                    b.HasKey("Id");

                    b.HasIndex("SignalRUserId");

                    b.ToTable("SignalRConnection");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRConversationRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("RoomName")
                        .IsUnique();

                    b.ToTable("SignalRConversationRoom");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SignalRConversationRoomId");

                    b.Property<int>("SignalRUserId");

                    b.HasKey("Id");

                    b.HasIndex("SignalRConversationRoomId");

                    b.HasIndex("SignalRUserId");

                    b.ToTable("SignalRMessage");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("SignalRUser");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRUserConversationRoom", b =>
                {
                    b.Property<int>("SignalRUserId");

                    b.Property<int>("SignalRConversationRoomId");

                    b.HasKey("SignalRUserId", "SignalRConversationRoomId");

                    b.HasIndex("SignalRConversationRoomId");

                    b.HasIndex("SignalRUserId");

                    b.ToTable("SignalRUserConversationRoom");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CityID");

                    b.Property<string>("CityName");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(320);

                    b.Property<string>("FacebookId")
                        .IsRequired();

                    b.Property<string>("FacebookToken")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Gender");

                    b.Property<bool>("IsBanned");

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProfilePictureURL")
                        .HasMaxLength(2000);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.UserAdvertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<int>("AdvertisementId");

                    b.Property<bool>("IsClicked");

                    b.Property<int?>("ReportId");

                    b.Property<DateTime>("ViewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "UserId", "AdvertisementId");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAdvertisement");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.UserCategory", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("CategoryId");

                    b.HasKey("UserId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCategory");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Advertisement", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithMany("Advertisement")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.AdvertisementCategory", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.Advertisement", "Advertisement")
                        .WithMany("AdvertisementCategory")
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectHey.DOMAIN.Category", "Category")
                        .WithMany("AdvertisementCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.AppSetting", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithOne("Appsetting")
                        .HasForeignKey("ProjectHey.DOMAIN.AppSetting", "UserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Blocked", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "BlockedUser")
                        .WithMany()
                        .HasForeignKey("BlockedUserId");

                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithMany("BlockedUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Connection", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "UserOne")
                        .WithMany("Connections")
                        .HasForeignKey("UserOneId");

                    b.HasOne("ProjectHey.DOMAIN.User", "UserTwo")
                        .WithMany()
                        .HasForeignKey("UserTwoId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Feedback", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithMany("Feedback")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.Reported", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectHey.DOMAIN.User", "ReportedUser")
                        .WithMany()
                        .HasForeignKey("ReportedUserId");

                    b.HasOne("ProjectHey.DOMAIN.User", "ReporterUser")
                        .WithMany("ReportedUsers")
                        .HasForeignKey("ReporterUserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRConnection", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.SignalRUser", "SignalRUser")
                        .WithMany("Connections")
                        .HasForeignKey("SignalRUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRMessage", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.SignalRConversationRoom", "SignalRConversationRoom")
                        .WithMany("Messages")
                        .HasForeignKey("SignalRConversationRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectHey.DOMAIN.SignalRUser", "SignalRUser")
                        .WithMany("Messages")
                        .HasForeignKey("SignalRUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRUser", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithOne("SignalRUser")
                        .HasForeignKey("ProjectHey.DOMAIN.SignalRUser", "UserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.SignalRUserConversationRoom", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.SignalRConversationRoom", "SignalRConversationRoom")
                        .WithMany("Users")
                        .HasForeignKey("SignalRConversationRoomId");

                    b.HasOne("ProjectHey.DOMAIN.SignalRUser", "SignalRUser")
                        .WithMany("Rooms")
                        .HasForeignKey("SignalRUserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.UserAdvertisement", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.Advertisement", "Advertisement")
                        .WithMany("WatchedAdvertisement")
                        .HasForeignKey("AdvertisementId");

                    b.HasOne("ProjectHey.DOMAIN.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId");

                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithMany("WatchedAdvertisement")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectHey.DOMAIN.UserCategory", b =>
                {
                    b.HasOne("ProjectHey.DOMAIN.Category", "Category")
                        .WithMany("UserCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectHey.DOMAIN.User", "User")
                        .WithMany("UserCategory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

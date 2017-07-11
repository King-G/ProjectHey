using FizzWare.NBuilder;
using ProjectHey.BLL;
using ProjectHey.DOMAIN;
using ProjectHey.DOMAIN.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectHey.MockData
{
    class Program
    {
        private static readonly AppSettingManager appSettingManager = new AppSettingManager();
        private static readonly CategoryManager categoryManager = new CategoryManager();
        private static readonly ConnectionManager connectionManager = new ConnectionManager();
        private static readonly MessageManager messageManager = new MessageManager();
        private static readonly ReportedManager reportedManager = new ReportedManager();
        private static readonly RoleManager roleManager = new RoleManager();
        private static readonly UserManager userManager = new UserManager();
        private static readonly ProviderManager providerManager = new ProviderManager();
        private static readonly UserProviderManager userProviderManager = new UserProviderManager();
        private static readonly AdvertisementManager advertisementManager = new AdvertisementManager();
        private static readonly AdvertisementCategoryManager advertisementCategoryManager = new AdvertisementCategoryManager();
        private static readonly BlockedManager blockedManager = new BlockedManager();
        private static readonly ReportManager reportManager = new ReportManager();
        private static readonly UserAdvertisementManager userAdvertisementManager = new UserAdvertisementManager();
        private static readonly UserCategoryManager userCategoryManager = new UserCategoryManager();
        private static readonly UserRoleManager userRoleManager = new UserRoleManager();
        private static readonly FeedbackManager feedbackManager = new FeedbackManager();

        private static readonly Random _random = new Random();
        private static readonly object _syncLock = new object();

        //Datetime
        private static DateTime start = new DateTime(1995, 1, 1);
        private static int range = (DateTime.Today - start).Days;

        static void Main(string[] args)
        {
            string input = System.Console.ReadLine();

            if (input != null)
                switch (input.ToLower())
                {
                    case "fill-database":
                        FillDatabase();
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
        }

        private static void FillDatabase()
        {
            int roleCount = 5;
            int categoryCount = 10;
            int providerCount = 1;

            int totalAdvertisementCount = 50;
            int advertisementCategoryCount = 3;

            int userCount = 100;

            int userCategoryCount = 2;
            int userFeedbackCount = 2;    
            int userWatchedAdvertisementCount = 20;
            int userConnectionCount = 10;
            int userReportedCount = 2;
            int userBlockedCount = 2;
            int userMessageCount = 20;


            BuilderSetup.DisablePropertyNamingFor<User, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Role, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Category, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Provider, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Report, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<AppSetting, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Feedback, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<UserAdvertisement, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Message, int>(x => x.Id);
            BuilderSetup.DisablePropertyNamingFor<Advertisement, int>(x => x.Id);



            #region Single Tables
            Console.WriteLine("Creating {0} roles", roleCount);
            var roles = Builder<Role>.CreateListOfSize(roleCount).All().Build().ToList();
            roles = roleManager.CreateRangeAsync(roles).Result.ToList();
            Console.WriteLine("{0} roles created", roleCount);

            Console.WriteLine("Creating {0} categories", categoryCount);
            var categories = Builder<Category>.CreateListOfSize(categoryCount).All().Build().ToList();
            categories = categoryManager.CreateRangeAsync(categories).Result.ToList();
            Console.WriteLine("{0} categories created", categoryCount);

            Console.WriteLine("Creating {0} provider ", providerCount);
            var providers = new List<Provider>() { new Provider() { Name = "facebook" } };
            providers = providerManager.CreateRangeAsync(providers).Result.ToList();
            Console.WriteLine("{0} categories created", providerCount);

            //Console.WriteLine("Creating {0} reports ", reportCount);
            //var reports = Builder<Report>.CreateListOfSize(reportCount).All().Build().ToList();
            //reports = reportManager.CreateRangeAsync(reports).Result.ToList();
            //Console.WriteLine("{0} categories created", reportCount);

            Console.WriteLine("Creating {0} users", userCount);
            var users = Builder<User>.CreateListOfSize(userCount).All()
                .With(x => x.Location = new Location() { Latitude = GetRandomLatitude(), Longitude = GetRandomLongitude() })
                .Build().ToList();
            users = userManager.CreateRangeAsync(users).Result.ToList(); // create users for Id

            #endregion

            //for (int i = 0; i < users.Count; i++)
            //{
            //    users[i].Appsetting = 
            //}
            try
            {
                CreateUserRoles(roles, users);
                CreateUserProviders(providers, users);
                CreateConnections(userConnectionCount, users);
                CreateAppSetting(users);
                CreateMessages(userMessageCount, users);
                CreateBlockedUsers(userBlockedCount, users);
                CreateReprtedUsers(userReportedCount, users);
                CreateUserCategories(userCategoryCount, categories, users);
                CreateFeedbacks(userFeedbackCount, users);

                List<Advertisement> advertisements = CreateAdvertisements(totalAdvertisementCount, users);
                CreateAdvertisementCategories(advertisementCategoryCount, categories, advertisements);
                CreateWatchedAdvertisements(userWatchedAdvertisementCount, users, advertisements);

            }
            catch (Exception exception)
            {
                var trace = new StackTrace(exception, true);
                var frame = trace.GetFrames().Last();
                var lineNumber = frame.GetFileLineNumber();
                var fileName = frame.GetFileName();
                throw exception;
            }



        }

        private static void CreateWatchedAdvertisements(int userWatchedAdvertisementCount, List<User> users, List<Advertisement> advertisements)
        {
            Console.WriteLine("Creating {0} watched advertisement categories", userWatchedAdvertisementCount);
            var watchedAdvertisements = Builder<UserAdvertisement>.CreateListOfSize(userWatchedAdvertisementCount).All()
                .With(x => x.AdvertisementId = Pick<Advertisement>.RandomItemFrom(advertisements).Id)
                .With(x => x.UserId = Pick<User>.RandomItemFrom(users).Id)
                .Build().ToList();
            watchedAdvertisements = userAdvertisementManager.CreateRangeAsync(watchedAdvertisements).Result.ToList();
            Console.WriteLine("{0} watched advertisements created", userWatchedAdvertisementCount);
        }

        private static void CreateAdvertisementCategories(int advertisementCategoryCount, List<Category> categories, List<Advertisement> advertisements)
        {
            Console.WriteLine("Creating {0} advertisement categories per advertisement", advertisementCategoryCount);
            List<AdvertisementCategory> advertisementCategories = new List<AdvertisementCategory>();
            for (int i = 0; i < advertisements.Count; i++)
            {
                List<Category> categoriesCopy = new List<Category>(categories);
                for (int j = 0; j < advertisementCategoryCount; j++)
                {
                    AdvertisementCategory advertisementCategory = new AdvertisementCategory
                    {
                        AdvertisementId = advertisements[i].Id
                    };
                    Category category = Pick<Category>.RandomItemFrom(categoriesCopy);
                    advertisementCategory.CategoryId = category.Id;

                    advertisementCategories.Add(advertisementCategory);
                    categoriesCopy.Remove(category);
                }
            }
            advertisementCategories = advertisementCategoryManager.CreateRangeAsync(advertisementCategories).Result.ToList();
            Console.WriteLine("{0} advertisement categories per advertisement created", advertisementCategoryCount);
        }

        private static void CreateFeedbacks(int userFeedbackCount, List<User> users)
        {
            Console.WriteLine("Creating {0} feedbacks", userFeedbackCount);
            List<Feedback> feedbacks = new List<Feedback>();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < userFeedbackCount; j++)
                {
                    Feedback feedback = new Feedback();
                    feedback = Builder<Feedback>.CreateNew().Build();
                    feedback.UserId = users[i].Id;

                    feedbacks.Add(feedback);
                }
            }
            feedbacks = feedbackManager.CreateRangeAsync(feedbacks).Result.ToList();
            Console.WriteLine("{0} feedbacks created", userFeedbackCount);
        }

        private static List<Advertisement> CreateAdvertisements(int totalAdvertisementCount, List<User> users)
        {
            Console.WriteLine("Creating {0} advertisements", totalAdvertisementCount);
            var advertisements = Builder<Advertisement>.CreateListOfSize(totalAdvertisementCount).All()
                .With(x => x.UserId = Pick<User>.RandomItemFrom(users).Id)
                .With(x => x.Location = new Location() { Latitude = GetRandomLatitude(), Longitude = GetRandomLongitude() })
                .Build().ToList();
            advertisements = advertisementManager.CreateRangeAsync(advertisements).Result.ToList();
            Console.WriteLine("{0} advertisements created", totalAdvertisementCount);
            return advertisements;
        }

        private static void CreateUserCategories(int userCategoryCount, List<Category> categories, List<User> users)
        {
            Console.WriteLine("Creating {0} usercategories per user", userCategoryCount);
            List<UserCategory> userCategories = new List<UserCategory>();
            for (int i = 0; i < users.Count; i++)
            {
                List<Category> categoriesCopy = new List<Category>(categories);
                for (int j = 0; j < userCategoryCount; j++)
                {
                    UserCategory userCategory = new UserCategory
                    {
                        UserId = users[i].Id
                    };

                    Category category = Pick<Category>.RandomItemFrom(categoriesCopy);
                    userCategory.CategoryId = category.Id;

                    userCategories.Add(userCategory);
                    categoriesCopy.Remove(category);
                }
            }

            userCategories = userCategoryManager.CreateRangeAsync(userCategories).Result.ToList();
            Console.WriteLine("{0} usercategories per user created", userCategoryCount);
        }

        private static void CreateReprtedUsers(int userReportedCount, List<User> users)
        {
            Console.WriteLine("Creating {0} reports per user", userReportedCount);
            List<Reported> reportedUsers = new List<Reported>();
            for (int i = 0; i < users.Count; i++)
            {
                List<User> usersCopy = new List<User>(users);
                for (int j = 0; j < userReportedCount; j++)
                {
                    Reported reported = new Reported
                    {
                        ReporterUserId = users[i].Id
                    };

                    User reportedUser = Pick<User>.RandomItemFrom(usersCopy.Where(x => x.Id != users[i].Id).ToList());
                    reported.ReportedUserId = reportedUser.Id;

                    usersCopy.Remove(reportedUser);

                    Report report = new Report();
                    report = Builder<Report>.CreateNew().Build();
                    report = reportManager.CreateAsync(report).Result;

                    reported.ReportId = report.Id;

                    reportedUsers.Add(reported);
                }
            }
            reportedUsers = reportedManager.CreateRangeAsync(reportedUsers).Result.ToList();
            Console.WriteLine("{0} reports per user created", userReportedCount);
        }

        private static void CreateBlockedUsers(int userBlockedCount, List<User> users)
        {
            Console.WriteLine("Creating {0} userBlocked per user", userBlockedCount);
            List<Blocked> blockedUsers = new List<Blocked>();
            for (int i = 0; i < users.Count; i++)
            {
                List<User> usersCopy = new List<User>(users);
                for (int j = 0; j < userBlockedCount; j++)
                {
                    Blocked blocked = new Blocked
                    {
                        UserId = users[i].Id
                    };

                    User blockedUser = Pick<User>.RandomItemFrom(usersCopy.Where(x => x.Id != users[i].Id).ToList());
                    blocked.BlockedUserId = blockedUser.Id;

                    usersCopy.Remove(blockedUser);

                    blockedUsers.Add(blocked);
                }           
            }
            blockedUsers = blockedManager.CreateRangeAsync(blockedUsers).Result.ToList();
            Console.WriteLine("{0} userlogins created per user", userBlockedCount);
        }

        private static void CreateMessages(int userMessageCount, List<User> users)
        {
            Console.WriteLine("Creating {0} send messages & {0} received messages per user", userMessageCount);
            List<Message> messages = new List<Message>();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < userMessageCount; j++)
                {
                    Message message = new Message();
                    message = Builder<Message>.CreateNew().Build();
                    message.UserSenderId = users[i].Id;

                    User receiver = Pick<User>.RandomItemFrom(users.Where(x => x.Id != users[i].Id).ToList());
                    message.UserReceiverId = receiver.Id;

                    messages.Add(message);
                }

                for (int j = 0; j < userMessageCount; j++)
                {
                    Message message = new Message();
                    message = Builder<Message>.CreateNew().Build();
                    message.UserReceiverId = users[i].Id;

                    User sender = Pick<User>.RandomItemFrom(users.Where(x => x.Id != users[i].Id).ToList());
                    message.UserSenderId = sender.Id;

                    messages.Add(message);
                }
            }

            messages = messageManager.CreateRangeAsync(messages).Result.ToList();
            Console.WriteLine("{0} send messages created & {0} received messages created", userMessageCount);
        }

        private static void CreateAppSetting(List<User> users)
        {
            Console.WriteLine("Creating {0} appsettings", users.Count);
            List<AppSetting> userAppSettings = new List<AppSetting>();
            for (int i = 0; i < users.Count; i++)
            {
                AppSetting appSetting = Builder<AppSetting>.CreateNew().Build();
                appSetting.UserId = users[i].Id;
                userAppSettings.Add(appSetting);
            }
            userAppSettings = appSettingManager.CreateRangeAsync(userAppSettings).Result.ToList();
            Console.WriteLine("{0} appsettings created", users.Count);
        }

        private static void CreateConnections(int userConnectionCount, List<User> users)
        {
            Console.WriteLine("Creating {0} connections per user", userConnectionCount);

            List<Connection> connectedUsers = new List<Connection>();
            for (int i = 0; i < users.Count; i++)
            {
                List<User> usersCopy = new List<User>(users);
                for (int j = 0; j < userConnectionCount; j++)
                {
                    Connection connection = new Connection();
                    connection = Builder<Connection>.CreateNew().Build();
                    connection.UserOneId = users[i].Id;

                    User connectedUser = Pick<User>.RandomItemFrom(usersCopy.Where(x => x.Id != users[i].Id).ToList());
                    connection.UserTwoId = connectedUser.Id;

                    usersCopy.Remove(connectedUser);

                    connectedUsers.Add(connection);
                }
            }
            connectedUsers = connectionManager.CreateRangeAsync(connectedUsers).Result.ToList();
            Console.WriteLine("{0} connections created per user", userConnectionCount);
        }

        private static void CreateUserProviders(List<Provider> providers, List<User> users)
        {
            Console.WriteLine("Creating {0} userProviders per user", users.Count);

            List<UserProvider> userProviders = new List<UserProvider>();
            for (int i = 0; i < users.Count; i++)
            {
                userProviders.Add(new UserProvider() { ProviderId = Pick<Provider>.RandomItemFrom(providers).Id, UserId = users[i].Id, ProviderUserId = (i+1) });
            }
            userProviders = userProviderManager.CreateRangeAsync(userProviders).Result.ToList();
            Console.WriteLine("{0} userProviders per user created", users.Count);
        }

        private static void CreateUserRoles(List<Role> roles, List<User> users)
        {
            Console.WriteLine("Creating {0} userRoles", users.Count);
            List<UserRole> userRoles = new List<UserRole>();
            for (int i = 0; i < users.Count; i++)
            {
                userRoles.Add(new UserRole() { RoleId = Pick<Role>.RandomItemFrom(roles).Id, UserId = users[i].Id });
            }
            userRoles = userRoleManager.CreateRangeAsync(userRoles).Result.ToList();
            Console.WriteLine("{0} userRoles created", users.Count);
        }

        private static double RandomDouble(double minimum, double maximum)
        {
            lock (_syncLock)
            {
                return _random.NextDouble() * (maximum - minimum) + minimum;
            }
        }
        private static double GetRandomLatitude()
        {
            return RandomDouble(-90.0, 90.0);
        }
        private static double GetRandomLongitude()
        {
            return RandomDouble(-180.0, 180.0);
        }
    }

}

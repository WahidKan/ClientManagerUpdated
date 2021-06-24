using System;
using TodoREST;
using UserManager.Services;
using UserManager.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static TodoItemManager? TodoManager { get; private set; }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            TodoManager = new TodoItemManager(new RestService());
            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new LoginPage());


            DatabaseLocation = databaseLocation;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

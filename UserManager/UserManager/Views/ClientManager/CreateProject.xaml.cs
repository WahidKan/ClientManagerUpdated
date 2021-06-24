using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using UserManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProject : ContentPage
    {
        public CreateProject()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Project project = new Project();
            project.Client_ID = Convert.ToInt32(clientId.Text);
            project.Project_Name = projectName.Text;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Project>();
            //    conn.Insert(project);
            //    ProjectViewModel.addItem(project);
            //    Navigation.PopAsync();
            //}

            Uri uri = new Uri(String.Format(Constants.AddProjectURL, String.Empty));

            using (HttpClient httpclient = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(project);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpclient.PostAsync(uri, stringContent);
            }

            ProjectViewModel.addItem(project);
            await Navigation.PopAsync();

        }
    }
}
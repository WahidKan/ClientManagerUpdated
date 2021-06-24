using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProjectPage : ContentPage
    {
        Project project;
        public EditProjectPage()
        {
            InitializeComponent();
        }

        public EditProjectPage(Project selectedProject)
        {
            InitializeComponent();
            project = selectedProject;
            clientId.Text = selectedProject.Client_ID.ToString();
            projectName.Text = selectedProject.Project_Name;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            project.Client_ID = Convert.ToInt32(clientId.Text);
            project.Project_Name = projectName.Text;

            Uri uri = new Uri(String.Format(Constants.UpdateProjectURL, String.Empty));
            using (HttpClient client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(project);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            //IndustryViewModel.addItem(industry);
            await Navigation.PopAsync();

        }
    }
}
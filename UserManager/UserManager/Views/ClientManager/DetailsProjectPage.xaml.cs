using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserManager.Views.ClientManager
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsProjectPage : ContentPage
    {
        public DetailsProjectPage()
        {
            InitializeComponent();
        }

        public DetailsProjectPage(Project selectedProject)
        {
            InitializeComponent();
            clientId.Text = selectedProject.Client_ID.ToString();
            projectName.Text = selectedProject.Project_Name;
        }
    }
}
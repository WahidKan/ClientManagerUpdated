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
    public partial class EditIndustryPage : ContentPage
    {
        public Industry industry;
        public EditIndustryPage()
        {
            InitializeComponent();
        }

        public EditIndustryPage(Industry selectedIndustry)
        {
            InitializeComponent();
            industry = selectedIndustry;
            IndustryNameEdit.Text = selectedIndustry.Industry_Name;
 

        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            industry.Industry_Name = IndustryNameEdit.Text;

            Uri uri = new Uri(String.Format(Constants.UpdateIndustryURL, String.Empty));
            using (HttpClient client = new HttpClient())
            {

                var json = JsonConvert.SerializeObject(industry);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            //IndustryViewModel.addItem(industry);
            await Navigation.PopAsync();


        }
    }
}
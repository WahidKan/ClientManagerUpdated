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
    public partial class CreateIndustry : ContentPage
    {
        public CreateIndustry()
        {
            InitializeComponent();
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            Industry industry = new Industry();
            industry.Industry_Name = industryName.Text;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Industry>();
            //    conn.Insert(industry);
            //IndustryViewModel.addItem(industry);
            //    //IndustryViewModel

            //}

            Uri uri = new Uri(String.Format(Constants.AddIndustryURL, String.Empty));
            using (HttpClient client = new HttpClient())
            {

                    var json = JsonConvert.SerializeObject(industry);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                    //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);
            }

            IndustryViewModel.addItem(industry);
            await Navigation.PopAsync();
            
            
        }
    }
}
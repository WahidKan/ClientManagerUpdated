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
    public partial class DetailsIndustryPage : ContentPage
    {
        public Industry industry;

        public DetailsIndustryPage()
        {
            InitializeComponent();
        }

        public DetailsIndustryPage(Industry selectedIndustry)
        {
            InitializeComponent();
            industry = selectedIndustry;
            IndustryNameEdit.Text = selectedIndustry.Industry_Name;
        }
    }
}
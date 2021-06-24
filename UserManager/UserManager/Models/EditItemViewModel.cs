using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UserManager.Models
{
    class EditItemViewModel
    {
        public EditItemViewModel(Industry industry)
        {
            //this.NavigateBackCommand = new Command(this.GoBack);
            //this.CancelCommand = new Command(this.GoBack);
            //this.SaveCommand = new Command(this.Save);
            this.Industry = industry;
            //this.Title = "Edit Item";
        }
        public Industry Industry { get; }
    }
}

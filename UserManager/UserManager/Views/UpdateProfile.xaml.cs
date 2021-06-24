using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserManager.Views;
using UserManager.Models;
using SQLite;

namespace UserManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProfile : ContentPage
    {
        User _user;
        public UpdateProfile()
        {
            InitializeComponent();
        }
        public UpdateProfile(User user)
        {
            InitializeComponent();
            // _user = user;
            if (user != null)
            {
                userName.Text = user.UserName;
                //userName.Text = "test";
                //userName.IsReadOnly = true;
                if (!String.IsNullOrEmpty(userName.Text)){ 
                userName.IsReadOnly = true;
            }
                firstName.Text = user.FirstName;
                lastName.Text = user.LastName;
                email.Text = user.Email;
                _user = user;
            }
            else {
                _user = new User();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Camera camera = new Camera("Hello World");
            //await Shell.Current.GoToAsync();

            //var contact = "Jawa";
            //Item item = new Item();

            

            //var camera = new Camera();
            //camera.BindingContext = contact;
            // Navigation.PopAsync();
            //NavigationService.NavigateToAsync<Item>(item);

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
               // User user = new User() {UserName = userName.Text, FirstName = firstName.Text, LastName = lastName.Text, Gender = "Male", Email = email.Text};
               // _user = user;
                
              

                conn.CreateTable<User>();
                int rows = 0;
                var users = conn.Table<User>().ToList();
                if (users != null && (users.Count != 0))
                {
                    _user = users.FirstOrDefault(x => x.UserName == userName.Text);
                    if (_user != null)
                    {

                        fillUserObject(_user);
                        rows = conn.Update(_user);

                    }
                    else {
                        _user = new User();
                        fillUserObject(_user);
                        rows = conn.Insert(_user);
                    }
                }
                else {
                    _user = new User();
                    fillUserObject(_user);
                    rows = conn.Insert(_user);
                }

                //int row = conn.Update
                Console.WriteLine("ROW::" + rows);
                if (rows > 0)
                {
                    DisplayAlert("Success", "User successfully updated", "OK");
                    Navigation.PopAsync();
                    //Shell.Current.GoToAsync("..");
                }

                else
                    DisplayAlert("Failure", "User failed to be updated", "OK");
            }
        }




        private void fillUserObject(User user) {
            user.UserName = userName.Text;
            user.FirstName = firstName.Text;
            user.Email = email.Text;
            user.LastName = lastName.Text;
          
        }

    }



}
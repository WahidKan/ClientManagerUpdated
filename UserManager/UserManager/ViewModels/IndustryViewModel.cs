using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserManager.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserManager.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace UserManager.ViewModels
{
    public class IndustryViewModel : BaseViewModel
    {
        public ObservableCollection<object> selectedItems;



        public ICommand EditCommand => new Command(EditIndustry);

        private static ObservableCollection<Industry> _industriesList = new ObservableCollection<Industry>();
        public ObservableCollection<Industry> Industries
        {
            get { return _industriesList; }
            set
            {
                if (_industriesList == value)
                    return;

                _industriesList = value;
                OnPropertyChanged();
            }
        }

        public IndustryViewModel()
        {

            //List<Industry> industries = new List<Industry>();
            //Console.Write("Inside ViewModel");
            //_industriesList.Add(new Industry { ID = 1, Industry_Name = "Telecom" });
            //_industriesList.Add(new Industry { ID = 2, Industry_Name = "Manufacturing" });
            //_industriesList.Add(new Industry { ID = 3, Industry_Name = "Banking" });


            //try
            //{
            //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //    {
            //        conn.CreateTable<Industry>();
            //        for (int i = 0; i < _industriesList.Count; i++)
            //        {
            //            conn.Insert(_industriesList[i]);
            //        }
            //        _industriesList = GetAllIndustries();


            //    }
            //}

            //catch (TargetInvocationException e)
            //{
            //    Console.WriteLine(e.Message);

            //}

            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //_industriesList = GetAllIndustries();
            GetAllIndustries();


        }

        public List<Industry> list { get; set; }
        public async void GetAllIndustries()
        {



                Uri uri = new Uri(String.Format(Constants.GetAllIndustriesURL, String.Empty));

                //HttpClientHandler handler = new HttpClientHandler();
                //handler.UseDefaultCredentials = true;

                using (HttpClient client = new HttpClient())
                {
                    try
                    {


                        HttpResponseMessage response = await client.GetAsync(uri);
                        //var industries = JsonConvert.DeserializeObject<List<Industry>>(response);

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            list = JsonConvert.DeserializeObject<List<Industry>>(content);
                        }
                        else
                        {
                            Console.WriteLine("nothing");
                        }
                    }
                    catch (System.Net.Http.HttpRequestException ex)
                    {
                        Debug.WriteLine(@"\tERROR {0}", ex.Message);
                    }

                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"\tERROR {0}", ex.Message);
                    }
                }




            //Industries = new List<Industry>();




            //var industryRepository = new IndustryRepository();
            //var list = await industryRepository.GetIndustries();

            ObservableCollection<Industry> oc = new ObservableCollection<Industry>();

            foreach (var item in list)
            {
                oc.Add(item);
            }

            Console.WriteLine(oc);

            //_industriesList = oc;
            Industries = oc;
            //return oc;

            //}

        }


        public void EditIndustry()
        {
            Industries.Add(new Industry { ID = 5, Industry_Name = "aaa" });
        }


        public static void addItem(Industry industry)
        {
            if (industry != null)
            {
                _industriesList.Add(industry);
            }

        }

        public static void editItem(Industry industry)
        {
            if (industry != null)
            {

                ObservableCollection<Industry> _tempList = _industriesList;

                foreach (Industry industry1 in _industriesList)
                {
                    if (industry.ID.Equals(industry1.ID))
                    {
                        _tempList.Remove(industry1);
                        _tempList.Add(industry);
                        //int index = _industriesList.IndexOf(industry1);
                        //_tempList.Add(industry);
                        //_tempList.Replace
                        break;
                    }
                }

                _industriesList = _tempList;

            }
        }

        public static void getItems()
        {


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                List<Industry> list = conn.Table<Industry>().ToList();
                ObservableCollection<Industry> oc = new ObservableCollection<Industry>();

                foreach (var item in list)
                {
                    oc.Add(item);
                }

                Console.WriteLine(oc);

                _industriesList = oc;

            }


        }


        private void GoToEditItem(object arg)
        {
            EditItemViewModel editItemViewModel = new EditItemViewModel((Industry)this.selectedItems[0]);
            //this.NavigationService.NavigateToConfigurationAsync(editItemViewModel);
        }

        private bool CanExecuteGoToEditItemCommand(object arg)
        {
            bool canExecute = this.selectedItems != null && this.selectedItems.Count == 1;
            return canExecute;
        }

        private ObservableCollection<Industry> ListToObservable(List<Industry> industries)
        {
            ObservableCollection<Industry> oc = new ObservableCollection<Industry>();

            foreach (var item in industries)
            {
                oc.Add(item);
            }

            Console.WriteLine(oc);

            return oc;
            
        }
    }
}


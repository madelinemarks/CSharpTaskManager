using SupportTicketXamarin.Pages;
using SupportTicketXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SupportTicketXamarin
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(MainViewModel.PersistencePath))
            {
                try
                {
                    BindingContext = JsonConvert
                        .DeserializeObject<MainViewModel>(File.ReadAllText(MainViewModel.PersistencePath), MainViewModel.Settings);
                }
                catch (Exception e)
                {
                    BindingContext = new MainViewModel();
                    File.Delete(MainViewModel.PersistencePath);
                }

            }
            else
            {
                BindingContext = new MainViewModel();
            }

            (BindingContext as MainViewModel).RefreshList(); // ?
        }

        private void AddA_Clicked(object sender, EventArgs e)
        {
            var dialog = new AppointmentDialog((BindingContext as MainViewModel).Items, BindingContext as MainViewModel);
            Navigation.PushModalAsync(dialog);
            (BindingContext as MainViewModel).RefreshList();
        }

        private void AddT_Clicked(object sender, EventArgs e)
        {
            var dialog = new SupportTicketDialog((BindingContext as MainViewModel).Items, BindingContext as MainViewModel);
            Navigation.PushModalAsync(dialog);
            (BindingContext as MainViewModel).RefreshList();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Remove();
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {

            if ((BindingContext as MainViewModel).SelectedItem is SupportTicket)
            {
                var dialog = new SupportTicketDialog((BindingContext as MainViewModel).Items, BindingContext as MainViewModel, true);
                Navigation.PushModalAsync(dialog);
                (BindingContext as MainViewModel).RefreshList();
            }
            else if ((BindingContext as MainViewModel).SelectedItem is Appointment)
            {
                var dialog = new AppointmentDialog((BindingContext as MainViewModel).Items, BindingContext as MainViewModel, true);
                Navigation.PushModalAsync(dialog);
                (BindingContext as MainViewModel).RefreshList();
            }
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Save();
        }

        private void Incomplete_Clicked(object sender, EventArgs e)
        {

        }
        
        private void Sort_Clicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Sort();
        }



    }
}

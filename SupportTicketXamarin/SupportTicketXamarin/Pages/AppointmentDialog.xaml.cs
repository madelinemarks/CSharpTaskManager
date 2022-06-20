using SupportTicketXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupportTicketXamarin.Pages
{
    public partial class AppointmentDialog : ContentPage
    {

        private ICollection<Item> items;
        private MainViewModel _mvm;
        private bool ed;
        public AppointmentDialog(ICollection<Item> items, MainViewModel mvm, bool edit = false)
        {
            InitializeComponent();
            _mvm = mvm;
            ed = edit;
            this.items = items;
            if (edit)
            {
                BindingContext = mvm.SelectedItem;
            } else
            {
                BindingContext = new Appointment();
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Ok_Clicked(object sender, EventArgs e)
        {

            if (ed)
            {
                items.Remove(_mvm.SelectedItem);
                items.Add(_mvm.SelectedItem);
            }
            else
            {
                items.Add(BindingContext as Appointment);
            }
            Navigation.PopModalAsync();
        }
    }
}
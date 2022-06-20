using SupportTicketXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SupportTicketXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportTicketDialog : ContentPage
    {
        private ICollection<Item> items;
        private MainViewModel _mvm;
        private bool ed;
        public SupportTicketDialog(ICollection<Item> items, MainViewModel mvm, bool edit = false)
        {
            InitializeComponent();
            this.items = items;
            _mvm = mvm;
            ed = edit;
            if (edit)
            {
                BindingContext = _mvm.SelectedItem;
            }
            else
            {
                BindingContext = new SupportTicket();
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
                items.Add(BindingContext as SupportTicket);
            }
            Navigation.PopModalAsync();
        }
    }
}
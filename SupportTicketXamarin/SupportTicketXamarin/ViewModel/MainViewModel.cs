using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
//using SupportTicketXamarin.Standard.Models;
//using SupportTicketXamarin.Standard.DTO;

namespace SupportTicketXamarin.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        internal static string PersistencePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\SaveData.json";
        internal static JsonSerializerSettings Settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        
        private bool sorted = false;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Item SelectedItem { get; set; }
      
        public ObservableCollection<Item> Items
        {
            get; set;
            /*          // couldnt get filtering to work, attempted logic to show I tried
            get
            {
                if (Sorted)
                {
                    return new ObservableCollection<Item>(Items.OrderByDescending(t => t.Priority));
                }
                else if (ToggleIncomplete)
                {
                    return new ObservableCollection<Item>(Items.Where(t => t.IsCompleted != null && t.IsCompleted == false));
                }
                else if (Query != null)
                {
                    return new ObservableCollection<Item>(Items.Where(t => t.Title.ToLower().Contains(Query.ToLower())
                     || t.Description.ToLower().Contains(Query.ToLower())));
                }
                else
                    return Items;
            }
            set
            {
                Items = new ObservableCollection<Item>();
            }*/
        }

        public MainViewModel()
        {
            ToggleIncomplete = false;
            Items = new ObservableCollection<Item>();
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Items");
        }


        private bool toggleIncomplete;
        public bool ToggleIncomplete
        {
            get
            {
                return toggleIncomplete;
            }
            set
            {
                toggleIncomplete = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Items");
            }
        }

        private string query;
        public string Query
        {
            get
            {
                return query;
            }
            set
            {
                query = value;
                NotifyPropertyChanged();
                RefreshList();
            }
        }

        public bool Sorted
        {
            get
            {
                return sorted;
            }
            set
            {
                sorted = value;
                NotifyPropertyChanged();
                RefreshList();
            }
        }

        public void RefreshList()
        {
            NotifyPropertyChanged("FilteredList");
        }


        public void Sort()
        {
            sorted = !sorted;
            RefreshList();
        }

        public void Remove()
        {
            Items.Remove(SelectedItem);
        }

        public void Complete()
        {
            SelectedItem.IsCompleted = true;
            NotifyPropertyChanged("SelectedItem");
            Refresh();
        }
        public void Save()
        {
            File.WriteAllText(PersistencePath, JsonConvert.SerializeObject(this, Settings));
        }

    }
}

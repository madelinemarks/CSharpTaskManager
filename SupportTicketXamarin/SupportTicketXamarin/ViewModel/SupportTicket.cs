using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketXamarin.ViewModel
{
    public class SupportTicket:Item, INotifyPropertyChanged
    {
        private DateTime deadline;
        public DateTime Deadline {
            get
            {
                return deadline;
            }

            set
            {
                deadline = value;
            }
        }

        public string DeadlineDisplay
        {
            get
            {
                return Deadline.ToShortDateString() ?? string.Empty;
            }
        }
        public override string ToString()
        {
            string Completed = "I";
            if (IsCompleted)
                Completed = "C";
            return $"[{Priority}] {Completed} | {Title} - {Description} - {DeadlineDisplay}";
        }

    }
}
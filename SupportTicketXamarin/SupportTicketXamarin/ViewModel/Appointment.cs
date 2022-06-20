using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportTicketXamarin.ViewModel
{
    public class Appointment : Item, INotifyPropertyChanged
    {
        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }
        private DateTime end;
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }
        private string people;
        public string People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
            }
        }

        private List<string> attendees;
        public List<string> Attendees
        {
            get
            {
                return attendees;
            }
            set
            {
                attendees = people.Split(' ').ToList(); 
            }
        }

        public override string ToString()
        {
            return $"[{Priority}] {Title} | {People} {Start}-{End}";
        }
    }
}
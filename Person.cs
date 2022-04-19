using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    public class Person : INotifyPropertyChanged
    {
        private string firstname;  //required
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("Name"); }
        }
        private string lastname; //required
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("Name"); }
        }
        private string? email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Name"); }
        }
        public double? price { get; set; }
        public string? region { get; set; }
        public int? access { get; set; }
        private bool adding;

        public string Name
        {
            get
            {
                return DisplayName();
            }
        }

        public Person() { }
        public Person(bool x) 
        {
            x = true;
            adding = x;
        }
        public Person(string name, string lname) 
        {
            this.firstname = name;
            this.lastname = lname;
        }

        public Person(string name, string lname, string email, double price, string region, int access)
        {
            this.firstname = name;
            this.lastname = lname;
            this.email = email;
            this.price = price;
            this.region = region;
            this.access = access;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string DisplayName()
        {
            if (adding)
                return "Dodaj nową osobę...";
            else if (String.IsNullOrEmpty(Email))
                return Firstname + " " + Lastname;
            return Firstname + " " + Lastname + " (" + Email + ") ";
        }


    }
}

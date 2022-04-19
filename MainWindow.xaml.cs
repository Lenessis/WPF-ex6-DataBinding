using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zad6
{
    public partial class MainWindow : Window
    {
        // -- Lista regionów (ComboBox) oraz lista osób (ListBox)
        public string[] Regions = 
        { 
            "Białystok",
            "Gdańsk",
            "Gdynia",
            "Kraków",
            "Sopot",
            "Szczecin",
            "Warszawa",
            "Wrocław" 
        };
        public Collection<Person> people { get; } = new ObservableCollection<Person>();

        Person add = new Person(true);       

        public MainWindow()
        {
            InitializeComponent();
            /*people.Add(new Person("Jan", "Kowalski"));
            people.Add(new Person("Kazimierz", "Kowalski", "kk@op.pl", 3.14, "Warszawa", 1));*/
            people.Add(add);
        }

        // -- Ładowanie okna - ładowanie regionów

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            PersonList.ItemsSource = people;
            Region.ItemsSource = Regions;
        }

        // -- Dodawanie nowej osoby

        private void ChangePerson(object sender, SelectionChangedEventArgs e)
        {
            if ((Person)PersonList.SelectedItem == add)
            {

                people.Insert(people.Count - 1, new Person("Imie", "Nazwisko"));
                PersonList.SelectedIndex = people.Count - 2;
            }

            if(PersonList.SelectedIndex != -1)
            {
                FirstName.IsEnabled = true;
                LastName.IsEnabled = true;
                DataDetails.IsEnabled = true;
            }

        }

        // Dane szczegółowe - obsługa checkBoxa 

        private void DataDetailsChecked(object sender, RoutedEventArgs e)
        {            
            try
            {
                Email.IsEnabled = true;
                Price.IsEnabled = true;
                Price.IsEnabled = true;
                Region.IsEnabled = true;
                Access.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd przy odblokowaniu pól.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataDetailsUnchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Email.IsEnabled = false;
                Price.IsEnabled = false;
                Price.IsEnabled = false;
                Region.IsEnabled = false;
                Access.IsEnabled = false;
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd przy zadblokowaniu pól.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // -- Usuwanie osoby

        private void RemovePersonButton(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning,MessageBoxResult.No) ==  MessageBoxResult.Yes)
            {
                people.RemoveAt(PersonList.SelectedIndex);
            }
        }

        private void CheckFirstNameContent(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(FirstName.Text))
            {
                //PersonList.SelectedIndex = index;
                
                MessageBox.Show("Pole \"Imię\" nie może być puste!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
               
               // FirstName.Focus();
            }
        }

        private void CheckLastNameContent(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(LastName.Text))
            {               
                MessageBox.Show("Pole \"Nazwisko\" nie może być puste!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
               // LastName.Focus();
            }
        }
    }
}

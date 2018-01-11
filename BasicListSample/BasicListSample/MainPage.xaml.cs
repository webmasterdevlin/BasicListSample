using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BasicListSample
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            MyListView.ItemsSource = GetList();
        }

        private static IEnumerable<Person> GetList(string searchText = null)
        {
            var contacts = new List<Person>()
            {
                new Person{Name = "Donald", Detail = "Online", Image = "https://placeimg.com/100/100/people/2"},
                new Person{Name = "Devlin", Detail = "Online", Image = "https://placeimg.com/100/100/people/3"},
                new Person{Name = "Ruby", Detail = "Offline", Image = "https://placeimg.com/100/100/people/1"},
                new Person{Name = "Rhea", Detail = "Online", Image = "https://placeimg.com/100/100/people/4"},
                new Person{Name = "Rhea", Detail = "Offline", Image = "https://placeimg.com/100/100/people/6"},
                new Person{Name = "Rhea", Detail = "Offline", Image = "https://placeimg.com/100/100/people/8"},
                new Person{Name = "Rhea", Detail = "Online", Image = "https://placeimg.com/100/100/people/7"},
                new Person{Name = "Rhea", Detail = "Offline", Image = "https://placeimg.com/100/100/people/9"},
                new Person{Name = "Rhea", Detail = "Online", Image = "https://placeimg.com/100/100/people/5"},
            };

            return string.IsNullOrEmpty(searchText) ? contacts : contacts.Where(c => c.Name.StartsWith(searchText));
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Person contact) DisplayAlert("Tapped", contact.Name, "Ok", "Cancel");

            //            var contact = e.Item as Person;
            //            DisplayAlert("Tapped", contact.Name, "Ok", "Cancel");
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MyListView.SelectedItem = null;
            //            var contact = e.SelectedItem as Person;
            //            DisplayAlert("Selected", contact.Name, "Ok");
        }

        private void ListView_OnRefreshing(object sender, EventArgs e)
        {
            MyListView.ItemsSource = GetList();
            MyListView.EndRefresh();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            MyListView.ItemsSource = GetList(e.NewTextValue);
        }
    }
}
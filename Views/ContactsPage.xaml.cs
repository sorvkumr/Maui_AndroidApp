using Maui_1_Application.Repository;
using System.Collections.ObjectModel;
using Contact = Maui_1_Application.Models.Contact;

namespace Maui_1_Application.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var contact = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contact;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
        //DisplayAlert("Text", "Check the alert message", "OK");
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}
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
        Search_Bar.Text = string.Empty;
        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void MenuItem_ClickDelete(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        ContactRepository.DeleteContact(contact.ContactId);
        LoadContacts();
    }

    public void LoadContacts()
    {
        var contact = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contact;
    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContracts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanges(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContracts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }
}
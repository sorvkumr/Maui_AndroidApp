using Maui_1_Application.Repository;
using Contact = Maui_1_Application.Models.Contact;

namespace Maui_1_Application.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    public string ContactId
    {
        set
        {
            contact = ContactRepository.GetContactById(int.Parse(value));
            if (contact != null)
            {
                entryName.Text = contact.Name;
                entryPhone.Text = contact.Phone;
                entryEmail.Text = contact.Email;
                entryAddress.Text = contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsValid)
        {
            contact.Name = entryName.Text;
            contact.Phone = entryPhone.Text;
            contact.Email = entryEmail.Text;
            contact.Address = entryAddress.Text;
            ContactRepository.UpdateContact(contact.ContactId, contact);
            Shell.Current.GoToAsync("..");
        }
        else
        {
            DisplayAlert("Error", "Name is required.", "OK");
        }
    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
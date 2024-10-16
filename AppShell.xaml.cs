using Maui_1_Application.Views;

namespace Maui_1_Application;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Routing Page
        Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
        Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
    }
}

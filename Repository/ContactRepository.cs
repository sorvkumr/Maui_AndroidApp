﻿using Contact = Maui_1_Application.Models.Contact;

namespace Maui_1_Application.Repository;
public class ContactRepository
{
    public static List<Contact> _contacts = new(){
            new Contact{ContactId=1, Name="John Doe", Email="JohnDoe@gmail.com", Phone="9685714526", Address="Punjab"},
            new Contact{ContactId=2 ,Name="John Fin", Email="JohnFin@gmail.com", Phone="9988774455", Address="CHD"},
            new Contact{ContactId=3, Name="Jane Finks", Email="JaneHanks@gmail.com",Phone="6352417485", Address="Ambala"},
            new Contact{ContactId=4 ,Name="Frank Liu", Email="FrankLiu@gmail.com",Phone="6655447788",Address="Una"},
        };

    public static List<Contact> GetContacts() => _contacts;
    public static Contact GetContactById(int contactId)
    {
        return _contacts.FirstOrDefault(x => x.ContactId == contactId);
    }

    public static void UpdateContact(int contactId, Contact contact)
    {
        if (contactId != contact.ContactId)
            return;
        var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
        if (contactToUpdate != null)
        {
            contactToUpdate.Address = contact.Address;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Name = contact.Name;
        }

    }
}

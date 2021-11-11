using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contact_List
{
    public class SaveIntoAndLoadFromDatabase
    {
        public void InsertDataIntoDatabase(Guid contactID, Genders gender, string title, string firstName, string lastName, string address, string addressComplement,
                                           int postalCode, string city, string region, string country, string email, string phoneNumber, string message)
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {
                // Create new object/row 
                var contact = new ContactList()
                {
                    // Assign the entered values to the corresponding columns
                    ContactID = contactID,
                    Gender = gender.ToString(),
                    Title = title,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    AddressComplement = addressComplement,
                    PostalCode = postalCode,
                    City = city,
                    Region = region,
                    Country = country,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Message = message
                };

                databaseContext.ContactList.Add(contact);
                
                try
                {
                    databaseContext.SaveChanges();
                }
                catch (EntityDataSourceValidationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        public void UpdateDataInDatabase(Guid contactID, Genders gender, string title, string firstName, string lastName, string address, string addressComplement,
                                         int postalCode, string city, string region, string country, string email, string phoneNumber, string message)
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {
                // Get the selected entry in the database
                var contact = databaseContext.ContactList.Find(contactID);

                // Change the columns of the respective row - ContactID must NOT be changed!
                contact.Gender = gender.ToString();
                contact.Title = title;
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.Address = address;
                contact.AddressComplement = addressComplement;
                contact.PostalCode = postalCode;
                contact.City = city;
                contact.Region = region;
                contact.Country = country;
                contact.Email = email;
                contact.PhoneNumber = phoneNumber;
                contact.Message = message;

                try
                {
                    databaseContext.SaveChanges();
                }
                catch (EntityDataSourceValidationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        public ICollection<ContactList> LoadDataFromDatabase()
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {
                // Load ALL datasets from the database
                var contact = databaseContext.ContactList.ToList();

                return contact;
            }
        }
    }
}
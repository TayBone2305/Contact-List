using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contact_List
{
    public class DatabaseCRUD
    {
        public static void InsertDataIntoDatabase(Guid contactID, Genders gender, string title, string firstName, string lastName, 
                                                  string address, string addressComplement, int postalCode, string city, string region, 
                                                  string country, string email, string phoneNumber, string message)
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {        
                // Create new object/row 
                var newContactInDT = new ContactList()
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

                databaseContext.ContactList.Add(newContactInDT);
                
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

        public static void UpdateDataInDatabase(Guid contactID, Genders gender, string title, string firstName, string lastName, 
                                                string address, string addressComplement, int postalCode, string city, string region, 
                                                string country, string email, string phoneNumber, string message)
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {
                // Get the selected entry in the database
                var newContactInDT = databaseContext.ContactList.Find(contactID);

                // Change the columns of the respective row - ContactID must NOT be changed!
                newContactInDT.Gender = gender.ToString();
                newContactInDT.Title = title;
                newContactInDT.FirstName = firstName;
                newContactInDT.LastName = lastName;
                newContactInDT.Address = address;
                newContactInDT.AddressComplement = addressComplement;
                newContactInDT.PostalCode = postalCode;
                newContactInDT.City = city;
                newContactInDT.Region = region;
                newContactInDT.Country = country;
                newContactInDT.Email = email;
                newContactInDT.PhoneNumber = phoneNumber;
                newContactInDT.Message = message;

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

        public static ICollection<ContactList> LoadDataFromDatabase()
        {
            using (var databaseContext = new tayfun_ContactListEntities())
            {
                try
                {
                    // Load ALL datasets from the database
                    var newContactInDT = databaseContext.ContactList.ToList();

                    return newContactInDT;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }

                return null;
            }
        }
    }
}
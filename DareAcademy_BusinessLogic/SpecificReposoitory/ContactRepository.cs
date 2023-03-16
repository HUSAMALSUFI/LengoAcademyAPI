using DareAcademy_DataAccess.Context;
using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using DareAcademy_DataAccess.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class ContactRepository : IContactRepository
    {
        private readonly IGeneric<Contact> generic;

        public ContactRepository(IGeneric<Contact> _generic)
        {
            generic = _generic;
        }
        public async Task<int> Insert(ContactDTO contactDTO)
        {
            var newContact = new Contact()
            {
                Email = contactDTO.Email,
                Address = contactDTO.Address,
                Phone = contactDTO.Phone,
                LogoPath=contactDTO.LogoPath,
                FavIconPath=contactDTO.FavIconPath,
            };
            return await generic.Insert(newContact);
        }
        public async Task<List<ContactDTO>> LoadAll()
        {
            var contacts = new List<ContactDTO>();
            var allcontact = await generic.LoadAll();
            if (allcontact?.Any() == true)
            {
                foreach (var contact in allcontact)
                {
                    contacts.Add(new ContactDTO()
                    {
                        Id = contact.Id,
                        Email = contact.Email,
                        Address = contact.Address,
                        Phone = contact.Phone,
                        LogoPath=contact.LogoPath,
                        FavIconPath=contact.FavIconPath,
                    });
                }
            }
            return contacts;
        }
        public async Task<ContactDTO> Load(int Id)
        {
            var contacts = await generic.Load(Id);
            if (contacts != null)
            {
                var contactsDetails = new ContactDTO()
                {
                    Email = contacts.Email,
                    Address = contacts.Address,
                    Phone = contacts.Phone,
                    LogoPath = contacts.LogoPath,
                    FavIconPath = contacts.FavIconPath,
                };
                return contactsDetails;
            }
            return null;
        }
        public async Task Update(ContactDTO contactDTO)
        {
            var newContact = new Contact()
            {
                Id = contactDTO.Id,
                Email = contactDTO.Email,
                Address = contactDTO.Address,
                Phone = contactDTO.Phone,
                LogoPath = contactDTO.LogoPath,
                FavIconPath = contactDTO.FavIconPath,
            };
            await generic.Update(newContact);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
    }
}
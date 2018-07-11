using ContactInfoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : Defined test models with accessible test methods
 * **/

namespace ContactInfoProject.Tests.Models
{
    class InMemoryContactRepository : IContactRepository
    {
        private List<tbl_contact> _db = new List<tbl_contact>();
        public Exception ExceptionToThrow { get; set; }

        /// <summary>
        /// Get all contact information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_contact> GetAllContact()
        {
            return _db.ToList();
        }

        /// <summary>
        /// Get contact details by Id
        /// </summary>
        /// <param name="id">Pass ID</param>
        /// <returns></returns>
        public tbl_contact GetContactByID(int id)
        {
            return _db.FirstOrDefault(d => d.Id == id);
        }

        /// <summary>
        /// Add contact information
        /// </summary>
        /// <param name="contactToCreate"></param>
        public void InsertContact(tbl_contact contactToCreate)
        {
            _db.Add(contactToCreate);
        }

        /// <summary>
        /// Delete contact information
        /// </summary>
        /// <param name="id"></param>
        public void DeleteContact(int id)
        {
            _db.Remove(GetContactByID(id));
        }

        /// <summary>
        /// Update contact information
        /// </summary>
        /// <param name="tbl_Contact"></param>
        public void UpdateContact(tbl_contact tbl_Contact)
        {
            foreach (tbl_contact contact in _db)
            {
                if (contact.Id == tbl_Contact.Id)
                {
                    _db.Remove(contact);
                    _db.Add(tbl_Contact);
                    break;
                }
            }
        }

        /// <summary>
        /// Save contact information
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return 1;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Dispose Object Here
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

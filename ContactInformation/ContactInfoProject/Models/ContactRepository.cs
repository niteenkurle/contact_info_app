using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : Defined models with accessible methods
 * **/

namespace ContactInfoProject.Models
{
    public class ContactRepository : IContactRepository, IDisposable
    {
        //instance of entities
        ContactInfoEntities context = new ContactInfoEntities();

        /// <summary>
        /// Get all contact information
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tbl_contact> GetAllContact()
        {
            return context.tbl_contact.ToList();
        }

        /// <summary>
        /// Gete contact details by passing Id
        /// </summary>
        /// <param name="id">Pass Id</param>
        /// <returns></returns>
        public tbl_contact GetContactByID(int id)
        {
            return context.tbl_contact.Find(id);
        }

        /// <summary>
        /// Add contact information
        /// </summary>
        /// <param name="emp"></param>
        public void InsertContact(tbl_contact emp)
        {
            context.tbl_contact.Add(emp);
        }

        /// <summary>
        /// Delete contact information
        /// </summary>
        /// <param name="emp_ID"></param>
        public void DeleteContact(int emp_ID)
        {
            tbl_contact emp = context.tbl_contact.Find(emp_ID);
            context.tbl_contact.Remove(emp);
        }

        /// <summary>
        /// Update contact information
        /// </summary>
        /// <param name="emp"></param>
        public void UpdateContact(tbl_contact emp)
        {
            context.Entry(emp).State = EntityState.Modified;
        }

        /// <summary>
        /// Save contact information
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// Dispose objects
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
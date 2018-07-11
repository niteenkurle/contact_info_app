using System;
using System.Collections.Generic;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : IContactInterface with signature
 * **/

/// <summary>
/// Interfaces
/// </summary>
namespace ContactInfoProject.Models
{
    /// <summary>
    /// Contact interface
    /// </summary>
    public interface IContactRepository : IDisposable
    {
        IEnumerable<tbl_contact> GetAllContact();
        tbl_contact GetContactByID(int contact_ID);
        void InsertContact(tbl_contact contact);
        void DeleteContact(int contact_ID);
        void UpdateContact(tbl_contact contact);
        int Save();
    }
}
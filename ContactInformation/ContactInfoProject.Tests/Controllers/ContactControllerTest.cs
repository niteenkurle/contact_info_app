using ContactInfoProject.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ContactInfoProject.Models;
using System.Web.Routing;
using ContactInfoProject.Tests.Models;
using System.Collections.Generic;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : Test Contact controller with TestClass & TestMethods
 * **/

namespace ContactInfoProject.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {
        /// <summary>
        /// Check Index View
        /// </summary>
        [TestMethod]
        public void Test_To_Load_Index_View()
        {
            var contactcontroller = GetContactController(new InMemoryContactRepository());

            ViewResult result = contactcontroller.Index();
            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        /// <summary>
        /// This method used to get contact controller
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        private static ContactController GetContactController(IContactRepository emprepository)
        {
            ContactController empcontroller = new ContactController(emprepository);
            empcontroller.ControllerContext = new ControllerContext()
            {
                Controller = empcontroller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return empcontroller;
        }

        /// <summary>
        ///  This method used to get all Contact listing
        /// </summary>
        [TestMethod]
        public void Test_To_Get_All_Contact_From_Repository()
        {
            // Arrange
            tbl_contact contact1 = GetContactName(1, "John", "Doe", "john.doe@gmmail.com", "987654321", true);
            tbl_contact contact2 = GetContactName(2, "John1", "Doe1", "john1.doe@gmmail.com", "987654312", true);
            InMemoryContactRepository inMemoryContactRepository = new InMemoryContactRepository();
            inMemoryContactRepository.InsertContact(contact1);
            inMemoryContactRepository.InsertContact(contact2);
            var controller = GetContactController(inMemoryContactRepository);
            var result = controller.Index();
            var datamodel = (List<tbl_contact>)result.ViewData.Model;
            CollectionAssert.Contains(datamodel.ToArray(), contact1);
            CollectionAssert.Contains(datamodel.ToArray(), contact2);
        }


        /// <summary>
        /// This method used to get contact
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Status"></param>       
        /// <returns></returns>
        tbl_contact GetContactName(int ID, string FirstName, string LastName, string Email, string PhoneNumber, bool Status)
        {
            return new tbl_contact
            {
                Id = ID,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Status = Status
            };
        }

        /// <summary>
        /// This test method used to post contact
        /// </summary>
        [TestMethod]
        public void Test_To_Create_Post_Contact_Repository()
        {
            InMemoryContactRepository contactrepository = new InMemoryContactRepository();
            ContactController contactcontroller = GetContactController(contactrepository);
            tbl_contact contact = GetContactID();
            contactcontroller.Create(contact);
            IEnumerable<tbl_contact> contactList = contactrepository.GetAllContact();
            //Assert.IsTrue(contactList.Contains(contact));
        }

        /// <summary>
        /// Get contact information
        /// </summary>
        /// <returns></returns>
        tbl_contact GetContactID()
        {
            return GetContactName(1, "John", "Doe", "john.doe@gmmail.com", "987654321", true);
        }


    }
}

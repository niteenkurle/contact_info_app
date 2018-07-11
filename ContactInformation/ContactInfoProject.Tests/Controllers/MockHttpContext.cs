using System.Security.Principal;
using System.Web;

/***
 * Created Date : 10-Jul-2018
 * Created by   : Nitin Kurle
 * Information  : Create read only identity Mock class
 * **/

namespace ContactInfoProject.Tests.Controllers
{
    internal class MockHttpContext : HttpContextBase
    {
        //Create read only identity user
        private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

        public override IPrincipal User
        {
            get
            {
                return _user;
            }
            set
            {
                base.User = value;
            }
        }
    }
}
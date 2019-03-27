using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Domain.Exceptions;
using Heimdall.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Heimdall.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void VALID_EMAIL()
        {
            /*
             * This is a reverse test, 
             * so knowing that a weak capacity is
             * generating a Domain Exception
             * */

            try
            {
                var user = new FatUser("marcos", "MySecurityPassword$1234", "1", "invalidemail", "Street X, District Y, Country Z", "55555");

                //Oh no, a validation flaw :(
                Assert.IsTrue(false);
            }
            catch (DomainException ex)
            {
                //YEA! validation in operation!
                Assert.IsTrue(true, ex.Message);
            }
        }

        [TestMethod]
        public void MEDIUM_LEVEL_SECURITY_PASSWORD()
        {
            /*
             * This is a reverse test, 
             * so knowing that a weak capacity is
             * generating a Weak Exception Password
             * */

            HeimdallConfiguration.Instance.SetPasswordSecurityLevel(UserPasswordSecurityLevel.MEDIUM);
            string notValidPassword = "weakPassword123"; //proposital weak password

            try
            {
                var user = new ThinUser("marcos", notValidPassword, "1");

                //Oh no, a security flaw :(
                Assert.IsTrue(false);
            }
            catch (WeakPasswordException ex)
            {
                //YEA! Safety in operation!
                Assert.IsTrue(true, ex.Message);
            }
        }

        [TestMethod]
        public void HIGHT_LEVEL_SECURITY_PASSWORD()
        {
            /*
             * This is a reverse test, 
             * so knowing that a weak capacity is
             * generating a Weak Exception Password
             * */

            HeimdallConfiguration.Instance.SetPasswordSecurityLevel(UserPasswordSecurityLevel.HIGHT);
            string notValidPassword = "weakPassword12$%ha.ha"; //proposital weak password

            try
            {
                var user = new ThinUser("marcos", notValidPassword, "1");

                //Oh no, a security flaw :(
                Assert.IsTrue(false);
            }
            catch (WeakPasswordException ex)
            {
                //YEA! Safety in operation!
                Assert.IsTrue(true, ex.Message);
            }
        }
    }
}

using Heimdall.Domain;
using Heimdall.Domain.Configurations;
using Heimdall.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Heimdall.Tests
{
    [TestClass]
    public class OrganizationTest
    {
        private void Configure()
        {
            HeimdallConfiguration.Instance.Database.UseSQLServer("localhost", "sa", "81547686", "Heimdall");
            HeimdallConfiguration.Instance.EncryptService.SetPassword("MySecurePa$$word@123456.C#");
        }

        private List<Organization> MockList
        {
            get
            {
                return new List<Organization>()
                {
                    new Organization("1", "ABC Informática", "(24) 3345-8971", "Av. Antonio de Almeida, N° 325, Retiro, Volta Redonda - RJ"),
                    new Organization("2", "Mr. Shake", "(24) 3312-3247", "Av. Antonio de Almeida, N° 1005, Retiro, Volta Redonda - RJ"),
                    new Organization("3", "Hortifruti Bom Preço", "(24) 3378-9458", "Av. Antonio de Almeida, N° 985, Retiro, Volta Redonda - RJ")
                };
            }
        }

        [TestMethod]
        public void CHANGE_ORGANIZATION()
        {
            OrganizationService service = null;
            try
            {
                Configure();
                service = new OrganizationService();
                service.Register(MockList[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            try
            {
                service = new OrganizationService();
                var org = MockList[0];
                org.SetName("Organization Name Changed");
                service.Change(org);
            }
            catch (Exception ex)
            {
                service.Remove(MockList[0]);
                Assert.Fail(ex.Message);
            }

            var organization = service.FindById("1");
            service.Remove(MockList[0]);
            Assert.AreEqual(organization.Name, "Organization Name Changed");
        }

        [TestMethod]
        public void DELETE_ORGANIZATION()
        {
            OrganizationService service = null;
            try
            {
                Configure();
                service = new OrganizationService();
                service.Register(MockList[0]);
            }
            catch (Exception ex)
            {
                service.Remove(MockList[0]);
                Assert.Fail(ex.Message);
            }

            service.Remove(MockList[0]);
            var organization = service.FindById("1");
            Assert.IsNull(organization);
        }

        [TestMethod]
        public void SEARCH_ORGANIZATION()
        {
            OrganizationService service = null;
            try
            {
                Configure();
                service = new OrganizationService();
                foreach (var orgMock in MockList)
                    service.Register(orgMock);
            }
            catch (Exception ex)
            {
                foreach (var orgMock in MockList)
                    service.Remove(orgMock);
                Assert.Fail(ex.Message);
            }

            try
            {
                List<Organization> organizations = service.Search("ABC");
                Assert.IsTrue(organizations.Count > 0);
                Assert.IsTrue(organizations[0].Name.Contains("ABC"));
            }
            catch (Exception ex)
            {
                foreach (var orgMock in MockList)
                    service.Remove(orgMock);
                Assert.Fail(ex.Message);
            }

            foreach (var orgMock in MockList)
                service.Remove(orgMock);
        }

        [TestMethod]
        public void CREATE_ORGANIZATION()
        {
            OrganizationService service = null;
            try
            {
                Configure();
                service = new OrganizationService();
                service.Register(MockList[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            var organization = service.FindById("1");
            service.Remove(organization);
            Assert.IsNotNull(organization);
        }
    }
}

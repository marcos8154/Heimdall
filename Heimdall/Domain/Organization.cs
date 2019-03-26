using Heimdall.Domain.Validation;

namespace Heimdall.Domain
{
    public class Organization
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string Phone { get; internal set; }
        public string Address { get; internal set; }

        internal Organization()
        {

        }

        public void SetName(string name)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(name, "Organization name can not be null");
            Name = name;
        }

        public void SetPhone(string phone)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(phone, "Organization phone can not be null");
            Phone = phone;
        }

        public void SetAddress(string address)
        {
            AssertionConcern.AssertArgumentNotNullOrEmpty(address, "Organization address can not be null");
            Address = address;
        }

        public Organization(string id, string name, string phone, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;

            AssertionConcern.AssertArgumentNotNullOrEmpty(id, "Organization id can not be null");
            AssertionConcern.AssertArgumentNotNullOrEmpty(name, "Organization name can not be null");
            AssertionConcern.AssertArgumentNotNullOrEmpty(phone, "Organization phone can not be null");
            AssertionConcern.AssertArgumentNotNullOrEmpty(address, "Organization address can not be null");
        }
    }
}

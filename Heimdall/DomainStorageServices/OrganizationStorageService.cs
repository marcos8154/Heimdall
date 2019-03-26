using Heimdall.Domain;
using Heimdall.DomainStorageServices.Contracts;
using System.Collections.Generic;

namespace Heimdall.DomainStorageServices
{
    internal class OrganizationStorageService : StorageServiceBase, IOrganizationStorageService
    {
        public OrganizationStorageService()
        {
            SetTableName("Organization");
        }

        public void Change(Organization organization)
        {
            string sql = @"update Organization set 
Name = @name,
Phone = @phone,
Address = @address
where Id = @id
";

            ConnectionFactory.OpenConnection();
            ConnectionFactory.CreateCommand(sql);
            ConnectionFactory.AddParameter("@id", organization.Id);
            ConnectionFactory.AddParameter("@name", organization.Name);
            ConnectionFactory.AddParameter("@phone", organization.Phone);
            ConnectionFactory.AddParameter("@address", organization.Address);
            ConnectionFactory.ExecuteCommand();
            ConnectionFactory.CloseConnection();
        }

        public Organization GetById(string id)
        {
            string sql = "select * from Organization where Id = @id";
            ConnectionFactory.OpenConnection();
            ConnectionFactory.CreateCommand(sql);
            ConnectionFactory.AddParameter("@id", id);
            var dr = ConnectionFactory.ExecuteReader();

            Organization result = null;

            if (dr.Read())
            {
                result = new Organization(
                    id: dr.GetString(0),
                    name: dr.GetString(1),
                    phone: dr.GetString(2),
                    address: dr.GetString(3));
            }

            dr.Close();
            ConnectionFactory.CloseConnection();

            return result;
        }

        public void Register(Organization organization)
        {
            string sql = @"insert into Organization 
(Id, Name, Phone, Address) 
values 
(@id, @name, @phone, @address)";

            ConnectionFactory.OpenConnection();
            ConnectionFactory.CreateCommand(sql);
            ConnectionFactory.AddParameter("@id", organization.Id);
            ConnectionFactory.AddParameter("@name", organization.Name);
            ConnectionFactory.AddParameter("@phone", organization.Phone);
            ConnectionFactory.AddParameter("@address", organization.Address);
            ConnectionFactory.ExecuteCommand();
            ConnectionFactory.CloseConnection();
        }

        public void Remove(Organization organization)
        {
            string sql = "delete from Organization where Id = @id";
            ConnectionFactory.OpenConnection();
            ConnectionFactory.CreateCommand(sql);
            ConnectionFactory.AddParameter("@id", organization.Id);
            ConnectionFactory.ExecuteCommand();
            ConnectionFactory.CloseConnection();
        }

        public List<Organization> Search(string name)
        {
            string sql = "select * from Organization where Name like @name";
            ConnectionFactory.OpenConnection();
            ConnectionFactory.CreateCommand(sql);
            ConnectionFactory.AddParameter("@name", $"%{name}%");
            var dr = ConnectionFactory.ExecuteReader();

            List<Organization> result = new List<Organization>();
            while (dr.Read())
            {
                result.Add(new Organization(
                    id: dr.GetString(0),
                    name: dr.GetString(1),
                    phone: dr.GetString(2),
                    address: dr.GetString(3)));
            }

            dr.Close();
            ConnectionFactory.CloseConnection();

            return result;
        }

        protected internal override string GetTableCreationScript()
        {
            return @"
create table Organization
(
    Id varchar (10) not null,
    Name varchar(50) not null,
    Phone varchar(15) not null,
    Address varchar(100) not null,

    primary key(Id)
)
";
        }
    }
}

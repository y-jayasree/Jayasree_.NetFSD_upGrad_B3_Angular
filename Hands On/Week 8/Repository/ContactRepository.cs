using System.Collections.Generic;
using System.Linq;
using Dapper;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;
        public ContactRepository(DapperContext context) => _context = context;

        public List<ContactInfo> GetAllContacts()
        {
            var sql = @"SELECT c.*, co.CompanyName, d.DepartmentName
                        FROM ContactInfo c
                        JOIN Company co ON c.CompanyId = co.CompanyId
                        JOIN Department d ON c.DepartmentId = d.DepartmentId";
            using var conn = _context.CreateConnection();
            return conn.Query<ContactInfo>(sql).ToList();
        }

        public ContactInfo GetContactById(int id)
        {
            var sql = @"SELECT c.*, co.CompanyName, d.DepartmentName
                        FROM ContactInfo c
                        JOIN Company co ON c.CompanyId = co.CompanyId
                        JOIN Department d ON c.DepartmentId = d.DepartmentId
                        WHERE c.ContactId=@ContactId";
            using var conn = _context.CreateConnection();
            return conn.QueryFirstOrDefault<ContactInfo>(sql, new { ContactId = id });
        }

        public void AddContact(ContactInfo contact)
        {
            var sql = @"INSERT INTO ContactInfo 
                        (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                        VALUES 
                        (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";
            using var conn = _context.CreateConnection();
            conn.Execute(sql, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            var sql = @"UPDATE ContactInfo SET
                        FirstName=@FirstName, LastName=@LastName, EmailId=@EmailId,
                        MobileNo=@MobileNo, Designation=@Designation,
                        CompanyId=@CompanyId, DepartmentId=@DepartmentId
                        WHERE ContactId=@ContactId";
            using var conn = _context.CreateConnection();
            conn.Execute(sql, contact);
        }

        public void DeleteContact(int id)
        {
            var sql = "DELETE FROM ContactInfo WHERE ContactId=@ContactId";
            using var conn = _context.CreateConnection();
            conn.Execute(sql, new { ContactId = id });
        }

        public List<Company> GetAllCompanies()
        {
            using var conn = _context.CreateConnection();
            return conn.Query<Company>("SELECT * FROM Company").ToList();
        }

        public List<Department> GetAllDepartments()
        {
            using var conn = _context.CreateConnection();
            return conn.Query<Department>("SELECT * FROM Department").ToList();
        }
    }
}

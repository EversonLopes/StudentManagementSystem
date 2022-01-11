using System;


namespace StudentManagementSystem.Services.Exceptions
{
    public class DbConcurrencyException:ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        {
        }
    }
}

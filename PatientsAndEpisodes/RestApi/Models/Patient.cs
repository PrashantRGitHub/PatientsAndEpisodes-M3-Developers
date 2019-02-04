using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public class Patient : IDBEntity
    {
        public int PatientId { get; set; }

        public string NhsNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
    }

    public interface IDBEntity
    {
        int PatientId { get; }
    }
}
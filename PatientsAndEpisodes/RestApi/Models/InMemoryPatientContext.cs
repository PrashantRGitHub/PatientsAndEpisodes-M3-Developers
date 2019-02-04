using System;
using System.Data.Entity;
using RestApi.Interfaces;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestApi.Models
{
    public class InMemoryPatientContext : IDatabaseContext
    {
        public Guid Whatever = Guid.NewGuid();

        private readonly InMemoryDbSet<Patient> _patients = new InMemoryDbSet<Patient>();
        private readonly InMemoryDbSet<Episode> _episodes = new InMemoryDbSet<Episode>();

        public IDbSet<Patient> Patients
        {
            get { return _patients; }
        }

        public IDbSet<Episode> Episodes
        {
            get { return _episodes; }
        }

      

    }
}
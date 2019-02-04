using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public class PatientInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<PatientContext>
    {
        protected override void Seed(PatientContext context)
        {
            var patients = new List<Patient>
                {
                    new Patient
                        {
                            DateOfBirth = new DateTime(1972, 10, 27),
                            FirstName = "Millicent",
                            PatientId = 1,
                            LastName = "Hammond",
                            NhsNumber = "1111111111"
                        },
                    new Patient
                        {
                            DateOfBirth = new DateTime(1987, 2, 14),
                            FirstName = "Bobby",
                            PatientId = 2,
                            LastName = "Atkins",
                            NhsNumber = "2222222222"
                        },
                    new Patient
                        {
                            DateOfBirth = new DateTime(1991, 12, 4),
                            FirstName = "Xanthe",
                            PatientId = 3,
                            LastName = "Camembert",
                            NhsNumber = "3333333333"
                        }
                };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();
            var episodes = new List<Episode>
                {
                    new Episode
                        {
                            AdmissionDate = new DateTime(2014, 11, 12),
                            Diagnosis = "Irritation of inner ear",
                            DischargeDate = new DateTime(2014, 11, 27),
                            EpisodeId = 1,
                            PatientId = 1
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 3, 20),
                            Diagnosis = "Sprained wrist",
                            DischargeDate = new DateTime(2015, 4, 2),
                            EpisodeId = 2,
                            PatientId = 1
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 11, 12),
                            Diagnosis = "Stomach cramps",
                            DischargeDate = new DateTime(2015, 11, 14),
                            EpisodeId = 3,
                            PatientId = 1
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 4, 18),
                            Diagnosis = "Laryngitis",
                            DischargeDate = new DateTime(2015, 5, 26),
                            EpisodeId = 4,
                            PatientId = 2
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 6, 2),
                            Diagnosis = "Athlete's foot",
                            DischargeDate = new DateTime(2015, 6, 13),
                            EpisodeId = 5,
                            PatientId = 2
                        }
                };
            episodes.ForEach(s => context.Episodes.Add(s));
            context.SaveChanges();
        }
    }
}
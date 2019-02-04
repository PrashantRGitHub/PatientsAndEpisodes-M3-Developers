//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApi.Controllers;
using RestApi.Interfaces;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using System.Net;

namespace RestApi.UnitTests
{
    [TestClass]
    public class GetPatientTests
    {
        private readonly IDatabaseContext _dbContext;
        private readonly List<Patient> _patients;
        private readonly List<Episode> _episodes;

        public GetPatientTests()
        {
            _dbContext = new InMemoryPatientContext();
            _patients = new List<Patient>();
            _episodes = new List<Episode>();
        }

        [TestInitialize]
        public void InitializeContext()
        {

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
                };

            _patients.Add(new Patient
            {
                DateOfBirth = new DateTime(1972, 10, 27),
                FirstName = "Millicent",
                PatientId = 1,
                LastName = "Hammond",
                NhsNumber = "1111111111",
                Episodes = episodes,
            });



            _patients.Add(new Patient
            {
                DateOfBirth = new DateTime(1987, 2, 14),
                FirstName = "Bobby",
                PatientId = 2,
                LastName = "Atkins",
                NhsNumber = "2222222222"
            });

            _patients.Add(new Patient
            {
                DateOfBirth = new DateTime(1991, 12, 4),
                FirstName = "Xanthe",
                PatientId = 3,
                LastName = "Camembert",
                NhsNumber = "3333333333",
            });

            _patients.ForEach(s => _dbContext.Patients.Add(s));

            _episodes.Add(new Episode
            {
                AdmissionDate = new DateTime(2014, 11, 12),
                Diagnosis = "Irritation of inner ear",
                DischargeDate = new DateTime(2014, 11, 27),
                EpisodeId = 1,
                PatientId = 1
            });

            _episodes.Add(new Episode
            {
                AdmissionDate = new DateTime(2015, 3, 20),
                Diagnosis = "Sprained wrist",
                DischargeDate = new DateTime(2015, 4, 2),
                EpisodeId = 2,
                PatientId = 1
            });
            _episodes.Add(new Episode
            {
                AdmissionDate = new DateTime(2015, 11, 12),
                Diagnosis = "Stomach cramps",
                DischargeDate = new DateTime(2015, 11, 14),
                EpisodeId = 3,
                PatientId = 1
            });
            _episodes.Add(new Episode
            {
                AdmissionDate = new DateTime(2015, 4, 18),
                Diagnosis = "Laryngitis",
                DischargeDate = new DateTime(2015, 5, 26),
                EpisodeId = 4,
                PatientId = 2
            });
            _episodes.Add(new Episode
            {
                AdmissionDate = new DateTime(2015, 6, 2),
                Diagnosis = "Athlete's foot",
                DischargeDate = new DateTime(2015, 6, 13),
                EpisodeId = 5,
                PatientId = 2
            });

            _episodes.ForEach(s => _dbContext.Episodes.Add(s));

        }

        [TestCleanup]
        public void ClearContext()
        {
            _episodes.ForEach(s => _dbContext.Episodes.Remove(s));
            _patients.ForEach(s => _dbContext.Patients.Remove(s));
        }

        [TestMethod]
        public void PatientFoundWithId()
        {

            // Get Controller 
            var controller = new PatientsController(_dbContext);

            var configuration = new HttpConfiguration();
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            controller.Request = request;
            controller.Configuration = configuration;

            // Act on Test  
            var response = controller.Get(1);

            // Assert the result  
            Patient patient;
            Assert.IsTrue(response.TryGetContentValue<Patient>(out patient));
            Assert.AreEqual("Millicent", patient.FirstName);
        }

        [TestMethod]
        public void PatientNotFound()
        {

            // Get Controller 
            var controller = new PatientsController(_dbContext);
            var configuration = new HttpConfiguration();
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            controller.Request = request;
            controller.Configuration = configuration;
            // Act on Test  
            var response = controller.Get(10);

            // Assert the result  
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }

        [TestMethod]
        public void EmpolyeeExistForPatient()
        {
            // Get Controller 
            var controller = new PatientsController(_dbContext);
            var configuration = new HttpConfiguration();
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            controller.Request = request;
            controller.Configuration = configuration;

            // Act on Test  
            var response = controller.Get(1);

            // Assert the result  
            Patient patient;
            Assert.IsTrue(response.TryGetContentValue<Patient>(out patient));
            Assert.IsTrue(patient.Episodes.Count > 0);
        }


        [TestMethod]
        public void EmpolyeeNotExistForPatient()
        {
            // Get Controller 
            var controller = new PatientsController(_dbContext);
            var configuration = new HttpConfiguration();
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            controller.Request = request;
            controller.Configuration = configuration;

            // Act on Test  
            var response = controller.Get(2);

            Patient patient;
            Assert.IsTrue(response.TryGetContentValue<Patient>(out patient));
            // Assert the result  
            Assert.IsNull(patient.Episodes);
        }

    }
}
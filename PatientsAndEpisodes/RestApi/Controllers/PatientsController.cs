using System;
using System.Web.Http;
using RestApi.Interfaces;
using RestApi.Models;
using System.Net.Http;
using System.Net;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IDatabaseContext _dbContext;

        public PatientsController(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public HttpResponseMessage Get(int patientId)
        {
            try
            {
                var patient = _dbContext.Patients.Find(patientId);

                if (patient != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Patient with Id {0} not Found", patientId));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
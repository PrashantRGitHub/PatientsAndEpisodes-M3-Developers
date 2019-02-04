using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Episode : IDBEntity
    {
        public int EpisodeId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public string Diagnosis { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
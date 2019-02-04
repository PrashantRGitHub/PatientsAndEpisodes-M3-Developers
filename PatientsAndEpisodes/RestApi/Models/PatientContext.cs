using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RestApi.Interfaces;
using System.Data.Entity.ModelConfiguration;

namespace RestApi.Models
{
    public class PatientContext : DbContext, IDatabaseContext
    {

        public PatientContext()
            : base("PatientContext")
        {
            Database.SetInitializer<PatientContext>(null);
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new PatientConfiguration());
          
        }
    }


    public class PatientConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            this.ToTable("Patient");

            this.HasKey<int>(s => s.PatientId);

            this.HasMany<Episode>(s => s.Episodes)
                .WithRequired(s => s.Patient)
                .HasForeignKey<int>(s => s.PatientId);

        }
    }

}

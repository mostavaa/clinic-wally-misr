using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(patientMetaData))]
    public partial class patient
    {

    }
    public class patientMetaData
    {
        [Required]
        [Display(Name = "Patient Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string name { get; set; }

        [Display(Name = "Diagnosis")]
        [MinLength(2)]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string diagnosis { get; set; }

        [Display(Name = "Diagnosis Code")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string diagnosisCode { get; set; }
        [Display(Name = "Notes")]
        [MinLength(2)]
        [MaxLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string notes { get; set; }

        [Display(Name = "Master Status")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string masterStatus { get; set; }
        [Display(Name = "Date of Diagnosis")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> dateofDiagnosis { get; set; }
        [Display(Name = "1st Status")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string firstStatus { get; set; }
        [Display(Name = "Date of Relapse")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> dateofRelapse { get; set; }
        [Display(Name = "Date of First Presentation")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> firstPresentationDate { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> birthDate { get; set; }
        [Required]
        [Display(Name = "Doctor")]

        public Nullable<System.Guid> doctorId { get; set; }
        [Display(Name = "Age")]

        
        public Nullable<int> age { get; set; }
        [Display(Name = "Gender")]
        [MinLength(2)]
        [MaxLength(10)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string gender { get; set; }
        [Display(Name = "Referred From")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string referredFrom { get; set; }
        [Display(Name = "Education")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string education { get; set; }
        [Display(Name = "Nationality")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string nationality { get; set; }
        [Display(Name = "Marital Status")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string maritalStatus { get; set; }
        [Display(Name = "Occupation")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string occupation { get; set; }
        [Display(Name = "No of Children")]

        

        public Nullable<int> noofChildren { get; set; }
        [Display(Name = "Age of Oldest")]

        

        public Nullable<int> ageofOldest { get; set; }
        
        [Display(Name = "Age of Youngest")]

        public Nullable<int> ageofYoungest { get; set; }
        
        [Display(Name = "Phone1")]
        [MinLength(7)]
        [MaxLength(15)]
        public string phone1 { get; set; }
        
        [Display(Name = "Phone2")]
        [MinLength(7)]
        [MaxLength(15)]
        public string phone2 { get; set; }
        
        [Display(Name = "Phone3")]
        [MinLength(7)]
        [MaxLength(15)]
        public string phone3 { get; set; }
        [EmailAddress]
        [Display(Name="E-mail")]
        public string email { get; set; }
        [Display(Name = "Governorate")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string governorate { get; set; }
        [Display(Name = "Address")]
        [MinLength(2)]
        [MaxLength(250)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string address { get; set; }
        [Display(Name = "Relation Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string relationName { get; set; }
        [Display(Name = "Relation")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string relation { get; set; }
        
        [Display(Name = "Phone1")]
        [MinLength(7)]
        [MaxLength(15)]
        public string relationPhone1 { get; set; }
        
        [Display(Name = "Phone2")]
        [MinLength(7)]
        [MaxLength(15)]
        public string relationPhone2 { get; set; }
        
        [Display(Name = "Phone3")]
        [MinLength(7)]
        [MaxLength(15)]
        public string relationPhone3 { get; set; }
        [Display(Name = "Address")]
        [MinLength(2)]
        [MaxLength(250)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string relationAddress { get; set; }
        [Display(Name = "Governorate")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string relationGovernorate { get; set; }
        [Display(Name = "Patient is")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string demographic { get; set; }
        [Display(Name = "Type")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string demographicType { get; set; }
        
        [Display(Name = "Since")]
        public string demographicSince { get; set; }
        
        [Display(Name = "Pack#")]
        public Nullable<int> packsNumber { get; set; }
        [Display(Name = "Alcohol Intake")]
        public bool alcoholIntake { get; set; }
        [Display(Name = "Menstrual")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string menstrual { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> LMPDate { get; set; }
        [Display(Name = "Contraception")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string contraception { get; set; }
        [Display(Name = "Pregnancy at Diagnosis")]
        public bool pregnancyatDiagnosis { get; set; }

        public bool Diabetes { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> diabetesSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string diabetesType { get; set; }
        [Display(Name = "Hypertension")]
        public bool hypertension { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> hypertensionSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string hypertensionType { get; set; }
        [Display(Name = "Hepatities C")]

        public bool hepatitiesC { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> hepatitiesCSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string hepatitiesCType { get; set; }
        [Display(Name = "Bilharziasis")]
        public Nullable<bool> bilharziasis { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> bilharziasisSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string bilharziasisType { get; set; }
        [Display(Name = "Cardiac")]

        public bool cardiac { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> cardiacSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        
        public string cardiacType { get; set; }
        [Display(Name = "Auto-Immune Disease")]
        public bool autoImmuneDisease { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]

        public Nullable<System.DateTime> autoImmuneDiseaseSince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string autoImmuneDiseaseType { get; set; }
        [Display(Name = "Allergy")]

        public bool allergy { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> allergySince { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string allergyType { get; set; }
    }
    public class patientService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public patient get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            patient acc = _context.patients.FirstOrDefault(o => o.id == (id));
            return acc;
        }
        public patient getByName(string name)
        {
            patient acc = _context.patients.FirstOrDefault(o => o.name == name);
            return acc;
        }

        public patient edit(patient acc)
        {

            try
            {
                var entry = _context.Entry<patient>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<patient>();
                    patient attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

                    if (attachedEntity != null)
                    {
                        var attachedEntry = _context.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(acc);
                    }
                    else
                    {
                        entry.State = System.Data.Entity.EntityState.Modified; // This should attach entity
                    }
                }
                Logger.Log(acc.name + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public patient add(patient acc)
        {
            try
            {
                _context.patients.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public patient delete(patient acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.name + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<patient> getAll()
        {
            return _context.patients;
        }
    }
}
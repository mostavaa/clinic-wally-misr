using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    public enum Persons
    {
        Nurse,
        SystemPerson,
        HospitalPerson,
        Employee,
        Doctor
    }
    [MetadataType(typeof(SystemPersonMetaData))]
    public partial class SystemPerson
    {

    }
    public class SystemPersonMetaData
    {
        [Display(Name = "Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Address")]
        [MinLength(2)]
        [MaxLength(250)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string address { get; set; }
        [Display(Name = "Gender")]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF]*$")]
        public string gender { get; set; }

        [Display(Name = "Religion")]
        [MinLength(2)]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s]*$")]
        public string religion { get; set; }
        [Display(Name = "Nationality")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s_-]*$")]
        public string nationality { get; set; }
        [Display(Name = "Marital Status")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s_-]*$")]
        public string maritalStatus { get; set; }
        [Display(Name = "Insurance Number")]
        [MinLength(2)]
        [MaxLength(50)]
        
        public string insuranceNo { get; set; }
        [Display(Name = "Social Security Number")]
        [StringLength(14)]
        
        public string SSN { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Birth Date")]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        [Display(Name = "Phone Number")]
        [MinLength(7)]
        [MaxLength(11)]
        
        public string Phone { get; set; }
        [Display(Name = "Mobile Number")]
        [MinLength(7)]
        [MaxLength(11)]
        
        public string mobile1 { get; set; }
        [Display(Name = "Mobile Number2")]
        [MinLength(7)]
        [MaxLength(11)]
        
        public string mobile2 { get; set; }

        [Display(Name = "Scientific Degree")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\u0600-\u06FF\s_-]*$")]
        public string scientificDegree { get; set; }
        [Display(Name = "Join Date")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> joinDate { get; set; }
        [Display(Name = "Leave Date")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> leaveDate { get; set; }
        [Display(Name = "Leave Reason")]
        [MinLength(2)]
        [MaxLength(150)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string leaveReason { get; set; }
        [Display(Name = "Place")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string place { get; set; }

        
        [Display(Name = "Job")]
        [Required]
        public Nullable<System.Guid> jobId { get; set; }
        [Display(Name = "SpecializationId")]

        public Nullable<System.Guid> specializationId { get; set; }
    }

    public class SystemPersonService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public SystemPerson get(Guid id)
        {
            SystemPerson acc = _context.SystemPersons.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public SystemPerson getByName(string name)
        {
            SystemPerson acc = _context.SystemPersons.FirstOrDefault(o => o.name == name);
            return acc;
        }

        
        public SystemPerson edit(SystemPerson acc)
        {

            try
            {

                var entry = _context.Entry<SystemPerson>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<SystemPerson>();
                    SystemPerson attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                _context.SaveChanges();
                Logger.Log(acc.name + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public SystemPerson add(SystemPerson acc)
        {
            try
            {
                _context.SystemPersons.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public SystemPerson delete(SystemPerson acc)
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
        public IQueryable<SystemPerson> getAll()
        {
            return _context.SystemPersons;
        }
    }
}
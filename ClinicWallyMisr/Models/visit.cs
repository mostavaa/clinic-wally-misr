using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace ClinicWallyMisr
{
    [MetadataType(typeof(visitMetaData))]
    public partial class visit
    {
    }
    public class visitMetaData
    {
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        [Display(Name = "Visit Date")]
        public Nullable<System.DateTime> visitDate { get; set; }
        [Display(Name = "Visit Status")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string visitStatus { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Site")]
        public string visitSite { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Complaint Type")]
        public string complaintType { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Present History & Complaint")]
        public string PresentHistory { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Decision")]
        public string decision { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Requested Investigations")]
        public string requestedInvestigations { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "General Appearance")]
        public string GeneralAppearance { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Mentality")]
        public string mentality { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string Built { get; set; }
        public bool Pallor { get; set; }
        [Display(Name = "Jaudice")]
        public bool jaundice { get; set; }
        [Display(Name = "Cyanosis")]
        public bool cyanosis { get; set; }
        [Display(Name = "During Walking")]
        public bool postureDuringWalking { get; set; }
        [Display(Name = "Standing")]
        public bool postureStanding { get; set; }
        [Display(Name = "Sitting")]

        public bool postureSitting { get; set; }
        [Display(Name = "Lying Supine or Phone")]
        public bool postureLyingSupineorPhone { get; set; }
        [Display(Name = "Vital Signs")]
        public string vitalSigns { get; set; }
        [Display(Name = "Doctor")]
        public Nullable<System.Guid> DoctorId { get; set; }
        [Display(Name = "Patient")]
        public Nullable<System.Guid> patientId { get; set; }
    }
    public class visitService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public visit get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            visit acc = _context.visits.FirstOrDefault(o => o.id == (id));
            return acc;
        }
        public visit edit(visit acc)
        {
            try
            {
                var entry = _context.Entry<visit>(acc); if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<visit>();
                    visit attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key
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
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public visit add(visit acc)
        {
            try
            {
                _context.visits.Add(acc);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public visit delete(visit acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<visit> getAll()
        {
            return _context.visits;
        }
    }
}
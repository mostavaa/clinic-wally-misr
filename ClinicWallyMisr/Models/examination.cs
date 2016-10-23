using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(examinationMetaData))]
    public partial class examination
    {

    }
    public class examinationMetaData
    {
        [Display(Name = "Redness")]

        public bool redness { get; set; }
        [Display(Name = "Redness")]
        public bool swelling { get; set; }
        [Display(Name = "Scars")]
        public bool scars { get; set; }
        [Display(Name = "LT Wasting of Quadriceps")]
        public bool LTWastingofQuadriceps { get; set; }
        [Display(Name = "RT Wasting of Quadriceps")]
        public bool RTWastingofQuadriceps { get; set; }
        [Display(Name = "Compare")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string LTWastingofQuadricepsCompare { get; set; }
        [Display(Name = "Compare")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string RTWastingofQuadricepsCompare { get; set; }
        [Display(Name = "LT Wasting of Scapula")]
        public bool LTWastingofScapula { get; set; }
        [Display(Name = "RT Wasting of Scapula")]
        public bool RTWastingofScapula { get; set; }
        [Display(Name = "LT Long Thoracic Nerve Injury")]
        public bool LTLognThoracicNerveInjury { get; set; }
        [Display(Name = "RT Long Thoracic Nerve Injury")]
        public bool RTLognThoracicNerveInjury1 { get; set; }
        public bool Effusion { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Type")]
        public string EffusionType { get; set; }
        [Display(Name = "Near By Joints")]
        public bool NearByJoints { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Notes")]
        public string NearByJointsType { get; set; }
        [Display(Name = "Gait Pattern")]
        public bool GaitPattern { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Type")]
        public string GaitPatternType { get; set; }
    }
    public class examinationService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public examination get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            examination acc = _context.examinations.FirstOrDefault(o => o.id == (id));
            return acc;
        }


        public examination edit(examination acc)
        {

            try
            {
                var entry = _context.Entry<examination>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<examination>();
                    examination attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
        public examination add(examination acc)
        {
            try
            {
                _context.examinations.Add(acc);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public examination delete(examination acc)
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
        public IQueryable<examination> getAll()
        {
            return _context.examinations;
        }
    }
}
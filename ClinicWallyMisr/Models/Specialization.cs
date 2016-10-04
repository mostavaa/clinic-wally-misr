using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(SpecializationMetaData))]
    public partial class Specialization
    {

    }
    public class SpecializationMetaData
    {
        [Display(Name = "Specialization")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string name { get; set; }
        [Display(Name = "Job")]
        public Nullable<System.Guid> jobId { get; set; }
    }
    public class SpecializationService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Specialization get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Specialization acc = _context.Specializations.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Specialization getByName(string name)
        {
            Specialization acc = _context.Specializations.FirstOrDefault(o => o.name == name);
            return acc;
        }

        public Specialization edit(Specialization acc)
        {

            try
            {
                var entry = _context.Entry<Specialization>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Specialization>();
                    Specialization attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
        public Specialization add(Specialization acc)
        {
            try
            {
                _context.Specializations.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Specialization delete(Specialization acc)
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
        public IQueryable<Specialization> getAll()
        {
            return _context.Specializations;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(JobMetaData))]
    public partial class Job
    {

    }
    public class JobMetaData
    {
        [Display(Name = "Job")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string name { get; set; }
    }
    public class JobService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Job get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Job acc = _context.Jobs.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Job getByName(string name)
        {
            Job acc = _context.Jobs.FirstOrDefault(o => o.name == name);
            return acc;
        }

        public Job edit(Job acc)
        {

            try
            {
                var entry = _context.Entry<Job>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Job>();
                    Job attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
        public Job add(Job acc)
        {
            try
            {
                _context.Jobs.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Job delete(Job acc)
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
        public IQueryable<Job> getAll()
        {
            return _context.Jobs;
        }
    }
}
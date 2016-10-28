using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(LabMetaData))]
    public partial class Lab
    {

    }
    public class LabMetaData
    {
        [Display(Name = "Lab Type")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string LabType { get; set; }
       
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string Name { get; set; }

        [Display(Name = "Result")]
        public Nullable<int> result { get; set; }
        public string Unit { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Result")]

        public string ResultStatus { get; set; }
        [Display(Name = "Graph")]
        public string graph { get; set; }
    }
    public class LabService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Lab get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Lab acc = _context.Labs.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Lab getByName(string name)
        {
            Lab acc = _context.Labs.FirstOrDefault(o => o.Name == name);
            return acc;
        }

        public Lab edit(Lab acc)
        {

            try
            {
                var entry = _context.Entry<Lab>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Lab>();
                    Lab attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.Name + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Lab add(Lab acc)
        {
            try
            {
                _context.Labs.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.Name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Lab delete(Lab acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.Name + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Lab> getAll()
        {
            return _context.Labs;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(EndoscopyMetaData))]
    public partial class Endoscopy
    {

    }
    public class EndoscopyMetaData
    {
        [Display(Name = "Endoscopy")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string Endoscopy1 { get; set; }

        [Display(Name = "Type of Endoscopy")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string EndoscopyType { get; set; }

        [Display(Name = "Site")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string site { get; set; }

        [Display(Name = "Comments")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string comments { get; set; }

        [Display(Name = "Graph")]
        public string graph { get; set; }
    }
    public class EndoscopyService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Endoscopy get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Endoscopy acc = _context.Endoscopies.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Endoscopy getByName(string name)
        {
            Endoscopy acc = _context.Endoscopies.FirstOrDefault(o => o.Endoscopy1 == name);
            return acc;
        }

        public Endoscopy edit(Endoscopy acc)
        {

            try
            {
                var entry = _context.Entry<Endoscopy>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Endoscopy>();
                    Endoscopy attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.Endoscopy1 + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Endoscopy add(Endoscopy acc)
        {
            try
            {
                _context.Endoscopies.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.Endoscopy1 + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Endoscopy delete(Endoscopy acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.Endoscopy1 + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Endoscopy> getAll()
        {
            return _context.Endoscopies;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(LaboratoryMetaData))]
    public partial class Laboratory
    {

    }
    public class LaboratoryMetaData
    {

        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Laboratory")]
        public string Laboratory1 { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name="Date of Lab")]
        public Nullable<System.DateTime> DateofLab { get; set; }
    }
    public class LaboratoryService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Laboratory get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Laboratory acc = _context.Laboratories.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Laboratory getByName(string name)
        {
            Laboratory acc = _context.Laboratories.FirstOrDefault(o => o.Laboratory1 == name);
            return acc;
        }

        public Laboratory edit(Laboratory acc)
        {

            try
            {
                var entry = _context.Entry<Laboratory>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Laboratory>();
                    Laboratory attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.Laboratory1 + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Laboratory add(Laboratory acc)
        {
            try
            {
                _context.Laboratories.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.Laboratory1 + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Laboratory delete(Laboratory acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.Laboratory1 + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Laboratory> getAll()
        {
            return _context.Laboratories;
        }
    }
}
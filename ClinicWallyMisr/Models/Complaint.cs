using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(ComplaintMetaData))]
    public partial class Complaint
    {

    }
    public class ComplaintMetaData
    {
        
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Complaint")]
        public string complaintName { get; set; }

    }
    public class ComplaintService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Complaint get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Complaint acc = _context.Complaints.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public Complaint getByName(string name)
        {
            Complaint acc = _context.Complaints.FirstOrDefault(o => o.complaintName == name);
            return acc;
        }

        public Complaint edit(Complaint acc)
        {

            try
            {
                var entry = _context.Entry<Complaint>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Complaint>();
                    Complaint attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.complaintName + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Complaint add(Complaint acc)
        {
            try
            {
                _context.Complaints.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.complaintName + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Complaint delete(Complaint acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.complaintName + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Complaint> getAll()
        {
            return _context.Complaints;
        }
    }
}
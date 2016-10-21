using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{


    [MetadataType(typeof(surgicalHistoryMetaData))]
    public partial class surgicalHistory
    {

    }
    public class surgicalHistoryMetaData
    {
    }
    public class surgicalHistoryService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public surgicalHistory get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            surgicalHistory acc = _context.surgicalHistories.FirstOrDefault(o => o.id == (id));
            return acc;
        }
        public surgicalHistory getByName(string name)
        {
            surgicalHistory acc = _context.surgicalHistories.FirstOrDefault(o => o.operationName == name);
            return acc;
        }

        public surgicalHistory edit(surgicalHistory acc)
        {

            try
            {
                var entry = _context.Entry<surgicalHistory>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<surgicalHistory>();
                    surgicalHistory attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.operationName + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public surgicalHistory add(surgicalHistory acc)
        {
            try
            {
                _context.surgicalHistories.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.operationName + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public surgicalHistory delete(surgicalHistory acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.operationName + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<surgicalHistory> getAll()
        {
            return _context.surgicalHistories;
        }
    }
}
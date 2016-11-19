using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(GroupMetaData))]
    public partial class Group
    {

    }
    public class GroupMetaData
    {
        [Display(Name = "Group")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string name { get; set; }
    }
    public class GroupService: DBService<Group>
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public override Group get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Group acc = _context.Groups.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public override Group getByName(string name)
        {
            Group acc = _context.Groups.FirstOrDefault(o => o.name == name);
            return acc;
        }

        public override Group edit(Group acc)
        {

            try
            {
                var entry = _context.Entry<Group>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Group>();
                    Group attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
        public override Group add(Group acc)
        {
            try
            {
                _context.Groups.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public override Group delete(Group acc)
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
        public override IQueryable<Group> getAll()
        {
            return _context.Groups;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(ImagingMetaData))]
    public partial class Imaging
    {

    }
    public class ImagingMetaData
    {

        [Display(Name = "Date of Image")]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> ImageDate { get; set; }
        [Display(Name = "Image Center")]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string ImageCenter { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        [Display(Name = "Type of Image")]
        public string TypeofImage { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string Site { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string Comments { get; set; }
        [Display(Name = "Image Name")]

        public string ImageName { get; set; }
    }
    public class ImagingService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Imaging get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Imaging acc = _context.Imagings.FirstOrDefault(o => o.id == (id));
            return acc;
        }
        public Imaging getByName(string name)
        {
            Imaging acc = _context.Imagings.FirstOrDefault(o => o.ImageName == name);
            return acc;
        }

        public Imaging edit(Imaging acc)
        {

            try
            {
                var entry = _context.Entry<Imaging>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Imaging>();
                    Imaging attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.ImageName + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Imaging add(Imaging acc)
        {
            try
            {
                _context.Imagings.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.ImageName + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Imaging delete(Imaging acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.ImageName + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Imaging> getAll()
        {
            return _context.Imagings;
        }
    }
}
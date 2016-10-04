using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(medicineMetaData))]
    public partial class medicine
    {
        public medicine()
        {
            id = Guid.NewGuid();
        }
    }
    public class medicineMetaData
    {
        [Display(Name = "Code")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string code { get; set; }

        [Display(Name = "Scientific Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string scientificName { get; set; }
        [Required]
        [Display(Name = "Commercial Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string commercialName { get; set; }

        [Display(Name = "Active Ingredient")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string activeIngredient { get; set; }

        [Display(Name = "Type")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string type { get; set; }

        [Display(Name = "Dose")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string dose { get; set; }

        [Display(Name = "Side Effects")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string sideEffects { get; set; }

        [Display(Name = "Notes")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string notes { get; set; }
    }
    public class medicineService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public medicine get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            medicine acc = _context.medicines.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public medicine getByName(string name)
        {
            medicine acc = _context.medicines.FirstOrDefault(o => o.commercialName == name);
            return acc;
        }

        public medicine edit(medicine acc)
        {

            try
            {
                var entry = _context.Entry<medicine>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<medicine>();
                    medicine attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
                Logger.Log(acc.commercialName + " is Edited", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public medicine add(medicine acc)
        {
            try
            {
                _context.medicines.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.commercialName + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public medicine delete(medicine acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();
                Logger.Log(acc.commercialName + " is Deleted", LogType.Info);

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<medicine> getAll()
        {
            return _context.medicines;
        }
    }
}
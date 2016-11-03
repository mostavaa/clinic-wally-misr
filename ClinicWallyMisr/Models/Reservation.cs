using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(ReservationMetaData))]
    public partial class Reservation
    {

    }
    public class ReservationMetaData
    {
        [Display(Name = "Patient Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string patientName { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> fromTime { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> toTime { get; set; }
        [Display(Name = "Type")]

        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]

        public string reservationType { get; set; }
        [Display(Name = "Notes")]

        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string notes { get; set; }
        [Display(Name = "Status")]

        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string status { get; set; }
        
        [Display(Name="room Number")]
        public string roomNumber { get; set; }
        [Display(Name="Doctor")]
        public Nullable<System.Guid> doctorId { get; set; }

    }
    public class ReservationService
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public Reservation get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Reservation acc = _context.Reservations.FirstOrDefault(o => o.id == (id));
            return acc;
        }


        public Reservation edit(Reservation acc)
        {

            try
            {
                var entry = _context.Entry<Reservation>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Reservation>();
                    Reservation attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Reservation add(Reservation acc)
        {
            try
            {
                _context.Reservations.Add(acc);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public Reservation delete(Reservation acc)
        {
            try
            {
                _context.Entry(acc).State = System.Data.Entity.EntityState.Deleted;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public IQueryable<Reservation> getAll()
        {
            return _context.Reservations;
        }
    }
}
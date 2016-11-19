using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    [MetadataType(typeof(AccountMetaData))]
    public partial class Account
    {

    }
    public class AccountMetaData
    {
        [Display(Name = "User Name")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string name { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(2)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9\u0600-\u06FF\s_-]*$")]
        public string password { get; set; }
        [Display(Name="E-mail")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.DateTime)]
        public Nullable<System.DateTime> creationDate { get; set; }
    }
    public class AccountService: DBService<Account>
    {
        private ClinicWallyMisrEntities _context = ClinicWallyMisrEntities.Instance;
        public override Account get(Guid? id)
        {
            if (id == null) id = Guid.Empty;
            Account acc = _context.Accounts.FirstOrDefault(o => o.id==(id));
            return acc;
        }
        public override Account getByName(string name)
        {
            Account acc = _context.Accounts.FirstOrDefault(o => o.name == name);
            return acc;
        }
        public Account getbyNameandPassword(string name , string password)
        {
            Account acc = _context.Accounts.FirstOrDefault(o => o.name == name && o.password==password);
            return acc;
        }

        public override Account edit(Account acc)
        {

            try
            {
                var entry = _context.Entry<Account>(acc);

                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    var set = _context.Set<Account>();
                    Account attachedEntity = set.Local.SingleOrDefault(e => e.id == acc.id);  // You need to have access to key

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
        public override Account add(Account acc)
        {
            try
            {
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                Logger.Log(acc.name + " is Added", LogType.Info);
            }
            catch (Exception e)
            {
                Logger.Log(e.ToString(), LogType.Error);
            }
            return acc;
        }
        public override Account delete(Account acc)
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
        public override IQueryable<Account> getAll()
        {
            return _context.Accounts;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    public partial class ClinicWallyMisrEntities
    {
        class inner
        {
            public static ClinicWallyMisrEntities clinicWallyMisrEntities;
            static inner()
            {
                clinicWallyMisrEntities = new ClinicWallyMisrEntities();
            }
        }
        public static ClinicWallyMisrEntities Instance
        {
            get
            {
                return inner.clinicWallyMisrEntities;
            }
        }
    }
}
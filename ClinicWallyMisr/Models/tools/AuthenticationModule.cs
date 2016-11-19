using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicWallyMisr
{
    public class AuthenticationModule: IHttpModule
    {
        private ClinicWallyMisrEntities db = ClinicWallyMisrEntities.Instance;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest+=context_AuthenticateRequest;
        }   
        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }
    }
}
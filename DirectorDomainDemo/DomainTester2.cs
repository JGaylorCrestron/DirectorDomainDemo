using System.Collections.Generic;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.DM.Streaming;

namespace DirectorDomainDemo
{
    public class DomainTester2
    {
        private DmXioDirectorEnterprise _dir;
        private List<DmXioDirectorBase.DmXioDomain> _domains = new List<DmXioDirectorBase.DmXioDomain>();
       

        public DomainTester2(ControlSystem cs)
        {
            CrestronConsole.PrintLine("Adding Explicit Tester IP ID 20");
            _dir = new DmXioDirectorEnterprise(0x20, cs);


            var domain1 = new DmXioDirectorBase.DmXioDomain(11, _dir);
            
            var tx1 = new DmNvx350(1, domain1, false);
            var rx1 = new DmNvx350(1, domain1, true);

            var domain2 = new DmXioDirectorBase.DmXioDomain(12, _dir);
            
            var tx2 = new DmNvx350(1, domain2, false);
            var rx2 = new DmNvx350(1, domain2, true);
           

            if (_dir.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
            {
                CrestronConsole.PrintLine($"Error Registering Diretor - {_dir.RegistrationFailureReason}");
            }
        }
    }
}
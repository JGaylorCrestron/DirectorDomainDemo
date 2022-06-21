using System.Collections.Generic;
using Crestron.SimplSharp;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.DM.Streaming;

namespace DirectorDomainDemo
{
    public class DomainTester
    {
        private DmXioDirectorEnterprise _dir;
        private List<DmXioDirectorBase.DmXioDomain> _domains = new List<DmXioDirectorBase.DmXioDomain>();
       

        public DomainTester(ControlSystem cs)
        
        {
            CrestronConsole.PrintLine("Adding Tester IP ID 10");
            _dir = new DmXioDirectorEnterprise(0x10, cs);

            for (uint i = 1; i < 10; i++)
            {
                DmXioDirectorBase.DmXioDomain domain;
                
                
                domain = new DmXioDirectorBase.DmXioDomain(i + 10, _dir);
                
               
                
                for (uint tx = 1; tx < 10; tx++)
                {
                    CrestronConsole.PrintLine($"Adding TX {tx} to Domain {domain.Id}");
                    var nvxTx = new DmNvx351(tx, domain, false);
                }
                
                for (uint rx = 1; rx < 10; rx++)
                {
                    CrestronConsole.PrintLine($"Adding RX {rx} to Domain {domain.Id}");
                    var nvxRx = new DmNvx363(rx, domain,  true);
                }
                    
            }

            if (_dir.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
            {
                CrestronConsole.PrintLine($"Error Registering Diretor - {_dir.RegistrationFailureReason}");
            }
        }
    }
}
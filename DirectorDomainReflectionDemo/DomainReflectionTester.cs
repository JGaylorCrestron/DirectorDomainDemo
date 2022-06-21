using System.Collections.Generic;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Reflection;
using Crestron.SimplSharpPro;
using Crestron.SimplSharpPro.DM.Streaming;

namespace DirectorDomainReflectionDemo
{
    public class DomainReflectionTester
    {
        private DmXioDirectorEnterprise _dir;
        private List<DmXioDirectorBase.DmXioDomain> _domains = new List<DmXioDirectorBase.DmXioDomain>();
       

        public DomainReflectionTester(ControlSystem cs)
        {
            _dir = new DmXioDirectorEnterprise(0x10, cs);

            var assembly = Assembly.Load("Crestron.SimplSharpPro.DM");

            for (uint i = 1; i < 3; i++)
            {
                DmXioDirectorBase.DmXioDomain domain;
                
                
                domain = new DmXioDirectorBase.DmXioDomain(i + 10, _dir);
                
               
                
                for (uint tx = 1; tx < 3; tx++)
                {
                    CrestronConsole.PrintLine($"Adding TX {tx} to Domain {domain.Id}");
                    var type = assembly.GetType("Crestron.SimplSharpPro.DM.Streaming.DmNvx351");
                    
                    var con = type.GetConstructor(new CType[] { typeof(uint), typeof(DmXioDirectorBase.DmXioDomain), typeof(bool) });

                    var nvxUnit = con.Invoke(new object[] {tx, domain, false});
                    
                    //var nvxTx = new DmNvx351(tx, domain, false);
                }
                
                for (uint rx = 1; rx < 3; rx++)
                {
                    
                    
                    CrestronConsole.PrintLine($"Adding RX {rx} to Domain {domain.Id}");
                    
                    var type = assembly.GetType("Crestron.SimplSharpPro.DM.Streaming.DmNvx351");
                    
                    var con = type.GetConstructor(new CType[] { typeof(uint), typeof(DmXioDirectorBase.DmXioDomain), typeof(bool) });

                    var nvxUnit = con.Invoke(new object[] {rx, domain, true});
                   // var nvxRx = new DmNvx363(rx, domain,  true);
                }
                    
            }

            if (_dir.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
            {
                CrestronConsole.PrintLine($"Error Registering Diretor - {_dir.RegistrationFailureReason}");
            }
        }
    }
}
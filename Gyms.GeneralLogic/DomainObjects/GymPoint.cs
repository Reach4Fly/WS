using System;
using System.Collections.Generic;
using System.Text;

namespace Gyms.DomainObjects
{
  public class GymPoint : DomainObject
    {
    
        public string NameObject { get; set; }

        public string NameZone { get; set; }
        public string District { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }

    }
}

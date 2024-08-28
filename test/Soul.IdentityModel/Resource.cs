using System;
using System.Collections.Generic;
using System.Text;

namespace Soul.IdentityModel
{
    public abstract class Resource
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}

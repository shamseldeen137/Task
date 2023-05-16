using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Service
{
  
        public class RandomPasswordOptions
        {
            public RandomPasswordOptions()
            {
                RequiredLength = 8;
                RequiredUniqueChars = 4;
                RequireLowercase = true;
                RequireUppercase = true;
                RequireNonAlphanumeric = true;
                RequireDigit = true;
            }
            public int RequiredLength { get; set; }
            public int RequiredUniqueChars { get; set; }
            public bool RequireDigit { get; set; }
            public bool RequireLowercase { get; set; }
            public bool RequireUppercase { get; set; }
            public bool RequireNonAlphanumeric { get; set; }
        }
    }


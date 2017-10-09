using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Lab
{
    class Program
    {
            public string Name
            {
                get
                {
                return _name ?? "";
                }
                set
                {
                _name = value?.Trim();
                ; 
                }
            }
        /// <summary>Gets or sets the description of the movie</summary>
            public string Description 
        }

    }
}

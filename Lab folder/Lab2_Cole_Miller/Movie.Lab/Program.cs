using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Lab
{
    class Program
    {
            // public readonly Product None =  new  Product(); 

            /// <summary>Gets or sets the name of the movie  </summary>
            /// <summary>Never returns Null.</summary>
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
        {
            get
            {
                return _description ?? " ";
            }
            set
            {
                _description = value?.Trim(); 
            }
        }
        ///<summary>Gets or sets the time of movie</summary>
        public decimal MovieTime { get; set; } = 0;
 
        ///<summary>Determines if you own the movie </summary>
           public bool OwnMovie { get; set; } 

        public override string ToString()
        {
            return Name; 
        }
        
        public decimal MovieLengthTime
        {
          get
            {
                return MovieTime; 
            }
        }
        ///<summary>Validates the name and Time of movie</summary>
        public virtual string Validate()
        {
            // The Name cannot be empty must fill in
            if (String.IsNullOrEmpty(Name))
                return "Namecannot be empty";
            //Time >=1
            if (MovieTime < 1)
                return "Movie time must be greater than 1";

            return null;
        }
        private string _name;
        private string _description;
    }

   
}

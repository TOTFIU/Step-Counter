using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAINER.Models
{
    public class UserModel_InData
    {
		

		
        public string User { get; set; }
        public Dictionary<int,int> Rank { get; set; }
		public Dictionary<int, string> Status { get; set; }
		public Dictionary<int,int> Steps { get; set; }

    }
}

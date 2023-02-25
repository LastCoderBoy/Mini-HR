using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project2_HR
{
    class KeepInfoAfterHire:KeepDataAfterTxt
    {
        public Dictionary<string, string> employeeSalary = new Dictionary<string, string>();
        public int Random_ID()
        {
            Random random = new Random();
            int candidateID = 0;

            candidateID = random.Next(1000, 10000);
            return candidateID;
		}
    }
}

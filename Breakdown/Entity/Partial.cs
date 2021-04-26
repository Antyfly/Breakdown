using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakdown.Entity
{
    partial class Client
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName + " " + Patronymic;
            }
        }
    }
}

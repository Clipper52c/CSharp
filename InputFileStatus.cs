using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Core.Domain._FundCode
{
    public class InputFileStatus
    {
        public InputFileStatus() { }
        public int Id { get; set; }
        public string FileName { get; set; }
        public int status { get; set; } // 0 init, 1 dropped, 2 imported, -2 fail (flip)
        public string EmailCommentPickup { get; set; }
    }
 
}

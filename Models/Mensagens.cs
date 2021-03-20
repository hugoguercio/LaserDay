using System;
using System.Collections.Generic;
using System.Text;

namespace LaserDay.Models
{
    class Mensagens
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Boolean HasQuotedMessage { get; set; }        
        public DateTime Timestamp { get; set; }


    }
}

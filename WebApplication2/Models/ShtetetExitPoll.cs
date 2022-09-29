using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class ShtetetExitPoll
    {
        public int? ShtetiId { get; set; }
        public int? EpollId { get; set; }

        public virtual ExitPoll? Epoll { get; set; }
        public virtual Shtetet? Shteti { get; set; }
    }
}

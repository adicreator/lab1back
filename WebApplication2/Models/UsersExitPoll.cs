﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class UsersExitPoll
    {
        public int? UsersId { get; set; }
        public int? EpollId { get; set; }

        public virtual ExitPoll? Epoll { get; set; }
        public virtual User? Users { get; set; }
    }
}

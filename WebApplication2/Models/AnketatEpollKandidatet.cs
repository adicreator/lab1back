using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class AnketatEpollKandidatet
    {
        public int? NumriKandidatit { get; set; }
        public string? AnketaEpId { get; set; }

        public virtual AnketatEpoll? AnketaEp { get; set; }
        public virtual Kandidatet? NumriKandidatitNavigation { get; set; }
    }
}

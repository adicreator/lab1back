using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class ShtetetSimpleSurvey
    {
        public int? ShtetiId { get; set; }
        public int? SsurveyId { get; set; }

        public virtual Shtetet? Shteti { get; set; }
        public virtual SimpleSurvey? Ssurvey { get; set; }
    }
}

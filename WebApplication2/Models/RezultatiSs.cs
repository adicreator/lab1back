﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class RezultatiSs
    {
        public int RezId { get; set; }
        public string? Rezultati { get; set; }
        public int? SsurveyId { get; set; }

        public virtual SimpleSurvey? Ssurvey { get; set; }
    }
}

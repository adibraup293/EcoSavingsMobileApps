using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSavingsMobileApps.Models
{
    class Submission
    {
        public string SubmissionID { get; set; }
        public DateTime ProposedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public double WeightInKG { get; set; }
        public int PointsAwarded { get; set; }
        public string Status { get; set; }

    }
}

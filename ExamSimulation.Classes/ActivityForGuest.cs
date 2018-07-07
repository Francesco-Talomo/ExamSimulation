using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamSimulation.Classes
{
    public class ActivityForGuest
    {
        [Display(Name = "Count Partecipant")]
        public int CountPartecipant { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
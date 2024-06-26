﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsmAppDev.Models
{
    public class JobApplication 
    {
        public int Id { get; set; }
        public string Email { get; set; }
       
        [ValidateNever]
        public int JobId { get; set; }
        [ForeignKey(nameof(JobId))]
        [ValidateNever]
        public Job Job { get; set; }      
        
        public DateTime DayApply { get; set; }
    }
}

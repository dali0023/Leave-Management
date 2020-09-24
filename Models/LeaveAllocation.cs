using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveAllocation
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }

        // Employee FK Set
        [Display(Name= "Employee")]
        public string EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        // Leave Type ID FK
        [Display(Name = "Leave Type")]
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }

    }
}

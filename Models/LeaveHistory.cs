using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveHistory
    {
        [Key]
        public int Id { get; set; }
        // REquesting Employee FK Set
        public string RequestingEmployeeID { get; set; }
        [ForeignKey("RequestingEmployeeID")]
        public virtual Employee RequestingEmployee { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Leave Type ID FK
        [Display(Name = "Leave Type")]
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveType LeaveType { get; set; }

        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }

        // Approved By FK
        public string ApprovedByID { get; set; }
        [ForeignKey("ApprovedByID")]
        public virtual Employee ApprovedBy { get; set; }
    }
}

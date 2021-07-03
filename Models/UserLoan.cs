using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServiceProject.Models
{
    public class UserLoan
    {
        [Key]
        public string UId { get; set; }
        public string LoanType { get; set; }
        public string LoanAmount { get; set; }
        public string ApplyDate { get; set; }
        public int RateOfInterest { get; set; }
        public string LoanDuration { get; set; }
        public string CourseFee { get; set; }
        public string CourseName { get; set; }
        public string FatherName { get; set; }
        public string FatherOcc { get; set; }
        public int FatherExp { get; set; }
        public string RationCard { get; set; }
        public string FatherInc { get; set; }
        public string AnnualIncome { get; set; }
        public string CompanyName { get; set; }
        public string Desig { get; set; }
        public int TotalExp { get; set; }
        public int CurrExp { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AuthServiceProject.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string GuardianType { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string Citizenship { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Contact { get; set; }
        public string Dob { get; set; }
        public int Age { get; set; }
        public string CitizenStatus { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AccountType { get; set; }
        public string BranchName { get; set; }
        public int InitDeposit { get; set; }
        public string IdentityProof { get; set; }
        public string Pan { get; set; }
        public string RefName { get; set; }
        public string RefAccountNo { get; set; }
        public string RefAddress { get; set; }
        public string AccountNumber { get; set; }



    }
}

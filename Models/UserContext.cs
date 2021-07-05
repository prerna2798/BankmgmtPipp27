using Microsoft.EntityFrameworkCore;


namespace AuthServiceProject.Models
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLoan> UserLoans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserName = "Thomas Jacob",
                UId = "R-000",
                Email = "thomas234@gmail.com",
                GuardianType = "Father",
                GuardianName = "Steve Jacob",
                Address = "45 Church Road Los Angeles",
                Password = "P@ssw0rd",
                ConfirmPassword = "P@ssw0rd",
                Citizenship = "Other",
                Gender = "Male",
                MaritalStatus = "Single",
                Contact = "8811209877",
                Dob = "2000-01-16",
                Age = 21,
                CitizenStatus = "Normal",
                Country = "USA",
                State = "Alaska",
                AccountType = "Savings",
                BranchName = "Alaska",
                InitDeposit = 5000,
                IdentityProof = "Aadhaar",
                Pan = "1234tytt4987",
                RefName = "Martin P",
                RefAccountNo = "5600063211678820",
                RefAddress = "23 Wiston Road Alaska",
                AccountNumber = "6700345528779000"
            });

            modelBuilder.Entity<UserLoan>().HasData(new UserLoan
            {
                UId="R-000",
                LoanType="personal",
                LoanAmount="300000",
                ApplyDate="01-01-2021",
                RateOfInterest=10,
                LoanDuration="5",
                AnnualIncome="400000",
                CompanyName="Cognizant",
                Desig="PAT",
                TotalExp=1,
                CurrExp=1

            });
        }
    }
}

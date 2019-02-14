namespace Domain.Models
{
    public class RegistrationModel
    {
        public RegistrationModel(string firstName, string lastName, string emailAddress, string password, string confirmPassword,string isStudent)
        {
            FirstName = firstName;
            LastName = LastName;
            EmailAddress = emailAddress;
            Password = password;
            ConfirmPassword = confirmPassword;
            IsStudent = isStudent;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string IsStudent { get; set; }
    }
}

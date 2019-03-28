

namespace Domain.Models
{
    public class RegistrationModel:GenericMapper<DataLayer.UserModel>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConfirmPassword { get; set; }
        public string IsStudent { get; set; }
        public RegistrationModel()
        {
            this.SetMapping(x => x.FirstName = this.FirstName, x => x.LastName = this.LastName,
                x => x.EmailAddress = this.EmailAddress, x => x.Password = this.Password,x => x.IsStudent = this.IsStudent);
        }
    }
}

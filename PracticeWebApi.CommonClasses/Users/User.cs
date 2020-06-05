namespace PracticeWebApi.CommonClasses.Users
{
    public class User : BaseResource
    {
        public Address Address { get; set; }
        public Name Name { get; set; }
        public string Email { get; set; }
    }
}

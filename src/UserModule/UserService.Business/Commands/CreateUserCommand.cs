namespace UserModule.UserService.Business.Commands
{
    public class CreateUserCommand
    {
        public string FirstName { get; set; } = null!;
        public string LastName {get; set;} = null!;

        public string Username {get; set;} = null!;

        public string Password {get; set;} = null!;
    }
}
namespace UserModule.UserService.Business.Commands
{
    public class RemoveUserCommand
    {
        public string Id { get; set; }

        public RemoveUserCommand(string id)
        {
            Id = id;
        }
    }
}
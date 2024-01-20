// using UserModule.UserService.Data.Repositories;

using UserModule.UserService.Data.Repositories;
public class Program
{
    public static void Main(string[] args)
    {
        // var repository = new UserRepository();

        // var list = repository.GetList().Result;

        // var result = repository.CreateAsync(new UserModule.UserService.Data.Entities.AppUser
        // {
        //     FirstName = "Berkay",
        //     LastName = "Akar",
        //     Username = "berkay",
        //     Password = "1"
        // }).Result;

        // var result = repository.FindOne("65aac50ace308b0f831c1b93").Result;

        // if (result != null)
        // {
        //     result.FirstName = "Yavuz";

        //     repository.UpdateAsync(result).Wait();
        // }





        // if (list != null)
        //     foreach (var item in list)
        //     {

        //         System.Console.WriteLine("User Firstname " + item.FirstName);
        //     }



        // Console.WriteLine("Hello, World! :");



       //CQRS =>  Command Query Responsibilty Segregation  

        // Command ve Query sorumluluklarına göre ayırma

        // COMMAND ne  QUERY

        // Write işlemleri için ayrı veritabanı read işlemleri ayrı veritabanım var.

        // COMMAND WRITE => Insert, Update, Delete,    Select + Update + Insert

        // QUERY READ  => Select

        // Record => Sınıflar gibi çalışlır
    
        // Command  CreateUserCommand |  CreateUserCommandHandler | CreateUserCommandResult  => CreateUser

        // UserService => ...... 10000


        //          UpdateUserCommand |  UpdateUserCommandHandler 

        
    }
}
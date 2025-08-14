using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace InMemoryGenericRepository;

class Program
{
    static void Main(string[] args)
    {
      
        ExecuteAsync().Wait();

    }

    private static Task ExecuteAsync()
    {
        TaskCompletionSource<bool> tcs = new();
        var customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "John",
                Address = "123 Main St",
                PhoneNumber = "123-456-7890",
                CountryCode = "US"
            },
            new Customer
            {
                Id = 2,
                Name = "Omar",
                Address = "123 Second St", 
                PhoneNumber = "123-456-9066",
                CountryCode = "JO"
            },new Customer()
            {
                Id = 3,
                Name = "Ahmed",
                Address = "123 Third St", 
                PhoneNumber = "123-456-7711",
                CountryCode = "UK"
            },
        };
        
        var genericRepository = new GenericRepository<Customer>(customers);

        var addUser1= genericRepository.Add(new Customer
        {
            Id = 4,
            Name = "Ali",
            Address = "123 Fourth St",
            PhoneNumber = "123-456-7711",
            CountryCode = "UK"
        }).GetAwaiter();
        var getAllUsers = genericRepository.GetAll().GetAwaiter();
        var addUser2=genericRepository.Add(new Customer
        {
            Id = 5,
            Name = "Ali",
            Address = "123 Fifth St",
            PhoneNumber = "123-456-7764",
            CountryCode = "SY"
        }).GetAwaiter();
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Start Find Customer with Id 1");
        Console.WriteLine("----------------------------------------");
        var findUser1 = genericRepository.Find(x => x.Id == 1).GetAwaiter();
       
         var addUser3 = genericRepository.Add(new Customer
        {
            Id = 6,
            Name = "Ali2",
            Address = "123 Sixth St",
            PhoneNumber = "123-456-7723",
            CountryCode = "KW"
        }).GetAwaiter();
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Start Find Customer with Id 5");
        Console.WriteLine("----------------------------------------");
        var findUser5 = genericRepository.Find(x => x.Id == 5).GetAwaiter();
        
        
        
        addUser1.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Added Customer with Id 4");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
            tcs.SetResult(true);
        });
        getAllUsers.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("First Get All Customers");
            Console.WriteLine("----------------------------------------");
            getAllUsers.GetResult().ForEach(customer =>
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(customer);
                Console.WriteLine("----------------------------------------");
            });
            Console.WriteLine("----------------------------------------");
            tcs.SetResult(true);
        });
        addUser2.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Added Customer with Id 5");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
        });
        
        findUser1.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("End Find Customer with Id 1");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(findUser1);
            Console.WriteLine("----------------------------------------");
        });
        
        addUser2.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Added Customer with Id 5");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
        });
        addUser3.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Added Customer with Id 6");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("----------------------------------------");
        });
        
        findUser5.OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("End Find Customer with Id 5");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(findUser5);
            Console.WriteLine("----------------------------------------");
        });
        
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Start Second GetAll Customers");
        Console.WriteLine("----------------------------------------");
        genericRepository.GetAll().GetAwaiter().OnCompleted(() =>
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Second Get All Customers");
            Console.WriteLine("----------------------------------------");
            getAllUsers.GetResult().ForEach(customer =>
            {
                customer.Name = "Ali";
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(customer);
                Console.WriteLine("----------------------------------------");
            });
            Console.WriteLine("----------------------------------------");
        });
        
    }
}

/*
 * In-Memory Generic Repository
 
Covered Topics: Generics, Generic Collections

Scenario: Store and query entities without a database.

Requirements:

Define IRepository<T> with Add, GetAll, Find.

Back with List<T>; ensure thread-safe reads using copy-on-write.

Demonstrate with a Customer entity.

 */
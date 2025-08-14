namespace InMemoryGenericRepository;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCode { get; set; }

    public override string ToString()
    {
        return $@"Customer Id {Id}
Customer Name {Name}
Customer Address {Address}
Customer Phone Number {PhoneNumber}
Customer Country Code {CountryCode}";
    }
}
public class Program
{
    //Bir sınıf sadece tek sınıfı inherit edebilir.
    //Bir sınıf, birden fazla interface'i implemente edebilir(aralarda virgüllerle)
    public static void Main(string[] args)
    {
       
        CustomerManager customerManager = new CustomerManager(new Customer(), /*new MilitaryCreditManager()*/ new TeacherCreditManager() );
        customerManager.GiveCredit();

        /*CreditManager creditmanager = new CreditManager();
        creditmanager.Calculate();
        creditmanager.Save();
        

        Customer customer = new Customer();
        customer.Id = 1;
        customer.City = "Ankara";


        CustomerManager customermanager = new CustomerManager(customer);
        customermanager.Save();
        customermanager.Delete();

        Company company = new Company();
        company.TaxNumber = "100000";
        company.CompanyName = "Arçelik";
        company.Id = 100;

        CustomerManager customerManager2 = new CustomerManager(new Person());

        Person person = new Person();
        person.NationalIdentity = "";

        Customer c1 = new Customer();
        Customer c2 = new Person();
        Customer c3 = new Company();*/

        Console.ReadLine();
    }
}
class CreditManager
{
    public void Calculate()
    {
        Console.WriteLine("Hesaplandı");
    }
    public void Save()
    {
        Console.WriteLine("Kredi verildi");
    }
}


interface ICreditManager
{
    void Calculate();
    void Save();

}

abstract class BaseCreditManager : ICreditManager
{
    public abstract void Calculate();

    public virtual void Save()
    {
        Console.WriteLine("Kaydedildi");
    }
}

//DRY(Don't Repeat Yourself)
class TeacherCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Öğretmen kredisi hesaplandı");
    }
    public override void Save()
    {
        //farklı kodlar burda
        base.Save();
        //farklı kodlar burda olabilir.
    }


}


class MilitaryCreditManager : BaseCreditManager, ICreditManager
{
    public override void Calculate()
    {
        Console.WriteLine("Asker kredisi hesaplandı");
    }

}
class Customer
{

    public Customer()
    {
        Console.WriteLine("müşteri nesnesi başlatıldı");
    }
    public int Id { get; set; }
    public string City { get; set; }

}

class Person : Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}

class Company : Customer
{
    public string CompanyName { get; set; }
    public string TaxNumber { get; set; }
}

class CustomerManager
{
    private Customer _customer;
    private ICreditManager _creditManager;

    public CustomerManager(Customer customer, ICreditManager creditManager)
    {
        _customer = customer;
        _creditManager = creditManager;

    }
    public void Save() 
    {
        Console.WriteLine("Müşteri kaydedildi " /*+ _customer.FirstName*/);
    }

    public void Delete()
    {
        Console.WriteLine("Müşteri silindi " /*+ _customer.FirstName*/);
    }

    public void GiveCredit()
    {
        _creditManager.Calculate();
        Console.WriteLine("Kredi verildi");
    }
}
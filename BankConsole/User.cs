using Newtonsoft.Json;
namespace BankConsole;

public class User //: Person   clase abstracta
{
    [JsonProperty]
    protected int ID {get; set; }
    [JsonProperty]
    protected string Name {get; set; }
    [JsonProperty]
    protected string Email {get; set; }
    [JsonProperty]
    protected decimal Balance { get; set; }
    [JsonProperty]
    protected DateTime RegisterDate {get; set; }

   public User(){}

public virtual void SetBalance(decimal amount)
{
    decimal quantity = 0;

    if(amount < 0)
        quantity = 0;
    else
        quantity = amount;
        this.Balance += quantity;
}
    public virtual string ShowData()
    {
        return $"ID: {this.ID}, Nombre: {this.Name} , Correo: {this.Email}, " + 
        $"Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate.ToShortDateString()} ";
    }

    public string ShowData(String initialMessage)
    {
        return $"\n{initialMessage} -> Nombre: {this.Name} , Correo: {this.Email}, " + 
        $"Saldo: {this.Balance}, Fecha de registro: {this.RegisterDate} ";
    }

    public User (int ID, string Name, string Email, decimal Balance)
    {
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        //SetBalance(Balance);
        this.RegisterDate = DateTime.Now;
    }

    public int GetID()
    {
        return ID;
    }
    public DateTime GetRegisterDate()
    {
        return RegisterDate;
    }

    //clase abstracta
   /* public override string GetName()
    {
        return Name;
    }*/
}

/*Interfaces
No se puede instanciar
proveer una definicion comun que multiples clases pueden compartir
todos sus elementos son abstractos
una clase que implementa a una interfaz debe implementar a todos sus elementos*/

/*Clases
Una clase puede heredar a otra clase sea abstracta o no
Una clase puede implementar a multiples clases*/
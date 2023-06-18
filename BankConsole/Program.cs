using BankConsole;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

bool estado;
string Email;
char userType;
decimal Balance;
int ID;

/*HashSet<int> ids = new HashSet<int>();
ids.Add(0);*/

//Client ximena = new Client(3, "ximena", "ximena@gmail.com",1500, 'M');
//Storage.AddUser(ximena);
if(args.Length == 0) //args es un arreglo
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Selecciona una opcion:");
    Console.WriteLine("1 - Crear un Usuario nuevo.");
    Console.WriteLine("2 - Eliminar un Usuario existente.");
    Console.WriteLine("3 - Salir.");

    int opcion = 0;
    do{
        string imput = Console.ReadLine();

        if(!int.TryParse(imput, out opcion))
            Console.WriteLine("Debe ingresar un numero (1, 2 o 3).");
        else if (opcion > 3)
            Console.WriteLine("Debes imgresar un numero valido (1, 2 o 3).");

    }while(opcion == 0 || opcion > 3);

    switch(opcion)
    {
        case 1:
            CreateUser();
        break;

        case 2:
            DeleteUser();
        break;

        case 3:
            Environment.Exit(0);
        break;
    }
}

void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Ingresa la informacion del usuario: ");

Console.WriteLine("ID: ");
    do{
       estado = false;
    string Text = Console.ReadLine();
        if(!int.TryParse(Text, out ID))
            Console.WriteLine("Error: El ID debe ser un numero entero positivo.");
            else int.TryParse(Text, out ID);
            if (ID < 0)
                Console.WriteLine("Error: El ID debe ser un numero entero positivo.");
                else if(Storage.ValidarID(Text) != null)
                    Console.WriteLine("Error: El ID debe ser unico entre los demas IDs existentes.");  
                    else
                        estado = true;
    }while(estado == false); //||

    Console.WriteLine("Nombre: ");
    string name = Console.ReadLine();

    Console.WriteLine("Email: ");
       do{
        estado= false;
        Email = Console.ReadLine();
        if(Regex.IsMatch(Email, @"^[a-zA-Z0-9]+([._][a-zA-Z0-9]+)*@gmail\.com"))
            estado = true;
        else
            Console.WriteLine("Error: Ingrese un correo electronico.");
    }while(estado == false);
    
     Console.WriteLine("Saldo: ");
    do{
        estado = false;
        string Text2 = Console.ReadLine();
        if(!decimal.TryParse(Text2, out Balance))
            Console.WriteLine("Error: El saldo debe ser un decimal positivo.");
            else decimal.TryParse(Text2, out Balance);
            if (Balance < 0)
                Console.WriteLine("Error: El saldo debe ser un decimal positivo.");
                else
                estado = true;
    }while(estado == false);

    Console.WriteLine("Escribe 'c' si el usuario es cliente, 'e' si es empleado: ");
    do{
        estado = false;
        userType = char.Parse(Console.ReadLine());
        if(userType != 'c' && userType != 'e')
            Console.WriteLine("Error: Solo debe responder con 'c' o con 'e': ");
        else
            estado = true;
    }while(estado == false);
    
    User newUser;

    if(userType.Equals('c'))
    {
        Console.Write("Regimen fiscal: (Escriba una letra)");
        char TaxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, Email, Balance, TaxRegime);
    }
    else
    {
        Console.WriteLine("Departamento: ");
        string department = Console.ReadLine();

        newUser = new Employee (ID, name, Email, Balance, department);
    }

    Storage.AddUser(newUser);
    Console.WriteLine("Usuario creado.");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser()
{
    Console.Clear();
    Console.Write("Ingresa el ID del usuario a eliminar: ");
    do{
       estado = false;
        string Text = Console.ReadLine();
        if(!int.TryParse(Text, out ID))
            Console.WriteLine("Error: El ID a eliminar debe ser un numero entero positivo.");
            else int.TryParse(Text, out ID);
            if (ID < 0)
                Console.WriteLine("Error: El ID a eliminar debe ser un numero entero positivo.");
                else if(Storage.ValidarID(Text) == null)
                    Console.WriteLine("Error: El ID a eliminar debe existir en el listado.");  
                    else
                        estado = true;
    }while(estado == false);
        string result = Storage.DeleteUser(ID);

        if(result.Equals("Success"))
        {
            Console.Write("Usuario eliminado.");
            Thread.Sleep(2000);
            ShowMenu();
        }
}

//El metodo de main existe pero esta oculto

//Client Chime = new Client(1, "Chime", "Chime@gmail.com", 1000, 'M');
//Chime.SetBalance(2000);
//Console.WriteLine(Chime.ShowData());

/*Chime.ID = 1;
Chime.Name = "Chime";
Chime.Email = "Chime@gmail.com";
Chime.Balance = 1000;
Chime.RegisterDate = DateTime.Now;*/

/*Employee Carlos = new Employee(2, "Carlos", "Carlos@gmail.com", 2500, "IT");
Storage.AddUser(Chime);
Storage.AddUser(Carlos);*/

//Carlos.SetBalance(2000);
//Console.WriteLine(Carlos.ShowData());

//Storage.AddUser(Chime);
//Storage.AddUser(Carlos);
//Console.WriteLine(Carlos.ShowData()); 
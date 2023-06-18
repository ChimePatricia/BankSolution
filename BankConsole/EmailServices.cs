//Enviar correo Email
using MailKit.Net.Smtp;
using MimeKit;

namespace BankConsole;

public static class EmailService
{
    //Envio de correo
    public static void SendMail()
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress ("Ximena Gomez", "ximenap03.gr@gmail.com"));
        message.To.Add(new MailboxAddress ("Carlos San Diego", "Carlos@mail.com"));
        message.Subject = "BankConsole: Usuarios nuevos";
        message.Body = new TextPart("plain"){
            Text = GetEmailText()
        };

        using (var client = new SmtpClient()){
            client.Connect("Smtp.gmail.com", 587, false);
            client.Authenticate("Chimena@gmail.com", "123");
            client.Send(message);
            client.Disconnect(true);
        }
    }
    //Obtener la informacion de texto que se quiere enviar

    private static string GetEmailText()
    {
        List<User> newUsers = Storage.GetNewUsers();

        if(newUsers.Count == 0)
            return "No hay usuarios nuevos";

            string emailText = "Usuarios agregados hoy: \n";
        foreach (User user in newUsers)
            emailText += "\t+ " + user.ShowData() + "\n"; //mostrar toda la informacion de users 

        return emailText;
    }
}
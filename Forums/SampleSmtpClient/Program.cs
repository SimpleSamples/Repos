using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

// I get the following error from this.
// Syntax error, command unrecognized.

// SmtpClient Class (System.Net.Mail) | Microsoft Docs
// https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Net.Mail.SmtpClient);k(DevLang-csharp)%26rd%3Dtrue%26f%3D255%26MSPPError%3D-2147217396&view=netframework-4.8

// Error while sending email with C# console app
// https://social.msdn.microsoft.com/Forums/en-US/c578eff6-7a5b-42d4-9324-ffd755136937/error-while-sending-email-with-c-console-app?forum=csharpgeneral

namespace SampleSmtpClient
{
    public class SimpleAsynchronousExample
    {
        static bool mailSent = false;

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }

        public static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("socalsam@gmail.com", "ginjbenjdqbjkvaw");
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            //MailAddress from = new MailAddress("socalsam@gmail.com",
            //   "SoCal " + (char)0xD8 + " Sam",
            MailAddress from = new MailAddress("socalsam@gmail.com");
            // Set destinations for the email message.
            MailAddress to = new MailAddress("Tomato@verizon.net");
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            // Include some non-ASCII characters in body and subject.
            //string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            //message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "test message 1" /* + someArrows */;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new
            SendCompletedEventHandler(SendCompletedCallback);
            // The userState can be any object that allows your callback 
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
        }
    }
}

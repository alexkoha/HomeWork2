using System;
using System.Threading;


namespace MailSystem
{ 
    public class MailArrivedEventArgs : EventArgs // args event implementation
    {
        public string Title { get; }
        public string Body { get; }

        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public MailArrivedEventArgs()
        {
            Title = "Empty Title";
            Body = "Empty Body";
        }
    }

    class Program
    {

        static void Main()
        {
            MailMenager test = new MailMenager();

            test.MailArrived += Show; // sign some method to event
            var timer = new Timer(temp => test.SimulateMailArrived(), null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            Thread.Sleep(10000);
        }

        static void Show(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine($"Title : {e.Title} \nMessage :\n{e.Body}\n");
        }
    }
}

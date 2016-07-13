using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailMenager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArived(MailArrivedEventArgs e)
        {
            MailArrived?.Invoke(this, e);
        }

        public void SimulateMailArrived()
        {
            MailArrivedEventArgs args = new MailArrivedEventArgs("Some Dummy Title", "Dummy dummy dummy message.");
            OnMailArived(args);
        }
    }

}

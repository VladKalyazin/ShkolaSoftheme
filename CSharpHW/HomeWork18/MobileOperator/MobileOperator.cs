using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    public class MobileAccount
    {
        public string Number { get; }
        public Dictionary<MobileAccount, string> KnownAccounts = new Dictionary<MobileAccount, string>();

        public delegate void MobileIncomingHandler(MobileAccount from, MobileAccount to);
        public event MobileIncomingHandler CallIncoming;
        public event MobileIncomingHandler SMSIncoming;

        public MobileAccount(MobileOperator Operator, string number)
        {
            Number = number;
            CallIncoming += Operator.HandlingCall;
            SMSIncoming += Operator.HandlingSMS;
        }

        public void Call(MobileAccount account)
        {
            CallIncoming(this, account);
        }

        public void SendSMS(MobileAccount account)
        {
            SMSIncoming(this, account);
        }

    }

    public class MobileOperator
    {
        public List<MobileAccount> Accounts { get; } = new List<MobileAccount>();
    
        public void HandlingCall(MobileAccount from, MobileAccount to)
        {
            if (to.KnownAccounts.ContainsKey(from))
                Console.WriteLine($"call from {to.KnownAccounts[from]}");
            else
                Console.WriteLine($"call from {from.Number}");
        }

        public void HandlingSMS(MobileAccount from, MobileAccount to)
        {
            if (to.KnownAccounts.ContainsKey(from))
                Console.WriteLine($"sms from {to.KnownAccounts[from]}");
            else
                Console.WriteLine($"sms from {from.Number}");
        }
    }
}

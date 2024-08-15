using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TravelBuddy.Service
{
    public class TwilioSendMessage
    {
        public TwilioSendMessage() { }

        public static void SendMessage(string message)
        {
            MessageResource.Create(
               new PhoneNumber("+17055610179"),
               from: new PhoneNumber("+12513130549"),
               body: message
               );
        }

    }
}

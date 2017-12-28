using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageHelper.SMS
{
    public class SMSService : ISMSService
    {
        private const string fromPhoneTest = "+15005550006";
        private const string _actSidTest = "ACc63371dc90fbc0494750257a7cabb24f";
        private const string _authTokenTest = "e7d00259d0273e80944b81ddcb4b6a6e";

        private const string fromPhoneLive = "+14242394327";
        private const string _actSidLive = "ACc2c4aa4ebce6b7aa5ff4413ee276438d";
        private const string _authTokenLive = "221a9e70862353f3660dc4396c327587";
        //twilio login details:
        //user:     kdhappuri@gmail.com
        //pwd:      !Rose1979abcd1
        public SMSService()
        {

            TwilioClient.Init(
                    _actSidTest,
                    _authTokenTest);
        }
        public async Task SendSMS(string toPhone, string message, string subject)
        {
            try
            {
                await MessageResource.CreateAsync(
                to: new PhoneNumber(toPhone),
                from: new PhoneNumber(fromPhoneTest),
                body: message);
            }
            catch(Exception ep)
            {

            }
            
        }
    }
}

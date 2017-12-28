using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHelper.SMS
{
    public interface ISMSService
    {
        Task SendSMS(string toPhone, string message, string subject);
    }
}

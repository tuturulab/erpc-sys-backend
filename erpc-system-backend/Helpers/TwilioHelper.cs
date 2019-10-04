using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class TwilioHelper 
{
    string accountSid ;
    string authToken;

    public TwilioHelper() 
    {
        accountSid = "AC4e12bdbb1c767bfeb6f19594ddc9ef15";
        authToken = "ff584996e8d280876fd2fa31683e975e";
    }

    public void sendMessage(string _message)
    {
        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: _message,
            from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            to: new Twilio.Types.PhoneNumber("whatsapp:+50578485633")
        );

         var message2 = MessageResource.Create(
            body: _message,
            from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
            to: new Twilio.Types.PhoneNumber("whatsapp:+50589708042")
        );

        //Console.WriteLine(message.Sid);
    }
}
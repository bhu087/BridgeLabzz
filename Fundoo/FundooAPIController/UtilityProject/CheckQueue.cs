using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Manager
{
    class CheckQueue
    {
        static void Main(string[] args)
        {
            MessageQueue myqueue = new MessageQueue();
            Message[] messages = null;
            MessageQueue[] QueueList = MessageQueue.GetPrivateQueuesByMachine(".");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("bhush087@gmail.com");
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential("bhush087@gmail.com", "Bhushan087***")
            };
            try
            { 
                foreach (MessageQueue queue in QueueList)
                {
                    messages = queue.GetAllMessages();
                    if (messages.Length > 0)
                    {
                        foreach (Message m in messages)
                        {
                            m.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                            string message = m.Body.ToString();
                            mail.To.Add("bhu087@gmail.com");////m.Label);
                            mail.Body = message;
                            smtp.Send(mail);
                            queue.Receive();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myqueue.Dispose();
            }
        }   
    }
}

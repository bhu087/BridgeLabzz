using Experimental.System.Messaging;
using System;

namespace UtilityProject
{
    public class ToSendMSMQ
    {
        public void StoreToMSMQ(string label, string subject, string body)
        {
            MessageQueue MyQueue = null;
            try
            {
                if (MessageQueue.Exists(@".\Private$\"+ label))
                {
                    MyQueue = new MessageQueue(@".\Private$\" + label);
                }
                else
                {
                    MyQueue = MessageQueue.Create(@".\Private$\" + label);
                }

                MyQueue.Label = label;
                MyQueue.Send("Subject : " + subject + "\n Body : "+ body, "IDG");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                MyQueue.Dispose();
            }
        }
    }
}

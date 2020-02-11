using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralDesignPatterns.MediatorDesignPattern
{
    public interface IChatRoom
    {
        void ShowMessage(User user, string message);
    }
}

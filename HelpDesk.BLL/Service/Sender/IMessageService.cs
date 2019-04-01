using HelpDesk.Model.Enums;
using HelpDesk.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.BLL.Service.Sender
{
    public interface IMessageService
    {
        MessageStates MessageState { get; }

        Task SendAsync(MailModel message, params string[] contacts);
        void Send(MailModel message, params string[] contacts);
    }
}

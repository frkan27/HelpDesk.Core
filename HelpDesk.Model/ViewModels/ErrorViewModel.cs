using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Model.ViewModels
{
   public class ErrorViewModel
    {
        public string Text { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int ErrorCode { get; set; }
    }
}

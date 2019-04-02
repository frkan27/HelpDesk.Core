using HelpDesk.Model.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.BLL
{
    public class BussinesLayerResult<T> where T : class
    {
        public List<ErrorMessagaObj> Erros { get; set; }
        public T Result { get; set; }
        public int Responce { get; set; }

        public BussinesLayerResult()
        {
            Erros = new List<ErrorMessagaObj>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Erros.Add(new ErrorMessagaObj()
            {
                Code = code,
                Message = message
            });
        }
    }
}

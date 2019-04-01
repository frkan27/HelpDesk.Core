using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Model.Message
{
   public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEmail = 153,
        UserAlreadyActive = 154,
        ActivateIdDoesNotExist = 155,
        UserNotFound = 156,
        ProfileCouldNotUpdated = 157,
        UserCouldNoteRemove = 158,
        UserCoultNotFound=159,
        UserCouldNotInserted = 160,
        UserCouldNotUpdated = 161,
        FaultRecordNotAdd = 162,
    }
}

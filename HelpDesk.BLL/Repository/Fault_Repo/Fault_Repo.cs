using System;
using System.Collections.Generic;
using System.Text;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.DAL;
using HelpDesk.Model.Entities.Poco;

namespace HelpDesk.BLL.Repository.Fault_Repo
{
    public class Fault_Repo : RepoBase<FaultRecord, int>
    {
        private readonly MyContext _dbContext;

        public Fault_Repo(MyContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

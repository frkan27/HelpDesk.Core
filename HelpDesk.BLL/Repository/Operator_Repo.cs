using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.DAL;
using HelpDesk.Model.Entities.Poco;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.BLL.Repository
{
    public class Operator_Repo : RepoBase<FaultRecord, int>
    {
        private readonly MyContext _dbContext;
        private readonly MembershipTools _membershipTools;


        public Operator_Repo(MyContext dbContext, MembershipTools membershipTools) : base(dbContext)
        {
            _dbContext = dbContext;
            _membershipTools = membershipTools;

        }

        public List<FaultRecord> GetUnApproveRecords()
        {
       
            return GetAll(x => x.OperatorAccept == false).ToList();
            //var data = new ArizaKayitRepo()
            //   .GetAll(x => x.OperatorKabul == false)
            //   .Select(x => Mapper.Map<ArizaViewModel>(x))
            //   .ToList();
        }
    }
}

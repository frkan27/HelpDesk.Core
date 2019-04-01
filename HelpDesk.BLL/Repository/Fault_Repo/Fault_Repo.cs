using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.BLL.Repository.Abstracts;
using HelpDesk.DAL;
using HelpDesk.Model.Entities.Poco;
using HelpDesk.Model.Message;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.BLL.Repository.Fault_Repo
{
    public class Fault_Repo : RepoBase<FaultRecord, int>
    {
        private readonly MyContext _dbContext;
        private readonly MembershipTools _membershipTools;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Fault_Repo(MyContext dbContext, MembershipTools membershipTools) : base(dbContext)
        {
            _dbContext = dbContext;
            _membershipTools = membershipTools;
            //_httpContextAccessor = httpContextAccessor;
        }

        public async Task<BussinesLayerResult<FaultRecord>> FaultAdd(FaultRecord data)
        {
            var res = new BussinesLayerResult<FaultRecord>();
            //var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var dbresult = Insert(data);


            if (dbresult > 0)
            {
                res.AddError(ErrorMessageCode.FaultRecordNotAdd,"Hata olustu");
                return res;
            }
        
            return res;
        }



    }
}


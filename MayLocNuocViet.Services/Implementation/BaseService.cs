using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using MLT.MayLocNuocViet.Services.Interfaces;
using MLT.MayLocNuocViet.Infrastructure.Interfaces;

namespace MLT.MayLocNuocViet.Services.Implementation
{
    public class BaseService : IBaseService
    {

        protected BaseService(IEFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected BaseService(IEFUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            UnitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        protected IEFUnitOfWork UnitOfWork { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public String GetCurrentUserId()
        {
            IEnumerable<Claim> httpClaim = _httpContextAccessor.HttpContext.User.Claims;
            var currentUserIdIndex = 0;
            var currentUserId = "";
            if (httpClaim.Count() > currentUserIdIndex)
            {
                currentUserId = httpClaim.ElementAt(currentUserIdIndex).Value.ToString();
            }
            return currentUserId;
        }

    }
}

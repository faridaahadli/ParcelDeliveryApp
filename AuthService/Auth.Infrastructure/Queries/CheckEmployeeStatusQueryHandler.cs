using Auth.Core.Entities;
using Auth.Core.Enums;
using Auth.Core.Interfaces.Queries;
using Auth.Core.Interfaces.Repositories;
using Auth.Data.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class CheckEmployeeStatusQueryHandler : IQueryHandler<CheckEmployeeStatusQuery, bool>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public CheckEmployeeStatusQueryHandler(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CheckEmployeeStatusQuery request, CancellationToken cancellationToken)
        {
            Employee employee=await _userRepo.GetEmployeeById(request.Id);
            if(employee == null)
                throw new CustomException("Data not found", HttpStatusCode.NotFound);
            if(employee.Status==(int)EmployeeStatus.Online)
                return true;  
            return false;
        }
    }
}

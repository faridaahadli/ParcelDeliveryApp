using Auth.Core.Entities;
using Auth.Core.Interfaces.Queries;
using Auth.Core.Interfaces.Repositories;
using Auth.Data.Exceptions;
using Auth.Infrastructure.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class GetEmployeeQueryHandler : IQueryHandler<GetEmployeeQuery, GetEmployeeResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;
        public GetEmployeeQueryHandler(IUserRepo userRepo, IRoleRepo roleRepo,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public async Task<GetEmployeeResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {

            Employee employee = await _userRepo.GetEmployeeById(request.UserId);
            var roles = _roleRepo.GetRolesByUserId(request.UserId);
            if (employee == null || roles.Any(p => p.Name == "courier"))
                throw new CustomException("Data not found", HttpStatusCode.NotFound);
            GetEmployeeResponse response = _mapper.Map<GetEmployeeResponse>(employee.User);
            response.Status = employee.Status;
            return response;
        }
    }
}

using Auth.Core.Entities;
using Auth.Core.Interfaces.Queries;
using Auth.Core.Interfaces.Repositories;
using Auth.Infrastructure.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Queries
{
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, IEnumerable<GetEmployeeResponse>>
    {
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;
        public GetEmployeesQueryHandler(IUserRepo userRepo, IRoleRepo roleRepo,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetEmployeeResponse>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            ICollection<GetEmployeeResponse> result=new List<GetEmployeeResponse>();
            var employees = await _userRepo.GetEmployees(request.Pagination.CurrentPage,request.Pagination.CountPerPage);
            foreach(var employee in employees)
            {
               GetEmployeeResponse employeeResponse = _mapper.Map<GetEmployeeResponse>(employee.User);
               employeeResponse.Status = employee.Status;
               result.Add(employeeResponse);               
            }
            
            return result;
        }
    }
}

using Auth.Core.Entities;
using Auth.Core.Enums;
using Auth.Core.Interfaces.Commands;
using Auth.Core.Interfaces.Repositories;
using Auth.Core.Interfaces.UnitOfWork;
using Auth.Data.Exceptions;
using Auth.Infrastructure.Helpers;
using Auth.Infrastructure.Responses;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepo userRepo, IRoleRepo roleRepo, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepo.CheckUniqueEmail(request.Email))
                throw new CustomException("Email address already taken", HttpStatusCode.BadRequest);
            Role role;

            string salt = Guid.NewGuid().ToString();
            request.Password = HashHelper.Hash(request.Password, salt);
            User user = _mapper.Map<User>(request);
            user.Salt = salt;


            if (request.IsCourier)
            {
                role = await _roleRepo.GetRoleByName("courier");
                user.Employee = new Employee() { UserId = user.Id, Status = (int)EmployeeStatus.Offline };
            }
            else
                role = await _roleRepo.GetRoleByName("user");
            user.UserToRoles.Add(new UserToRole() { Role = role });
            await _userRepo.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);
            return response;
        }
    }
}

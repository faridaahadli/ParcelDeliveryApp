using Auth.Core.Entities;
using Auth.Core.Interfaces.Jwt;
using Auth.Core.Interfaces.Queries;
using Auth.Core.Interfaces.Repositories;
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

namespace Auth.Infrastructure.Queries
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, LoginResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IJwtManager _jwtManager;
        public LoginQueryHandler(IUserRepo userRepo,IMapper mapper,
           IJwtManager jwtManager)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _jwtManager = jwtManager;
        }
        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

           User user=_mapper.Map<User>(request);
           user = await _userRepo.GetUserByEmail(request.Email);
            if (user == null)
                throw new CustomException("User not found", HttpStatusCode.NotFound);       
            if (HashHelper.Hash(request.Password,user.Salt) != user.Password)
                throw new CustomException("Password is not correct", HttpStatusCode.Forbidden);
            LoginResponse response =_mapper.Map<LoginResponse>(user);
            response.Token = await _jwtManager.CreateToken(response.Id);
            return response;
        }
    }
}

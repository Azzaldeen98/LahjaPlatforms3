﻿
using Application.Services.Auth;
using Application.UseCase;
using AutoMapper;
using Blazorise.Extensions;
using Domain.Entities.Auth.Request;
using Domain.Entities.Auth.Response;
using Domain.Wrapper;
using Infrastructure.Models.Plans;
using LAHJA.Helpers.Services;


namespace LAHJA.ApplicationLayer.Auth
{
    public class ClientAuthService
    {
        private readonly TokenService tokenService;
        private readonly WebAuthService service;

        private readonly IMapper _mapper;


        public ClientAuthService(WebAuthService service, IMapper mapper, TokenService tokenService)
        {

            this.service = service;
            _mapper = mapper;
            this.tokenService = tokenService;
        }

        //public async Task<Result<LoginResponse>> loginAsync(VitsModel.Auth.LoginRequest request)
        //{

        //    var model = _mapper.Map<LoginRequest>(request);
        //    var response = await service.loginAsync(model);
        //    if (response.Succeeded)
        //    {
        //        await tokenService.SaveAllTokensAsync(response.Data.accessToken,
        //                                            response.Data.refreshToken,
        //                                            response.Data.expiresIn,
        //                                            response.Data.tokenType);
        //    }


        //    return response;
        //}

        public async Task<Result<LoginResponse>> loginAsync(LoginRequest model)
        {


            var response = await service.loginAsync(model);
            if (response.Succeeded)
            {
                await tokenService.RemoveAllTokensAsync();
                await tokenService.SaveAllTokensAsync(response.Data.accessToken,
                                                    response.Data.refreshToken,
                                                    response.Data.expiresIn,
                                                    response.Data.tokenType);
            }


            return response;
        }


        public async Task<Result<RegisterResponse>> registerAsync(RegisterRequest request)
        {

            return await service.registerAsync(request);

        }

        public async Task<Result<ForgetPasswordResponse>> forgetPasswordAsync(ForgetPasswordRequest model)
        {
            return await service.forgetPasswordAsync(model);

        }

        public async Task<Result<ResetPasswordResponse>> resetPasswordAsync(ResetPasswordRequest request)
        {

            return await service.resetPasswordAsync(request);

        }


        public async Task<Result<string>> confirmationEmailAsync(ConfirmationEmail request)
        {

            return await service.confirmationEmailAsync(request);

        }

        public async Task<Result<string>> reConfirmationEmailAsync(ResendConfirmationEmail request)
        {

            return await service.reSendConfirmationEmailAsync(request);

        }

        public async Task<Result<string>> logoutAsync()
        {
            var response = await service.logoutAsync();
            if (response.Succeeded)
            {
                await tokenService.RemoveAllTokensAsync();
        
            }
            return response;

        }
    }
}
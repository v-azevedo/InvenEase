using InvenEase.Application.Authentication.Commands.Register;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Authentication.Queries.Login;
using InvenEase.Contracts.Authentication;

using Mapster;

namespace InvenEase.Api.Common.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.Roles, src => src.User.Roles.Select(role => role.Value))
            .Map(dest => dest.Permissions, src => src.User.Permissions.Select(permission => permission.Value))
            .Map(dest => dest, src => src.User);
    }
}
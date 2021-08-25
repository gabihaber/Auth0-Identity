using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityGabi.Extensions
{
    public class PermissaoNecessario : IAuthorizationRequirement
    {
        public string Permissao { get; }

        public PermissaoNecessario(string permissao)
        {
            Permissao = permissao;
        }

    }

    public class PermissaoNecessariaHandler : AuthorizationHandler<PermissaoNecessario>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissaoNecessario requisito)
        {
            if (context.User.HasClaim(c => c.Type == "Permissao" && c.Value.Contains(requisito.Permissao)))
            {
                context.Succeed(requisito);
            }
            return Task.CompletedTask;
        }
    }
}
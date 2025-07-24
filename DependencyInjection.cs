﻿using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace Validation.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddAcmeValidationCore(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),
                                           includeInternalTypes: true);
        return services;
    }
}

// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Threading.Tasks;

namespace Duende.IdentityServer.Validation;

/// <summary>
/// Default implementation of the CIBA validator extensibility point. This
/// validator deliberately does nothing.
/// </summary>
public class DefaultCustomBackchannelAuthenticationValidator : ICustomBackchannelAuthenticationValidator
{
    /// <inheritdoc/>
    public Task ValidateAsync(CustomBackchannelAuthenticationRequestValidationContext customValidationContext)
    {
        return Task.CompletedTask;
    }
}
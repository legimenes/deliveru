namespace Deliveru.IAM.Extensions;
public static class OpenIddictExtensions
{
    public static WebApplicationBuilder AddOpenIddict(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddOpenIddict()
            .AddServer(options =>
            {
                options.AllowClientCredentialsFlow();
                options.SetTokenEndpointUris("connect/token");
                options.AddDevelopmentEncryptionCertificate()
                    .AddDevelopmentSigningCertificate();
                options.DisableAccessTokenEncryption();
                options.UseAspNetCore()
                    .EnableTokenEndpointPassthrough();
            });
        return builder;
    }
}

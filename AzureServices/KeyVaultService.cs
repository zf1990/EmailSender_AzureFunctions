using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Threading.Tasks;

namespace AzureServices
{
    public class KeyVaultService
    {
        public async Task<string> GetSecretValue(string keyName)
        {
            string secret = "";

            AzureServiceTokenProvider provider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(provider.KeyVaultTokenCallback));
            //slow without ConfigureAwait(false)    
            //keyvault should be keyvault DNS Name
            string connectionString = Environment.GetEnvironmentVariable("keyvault") + keyName;
            var secretBundle = await keyVaultClient.GetSecretAsync(connectionString).ConfigureAwait(false);
            secret = secretBundle.Value;

            return secret;
        }
    }
}
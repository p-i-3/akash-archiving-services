using Proj.Models;

namespace Proj.Services
{
    public interface ISecretsHolder
    {
        public string GetSecret();
    }
}
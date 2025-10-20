using Lifetime_Examples.Interface;

namespace Lifetime_Examples.Service
{
    public class TransientGuidService : ITransientGuidService
    {
        private readonly Guid ID;
        public TransientGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}

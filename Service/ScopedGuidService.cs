using Lifetime_Examples.Interface;

namespace Lifetime_Examples.Service
{
    public class ScopedGuidService : IScopedGuidService
    {
        private readonly Guid ID;
        public ScopedGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}

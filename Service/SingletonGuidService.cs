using Lifetime_Examples.Interface;

namespace Lifetime_Examples.Service
{
    public class SingletonGuidService : ISingletonGuidService
    {
        private readonly Guid ID;
        public SingletonGuidService()
        {
            ID = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return ID.ToString();
        }
    }
}

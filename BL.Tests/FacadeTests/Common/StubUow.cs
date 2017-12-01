using System.Threading.Tasks;
using Infrastructure.UnitOfWork;

namespace BL.Tests.FacadeTests.Common
{
    internal class StubUow : UnitOfWorkBase
    {
        protected override Task CommitCore()
        {
            return Task.Delay(15);
        }

        public override void Dispose()
        {
        }
    }
}
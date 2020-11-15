using Zenject;

using Conekton.ARMultiplayer.PersistentCoordinate.Domain;
using Conekton.ARMultiplayer.PersistentCoordinate.Infrastructure;

namespace Conekton.ARMultiplayer.PersistentCoordinate.Application
{
    public class PersistentCoordinateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPersistentCoordinateService>()
                .FromSubContainerResolve()
                .ByNewGameObjectMethod(InstallBindingsToSubContainer)
                .AsCached();
        }

        private void InstallBindingsToSubContainer(DiContainer subContainer)
        {
            subContainer.Bind<IPersistentCoordinateService>().To<PersistentCoordinateService>().AsCached();
            subContainer.Bind<IPersistentCoordinateSystem>().To<PersistentCoordinateSystem>().AsCached();
            subContainer.Bind<IPersistentCoordinateRepository>().To<PersistentCoordinateRepository>().AsCached();
        }
    }
}


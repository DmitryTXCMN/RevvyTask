using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using RevvyTask.Services;

public class ApplicationCastleInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IOfficialNoteDepartamentService>().ImplementedBy<OfficialNoteDepartamentService>());
        container.Register(Component.For<ITaskResolver>().ImplementedBy<TaskResolver>());
        container.Register(Component.For<IConsoleInputService>().ImplementedBy<ConsoleInputService>());
    }
}
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RevvyTask.Services;
using System.ComponentModel;

public static class CastleControllerFactory
{
    public static IWindsorContainer Container { get; set; }

    public static void SetContainer(IWindsorContainer container)
    {
        Container = container;
    }
}
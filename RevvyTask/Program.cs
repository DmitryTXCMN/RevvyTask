using Castle.Windsor;
using RevvyTask.Services;

var container = new WindsorContainer();
container.Install(new ApplicationCastleInstaller());
CastleControllerFactory.SetContainer(container);


var resolver = container.Resolve<ITaskResolver>();
var inputter = container.Resolve<IConsoleInputService>();

while (inputter.Input())
{
    var result = resolver.Resolve();

    // Можно было бы сервис вывода сделать, но уже избыточно)
    Console.WriteLine(result);
}

container.Release(inputter);
container.Release(resolver);

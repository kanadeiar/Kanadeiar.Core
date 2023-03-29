Console.WriteLine("Test Container");

IKndContainer container = new KndContainer();

container.Register<ISecond, Second>();
container.Register<ISample, Sample>();

var sample = container.Resolve<ISample>();

Console.WriteLine($"Message: {sample.GetMessage()}");

Console.WriteLine("Press Any Key to end ...");
var _ = Console.ReadKey();

using Volo.Abp.DependencyInjection;

 namespace MarauderMap.Desktop
{
    public class HelloWorldService : ITransientDependency
    {
        public string SayHello()
        {
            return "Hello world!";
        }
    }
}

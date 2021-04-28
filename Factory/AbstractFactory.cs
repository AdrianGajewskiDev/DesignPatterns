namespace Factory
{
    public class AbstractFactory
    {
        public AbstractFactory()
        {
            var android = new DeviceOS(new Android());
            var appleOS = new DeviceOS(new Apple());
        }
    }

    public class DeviceOS 
    {
        public Button Button { get; private set; }

        public DeviceOS(IUIFactory uIFactory)
        {
            Button = uIFactory.CreateButton();
        }
    }
    
    public interface IUIFactory
    {
        Button CreateButton();
    }

    public class Apple : IUIFactory
    {
        public Button CreateButton()
        {
            return new Button() { Type = "This is apple button" };
        }
    }

    public class Android : IUIFactory
    {
        public Button CreateButton()
        {
            return new Button() { Type = "This is android button" };
        }
    }
}

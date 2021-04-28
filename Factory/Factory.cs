namespace Factory
{

    public class Dropdown 
    {
        public Button Button { get; private set; }

        public Dropdown()
        {
            Button = ButtonFactory.CreateButton();
        }
    }

    public class NavigationBar
    {
        public Button Button { get; private set; }

        public NavigationBar()
        {
            Button = ButtonFactory.CreateButton();
        }
    }

    public class Button
    {
        public string Type { get; set; }
    }

    public class ButtonFactory
    {
        public static Button CreateButton()
        {
            return new Button() { Type = "Default button" };

        }
    }
}

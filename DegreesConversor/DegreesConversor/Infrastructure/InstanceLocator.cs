namespace DegreesConversor.Infrastructure
{
    using ViewModels;
    public class InstanceLocator
    {

        public MainViewModels Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModels();
        }

    }
}

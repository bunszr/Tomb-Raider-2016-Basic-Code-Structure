namespace CampSite
{
    public interface IPanelObserver : IObserver
    {
        void OnPanelActive();
        void OnPanelDeactive();
    }
}
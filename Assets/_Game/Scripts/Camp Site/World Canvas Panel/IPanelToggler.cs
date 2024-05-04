using UniRx;

namespace CampSite
{
    public interface IPanelToggler
    {
        void Active();
        void Deactive();
        ReactiveProperty<bool> IsActiveRP { get; }
    }
}
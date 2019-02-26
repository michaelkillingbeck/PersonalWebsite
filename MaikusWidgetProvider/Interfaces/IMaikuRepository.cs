using MaikusWidgetProvider.Models;

namespace MaikusWidgetProvider.Interfaces
{
    public interface IMaikuRepository
    {
        bool IsInitialized();
        Maiku GetRandomMaiku();
    }
}

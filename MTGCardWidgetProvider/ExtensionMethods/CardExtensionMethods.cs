using CommonComponents;
using MtgApiManager.Lib.Model;

namespace MTGCardWidgetProvider.ExtensionMethods
{
    public static class CardExtensionMethods
    {
        public static Widget ToWidget(this Card card)
        {
            Widget returnWidget = new Widget
            {
                Header = card.Name
            };

            returnWidget.SetContent(new string[]
                {
                    card.Set,
                    card.Text,
                    card.ManaCost
                });

            return returnWidget;
        }
    }
}

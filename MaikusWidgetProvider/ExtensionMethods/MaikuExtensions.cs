using CommonComponents;
using MaikusWidgetProvider.Models;
using System;

namespace MaikusWidgetProvider.ExtensionMethods
{
    public static class MaikuExtensions
    {
        public static Widget ToWidget(this Maiku maiku)
        {
            Widget returnObject = new Widget();
            returnObject.Header = maiku.PublishedDate.Date.ToShortDateString();
            returnObject.SetContent(maiku.Content.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries));

            return returnObject;
        }
    }
}
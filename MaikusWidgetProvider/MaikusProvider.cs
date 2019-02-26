using CommonComponents;
using CommonComponents.Interfaces;
using MaikusWidgetProvider.ExtensionMethods;
using MaikusWidgetProvider.Interfaces;
using MaikusWidgetProvider.Repositories;
using System.ComponentModel.Composition;

namespace MaikusWidgetProvider
{
    [Export(typeof(IWidgetProvider))]
    public class MaikusProvider : IWidgetProvider
    {
        private ILogger _logger;
        private IMaikuRepository _maikuRepository;

        public MaikusProvider()
        {
            _logger = new Logger();
            _maikuRepository = new JSONMaikuRepository();
            _logger.DebugFormat($"Created new {typeof(JSONMaikuRepository)}.");
        }

        public Widget GetWidget()
        {
            _logger.DebugFormat($"Returning new {typeof(Widget)} from {nameof(_maikuRepository)}.");
            return _maikuRepository.GetRandomMaiku().ToWidget();
        }
    }
}

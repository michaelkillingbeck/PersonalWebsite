using CommonComponents;
using CommonComponents.Interfaces;
using NLipsum.Core;
using System.ComponentModel.Composition;

namespace LoremIpsumWidgetProvider
{
    [Export(typeof(IWidgetProvider))]
    public class WidgetProvider : IWidgetProvider
    {
        private ILogger _logger;
        
        public WidgetProvider()
        {
            _logger = new Logger();
            _logger.DebugFormat($"Creating new {typeof(WidgetProvider)}");
        }

        public Widget GetWidget()
        {
            var generator = new LipsumGenerator();
            _logger.DebugFormat($"Created new {typeof(LipsumGenerator)}.");

            var widget =  new Widget
            {
                Header = "Dummy widget"
            };

            widget.SetContent(generator.GenerateSentences(3, Sentence.Short));

            _logger.DebugFormat("Returning new Dummy Widget.");
            return widget;
        }
    }
}

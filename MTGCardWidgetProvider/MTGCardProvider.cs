using CommonComponents;
using CommonComponents.Interfaces;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MTGCardWidgetProvider.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace MTGCardWidgetProvider
{
    [Export(typeof(IWidgetProvider))]
    public class MTGCardProvider : IWidgetProvider
    {
        private static List<Card> _booster = null;
        private static bool _isInitialized = false;
        private static ILogger _logger;

        public MTGCardProvider()
        {
            _logger = new Logger();
            _logger.DebugFormat($"Created new {typeof(MTGCardProvider)}.");
            LoadRavnicaAllegienceBooster();
        }

        public void LoadRavnicaAllegienceBooster()
        {
            _logger.DebugFormat("Loading RNA booster.");
            if (!_isInitialized)
            {
                _logger.DebugFormat($"{typeof(MTGCardProvider)} is not yet initialized.");
                SetService setService = new SetService();
                var result = setService.GenerateBooster("RNA");
                _logger.DebugFormat("Response received from API.");

                if (result.IsSuccess)
                {
                    _logger.DebugFormat($"{nameof(result)} returned success.");
                    _booster = result.Value;
                    _isInitialized = true;
                    _logger.DebugFormat($"{typeof(MTGCardProvider)} is initialized.");
                }
            }
            else
            {
                _logger.DebugFormat($"{typeof(MTGCardProvider)} is already initialized.");
            }
        }

        public Widget GetWidget()
        {
            if (_isInitialized)
            {
                _logger.DebugFormat($"{typeof(MTGCardProvider)} is already initialized. Returning random card from booster.");
                Random rng = new Random();
                _logger.DebugFormat($"Returning Card from {nameof(_booster)} at index {rng}.");
                return _booster[rng.Next(0, _booster.Count)].ToWidget();
            }
            else
            {
                _logger.DebugFormat($"{typeof(MTGCardProvider)} is not already initialized. Returning random card from booster.");
                LoadRavnicaAllegienceBooster();
                if (_isInitialized)
                {
                    _logger.DebugFormat($"{typeof(MTGCardProvider)} is now initialized. Returning random card from booster.");
                    Random rng = new Random();
                    _logger.DebugFormat($"Returning Card from {nameof(_booster)} at index {rng}.");
                    return _booster[rng.Next(0, _booster.Count)].ToWidget();
                }
                else
                {
                    _logger.DebugFormat($"{typeof(MTGCardProvider)} is still not initialized. Returning random card from booster. Returning placeholder Widget.");
                    return new Widget
                    {
                        Header = $"{typeof(MTGCardProvider)} is not initialized."
                    };
                }
            }
        }
    }
}

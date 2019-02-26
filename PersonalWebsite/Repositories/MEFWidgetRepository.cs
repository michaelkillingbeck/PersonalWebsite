using CommonComponents;
using PersonalWebsite.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using CommonComponents.Interfaces;

namespace PersonalWebsite.Repositories
{
    public class MEFWidgetRepository : IWidgetRepository
    {
        private static AggregateCatalog _catalog = null;
        private static CompositionContainer _container = null;
        private static ILogger _logger = null;
        [ImportMany(typeof(IWidgetProvider))]
        public List<IWidgetProvider> Providers { get; set; }

        public MEFWidgetRepository(ILogger logger = null)
        {
            if (_logger is null)
            {
                _logger = logger ?? new Logger();
            }

            if (_catalog is null)
            {
                _catalog = new AggregateCatalog();
                _catalog.Catalogs.Add(new DirectoryCatalog(@"C:\Github Code\PersonalWebsite\Components"));
                _container = new CompositionContainer(_catalog);
            }

            _logger.DebugFormat($"{nameof(Providers)} is null. Generating new providers.");
            Providers = new List<IWidgetProvider>();
            _container.ComposeParts(this);
            _logger.DebugFormat($"Found {Providers.Count} providers.");
        }

        public Widget GetRandomWidget()
        {
            Random rng = new Random();
            var index = rng.Next(0, Providers.Count);
            _logger.DebugFormat($"Returning Widget from Provider at index {rng}.");

            return Providers[index].GetWidget();
        }
    }
}
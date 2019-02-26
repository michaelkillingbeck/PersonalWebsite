using CommonComponents;
using CommonComponents.Interfaces;
using MaikusWidgetProvider.Interfaces;
using MaikusWidgetProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MaikusWidgetProvider.Repositories
{
    public class JSONMaikuRepository : IMaikuRepository
    {
        private string _fileName = @"C:\Github Code\PersonalWebsite\MaikusWidgetProvider\Maikus.json";
        private ILogger _logger;
        private static bool _isInitialized = false;
        private static List<Maiku> _maikus = new List<Maiku>();

        public JSONMaikuRepository(ILogger logger = null)
        {
            _logger = logger ?? new Logger();

            if (File.Exists(_fileName))
            {
                _logger.DebugFormat("JSON Maikus file was found.");
                LoadMaikus();
            }
            else
            {
                _logger.DebugFormat($"Maikus file was not found at : {_fileName}");
            }
        }

        public Maiku GetRandomMaiku()
        {
            Random rng = new Random();
            var index = rng.Next(0, _maikus.Count);
            _logger.DebugFormat($"Returning Maiku from index {rng}.");

            return _maikus[index];
        }

        public bool IsInitialized()
        {
            _logger.DebugFormat($"{typeof(JSONMaikuRepository)} is {(_isInitialized ? "" : "not")} initialized.");
            return _isInitialized;
        }

        public void LoadMaikus()
        {
            _logger.DebugFormat($"{typeof(JSONMaikuRepository)} is loading Maikus.");
            if (!_isInitialized)
            {
                _maikus = JsonConvert.DeserializeObject<List<Maiku>>(File.ReadAllText(_fileName));
                _logger.DebugFormat($"Loaded Maikus. Setting {nameof(_isInitialized)} to True.");
                _isInitialized = true;
            }
        }
    }
}

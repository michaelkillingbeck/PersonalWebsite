using System;

namespace CommonComponents
{
    public class Widget
    {
        private string[] _content = new string[3];

        public string Header { get; set; }

        public string[] Content => _content;

        public void SetContent(string[] content)
        {
            if (content.Length > 3)
            {
                throw new ArgumentException($"Parameter {nameof(content)} has too many elements.");
            }

            _content = content;
        }
    }
}

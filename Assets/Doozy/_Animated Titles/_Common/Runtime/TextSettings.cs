using System;

namespace Doozy.Sandbox.AnimatedTitles
{
    [Serializable]
    public class TextSettings
    {
        public string gameObjectName { get; }
        public string defaultText { get; }
        public int defaultFontSize { get; }
            
        public string GameObjectName;
        public string Text;
        public int FontSize;

        public TextSettings(string gameObjectName, string defaultText, int defaultFontSize)
        {
            this.gameObjectName = gameObjectName;
            this.defaultText = defaultText;
            this.defaultFontSize = defaultFontSize;
            GameObjectName = gameObjectName;
            Text = defaultText;
            FontSize = defaultFontSize;
        }

        public void Reset()
        {
            GameObjectName = gameObjectName;
            Text = defaultText;
            FontSize = defaultFontSize;
        }
    }
}

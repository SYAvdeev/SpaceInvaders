using System.Collections.Generic;
using SpaceInvaders.Utility;

namespace SpaceInvaders.UI.UI
{
    public class UIModel
    {
        internal Pool<string, IUIScreen> ScreenPool { get; } = new();
        internal Dictionary<string, IUIScreen> CurrentOpenedScreens { get; } = new();
    }
}
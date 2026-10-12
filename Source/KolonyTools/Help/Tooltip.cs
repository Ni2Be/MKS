using UnityEngine;

namespace KolonyTools
{
    /// <summary>
    /// Draws the tooltip of the hovered control inside an IMGUI window.
    /// </summary>
    /// <remarks>
    /// Give a control a tooltip by drawing it with a <see cref="GUIContent"/> that has one,
    /// then call <see cref="Draw(Rect)"/> as the last thing in the window function.
    /// </remarks>
    public static class Tooltip
    {
        private const float DELAY = 0.4f;
        private const float MAX_WIDTH = 280f;
        private const float MARGIN = 4f;

        private static GUIStyle _style;
        private static string _lastText = string.Empty;
        private static int _lastFrame;
        private static float _hoverStart;

        /// <summary>
        /// Draws the current tooltip, if there is one, clamped to the bounds of the window.
        /// </summary>
        /// <param name="windowRect">The screen rect of the window being drawn.</param>
        public static void Draw(Rect windowRect)
        {
            if (Event.current.type != EventType.Repaint)
                return;

            var text = GUI.tooltip;
            if (string.IsNullOrEmpty(text))
                return;

            // Don't let a tooltip leak into the windows drawn after this one
            GUI.tooltip = string.Empty;

            var mouse = Event.current.mousePosition;
            if (mouse.x < 0 || mouse.y < 0 || mouse.x > windowRect.width || mouse.y > windowRect.height)
                return;

            // Wait a moment before showing a tooltip, so they don't flicker while the mouse moves across the window
            var frame = Time.frameCount;
            if (text != _lastText || frame - _lastFrame > 1)
            {
                _lastText = text;
                _hoverStart = Time.realtimeSinceStartup;
            }
            _lastFrame = frame;

            if (Time.realtimeSinceStartup - _hoverStart < DELAY)
                return;

            InitStyle();

            var content = new GUIContent(text);
            var width = Mathf.Min(MAX_WIDTH, windowRect.width - MARGIN * 2, _style.CalcSize(content).x);
            var height = _style.CalcHeight(content, width);

            // Show below and to the right of the cursor, unless that would leave the window
            var x = mouse.x + 14f;
            if (x + width > windowRect.width - MARGIN)
                x = windowRect.width - MARGIN - width;

            var y = mouse.y + 20f;
            if (y + height > windowRect.height - MARGIN)
                y = mouse.y - height - 6f;

            GUI.Label(new Rect(Mathf.Max(MARGIN, x), Mathf.Max(MARGIN, y), width, height), content, _style);
        }

        private static void InitStyle()
        {
            if (_style != null && _style.normal.background != null)
                return;

            // Dark box with a 1px light border
            var border = new Color(0.55f, 0.55f, 0.55f, 1f);
            var fill = new Color(0.08f, 0.08f, 0.08f, 0.97f);
            var background = new Texture2D(3, 3, TextureFormat.ARGB32, false);
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    background.SetPixel(x, y, x == 1 && y == 1 ? fill : border);
                }
            }
            background.filterMode = FilterMode.Point;
            background.Apply();

            _style = new GUIStyle(HighLogic.Skin.label)
            {
                alignment = TextAnchor.UpperLeft,
                border = new RectOffset(1, 1, 1, 1),
                fontSize = 12,
                margin = new RectOffset(0, 0, 0, 0),
                padding = new RectOffset(7, 7, 5, 5),
                richText = true,
                stretchHeight = false,
                stretchWidth = false,
                wordWrap = true
            };
            _style.normal.background = background;
            _style.normal.textColor = Color.white;
        }
    }
}

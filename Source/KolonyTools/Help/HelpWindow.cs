using UnityEngine;
using USITools.UI;

namespace KolonyTools
{
    /// <summary>
    /// Displays the help topics from <see cref="HelpText"/> in a window next to the Kolonization Dashboard.
    /// </summary>
    public class HelpWindow : Window
    {
        private const float TOPIC_LIST_WIDTH = 150f;

        private GUIStyle _bodyStyle;
        private GUIStyle _topicStyle;
        private GUIStyle _selectedTopicStyle;
        private Vector2 _scrollPosition = Vector2.zero;
        private int _selectedTopic;

        public int SelectedTopic
        {
            get { return _selectedTopic; }
        }

        public HelpWindow()
            : base("MKS Help", 520, 460)
        {
        }

        /// <summary>
        /// Show a topic, opening the window if necessary.
        /// </summary>
        /// <param name="topic">Index into <see cref="HelpText.Topics"/>.</param>
        public void ShowTopic(int topic)
        {
            SelectTopic(topic);
            SetVisible(true);
        }

        /// <summary>
        /// Switch to a topic without changing the visibility of the window.
        /// </summary>
        /// <param name="topic">Index into <see cref="HelpText.Topics"/>.</param>
        public void SelectTopic(int topic)
        {
            if (topic < 0 || topic >= HelpText.Topics.Length)
                topic = HelpText.TOPIC_OVERVIEW;

            if (topic != _selectedTopic)
            {
                _selectedTopic = topic;
                _scrollPosition = Vector2.zero;
            }
        }

        /// <summary>
        /// Place the window beside another window, on whichever side has room for it.
        /// </summary>
        public void MoveNextTo(Rect other)
        {
            var x = other.xMax + 5f;
            if (x + _windowPos.width > Screen.width)
                x = Mathf.Max(0f, other.x - _windowPos.width - 5f);

            _windowPos.x = x;
            _windowPos.y = other.y;
        }

        protected override void ConfigureStyles()
        {
            base.ConfigureStyles();

            if (_bodyStyle == null)
            {
                _bodyStyle = new GUIStyle(HighLogic.Skin.label)
                {
                    alignment = TextAnchor.UpperLeft,
                    richText = true,
                    wordWrap = true
                };
                _bodyStyle.normal.textColor = Color.white;

                _topicStyle = new GUIStyle(HighLogic.Skin.button)
                {
                    alignment = TextAnchor.MiddleLeft,
                    fontSize = 12,
                    wordWrap = false
                };

                // The selected topic keeps the pressed look of the button
                _selectedTopicStyle = new GUIStyle(_topicStyle);
                _selectedTopicStyle.normal = _selectedTopicStyle.active;
                _selectedTopicStyle.hover = _selectedTopicStyle.active;
            }
        }

        /// <summary>
        /// Called by <see cref="MonoBehaviour"/>.OnGUI to render the UI.
        /// </summary>
        /// <param name="windowId"></param>
        protected override void DrawWindowContents(int windowId)
        {
            GUILayout.BeginHorizontal();

            // Topic list
            GUILayout.BeginVertical(GUILayout.Width(TOPIC_LIST_WIDTH));
            for (int i = 0; i < HelpText.Topics.Length; i++)
            {
                var style = i == _selectedTopic ? _selectedTopicStyle : _topicStyle;
                if (GUILayout.Button(HelpText.Topics[i].Title, style, GUILayout.Width(TOPIC_LIST_WIDTH)))
                    SelectTopic(i);
            }
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Close", UIHelper.buttonStyle, GUILayout.Width(TOPIC_LIST_WIDTH)))
                SetVisible(false);
            GUILayout.EndVertical();

            // Selected topic
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, UIHelper.scrollStyle);
            GUILayout.Label(HelpText.Topics[_selectedTopic].Body, _bodyStyle);
            GUILayout.EndScrollView();

            GUILayout.EndHorizontal();
        }
    }
}

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UI.Editor
{
    [CustomEditor(typeof(MenuBase), true)]
    public class MenuBaseEditor : UnityEditor.Editor
    {
        private MenuBase _menuBase;

        private void OnEnable()
        {
            _menuBase = (MenuBase) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Show"))
                _menuBase.Internal_Show();
            if (GUILayout.Button("Hide"))
                _menuBase.Internal_Hide();
        }
    }
}
#endif
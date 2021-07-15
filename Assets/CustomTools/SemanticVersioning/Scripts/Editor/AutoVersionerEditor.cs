using CustomTools.SemanticVersioning.Scripts.Enum;
using CustomTools.SemanticVersioning.Scripts.Versioning;
using UnityEditor;
using UnityEngine;

namespace CustomTools.SemanticVersioning.Scripts.Editor
{
    [CustomEditor(typeof(AutoVersioner))]
    public class AutoVersionerEditor : UnityEditor.Editor
    {
        #region Builtin Methods

        private void OnPreSceneGUI()
        {
            SetVersion();
        }

        private void OnSceneDrag(SceneView sceneView, int index)
        {
            SetVersion();
        }

        private void OnSceneGUI()
        {
            SetVersion();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AutoVersioner autoVersioner = (AutoVersioner) target;

            autoVersioner.SetVersionTextComponent();

            EditorGUILayout.Space();
            autoVersioner.GetVersioner();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"Major Version Info : {autoVersioner.VersionData.Major}");
            if (GUILayout.Button("+", GUILayout.Width(25), GUILayout.Height(25)))
            {
                autoVersioner.SetMajorUpdate();
                PressedAnyButton();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"Minor Version Info : {autoVersioner.VersionData.Minor}");
            if (GUILayout.Button("+", GUILayout.Width(25), GUILayout.Height(25)))
            {
                autoVersioner.SetMinorUpdate();
                PressedAnyButton();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"Patch Version Info : {autoVersioner.VersionData.Patch}");
            if (GUILayout.Button("+", GUILayout.Width(25), GUILayout.Height(25)))
            {
                autoVersioner.SetPatchUpdate();
                PressedAnyButton();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"Pre-release Version Info : {autoVersioner.VersionData.Prerelease}");

            autoVersioner.SetPrerelease();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField($"Build Version Info : {autoVersioner.VersionData.Build}");
            if (GUILayout.Button("+", GUILayout.Width(25), GUILayout.Height(25)))
            {
                autoVersioner.SetBuild();
                PressedAnyButton();
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button(" RESET"))
            {
                autoVersioner.ResetVersionData();
                autoVersioner._releaseType = ReleaseType.None;
                PressedAnyButton();
            }

            EditorGUILayout.Space();
            autoVersioner.SetVersionText();
        }

        private void OnValidate()
        {
            SetVersion();
        }

        #endregion

        #region Custom Methods

        private void SetVersion()
        {
            AutoVersioner autoVersioner = (AutoVersioner) target;

            autoVersioner.GetVersioner();
            autoVersioner.SetVersionText();
        }

        private void PressedAnyButton()
        {
            AutoVersioner autoVersioner = (AutoVersioner) target;

            if (PrefabUtility.IsAnyPrefabInstanceRoot(autoVersioner.gameObject))
            {
                PrefabUtility.ApplyPrefabInstance(autoVersioner.gameObject, InteractionMode.AutomatedAction);
            }
        }

        #endregion
    }
}
using System.Text;
using CustomTools.SemanticVersioning.Scripts.Enum;
using CustomTools.SemanticVersioning.Scripts.Scriptable_Objects;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CustomTools.SemanticVersioning.Scripts.Versioning
{
    [RequireComponent(typeof(Text))]
    [ExecuteInEditMode]
    public class AutoVersioner : MonoBehaviour
    {
        #region Fields And Properties

        private Text _versionText;

        public Text VersionText
        {
            get => _versionText;
        }

        private VersionScriptableObject _versionData;

        public VersionScriptableObject VersionData
        {
            get => _versionData;
            private set => _versionData = value;
        }


        public ReleaseType _releaseType;

        #endregion

        #region Builtin Methods

        private void Start()
        {
#if UNITY_EDITOR

            GetVersioner();
            _versionData.SetBuild();

            if (_versionText == null)
            {
                _versionText = GetComponent<Text>();
            }

            SetVersionText();
            //
            // VersionData version = new VersionData(0,1,1,ReleaseType.None,10);
            //
            // VersionData secondVersion = new VersionData(1,1,1,ReleaseType.None,10);
            //
            //
            // Debug.Log(version.IsOlder(secondVersion));
        
            if (PrefabUtility.IsAnyPrefabInstanceRoot(gameObject))
            {
                PrefabUtility.ApplyPrefabInstance(gameObject, InteractionMode.AutomatedAction);
            }
#endif
        }

        #endregion

        #region Custom Methods

        public void SetMajorUpdate()
        {
            GetVersioner();

            _versionData.SetMajorUpdate();
            SetVersionText();
        }

        public void SetMinorUpdate()
        {
            GetVersioner();

            _versionData.SetMinorUpdate();
            SetVersionText();
        }

        public void SetPatchUpdate()
        {
            GetVersioner();

            _versionData.SetPatchUpdate();
            SetVersionText();
        }

        public void SetPrerelease()
        {
            GetVersioner();

            _versionData.SetPrerelease(_releaseType);
            SetVersionText();
        }

        public void SetBuild()
        {
            GetVersioner();
            _versionData.SetBuild();
            SetVersionText();
        }

        public void GetVersioner()
        {
            _versionData = Resources.Load<VersionScriptableObject>(
                "SOC/Versioner");
        }

        public void SetVersionText()
        {
            if (VersionText == null)
            {
                Debug.LogWarning("Version text cannot be null in `AutoVersioner` class..");
                return;
            }

            string preRelease = _versionData.Prerelease == ReleaseType.None ? "" : _versionData.Prerelease.ToString();
            StringBuilder versionSb = new StringBuilder();

            versionSb.Append(_versionData.Major);
            versionSb.Append(".");
            versionSb.Append(_versionData.Minor);
            versionSb.Append(".");
            versionSb.Append(_versionData.Patch);
            versionSb.Append(".");
            versionSb.Append(_versionData.Build);
            versionSb.Append(preRelease);

            _versionText.text = versionSb.ToString();
            SetScriptableObjectDirty();
        }

        private void SetScriptableObjectDirty()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(_versionData);
#endif
        }

#if UNITY_EDITOR
        public void SetVersionTextComponent()
        {
            _versionText = GetComponent<Text>();
        }
#endif

        public void ResetVersionData()
        {
            _versionData.ResetScriptableObject();
            SetVersionText();
        }

        #endregion
    }
}
using UnityEditor;
using UnityEngine;

namespace Generals.Editor
{
    /// <summary>
    /// Автоматизация сборки проекта.
    /// </summary>
    public static class BuildPipeline
    {
        [MenuItem("Build/Build Android")]
        public static void BuildAndroid()
        {
            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = new[] { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/BattleScene.unity" };
            options.locationPathName = "Builds/Android/GeneralsMobile.apk";
            options.target = BuildTarget.Android;
            options.options = BuildOptions.None;

            BuildPipeline.BuildPlayer(options);
            Debug.Log("[Build] Сборка Android завершена.");
        }

        [MenuItem("Build/Build iOS")]
        public static void BuildIOS()
        {
            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = new[] { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/BattleScene.unity" };
            options.locationPathName = "Builds/iOS/GeneralsMobile";
            options.target = BuildTarget.iOS;
            options.options = BuildOptions.None;

            BuildPipeline.BuildPlayer(options);
            Debug.Log("[Build] Сборка iOS завершена.");
        }
    }
}

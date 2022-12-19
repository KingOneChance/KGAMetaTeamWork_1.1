using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;
using System;

// Output the build size or a failure depending on BuildPlayer.

public class BuildPlayer : MonoBehaviour
{
    [MenuItem("Build/Build AOS")]
    public static void Build_AOS_Debug()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity"};
        //buildPlayerOptions.locationPathName = "BuildT";
        buildPlayerOptions.locationPathName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
}
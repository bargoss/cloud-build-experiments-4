
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildUtils : MonoBehaviour
{
    const string BuildsDir = "Builds";
    
    [MenuItem("ByteTyper/Build/Windows", false, 0)]
    public static void BuildWindows()
    {
        if(!Directory.Exists(BuildsDir))
        {
            Directory.CreateDirectory(BuildsDir);
        }
        
        Log($"Starting build");
        
        BuildPipeline.BuildPlayer(GetScenePaths(), Path.Combine(BuildsDir, "BuildTest.exe"), BuildTarget.StandaloneWindows64, BuildOptions.None);
        
        Log($"Build finished?");
    }

    private static EditorBuildSettingsScene[] GetScenePaths()
    {
        var scenes = new List<EditorBuildSettingsScene>();
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                scenes.Add(scene);
            }
        }
        return scenes.ToArray();
    }

    private static void Log(string line)
    {
        Debug.Log("BYTE: " + line);
    }
}
#endif
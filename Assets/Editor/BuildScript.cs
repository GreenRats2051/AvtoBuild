using UnityEditor;

public class BuildScript
{
    [MenuItem("Build/Build All")]
    public static void BuildAll()
    {
        BuildWindows();
        BuildAndroid();

        EditorUtility.DisplayDialog("Build Complete", "All builds completed!", "OK");
    }

    [MenuItem("Build/Windows")]
    public static void BuildWindows()
    {
        BuildPipeline.BuildPlayer(GetScenesFromBuildSettings(), "Builds/Windows/Game.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    [MenuItem("Build/Android")]
    public static void BuildAndroid()
    {
        BuildPipeline.BuildPlayer(GetScenesFromBuildSettings(), "Builds/Android/Game.apk", BuildTarget.Android, BuildOptions.None);
    }

    private static string[] GetScenesFromBuildSettings()
    {
        string[] scenes = new string[EditorBuildSettings.scenes.Length];

        for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }

        return scenes;
    }
}
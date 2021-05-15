using UnityEditor;
using UnityEngine;

public class MENUCUSTOMIZATION : MonoBehaviour
{   

    //ACTIONS ----------------------------------------------------------------------------
    [MenuItem("Assets/Create/Actions/SceneTransition", false, 0)]
    public static void NewST()
    {
        ScriptableObject st = ScriptableObject.CreateInstance("SceneTransition");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New Scene Transition.asset";
        ProjectWindowUtil.CreateAsset(st, path);
    }
    [MenuItem("Assets/Create/Actions/CampaignStarter", false, 0)]
    public static void NewCS()
    {
        ScriptableObject cs = ScriptableObject.CreateInstance("CampaignStarter");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New Campaign Starter.asset";
        ProjectWindowUtil.CreateAsset(cs, path);
    }
    [MenuItem("Assets/Create/Actions/LevelLoad", false, 0)]
    public static void NewLL()
    {
        ScriptableObject ll = ScriptableObject.CreateInstance("LevelLoad");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New Level Load.asset";
        ProjectWindowUtil.CreateAsset(ll, path);
    }
    [MenuItem("Assets/Create/Actions/GameOver", false, 0)]
    public static void NewGO()
    {
        ScriptableObject go = ScriptableObject.CreateInstance("GameOver");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/GameOver.asset";
        ProjectWindowUtil.CreateAsset(go, path);
    }

    //VALUES------------------------------------------------------------------------------
    [MenuItem("Assets/Create/Values/IntValue", false, 0)]
    public static void NewIV()
    {
        ScriptableObject iv = ScriptableObject.CreateInstance("IntValue");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New IntValue.asset";
        ProjectWindowUtil.CreateAsset(iv, path);
    }
    [MenuItem("Assets/Create/Values/FloatValue", false, 0)]
    public static void NewFV()
    {
        ScriptableObject fv = ScriptableObject.CreateInstance("FloatValue");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New FloatValue.asset";
        ProjectWindowUtil.CreateAsset(fv, path);
    }
    [MenuItem("Assets/Create/Values/BoolValue", false, 0)]
    public static void NewBV()
    {
        ScriptableObject bv = ScriptableObject.CreateInstance("BoolValue");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New BoolValue.asset";
        ProjectWindowUtil.CreateAsset(bv, path);
    }
    [MenuItem("Assets/Create/Values/SpriteValue", false, 0)]
    public static void NewSV()
    {
        ScriptableObject sv = ScriptableObject.CreateInstance("SpriteValue");
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        path += "/New SpriteValue.asset";
        ProjectWindowUtil.CreateAsset(sv, path);
    }

    // [CustomEditor (typeof(ICallable))]
    // public class CallableInspector : Editor
    // {
    //     void OnInspectorGUI()
    //     {
    //         ICallable call  = (ICallable)target;
    //         ICallable.this = EditorGUILayout.ObjectField(ICallable.this, typeof(ICallable), false);
    //         DrawDefaultInspector();
    //     }
    // }
}

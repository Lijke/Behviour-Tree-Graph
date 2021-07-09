using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;



public class BehaviourTreeEditior : EditorWindow
{
    BehviourTreeView treeView;
    InspektorView inspektorView;
    [MenuItem("BehaviourTreeEditior/Editor ...")]
    public static void OpenWindow()
    {
        BehaviourTreeEditior wnd = GetWindow<BehaviourTreeEditior>();
        wnd.titleContent = new GUIContent("BehaviourTreeEditior");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;


        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BehaviourTreeEditior.uxml");
        visualTree.CloneTree(root);
        

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviourTreeEditior.uss");
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehviourTreeView>();
        inspektorView = root.Q<InspektorView>();
        treeView.OnNodeSelected = OnNodeSelectionChange ;
        OnSelectionChange();
    }
    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;
        if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
        {
            treeView.PopulateView(tree);
        }
    }

    void OnNodeSelectionChange(NodeView node)
    {
        inspektorView.UpdateSelection(node);
    }
}
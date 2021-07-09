using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEditor;

public class InspektorView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<InspektorView, VisualElement.UxmlTraits> { }
    Editor editor;
    public InspektorView()
    {

    }
    internal void UpdateSelection(NodeView nodeView)
    {
        Clear();
        UnityEngine.Object.DestroyImmediate(editor);
        editor = Editor.CreateEditor(nodeView.node);
        IMGUIContainer container = new IMGUIContainer(() =>{ editor.OnInspectorGUI(); });
        Add(container);     
    }
}

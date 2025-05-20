using UnityEditor;
using UnityEngine;

/// <summary>
/// Colorful Hierarchy Window Group Header
/// Author: github.com/farukcan
/// Thanks for concept of idea :
/// http://diegogiacomelli.com.br/unitytips-hierarchy-window-group-header
/// Sample GameObject Names: "#red CAMERA" , "#" , "##E7A5F6 Hex" , "# "
/// </summary>
///
namespace Toolkit
{
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        static HierarchyWindowGroupHeader()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null && gameObject.name.StartsWith("#", System.StringComparison.Ordinal))
            {
                string colorName = gameObject.name.Substring(1).Split(' ')[0];
                Color color = Color.gray;
                
                if(ColorUtility.TryParseHtmlString(colorName.ToLower(), out Color outColor)){
                    color = outColor;
                }
                
                Rect nextSelectionRect = selectionRect;
                EditorGUI.DrawRect(selectionRect, color);

#if UNITY_2022_1_OR_NEWER
           
                nextSelectionRect.y -= 3.5f;
                EditorGUI.DropShadowLabel(nextSelectionRect, gameObject.name.Replace("#"+colorName+" ", ""));    
#else 
                EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("#"+colorName+" ", ""));
#endif
            }
        }
    }
}
using HK.Ferry.FieldSystems;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FieldDataWindow : EditorWindow
    {
        private int width = 0;

        private int height = 0;

        private SerializedObject serializedFieldData;

        private int editingCellIndex = -1;

        [MenuItem("Window/Ferry/FieldData")]
        private static void Open()
        {
            GetWindow<FieldDataWindow>();
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        {
            Selection.selectionChanged -= OnSelectionChanged;
        }

        private void OnGUI()
        {
            var target = Selection.activeObject;
            if (target is FieldData fieldData)
            {
                serializedFieldData.Update();
                using (var changeScope = new EditorGUI.ChangeCheckScope())
                {
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        DrawField(fieldData);
                        DrawCellEvent(fieldData);
                    }

                    if (changeScope.changed)
                    {
                        EditorUtility.SetDirty(fieldData);
                        Undo.RegisterCompleteObjectUndo(fieldData, "Change FieldData");
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("Please Select FieldData Asset");
            }
        }

        private void OnSelectionChanged()
        {
            Repaint();
            if (Selection.activeObject is FieldData fieldData)
            {
                width = fieldData.width;
                height = fieldData.height;
                serializedFieldData = new SerializedObject(fieldData);
                editingCellIndex = -1;
            }
        }

        private void DrawField(FieldData fieldData)
        {
            using (new EditorGUILayout.VerticalScope(GUILayout.Width(position.size.x / 2)))
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    width = EditorGUILayout.IntField("Width", width);
                    height = EditorGUILayout.IntField("Height", height);
                }

                if (GUILayout.Button("Change"))
                {
                    fieldData.width = width;
                    fieldData.height = height;
                }

                using (new EditorGUILayout.VerticalScope())
                {
                    for (var y = 0; y < fieldData.height; y++)
                    {
                        using (new EditorGUILayout.VerticalScope())
                        {
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                for (var x = 0; x < fieldData.width; x++)
                                {
                                    if (GUILayout.Button("", GUILayout.Width(20), GUILayout.Height(20)))
                                    {
                                        editingCellIndex = fieldData.cellDatas.FindIndex(c => c.x == x && c.y == y);
                                        if (editingCellIndex == -1)
                                        {
                                            editingCellIndex = fieldData.cellDatas.Count;
                                            var newCellData = new CellData
                                            {
                                                x = x,
                                                y = y
                                            };
                                            fieldData.cellDatas.Add(newCellData);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DrawCellEvent(FieldData fieldData)
        {
            if (editingCellIndex == -1)
            {
                return;
            }

            using (new EditorGUILayout.VerticalScope(GUILayout.Width(position.size.x / 2)))
            {
                serializedFieldData.Update();
                EditorGUILayout.PropertyField(serializedFieldData.FindProperty($"cellDatas.Array.data[{editingCellIndex}]"));
                serializedFieldData.ApplyModifiedProperties();
            }
        }
    }
}

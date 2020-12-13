using HK.Ferry.BattleSystems;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    [CustomEditor(typeof(BattleSimulator))]
    public sealed class BattleSimulatorEditor : Editor
    {
        private BattleSimulator simulator;

        private int beforeDamage;

        private void OnEnable()
        {
            this.simulator = (BattleSimulator)target;
        }

        public override void OnInspectorGUI()
        {
            using (var isChange = new EditorGUI.ChangeCheckScope())
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    DrawCharacterStatus(simulator.attacker);
                    DrawCharacterStatus(simulator.defenser);
                }
                Line();
                var damage = BattleCalcurator.GetDamage(simulator.attacker, simulator.defenser);
                GUILayout.Label($"{beforeDamage} -> {damage}({damage - beforeDamage})");
                Line();
                if (GUILayout.Button("Reset Power"))
                {
                    simulator.attacker.greatPower.Value = 1.0f;
                    simulator.attacker.artistPower.Value = 1.0f;
                    simulator.attacker.wisdomPower.Value = 1.0f;
                    simulator.defenser.greatPower.Value = 1.0f;
                    simulator.defenser.artistPower.Value = 1.0f;
                    simulator.defenser.wisdomPower.Value = 1.0f;
                }

                using (new EditorGUILayout.HorizontalScope())
                {
                    DrawModifyButton(simulator.attacker, simulator.defenser);
                    DrawModifyButton(simulator.defenser, simulator.attacker);
                }

                if (isChange.changed)
                {
                    beforeDamage = damage;
                    EditorUtility.SetDirty(simulator);
                }
            }
        }

        private void Line()
        {
            GUILayout.Box("", GUILayout.Height(1), GUILayout.ExpandWidth(true));
        }

        private void DrawCharacterStatus(CharacterStatus s)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                s.attack.Value = EditorGUILayout.IntField("Attack", s.attack.Value);
                s.greatPower.Value = EditorGUILayout.FloatField("Great Power", s.greatPower.Value);
                s.artistPower.Value = EditorGUILayout.FloatField("Brave Power", s.artistPower.Value);
                s.wisdomPower.Value = EditorGUILayout.FloatField("Neatly Power", s.wisdomPower.Value);
            }
        }

        private void DrawModifyButton(CharacterStatus owner, CharacterStatus target)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("g += 0.1"))
                    {
                        owner.greatPower.Value += 0.1f;
                    }
                    if (GUILayout.Button("g -= 0.1"))
                    {
                        owner.greatPower.Value -= 0.1f;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("b += 0.1"))
                    {
                        owner.artistPower.Value += 0.1f;
                    }
                    if (GUILayout.Button("b -= 0.1"))
                    {
                        owner.artistPower.Value -= 0.1f;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("n += 0.1"))
                    {
                        owner.wisdomPower.Value += 0.1f;
                    }
                    if (GUILayout.Button("n -= 0.1"))
                    {
                        owner.wisdomPower.Value -= 0.1f;
                    }
                }
                if (GUILayout.Button("g += 0.3 b -= 0.1"))
                {
                    owner.greatPower.Value += 0.3f;
                    owner.artistPower.Value -= 0.1f;
                }
                if (GUILayout.Button("b += 0.3 n -= 0.1"))
                {
                    owner.artistPower.Value += 0.3f;
                    owner.wisdomPower.Value -= 0.1f;
                }
                if (GUILayout.Button("n += 0.3 g -= 0.1"))
                {
                    owner.wisdomPower.Value += 0.3f;
                    owner.greatPower.Value -= 0.1f;
                }
            }
        }
    }
}

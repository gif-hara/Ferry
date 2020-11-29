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
                var newAttacker = new CharacterStatus(simulator.attacker);
                var newDefenser = new CharacterStatus(simulator.defenser);
                using (new EditorGUILayout.HorizontalScope())
                {
                    newAttacker = DrawCharacterStatus(newAttacker);
                    newDefenser = DrawCharacterStatus(newDefenser);
                }
                Line();
                var damage = BattleCalcurator.GetDamage(simulator.attacker, simulator.defenser);
                GUILayout.Label($"{beforeDamage} -> {damage}({damage - beforeDamage})");
                Line();
                if (GUILayout.Button("Reset Power"))
                {
                    newAttacker.greatPower = 1.0f;
                    newAttacker.bravePower = 1.0f;
                    newAttacker.neatlyPower = 1.0f;
                    newDefenser.greatPower = 1.0f;
                    newDefenser.bravePower = 1.0f;
                    newDefenser.neatlyPower = 1.0f;
                }

                using (new EditorGUILayout.HorizontalScope())
                {
                    newAttacker = DrawModifyButton(newAttacker, newDefenser);
                    newDefenser = DrawModifyButton(newDefenser, newAttacker);
                }

                if (isChange.changed)
                {
                    beforeDamage = damage;
                    simulator.attacker = newAttacker;
                    simulator.defenser = newDefenser;
                    EditorUtility.SetDirty(simulator);
                }
            }
        }

        private void Line()
        {
            GUILayout.Box("", GUILayout.Height(1), GUILayout.ExpandWidth(true));
        }

        private CharacterStatus DrawCharacterStatus(CharacterStatus s)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                s.attack = EditorGUILayout.IntField("Attack", s.attack);
                s.greatPower = EditorGUILayout.FloatField("Great Power", s.greatPower);
                s.bravePower = EditorGUILayout.FloatField("Brave Power", s.bravePower);
                s.neatlyPower = EditorGUILayout.FloatField("Neatly Power", s.neatlyPower);
            }

            return s;
        }

        private CharacterStatus DrawModifyButton(CharacterStatus owner, CharacterStatus target)
        {
            using (new EditorGUILayout.VerticalScope())
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("g += 0.1"))
                    {
                        owner.greatPower += 0.1f;
                    }
                    if (GUILayout.Button("g -= 0.1"))
                    {
                        owner.greatPower -= 0.1f;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("b += 0.1"))
                    {
                        owner.bravePower += 0.1f;
                    }
                    if (GUILayout.Button("b -= 0.1"))
                    {
                        owner.bravePower -= 0.1f;
                    }
                }
                using (new EditorGUILayout.HorizontalScope())
                {
                    if (GUILayout.Button("n += 0.1"))
                    {
                        owner.neatlyPower += 0.1f;
                    }
                    if (GUILayout.Button("n -= 0.1"))
                    {
                        owner.neatlyPower -= 0.1f;
                    }
                }
                if (GUILayout.Button("g += 0.3 b -= 0.1"))
                {
                    owner.greatPower += 0.3f;
                    owner.bravePower -= 0.1f;
                }
                if (GUILayout.Button("b += 0.3 n -= 0.1"))
                {
                    owner.bravePower += 0.3f;
                    owner.neatlyPower -= 0.1f;
                }
                if (GUILayout.Button("n += 0.3 g -= 0.1"))
                {
                    owner.neatlyPower += 0.3f;
                    owner.greatPower -= 0.1f;
                }
            }

            return owner;
        }
    }
}

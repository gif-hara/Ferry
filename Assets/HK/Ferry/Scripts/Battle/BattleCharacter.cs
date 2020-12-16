using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BattleCharacter
    {
        public CharacterSpec CurrentSpec
        {
            get;
            private set;
        }

        public CharacterSpec BaseSpec
        {
            get;
            private set;
        }

        public BattleCharacter(CharacterSpec characterSpec)
        {
            CurrentSpec = new CharacterSpec(characterSpec);
            BaseSpec = characterSpec;
        }

        public float HitPointRate => (float)CurrentSpec.Status.hitPoint.Value / BaseSpec.Status.hitPoint.Value;

        public void TakeDamage(int value)
        {
            CurrentSpec.Status.hitPoint.Value -= value;
        }

        public bool IsDead => CurrentSpec.Status.hitPoint.Value <= 0;
    }
}

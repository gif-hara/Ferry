using System.Collections.Generic;
using HK.Ferry.ActorControllers;
using HK.Ferry.Extensions;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;
using static HK.Ferry.Constants;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// <see cref="ITerm"/>の抽象クラス
    /// </summary>
    public abstract class Term : ITerm
    {
        [SerializeField, TermsPopup]
        protected string descriptionLocalizeKey = default;

        [SerializeField]
        private TargetType targetType = default;

        public virtual string Description => this.descriptionLocalizeKey.AsLocalize();

        public virtual TargetType TargetType => this.targetType;

        public abstract IReadOnlyList<Actor> GetTargets(IReadOnlyList<Actor> targets);
    }
}

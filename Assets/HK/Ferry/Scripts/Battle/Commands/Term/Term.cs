using HK.Ferry.Extensions;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.CommandData.Terms
{
    /// <summary>
    /// <see cref="ITerm"/>の抽象クラス
    /// </summary>
    public abstract class Term : ITerm
    {
        [SerializeField, TermsPopup]
        protected string descriptionLocalizeKey = default;

        public virtual string Description => this.descriptionLocalizeKey.AsLocalize();
    }
}

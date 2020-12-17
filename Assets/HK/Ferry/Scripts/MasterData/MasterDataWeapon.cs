﻿using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.Ferry.Database
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "Ferry/MasterData/Weapon")]
    public sealed class MasterDataWeapon : MasterData<MasterDataWeapon, MasterDataWeapon.Record, string>
    {
        [Serializable]
        public class Record : IIdHolder<string>
        {
            [SerializeField, TermsPopup]
            private string name = default;

            public string Id => name;

            [SerializeField]
            private int attack = default;
            public int Attack => attack;
        }
    }
}

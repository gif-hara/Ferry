using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static class UI
		{
			public static string ArtistPower 		{ get{ return LocalizationManager.GetTranslation ("UI/ArtistPower"); } }
			public static string ArtistPowerFormat 		{ get{ return LocalizationManager.GetTranslation ("UI/ArtistPowerFormat"); } }
			public static string Attack 		{ get{ return LocalizationManager.GetTranslation ("UI/Attack"); } }
			public static string AttackFormat 		{ get{ return LocalizationManager.GetTranslation ("UI/AttackFormat"); } }
			public static string GreatPower 		{ get{ return LocalizationManager.GetTranslation ("UI/GreatPower"); } }
			public static string GreatPowerFormat 		{ get{ return LocalizationManager.GetTranslation ("UI/GreatPowerFormat"); } }
			public static string Sentence_AddPower 		{ get{ return LocalizationManager.GetTranslation ("UI/Sentence_AddPower"); } }
			public static string Sentence_Attack 		{ get{ return LocalizationManager.GetTranslation ("UI/Sentence_Attack"); } }
			public static string WisdomPower 		{ get{ return LocalizationManager.GetTranslation ("UI/WisdomPower"); } }
			public static string WisdomPowerFormat 		{ get{ return LocalizationManager.GetTranslation ("UI/WisdomPowerFormat"); } }
		}
	}

    public static class ScriptTerms
	{

		public static class UI
		{
		    public const string ArtistPower = "UI/ArtistPower";
		    public const string ArtistPowerFormat = "UI/ArtistPowerFormat";
		    public const string Attack = "UI/Attack";
		    public const string AttackFormat = "UI/AttackFormat";
		    public const string GreatPower = "UI/GreatPower";
		    public const string GreatPowerFormat = "UI/GreatPowerFormat";
		    public const string Sentence_AddPower = "UI/Sentence_AddPower";
		    public const string Sentence_Attack = "UI/Sentence_Attack";
		    public const string WisdomPower = "UI/WisdomPower";
		    public const string WisdomPowerFormat = "UI/WisdomPowerFormat";
		}
	}
}
using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static class UI
		{
			public static string ArtistPower 		{ get{ return LocalizationManager.GetTranslation ("UI/ArtistPower"); } }
			public static string Attack 		{ get{ return LocalizationManager.GetTranslation ("UI/Attack"); } }
			public static string GreatPower 		{ get{ return LocalizationManager.GetTranslation ("UI/GreatPower"); } }
			public static string Sentence_Attack 		{ get{ return LocalizationManager.GetTranslation ("UI/Sentence_Attack"); } }
			public static string WisdomPower 		{ get{ return LocalizationManager.GetTranslation ("UI/WisdomPower"); } }
		}
	}

    public static class ScriptTerms
	{

		public static class UI
		{
		    public const string ArtistPower = "UI/ArtistPower";
		    public const string Attack = "UI/Attack";
		    public const string GreatPower = "UI/GreatPower";
		    public const string Sentence_Attack = "UI/Sentence_Attack";
		    public const string WisdomPower = "UI/WisdomPower";
		}
	}
}
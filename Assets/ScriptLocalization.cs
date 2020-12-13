using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static class CommandName
		{
			public static string Attack01 		{ get{ return LocalizationManager.GetTranslation ("CommandName/Attack01"); } }
		}

		public static class CommandTerm
		{
			public static string Random 		{ get{ return LocalizationManager.GetTranslation ("CommandTerm/Random"); } }
		}

		public static class UI
		{
			public static string ArtistPower 		{ get{ return LocalizationManager.GetTranslation ("UI/ArtistPower"); } }
			public static string Attack 		{ get{ return LocalizationManager.GetTranslation ("UI/Attack"); } }
			public static string GreatPower 		{ get{ return LocalizationManager.GetTranslation ("UI/GreatPower"); } }
			public static string WisdomPower 		{ get{ return LocalizationManager.GetTranslation ("UI/WisdomPower"); } }
		}
	}

    public static class ScriptTerms
	{

		public static class CommandName
		{
		    public const string Attack01 = "CommandName/Attack01";
		}

		public static class CommandTerm
		{
		    public const string Random = "CommandTerm/Random";
		}

		public static class UI
		{
		    public const string ArtistPower = "UI/ArtistPower";
		    public const string Attack = "UI/Attack";
		    public const string GreatPower = "UI/GreatPower";
		    public const string WisdomPower = "UI/WisdomPower";
		}
	}
}
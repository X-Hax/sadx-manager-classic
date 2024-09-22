using IniFile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace SADXModManager
{
	public class GraphicsSettings
	{
		public enum FillMode
		{
			Stretch = 0,
			Fit = 1,
			Fill = 2
		}

		public enum TextureFilter
		{
			temp = 0,
		}

		public enum DisplayMode
		{
			Windowed,
			Fullscreen,
			Borderless,
			CustomWindow
		}

		[DefaultValue(1)]
		public int SelectedScreen { get; set; } = 1;             // SADXLoaderInfo.ScreenNum

		[DefaultValue(640)]
		public int HorizontalResolution { get; set; } = 640;    // SADXLoaderInfo.HorizontalResolution

		[DefaultValue(480)]
		public int VerticalResolution { get; set; } = 480;      // SADXLoaderInfo.VerticalResolution

		[DefaultValue(false)]
		public bool Enable43ResolutionRatio { get; set; } = false;          // SADXLoaderInfo.ForseAspectRatio

		[DefaultValue(true)]
		public bool EnableVsync { get; set; } = true;           // SADXLoaderInfo.EnableVSync

		[DefaultValue(true)]
		public bool EnablePauseOnInactive { get; set; } = true;     // SADXLoaderInfo.PauseWhenInactive

		[DefaultValue(640)]
		public int CustomWindowWidth { get; set; } = 640;             // SADXLoaderInfo.WindowWidth

		[DefaultValue(480)]
		public int CustomWindowHeight { get; set; } = 480;            // SADXLoaderInfo.WindowHeight

		[DefaultValue(false)]
		public bool EnableKeepResolutionRatio { get; set; }     // SADXLoaderInfo.MaintainWindowAspectRatio

		[DefaultValue(false)]
		public bool EnableResizableWindow { get; set; }               // SADXLoaderInfo.ResizableWindow

		[DefaultValue((int)FillMode.Fill)]
		public int FillModeBackground { get; set; } = (int)FillMode.Fill;   // SADXLoaderInfo.BackgroundFillMode

		[DefaultValue((int)FillMode.Fit)]
		public int FillModeFMV { get; set; } = (int)FillMode.Fit;           // SADXLoaderInfo.FmvFillMode

		[DefaultValue(TextureFilter.temp)]
		public TextureFilter ModeTextureFiltering { get; set; }

		[DefaultValue(TextureFilter.temp)]
		public TextureFilter ModeUIFiltering { get; set; }

		[DefaultValue(true)]
		public bool EnableUIScaling { get; set; } = true;              // SADXLoaderInfo.ScaleHud

		[DefaultValue(true)]
		public bool EnableForcedMipmapping { get; set; } = true;            // SADXLoaderInfo.AutoMipmap

		[DefaultValue(true)]
		public bool EnableForcedTextureFilter { get; set; } = true; // SADXLoaderInfo.TextureFilter

		[DefaultValue(DisplayMode.Borderless)]
		public int ScreenMode { get; set; } = (int)DisplayMode.Borderless;

		[DefaultValue(false)]
		public bool ShowMouseInFullscreen { get; set; }

		[DefaultValue(false)]
		public bool DisableBorderImage { get; set; }
	}

	public class ControllerSettings
	{
		[DefaultValue(true)]
		public bool EnabledInputMod { get; set; } = true;   // SADXLoaderInfo.InputModEnabled
	}

	public class SoundSettings
	{
		[DefaultValue(true)]
		public bool EnableBassMusic { get; set; } = true;             // SADXLoaderInfo.EnableBassMusic

		[DefaultValue(false)]
		public bool EnableBassSFX { get; set; } = false;              // SADXLoaderInfo.EnableBassSFX

		[DefaultValue(100)]
		public int SEVolume { get; set; } = 100;                // SADXLoaderInfo.SEVolume
	}

	public class TestSpawnSettings
	{
		public enum GameLanguage
		{
			Japanese = 0,
			English = 1,
			French = 2,
			Spanish = 3,
			German = 4
		}

		/// <summary>
		/// Enables Character options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseCharacter { get; set; } = false;

		/// <summary>
		/// Enables the Level, Act, and Time of Day options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseLevel { get; set; } = false;

		/// <summary>
		/// Enables the Event options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseEvent { get; set; } = false;

		/// <summary>
		/// Enables the GameMode options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseGameMode { get; set; } = false;

		/// <summary>
		/// Enables the Save options when launching.
		/// </summary>
		[DefaultValue(false)]
		public bool UseSave { get; set; } = false;

		/// <summary>
		/// Selected index for the level used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int LevelIndex { get; set; } = -1;       // SADXLoaderInfo.TestSpawnLevel

		/// <summary>
		/// Selected index for the act used by test spawn.
		/// </summary>
		[DefaultValue(0)]
		public int ActIndex { get; set; } = 0;          // SADXLoaderInfo.TestSpawnAct

		/// <summary>
		/// Selected index for the character used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int CharacterIndex { get; set; } = -1;   // SADXLoaderInfo.TestSpawnCharacter

		/// <summary>
		/// Selected index of an event used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int EventIndex { get; set; } = -1;       // SADXLoaderInfo.TestSpawnEvent

		/// <summary>
		/// Selected index for the GameMode used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int GameModeIndex { get; set; } = -1;    // SADXLoaderInfo.TestSpawnGameMode

		/// <summary>
		/// Selected save file index used by test spawn.
		/// </summary>
		[DefaultValue(-1)]
		public int SaveIndex { get; set; } = -1;      // SADXLoaderInfo.TestSpawnSaveID

		/// <summary>
		/// Sets the game's Text Language.
		/// </summary>
		[DefaultValue((int)GameLanguage.English)]
		public int GameTextLanguage { get; set; } = 1;      // SADXLoaderInfo.TextLanguage

		/// <summary>
		/// Sets the game's Voice Language.
		/// </summary>
		[DefaultValue((int)GameLanguage.English)]
		public int GameVoiceLanguage { get; set; } = 1;     // SADXLoaderInfo.VoiceLanguage

		/// <summary>
		/// Enables the Manual settings for Character, Level, and Act.
		/// </summary>
		[DefaultValue(false)]
		public bool UseManual { get; set; } = false;

		/// <summary>
		/// Enables manually modifying the start position when using test spawn.
		/// </summary>
		[DefaultValue(false)]
		public bool UsePosition { get; set; } = false; // SADXLoaderInfo.TestSpawnPositionEnabled

		/// <summary>
		/// X Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float XPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnX

		/// <summary>
		/// Y Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float YPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnY

		/// <summary>
		/// Z Position where the player will spawn using test spawn.
		/// </summary>
		[DefaultValue(0f)]
		public float ZPosition { get; set; } = 0f;            // SADXLoaderInfo.TestSpawnZ

		/// <summary>
		/// Initial Y Rotation for the player when using test spawn.
		/// </summary>
		[DefaultValue(0)]
		public int Rotation { get; set; } = 0;     // SADXLoaderInfo.TestSpawnRotation
	}

	public class GamePatches
	{
		/// <summary>
		/// Modifies the sound system. Only SF94 knows why.
		/// </summary>
		[DefaultValue(true)]
		public bool HRTFSound { get; set; } = true;        // SADXLoaderInfo.HRTFSound

		/// <summary>
		/// Fixes the game turning off free cam when dying if it was previously set.
		/// </summary>
		[DefaultValue(true)]
		public bool KeepCamSettings { get; set; } = true;           // SADXLoaderInfo.CCEF

		/// <summary>
		/// Fixes the game's rendering to properly allow mesh's with vertex colors to be rendered with those vertex colors.
		/// </summary>
		[DefaultValue(true)]
		public bool FixVertexColorRendering { get; set; } = true; //vertex color	// SADXLoaderInfo.PolyBuff

		/// <summary>
		/// Fixes the material colors so they render properly.
		/// </summary>
		[DefaultValue(true)]
		public bool MaterialColorFix { get; set; } = true;      // SADXLoaderInfo.MaterialColorFix

		/// <summary>
		/// Increases nodes limits to 254 (originally 111 for characters)
		/// </summary>
		[DefaultValue(true)]
		public bool NodeLimit { get; set; } = true;      // New Feature, doesn't originally exist

		/// <summary>
		/// Fixes the game's FOV.
		/// </summary>
		[DefaultValue(true)]
		public bool FOVFix { get; set; } = true;     // SADXLoaderInfo.FovFix

		/// <summary>
		/// Fixes Skychase to properly render.
		/// </summary>
		[DefaultValue(true)]
		public bool SkyChaseResolutionFix { get; set; } = true; // SADXLoaderInfo.SCFix

		/// <summary>
		/// Fixes a bug that will cause the game to crash when fighting Chaos 2.
		/// </summary>
		[DefaultValue(true)]
		public bool Chaos2CrashFix { get; set; } = true;        // SADXLoaderInfo.Chaos2CrashFix

		/// <summary>
		/// Fixes specular rendering on Chunk models.
		/// </summary>
		[DefaultValue(true)]
		public bool ChunkSpecularFix { get; set; } = true;         // SADXLoaderInfo.ChunkSpecFix

		/// <summary>
		/// Fixes rendering on E-102's gun which uses an N-Gon.
		/// </summary>
		[DefaultValue(true)]
		public bool E102NGonFix { get; set; } = true;           // SADXLoaderInfo.E102PolyFix

		/// <summary>
		/// Fixes Chao Panel rendering.
		/// </summary>
		[DefaultValue(true)]
		public bool ChaoPanelFix { get; set; } = true;          // SADXLoaderInfo.ChaoPanelFix

		/// <summary>
		/// Fixes a slight pixel offset in the window.
		/// </summary>
		[DefaultValue(true)]
		public bool PixelOffSetFix { get; set; } = true;        // SADXLoaderInfo.PixelOffsetFix

		/// <summary>
		/// Fixes lights
		/// </summary>
		[DefaultValue(true)]
		public bool LightFix { get; set; } = true;           // SADXLoaderInfo.LightFix

		/// <summary>
		/// Removes GBIX processing for most textures. UI is excluded.
		/// </summary>
		[DefaultValue(true)]
		public bool KillGBIX { get; set; } = true;            // SADXLoaderInfo.KillGbix

		/// <summary>
		/// Disables the built in CD Check.
		/// </summary>
		[DefaultValue(false)]
		public bool DisableCDCheck { get; set; } = false;       // SADXLoaderInfo.DisableCDCheck

		/// <summary>
		/// Extends save support to allow custom names and alternate save directories.
		/// </summary>
		[DefaultValue(true)]
		public bool ExtendedSaveSupport { get; set; } = true;

		/// <summary>
		/// Prevents common crashes in the game, namely texture related ones.
		/// </summary>
		[DefaultValue(true)]
		public bool CrashGuard { get; set; } = true;

		/// <summary>
		/// Fixes XInput without the need for using SDL/Better Input.
		/// </summary>
		[DefaultValue(false)]
		public bool XInputFix { get; set; } = false;
	}

	public class DebugSettings
	{
		/// <summary>
		/// Enables debug printing to the console window.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugConsole { get; set; }      // SADXLoaderInfo.DebugConsole

		/// <summary>
		/// Enables debug printing in the game window.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugScreen { get; set; }       // SADXLoaderInfo.DebugScreen

		/// <summary>
		/// Enables debug printing to a file.
		/// </summary>
		[DefaultValue(false)]
		public bool EnableDebugFile { get; set; }         // SADXLoaderInfo.DebugFile

		/// <summary>
		/// Enables crash log mini dump creation.
		/// </summary>
		[DefaultValue(true)]
		public bool EnableDebugCrashLog { get; set; } = true;    // SADXLoaderInfo.DebugCrashLog
	}

	public class GameSettings
	{
		/// <summary>
		/// Versioning. Please comment a brief on the changes to the version.
		/// </summary>
		public enum SADXSettingsVersions
		{
			v0,     // Version 0: Original LoaderInfo version
			v1,     // Version 1: Initial version at launch
			v2,     // Version 2: Updated to include all settings, intended to be used as the only loaded file, now writes SADXLoaderInfo and SADXConfigFile.
			v3,     // Version 3: Added Graphics.StretchToWindow and Graphics.DisableBorderWindow.

			MAX,    // Do Not Modify, new versions are placed above this.
		}

		/// <summary>
		/// Versioning for the SADX Settings file.
		/// </summary>
		[DefaultValue((int)(SADXSettingsVersions.MAX - 1))]
		public int SettingsVersion { get; set; } = (int)(SADXSettingsVersions.MAX - 1);

		/// <summary>
		/// Graphics Settings for SADX.
		/// </summary>
		public GraphicsSettings Graphics { get; set; } = new GraphicsSettings();

		/// <summary>
		/// Controller Settings for SADX.
		/// </summary>
		public ControllerSettings Controller { get; set; } = new ControllerSettings();

		/// <summary>
		/// Sound Settings for SADX.
		/// </summary>
		public SoundSettings Sound { get; set; } = new SoundSettings();

		/// <summary>
		/// TestSpawn Settings for SADX.
		/// </summary>
		public TestSpawnSettings TestSpawn { get; set; } = new TestSpawnSettings();

		/// <summary>
		/// Patches for SADX.
		/// </summary>
		public GamePatches Patches { get; set; } = new GamePatches();

		/// <summary>
		/// Debug Settings.
		/// </summary>
		public DebugSettings DebugSettings { get; set; } = new DebugSettings();

		/// <summary>
		/// Path to the game install saved with this configuration.
		/// </summary>
		public string GamePath { get; set; } = string.Empty;

		/// <summary>
		/// Enabled Mods for SADX.
		/// </summary>
		[IniName("Mod")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> EnabledMods { get; set; } = new List<string>();       // SADXLoaderInfo.Mods

		/// <summary>
		/// Enabled Codes for SADX.
		/// </summary>
		[IniName("Code")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> EnabledCodes { get; set; } = new List<string>();      // SADXLoaderInfo.EnabledCodes


		/// <summary>
		/// Deserializes an SADX GameSettings JSON File and returns a populated class.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static GameSettings Deserialize(string path)
		{
			try
			{
				if (File.Exists(path))
				{
					JsonSerializer js = new JsonSerializer() { Culture = System.Globalization.CultureInfo.InvariantCulture };
					TextReader tr = File.OpenText(path);
					JsonTextReader jtr = new JsonTextReader(tr);
					GameSettings settings = js.Deserialize<GameSettings>(jtr);

					return settings;
				}
				else
					return new GameSettings();
			}
			catch (Exception ex)
			{
				//new MessageWindow(Lang.GetString("MessageWindow.DefaultTitle.Error"), Lang.GetString("MessageWindow.Errors.ProfileLoad") + "\n\n" + ex.Message, MessageWindow.WindowType.IconMessage, MessageWindow.Icons.Error).ShowDialog();
			}

			return new GameSettings();
		}
	}

	public class ProfileData
	{
		public string Name { get; set; }
		public string Filename { get; set; }
	}

	public class ProfilesJson
	{
		[DefaultValue(0)]
		public int ProfileIndex;
		public List<ProfileData> ProfilesList;

		public ProfilesJson()
		{
			ProfilesList = new List<ProfileData>();
			ProfilesList.Add(new ProfileData { Name = "Default", Filename = "Default.json" });
		}
	}

	public class UpdateSettings
	{
		[DefaultValue(true)]
		public bool EnableManagerBootCheck { get; set; } = true;    // LoaderInfo.UpdateCheck

		[DefaultValue(true)]
		public bool EnableModsBootCheck { get; set; } = true;       // LoaderInfo.ModUpdateCheck

		[DefaultValue(true)]
		public bool EnableLoaderBootCheck { get; set; } = true;

		[DefaultValue(0)]
		public long UpdateTimeOutCD { get; set; } = 0;

		[DefaultValue(0)]
		public int UpdateCheckCount { get; set; } = 0;
	}

	public class ManagerConfig
	{
		[DefaultValue(1)]
		public int SettingsVersion;
		[DefaultValue(1)]
		public int CurrentSetGame;
		[DefaultValue(0)]
		public int Theme;
		[DefaultValue(0)]
		public int Language;
		public string ModAuthor;
		[DefaultValue(false)]
		public bool EnableDeveloperMode;
		[DefaultValue(true)]
		public bool KeepManagerOpen;
		
		public UpdateSettings UpdateSettings;
		public List<uint> gamesInstalled;

		public ManagerConfig()
		{
			gamesInstalled = new List<uint>();
			gamesInstalled.Add(1);
			SettingsVersion = 1;
			CurrentSetGame = 1;
			Theme = 0;
			Language = 0;
			EnableDeveloperMode = false;
			KeepManagerOpen = true;
			ModAuthor = "";
			UpdateSettings = new UpdateSettings();
			UpdateSettings.EnableManagerBootCheck = true;
			UpdateSettings.EnableModsBootCheck = true;
			UpdateSettings.EnableLoaderBootCheck = true;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelPilot;
using PixelPilot.PixelGameClient;
using PixelPilot.PixelGameClient.Messages.Received;
using PixelPilot.PixelGameClient.World;
using PixelPilot.PixelGameClient.World.Blocks;
using PixelPilot.PixelGameClient.World.Constants;
using EELVL;
namespace PWToEE
{
    public class Downloader
    {

        public static void Download(PixelPilotClient client,MainForm mf)
        {
            var world = new PixelWorld();
            client.OnPacketReceived += world.HandlePacket;
            client.OnPacketReceived += (_, packet) =>
            {
                switch (packet)
                {
                    case InitPacket initPacket:
                        mf.tssSText.Text = "Info: Converting data!";
                        mf.tssSText.ForeColor = Color.DarkBlue;
                        string fixedtitle = RemoveInvalidChars(initPacket.RoomTitle.Replace(" ", "_"));
                        string fixedname = RemoveInvalidChars(initPacket.Owner.Replace(" ", "_").ToLower());
                        string path = $"{Directory.GetCurrentDirectory()}\\{fixedtitle}_-_{fixedname}.eelvl";
                        if (File.Exists(path)) { File.Delete(path); }
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                        EELVL.Level savelvl = new Level(world.Width, world.Height);
                        savelvl.WorldName = initPacket.RoomTitle;
                        savelvl.OwnerName = initPacket.Owner.ToLower();
                        int rotation = 0;
                        for (int x = 0; x < world.Width; x++)
                        {
                            for (int y = 0; y < world.Height; y++)
                            {
                                IPixelBlock foreground = world.BlockAt(WorldLayer.Foreground, x, y);
                                IPixelBlock background = world.BlockAt(WorldLayer.Background, x, y);
                                switch (foreground.Block)
                                {
                                    #region Basic
                                    case PixelBlock.BasicBlack:
                                        savelvl[0, x, y] = new Blocks.Block(182);
                                        break;
                                    case PixelBlock.BasicBlue:
                                        savelvl[0, x, y] = new Blocks.Block(10);
                                        break;
                                    case PixelBlock.BasicCyan:
                                        savelvl[0, x, y] = new Blocks.Block(15);
                                        break;
                                    case PixelBlock.BasicGray:
                                        savelvl[0, x, y] = new Blocks.Block(9);
                                        break;
                                    case PixelBlock.BasicGreen:
                                        savelvl[0, x, y] = new Blocks.Block(14);
                                        break;
                                    case PixelBlock.BasicMagenta:
                                        savelvl[0, x, y] = new Blocks.Block(11);
                                        break;
                                    case PixelBlock.BasicOrange:
                                        savelvl[0, x, y] = new Blocks.Block(1018);
                                        break;
                                    case PixelBlock.BasicRed:
                                        savelvl[0, x, y] = new Blocks.Block(12);
                                        break;
                                    case PixelBlock.BasicWhite:
                                        savelvl[0, x, y] = new Blocks.Block(1088);
                                        break;
                                    case PixelBlock.BasicYellow:
                                        savelvl[0, x, y] = new Blocks.Block(13);
                                        break;
                                    #endregion

                                    #region Beveled
                                    case PixelBlock.BeveledBlack:
                                        savelvl[0, x, y] = new Blocks.Block(1021);
                                        break;
                                    case PixelBlock.BeveledBlue:
                                        savelvl[0, x, y] = new Blocks.Block(39);
                                        break;
                                    case PixelBlock.BeveledCyan:
                                        savelvl[0, x, y] = new Blocks.Block(1019);
                                        break;
                                    case PixelBlock.BeveledGray:
                                        savelvl[0, x, y] = new Blocks.Block(42);
                                        break;
                                    case PixelBlock.BeveledGreen:
                                        savelvl[0, x, y] = new Blocks.Block(38);
                                        break;
                                    case PixelBlock.BeveledMagenta:
                                        savelvl[0, x, y] = new Blocks.Block(37);
                                        break;
                                    case PixelBlock.BeveledOrange:
                                        savelvl[0, x, y] = new Blocks.Block(1020);
                                        break;
                                    case PixelBlock.BeveledRed:
                                        savelvl[0, x, y] = new Blocks.Block(40);
                                        break;
                                    case PixelBlock.BeveledWhite:
                                        savelvl[0, x, y] = new Blocks.Block(1089);
                                        break;
                                    case PixelBlock.BeveledYellow:
                                        savelvl[0, x, y] = new Blocks.Block(41);
                                        break;
                                    #endregion

                                    #region Bricks
                                    case PixelBlock.BricksBlack:
                                        savelvl[0, x, y] = new Blocks.Block(1024);
                                        break;
                                    case PixelBlock.BricksBlue:
                                        savelvl[0, x, y] = new Blocks.Block(1023);
                                        break;
                                    case PixelBlock.BricksBrown:
                                        savelvl[0, x, y] = new Blocks.Block(16);
                                        break;
                                    case PixelBlock.BricksGray:
                                        savelvl[0, x, y] = new Blocks.Block(1022);
                                        break;
                                    case PixelBlock.BricksOlive:
                                        savelvl[0, x, y] = new Blocks.Block(21);
                                        break;
                                    case PixelBlock.BricksPurple:
                                        savelvl[0, x, y] = new Blocks.Block(18);
                                        break;
                                    case PixelBlock.BricksRed:
                                        savelvl[0, x, y] = new Blocks.Block(20);
                                        break;
                                    case PixelBlock.BricksTeal:
                                        savelvl[0, x, y] = new Blocks.Block(17);
                                        break;
                                    case PixelBlock.BricksWhite:
                                        savelvl[0, x, y] = new Blocks.Block(1090);
                                        break;
                                    case PixelBlock.BricksGreen:
                                        savelvl[0, x, y] = new Blocks.Block(19);
                                        break;

                                    //Grass
                                    case PixelBlock.BricksGrass:
                                        savelvl[0, x, y] = new Blocks.Block(35);
                                        break;

                                    case PixelBlock.BricksGrassLeftEdge:
                                        savelvl[0, x, y] = new Blocks.Block(34);
                                        break;
                                    case PixelBlock.BricksGrassRightEdge:
                                        savelvl[0, x, y] = new Blocks.Block(36);
                                        break;
                                    #endregion

                                    #region Metal
                                    case PixelBlock.MetalCopper:
                                        savelvl[0, x, y] = new Blocks.Block(30);
                                        break;
                                    case PixelBlock.MetalGold:
                                        savelvl[0, x, y] = new Blocks.Block(31);
                                        break;
                                    case PixelBlock.MetalSilver:
                                        savelvl[0, x, y] = new Blocks.Block(29);
                                        break;
                                    #endregion

                                    #region Generic
                                    case PixelBlock.FaceBlock:
                                        savelvl[0, x, y] = new Blocks.Block(32);
                                        break;
                                    case PixelBlock.DarkHazardStripes:
                                        savelvl[0, x, y] = new Blocks.Block(1058);
                                        break;
                                    case PixelBlock.HazardStripes:
                                        savelvl[0, x, y] = new Blocks.Block(22);
                                        break;
                                    case PixelBlock.NoFaceBlock:
                                        savelvl[0, x, y] = new Blocks.Block(1057);
                                        break;
                                    case PixelBlock.BlackBlock:
                                        savelvl[0, x, y] = new Blocks.Block(33);
                                        break;
                                    case PixelBlock.FullBlackBlock:
                                        savelvl[0, x, y] = new Blocks.Block(44);
                                        break;
                                    #endregion

                                    #region Secrets
                                    case PixelBlock.SecretAppear:
                                        savelvl[0, x, y] = new Blocks.Block(50);
                                        break;
                                    case PixelBlock.SecretDisappear:
                                        savelvl[0, x, y] = new Blocks.Block(243);
                                        break;
                                    case PixelBlock.SecretInvisible:
                                        savelvl[0, x, y] = new Blocks.Block(136);
                                        break;
                                    #endregion

                                    #region Glass
                                    case PixelBlock.GlassBlue:
                                        savelvl[0, x, y] = new Blocks.Block(54);
                                        break;
                                    case PixelBlock.GlassCyan:
                                        savelvl[0, x, y] = new Blocks.Block(55);
                                        break;
                                    case PixelBlock.GlassGreen:
                                        savelvl[0, x, y] = new Blocks.Block(56);
                                        break;
                                    case PixelBlock.GlassMagenta:
                                        savelvl[0, x, y] = new Blocks.Block(52);
                                        break;
                                    case PixelBlock.GlassOrange:
                                        savelvl[0, x, y] = new Blocks.Block(58);
                                        break;
                                    case PixelBlock.GlassPurple:
                                        savelvl[0, x, y] = new Blocks.Block(53);
                                        break;
                                    case PixelBlock.GlassRed:
                                        savelvl[0, x, y] = new Blocks.Block(51);
                                        break;
                                    case PixelBlock.GlassYellow:
                                        savelvl[0, x, y] = new Blocks.Block(57);
                                        break;
                                    #endregion

                                    #region Minerals
                                    case PixelBlock.MineralsBlue:
                                        savelvl[0, x, y] = new Blocks.Block(72);
                                        break;
                                    case PixelBlock.MineralsCyan:
                                        savelvl[0, x, y] = new Blocks.Block(73);
                                        break;
                                    case PixelBlock.MineralsGreen:
                                        savelvl[0, x, y] = new Blocks.Block(74);
                                        break;
                                    case PixelBlock.MineralsPurple:
                                    case PixelBlock.MineralsMagenta:
                                        savelvl[0, x, y] = new Blocks.Block(71);
                                        break;
                                    case PixelBlock.MineralsOrange:
                                        savelvl[0, x, y] = new Blocks.Block(76);
                                        break;
                                    case PixelBlock.MineralsRed:
                                        savelvl[0, x, y] = new Blocks.Block(70);
                                        break;
                                    case PixelBlock.MineralsYellow:
                                        savelvl[0, x, y] = new Blocks.Block(75);
                                        break;
                                    #endregion

                                    #region Factory
                                    case PixelBlock.FactoryMetalCrate:
                                        savelvl[0, x, y] = new Blocks.Block(45);
                                        break;
                                    case PixelBlock.FactoryStone:
                                        savelvl[0, x, y] = new Blocks.Block(46);
                                        break;
                                    case PixelBlock.FactoryWood:
                                        savelvl[0, x, y] = new Blocks.Block(47);
                                        break;
                                    case PixelBlock.FactoryWoodenCrate:
                                        savelvl[0, x, y] = new Blocks.Block(48);
                                        break;
                                    case PixelBlock.FactoryScales:
                                        savelvl[0, x, y] = new Blocks.Block(49);
                                        break;
                                    #endregion

                                    #region Candy

                                    //Blocks
                                    case PixelBlock.CandyBlue:
                                        savelvl[0, x, y] = new Blocks.Block(1154);
                                        break;
                                    case PixelBlock.CandyChocolate:
                                        savelvl[0, x, y] = new Blocks.Block(67);
                                        break;
                                    case PixelBlock.CandyLicorice:
                                        savelvl[0, x, y] = new Blocks.Block(66);
                                        break;
                                    case PixelBlock.CandyPink:
                                        savelvl[0, x, y] = new Blocks.Block(60);
                                        break;
                                    case PixelBlock.CandyPlatformCyan:
                                        savelvl[0, x, y] = new Blocks.Block(63);
                                        break;

                                    //Platforms
                                    case PixelBlock.CandyPlatformGreen:
                                        savelvl[0, x, y] = new Blocks.Block(64);
                                        break;
                                    case PixelBlock.CandyPlatformPink:
                                        savelvl[0, x, y] = new Blocks.Block(61);
                                        break;
                                    case PixelBlock.CandyPlatformRed:
                                        savelvl[0, x, y] = new Blocks.Block(62);
                                        break;

                                    //Decorations
                                    case PixelBlock.CandyCreamLarge:
                                        savelvl[0, x, y] = new Blocks.Block(431);
                                        break;
                                    case PixelBlock.CandyCreamSmall:
                                        savelvl[0, x, y] = new Blocks.Block(227);
                                        break;
                                    case PixelBlock.CandyGumdropGreen:
                                        savelvl[0, x, y] = new Blocks.Block(433);
                                        break;
                                    case PixelBlock.CandyGumdropPink:
                                        savelvl[0, x, y] = new Blocks.Block(434);
                                        break;
                                    case PixelBlock.CandyGumdropRed:
                                        savelvl[0, x, y] = new Blocks.Block(432);
                                        break;
                                    #endregion

                                    #region Beach

                                    //Blocks
                                    case PixelBlock.BeachSand:
                                        savelvl[0, x, y] = new Blocks.Block(59);
                                        break;

                                    //Decorations
                                    case PixelBlock.BeachRock:
                                        savelvl[0, x, y] = new Blocks.Block(231);
                                        break;
                                    case PixelBlock.BeachDryBush:
                                        savelvl[0, x, y] = new Blocks.Block(232);
                                        break;
                                    case PixelBlock.BeachParasol:
                                        savelvl[0, x, y] = new Blocks.Block(228);
                                        break;
                                    case PixelBlock.BeachSandPileLeft:
                                        savelvl[0, x, y] = new Blocks.Block(230);
                                        break;
                                    case PixelBlock.BeachSandPileRight:
                                        savelvl[0, x, y] = new Blocks.Block(229);
                                        break;
                                    #endregion

                                    #region Eggs
                                    //Decorations
                                    case PixelBlock.EasterEggBlue:
                                        savelvl[0, x, y] = new Blocks.Block(256);
                                        break;
                                    case PixelBlock.EasterEggGreen:
                                        savelvl[0, x, y] = new Blocks.Block(260);
                                        break;
                                    case PixelBlock.EasterEggPink:
                                        savelvl[0, x, y] = new Blocks.Block(257);
                                        break;
                                    case PixelBlock.EasterEggRed:
                                        savelvl[0, x, y] = new Blocks.Block(259);
                                        break;
                                    case PixelBlock.EasterEggYellow:
                                        savelvl[0, x, y] = new Blocks.Block(258);
                                        break;
                                    #endregion

                                    #region Meadow
                                    case PixelBlock.MeadowBushLeft:
                                        savelvl[0, x, y] = new Blocks.Block(236);
                                        break;
                                    case PixelBlock.MeadowBushRight:
                                        savelvl[0, x, y] = new Blocks.Block(238);
                                        break;
                                    case PixelBlock.MeadowBushMiddle:
                                        savelvl[0, x, y] = new Blocks.Block(237);
                                        break;

                                    case PixelBlock.MeadowGrassLeft:
                                        savelvl[0, x, y] = new Blocks.Block(233);
                                        break;
                                    case PixelBlock.MeadowGrassRight:
                                        savelvl[0, x, y] = new Blocks.Block(235);
                                        break;
                                    case PixelBlock.MeadowGrassMiddle:
                                        savelvl[0, x, y] = new Blocks.Block(234);
                                        break;
                                    case PixelBlock.MeadowSmallBush:
                                        savelvl[0, x, y] = new Blocks.Block(240);
                                        break;
                                    case PixelBlock.MeadowYellowFlower:
                                        savelvl[0, x, y] = new Blocks.Block(239);
                                        break;
                                    #endregion

                                    #region Action

                                    //Gravity
                                    case PixelBlock.GravityDot:
                                        savelvl[0, x, y] = new Blocks.Block(4);
                                        break;

                                    case PixelBlock.GravityDown:
                                        savelvl[0, x, y] = new Blocks.Block(1518);
                                        break;
                                    case PixelBlock.GravityLeft:
                                        savelvl[0, x, y] = new Blocks.Block(1);
                                        break;
                                    case PixelBlock.GravityRight:
                                        savelvl[0, x, y] = new Blocks.Block(3);
                                        break;
                                    case PixelBlock.GravitySlowDot:
                                        savelvl[0, x, y] = new Blocks.Block(459);
                                        break;
                                    case PixelBlock.GravityUp:
                                        savelvl[0, x, y] = new Blocks.Block(2);
                                        break;

                                    //Boost
                                    case PixelBlock.BoostDown:
                                        savelvl[0, x, y] = new Blocks.Block(117);
                                        break;
                                    case PixelBlock.BoostLeft:
                                        savelvl[0, x, y] = new Blocks.Block(114);
                                        break;
                                    case PixelBlock.BoostRight:
                                        savelvl[0, x, y] = new Blocks.Block(115);
                                        break;
                                    case PixelBlock.BoostUp:
                                        savelvl[0, x, y] = new Blocks.Block(116);
                                        break;

                                    //Crown
                                    case PixelBlock.Crown:
                                        savelvl[0, x, y] = new Blocks.Block(5);
                                        break;

                                    //Coins
                                    case PixelBlock.Coin:
                                        savelvl[0, x, y] = new Blocks.Block(100);
                                        break;
                                    case PixelBlock.BlueCoin:
                                        savelvl[0, x, y] = new Blocks.Block(101);
                                        break;

                                    //Spawn
                                    case PixelBlock.SpawnPoint:
                                        savelvl[0, x, y] = new Blocks.Block(255);
                                        break;
                                    case PixelBlock.Checkpoint:
                                        savelvl[0, x, y] = new Blocks.Block(360);
                                        break;


                                    #endregion

                                    #region Portal
                                    case PixelBlock.Portal:
                                        rotation = 0;
                                        if (((PortalBlock)foreground).Direction == 0) rotation = 1;
                                        else if (((PortalBlock)foreground).Direction == 1) rotation = 2;
                                        else if (((PortalBlock)foreground).Direction == 2) rotation = 3;
                                        else if (((PortalBlock)foreground).Direction == 3) rotation = 0;
                                        savelvl[0, x, y] = new Blocks.PortalBlock(242, rotation, ((PortalBlock)foreground).PortalId, ((PortalBlock)foreground).TargetId);
                                        break;

                                    case PixelBlock.PortalInvisible:
                                        rotation = 0;
                                        if (((PortalBlock)foreground).Direction == 0) rotation = 1;
                                        else if (((PortalBlock)foreground).Direction == 1) rotation = 2;
                                        else if (((PortalBlock)foreground).Direction == 2) rotation = 3;
                                        else if (((PortalBlock)foreground).Direction == 3) rotation = 0;
                                        savelvl[0, x, y] = new Blocks.PortalBlock(381, rotation, ((PortalBlock)foreground).PortalId, ((PortalBlock)foreground).TargetId);
                                        break;
                                    #endregion

                                    //Water
                                    case PixelBlock.Water:
                                        savelvl[0, x, y] = new Blocks.Block(119);
                                        break;
                                    case PixelBlock.WaterSurface:
                                        savelvl[0, x, y] = new Blocks.Block(300);
                                        break;

                                    #region Keys
                                    //Key door/Gate
                                    case PixelBlock.KeyBlue:
                                        savelvl[0, x, y] = new Blocks.Block(8);
                                        break;
                                    case PixelBlock.KeyGreen:
                                        savelvl[0, x, y] = new Blocks.Block(7);
                                        break;
                                    case PixelBlock.KeyRed:
                                        savelvl[0, x, y] = new Blocks.Block(6);
                                        break;

                                    case PixelBlock.KeyDoorBlue:
                                        savelvl[0, x, y] = new Blocks.Block(25);
                                        break;
                                    case PixelBlock.KeyDoorGreen:
                                        savelvl[0, x, y] = new Blocks.Block(24);
                                        break;
                                    case PixelBlock.KeyDoorRed:
                                        savelvl[0, x, y] = new Blocks.Block(23);
                                        break;

                                    case PixelBlock.KeyGateBlue:
                                        savelvl[0, x, y] = new Blocks.Block(28);
                                        break;
                                    case PixelBlock.KeyGateGreen:
                                        savelvl[0, x, y] = new Blocks.Block(27);
                                        break;
                                    case PixelBlock.KeyGateRed:
                                        savelvl[0, x, y] = new Blocks.Block(26);
                                        break;
                                    #endregion

                                    #region Coins
                                    //Coins door/gate
                                    case PixelBlock.CoinDoor:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(43, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.BlueCoinDoor:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(213, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.CoinGate:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(165, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.BlueCoinGate:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(214, ((MorphableBlock)foreground).Morph);
                                        break;
                                    #endregion

                                    #region Switches
                                    //Switches
                                    case PixelBlock.GlobalSwitch:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(467, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.GlobalSwitchDoor:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(1079, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.GlobalSwitchGate:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(1080, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.LocalSwitch:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(113, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.LocalSwitchDoor:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(184, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.LocalSwitchGate:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(185, ((MorphableBlock)foreground).Morph);
                                        break;
                                    #endregion

                                    #region Misc
                                    case PixelBlock.DeathDoor:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(1011, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.DeathGate:
                                        savelvl[0, x, y] = new Blocks.NumberBlock(1012, ((MorphableBlock)foreground).Morph);
                                        break;
                                    case PixelBlock.Spikes:
                                        rotation = 0;
                                        if (((MorphableBlock)foreground).Morph == 0) rotation = 1;
                                        else if (((MorphableBlock)foreground).Morph == 1) rotation = 2;
                                        else if (((MorphableBlock)foreground).Morph == 2) rotation = 3;
                                        else if (((MorphableBlock)foreground).Morph == 3) rotation = 0;
                                        savelvl[0, x, y] = new Blocks.RotatableBlock(361, rotation);
                                        break;

                                    case PixelBlock.SpikesCenter:
                                        savelvl[0, x, y] = new Blocks.Block(1580);
                                        break;
                                    case PixelBlock.Fire:
                                        savelvl[0, x, y] = new Blocks.Block(368);
                                        break;
                                    #endregion

                                    case PixelBlock.Empty:
                                        savelvl[0, x, y] = new Blocks.Block(0);
                                        break;
                                }
                                switch (background.Block)
                                {
                                    #region Basic
                                    case PixelBlock.BasicBlackBg:
                                        savelvl[1, x, y] = new Blocks.Block(645);
                                        break;
                                    case PixelBlock.BasicBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(501);
                                        break;
                                    case PixelBlock.BasicCyanBg:
                                        savelvl[1, x, y] = new Blocks.Block(506);
                                        break;
                                    case PixelBlock.BasicGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(505);
                                        break;
                                    case PixelBlock.BasicMagentaBg:
                                        savelvl[1, x, y] = new Blocks.Block(502);
                                        break;
                                    case PixelBlock.BasicOrangeBg:
                                        savelvl[1, x, y] = new Blocks.Block(644);
                                        break;
                                    case PixelBlock.BasicWhiteBg:
                                        savelvl[1, x, y] = new Blocks.Block(715);
                                        break;
                                    case PixelBlock.BasicYellowBg:
                                        savelvl[1, x, y] = new Blocks.Block(504);
                                        break;
                                    case PixelBlock.BasicRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(503);
                                        break;
                                    case PixelBlock.BasicGrayBg:
                                        savelvl[1, x, y] = new Blocks.Block(500);
                                        break;
                                    #endregion

                                    #region Brick
                                    case PixelBlock.BricksBlackBg:
                                        savelvl[1, x, y] = new Blocks.Block(648);
                                        break;
                                    case PixelBlock.BricksBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(647);
                                        break;
                                    case PixelBlock.BricksBrownBg:
                                        savelvl[1, x, y] = new Blocks.Block(507);
                                        break;
                                    case PixelBlock.BricksGrayBg:
                                        savelvl[1, x, y] = new Blocks.Block(646);
                                        break;
                                    case PixelBlock.BricksGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(510);
                                        break;
                                    case PixelBlock.BricksOliveBg:
                                        savelvl[1, x, y] = new Blocks.Block(512);
                                        break;
                                    case PixelBlock.BricksPurpleBg:
                                        savelvl[1, x, y] = new Blocks.Block(509);
                                        break;
                                    case PixelBlock.BricksRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(511);
                                        break;
                                    case PixelBlock.BricksTealBg:
                                        savelvl[1, x, y] = new Blocks.Block(508);
                                        break;
                                    case PixelBlock.BricksWhiteBg:
                                        savelvl[1, x, y] = new Blocks.Block(716);
                                        break;
                                    #endregion

                                    #region Checker
                                    case PixelBlock.CheckerBlackBg:
                                        savelvl[1, x, y] = new Blocks.Block(650);
                                        break;
                                    case PixelBlock.CheckerBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(514);
                                        break;
                                    case PixelBlock.CheckerCyanBg:
                                        savelvl[1, x, y] = new Blocks.Block(519);
                                        break;
                                    case PixelBlock.CheckerGrayBg:
                                        savelvl[1, x, y] = new Blocks.Block(513);
                                        break;
                                    case PixelBlock.CheckerGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(518);
                                        break;
                                    case PixelBlock.CheckerMagentaBg:
                                        savelvl[1, x, y] = new Blocks.Block(515);
                                        break;
                                    case PixelBlock.CheckerOrangeBg:
                                        savelvl[1, x, y] = new Blocks.Block(649);
                                        break;
                                    case PixelBlock.CheckerRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(516);
                                        break;
                                    case PixelBlock.CheckerWhiteBg:
                                        savelvl[1, x, y] = new Blocks.Block(718);
                                        break;
                                    case PixelBlock.CheckerYellowBg:
                                        savelvl[1, x, y] = new Blocks.Block(517);
                                        break;
                                    #endregion

                                    #region Dark
                                    case PixelBlock.DarkBlackBg:
                                        savelvl[1, x, y] = new Blocks.Block(652);
                                        break;
                                    case PixelBlock.DarkBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(521);
                                        break;
                                    case PixelBlock.DarkCyanBg:
                                        savelvl[1, x, y] = new Blocks.Block(526);
                                        break;
                                    case PixelBlock.DarkGrayBg:
                                        savelvl[1, x, y] = new Blocks.Block(520);
                                        break;
                                    case PixelBlock.DarkGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(525);
                                        break;
                                    case PixelBlock.DarkMagentaBg:
                                        savelvl[1, x, y] = new Blocks.Block(522);
                                        break;
                                    case PixelBlock.DarkOrangeBg:
                                        savelvl[1, x, y] = new Blocks.Block(651);
                                        break;
                                    case PixelBlock.DarkRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(523);
                                        break;
                                    case PixelBlock.DarkWhiteBg:
                                        savelvl[1, x, y] = new Blocks.Block(719);
                                        break;
                                    case PixelBlock.DarkYellowBg:
                                        savelvl[1, x, y] = new Blocks.Block(524);
                                        break;
                                    #endregion

                                    #region Normal
                                    case PixelBlock.NormalBlackBg:
                                        savelvl[1, x, y] = new Blocks.Block(654);
                                        break;
                                    case PixelBlock.NormalBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(611);
                                        break;
                                    case PixelBlock.NormalCyanBg:
                                        savelvl[1, x, y] = new Blocks.Block(616);
                                        break;
                                    case PixelBlock.NormalGrayBg:
                                        savelvl[1, x, y] = new Blocks.Block(610);
                                        break;
                                    case PixelBlock.NormalGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(615);
                                        break;
                                    case PixelBlock.NormalMagentaBg:
                                        savelvl[1, x, y] = new Blocks.Block(612);
                                        break;
                                    case PixelBlock.NormalOrangeBg:
                                        savelvl[1, x, y] = new Blocks.Block(653);
                                        break;
                                    case PixelBlock.NormalRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(613);
                                        break;
                                    case PixelBlock.NormalWhiteBg:
                                        savelvl[1, x, y] = new Blocks.Block(717);
                                        break;
                                    case PixelBlock.NormalYellowBg:
                                        savelvl[1, x, y] = new Blocks.Block(614);
                                        break;
                                    #endregion

                                    #region Pastel
                                    case PixelBlock.PastelBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(531);
                                        break;
                                    case PixelBlock.PastelCyanBg:
                                        savelvl[1, x, y] = new Blocks.Block(530);
                                        break;
                                    case PixelBlock.PastelGreenBg:
                                        savelvl[1, x, y] = new Blocks.Block(528);
                                        break;
                                    case PixelBlock.PastelLimeBg:
                                        savelvl[1, x, y] = new Blocks.Block(529);
                                        break;
                                    case PixelBlock.PastelOrangeBg:
                                        savelvl[1, x, y] = new Blocks.Block(676);
                                        break;
                                    case PixelBlock.PastelPurpleBg:
                                        savelvl[1, x, y] = new Blocks.Block(677);
                                        break;
                                    case PixelBlock.PastelRedBg:
                                        savelvl[1, x, y] = new Blocks.Block(532);
                                        break;
                                    case PixelBlock.PastelYellowBg:
                                        savelvl[1, x, y] = new Blocks.Block(527);
                                        break;
                                    #endregion

                                    #region Candy
                                    case PixelBlock.CandyBlueBg:
                                        savelvl[1, x, y] = new Blocks.Block(540);
                                        break;
                                    case PixelBlock.CandyPinkBg:
                                        savelvl[1, x, y] = new Blocks.Block(539);
                                        break;
                                        #endregion
                                }
                            }

                        }
                        savelvl.Save(fs);
                        mf.tssSText.Text = "Info: Data succesfully saved!";
                        mf.tssSText.ForeColor = Color.DarkGreen;
                        client?.Disconnect();
                        break;

                };
            };
        }
        public static string RemoveInvalidChars(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.My;
using PCLCS;

namespace PCL;

[StandardModule]
internal sealed class ModSecret
{
    public const string VersionBranchMain = "Official";

    public const string RegFolder = "PCL";

    public const string OAuthClientId = "fe72edc2-3a6f-4280-90e8-e2beb64ce7e1";

    public const string ClsBaseUrl = "https://ap-shanghai.cls.tencentcs.com/track?topic_id=pcl-remote-1253424809";

    public static ModBase.MyColor Color1 = new ModBase.MyColor(52.0, 61.0, 74.0);

    public static ModBase.MyColor Color2 = new ModBase.MyColor(11.0, 91.0, 203.0);

    public static ModBase.MyColor Color3 = new ModBase.MyColor(19.0, 112.0, 243.0);

    public static ModBase.MyColor Color4 = new ModBase.MyColor(72.0, 144.0, 245.0);

    public static ModBase.MyColor Color5 = new ModBase.MyColor(150.0, 192.0, 249.0);

    public static ModBase.MyColor Color6 = new ModBase.MyColor(213.0, 230.0, 253.0);

    public static ModBase.MyColor Color7 = new ModBase.MyColor(222.0, 236.0, 253.0);

    public static ModBase.MyColor Color8 = new ModBase.MyColor(234.0, 242.0, 254.0);

    public static ModBase.MyColor ColorBg0 = new ModBase.MyColor(150.0, 192.0, 249.0);

    public static ModBase.MyColor ColorBg1 = new ModBase.MyColor(190.0, Color7);

    public static ModBase.MyColor ColorGray1 = new ModBase.MyColor(64.0, 64.0, 64.0);

    public static ModBase.MyColor ColorGray2 = new ModBase.MyColor(115.0, 115.0, 115.0);

    public static ModBase.MyColor ColorGray3 = new ModBase.MyColor(140.0, 140.0, 140.0);

    public static ModBase.MyColor ColorGray4 = new ModBase.MyColor(166.0, 166.0, 166.0);

    public static ModBase.MyColor ColorGray5 = new ModBase.MyColor(204.0, 204.0, 204.0);

    public static ModBase.MyColor ColorGray6 = new ModBase.MyColor(235.0, 235.0, 235.0);

    public static ModBase.MyColor ColorGray7 = new ModBase.MyColor(240.0, 240.0, 240.0);

    public static ModBase.MyColor ColorGray8 = new ModBase.MyColor(245.0, 245.0, 245.0);

    public static ModBase.MyColor ColorSemiTransparent = new ModBase.MyColor(1.0, Color8);

    public static int ThemeNow = -1;

    public static int ColorHue = 210;

    public static int ColorSat = 85;

    public static int ColorLightAdjust = 0;

    public static OneOf<int, int[]> ColorHueTopbarDelta = (OneOf<int, int[]>)(0);

    public static int ThemeDontClick = 0;

    private static bool IsUpdating = false;

    internal static bool IsUpdateWaitingRestart = false;

    private static string UpdateMark = "EmptyMark********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************";

    public static JObject ServerConfig;

    public static ModLoader.LoaderTask<int, int> ServerLoader = new ModLoader.LoaderTask<int, int>("PCL 配置更新", ServerSub, null, ThreadPriority.BelowNormal)
    {
        ReloadTimeout = 3600000
    };

    private static List<string> _PotatoFeatures = null;

    private const string EcdsaPublicKey = "RUNTMSAAAAC4QTUNAewh23Q4Q6koHkyIrDIIZUSbua23sf2DiZmIRwSzadISDRyTVTbuWniH3KR7rKj8XBsabms1be6i3c+S";

    private static bool _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate;

    private static StaticLocalInitFlag _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init;

    private static bool _0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate;

    public static DonationRank CurrentRank
    {
        get
        {
            return (DonationRank)0;
        }
    }

    private static bool HasUpdatePermission => true;

    private static List<string> PotatoFeatures
    {
        get
        {
            if (_PotatoFeatures == null)
            {
                _PotatoFeatures = new List<string>();
                string[] array = StringExtensions.Split(Settings.Get<string>("Potatoes").ToString(), '|', true);
                for (int i = 0; i < array.Length; i = checked(i + 1))
                {
                    OneOf<List<string>, string> val = CheckPotatoCode(array[i]);
                    if (val.Is<List<string>>())
                    {
                        _PotatoFeatures.AddRange(val.As<List<string>>());
                    }
                }
                _PotatoFeatures = _PotatoFeatures.Distinct().ToList();
            }
            return _PotatoFeatures;
        }
    }

    static ModSecret()
    {
    }

    internal static string SecretCdnSign(string UrlWithMark)
    {
        if (ModBase.ApplicationStartTick < 1)
        {
            return UrlWithMark;
        }
        if (!StringExtensions.EndsWithF(UrlWithMark, "{CDN}", false))
        {
            return UrlWithMark;
        }
        string text = UrlWithMark.Replace("{CDN}", "").Replace(" ", "%20");
        string text2 = StringExtensions.EnsureLength(ModBase.RandomInteger(0, 2147483645).ToString("x"), '0', 8);
        string text3 = Conversions.ToString(ModBase.GetUnixTimestampUtc());
        string text4 = text.Substring(checked(StringExtensions.IndexOfF(text, "://", false) + 3));
        text4 = text4.Substring(StringExtensions.IndexOfF(text4, "/", false));
        string text5 = CryptographyUtils.ComputeHash(EnumerableExtensions.Join((IEnumerable)new string[5] { text4, text3, text2, "0", "PCL2Server" }, "-"), (MeloongCore.CryptographyUtils.HashMethod)0);
        return text + (text.Contains("?") ? "&" : "?") + "sign=" + EnumerableExtensions.Join((IEnumerable)new string[4] { text3, text2, "0", text5 }, "-");
    }

    internal static void SecretHeadersSign(string Url, ref HttpRequestMessage Req, bool SimulateBrowserHeaders = false)
    {
        if (ModBase.ApplicationStartTick < 1)
        {
            return;
        }
        if (!Req.Headers.UserAgent.Any())
        {
            if (Url.Contains("baidupcs.com") || Url.Contains("baidu.com"))
            {
                Req.Headers.Add("User-Agent", "LogStatistic");
            }
            else if (SimulateBrowserHeaders)
            {
                Req.Headers.Add("User-Agent", string.Format("PCL2/{0}.{1} Mozilla/5.0 AppleWebKit/537.36 Chrome/63.0.3239.132 Safari/537.36", "2.13.1.1", 50));
            }
            else
            {
                Req.Headers.Add("User-Agent", string.Format("PCL2/{0}.{1}", "2.13.1.1", 50));
            }
        }
        if (!SimulateBrowserHeaders)
        {
            Req.Headers.Referrer = new Uri($"http://{408}.pcl2.server/");
        }
        if (IsCurseForgeHost(Url))
        {
            Req.Headers.Add("x-api-key", Encoding.Default.GetString(Convert.FromBase64String("JDJhJDEwJDdXV1YxV0VMY3dYOFhwN2Q2OE1Icy41Z3JUeVpWYTZTeW55ZVN5TWgxcnNFODluSWEwOXpP")));
        }
    }

    /// <summary>
    /// 仅当 URL 的主机名确为 CurseForge/ForgeCDN 时才附加 API Key，避免按子串匹配把密钥发给第三方。
    /// </summary>
    private static bool IsCurseForgeHost(string Url)
    {
        try
        {
            string host = new Uri(Url).Host;
            return host.Equals("api.curseforge.com", StringComparison.OrdinalIgnoreCase)
                || host.Equals("forgecdn.net", StringComparison.OrdinalIgnoreCase)
                || host.EndsWith(".forgecdn.net", StringComparison.OrdinalIgnoreCase);
        }
        catch (UriFormatException)
        {
            return false;
        }
    }

    public static void ThemeRefresh(int NewTheme = -1)
    {
        checked
        {
            try
            {
                NewTheme = 0;
                if ((ThemeNow != NewTheme || NewTheme < 0) && ThemeCheckOne((NewTheme >= 0) ? NewTheme : ThemeNow))
                {
                    if (NewTheme >= 0)
                    {
                        ThemeNow = NewTheme;
                    }
                    ColorHue = 210;
                    ColorSat = 85;
                    ColorLightAdjust = 0;
                    switch (ThemeDontClick)
                    {
                        case 1:
                            ColorLightAdjust = 999;
                            break;
                        case 2:
                            ColorHue = ModBase.RandomInteger(0, 359);
                            ColorSat = ModBase.RandomInteger(40, 70);
                            ColorLightAdjust = ModBase.RandomInteger(-20, 20);
                            break;
                    }
                    Color1 = new ModBase.MyColor().FromHSL2(ColorHue, (double)ColorSat * 0.2, 25.0 + (double)ColorLightAdjust * 0.3);
                    Color2 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 45 + ColorLightAdjust);
                    Color3 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 55 + ColorLightAdjust);
                    Color4 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 65 + ColorLightAdjust);
                    Color5 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 80.0 + (double)ColorLightAdjust * 0.4);
                    Color6 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 91.0 + (double)ColorLightAdjust * 0.1);
                    Color7 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 95.0);
                    Color8 = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 97.0);
                    ColorBg0 = Color4 * 0.4 + Color5 * 0.4 + ColorGray4 * 0.2;
                    ColorBg1 = new ModBase.MyColor(190.0, Color7);
                    ColorSemiTransparent = new ModBase.MyColor(1.0, Color8);
                    System.Windows.Application.Current.Resources["ColorBrush1"] = new SolidColorBrush(Color1);
                    System.Windows.Application.Current.Resources["ColorBrush2"] = new SolidColorBrush(Color2);
                    System.Windows.Application.Current.Resources["ColorBrush3"] = new SolidColorBrush(Color3);
                    System.Windows.Application.Current.Resources["ColorBrush4"] = new SolidColorBrush(Color4);
                    System.Windows.Application.Current.Resources["ColorBrush5"] = new SolidColorBrush(Color5);
                    System.Windows.Application.Current.Resources["ColorBrush6"] = new SolidColorBrush(Color6);
                    System.Windows.Application.Current.Resources["ColorBrush7"] = new SolidColorBrush(Color7);
                    System.Windows.Application.Current.Resources["ColorBrush8"] = new SolidColorBrush(Color8);
                    System.Windows.Application.Current.Resources["ColorBrushBg0"] = new SolidColorBrush(ColorBg0);
                    System.Windows.Application.Current.Resources["ColorBrushBg1"] = new SolidColorBrush(ColorBg1);
                    System.Windows.Application.Current.Resources["ColorObject1"] = (Color)Color1;
                    System.Windows.Application.Current.Resources["ColorObject2"] = (Color)Color2;
                    System.Windows.Application.Current.Resources["ColorObject3"] = (Color)Color3;
                    System.Windows.Application.Current.Resources["ColorObject4"] = (Color)Color4;
                    System.Windows.Application.Current.Resources["ColorObject5"] = (Color)Color5;
                    System.Windows.Application.Current.Resources["ColorObject6"] = (Color)Color6;
                    System.Windows.Application.Current.Resources["ColorObject7"] = (Color)Color7;
                    System.Windows.Application.Current.Resources["ColorObject8"] = (Color)Color8;
                    System.Windows.Application.Current.Resources["ColorObjectBg0"] = (Color)ColorBg0;
                    System.Windows.Application.Current.Resources["ColorObjectBg1"] = (Color)ColorBg1;
                    ThemeRefreshMain();
                    if (ThemeNow != 12 && ThemeNow != 14 && ThemeDontClick != 2)
                    {
                        Logger.Info($"刷新主题：{ThemeNow}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "刷新主题颜色失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    public static void ThemeRefreshMain()
    {
        ModBase.RunInUi(checked(() =>
        {
            if (ModMain.FrmMain.IsLoaded)
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush
                {
                    EndPoint = new Point(1.0, 0.0),
                    StartPoint = new Point(0.0, 0.0)
                };
                if (ThemeNow == 5)
                {
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.5,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 15.0)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 1.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
                    });
                    ModMain.FrmMain.PanTitle.Background = linearGradientBrush;
                    ModMain.FrmMain.PanTitle.Background.Freeze();
                }
                else if (ThemeNow != 12 && ThemeDontClick != 2)
                {
                    int[] array = ColorHueTopbarDelta.Switch<int[]>((Func<int, int[]>)((int d) => new int[3]
                    {
                        -d,
                        0,
                        d
                    }), (Func<int[], int[]>)((int[] d) => d));
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + array[0], ColorSat, 48 + ColorLightAdjust)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.5,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + array[1], ColorSat, 54 + ColorLightAdjust)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 1.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + array[2], ColorSat, 48 + ColorLightAdjust)
                    });
                    ModMain.FrmMain.PanTitle.Background = linearGradientBrush;
                    ModMain.FrmMain.PanTitle.Background.Freeze();
                }
                else
                {
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue - 21, ColorSat, 53 + ColorLightAdjust)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.33,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue - 7, ColorSat, 47 + ColorLightAdjust)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.67,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + 7, ColorSat, 47 + ColorLightAdjust)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 1.0,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + 21, ColorSat, 53 + ColorLightAdjust)
                    });
                    ModMain.FrmMain.PanTitle.Background = linearGradientBrush;
                }
                if (ThemeNow >= 5 && ThemeNow != 14)
                {
                    ModMain.FrmMain.ImgTitle.Source = $"{ModBase.PathImage}Themes/{ThemeNow}.png";
                }
                else
                {
                    ModMain.FrmMain.ImgTitle.Source = null;
                }
                ModMain.FrmMain.ImgTitle.Opacity = ((ThemeNow == 13) ? 0.25 : 0.5);
                if (Settings.Get<bool>("UiBackgroundColorful"))
                {
                    linearGradientBrush = new LinearGradientBrush
                    {
                        EndPoint = new Point(0.1, 1.0),
                        StartPoint = new Point(0.9, 0.0)
                    };
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = -0.1,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue - 15, (double)ColorSat * 0.8, 91.0)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 0.4,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue, (double)ColorSat * 0.8, 91.0)
                    });
                    linearGradientBrush.GradientStops.Add(new GradientStop
                    {
                        Offset = 1.1,
                        Color = new ModBase.MyColor().FromHSL2(ColorHue + 15, (double)ColorSat * 0.8, 91.0)
                    });
                    ModMain.FrmMain.PanForm.Background = linearGradientBrush;
                }
                else
                {
                    ModMain.FrmMain.PanForm.Background = new ModBase.MyColor(245.0, 245.0, 245.0);
                }
                ModMain.FrmMain.PanForm.Background.Freeze();
            }
        }));
    }

    internal static void ThemeCheckAll(bool EffectSetup)
    {
        ModBase.RunInUi(() =>
        {
            try
            {
                int num = Settings.Get<int>("UiLauncherTheme");
                if (!ThemeCheckOne(num))
                {
                    Logger.Warn($"检测到尚未解锁的主题：{num}，已重置为默认主题", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    Settings.Set("UiLauncherTheme", 0);
                }
                if (EffectSetup && ModMain.FrmSetupUI != null)
                {
                    List<int> list = new List<int>();
                    int num2 = 0;
                    do
                    {
                        if (ThemeCheckOne(num2))
                        {
                            list.Add(num2);
                        }
                        num2 = checked(num2 + 1);
                    }
                    while (num2 <= 14);
                    list.Add(42);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                if ((ex2.InnerException ?? ex2) is FormatException)
                {
                    Logger.Error(ex2, "解锁的主题列表存档已损坏，主题解锁已被重置", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    Settings.Set("UiLauncherThemeHide2", "");
                }
                else
                {
                    Logger.Error(ex2, "检查主题失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                }
                ProjectData.ClearProjectError();
            }
        });
    }

    internal static bool ThemeCheckOne(int Id)
    {
        if (new int[6] { 0, 1, 2, 3, 4, 42 }.Contains(Id))
        {
            return true;
        }
        if (PotatoFeatures.Contains("Theme" + Conversions.ToString(Id)))
        {
            return true;
        }
        switch (Id)
        {
            case 8:
                return (int)CurrentRank >= 23;
            case 14:
                return Enumerable.Range(5, 9).Count(ThemeCheckOne) >= 5;
            default:
                if (Settings.Get<string>("UiLauncherThemeHide").Contains("7"))
                {
                    ThemeUnlock(7, ShowDoubleHint: false);
                }
                return StringExtensions.Split(Settings.Get<string>("UiLauncherThemeHide2").ToString(), "|", false).Contains(Id.ToString());
        }
    }

    internal static bool ThemeUnlock(int Id, bool ShowDoubleHint = true, string UnlockHint = null)
    {
        return false;
    }

    internal static void UpdateCheckByButton()
    {
        if (_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init == null)
        {
            Interlocked.CompareExchange(ref _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init, new StaticLocalInitFlag(), null);
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init, ref lockTaken);
            if (_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init.State == 0)
            {
                _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init.State = 2;
                _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate = false;
            }
            else if (_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate_0024Init);
            }
        }
        if (_0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate)
        {
            ModMain.Hint("正在检查更新，请稍候！");
            return;
        }
        _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate = true;
        ModBase.RunInThread(() =>
        {
            try
            {
                ModMain.Hint("正在检查更新，请稍候！");
                ServerLoader.WaitForExit(null, null, IsForceRestart: true);
                bool? flag = PageSetupSystem.IsLauncherNewest();
                if (!flag.HasValue)
                {
                    ModMain.Hint("连接 PCL 服务器失败，请确认系统时间是否准确，尝试将 PCL 加入杀毒软件或防火墙白名单，然后重启 PCL！", ModMain.HintType.Red);
                }
                else if (flag == true)
                {
                    ModMain.Hint(string.Format("已经是最新{0} {1}，不需要更新啦，可以直接使用！", "正式版", "2.13.1.1"), ModMain.HintType.Green);
                }
                else
                {
                    if (!HasUpdatePermission)
                    {
                        InputPotatoCode(IsUpdating: true);
                        if (!HasUpdatePermission)
                        {
                            return;
                        }
                    }
                    else if (ModMain.MyMsgBox("发现启动器更新，是否立即下载？", "发现更新！", "更新！冲！", "取消") == 2)
                    {
                        return;
                    }
                    UpdateStart(Silent: false);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "尝试手动开始更新失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                ProjectData.ClearProjectError();
            }
            finally
            {
                _0024STATIC_0024UpdateCheckByButton_0024001_0024IsUiCheckingUpdate = false;
            }
        });
    }

    private static void UpdateStart(bool Silent, IEnumerable<string> UrlsOverride = null)
    {
        if (IsUpdating)
        {
            if (!Silent)
            {
                ModMain.Hint("PCL 正在下载更新，更新结束时将自动重启，请稍候！");
                _0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate = false;
            }
            if (IsUpdateWaitingRestart)
            {
                UpdateRestart(TriggerRestartAndByEnd: true);
            }
            return;
        }
        IsUpdating = true;
        _0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate = Silent;
        if (!_0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate)
        {
            ModMain.Hint("PCL 正在下载更新，更新结束时将自动重启，请稍候！");
        }
        try
        {
            List<string> list = null;
            string text = null;
            string text2 = null;
            ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("启动器更新", new ModLoader.LoaderBase[3]
            {
                new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取更新信息", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
                {
                    if (ServerLoader.State == ModBase.LoadState.Loading)
                    {
                        ServerLoader.WaitForExit();
                    }
                    if (UrlsOverride != null)
                    {
                        list = UrlsOverride.ToList();
                    }
                    else
                    {
                        JObject serverConfig = ServerConfig;
                        object obj;
                        if (serverConfig == null)
                        {
                            obj = null;
                        }
                        else
                        {
                            JToken val = serverConfig["Update"];
                            obj = ((val != null) ? val[(object)ModBase.BuildTypes.Release.ToString()] : null);
                        }
                        if (obj != null)
                        {
                            JObject val2 = (JObject)ServerConfig["Update"][(object)ModBase.BuildTypes.Release.ToString()];
                            if (val2.ContainsKey("PatchUrls") && StringExtensions.StartsWithF(UpdateMark, "Empty", false))
                            {
                                list = val2["PatchUrls"].ToObject<List<string>>();
                            }
                            else if (val2.ContainsKey("DownloadUrls"))
                            {
                                list = val2["DownloadUrls"].ToObject<List<string>>();
                            }
                        }
                    }
                    if (list == null || !list.Any())
                    {
                        Logger.Error("更新失败：服务器没有提供有效的更新包下载链接，或无法连接到服务器！", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        IsUpdating = false;
                    }
                    else
                    {
                        list = list.Select((string u) => ModMain.ArgumentReplace(u, WebUtility.HtmlEncode)).ToList();
                        text = "." + StringExtensions.AfterLast(StringExtensions.BeforeLast(list.First(), "{CDN}", false), ".", false);
                        text2 = string.Format("{0}{1}.{2}{3}", ModMain.RequestTaskTempFolder(), "2.13.1.1", 50, text);
                        Logger.Info(string.Format("更新开始，静默：{0}，扩展名：{1}，下载目标：{2}，URL：{3}", _0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate, text, text2, EnumerableExtensions.Join((IEnumerable)list, "，")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        Task.Output = new ModNet.NetFile[1]
                        {
                            new ModNet.NetFile(list, text2)
                        }.ToList();
                    }
                })
                {
                    ProgressWeight = 0.1
                },
                new ModNet.LoaderDownload("下载更新文件", new List<ModNet.NetFile>())
                {
                    ProgressWeight = 1.0
                },
                new ModLoader.LoaderTask<string, int>("安装更新", (Action<ModLoader.LoaderTask<string, int>>)((ModLoader.LoaderTask<string, int> a0) =>
                {
                    string text3 = Paths.Base + "PCL\\Plain Craft Launcher 2.exe";
                    if (FileUtils.Exists(text3))
                    {
                        FileUtils.Delete(text3, false);
                        Logger.Info($"已清理已存在的更新文件：{text3}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    }
                    if (Operators.CompareString(text, ".zip", TextCompare: false) == 0)
                    {
                        Logger.Info($"解压更新文件：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        FileUtils.ExtractToDirectory(text2, Paths.Base + "PCL\\", default(CancellationToken), (ProgressProvider)null);
                    }
                    else
                    {
                        Logger.Info($"应用补丁文件：{ModBase.PathExe} + {text2} → {Paths.Base}PCL\\Plain Craft Launcher 2.exe", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        MsDelta.Apply(ModBase.PathExe, text2, $"{Paths.Base}PCL\\Plain Craft Launcher 2.exe");
                    }
                    if (_0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate)
                    {
                        IsUpdateWaitingRestart = true;
                    }
                    else
                    {
                        if (ModLaunch.McLaunchLoader.State == ModBase.LoadState.Loading)
                        {
                            ModMain.Hint("更新已准备就绪，PCL 将在游戏启动完成后重启！", ModMain.HintType.Green);
                            while (ModLaunch.McLaunchLoader.State == ModBase.LoadState.Loading)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        UpdateRestart(TriggerRestartAndByEnd: true);
                    }
                }), (Func<string>)null, ThreadPriority.Normal)
                {
                    ProgressWeight = 0.1
                }
            });
            loaderCombo.OnStateChanged = (ModLoader.LoaderBase a0) =>
            {
                if (loaderCombo.State == ModBase.LoadState.Failed)
                {
                    if (_0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate)
                    {
                        Logger.Warn(loaderCombo.Error, "启动器静默更新失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    }
                    else if (ExceptionExtensions.GetDisplay(loaderCombo.Error, false).Contains("(403)"))
                    {
                        ModMain.MyMsgBox("你的系统时间可能并不准确，导致下载验证未通过。\r\n请在校对、修改系统时间后再次尝试更新。", "启动器更新失败");
                    }
                    else if (ExceptionExtensions.GetDisplay(loaderCombo.Error, false).Contains("(404)"))
                    {
                        ModMain.MyMsgBox(string.Format("未找到更新包。可能的原因有：{0}- 你所使用的 PCL 不是官方版本{1}- 服务器异常", "\r\n", "\r\n"), "启动器更新失败");
                    }
                    else if (loaderCombo.Error is FileNotFoundException)
                    {
                        if (ModMain.MyMsgBox(string.Format("由于被 Windows 安全中心拦截，或者存在权限问题，导致 PCL 无法更新。{0}请将 PCL 所在文件夹加入白名单！", "\r\n"), "更新失败", "查看帮助", "确定", "", IsWarn: true) == 1)
                        {
                            CustomEvent.Raise(CustomEvent.EventType.打开帮助, "启动器/Microsoft Defender 添加排除项.json");
                        }
                    }
                    else
                    {
                        Logger.Error(loaderCombo.Error, "启动器更新失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    }
                }
                if (loaderCombo.State == ModBase.LoadState.Finished || loaderCombo.State == ModBase.LoadState.Failed || loaderCombo.State == ModBase.LoadState.Canceled)
                {
                    IsUpdating = false;
                }
            };
            loaderCombo.Start();
            ModBase.RunInUi(() =>
            {
                if (!_0024STATIC_0024UpdateStart_00240212151280E11E_0024IsSilentUpdate)
                {
                    ModLoader.LoaderTaskbarAdd(loaderCombo);
                    ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
                }
            });
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始启动器更新失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            IsUpdating = false;
            ProjectData.ClearProjectError();
        }
    }

    public static void UpdateRestart(bool TriggerRestartAndByEnd)
    {
        try
        {
            IsUpdateWaitingRestart = false;
            string fileName = Paths.Base + "PCL\\Plain Craft Launcher 2.exe";
            string text = $"--update {Process.GetCurrentProcess().Id} \"{AppDomain.CurrentDomain.SetupInformation.ApplicationName}\" \"{AppDomain.CurrentDomain.SetupInformation.ApplicationName}\" {TriggerRestartAndByEnd}";
            Logger.Info($"更新程序启动，参数：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            ModBase.StartProcess(new ProcessStartInfo(fileName)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                Arguments = text
            });
            if (TriggerRestartAndByEnd)
            {
                ModMain.FrmMain.EndProgram(SendWarning: false);
                Logger.Info("已由于更新强制结束程序", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            }
        }
        catch (Win32Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Win32Exception ex2 = ex;
            Logger.Warn((Exception)ex2, "自动更新时触发 Win32 错误，疑似被拦截", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            if (ModMain.MyMsgBox(string.Format("由于被 Windows 安全中心拦截，或者存在权限问题，导致 PCL 无法更新。{0}请将 PCL 所在文件夹加入白名单，或者手动用 {1}PCL\\Plain Craft Launcher 2.exe 替换当前文件！", "\r\n", Paths.Base), "更新失败", "查看帮助", "确定", "", IsWarn: true) == 1)
            {
                CustomEvent.Raise(CustomEvent.EventType.打开帮助, "启动器/Microsoft Defender 添加排除项.json");
            }
            ProjectData.ClearProjectError();
        }
    }

    public static void UpdateReplace(int ProcessId, string OldFileName, string NewFileName, bool TriggerRestart)
    {
        try
        {
            Process.GetProcessById(ProcessId).Kill();
        }
        catch (Exception projectError)
        {
            ProjectData.SetProjectError(projectError);
            ProjectData.ClearProjectError();
        }
        checked
        {
            string text = Paths.Base.Substring(0, Paths.Base.Length - 4) + PathUtils.GetLastPart(OldFileName);
            string text2 = Paths.Base.Substring(0, Paths.Base.Length - 4) + PathUtils.GetLastPart(NewFileName);
            Exception ex = null;
            int num = 0;
            do
            {
                try
                {
                    FileUtils.Delete(text, false);
                    FileUtils.Delete(text2, false);
                    if (!FileUtils.Exists(text) && !FileUtils.Exists(text2))
                    {
                        break;
                    }
                }
                catch (Exception ex2)
                {
                    ProjectData.SetProjectError(ex2);
                    Exception ex3 = ex2;
                    ex = ex3;
                    ProjectData.ClearProjectError();
                }
                Thread.Sleep(num * 500 + 500);
                num++;
            }
            while (num <= 4);
            VB_0024AnonymousDelegate_11<string, string> obj = (string Reason) => string.Format("由于{0}，PCL 无法完成更新。{1}请依次尝试：{2}", Reason, "\r\n", "\r\n") + ((StringExtensions.StartsWithF(Paths.Base, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), true) || StringExtensions.StartsWithF(Paths.Base, Environment.GetFolderPath(Environment.SpecialFolder.Personal), true)) ? " - 将 PCL 文件移动到桌面、文档、C 盘以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "") + (StringExtensions.StartsWithF(Paths.Base, "C", true) ? " - 将 PCL 文件移动到 C 盘以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "") + ((!WindowsUtils.HasAdminRole()) ? " - 右键 PCL，选择以管理员身份运行\r\n" : "") + string.Format(" - 手动剪切 PCL 文件夹中的新版本程序，覆盖原程序：{0}   将位于 {1}{2}   的程序{3}   剪切到 {4} 并覆盖即可。", "\r\n", ModBase.PathExe, "\r\n", "\r\n", text2);
            if (FileUtils.Exists(text) || FileUtils.Exists(text2))
            {
                if (ex is UnauthorizedAccessException)
                {
                    Interaction.MsgBox(string.Format("{0}{1}{2}详细错误信息：{3}{4}", obj("删除老版本文件时权限不足"), "\r\n", "\r\n", "\r\n", ExceptionExtensions.GetDisplay(ex, true)), MsgBoxStyle.Critical, "更新失败");
                }
                else
                {
                    Interaction.MsgBox(string.Format("{0}{1}{2}详细错误信息：{3}{4}", obj("删除老版本文件时出错"), "\r\n", "\r\n", "\r\n", ExceptionExtensions.GetDisplay(ex, true)), MsgBoxStyle.Critical, "更新失败");
                }
                return;
            }
            try
            {
                FileUtils.Copy(ModBase.PathExe, text2);
            }
            catch (UnauthorizedAccessException ex4)
            {
                ProjectData.SetProjectError(ex4);
                UnauthorizedAccessException ex5 = ex4;
                Interaction.MsgBox(string.Format("{0}{1}{2}详细错误信息：{3}{4}", obj("复制新版本文件时权限不足"), "\r\n", "\r\n", "\r\n", ExceptionExtensions.GetDisplay((Exception)ex5, true)), MsgBoxStyle.Critical, "更新失败");
                ProjectData.ClearProjectError();
            }
            catch (Exception ex6)
            {
                ProjectData.SetProjectError(ex6);
                Exception ex7 = ex6;
                Interaction.MsgBox(string.Format("{0}{1}{2}详细错误信息：{3}{4}", obj("复制新版本文件时出错"), "\r\n", "\r\n", "\r\n", ExceptionExtensions.GetDisplay(ex7, true)), MsgBoxStyle.Critical, "更新失败");
                ProjectData.ClearProjectError();
                return;
            }
            if (!TriggerRestart)
            {
                return;
            }
            try
            {
                ModBase.StartProcess(text2);
            }
            catch (Exception ex8)
            {
                ProjectData.SetProjectError(ex8);
                Exception ex9 = ex8;
                Interaction.MsgBox(string.Format("PCL 更新已完成，但在自动重启 PCL 时遇到了意外，请手动启动 PCL。{0}{1}详细错误信息：{2}{3}", "\r\n", "\r\n", "\r\n", ExceptionExtensions.GetDisplay(ex9, true)), MsgBoxStyle.Information, "更新完成");
                ProjectData.ClearProjectError();
            }
        }
    }

    internal static void DownloadLatestPCL(ModLoader.LoaderBase LoaderToSyncProgress = null)
    {
        int num = (FileUtils.Exists(ModBase.PathTemp + "Latest.exe") ? Settings.Get<int>("SystemHighestSavedBetaVersionReg") : 0);
        int num2 = 0;
        string text = FileUtils.TryReadAsString(ModBase.PathTemp + "Cache\\Notice.cfg", (Encoding)null, (Type)null) ?? "";
        if (StringExtensions.Split(text, "|", false).Count() >= 3)
        {
            num2 = Conversions.ToInteger(StringExtensions.Split(text, "|", false)[2]);
        }
        if (num < num2)
        {
            Logger.Info($"需要下载最新正式版：{num} -> {num2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            if (ServerConfig == null)
            {
                ServerLoader.WaitForExit(null, null, ServerLoader.State == ModBase.LoadState.Finished);
            }
            if (ServerConfig == null)
            {
                throw new Exception("无法从服务器获取正式版 PCL 下载链接！");
            }
            ModNet.NetDownloadByLoader(((IEnumerable<JToken>)ServerConfig["Update"][(object)"Release"][(object)"DownloadUrls"]).Select((JToken t) => t.ToString()).ToList(), ModBase.PathTemp + "Latest.zip", LoaderToSyncProgress, new FileChecker
            {
                MinSize = 1048576L
            });
            FileUtils.ExtractToDirectory(ModBase.PathTemp + "Latest.zip", ModBase.PathTemp, default(CancellationToken), (ProgressProvider)null);
            FileUtils.Delete(ModBase.PathTemp + "Latest.zip", false);
            FileUtils.Move(ModBase.PathTemp + "Plain Craft Launcher 2.exe", ModBase.PathTemp + "Latest.exe");
            Settings.Set("SystemHighestSavedBetaVersionReg", num2);
        }
    }

    private static void ServerSub(ModLoader.LoaderTask<int, int> Loader)
    {
        try
        {
            if (FileUtils.Exists(Paths.Base + "PCL\\update.exe"))
            {
                FileUtils.Delete(Paths.Base + "PCL\\update.exe", false);
                Logger.Info("已清理更新缓存", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, "清理更新缓存失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            ProjectData.ClearProjectError();
        }
        int num = 0;
        string text = ModBase.PathTemp + "Cache\\ServerConfig.json";
        checked
        {
            try
            {
                if (FileUtils.Exists(text))
                {
                    ServerConfig = (JObject)FileUtils.ReadAsJson(text, (Encoding)null, (Type)null);
                    num = (int)Math.Round(ModBase.Val(ServerConfig["Version"]));
                    Logger.Info($"已读取本地缓存的配置：{num}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                }
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, "读取配置信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                ServerConfig = null;
                FileUtils.Delete(text, false);
                ProjectData.ClearProjectError();
            }
            Loader.Progress = 0.2;
            int num2 = Settings.Get<int>("HintNotice");
            int num3 = Settings.Get<int>("HintDownload");
            string text2 = ModBase.PathTemp + "Cache\\Notice.cfg";
            string text3;
            int num4;
            int num5;
            try
            {
                text3 = ModNet.NetRequestByClientRetry("https://pcl2-server-1253424809.file.myqcloud.com/notice.cfg{CDN}");
                num4 = (int)Math.Round(ModBase.Val(StringExtensions.Split(text3, "|", false)[0]));
                num5 = (int)Math.Round(ModBase.Val(StringExtensions.Split(text3, "|", false)[3]));
                if (num4 == 0)
                {
                    throw new Exception("获取到的内容有误！（" + text3 + "）");
                }
                if (num4 > num2)
                {
                    Logger.Info($"本地公告编号：{num2}，服务器公告：{text3}，需更新", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                }
                else
                {
                    Logger.Info($"本地公告编号：{num2}，服务器公告：{text3}，无需更新", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    if (Settings.Get<int>("SystemHighestSavedBetaVersionReg") < 408 || !FileUtils.Exists(ModBase.PathTemp + "Latest.exe"))
                    {
                        Settings.Set("SystemHighestSavedBetaVersionReg", 408);
                        Logger.Info($"复制自身为最新正式版：版本号升高到 {408}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        try
                        {
                            FileUtils.Copy(ModBase.PathExe, ModBase.PathTemp + "Latest.exe");
                        }
                        catch (Exception ex5)
                        {
                            ProjectData.SetProjectError(ex5);
                            Exception ex6 = ex5;
                            Logger.Warn(ex6, "复制自身为最新正式版失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                            ProjectData.ClearProjectError();
                        }
                    }
                }
                FileUtils.Write(text2, text3, (Encoding)null);
            }
            catch (Exception ex7)
            {
                ProjectData.SetProjectError(ex7);
                Exception ex8 = ex7;
                if (ex8 is InvalidOperationException && ex8.Message.Contains("FIPS"))
                {
                    if (ModMain.MyMsgBox("由于系统未启用 FIPS 兼容算法，PCL 可能无法正常运行。\r\n请按照教程启用该功能，然后重启 PCL。", "兼容性警告", "打开教程", "取消", "", IsWarn: true) == 1)
                    {
                        ModBase.OpenWebsite("https://blog.csdn.net/qq_37608398/article/details/81209922");
                    }
                }
                else
                {
                    Logger.Warn(ex8, "获取 PCL 服务器状态失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    FileUtils.Delete(text2, false);
                }
                ProjectData.ClearProjectError();
                return;
            }
            Loader.Progress = 0.4;
            try
            {
                double num6 = ModBase.Val(StringExtensions.Split(text3, "|", false)[4]);
                if ((double)num < num6)
                {
                    Logger.Info($"本地配置版本号：{num}，服务器配置版本号：{num6}，需要更新", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    ModNet.NetDownloadByClient("https://pcl2-server-1253424809.file.myqcloud.com/ServerConfig.json{CDN}", text);
                    ServerConfig = (JObject)FileUtils.ReadAsJson(text, (Encoding)null, (Type)null);
                }
            }
            catch (Exception ex9)
            {
                ProjectData.SetProjectError(ex9);
                Exception ex10 = ex9;
                Logger.Warn(ex10, "下载配置信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                ProjectData.ClearProjectError();
            }
            Loader.Progress = 0.6;
            try
            {
                if (num5 > num3 || !FileUtils.Exists(ModBase.PathTemp + "Cache\\download.json"))
                {
                    string text4 = ModNet.NetRequestByClientRetry("https://pcl2-server-1253424809.file.myqcloud.com/minecraft/download.json{CDN}", null, null, null, null, "*/*", null, RequireJson: true);
                    FileUtils.Write(ModBase.PathTemp + "Cache\\download.json", text4, (Encoding)null);
                }
                Settings.Set("HintDownload", num5);
            }
            catch (Exception ex11)
            {
                ProjectData.SetProjectError(ex11);
                Exception ex12 = ex11;
                Logger.Warn(ex12, "下载 PCL 特供版信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                FileUtils.Delete(ModBase.PathTemp + "Cache\\download.json", false);
                ProjectData.ClearProjectError();
            }
            Loader.Progress = 0.8;
            string text5;
            try
            {
                if (num4 <= num2 && FileUtils.Exists(ModBase.PathTemp + "Cache\\Notice.json"))
                {
                    text5 = FileUtils.ReadAsString(ModBase.PathTemp + "Cache\\Notice.json", (Encoding)null, (Type)null);
                }
                else
                {
                    text5 = ModNet.NetRequestByClientRetry("https://pcl2-server-1253424809.file.myqcloud.com/notice.json{CDN}", null, null, null, null, "*/*", null, RequireJson: true);
                    FileUtils.Write(ModBase.PathTemp + "Cache\\Notice.json", text5, (Encoding)null);
                }
                Settings.Set("HintNotice", num4);
            }
            catch (Exception ex13)
            {
                ProjectData.SetProjectError(ex13);
                Exception ex14 = ex13;
                Logger.Warn(ex14, "下载 PCL 服务器公告失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                FileUtils.Delete(ModBase.PathTemp + "Cache\\Notice.json", false);
                ProjectData.ClearProjectError();
                return;
            }
            Loader.Progress = 0.95;
            try
            {
                foreach (JObject item in (IEnumerable<JToken>)StringExtensions.DeserializeJson(text5.Replace("{UNIQUE}", ModBase.Identify)))
                {
                    JObject val = item;
                    int num7 = (int)Math.Round(ModBase.Val(val["id"] ?? (JToken)(0)));
                    if (num7 <= num2)
                    {
                        continue;
                    }
                    bool flag = true;
                    foreach (JProperty item2 in (IEnumerable<JToken>)(val["requirements"] ?? (JToken)(new byte[0])))
                    {
                        JProperty val2 = item2;
                        if (!ServerRequirement(val2.Name, val2.Value))
                        {
                            flag = false;
                        }
                    }
                    if (!flag)
                    {
                        continue;
                    }
                    int num8 = (int)(val["importantLevel"] ?? (JToken)(2));
                    bool flag2 = (bool)(val["isUpdate"] ?? (JToken)(false));
                    Logger.Info($"重要等级 {num8}，更新公告 {flag2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    if (Settings.Get<int>(flag2 ? "SystemSystemUpdate" : "SystemSystemActivity") > num8 || (flag2 && IsUpdating))
                    {
                        continue;
                    }
                    string title = (val["title"] ?? (JToken)("公告")).ToString();
                    string text6 = (val["description"] ?? (JToken)("")).ToString().Replace("\\n", "\r\n");
                    JArray val3 = (JArray)(((object)val["buttons"]) ?? ((object)new JArray()));
                    int count = ((JContainer)val3).Count;
                    object obj = new object[0];
                    if (count > 0)
                    {
                        Logger.Info($"显示公告 {num7}：{text6}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        int num9;
                        switch (count)
                        {
                            case 1:
                                num9 = ModMain.MyMsgBox(text6, title, (val3[0][(object)"text"] ?? (JToken)("确定")).ToString(), "", "", IsWarn: false, HighLight: true, ForceWait: true);
                                break;
                            case 2:
                                num9 = ModMain.MyMsgBox(text6, title, (val3[0][(object)"text"] ?? (JToken)("确定")).ToString(), (val3[1][(object)"text"] ?? (JToken)("确定")).ToString());
                                break;
                            case 3:
                                num9 = ModMain.MyMsgBox(text6, title, (val3[0][(object)"text"] ?? (JToken)("确定")).ToString(), (val3[1][(object)"text"] ?? (JToken)("确定")).ToString(), (val3[2][(object)"text"] ?? (JToken)("确定")).ToString());
                                break;
                            default:
                                Logger.Warn($"公告 {num7} 的弹窗有 {count} 个按钮，无法显示", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                                continue;
                        }
                        num9 = MathUtils.Clamp<int>(num9, 1, count);
                        obj = val3[num9 - 1][(object)"actions"] ?? (JToken)(new byte[0]);
                    }
                    else
                    {
                        obj = val["actions"] ?? (JToken)(new byte[0]);
                    }
                    foreach (JProperty item3 in (IEnumerable)obj)
                    {
                        JProperty val4 = item3;
                        try
                        {
                            switch (val4.Name)
                            {
                                case "copy":
                                    ModBase.ClipboardSet(val4.Value.ToString());
                                    break;
                                case "website":
                                    ModBase.OpenWebsite(val4.Value.ToString());
                                    break;
                                case "stop":
                                    ModMain.FrmMain.EndProgram(SendWarning: false);
                                    break;
                                case "setup":
                                    {
                                        JObject val5 = (JObject)val4.Value;
                                        foreach (KeyValuePair<string, JToken> item4 in val5)
                                        {
                                            Settings.Set(item4.Key, item4.Value.ToString());
                                        }
                                        break;
                                    }
                                case "update":
                                case "slientupdate":
                                    {
                                        _ = (JObject)val4.Value;
                                        bool flag3 = Operators.CompareString(val4.Name, "slientupdate", TextCompare: false) == 0;
                                        if (!HasUpdatePermission)
                                        {
                                            if (!flag3)
                                            {
                                                InputPotatoCode(IsUpdating: true);
                                            }
                                            if (!HasUpdatePermission)
                                            {
                                                break;
                                            }
                                        }
                                        UpdateStart(flag3);
                                        break;
                                    }
                                default:
                                    throw new Exception("未知的行动支：" + val4.Name + ", " + val4.Value.ToString());
                            }
                        }
                        catch (Exception ex15)
                        {
                            ProjectData.SetProjectError(ex15);
                            Exception ex16 = ex15;
                            Logger.Error(ex16, $"执行 PCL 服务器公告动作失败（{val4.Name}, {val4.Value}）", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                            ProjectData.ClearProjectError();
                        }
                    }
                }
            }
            catch (Exception ex17)
            {
                ProjectData.SetProjectError(ex17);
                Exception ex18 = ex17;
                Logger.Warn(text5, (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                Logger.Error(ex18, $"读取 PCL 服务器公告失败（{text5.Length}）", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                FileUtils.Delete(ModBase.PathTemp + "Cache\\Notice.json", false);
                ProjectData.ClearProjectError();
            }
        }
    }

    private static bool ServerRequirement(string Name, JToken Value)
    {
        checked
        {
            bool result;
            try
            {
                switch (Name)
                {
                    case "d10000 <=":
                        result = (double)ModBase.RandomInteger(1, 10000) <= ModBase.Val(Value);
                        break;
                    case "opencount <=":
                        result = (double)Settings.Get<int>("SystemCount") <= ModBase.Val(Value);
                        break;
                    case "opencount >=":
                        result = (double)Settings.Get<int>("SystemCount") >= ModBase.Val(Value);
                        break;
                    case "versioncode <=":
                        result = 408.0 <= ModBase.Val(Value);
                        break;
                    case "versioncode >=":
                        result = 408.0 >= ModBase.Val(Value);
                        break;
                    case "versionbranch <=":
                        result = ModBase.Val(50) <= ModBase.Val(Value);
                        break;
                    case "versionbranch >=":
                        result = ModBase.Val(50) >= ModBase.Val(Value);
                        break;
                    case "uniqueaddress =":
                        result = Operators.CompareString(ModBase.Identify, Value.ToString(), TextCompare: false) == 0;
                        break;
                    case "unlockedtheme =":
                        result = ThemeCheckOne((int)Math.Round(ModBase.Val(Value)));
                        break;
                    case "unlockedtheme !=":
                        result = !ThemeCheckOne((int)Math.Round(ModBase.Val(Value)));
                        break;
                    case "setupinteger >=":
                        result = (double)Settings.Get<int>(((JProperty)Value).Name) >= ModBase.Val(((JProperty)Value).Value);
                        break;
                    case "setupinteger <=":
                        result = (double)Settings.Get<int>(((JProperty)Value).Name) <= ModBase.Val(((JProperty)Value).Value);
                        break;
                    case "setupboolean =":
                        result = Settings.Get<bool>(((JProperty)Value).Name) == ((JProperty)Value).Value.ToObject<bool>();
                        break;
                    case "debug =":
                        result = Operators.CompareString(StringExtensions.Lower(ModBase.ModeDebug.ToString()), StringExtensions.Lower(Value.ToString()), TextCompare: false) == 0;
                        break;
                    default:
                        Logger.Warn($"未知的条件支：{Name}, {Value}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                        result = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn($"判断分支条件失败：{Name}, {Value}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }
    }

    private static OneOf<List<string>, string> CheckPotatoCode(string Key)
    {
        OneOf<List<string>, string> result;
        if (string.IsNullOrEmpty(Key))
        {
            result = (OneOf<List<string>, string>)("输入的土豆码为空。");
        }
        else if (Key.Length < 30 && StringExtensions.ContainsIgnoreCase(Key, ModBase.Identify))
        {
            result = (OneOf<List<string>, string>)(string.Format("你输入的是识别码，不是土豆码。{0}要获取土豆码，请在爱发电私信发送【土豆 {1}】。", "\r\n", ModBase.Identify));
        }
        else if (Key.Length > 85 && Key.Length < 90 && StringExtensions.EndsWithF(Key, "=", false))
        {
            result = (OneOf<List<string>, string>)(string.Format("你输入的是解锁码，不是土豆码。{0}要获取土豆码，请在爱发电私信发送【土豆】。", "\r\n"));
        }
        else if (Key.Length > 150 && Key.Length < 165 && StringExtensions.EndsWithF(Key, "11", false))
        {
            result = (OneOf<List<string>, string>)(string.Format("你输入的是更新密钥，不是土豆码。{0}要获取土豆码，请在爱发电私信发送【土豆】。", "\r\n"));
        }
        else if (!StringExtensions.StartsWithF(Key, "CD", true) || !Key.Contains("#"))
        {
            result = (OneOf<List<string>, string>)(string.Format("你输入的不是土豆码……有一说一，这是啥玩意儿？{0}要获取土豆码，请在爱发电私信发送【土豆 {1}】。", "\r\n", ModBase.Identify));
        }
        else if (Key[2] > '1')
        {
            result = (OneOf<List<string>, string>)(string.Format("这个土豆码得在新版 PCL 上才能使用。{0}请更新 PCL，或是在爱发电私信发送【下载】，然后在新下载的 PCL 上输入土豆码。", "\r\n"));
        }
        else if ('1' > Key[3])
        {
            result = (OneOf<List<string>, string>)(string.Format("这个土豆码不太新鲜，已经过期了。{0}请在爱发电私信重新发送【土豆 {1}】，获取更新鲜的土豆码。", "\r\n", ModBase.Identify));
        }
        else if (!StringExtensions.StartsWithF(Key, "CD", false))
        {
            result = (OneOf<List<string>, string>)(string.Format("土豆码区分大小写，但你把一些大写的东西输成小写的了。{0}你可以选中文本，然后右键复制粘贴，不必手动输入。", "\r\n"));
        }
        else
        {
            try
            {
                string[] array = Key.Substring(4).Replace("p", "=").Replace("%", "p")
                    .Split('#');
                string text = Encoding.UTF8.GetString(Convert.FromBase64String(array[1]));
                CryptographyUtils.EcdsaVerify(ModBase.Identify + Conversions.ToString(Key[2]) + Conversions.ToString(Key[3]) + text, array[0], "RUNTMSAAAAC4QTUNAewh23Q4Q6koHkyIrDIIZUSbua23sf2DiZmIRwSzadISDRyTVTbuWniH3KR7rKj8XBsabms1be6i3c+S");
                result = (OneOf<List<string>, string>)(StringExtensions.Split(text, ',', true).ToList());
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, $"土豆码校验失败（{Key}）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                result = (OneOf<List<string>, string>)(string.Format("土豆码有误，请检查：{0}- 私信显示的识别码应当为 {1}，如果不是，请在私信发送【土豆 {2}】{3}- 你输入的以下土豆码是否与私信中的一致：{4}{5}{6}{7}错误原因：{8}", "\r\n", ModBase.Identify, ModBase.Identify, "\r\n", "\r\n", Key, "\r\n", "\r\n", ex2.Message));
                ProjectData.ClearProjectError();
            }
        }
        return result;
    }

    public static void InputPotatoCode(bool IsUpdating)
    {
        ModMain.Hint("请使用 PCL 快照版输入土豆码！如果你赞助过 PCL，可以在爱发电私信发送【下载】获取 PCL 快照版！");
    }

    internal static void GeneratePotatoCode()
    {
    }

    internal static string GetIdentify()
    {
        string result;
        try
        {
            if (ModBase.ApplicationStartTick < 1)
            {
                result = "0000-0000-0000-0000";
            }
            else
            {
                string text;
                try
                {
                    text = StringExtensions.Upper(RegistryUtils.TryRead(string.Format("HKEY_LOCAL_MACHINE\\SYSTEM\\Har{0}wareConfig", StringExtensions.Lower("D")), "LastConfig", (object)"Unknown").ToString()).Trim('{', '}');
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Warn(ex2, "获取主板标识码失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
                    text = "Unknown";
                    ProjectData.ClearProjectError();
                }
                string text2;
                try
                {
                    text2 = Settings.Get<string>("Identify");
                }
                catch (Exception projectError)
                {
                    ProjectData.SetProjectError(projectError);
                    text2 = "";
                    ProjectData.ClearProjectError();
                }
                if (text2.Length < 3)
                {
                    text2 = Conversions.ToString(ModBase.GetTimeMs()) + Conversions.ToString(MyWpfExtension.Computer.Info.AvailablePhysicalMemory);
                    Settings.Set("Identify", text2);
                }
                string text3 = StringExtensions.EnsureLength(StringExtensions.GetStableHashCode(text + text2).ToString("X"), '7', 16);
                result = $"{text3.Substring(4, 4)}-{text3.Substring(12, 4)}-{text3.Substring(0, 4)}-{text3.Substring(8, 4)}";
            }
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Error(ex4, string.Format("PCL 无法获取设备识别码，这可能会导致部分设置无法正常存储。{0}{1}详细的错误信息", "\r\n", "\r\n"), (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\ModSecret.vb");
            result = "0000-0000-0000-0000";
            ProjectData.ClearProjectError();
        }
        return result;
    }
}

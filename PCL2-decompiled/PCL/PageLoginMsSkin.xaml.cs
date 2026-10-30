using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginMsSkin : Grid, IComponentConnector
{
    private bool IsChanging;

    [CompilerGenerated]
    [AccessedThroughProperty("PanData")]
    private Grid _PanData;

    [CompilerGenerated]
    [AccessedThroughProperty("TextName")]
    private TextBlock _TextName;

    [CompilerGenerated]
    [AccessedThroughProperty("PanButtons")]
    private Border _PanButtons;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSkin")]
    private MyIconButton _BtnSkin;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnEdit")]
    private MyIconButton _BtnEdit;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnExit")]
    private MyIconButton _BtnExit;

    [CompilerGenerated]
    [AccessedThroughProperty("Skin")]
    private MySkin _Skin;

    internal virtual Grid PanData_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanData;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseEventHandler value2 = ShowPanel;
            MouseEventHandler value3 = HidePanel;
            Grid grid = _PanData;
            if (grid != null)
            {
                grid.MouseEnter -= value2;
                grid.MouseLeave -= value3;
            }
            _PanData = value;
            grid = _PanData;
            if (grid != null)
            {
                grid.MouseEnter += value2;
                grid.MouseLeave += value3;
            }
        }
    }

    internal virtual TextBlock TextName_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextName;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextName = value;
        }
    }

    internal virtual Border PanButtons_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanButtons;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanButtons = value;
        }
    }

    internal virtual MyIconButton BtnSkin_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSkin;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = (object a0, EventArgs a1) =>
            {
                BtnSkin_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
            };
            MyIconButton myIconButton = _BtnSkin;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnSkin = value;
            myIconButton = _BtnSkin;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MyIconButton BtnEdit_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnEdit;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = BtnEdit_Click;
            MyIconButton myIconButton = _BtnEdit;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnEdit = value;
            myIconButton = _BtnEdit;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MyIconButton BtnExit_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnExit;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = (object a0, EventArgs a1) =>
            {
                BtnExit_Click();
            };
            MyIconButton myIconButton = _BtnExit;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnExit = value;
            myIconButton = _BtnExit;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MySkin Skin_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Skin;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _Skin = value;
        }
    }

    public PageLoginMsSkin()
    {
        Loaded += PageLoginLegacy_Loaded;
        IsChanging = false;
        InitializeComponent();
        _InitWithEvents();
        Skin.Loader = PageLaunchLeft.SkinMs;
    }

    private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
    {
        Skin.Loader.Start();
    }

    public void Reload(bool KeepInput)
    {
        TextName.Text = Settings.Get<string>("CacheMsV2Name");
    }

    public static ModLaunch.McLoginMs GetLoginData()
    {
        if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Finished)
        {
            return new ModLaunch.McLoginMs
            {
                OAuthRefreshToken = Settings.Get<string>("CacheMsV2OAuthRefresh"),
                UserName = Settings.Get<string>("CacheMsV2Name"),
                AccessToken = Settings.Get<string>("CacheMsV2Access"),
                Uuid = Settings.Get<string>("CacheMsV2Uuid"),
                ProfileJson = Settings.Get<string>("CacheMsV2ProfileJson")
            };
        }
        return new ModLaunch.McLoginMs
        {
            OAuthRefreshToken = Settings.Get<string>("CacheMsV2OAuthRefresh"),
            UserName = Settings.Get<string>("CacheMsV2Name")
        };
    }

    private void ShowPanel(object sender, MouseEventArgs e)
    {
        ModAnimation.AniStart(ModAnimation.AaOpacity(PanButtons, 1.0 - PanButtons.Opacity, 120), "PageLoginMsSkin Button");
    }

    public void HidePanel(object sender, EventArgs e)
    {
        if (!BtnEdit.ContextMenu.IsOpen && !BtnSkin.ContextMenu.IsOpen && !PanData.IsMouseOver)
        {
            ModAnimation.AniStart(ModAnimation.AaOpacity(PanButtons, 0.0 - PanButtons.Opacity, 120), "PageLoginMsSkin Button");
        }
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        BtnEdit.ContextMenu.IsOpen = true;
    }

    private void BtnExit_Click()
    {
        Settings.Set("CacheMsV2OAuthRefresh", "");
        Settings.Set("CacheMsV2Access", "");
        Settings.Set("CacheMsV2ProfileJson", "");
        Settings.Set("CacheMsV2Uuid", "");
        Settings.Set("CacheMsV2Name", "");
        Settings.Set("CacheMsV2Expires", 0L);
        ModLaunch.McLoginMsLoader.Cancel();
        ModMain.FrmLaunchLeft.RefreshPage(KeepInput: false, Anim: true);
    }

    private void BtnSkin_Click(object sender, RoutedEventArgs e)
    {
        BtnSkin.ContextMenu.IsOpen = true;
    }

    public void BtnSkinEdit_Click(object sender, RoutedEventArgs e)
    {
        if (IsChanging)
        {
            ModMain.Hint("正在更改皮肤中，请稍候！");
            return;
        }
        if (ModLaunch.McLoginLoader.State == ModBase.LoadState.Failed)
        {
            ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Red);
            return;
        }
        ModMinecraft.McSkinInfo skinInfo = ModMinecraft.McSkinSelect();
        if (skinInfo.IsVaild)
        {
            ModMain.Hint("正在更改皮肤……");
            IsChanging = true;
            ModBase.RunInNewThread(() =>
            {
                EditSkin(skinInfo);
            }, "Ms Skin Upload");
        }
    }

    private void EditSkin(ModMinecraft.McSkinInfo SkinInfo)
    {
        while (true)
        {
            try
            {
                while (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Loading)
                {
                    Thread.Sleep(10);
                }
                if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Failed)
                {
                    throw new Exception("登录失败", ModLaunch.McLoginMsLoader.Error);
                }
                string text = Settings.Get<string>("CacheMsV2Access");
                Settings.Get<string>("CacheMsV2Uuid");
                string text2 = ModNet.NetRequestByClientRetry("https://api.minecraftservices.com/minecraft/profile/skins", HttpMethod.Post, null, new MultipartFormDataContent
                {
                    {
                        new StringContent(SkinInfo.IsSlim ? "slim" : "classic"),
                        "variant"
                    },
                    {
                        new ByteArrayContent(FileUtils.ReadAsBytes(SkinInfo.LocalFile, (Type)null)),
                        "file",
                        PathUtils.GetLastPart(SkinInfo.LocalFile)
                    }
                }, null, "*/*", new string[3, 2]
                {
                    {
                        "Authorization",
                        "Bearer " + text
                    },
                    { "Accept", "*/*" },
                    { "User-Agent", "MojangSharp/0.1" }
                });
                if (text2.Contains("request requires user authentication"))
                {
                    ModMain.Hint("正在重新登录，将在登录后自动更改皮肤……");
                    ModLaunch.McLoginMsLoader.Start(GetLoginData(), IsForceRestart: true);
                    continue;
                }
                Logger.Info(string.Format("皮肤修改返回值：{0}{1}", "\r\n", text2), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMsSkin.xaml.vb");
                JObject val = (JObject)StringExtensions.DeserializeJson(text2);
                if (val.ContainsKey("errorMessage"))
                {
                    throw new Exception(val["errorMessage"].ToString());
                }
                foreach (JObject item in (IEnumerable<JToken>)val["skins"])
                {
                    JObject val2 = item;
                    if (Operators.CompareString(val2["state"].ToString(), "ACTIVE", TextCompare: false) == 0)
                    {
                        MySkin.ReloadCache((string)val2["url"]);
                        return;
                    }
                }
                throw new Exception("未知错误（" + text2 + "）");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                if (ex2 is HttpRequestCodeException)
                {
                    HttpRequestCodeException ex3 = (HttpRequestCodeException)ex2;
                    switch (ex3.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            {
                                Logger.Warn(ex2, "更改皮肤时遭遇 400 错误", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMsSkin.xaml.vb");
                                string response = ex3.Response;
                                if (response != null && response.Contains("\"error\""))
                                {
                                    ModMain.Hint("更改皮肤失败：" + StringExtensions.DeserializeJson(ex3.Response)[(object)"error"].ToString(), ModMain.HintType.Red);
                                    ProjectData.ClearProjectError();
                                    return;
                                }
                                string response2 = ex3.Response;
                                if (response2 != null && response2.Contains("\"errorMessage\""))
                                {
                                    ModMain.Hint("更改皮肤失败：" + StringExtensions.DeserializeJson(ex3.Response)[(object)"errorMessage"].ToString(), ModMain.HintType.Red);
                                    ProjectData.ClearProjectError();
                                    return;
                                }
                                break;
                            }
                        case HttpStatusCode.Unauthorized:
                            Logger.Warn(ex2, "更改皮肤时遭遇 401 错误", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMsSkin.xaml.vb");
                            ModMain.Hint("正在重新登录，将在登录后自动更改皮肤……");
                            ModLaunch.McLoginMsLoader.Start(GetLoginData(), IsForceRestart: true);
                            ProjectData.ClearProjectError();
                            goto end_IL_0212;
                    }
                }
                else if (ExceptionExtensions.IsBadNetwork(ex2))
                {
                    ModMain.Hint("更改皮肤失败：连接 Mojang 服务器超时，请稍后再试，或使用 VPN 改善网络环境", ModMain.HintType.Red);
                }
                else
                {
                    Logger.Error(ex2, "更改皮肤失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMsSkin.xaml.vb");
                }
                ProjectData.ClearProjectError();
                break;
            end_IL_0212:;
            }
            finally
            {
                IsChanging = false;
            }
        }
    }

    public void BtnSkinSave_Click(object sender, RoutedEventArgs e)
    {
        Skin.BtnSkinSave_Click();
    }

    public void BtnSkinRefresh_Click(object sender, RoutedEventArgs e)
    {
        Skin.RefreshClick();
    }

    public void BtnSkinCape_Click(object sender, RoutedEventArgs e)
    {
        Skin.BtnSkinCape_Click();
    }

    public void BtnSkinCapeRefresh_Click(object sender, RoutedEventArgs e)
    {
        ModBase.RunInThread(() =>
        {
            try
            {
                ModMain.Hint("正在刷新披风列表……");
                if (ModLaunch.McLaunchLoader.State == ModBase.LoadState.Loading)
                {
                    ModLaunch.McLoginMsLoader.WaitForExit();
                }
                else
                {
                    ModLaunch.McLoginMsLoader.WaitForExit(GetLoginData(), null, IsForceRestart: true);
                }
                ModMain.Hint("已刷新披风列表！", ModMain.HintType.Green);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "刷新披风列表失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMsSkin.xaml.vb");
                ProjectData.ClearProjectError();
            }
        });
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnEdit_WithEvents = BtnEdit;
        BtnExit_WithEvents = BtnExit;
        BtnSkin_WithEvents = BtnSkin;
        PanButtons_WithEvents = PanButtons;
        PanData_WithEvents = PanData;
        Skin_WithEvents = Skin;
        TextName_WithEvents = TextName;
    }
}

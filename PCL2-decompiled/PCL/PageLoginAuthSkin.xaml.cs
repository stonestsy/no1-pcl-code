using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginAuthSkin : Grid, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("PanData")]
    private Grid _PanData;

    [CompilerGenerated]
    [AccessedThroughProperty("TextName")]
    private TextBlock _TextName;

    [CompilerGenerated]
    [AccessedThroughProperty("TextEmail")]
    private TextBlock _TextEmail;

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
            MouseEventHandler value2 = PageLoginAuthSkin_MouseEnter;
            MouseEventHandler value3 = PageLoginAuthSkin_MouseLeave;
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

    internal virtual TextBlock TextEmail_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextEmail;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextEmail = value;
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
                ExitLogin();
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
            MySkin.ClickEventHandler obj = Skin_Click;
            MySkin mySkin = _Skin;
            if (mySkin != null)
            {
                mySkin.Click -= obj;
            }
            _Skin = value;
            mySkin = _Skin;
            if (mySkin != null)
            {
                mySkin.Click += obj;
            }
        }
    }

    public PageLoginAuthSkin()
    {
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            PageLoginLegacy_Loaded();
        };
        InitializeComponent();
        _InitWithEvents();
        Skin.Loader = PageLaunchLeft.SkinAuth;
    }

    private void PageLoginLegacy_Loaded()
    {
        Skin.Loader.Start();
    }

    public void Reload(bool KeepInput)
    {
        TextName.Text = Settings.Get<string>("CacheAuthName");
        TextEmail.Text = Settings.Get<string>("CacheAuthUsername");
        TextEmail.Visibility = (Settings.Get<bool>("UiLauncherEmail") ? Visibility.Collapsed : Visibility.Visible);
        PageLoginLegacy_Loaded();
    }

    public static ModLaunch.McLoginServer GetLoginData()
    {
        string baseUrl = (Information.IsNothing(ModMinecraft.McInstanceSelected) ? Settings.Get<string>("CacheAuthServerServer") : Settings.Get<string>("VersionServerAuthServer", ModMinecraft.McInstanceSelected)) + "/authserver";
        return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
        {
            Token = "Auth",
            BaseUrl = baseUrl,
            UserName = Settings.Get<string>("CacheAuthUsername"),
            Password = Settings.Get<string>("CacheAuthPass"),
            Description = "Authlib-Injector",
            Type = ModLaunch.McLoginType.Auth
        };
    }

    private void PageLoginAuthSkin_MouseEnter(object sender, MouseEventArgs e)
    {
        ModAnimation.AniStart(new ModAnimation.AniData[6]
        {
            ModAnimation.AaOpacity(BtnEdit, 1.0 - BtnEdit.Opacity, 80),
            ModAnimation.AaHeight(BtnEdit, 25.5 - BtnEdit.Height, 140, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnEdit, -1.5, 50, 140, new ModAnimation.AniEaseInFluent()),
            ModAnimation.AaOpacity(BtnExit, 1.0 - BtnExit.Opacity, 80),
            ModAnimation.AaHeight(BtnExit, 25.5 - BtnExit.Height, 140, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnExit, -1.5, 50, 140, new ModAnimation.AniEaseInFluent())
        }, "PageLoginAuthSkin Button");
    }

    private void PageLoginAuthSkin_MouseLeave(object sender, MouseEventArgs e)
    {
        ModAnimation.AniStart(new ModAnimation.AniData[4]
        {
            ModAnimation.AaOpacity(BtnEdit, 0.0 - BtnEdit.Opacity, 120, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnEdit, 14.0 - BtnEdit.Height, 120, 0, new ModAnimation.AniEaseInFluent()),
            ModAnimation.AaOpacity(BtnExit, 0.0 - BtnExit.Opacity, 120, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnExit, 14.0 - BtnExit.Height, 120, 0, new ModAnimation.AniEaseInFluent())
        }, "PageLoginAuthSkin Button");
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        if (ModLaunch.McLoginLoader.State == ModBase.LoadState.Loading)
        {
            Logger.Warn("要求更换角色，但登录加载器繁忙", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginAuthSkin.xaml.vb");
            if (ModLaunch.McLoginLoader.Input is ModLaunch.McLoginServer && ((ModLaunch.McLoginServer)ModLaunch.McLoginLoader.Input).ForceReselectProfile)
            {
                ModMain.Hint("正在尝试更换，请稍候！");
            }
            else
            {
                ModMain.Hint("正在登录中，请稍后再更换角色！", ModMain.HintType.Red);
            }
            return;
        }
        ModMain.Hint("正在尝试更换，请稍候！");
        Settings.Set("CacheAuthUuid", "");
        Settings.Set("CacheAuthName", "");
        ModBase.RunInThread(() =>
        {
            try
            {
                ModLaunch.McLoginServer loginData = GetLoginData();
                loginData.ForceReselectProfile = true;
                ModLaunch.McLoginLoader.WaitForExit(loginData, null, IsForceRestart: true);
                ModBase.RunInUi(() =>
                {
                    Reload(KeepInput: true);
                });
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "更换角色失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginAuthSkin.xaml.vb");
                ProjectData.ClearProjectError();
            }
        });
    }

    public static void ExitLogin()
    {
        Settings.Set("CacheAuthAccess", "");
        Settings.Set("CacheAuthUuid", "");
        Settings.Set("CacheAuthName", "");
        ModLaunch.McLoginAuthLoader.Input = null;
        ModMain.FrmLaunchLeft.RefreshPage(KeepInput: false, Anim: true);
    }

    private void Skin_Click(object sender, MouseButtonEventArgs e)
    {
        string text = (((object)ModMinecraft.McInstanceSelected != null) ? Settings.Get<string>("VersionServerAuthRegister", ModMinecraft.McInstanceSelected) : Settings.Get<string>("CacheAuthServerRegister"));
        if (string.IsNullOrEmpty(new ValidateHttp().Validate(text)))
        {
            ModBase.OpenWebsite(text.Replace("/auth/register", "/user/closet"));
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnEdit_WithEvents = BtnEdit;
        BtnExit_WithEvents = BtnExit;
        PanData_WithEvents = PanData;
        Skin_WithEvents = Skin;
        TextEmail_WithEvents = TextEmail;
        TextName_WithEvents = TextName;
    }
}

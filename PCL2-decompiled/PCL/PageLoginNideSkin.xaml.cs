using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginNideSkin : Grid, IComponentConnector
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
            MouseEventHandler value2 = PageLoginNideSkin_MouseEnter;
            MouseEventHandler value3 = PageLoginNideSkin_MouseLeave;
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
            _BtnEdit = value;
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

    public PageLoginNideSkin()
    {
        Loaded += PageLoginLegacy_Loaded;
        InitializeComponent();
        _InitWithEvents();
        Skin.Loader = PageLaunchLeft.SkinNide;
    }

    private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
    {
        Skin.Loader.Start();
    }

    public void Reload(bool KeepInput)
    {
        TextName.Text = Settings.Get<string>("CacheNideName");
        TextEmail.Text = Settings.Get<string>("CacheNideUsername");
        TextEmail.Visibility = ModBase.ToVisibility(!Settings.Get<bool>("UiLauncherEmail"));
    }

    public static ModLaunch.McLoginServer GetLoginData()
    {
        string text = (Information.IsNothing(ModMinecraft.McInstanceSelected) ? Settings.Get<string>("CacheNideServer") : Settings.Get<string>("VersionServerNide", ModMinecraft.McInstanceSelected));
        return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Nide)
        {
            Token = "Nide",
            UserName = Settings.Get<string>("CacheNideUsername"),
            Password = Settings.Get<string>("CacheNidePass"),
            Description = "统一通行证",
            Type = ModLaunch.McLoginType.Nide,
            BaseUrl = "https://auth.mc-user.com:233/" + text + "/authserver"
        };
    }

    private void PageLoginNideSkin_MouseEnter(object sender, MouseEventArgs e)
    {
        ModAnimation.AniStart(new ModAnimation.AniData[6]
        {
            ModAnimation.AaOpacity(BtnEdit, 1.0 - BtnEdit.Opacity, 80),
            ModAnimation.AaHeight(BtnEdit, 25.5 - BtnEdit.Height, 140, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnEdit, -1.5, 50, 140, new ModAnimation.AniEaseInFluent()),
            ModAnimation.AaOpacity(BtnExit, 1.0 - BtnExit.Opacity, 80),
            ModAnimation.AaHeight(BtnExit, 25.5 - BtnExit.Height, 140, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnExit, -1.5, 50, 140, new ModAnimation.AniEaseInFluent())
        }, "PageLoginNideSkin Button");
    }

    private void PageLoginNideSkin_MouseLeave(object sender, MouseEventArgs e)
    {
        ModAnimation.AniStart(new ModAnimation.AniData[4]
        {
            ModAnimation.AaOpacity(BtnEdit, 0.0 - BtnEdit.Opacity, 120, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnEdit, 14.0 - BtnEdit.Height, 120, 0, new ModAnimation.AniEaseInFluent()),
            ModAnimation.AaOpacity(BtnExit, 0.0 - BtnExit.Opacity, 120, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaHeight(BtnExit, 14.0 - BtnExit.Height, 120, 0, new ModAnimation.AniEaseInFluent())
        }, "PageLoginNideSkin Button");
    }

    public static void ExitLogin()
    {
        Settings.Set("CacheNideAccess", "");
        ModLaunch.McLoginNideLoader.Input = null;
        ModMain.FrmLaunchLeft.RefreshPage(KeepInput: false, Anim: true);
    }

    private void Skin_Click(object sender, MouseButtonEventArgs e)
    {
        ModBase.OpenWebsite("https://login.mc-user.com:233/" + (Information.IsNothing(ModMinecraft.McInstanceSelected) ? Settings.Get<string>("CacheNideServer") : Settings.Get<string>("VersionServerNide", ModMinecraft.McInstanceSelected)) + "/skin");
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

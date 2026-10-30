using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginLegacy : Grid, IComponentConnector
{
    public bool IsReloaded;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("HintChinese")]
    private MyHint _HintChinese;

    [CompilerGenerated]
    [AccessedThroughProperty("Skin")]
    private MySkin _Skin;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboName")]
    private MyComboBox _ComboName;

    internal virtual StackPanel PanMain_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanMain;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanMain = value;
        }
    }

    internal virtual MyHint HintChinese_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintChinese;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintChinese = value;
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
            MySkin.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                Skin_Click();
            };
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

    internal virtual MyComboBox ComboName_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboName;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            KeyEventHandler value2 = ComboName_PreviewKeyDown;
            MyComboBox.TextChangedEventHandler obj = ComboLegacy_TextChanged;
            MyComboBox myComboBox = _ComboName;
            if (myComboBox != null)
            {
                myComboBox.PreviewKeyDown -= value2;
                myComboBox.TextChanged -= obj;
            }
            _ComboName = value;
            myComboBox = _ComboName;
            if (myComboBox != null)
            {
                myComboBox.PreviewKeyDown += value2;
                myComboBox.TextChanged += obj;
            }
        }
    }

    public PageLoginLegacy()
    {
        Loaded += PageLoginLegacy_Loaded;
        IsReloaded = false;
        InitializeComponent();
        _InitWithEvents();
        Skin.Loader = PageLaunchLeft.SkinLegacy;
    }

    private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
    {
        Skin.Loader.Start();
    }

    public void Reload(bool KeepInput)
    {
        if (KeepInput && IsReloaded)
        {
            string text = ComboName.Text.Trim();
            ComboName.ItemsSource = ((Operators.CompareString(Settings.Get<string>("LoginLegacyName"), "", TextCompare: false) == 0) ? null : StringExtensions.Split(Settings.Get<string>("LoginLegacyName"), "\u00a8", false));
            ComboName.Text = text;
        }
        else if (Operators.CompareString(Settings.Get<string>("LoginLegacyName"), "", TextCompare: false) == 0)
        {
            ComboName.ItemsSource = null;
        }
        else
        {
            ComboName.ItemsSource = StringExtensions.Split(Settings.Get<string>("LoginLegacyName").ToString(), "\u00a8", false);
            ComboName.Text = StringExtensions.BeforeFirst(Settings.Get<string>("LoginLegacyName").ToString(), "\u00a8", false).Trim();
        }
        IsReloaded = true;
    }

    public static ModLaunch.McLoginData GetLoginData()
    {
        string userName = ((ModMain.FrmLoginLegacy == null) ? "" : ModMain.FrmLoginLegacy.ComboName.Text.Replace("\u00a8", "").Trim());
        return new ModLaunch.McLoginLegacy
        {
            UserName = userName,
            SkinType = Settings.Get<int>("LaunchSkinType"),
            SkinName = Settings.Get<string>("LaunchSkinID")
        };
    }

    public static string IsVaild(ModLaunch.McLoginLegacy LoginData)
    {
        if (Operators.CompareString(LoginData.UserName.Trim(), "", TextCompare: false) == 0)
        {
            return "玩家名不能为空！";
        }
        if (LoginData.UserName.Contains("\""))
        {
            return "玩家名不能包含英文引号！";
        }
        if ((object)ModMinecraft.McInstanceSelected != null && ModMinecraft.McInstanceSelected.Version.Vaild && ModMinecraft.McInstanceSelected.Version.Vanilla >= new Version(20, 0, 3) && LoginData.UserName.Trim().Length > 16)
        {
            return "自 1.20.3 起，玩家名至多只能包含 16 个字符！";
        }
        return "";
    }

    public string IsVaild()
    {
        return IsVaild((ModLaunch.McLoginLegacy)GetLoginData());
    }

    private void ComboName_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            int caretIndex = ((MyTextBox)ComboName.Template.FindName("PART_EditableTextBox", ComboName)).CaretIndex;
            if (caretIndex == ComboName.Text.Length || caretIndex == 0)
            {
                e.Handled = true;
            }
        }
    }

    private void ComboLegacy_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Settings.Get<int>("LaunchSkinType") == 0)
        {
            PageLaunchLeft.SkinLegacy.Start(null, IsForceRestart: true);
        }
        HintChinese.Visibility = (StringExtensions.RegexCheck(ComboName.Text, "^[0-9A-Za-z_]*$", RegexOptions.None) ? Visibility.Collapsed : Visibility.Visible);
        ModBase.RunInUi(() =>
        {
            PanMain.InvalidateMeasure();
        }, ForceWaitUntilLoaded: true);
    }

    private void Skin_Click()
    {
        if ((Settings.Get<bool>("UiHiddenPageSetup") || Settings.Get<bool>("UiHiddenSetupLaunch")) && !PageSetupUI.HiddenForceShow)
        {
            ModMain.Hint("启动设置已被禁用！", ModMain.HintType.Red);
        }
        else
        {
            ModMain.FrmMain.PageChange(FormMain.PageType.Setup);
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        ComboName_WithEvents = ComboName;
        HintChinese_WithEvents = HintChinese;
        PanMain_WithEvents = PanMain;
        Skin_WithEvents = Skin;
    }
}

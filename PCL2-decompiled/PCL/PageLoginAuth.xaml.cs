using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginAuth : Grid, IComponentConnector
{
    private bool IsFirstLoad;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboName")]
    private MyComboBox _ComboName;

    [CompilerGenerated]
    [AccessedThroughProperty("TextPass")]
    private PasswordBox _TextPass;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckRemember")]
    private MyCheckBox _CheckRemember;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLink")]
    private MyTextButton _BtnLink;

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
            MyComboBox.TextChangedEventHandler obj = ComboName_TextChanged;
            SelectionChangedEventHandler value2 = (object a0, SelectionChangedEventArgs a1) =>
            {
                ComboName_SelectionChanged((MyComboBox)a0, a1);
            };
            MyComboBox.TextChangedEventHandler obj2 = (object a0, TextChangedEventArgs a1) =>
            {
                ComboName_TextChanged();
            };
            MyComboBox myComboBox = _ComboName;
            if (myComboBox != null)
            {
                myComboBox.TextChanged -= obj;
                myComboBox.SelectionChanged -= value2;
                myComboBox.TextChanged -= obj2;
            }
            _ComboName = value;
            myComboBox = _ComboName;
            if (myComboBox != null)
            {
                myComboBox.TextChanged += obj;
                myComboBox.SelectionChanged += value2;
                myComboBox.TextChanged += obj2;
            }
        }
    }

    internal virtual PasswordBox TextPass_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextPass;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            RoutedEventHandler value2 = TextPass_PasswordChanged;
            PasswordBox passwordBox = _TextPass;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged -= value2;
            }
            _TextPass = value;
            passwordBox = _TextPass;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += value2;
            }
        }
    }

    internal virtual MyCheckBox CheckRemember_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckRemember;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                CheckBoxChange((MyCheckBox)a0, a1);
            };
            MyCheckBox myCheckBox = _CheckRemember;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckRemember = value;
            myCheckBox = _CheckRemember;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyTextButton BtnLink_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLink;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyTextButton.ClickEventHandler obj = Btn_Click;
            MyTextButton myTextButton = _BtnLink;
            if (myTextButton != null)
            {
                myTextButton.Click -= obj;
            }
            _BtnLink = value;
            myTextButton = _BtnLink;
            if (myTextButton != null)
            {
                myTextButton.Click += obj;
            }
        }
    }

    public PageLoginAuth()
    {
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            ReloadRegisterButton();
        };
        IsFirstLoad = true;
        InitializeComponent();
        _InitWithEvents();
    }

    public void Reload(bool KeepInput)
    {
        CheckRemember.Checked = Settings.Get<bool>("LoginRemember");
        if (KeepInput && !IsFirstLoad)
        {
            string text = ComboName.Text;
            ComboName.ItemsSource = ((Operators.CompareString(Settings.Get<string>("LoginAuthEmail"), "", TextCompare: false) == 0) ? null : StringExtensions.Split(Settings.Get<string>("LoginAuthEmail"), "\u00a8", false));
            ComboName.Text = text;
        }
        else if (Operators.CompareString(Settings.Get<string>("LoginAuthEmail"), "", TextCompare: false) == 0)
        {
            ComboName.ItemsSource = null;
        }
        else
        {
            ComboName.ItemsSource = StringExtensions.Split(Settings.Get<string>("LoginAuthEmail"), "\u00a8", false);
            ComboName.Text = StringExtensions.BeforeFirst(Settings.Get<string>("LoginAuthEmail"), "\u00a8", false);
            if (Settings.Get<bool>("LoginRemember"))
            {
                TextPass.Password = StringExtensions.BeforeFirst(Settings.Get<string>("LoginAuthPass"), "\u00a8", false).Trim();
            }
        }
        IsFirstLoad = false;
    }

    public static ModLaunch.McLoginServer GetLoginData()
    {
        string baseUrl = (Information.IsNothing(ModMinecraft.McInstanceSelected) ? Settings.Get<string>("CacheAuthServerServer") : Settings.Get<string>("VersionServerAuthServer", ModMinecraft.McInstanceSelected)) + "/authserver";
        if (ModMain.FrmLoginAuth == null)
        {
            return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
            {
                Token = "Auth",
                BaseUrl = baseUrl,
                UserName = "",
                Password = "",
                Description = "Authlib-Injector",
                Type = ModLaunch.McLoginType.Auth
            };
        }
        return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
        {
            Token = "Auth",
            BaseUrl = baseUrl,
            UserName = ModMain.FrmLoginAuth.ComboName.Text.Replace("\u00a8", "").Trim(),
            Password = ModMain.FrmLoginAuth.TextPass.Password.Replace("\u00a8", "").Trim(),
            Description = "Authlib-Injector",
            Type = ModLaunch.McLoginType.Auth
        };
    }

    public static string IsVaild(ModLaunch.McLoginServer LoginData)
    {
        if (Operators.CompareString(LoginData.UserName, "", TextCompare: false) == 0)
        {
            return "账号不能为空！";
        }
        if (Operators.CompareString(LoginData.Password, "", TextCompare: false) == 0)
        {
            return "密码不能为空！";
        }
        return "";
    }

    public string IsVaild()
    {
        return IsVaild(GetLoginData());
    }

    private void ComboName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), "", TextCompare: false))
        {
            TextPass.Password = "";
        }
        if (ModAnimation.AniControlEnabled == 0)
        {
            Settings.Set("CacheAuthAccess", "");
        }
    }

    private void TextPass_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0)
        {
            Settings.Set("CacheAuthAccess", "");
        }
    }

    private void ComboName_SelectionChanged(MyComboBox sender, SelectionChangedEventArgs e)
    {
        if (sender.SelectedIndex == -1 || !Settings.Get<bool>("LoginRemember"))
        {
            TextPass.Password = "";
        }
        else
        {
            TextPass.Password = StringExtensions.Split(Settings.Get<string>("LoginAuthPass").ToString(), "\u00a8", false)[sender.SelectedIndex].Trim();
        }
    }

    private void CheckBoxChange(MyCheckBox sender, object e)
    {
        if (ModAnimation.AniControlEnabled == 0)
        {
            Settings.Set(Conversions.ToString(sender.Tag), sender.Checked);
        }
    }

    private void ComboName_TextChanged()
    {
        BtnLink.Content = ((Operators.CompareString(ComboName.Text, "", TextCompare: false) == 0) ? "注册账号" : "找回密码");
    }

    private void Btn_Click(object sender, EventArgs e)
    {
        if (Operators.ConditionalCompareObjectEqual(BtnLink.Content, "注册账号", TextCompare: false))
        {
            ModBase.OpenWebsite(((object)ModMinecraft.McInstanceSelected != null) ? Settings.Get<string>("VersionServerAuthRegister", ModMinecraft.McInstanceSelected) : Settings.Get<string>("CacheAuthServerRegister"));
        }
        else
        {
            ModBase.OpenWebsite((((object)ModMinecraft.McInstanceSelected != null) ? Settings.Get<string>("VersionServerAuthRegister", ModMinecraft.McInstanceSelected) : Settings.Get<string>("CacheAuthServerRegister")).Replace("/auth/register", "/auth/forgot"));
        }
    }

    private void ReloadRegisterButton()
    {
        string str = (((object)ModMinecraft.McInstanceSelected != null) ? Settings.Get<string>("VersionServerAuthRegister", ModMinecraft.McInstanceSelected) : Settings.Get<string>("CacheAuthServerRegister"));
        BtnLink.Visibility = ((!string.IsNullOrEmpty(new ValidateHttp().Validate(str))) ? Visibility.Collapsed : Visibility.Visible);
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnLink_WithEvents = BtnLink;
        CheckRemember_WithEvents = CheckRemember;
        ComboName_WithEvents = ComboName;
        TextPass_WithEvents = TextPass;
    }
}

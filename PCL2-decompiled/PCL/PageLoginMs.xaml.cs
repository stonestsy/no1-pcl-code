using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginMs : StackPanel, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("PanEmpty")]
    private Grid _PanEmpty;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboAccounts")]
    private MyComboBox _ComboAccounts;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLogin")]
    private MyButton _BtnLogin;

    internal virtual Grid PanEmpty_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanEmpty;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanEmpty = value;
        }
    }

    internal virtual MyComboBox ComboAccounts_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboAccounts;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = ComboAccounts_SelectionChanged;
            MyComboBox myComboBox = _ComboAccounts;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboAccounts = value;
            myComboBox = _ComboAccounts;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual MyButton BtnLogin_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLogin;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnLogin_Click;
            MyButton myButton = _BtnLogin;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnLogin = value;
            myButton = _BtnLogin;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    public PageLoginMs()
    {
        InitializeComponent();
        _InitWithEvents();
    }

    public void Reload(bool KeepInput)
    {
        int selectedIndex = ComboAccounts.SelectedIndex;
        ComboAccounts.Items.Clear();
        ComboAccounts.Items.Add(new MyComboBoxItem
        {
            Content = "添加新账号"
        });
        try
        {
            JObject val = (JObject)StringExtensions.DeserializeJson(Settings.Get<string>("LoginMsJson"));
            foreach (KeyValuePair<string, JToken> item in val)
            {
                MyListItem myListItem = (MyListItem)((DataTemplate)FindResource("ComboBoxItemTemplateWithDelete")).LoadContent();
                myListItem.Tag = item.Value.ToString();
                myListItem.Title = item.Key;
                myListItem.Buttons.ElementAtOrDefault(0).Tag = item.Key;
                ComboAccounts.Items.Add(myListItem);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "微软登录信息出错，登录信息已被重置", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMs.xaml.vb");
            Settings.Set("LoginMsJson", "{}");
            ProjectData.ClearProjectError();
        }
        ComboAccounts.SelectedIndex = (KeepInput ? Math.Max(0, selectedIndex) : 0);
    }

    private void ComboAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0 && ComboAccounts.SelectedItem != null && ComboAccounts.ContentPresenter != null)
        {
            if (ComboAccounts.SelectedItem is MyListItem)
            {
                ComboAccounts.ContentPresenter.Content = ((MyListItem)ComboAccounts.SelectedItem).Title;
            }
            else if (ComboAccounts.SelectedItem is MyComboBoxItem)
            {
                ComboAccounts.ContentPresenter.Content = RuntimeHelpers.GetObjectValue(((MyComboBoxItem)ComboAccounts.SelectedItem).Content);
            }
        }
    }

    public static ModLaunch.McLoginMs GetLoginData()
    {
        if (ModMain.FrmLoginMs == null)
        {
            return new ModLaunch.McLoginMs
            {
                OAuthRefreshToken = Settings.Get<string>("CacheMsV2OAuthRefresh"),
                UserName = Settings.Get<string>("CacheMsV2Name")
            };
        }
        ModLaunch.McLoginMs result = null;
        ModBase.RunInUiWait(() =>
        {
            if (ModMain.FrmLoginMs.ComboAccounts.SelectedIndex == 0)
            {
                result = new ModLaunch.McLoginMs();
            }
            else
            {
                MyListItem myListItem = (MyListItem)ModMain.FrmLoginMs.ComboAccounts.SelectedItem;
                result = new ModLaunch.McLoginMs
                {
                    OAuthRefreshToken = Conversions.ToString(myListItem.Tag),
                    UserName = myListItem.Title
                };
            }
        });
        return result;
    }

    public static string IsVaild(ModLaunch.McLoginMs LoginData)
    {
        if (Operators.CompareString(LoginData.OAuthRefreshToken, "", TextCompare: false) == 0)
        {
            return "请在登录账号后再启动游戏！";
        }
        return "";
    }

    public string IsVaild()
    {
        return IsVaild(GetLoginData());
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        ComboAccounts.IsEnabled = false;
        BtnLogin.IsEnabled = false;
        BtnLogin.Text = "0%";
        ModBase.RunInNewThread(() =>
        {
            try
            {
                ModLaunch.McLoginMsLoader.Start(GetLoginData(), IsForceRestart: true);
                while (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Loading)
                {
                    ModBase.RunInUi(() =>
                    {
                        BtnLogin.Text = Conversions.ToString(Math.Round(ModLaunch.McLoginMsLoader.Progress * 100.0)) + "%";
                    });
                    Thread.Sleep(50);
                }
                if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Finished)
                {
                    ModBase.RunInUi(() =>
                    {
                        ModMain.FrmLaunchLeft.RefreshPage(KeepInput: false, Anim: true);
                    });
                    return;
                }
                if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Canceled)
                {
                    throw new OperationCanceledException();
                }
                if (ModLaunch.McLoginMsLoader.Error == null)
                {
                    throw new Exception("未知错误！");
                }
                throw new Exception(ModLaunch.McLoginMsLoader.Error.Message, ModLaunch.McLoginMsLoader.Error);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                if (!ExceptionExtensions.IsCanceled(ex2))
                {
                    if (StringExtensions.StartsWithF(ex2.Message, "$", false))
                    {
                        ModMain.Hint(ex2.Message.TrimStart('$'), ModMain.HintType.Red);
                    }
                    else if (ex2 is AuthenticationException && ex2.Message.Contains("SSL/TLS"))
                    {
                        Logger.Error(ex2, string.Format("正版登录验证失败，请考虑在 [设置 → 其他] 中关闭 [在正版登录时验证 SSL 证书]，然后再试。{0}{1}原始错误信息：", "\r\n", "\r\n"), (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMs.xaml.vb");
                    }
                    else
                    {
                        Logger.Error(ex2, "正版登录尝试失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\PageLoginMs.xaml.vb");
                    }
                }
                ProjectData.ClearProjectError();
            }
            finally
            {
                ModBase.RunInUi(() =>
                {
                    ComboAccounts.IsEnabled = true;
                    BtnLogin.IsEnabled = true;
                    BtnLogin.Text = "登录";
                });
            }
        }, "Ms Login");
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnLogin_WithEvents = BtnLogin;
        ComboAccounts_WithEvents = ComboAccounts;
        PanEmpty_WithEvents = PanEmpty;
    }
}

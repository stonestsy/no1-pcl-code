using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupSystem : MyPageRight, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboDownloadSource")]
    private MyComboBox _ComboDownloadSource;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboDownloadVersion")]
    private MyComboBox _ComboDownloadVersion;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderDownloadThread")]
    private MySlider _SliderDownloadThread;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderDownloadSpeed")]
    private MySlider _SliderDownloadSpeed;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckDownloadCert")]
    private MyCheckBox _CheckDownloadCert;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboDownloadMod")]
    private MyComboBox _ComboDownloadMod;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboDownloadTranslateV2")]
    private MyComboBox _ComboDownloadTranslateV2;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboModLocalNameStyle")]
    private MyComboBox _ComboModLocalNameStyle;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckUpdateRelease")]
    private MyCheckBox _CheckUpdateRelease;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckUpdateSnapshot")]
    private MyCheckBox _CheckUpdateSnapshot;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHelpChinese")]
    private MyCheckBox _CheckHelpChinese;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboSystemUpdate")]
    private MyComboBox _ComboSystemUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemSystemUpdateDownload")]
    private MyComboBoxItem _ItemSystemUpdateDownload;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboSystemActivity")]
    private MyComboBox _ComboSystemActivity;

    [CompilerGenerated]
    [AccessedThroughProperty("TextSystemCache")]
    private MyTextBox _TextSystemCache;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckSystemTelemetry")]
    private MyCheckBox _CheckSystemTelemetry;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSystemUpdate")]
    private MyButton _BtnSystemUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSystemSettingExp")]
    private MyButton _BtnSystemSettingExp;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSystemSettingImp")]
    private MyButton _BtnSystemSettingImp;

    [CompilerGenerated]
    [AccessedThroughProperty("PanDonate")]
    private Grid _PanDonate;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSystemIdentify")]
    private MyButton _BtnSystemIdentify;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSystemUnlock")]
    private MyButton _BtnSystemUnlock;

    [CompilerGenerated]
    [AccessedThroughProperty("CardDebug")]
    private MyCard _CardDebug;

    [CompilerGenerated]
    [AccessedThroughProperty("PanDebugAnim")]
    private Grid _PanDebugAnim;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderDebugAnim")]
    private MySlider _SliderDebugAnim;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckDebugSkipCopy")]
    private MyCheckBox _CheckDebugSkipCopy;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckDebugMode")]
    private MyCheckBox _CheckDebugMode;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckDebugDelay")]
    private MyCheckBox _CheckDebugDelay;

    private bool _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded;

    private StaticLocalInitFlag _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init;

    internal virtual MyScrollViewer PanBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBack = value;
        }
    }

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

    internal virtual MyComboBox ComboDownloadSource_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboDownloadSource;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboDownloadSource = value;
        }
    }

    internal virtual MyComboBox ComboDownloadVersion_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboDownloadVersion;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboDownloadVersion = value;
        }
    }

    internal virtual MySlider SliderDownloadThread_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderDownloadThread;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.PreviewChangeEventHandler obj = SliderDownloadThread_PreviewChange;
            MySlider mySlider = _SliderDownloadThread;
            if (mySlider != null)
            {
                mySlider.PreviewChange -= obj;
            }
            _SliderDownloadThread = value;
            mySlider = _SliderDownloadThread;
            if (mySlider != null)
            {
                mySlider.PreviewChange += obj;
            }
        }
    }

    internal virtual MySlider SliderDownloadSpeed_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderDownloadSpeed;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderDownloadSpeed = value;
        }
    }

    internal virtual MyCheckBox CheckDownloadCert_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckDownloadCert;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckDownloadCert = value;
        }
    }

    internal virtual MyComboBox ComboDownloadMod_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboDownloadMod;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboDownloadMod = value;
        }
    }

    internal virtual MyComboBox ComboDownloadTranslateV2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboDownloadTranslateV2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboDownloadTranslateV2 = value;
        }
    }

    internal virtual MyComboBox ComboModLocalNameStyle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboModLocalNameStyle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboModLocalNameStyle = value;
        }
    }

    internal virtual MyCheckBox CheckUpdateRelease_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckUpdateRelease;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckUpdateRelease = value;
        }
    }

    internal virtual MyCheckBox CheckUpdateSnapshot_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckUpdateSnapshot;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckUpdateSnapshot = value;
        }
    }

    internal virtual MyCheckBox CheckHelpChinese_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHelpChinese;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckHelpChinese = value;
        }
    }

    internal virtual MyComboBox ComboSystemUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboSystemUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = ComboSystemUpdate_SelectionChanged;
            MyComboBox myComboBox = _ComboSystemUpdate;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboSystemUpdate = value;
            myComboBox = _ComboSystemUpdate;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual MyComboBoxItem ItemSystemUpdateDownload_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemSystemUpdateDownload;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ItemSystemUpdateDownload = value;
        }
    }

    internal virtual MyComboBox ComboSystemActivity_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboSystemActivity;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = ComboSystemActivity_SelectionChanged;
            MyComboBox myComboBox = _ComboSystemActivity;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboSystemActivity = value;
            myComboBox = _ComboSystemActivity;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual MyTextBox TextSystemCache_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextSystemCache;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextSystemCache = value;
        }
    }

    internal virtual MyCheckBox CheckSystemTelemetry_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckSystemTelemetry;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckSystemTelemetry = value;
        }
    }

    internal virtual MyButton BtnSystemUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSystemUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSystemUpdate_Click;
            MyButton myButton = _BtnSystemUpdate;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSystemUpdate = value;
            myButton = _BtnSystemUpdate;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnSystemSettingExp_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSystemSettingExp;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSystemSettingExp_Click;
            MyButton myButton = _BtnSystemSettingExp;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSystemSettingExp = value;
            myButton = _BtnSystemSettingExp;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnSystemSettingImp_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSystemSettingImp;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSystemSettingImp_Click;
            MyButton myButton = _BtnSystemSettingImp;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSystemSettingImp = value;
            myButton = _BtnSystemSettingImp;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual Grid PanDonate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanDonate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanDonate = value;
        }
    }

    internal virtual MyButton BtnSystemIdentify_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSystemIdentify;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSystemIdentify_Click;
            MyButton myButton = _BtnSystemIdentify;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSystemIdentify = value;
            myButton = _BtnSystemIdentify;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnSystemUnlock_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSystemUnlock;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSystemUnlock_Click;
            MyButton myButton = _BtnSystemUnlock;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSystemUnlock = value;
            myButton = _BtnSystemUnlock;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard CardDebug_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardDebug;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardDebug = value;
        }
    }

    internal virtual Grid PanDebugAnim_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanDebugAnim;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanDebugAnim = value;
        }
    }

    internal virtual MySlider SliderDebugAnim_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderDebugAnim;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderDebugAnim = value;
        }
    }

    internal virtual MyCheckBox CheckDebugSkipCopy_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckDebugSkipCopy;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckDebugSkipCopy = value;
        }
    }

    internal virtual MyCheckBox CheckDebugMode_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckDebugMode;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                CheckDebugMode_Change();
            };
            MyCheckBox myCheckBox = _CheckDebugMode;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckDebugMode = value;
            myCheckBox = _CheckDebugMode;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckDebugDelay_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckDebugDelay;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckDebugDelay = value;
        }
    }

    public PageSetupSystem()
    {
        Loaded += PageSetupSystem_Loaded;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToHome();
        PanDonate.Visibility = Visibility.Collapsed;
        if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init == null)
        {
            Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init, new StaticLocalInitFlag(), null);
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init, ref lockTaken);
            if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init.State == 0)
            {
                _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init.State = 2;
                _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded = false;
            }
            else if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded_0024Init);
            }
        }
        checked
        {
            if (!_0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded)
            {
                _0024STATIC_0024PageSetupSystem_Loaded_002420211C128135_0024IsLoaded = true;
                ModAnimation.AniControlEnabled++;
                Reload();
                SliderLoad();
                ModAnimation.AniControlEnabled--;
            }
        }
    }

    public void Reload()
    {
        SettingService.RefreshSettings(this);
    }

    public void Reset()
    {
        try
        {
            SettingService.ResetSettings(this);
            Logger.Info("已初始化启动器页设置", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
            ModMain.Hint("已初始化启动器页设置！", ModMain.HintType.Green, Log: false);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "初始化启动器页设置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
            ProjectData.ClearProjectError();
        }
        Reload();
    }

    private void SliderLoad()
    {
        SliderDownloadThread.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.AddObject(v, 1));
        SliderDownloadSpeed.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) =>
        {
            if (Operators.ConditionalCompareObjectLessEqual(v, 14, TextCompare: false))
            {
                return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.AddObject(v, 1), 0.1), " M/s");
            }
            if (Operators.ConditionalCompareObjectLessEqual(v, 31, TextCompare: false))
            {
                return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.SubtractObject(v, 11), 0.5), " M/s");
            }
            return Operators.ConditionalCompareObjectLessEqual(v, 41, TextCompare: false) ? Operators.ConcatenateObject(Operators.SubtractObject(v, 21), " M/s") : "无限制";
        });
        SliderDebugAnim.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => (!Operators.ConditionalCompareObjectGreater(v, 29, TextCompare: false)) ? Operators.ConcatenateObject(Operators.AddObject(Operators.DivideObject(v, 10), 0.1), "x") : "关闭");
    }

    private void SliderDownloadThread_PreviewChange(object sender, ModBase.RouteEventArgs e)
    {
        if (SliderDownloadThread.Value >= 100 && !Settings.Get<bool>("HintDownloadThread"))
        {
            Settings.Set("HintDownloadThread", true);
            ModMain.MyMsgBox("如果设置过多的下载线程，可能会导致下载时出现非常严重的卡顿。\r\n一般设置 64 线程即可满足大多数下载需求，除非你知道你在干什么，否则不建议设置更多的线程数！", "警告", "我知道了", "", "", IsWarn: true);
        }
    }

    private void BtnSystemIdentify_Click(object sender, MouseButtonEventArgs e)
    {
        PageOtherAbout.CopyIdentify();
    }

    private void BtnSystemUnlock_Click(object sender, MouseButtonEventArgs e)
    {
        ModSecret.InputPotatoCode(IsUpdating: false);
    }

    private void CheckDebugMode_Change()
    {
        if (ModAnimation.AniControlEnabled == 0)
        {
            ModMain.Hint("部分调试信息将在刷新或启动器重启后切换显示！", ModMain.HintType.Blue, Log: false);
        }
    }

    private void ComboSystemActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0 && ComboSystemActivity.SelectedIndex == 2 && ModMain.MyMsgBox("若选择此项，即使在将来出现严重问题时，你也无法获取相关通知。\r\n例如，如果发现某个版本游戏存在严重 Bug，你可能就会因为无法得到通知而导致无法预知的后果。\r\n\r\n一般选择 仅在有重要通知时显示公告 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2 && e.RemovedItems.Count > 0)
        {
            ComboSystemActivity.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
        }
    }

    private void ComboSystemUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0 && ComboSystemUpdate.SelectedIndex == 3 && ModMain.MyMsgBox("若选择此项，即使在启动器将来出现严重问题时，你也无法获取更新并获得修复。\r\n例如，如果官方修改了登录方式，从而导致现有启动器无法登录，你可能就会因为无法更新而无法开始游戏。\r\n\r\n一般选择 仅在有重大漏洞更新时显示提示 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2 && e.RemovedItems.Count > 0)
        {
            ComboSystemUpdate.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
        }
    }

    private void BtnSystemUpdate_Click(object sender, EventArgs e)
    {
        ModSecret.UpdateCheckByButton();
    }

    public static bool? IsLauncherNewest()
    {
        bool? result;
        try
        {
            string text = FileUtils.TryReadAsString(ModBase.PathTemp + "Cache\\Notice.cfg", (Encoding)null, (Type)null) ?? "";
            if (StringExtensions.Split(text, "|", false).Count() >= 3)
            {
                return Conversions.ToDouble(StringExtensions.Split(text, "|", false)[2]) <= 408.0;
            }
            result = null;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "确认启动器更新失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
            result = null;
            ProjectData.ClearProjectError();
        }
        return result;
    }

    private void BtnSystemSettingExp_Click(object sender, MouseButtonEventArgs e)
    {
        ModMain.Hint("该功能尚在开发中！");
    }

    private void BtnSystemSettingImp_Click(object sender, MouseButtonEventArgs e)
    {
        ModMain.Hint("该功能尚在开发中！");
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnSystemIdentify_WithEvents = BtnSystemIdentify;
        BtnSystemSettingExp_WithEvents = BtnSystemSettingExp;
        BtnSystemSettingImp_WithEvents = BtnSystemSettingImp;
        BtnSystemUnlock_WithEvents = BtnSystemUnlock;
        BtnSystemUpdate_WithEvents = BtnSystemUpdate;
        CardDebug_WithEvents = CardDebug;
        CheckDebugDelay_WithEvents = CheckDebugDelay;
        CheckDebugMode_WithEvents = CheckDebugMode;
        CheckDebugSkipCopy_WithEvents = CheckDebugSkipCopy;
        CheckDownloadCert_WithEvents = CheckDownloadCert;
        CheckHelpChinese_WithEvents = CheckHelpChinese;
        CheckSystemTelemetry_WithEvents = CheckSystemTelemetry;
        CheckUpdateRelease_WithEvents = CheckUpdateRelease;
        CheckUpdateSnapshot_WithEvents = CheckUpdateSnapshot;
        ComboDownloadMod_WithEvents = ComboDownloadMod;
        ComboDownloadSource_WithEvents = ComboDownloadSource;
        ComboDownloadTranslateV2_WithEvents = ComboDownloadTranslateV2;
        ComboDownloadVersion_WithEvents = ComboDownloadVersion;
        ComboModLocalNameStyle_WithEvents = ComboModLocalNameStyle;
        ComboSystemActivity_WithEvents = ComboSystemActivity;
        ComboSystemUpdate_WithEvents = ComboSystemUpdate;
        ItemSystemUpdateDownload_WithEvents = ItemSystemUpdateDownload;
        PanBack_WithEvents = PanBack;
        PanDebugAnim_WithEvents = PanDebugAnim;
        PanDonate_WithEvents = PanDonate;
        PanMain_WithEvents = PanMain;
        SliderDebugAnim_WithEvents = SliderDebugAnim;
        SliderDownloadSpeed_WithEvents = SliderDownloadSpeed;
        SliderDownloadThread_WithEvents = SliderDownloadThread;
        TextSystemCache_WithEvents = TextSystemCache;
    }
}

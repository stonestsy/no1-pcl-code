using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupLink : MyPageRight, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("CardArgument")]
    private MyCard _CardArgument;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboLatencyMode")]
    private MyComboBox _ComboLatencyMode;

    [CompilerGenerated]
    [AccessedThroughProperty("TextCustomPeer")]
    private MyTextBox _TextCustomPeer;

    private bool _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded;

    private StaticLocalInitFlag _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init;

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

    internal virtual MyCard CardArgument_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardArgument;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardArgument = value;
        }
    }

    internal virtual MyComboBox ComboLatencyMode_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboLatencyMode;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboLatencyMode = value;
        }
    }

    internal virtual MyTextBox TextCustomPeer_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextCustomPeer;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextCustomPeer = value;
        }
    }

    public PageSetupLink()
    {
        Loaded += PageSetupLink_Loaded;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageSetupLink_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToHome();
        if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init == null)
        {
            Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init, new StaticLocalInitFlag(), null);
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init, ref lockTaken);
            if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init.State == 0)
            {
                _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init.State = 2;
                _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded = false;
            }
            else if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded_0024Init);
            }
        }
        checked
        {
            if (!_0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded)
            {
                _0024STATIC_0024PageSetupLink_Loaded_002420211C128135_0024IsLoaded = true;
                ModAnimation.AniControlEnabled++;
                Reload();
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
            Logger.Info("已初始化联机页设置", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLink.xaml.vb");
            ModMain.Hint("已初始化联机页设置！", ModMain.HintType.Green, Log: false);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "初始化联机页设置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLink.xaml.vb");
            ProjectData.ClearProjectError();
        }
        Reload();
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        CardArgument_WithEvents = CardArgument;
        ComboLatencyMode_WithEvents = ComboLatencyMode;
        PanBack_WithEvents = PanBack;
        PanMain_WithEvents = PanMain;
        TextCustomPeer_WithEvents = TextCustomPeer;
    }
}

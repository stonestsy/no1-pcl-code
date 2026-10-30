using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceModDisabled : MyPageRight, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private MyCard _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnDownload")]
    private MyButton _BtnDownload;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnVersion")]
    private MyButton _BtnVersion;

    internal virtual MyCard PanMain_WithEvents
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

    internal virtual MyButton BtnDownload_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnDownload;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnDownload_Click;
            RoutedEventHandler value2 = (object a0, RoutedEventArgs a1) =>
            {
                BtnDownload_Loaded();
            };
            MyButton myButton = _BtnDownload;
            if (myButton != null)
            {
                myButton.Click -= obj;
                myButton.Loaded -= value2;
            }
            _BtnDownload = value;
            myButton = _BtnDownload;
            if (myButton != null)
            {
                myButton.Click += obj;
                myButton.Loaded += value2;
            }
        }
    }

    internal virtual MyButton BtnVersion_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnVersion;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnVersion_Click;
            MyButton myButton = _BtnVersion;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnVersion = value;
            myButton = _BtnVersion;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    public PageInstanceModDisabled()
    {
        InitializeComponent();
        _InitWithEvents();
    }

    private void BtnDownload_Click(object sender, EventArgs e)
    {
        ModMain.FrmMain.PageChange(FormMain.PageType.Download);
    }

    private void BtnVersion_Click(object sender, EventArgs e)
    {
        ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
        ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
    }

    public void BtnDownload_Loaded()
    {
        Visibility visibility = (((Settings.Get<bool>("UiHiddenPageDownload") && !PageSetupUI.HiddenForceShow) || (ModMain.FrmSelectRight != null && ModMain.FrmSelectRight.ShowHidden)) ? Visibility.Collapsed : Visibility.Visible);
        if (BtnDownload.Visibility != visibility)
        {
            BtnDownload.Visibility = visibility;
            PanMain.TriggerForceResize();
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnDownload_WithEvents = BtnDownload;
        BtnVersion_WithEvents = BtnVersion;
        PanMain_WithEvents = PanMain;
    }
}

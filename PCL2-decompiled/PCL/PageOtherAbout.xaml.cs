using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageOtherAbout : MyPageRight, IComponentConnector
{
    private new bool IsLoaded;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemAboutPcl")]
    private MyListItem _ItemAboutPcl;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAboutUpdate")]
    private MyButton _BtnAboutUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnDonateOutput")]
    private MyButton _BtnDonateOutput;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnDonateDonate")]
    private MyButton _BtnDonateDonate;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnDonateCopy")]
    private MyButton _BtnDonateCopy;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnDonateInput")]
    private MyButton _BtnDonateInput;

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

    internal virtual MyListItem ItemAboutPcl_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemAboutPcl;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ItemAboutPcl = value;
        }
    }

    internal virtual MyButton BtnAboutUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAboutUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnAboutUpdate_Click;
            MyButton myButton = _BtnAboutUpdate;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnAboutUpdate = value;
            myButton = _BtnAboutUpdate;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnDonateOutput_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnDonateOutput;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnDonateOutput_Click;
            MyButton myButton = _BtnDonateOutput;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnDonateOutput = value;
            myButton = _BtnDonateOutput;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnDonateDonate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnDonateDonate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnDonateDonate = value;
        }
    }

    internal virtual MyButton BtnDonateCopy_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnDonateCopy;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                CopyIdentify();
            };
            MyButton myButton = _BtnDonateCopy;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnDonateCopy = value;
            myButton = _BtnDonateCopy;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnDonateInput_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnDonateInput;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                BtnDonateCodeInput_Click();
            };
            MyButton myButton = _BtnDonateInput;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnDonateInput = value;
            myButton = _BtnDonateInput;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    public PageOtherAbout()
    {
        Loaded += PageOtherAbout_Loaded;
        IsLoaded = false;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageOtherAbout_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToHome();
        if (!IsLoaded)
        {
            IsLoaded = true;
            ItemAboutPcl.Info = ItemAboutPcl.Info.Replace("%VERSION%", "正式版 2.13.1.1").Replace("%VERSIONCODE%", Conversions.ToString(408)).Replace("%BRANCH%", Conversions.ToString(50));
        }
    }

    public static void CopyIdentify()
    {
        ModBase.ClipboardSet(ModBase.Identify);
    }

    private void BtnDonateCodeInput_Click()
    {
        ModSecret.InputPotatoCode(IsUpdating: false);
    }

    private void BtnDonateOutput_Click(object sender, EventArgs e)
    {
        ModSecret.GeneratePotatoCode();
    }

    private void BtnAboutUpdate_Click(object sender, MouseButtonEventArgs e)
    {
        ModSecret.UpdateCheckByButton();
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnAboutUpdate_WithEvents = BtnAboutUpdate;
        BtnDonateCopy_WithEvents = BtnDonateCopy;
        BtnDonateDonate_WithEvents = BtnDonateDonate;
        BtnDonateInput_WithEvents = BtnDonateInput;
        BtnDonateOutput_WithEvents = BtnDonateOutput;
        ItemAboutPcl_WithEvents = ItemAboutPcl;
        PanBack_WithEvents = PanBack;
        PanMain_WithEvents = PanMain;
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupUI : MyPageRight, IComponentConnector
{
    private static bool _HiddenForceShow = false;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("CardLauncher")]
    private MyCard _CardLauncher;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderLauncherTransparent")]
    private MySlider _SliderLauncherTransparent;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherHue")]
    private TextBlock _LabLauncherHue;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderLauncherHue")]
    private MySlider _SliderLauncherHue;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherDelta")]
    private TextBlock _LabLauncherDelta;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderLauncherDelta")]
    private MySlider _SliderLauncherDelta;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherSat")]
    private TextBlock _LabLauncherSat;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderLauncherSat")]
    private MySlider _SliderLauncherSat;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherLight")]
    private TextBlock _LabLauncherLight;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderLauncherLight")]
    private MySlider _SliderLauncherLight;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLauncherTheme")]
    private Grid _PanLauncherTheme;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme0")]
    private MyRadioBox _RadioLauncherTheme0;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme1")]
    private MyRadioBox _RadioLauncherTheme1;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme2")]
    private MyRadioBox _RadioLauncherTheme2;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme3")]
    private MyRadioBox _RadioLauncherTheme3;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme4")]
    private MyRadioBox _RadioLauncherTheme4;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme5")]
    private MyRadioBox _RadioLauncherTheme5;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme5Gray")]
    private MyRadioBox _RadioLauncherTheme5Gray;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherTheme5Unlock")]
    private TextBlock _LabLauncherTheme5Unlock;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme12")]
    private MyRadioBox _RadioLauncherTheme12;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme6")]
    private MyRadioBox _RadioLauncherTheme6;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme7")]
    private MyRadioBox _RadioLauncherTheme7;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme13")]
    private MyRadioBox _RadioLauncherTheme13;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme8")]
    private MyRadioBox _RadioLauncherTheme8;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherTheme8Copy")]
    private TextBlock _LabLauncherTheme8Copy;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme9")]
    private MyRadioBox _RadioLauncherTheme9;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherTheme9Copy")]
    private TextBlock _LabLauncherTheme9Copy;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme10")]
    private MyRadioBox _RadioLauncherTheme10;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme11")]
    private MyRadioBox _RadioLauncherTheme11;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLauncherTheme11Click")]
    private TextBlock _LabLauncherTheme11Click;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLauncherTheme14")]
    private MyRadioBox _RadioLauncherTheme14;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLauncherHide")]
    private Border _PanLauncherHide;

    [CompilerGenerated]
    [AccessedThroughProperty("CardBackground")]
    private MyCard _CardBackground;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBackgroundSuit")]
    private Grid _PanBackgroundSuit;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBackgroundOpacity")]
    private Grid _PanBackgroundOpacity;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderBackgroundOpacity")]
    private MySlider _SliderBackgroundOpacity;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBackgroundBlur")]
    private Grid _PanBackgroundBlur;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderBackgroundBlur")]
    private MySlider _SliderBackgroundBlur;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnBackgroundOpen")]
    private MyButton _BtnBackgroundOpen;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnBackgroundRefresh")]
    private MyButton _BtnBackgroundRefresh;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnBackgroundClear")]
    private MyButton _BtnBackgroundClear;

    [CompilerGenerated]
    [AccessedThroughProperty("CardMusic")]
    private MyCard _CardMusic;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMusicVolume")]
    private Grid _PanMusicVolume;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderMusicVolume")]
    private MySlider _SliderMusicVolume;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMusicDetail")]
    private StackPanel _PanMusicDetail;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckMusicRandom")]
    private MyCheckBox _CheckMusicRandom;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckMusicAuto")]
    private MyCheckBox _CheckMusicAuto;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckMusicStart")]
    private MyCheckBox _CheckMusicStart;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckMusicStop")]
    private MyCheckBox _CheckMusicStop;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnMusicOpen")]
    private MyButton _BtnMusicOpen;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnMusicRefresh")]
    private MyButton _BtnMusicRefresh;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnMusicClear")]
    private MyButton _BtnMusicClear;

    [CompilerGenerated]
    [AccessedThroughProperty("CardLogo")]
    private MyCard _CardLogo;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLogoType0")]
    private MyRadioBox _RadioLogoType0;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLogoType1")]
    private MyRadioBox _RadioLogoType1;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLogoType2")]
    private MyRadioBox _RadioLogoType2;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioLogoType3")]
    private MyRadioBox _RadioLogoType3;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckLogoLeft")]
    private MyCheckBox _CheckLogoLeft;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLogoText")]
    private Grid _PanLogoText;

    [CompilerGenerated]
    [AccessedThroughProperty("TextLogoText")]
    private MyTextBox _TextLogoText;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLogoChange")]
    private Grid _PanLogoChange;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLogoChange")]
    private MyButton _BtnLogoChange;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLogoDelete")]
    private MyButton _BtnLogoDelete;

    [CompilerGenerated]
    [AccessedThroughProperty("CardCustom")]
    private MyCard _CardCustom;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioCustomType0")]
    private MyRadioBox _RadioCustomType0;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioCustomType3")]
    private MyRadioBox _RadioCustomType3;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioCustomType1")]
    private MyRadioBox _RadioCustomType1;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioCustomType2")]
    private MyRadioBox _RadioCustomType2;

    [CompilerGenerated]
    [AccessedThroughProperty("HintCustom")]
    private MyHint _HintCustom;

    [CompilerGenerated]
    [AccessedThroughProperty("HintCustomWarn")]
    private MyHint _HintCustomWarn;

    [CompilerGenerated]
    [AccessedThroughProperty("PanCustomLocal")]
    private Grid _PanCustomLocal;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnCustomRefresh")]
    private MyButton _BtnCustomRefresh;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnCustomFile")]
    private MyButton _BtnCustomFile;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnCustomTutorial")]
    private MyButton _BtnCustomTutorial;

    [CompilerGenerated]
    [AccessedThroughProperty("PanCustomNet")]
    private Grid _PanCustomNet;

    [CompilerGenerated]
    [AccessedThroughProperty("TextCustomNet")]
    private MyTextBox _TextCustomNet;

    [CompilerGenerated]
    [AccessedThroughProperty("PanCustomPreset")]
    private Grid _PanCustomPreset;

    [CompilerGenerated]
    [AccessedThroughProperty("CardSwitch")]
    private MyCard _CardSwitch;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenPageDownload")]
    private MyCheckBox _CheckHiddenPageDownload;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenPageLink")]
    private MyCheckBox _CheckHiddenPageLink;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenPageSetup")]
    private MyCheckBox _CheckHiddenPageSetup;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenPageOther")]
    private MyCheckBox _CheckHiddenPageOther;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenSetupLaunch")]
    private MyCheckBox _CheckHiddenSetupLaunch;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenSetupLink")]
    private MyCheckBox _CheckHiddenSetupLink;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenSetupUI")]
    private MyCheckBox _CheckHiddenSetupUI;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenSetupSystem")]
    private MyCheckBox _CheckHiddenSetupSystem;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenOtherHelp")]
    private MyCheckBox _CheckHiddenOtherHelp;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenOtherAbout")]
    private MyCheckBox _CheckHiddenOtherAbout;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenOtherTest")]
    private MyCheckBox _CheckHiddenOtherTest;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenOtherFeedback")]
    private MyCheckBox _CheckHiddenOtherFeedback;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenOtherVote")]
    private MyCheckBox _CheckHiddenOtherVote;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckLauncherEmail")]
    private MyCheckBox _CheckLauncherEmail;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenFunctionSelect")]
    private MyCheckBox _CheckHiddenFunctionSelect;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenFunctionModUpdate")]
    private MyCheckBox _CheckHiddenFunctionModUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckHiddenFunctionHidden")]
    private MyCheckBox _CheckHiddenFunctionHidden;

    private bool _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded;

    private StaticLocalInitFlag _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init;

    public static bool HiddenForceShow
    {
        get
        {
            return _HiddenForceShow;
        }
        set
        {
            _HiddenForceShow = value;
            HiddenRefresh();
        }
    }

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

    internal virtual MyCard CardLauncher_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardLauncher;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardLauncher = value;
        }
    }

    internal virtual MySlider SliderLauncherTransparent_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderLauncherTransparent;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderLauncherTransparent = value;
        }
    }

    internal virtual TextBlock LabLauncherHue_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherHue;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabLauncherHue = value;
        }
    }

    internal virtual MySlider SliderLauncherHue_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderLauncherHue;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HSL_Change();
            };
            MySlider mySlider = _SliderLauncherHue;
            if (mySlider != null)
            {
                mySlider.Change -= obj;
            }
            _SliderLauncherHue = value;
            mySlider = _SliderLauncherHue;
            if (mySlider != null)
            {
                mySlider.Change += obj;
            }
        }
    }

    internal virtual TextBlock LabLauncherDelta_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherDelta;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabLauncherDelta = value;
        }
    }

    internal virtual MySlider SliderLauncherDelta_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderLauncherDelta;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HSL_Change();
            };
            MySlider mySlider = _SliderLauncherDelta;
            if (mySlider != null)
            {
                mySlider.Change -= obj;
            }
            _SliderLauncherDelta = value;
            mySlider = _SliderLauncherDelta;
            if (mySlider != null)
            {
                mySlider.Change += obj;
            }
        }
    }

    internal virtual TextBlock LabLauncherSat_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherSat;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabLauncherSat = value;
        }
    }

    internal virtual MySlider SliderLauncherSat_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderLauncherSat;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HSL_Change();
            };
            MySlider mySlider = _SliderLauncherSat;
            if (mySlider != null)
            {
                mySlider.Change -= obj;
            }
            _SliderLauncherSat = value;
            mySlider = _SliderLauncherSat;
            if (mySlider != null)
            {
                mySlider.Change += obj;
            }
        }
    }

    internal virtual TextBlock LabLauncherLight_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherLight;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabLauncherLight = value;
        }
    }

    internal virtual MySlider SliderLauncherLight_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderLauncherLight;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HSL_Change();
            };
            MySlider mySlider = _SliderLauncherLight;
            if (mySlider != null)
            {
                mySlider.Change -= obj;
            }
            _SliderLauncherLight = value;
            mySlider = _SliderLauncherLight;
            if (mySlider != null)
            {
                mySlider.Change += obj;
            }
        }
    }

    internal virtual Grid PanLauncherTheme_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLauncherTheme;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLauncherTheme = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme0_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme0 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme1 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme2 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme3_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme3;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme3 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme4_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme4;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme4 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme5_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme5;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme5 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme5Gray_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme5Gray;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme5Gray = value;
        }
    }

    internal virtual TextBlock LabLauncherTheme5Unlock_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherTheme5Unlock;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = LabLauncherTheme5Unlock_MouseLeftButtonUp;
            TextBlock textBlock = _LabLauncherTheme5Unlock;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonUp -= value2;
            }
            _LabLauncherTheme5Unlock = value;
            textBlock = _LabLauncherTheme5Unlock;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme12_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme12;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme12 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme6_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme6;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme6 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme7_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme7;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme7 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme13_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme13;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme13 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme8_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme8;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme8Copy_MouseRightButtonUp();
            };
            MyRadioBox myRadioBox = _RadioLauncherTheme8;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp -= value2;
            }
            _RadioLauncherTheme8 = value;
            myRadioBox = _RadioLauncherTheme8;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp += value2;
            }
        }
    }

    internal virtual TextBlock LabLauncherTheme8Copy_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherTheme8Copy;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme8Copy_MouseRightButtonUp();
            };
            TextBlock textBlock = _LabLauncherTheme8Copy;
            if (textBlock != null)
            {
                textBlock.MouseRightButtonUp -= value2;
            }
            _LabLauncherTheme8Copy = value;
            textBlock = _LabLauncherTheme8Copy;
            if (textBlock != null)
            {
                textBlock.MouseRightButtonUp += value2;
            }
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme9_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme9;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme9Copy_MouseRightButtonUp();
            };
            MyRadioBox myRadioBox = _RadioLauncherTheme9;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp -= value2;
            }
            _RadioLauncherTheme9 = value;
            myRadioBox = _RadioLauncherTheme9;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp += value2;
            }
        }
    }

    internal virtual TextBlock LabLauncherTheme9Copy_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherTheme9Copy;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme9Copy_MouseRightButtonUp();
            };
            TextBlock textBlock = _LabLauncherTheme9Copy;
            if (textBlock != null)
            {
                textBlock.MouseRightButtonUp -= value2;
            }
            _LabLauncherTheme9Copy = value;
            textBlock = _LabLauncherTheme9Copy;
            if (textBlock != null)
            {
                textBlock.MouseRightButtonUp += value2;
            }
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme10_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme10;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLauncherTheme10 = value;
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme11_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme11;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme11Click_MouseLeftButtonUp();
            };
            MyRadioBox myRadioBox = _RadioLauncherTheme11;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp -= value2;
            }
            _RadioLauncherTheme11 = value;
            myRadioBox = _RadioLauncherTheme11;
            if (myRadioBox != null)
            {
                myRadioBox.MouseRightButtonUp += value2;
            }
        }
    }

    internal virtual TextBlock LabLauncherTheme11Click_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLauncherTheme11Click;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                LabLauncherTheme11Click_MouseLeftButtonUp();
            };
            TextBlock textBlock = _LabLauncherTheme11Click;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonUp -= value2;
            }
            _LabLauncherTheme11Click = value;
            textBlock = _LabLauncherTheme11Click;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual MyRadioBox RadioLauncherTheme14_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLauncherTheme14;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.ChangedEventHandler obj = RadioLauncherTheme14_Change;
            MyRadioBox myRadioBox = _RadioLauncherTheme14;
            if (myRadioBox != null)
            {
                myRadioBox.Changed -= obj;
            }
            _RadioLauncherTheme14 = value;
            myRadioBox = _RadioLauncherTheme14;
            if (myRadioBox != null)
            {
                myRadioBox.Changed += obj;
            }
        }
    }

    internal virtual Border PanLauncherHide_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLauncherHide;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLauncherHide = value;
        }
    }

    internal virtual MyCard CardBackground_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardBackground;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardBackground = value;
        }
    }

    internal virtual Grid PanBackgroundSuit_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBackgroundSuit;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBackgroundSuit = value;
        }
    }

    internal virtual Grid PanBackgroundOpacity_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBackgroundOpacity;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBackgroundOpacity = value;
        }
    }

    internal virtual MySlider SliderBackgroundOpacity_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderBackgroundOpacity;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderBackgroundOpacity = value;
        }
    }

    internal virtual Grid PanBackgroundBlur_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBackgroundBlur;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBackgroundBlur = value;
        }
    }

    internal virtual MySlider SliderBackgroundBlur_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderBackgroundBlur;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderBackgroundBlur = value;
        }
    }

    internal virtual MyButton BtnBackgroundOpen_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnBackgroundOpen;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnUIBgOpen_Click;
            MyButton myButton = _BtnBackgroundOpen;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnBackgroundOpen = value;
            myButton = _BtnBackgroundOpen;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnBackgroundRefresh_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnBackgroundRefresh;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnBackgroundRefresh_Click;
            MyButton myButton = _BtnBackgroundRefresh;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnBackgroundRefresh = value;
            myButton = _BtnBackgroundRefresh;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnBackgroundClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnBackgroundClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnBackgroundClear_Click;
            MyButton myButton = _BtnBackgroundClear;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnBackgroundClear = value;
            myButton = _BtnBackgroundClear;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard CardMusic_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardMusic;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardMusic = value;
        }
    }

    internal virtual Grid PanMusicVolume_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanMusicVolume;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanMusicVolume = value;
        }
    }

    internal virtual MySlider SliderMusicVolume_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderMusicVolume;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _SliderMusicVolume = value;
        }
    }

    internal virtual StackPanel PanMusicDetail_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanMusicDetail;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanMusicDetail = value;
        }
    }

    internal virtual MyCheckBox CheckMusicRandom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckMusicRandom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckMusicRandom = value;
        }
    }

    internal virtual MyCheckBox CheckMusicAuto_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckMusicAuto;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckMusicAuto = value;
        }
    }

    internal virtual MyCheckBox CheckMusicStart_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckMusicStart;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                CheckMusicStart_Change();
            };
            MyCheckBox myCheckBox = _CheckMusicStart;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckMusicStart = value;
            myCheckBox = _CheckMusicStart;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckMusicStop_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckMusicStop;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                CheckMusicStop_Change();
            };
            MyCheckBox myCheckBox = _CheckMusicStop;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckMusicStop = value;
            myCheckBox = _CheckMusicStop;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyButton BtnMusicOpen_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnMusicOpen;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnMusicOpen_Click;
            MyButton myButton = _BtnMusicOpen;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnMusicOpen = value;
            myButton = _BtnMusicOpen;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnMusicRefresh_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnMusicRefresh;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnMusicRefresh_Click;
            MyButton myButton = _BtnMusicRefresh;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnMusicRefresh = value;
            myButton = _BtnMusicRefresh;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnMusicClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnMusicClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnMusicClear_Click;
            MyButton myButton = _BtnMusicClear;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnMusicClear = value;
            myButton = _BtnMusicClear;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard CardLogo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardLogo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardLogo = value;
        }
    }

    internal virtual MyRadioBox RadioLogoType0_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLogoType0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLogoType0 = value;
        }
    }

    internal virtual MyRadioBox RadioLogoType1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLogoType1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLogoType1 = value;
        }
    }

    internal virtual MyRadioBox RadioLogoType2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLogoType2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioLogoType2 = value;
        }
    }

    internal virtual MyRadioBox RadioLogoType3_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioLogoType3;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioBox.PreviewCheckEventHandler obj = RadioLogoType3_Check;
            MyRadioBox myRadioBox = _RadioLogoType3;
            if (myRadioBox != null)
            {
                myRadioBox.PreviewCheck -= obj;
            }
            _RadioLogoType3 = value;
            myRadioBox = _RadioLogoType3;
            if (myRadioBox != null)
            {
                myRadioBox.PreviewCheck += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckLogoLeft_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckLogoLeft;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckLogoLeft = value;
        }
    }

    internal virtual Grid PanLogoText_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLogoText;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLogoText = value;
        }
    }

    internal virtual MyTextBox TextLogoText_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextLogoText;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextLogoText = value;
        }
    }

    internal virtual Grid PanLogoChange_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLogoChange;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLogoChange = value;
        }
    }

    internal virtual MyButton BtnLogoChange_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLogoChange;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnLogoChange_Click;
            MyButton myButton = _BtnLogoChange;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnLogoChange = value;
            myButton = _BtnLogoChange;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnLogoDelete_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLogoDelete;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnLogoDelete_Click;
            MyButton myButton = _BtnLogoDelete;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnLogoDelete = value;
            myButton = _BtnLogoDelete;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard CardCustom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardCustom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardCustom = value;
        }
    }

    internal virtual MyRadioBox RadioCustomType0_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioCustomType0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioCustomType0 = value;
        }
    }

    internal virtual MyRadioBox RadioCustomType3_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioCustomType3;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioCustomType3 = value;
        }
    }

    internal virtual MyRadioBox RadioCustomType1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioCustomType1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioCustomType1 = value;
        }
    }

    internal virtual MyRadioBox RadioCustomType2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioCustomType2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioCustomType2 = value;
        }
    }

    internal virtual MyHint HintCustom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintCustom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintCustom = value;
        }
    }

    internal virtual MyHint HintCustomWarn_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintCustomWarn;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintCustomWarn = value;
        }
    }

    internal virtual Grid PanCustomLocal_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanCustomLocal;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanCustomLocal = value;
        }
    }

    internal virtual MyButton BtnCustomRefresh_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnCustomRefresh;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                BtnCustomRefresh_Click();
            };
            MyButton myButton = _BtnCustomRefresh;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnCustomRefresh = value;
            myButton = _BtnCustomRefresh;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnCustomFile_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnCustomFile;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnCustomFile_Click;
            MyButton myButton = _BtnCustomFile;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnCustomFile = value;
            myButton = _BtnCustomFile;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnCustomTutorial_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnCustomTutorial;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnCustomTutorial_Click;
            MyButton myButton = _BtnCustomTutorial;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnCustomTutorial = value;
            myButton = _BtnCustomTutorial;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual Grid PanCustomNet_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanCustomNet;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanCustomNet = value;
        }
    }

    internal virtual MyTextBox TextCustomNet_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextCustomNet;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextCustomNet = value;
        }
    }

    internal virtual Grid PanCustomPreset_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanCustomPreset;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanCustomPreset = value;
        }
    }

    internal virtual MyCard CardSwitch_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardSwitch;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardSwitch = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenPageDownload_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenPageDownload;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckHiddenPageDownload = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenPageLink_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenPageLink;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckHiddenPageLink = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenPageSetup_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenPageSetup;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenSetupMain();
            };
            MyCheckBox.ChangeEventHandler obj2 = HiddenHint;
            MyCheckBox myCheckBox = _CheckHiddenPageSetup;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
                myCheckBox.Change -= obj2;
            }
            _CheckHiddenPageSetup = value;
            myCheckBox = _CheckHiddenPageSetup;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
                myCheckBox.Change += obj2;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenPageOther_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenPageOther;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenOtherMain();
            };
            MyCheckBox myCheckBox = _CheckHiddenPageOther;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenPageOther = value;
            myCheckBox = _CheckHiddenPageOther;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenSetupLaunch_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenSetupLaunch;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenSetupSub();
            };
            MyCheckBox myCheckBox = _CheckHiddenSetupLaunch;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenSetupLaunch = value;
            myCheckBox = _CheckHiddenSetupLaunch;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenSetupLink_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenSetupLink;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenSetupSub();
            };
            MyCheckBox myCheckBox = _CheckHiddenSetupLink;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenSetupLink = value;
            myCheckBox = _CheckHiddenSetupLink;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenSetupUI_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenSetupUI;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenSetupSub();
            };
            MyCheckBox.ChangeEventHandler obj2 = HiddenHint;
            MyCheckBox myCheckBox = _CheckHiddenSetupUI;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
                myCheckBox.Change -= obj2;
            }
            _CheckHiddenSetupUI = value;
            myCheckBox = _CheckHiddenSetupUI;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
                myCheckBox.Change += obj2;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenSetupSystem_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenSetupSystem;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                HiddenSetupSub();
            };
            MyCheckBox myCheckBox = _CheckHiddenSetupSystem;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenSetupSystem = value;
            myCheckBox = _CheckHiddenSetupSystem;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenOtherHelp_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenOtherHelp;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenOtherSub;
            MyCheckBox myCheckBox = _CheckHiddenOtherHelp;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenOtherHelp = value;
            myCheckBox = _CheckHiddenOtherHelp;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenOtherAbout_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenOtherAbout;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenOtherSub;
            MyCheckBox myCheckBox = _CheckHiddenOtherAbout;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenOtherAbout = value;
            myCheckBox = _CheckHiddenOtherAbout;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenOtherTest_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenOtherTest;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenOtherSub;
            MyCheckBox myCheckBox = _CheckHiddenOtherTest;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenOtherTest = value;
            myCheckBox = _CheckHiddenOtherTest;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenOtherFeedback_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenOtherFeedback;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenOtherNet;
            MyCheckBox myCheckBox = _CheckHiddenOtherFeedback;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenOtherFeedback = value;
            myCheckBox = _CheckHiddenOtherFeedback;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckHiddenOtherVote_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenOtherVote;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenOtherNet;
            MyCheckBox myCheckBox = _CheckHiddenOtherVote;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenOtherVote = value;
            myCheckBox = _CheckHiddenOtherVote;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckLauncherEmail_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckLauncherEmail;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckLauncherEmail = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenFunctionSelect_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenFunctionSelect;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckHiddenFunctionSelect = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenFunctionModUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenFunctionModUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckHiddenFunctionModUpdate = value;
        }
    }

    internal virtual MyCheckBox CheckHiddenFunctionHidden_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckHiddenFunctionHidden;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = HiddenHint;
            MyCheckBox myCheckBox = _CheckHiddenFunctionHidden;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckHiddenFunctionHidden = value;
            myCheckBox = _CheckHiddenFunctionHidden;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    public PageSetupUI()
    {
        Loaded += PageSetupUI_Loaded;
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            HiddenRefresh();
        };
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageSetupUI_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToHome();
        ModSecret.ThemeCheckAll(EffectSetup: true);
        if (ModSecret.ThemeDontClick != 0)
        {
            string text = null;
            switch (ModSecret.ThemeDontClick)
            {
                case 1:
                    text = "眼瞎白";
                    break;
                case 2:
                    text = "真·滑稽彩";
                    break;
            }
            foreach (object child in PanLauncherTheme.Children)
            {
                object objectValue = RuntimeHelpers.GetObjectValue(child);
                if (objectValue is MyRadioBox && ((MyRadioBox)objectValue).IsEnabled)
                {
                    ((MyRadioBox)objectValue).Text = text;
                }
            }
        }
        checked
        {
            ModAnimation.AniControlEnabled++;
            Refresh();
            ModAnimation.AniControlEnabled--;
            if (_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init == null)
            {
                Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init, new StaticLocalInitFlag(), null);
            }
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init, ref lockTaken);
                if (_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init.State == 0)
                {
                    _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init.State = 2;
                    _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded = false;
                }
                else if (_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init.State == 2)
                {
                    throw new IncompleteInitialization();
                }
            }
            finally
            {
                _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init.State = 1;
                if (lockTaken)
                {
                    Monitor.Exit(_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded_0024Init);
                }
            }
            if (!_0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded)
            {
                _0024STATIC_0024PageSetupUI_Loaded_002420211C128135_0024Reloaded = true;
                SliderLoad();
                PanLauncherHide.Visibility = Visibility.Visible;
                if (!RadioLauncherTheme8.IsEnabled)
                {
                    LabLauncherTheme8Copy.ToolTip = $"累积赞助达到 ¥23.33 后，在爱发电私信发送【土豆 {ModBase.Identify}】以解锁。" + "\r\n右键打开赞助页面，如果觉得 PCL 做得还不错就支持一下吧 =w=！";
                }
                RadioLauncherTheme8.ToolTip = $"累积赞助达到 ¥23.33 后，在爱发电私信发送【土豆 {ModBase.Identify}】以解锁";
                if (!RadioLauncherTheme9.IsEnabled)
                {
                    LabLauncherTheme9Copy.ToolTip = "· 反馈一个 Bug，在标记为 [完成] 后回复识别码要求解锁（右键打开反馈页面）\r\n· 提交一个 Pull Request 或主页预设，在标记为 [完成] 后回复识别码要求解锁";
                }
                RadioLauncherTheme9.ToolTip = "· 反馈一个 Bug，在标记为 [完成] 后回复识别码要求解锁\r\n· 提交一个 Pull Request 或主页预设，在标记为 [完成] 后回复识别码要求解锁";
            }
        }
    }

    public void Refresh()
    {
        try
        {
            SettingService.RefreshSettings(this);
            BackgroundRefresh(IsHint: false, Refresh: false);
            CheckLogoLeft.Visibility = ((!RadioLogoType0.Checked) ? Visibility.Collapsed : Visibility.Visible);
            PanLogoText.Visibility = ((!RadioLogoType2.Checked) ? Visibility.Collapsed : Visibility.Visible);
            PanLogoChange.Visibility = ((!RadioLogoType3.Checked) ? Visibility.Collapsed : Visibility.Visible);
            MusicRefreshUI();
            OnMainPageTypeChanged();
        }
        catch (NullReferenceException ex)
        {
            ProjectData.SetProjectError(ex);
            NullReferenceException ex2 = ex;
            Logger.Error((Exception)ex2, "个性化设置项存在异常，已被自动重置", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            Reset();
            ProjectData.ClearProjectError();
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Error(ex4, "重载个性化设置时出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Reset()
    {
        try
        {
            SettingService.ResetSettings(this);
            Logger.Info("已初始化个性化设置！", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ModMain.Hint("已初始化个性化设置", ModMain.HintType.Green, Log: false);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "初始化个性化设置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ProjectData.ClearProjectError();
        }
        Refresh();
    }

    private void BtnUIBgOpen_Click(object sender, EventArgs e)
    {
        ModBase.OpenExplorer(Paths.Base + "PCL\\Pictures\\");
    }

    private void BtnBackgroundRefresh_Click(object sender, EventArgs e)
    {
        BackgroundRefresh(IsHint: true, Refresh: true);
    }

    public void BackgroundRefreshUI(bool Show, int Count)
    {
        if (!Information.IsNothing(PanBackgroundOpacity))
        {
            if (Show)
            {
                PanBackgroundOpacity.Visibility = Visibility.Visible;
                PanBackgroundBlur.Visibility = Visibility.Visible;
                PanBackgroundSuit.Visibility = Visibility.Visible;
                BtnBackgroundClear.Visibility = Visibility.Visible;
                CardBackground.Title = "背景图片（" + Conversions.ToString(Count) + " 张）";
            }
            else
            {
                PanBackgroundOpacity.Visibility = Visibility.Collapsed;
                PanBackgroundBlur.Visibility = Visibility.Collapsed;
                PanBackgroundSuit.Visibility = Visibility.Collapsed;
                BtnBackgroundClear.Visibility = Visibility.Collapsed;
                CardBackground.Title = "背景图片";
            }
            CardBackground.TriggerForceResize();
        }
    }

    private void BtnBackgroundClear_Click(object sender, EventArgs e)
    {
        if (ModMain.MyMsgBox("即将删除背景图片文件夹中的所有文件。\r\n此操作不可撤销，是否确定？", "警告", "确定", "取消", "", IsWarn: true) == 1)
        {
            DirectoryUtils.Delete(Paths.Base + "PCL\\Pictures", false);
            BackgroundRefresh(IsHint: false, Refresh: true);
            ModMain.Hint("背景图片已清空！", ModMain.HintType.Green);
        }
    }

    public static void BackgroundRefresh(bool IsHint, bool Refresh)
    {
        try
        {
            DirectoryUtils.Create(Paths.Base + "PCL\\Pictures\\");
            List<string> list = new List<string>();
            foreach (string item in DirectoryUtils.EnumerateFiles(Paths.Base + "PCL\\Pictures\\", true, "*"))
            {
                string extension = PathUtils.GetExtension(item);
                if (Operators.CompareString(extension, "ini", TextCompare: false) != 0 && Operators.CompareString(extension, "db", TextCompare: false) != 0)
                {
                    list.Add(item);
                }
            }
            if (!list.Any())
            {
                if (Refresh)
                {
                    if (ModMain.FrmMain.ImgBack.Visibility == Visibility.Collapsed)
                    {
                        if (IsHint)
                        {
                            ModMain.Hint("未检测到可用背景图片！", ModMain.HintType.Red);
                        }
                    }
                    else
                    {
                        ModMain.FrmMain.ImgBack.Visibility = Visibility.Collapsed;
                        if (IsHint)
                        {
                            ModMain.Hint("背景图片已清除！", ModMain.HintType.Green);
                        }
                    }
                }
                if (!Information.IsNothing(ModMain.FrmSetupUI))
                {
                    ModMain.FrmSetupUI.BackgroundRefreshUI(Show: false, 0);
                }
                return;
            }
            if (Refresh)
            {
                string text = ModBase.RandomOne(list);
                try
                {
                    Logger.Info($"加载背景图片：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                    ModMain.FrmMain.ImgBack.Background = (ImageBrush)new MyBitmap(text);
                    ModMain.FrmMain.ImgBack.Visibility = Visibility.Visible;
                    ModMain.FrmMain.UpdateBackgroundAndTitleBar();
                    if (IsHint)
                    {
                        ModMain.Hint("背景图片已刷新：" + PathUtils.GetLastPart(text), ModMain.HintType.Green, Log: false);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    if (ex2.Message.Contains("参数无效"))
                    {
                        Logger.Error(string.Format("刷新背景图片失败，该图片文件可能并非标准格式。{0}你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。{1}文件：{2}", "\r\n", "\r\n", text), (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                    }
                    else
                    {
                        Logger.Error(ex2, $"刷新背景图片失败（{text}）", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                    }
                    ProjectData.ClearProjectError();
                }
            }
            if (!Information.IsNothing(ModMain.FrmSetupUI))
            {
                ModMain.FrmSetupUI.BackgroundRefreshUI(Show: true, list.Count);
            }
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Error(ex4, "刷新背景图片时出现未知错误", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void BtnLogoChange_Click(object sender, EventArgs e)
    {
        string text = Dialogs.SelectFile("选择图片", false, (string)null, (OneOf<IEnumerable<(string[], string)>, string>)(new (string[], string)[1] { (new string[5] { "png", "jpg", "jpeg", "gif", "webp" }, "常用图片文件") })).FirstOrDefault();
        if (string.IsNullOrEmpty(text))
        {
            return;
        }
        string text2 = Paths.Base + "PCL\\Logo.png";
        try
        {
            FileUtils.Copy(text, text2);
            ModMain.FrmMain.ImageTitleLogo.Source = null;
            ModMain.FrmMain.ImageTitleLogo.Source = text2;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            if (ex2.Message.Contains("参数无效"))
            {
                Logger.Error(string.Format("改变标题栏图片失败，该图片文件可能并非标准格式。{0}你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。{1}文件：{2}", "\r\n", "\r\n", text2), (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            }
            else
            {
                Logger.Error(ex2, "设置标题栏图片失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            }
            ModMain.FrmMain.ImageTitleLogo.Source = null;
            ProjectData.ClearProjectError();
        }
    }

    private void RadioLogoType3_Check(object sender, ModBase.RouteEventArgs e)
    {
        if (ModAnimation.AniControlEnabled != 0 || !e.RaiseByMouse)
        {
            return;
        }
        while (true)
        {
            string text = Paths.Base + "PCL\\Logo.png";
            if (FileUtils.Exists(text))
            {
                try
                {
                    ModMain.FrmMain.ImageTitleLogo.Source = null;
                    ModMain.FrmMain.ImageTitleLogo.Source = text;
                    return;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    if (ex2.Message.Contains("参数无效"))
                    {
                        Logger.Error(string.Format("改变标题栏图片失败，该图片文件可能并非标准格式。{0}你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。{1}文件：{2}", "\r\n", "\r\n", text), (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                    }
                    else
                    {
                        Logger.Error(ex2, "调整标题栏图片失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                    }
                    ModMain.FrmMain.ImageTitleLogo.Source = null;
                    e.Handled = true;
                    try
                    {
                        FileUtils.Delete(text, false);
                    }
                    catch (Exception ex3)
                    {
                        ProjectData.SetProjectError(ex3);
                        Exception ex4 = ex3;
                        Logger.Error(ex4, "清理错误的标题栏图片失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                        ProjectData.ClearProjectError();
                    }
                    ProjectData.ClearProjectError();
                    return;
                }
            }
            string text2 = Dialogs.SelectFile("选择图片", false, (string)null, (OneOf<IEnumerable<(string[], string)>, string>)(new (string[], string)[1] { (new string[5] { "png", "jpeg", "jpg", "gif", "webp" }, "常用图片文件") })).FirstOrDefault();
            if (string.IsNullOrEmpty(text2))
            {
                break;
            }
            try
            {
                FileUtils.Copy(text2, text);
            }
            catch (Exception ex5)
            {
                ProjectData.SetProjectError(ex5);
                Exception ex6 = ex5;
                Logger.Error(ex6, "复制标题栏图片失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                ProjectData.ClearProjectError();
                return;
            }
        }
        ModMain.FrmMain.ImageTitleLogo.Source = null;
        e.Handled = true;
    }

    private void BtnLogoDelete_Click(object sender, EventArgs e)
    {
        try
        {
            FileUtils.Delete(Paths.Base + "PCL\\Logo.png", false);
            RadioLogoType1.SetChecked(value: true, user: true);
            ModMain.Hint("标题栏图片已清空！", ModMain.HintType.Green);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "清空标题栏图片失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void BtnMusicOpen_Click(object sender, EventArgs e)
    {
        ModBase.OpenExplorer(Paths.Base + "PCL\\Musics\\");
    }

    private void BtnMusicRefresh_Click(object sender, EventArgs e)
    {
        ModMusic.MusicRefreshPlay(ShowHint: true);
    }

    public void MusicRefreshUI()
    {
        if (PanBackgroundOpacity == null)
        {
            return;
        }
        if (ModMusic.MusicAllList.Any())
        {
            PanMusicVolume.Visibility = Visibility.Visible;
            PanMusicDetail.Visibility = Visibility.Visible;
            BtnMusicClear.Visibility = Visibility.Visible;
            CardMusic.Title = "背景音乐（" + Conversions.ToString(DirectoryUtils.EnumerateFiles(Paths.Base + "PCL\\Musics\\", true, "*").Count((string f) => !new string[7] { "ini", "jpg", "txt", "cfg", "lrc", "db", "png" }.Contains(PathUtils.GetExtension(f)))) + " 首）";
        }
        else
        {
            PanMusicVolume.Visibility = Visibility.Collapsed;
            PanMusicDetail.Visibility = Visibility.Collapsed;
            BtnMusicClear.Visibility = Visibility.Collapsed;
            CardMusic.Title = "背景音乐";
        }
        CardMusic.TriggerForceResize();
    }

    private void BtnMusicClear_Click(object sender, EventArgs e)
    {
        if (ModMain.MyMsgBox("即将删除背景音乐文件夹中的所有文件。\r\n此操作不可撤销，是否确定？", "警告", "确定", "取消", "", IsWarn: true) != 1)
        {
            return;
        }
        ModBase.RunInThread(() =>
        {
            ModMain.Hint("正在删除背景音乐……");
            ModMusic.MusicNAudio = null;
            ModMusic.MusicWaitingList = new List<string>();
            ModMusic.MusicAllList = new List<string>();
            Thread.Sleep(200);
            try
            {
                DirectoryUtils.Delete(Paths.Base + "PCL\\Musics", false);
                ModMain.Hint("背景音乐已删除！", ModMain.HintType.Green);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "删除背景音乐失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                ProjectData.ClearProjectError();
            }
            try
            {
                DirectoryUtils.Create(Paths.Base + "PCL\\Musics\\");
                ModBase.RunInUi(() =>
                {
                    ModMusic.MusicRefreshPlay(ShowHint: false);
                });
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Error(ex4, "重建背景音乐文件夹失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                ProjectData.ClearProjectError();
            }
        });
    }

    private void CheckMusicStart_Change()
    {
        if (ModAnimation.AniControlEnabled == 0 && CheckMusicStart.Checked)
        {
            CheckMusicStop.Checked = false;
        }
    }

    private void CheckMusicStop_Change()
    {
        if (ModAnimation.AniControlEnabled == 0 && CheckMusicStop.Checked)
        {
            CheckMusicStart.Checked = false;
        }
    }

    private void BtnCustomFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (!FileUtils.Exists(Paths.Base + "PCL\\Custom.xaml") || ModMain.MyMsgBox("当前已存在布局文件，继续生成教学文件将会覆盖现有布局文件！", "覆盖确认", "继续", "取消", "", IsWarn: true) != 2)
            {
                ModBase.ExtractResources(Paths.Base + "PCL\\Custom.xaml", "Custom");
                ModMain.Hint("教学文件已生成！", ModMain.HintType.Green);
                ModBase.OpenExplorer(Paths.Base + "PCL\\Custom.xaml");
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "生成教学文件失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void BtnCustomRefresh_Click()
    {
        ModMain.FrmLaunchRight.ForceRefresh();
        ModMain.Hint("已刷新主页！", ModMain.HintType.Green);
    }

    private void BtnCustomTutorial_Click(object sender, EventArgs e)
    {
        ModMain.MyMsgBox("1. 点击 生成教学文件 按钮，这会在 PCL 文件夹下生成 Custom.xaml 布局文件。\r\n2. 使用记事本等工具打开这个文件并进行修改，修改完记得保存。\r\n3. 点击 刷新主页 按钮，查看主页现在长啥样了。\r\n\r\n你可以在生成教学文件后直接刷新主页，对照着进行修改，更有助于理解。\r\n直接将主页文件拖进 PCL 窗口也可以快捷加载。", "主页自定义教程");
    }

    public static void OnMainPageTypeChanged()
    {
        if (ModMain.FrmSetupUI != null)
        {
            switch (Settings.Get<int>("UiCustomType"))
            {
                case 0:
                    ModMain.FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.HintCustom.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.HintCustomWarn.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    ModMain.FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomLocal.Visibility = Visibility.Visible;
                    ModMain.FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.HintCustom.Visibility = Visibility.Visible;
                    ModMain.FrmSetupUI.HintCustomWarn.Visibility = (Settings.Get<bool>("HintCustomWarn") ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmSetupUI.HintCustom.Text = string.Format("从 PCL 文件夹下的 Custom.xaml 读取主页内容。{0}你可以手动编辑该文件，向主页添加文本、图片、常用网站、快捷启动等功能。", "\r\n");
                    CustomEventService.SetEventType(ModMain.FrmSetupUI.HintCustom, CustomEvent.EventType.None);
                    break;
                case 2:
                    ModMain.FrmSetupUI.PanCustomPreset.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomNet.Visibility = Visibility.Visible;
                    ModMain.FrmSetupUI.HintCustom.Visibility = Visibility.Visible;
                    ModMain.FrmSetupUI.HintCustomWarn.Visibility = (Settings.Get<bool>("HintCustomWarn") ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmSetupUI.HintCustom.Text = string.Format("从指定网址联网获取主页内容。服主也可以用于动态更新服务器公告。{0}如果你制作了稳定运行的联网主页，可以点击这条提示投稿，若合格即可加入预设！", "\r\n");
                    CustomEventService.SetEventType(ModMain.FrmSetupUI.HintCustom, CustomEvent.EventType.打开网页);
                    CustomEventService.SetEventData(ModMain.FrmSetupUI.HintCustom, "https://github.com/Meloong-Git/PCL/discussions/2528");
                    break;
                case 3:
                    ModMain.FrmSetupUI.PanCustomPreset.Visibility = Visibility.Visible;
                    ModMain.FrmSetupUI.PanCustomLocal.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.PanCustomNet.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.HintCustom.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupUI.HintCustomWarn.Visibility = Visibility.Collapsed;
                    break;
            }
            ModMain.FrmSetupUI.CardCustom.TriggerForceResize();
        }
    }

    private void LabLauncherTheme5Unlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        RadioLauncherTheme5Gray.Opacity -= 0.7;
        RadioLauncherTheme5.Opacity += 0.7;
        ModAnimation.AniStart(checked(new ModAnimation.AniData[2]
        {
            ModAnimation.AaOpacity(RadioLauncherTheme5Gray, 1.0, (int)Math.Round(1000.0 * ModAnimation.AniSpeed), (int)Math.Round(500.0 * ModAnimation.AniSpeed), new ModAnimation.AniEaseInFluent()),
            ModAnimation.AaOpacity(RadioLauncherTheme5, -1.0, (int)Math.Round(1000.0 * ModAnimation.AniSpeed), (int)Math.Round(500.0 * ModAnimation.AniSpeed), new ModAnimation.AniEaseInFluent())
        }), "ThemeUnlock");
        if (RadioLauncherTheme5Gray.Opacity < 0.02)
        {
            ModSecret.ThemeUnlock(5, ShowDoubleHint: true, "隐藏主题 玄素黑 已解锁！");
            ModAnimation.AniStop("ThemeUnlock");
            RadioLauncherTheme5.Checked = true;
        }
    }

    private void LabLauncherTheme11Click_MouseLeftButtonUp()
    {
        if ((LabLauncherTheme11Click.Visibility == Visibility.Collapsed || (LabLauncherTheme11Click.ToolTip ?? "").ToString().Contains("点击")) && ModMain.MyMsgBox("1. 不爬取或攻击相关服务或网站，不盗取相关账号，没有谜题可以或需要以此来解决。\r\n2. 不得篡改或损毁相关公开信息，请尽量让它们保持原状。\r\n3. 在你感到迷茫的时候，看看回声洞可能会给你带来惊喜。\r\n\r\n若违规，可能会被从任意相关群中踢出！", "解密游戏的基本规则", "我知道了", "恕我拒绝") == 1)
        {
            ModMain.MyMsgBox("你需要用自己的智慧来找到下一步的线索……\r\n初始线索：gnp.dorC61\\60\\20\\0202\\moc.x1xa.2s\\\\:sp" + StringExtensions.Lower("T") + "th", "解密游戏");
        }
    }

    private void LabLauncherTheme8Copy_MouseRightButtonUp()
    {
        ModBase.OpenWebsite("https://meloong.com/afd/a/LTCat");
    }

    private void LabLauncherTheme9Copy_MouseRightButtonUp()
    {
        PageOtherLeft.TryFeedback();
    }

    private void RadioLauncherTheme14_Change(object sender, ModBase.RouteEventArgs e)
    {
        if (RadioLauncherTheme14.Checked)
        {
            if (LabLauncherHue.Visibility == Visibility.Visible)
            {
                return;
            }
            LabLauncherHue.Visibility = Visibility.Visible;
            SliderLauncherHue.Visibility = Visibility.Visible;
            LabLauncherSat.Visibility = Visibility.Visible;
            SliderLauncherSat.Visibility = Visibility.Visible;
            LabLauncherDelta.Visibility = Visibility.Visible;
            SliderLauncherDelta.Visibility = Visibility.Visible;
            LabLauncherLight.Visibility = Visibility.Visible;
            SliderLauncherLight.Visibility = Visibility.Visible;
        }
        else
        {
            if (LabLauncherHue.Visibility == Visibility.Collapsed)
            {
                return;
            }
            LabLauncherHue.Visibility = Visibility.Collapsed;
            SliderLauncherHue.Visibility = Visibility.Collapsed;
            LabLauncherSat.Visibility = Visibility.Collapsed;
            SliderLauncherSat.Visibility = Visibility.Collapsed;
            LabLauncherDelta.Visibility = Visibility.Collapsed;
            SliderLauncherDelta.Visibility = Visibility.Collapsed;
            LabLauncherLight.Visibility = Visibility.Collapsed;
            SliderLauncherLight.Visibility = Visibility.Collapsed;
        }
        CardLauncher.TriggerForceResize();
    }

    private void HSL_Change()
    {
        if (ModAnimation.AniControlEnabled == 0 && SliderLauncherSat != null && SliderLauncherSat.IsLoaded)
        {
            ModSecret.ThemeRefresh();
        }
    }

    public static void HiddenRefresh()
    {
        if (ModMain.FrmMain.PanTitleSelect == null || !ModMain.FrmMain.PanTitleSelect.IsLoaded)
        {
            return;
        }
        checked
        {
            try
            {
                if (!HiddenForceShow && Settings.Get<bool>("UiHiddenPageDownload") && Settings.Get<bool>("UiHiddenPageLink") && Settings.Get<bool>("UiHiddenPageSetup") && Settings.Get<bool>("UiHiddenPageOther"))
                {
                    ModMain.FrmMain.PanTitleSelect.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ModMain.FrmMain.PanTitleSelect.Visibility = Visibility.Visible;
                    ModMain.FrmMain.BtnTitleSelect1.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenPageDownload")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmMain.BtnTitleSelect2.Visibility = Visibility.Collapsed;
                    ModMain.FrmMain.BtnTitleSelect3.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenPageSetup")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmMain.BtnTitleSelect4.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenPageOther")) ? Visibility.Collapsed : Visibility.Visible);
                }
                ModMain.FrmLaunchLeft.RefreshButtonsUI();
                if (ModMain.FrmSetupUI != null)
                {
                    ModMain.FrmSetupUI.CardSwitch.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenFunctionHidden")) ? Visibility.Collapsed : Visibility.Visible);
                }
                if (ModMain.FrmSetupLeft != null)
                {
                    ModMain.FrmSetupLeft.ItemLaunch.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenSetupLaunch")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmSetupLeft.ItemUI.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenSetupUi")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmSetupLeft.ItemLink.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupLeft.ItemSystem.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenSetupSystem")) ? Visibility.Collapsed : Visibility.Visible);
                    int num = 0;
                    if (!Settings.Get<bool>("UiHiddenSetupLaunch"))
                    {
                        num++;
                    }
                    if (!Settings.Get<bool>("UiHiddenSetupUi"))
                    {
                        num++;
                    }
                    if (!Settings.Get<bool>("UiHiddenSetupSystem"))
                    {
                        num++;
                    }
                    ModMain.FrmSetupLeft.PanItem.Visibility = ((num < 2 && !HiddenForceShow) ? Visibility.Collapsed : Visibility.Visible);
                }
                int num2 = 0;
                if (!Settings.Get<bool>("UiHiddenOtherHelp"))
                {
                    num2++;
                }
                if (!Settings.Get<bool>("UiHiddenOtherAbout"))
                {
                    num2++;
                }
                if (!Settings.Get<bool>("UiHiddenOtherTest"))
                {
                    num2++;
                }
                if (!Settings.Get<bool>("UiHiddenOtherFeedback"))
                {
                    num2++;
                }
                if (!Settings.Get<bool>("UiHiddenOtherVote"))
                {
                    num2++;
                }
                if (ModMain.FrmOtherLeft != null)
                {
                    ModMain.FrmOtherLeft.ItemHelp.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenOtherHelp")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmOtherLeft.ItemFeedback.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenOtherFeedback")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmOtherLeft.ItemVote.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenOtherVote")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmOtherLeft.ItemAbout.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenOtherAbout")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmOtherLeft.ItemTest.Visibility = ((!HiddenForceShow && Settings.Get<bool>("UiHiddenOtherTest")) ? Visibility.Collapsed : Visibility.Visible);
                    ModMain.FrmOtherLeft.PanItem.Visibility = ((num2 < 2 && !HiddenForceShow) ? Visibility.Collapsed : Visibility.Visible);
                }
                if (num2 == 1 && !HiddenForceShow)
                {
                    if (!Settings.Get<bool>("UiHiddenOtherHelp"))
                    {
                        ModMain.FrmMain.BtnTitleSelect4.Text = "帮助";
                    }
                    else if (!Settings.Get<bool>("UiHiddenOtherAbout"))
                    {
                        ModMain.FrmMain.BtnTitleSelect4.Text = "关于";
                    }
                    else
                    {
                        ModMain.FrmMain.BtnTitleSelect4.Text = "百宝箱";
                    }
                }
                else
                {
                    ModMain.FrmMain.BtnTitleSelect4.Text = "更多";
                }
                if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect)
                {
                    ModMain.FrmSelectRight.BtnEmptyDownload_Loaded();
                }
                if (ModMain.FrmMain.PageCurrent == FormMain.PageType.Launch)
                {
                    ModMain.FrmLaunchLeft.RefreshButtonsUI();
                }
                if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmInstanceModDisabled != null)
                {
                    ModMain.FrmInstanceModDisabled.BtnDownload_Loaded();
                }
                if (ModMain.FrmSetupUI != null)
                {
                    ModMain.FrmSetupUI.CardSwitch.Title = (HiddenForceShow ? "功能隐藏（已暂时关闭，按 F12 以重新启用）" : "功能隐藏");
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "刷新功能隐藏项目失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupUI.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    private void HiddenSetupMain()
    {
        if (CheckHiddenPageSetup.Checked)
        {
            CheckHiddenSetupLaunch.Checked = true;
            CheckHiddenSetupSystem.Checked = true;
            CheckHiddenSetupLink.Checked = true;
            CheckHiddenSetupUI.Checked = true;
        }
        else if (Settings.Get<bool>("UiHiddenSetupLaunch") && Settings.Get<bool>("UiHiddenSetupUi") && Settings.Get<bool>("UiHiddenSetupSystem") && Settings.Get<bool>("UiHiddenSetupLink"))
        {
            CheckHiddenSetupLaunch.Checked = false;
            CheckHiddenSetupSystem.Checked = false;
            CheckHiddenSetupLink.Checked = false;
            CheckHiddenSetupUI.Checked = false;
        }
    }

    private void HiddenSetupSub()
    {
        if (Settings.Get<bool>("UiHiddenSetupLaunch") && Settings.Get<bool>("UiHiddenSetupUi") && Settings.Get<bool>("UiHiddenSetupSystem") && Settings.Get<bool>("UiHiddenSetupLink"))
        {
            CheckHiddenPageSetup.Checked = true;
        }
        else
        {
            CheckHiddenPageSetup.Checked = false;
        }
    }

    private void HiddenOtherMain()
    {
        if (CheckHiddenPageOther.Checked)
        {
            CheckHiddenOtherAbout.Checked = true;
            CheckHiddenOtherTest.Checked = true;
            CheckHiddenOtherFeedback.Checked = true;
            CheckHiddenOtherVote.Checked = true;
            CheckHiddenOtherHelp.Checked = true;
        }
        else if (Settings.Get<bool>("UiHiddenOtherHelp") && Settings.Get<bool>("UiHiddenOtherAbout") && Settings.Get<bool>("UiHiddenOtherTest") && Settings.Get<bool>("UiHiddenOtherVote") && Settings.Get<bool>("UiHiddenOtherFeedback"))
        {
            CheckHiddenOtherAbout.Checked = false;
            CheckHiddenOtherTest.Checked = false;
            CheckHiddenOtherFeedback.Checked = false;
            CheckHiddenOtherVote.Checked = false;
            CheckHiddenOtherHelp.Checked = false;
        }
    }

    private void HiddenOtherSub(object sender, bool user)
    {
        if (Settings.Get<bool>("UiHiddenOtherHelp") && Settings.Get<bool>("UiHiddenOtherAbout") && Settings.Get<bool>("UiHiddenOtherTest"))
        {
            CheckHiddenPageOther.Checked = true;
        }
        else
        {
            CheckHiddenPageOther.Checked = false;
        }
        if (user && Settings.Get<bool>("UiHiddenOtherHelp") && Settings.Get<bool>("UiHiddenOtherAbout") && Settings.Get<bool>("UiHiddenOtherTest"))
        {
            CheckHiddenOtherFeedback.Checked = true;
            CheckHiddenOtherVote.Checked = true;
        }
    }

    private void HiddenOtherNet(object sender, bool user)
    {
        if (user && Settings.Get<bool>("UiHiddenOtherHelp") && Settings.Get<bool>("UiHiddenOtherAbout") && Settings.Get<bool>("UiHiddenOtherTest") && (!Settings.Get<bool>("UiHiddenOtherFeedback") || !Settings.Get<bool>("UiHiddenOtherVote")))
        {
            CheckHiddenOtherAbout.Checked = false;
            CheckHiddenOtherTest.Checked = false;
            CheckHiddenOtherHelp.Checked = false;
        }
    }

    private void HiddenHint(object sender, bool user)
    {
        if (Conversions.ToBoolean(ModAnimation.AniControlEnabled == 0 && Conversions.ToBoolean(NewLateBinding.LateGet(sender, null, "Checked", new object[0], null, null, null))))
        {
            ModMain.Hint("按 F12 即可暂时关闭功能隐藏设置。千万别忘了，要不然设置就改不回来了……");
        }
    }

    private void SliderLoad()
    {
        SliderMusicVolume.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(NewLateBinding.LateGet(null, typeof(Math), "Ceiling", new object[1] { Operators.MultiplyObject(v, 0.1) }, null, null, null), "%"));
        SliderLauncherTransparent.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(NewLateBinding.LateGet(null, typeof(Math), "Round", new object[1] { Operators.AddObject(40, Operators.MultiplyObject(v, 0.1)) }, null, null, null), "%"));
        SliderLauncherHue.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(v, "°"));
        SliderLauncherSat.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(v, "%"));
        checked
        {
            SliderLauncherDelta.GetHintText = (VB_0024AnonymousDelegate_26<int, string>)((int Value) =>
            {
                if (Value > 90)
                {
                    return "+" + Conversions.ToString(Value - 90);
                }
                return (Value == 90) ? Conversions.ToString(0) : Conversions.ToString(Value - 90);
            });
            SliderLauncherLight.GetHintText = (VB_0024AnonymousDelegate_26<int, string>)((int Value) =>
            {
                if (Value > 20)
                {
                    return "+" + Conversions.ToString(Value - 20);
                }
                return (Value == 20) ? Conversions.ToString(0) : Conversions.ToString(Value - 20);
            });
            SliderBackgroundOpacity.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(NewLateBinding.LateGet(null, typeof(Math), "Round", new object[1] { Operators.MultiplyObject(v, 0.1) }, null, null, null), "%"));
            SliderBackgroundBlur.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)((object v) => Operators.ConcatenateObject(v, " 像素"));
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnBackgroundClear_WithEvents = BtnBackgroundClear;
        BtnBackgroundOpen_WithEvents = BtnBackgroundOpen;
        BtnBackgroundRefresh_WithEvents = BtnBackgroundRefresh;
        BtnCustomFile_WithEvents = BtnCustomFile;
        BtnCustomRefresh_WithEvents = BtnCustomRefresh;
        BtnCustomTutorial_WithEvents = BtnCustomTutorial;
        BtnLogoChange_WithEvents = BtnLogoChange;
        BtnLogoDelete_WithEvents = BtnLogoDelete;
        BtnMusicClear_WithEvents = BtnMusicClear;
        BtnMusicOpen_WithEvents = BtnMusicOpen;
        BtnMusicRefresh_WithEvents = BtnMusicRefresh;
        CardBackground_WithEvents = CardBackground;
        CardCustom_WithEvents = CardCustom;
        CardLauncher_WithEvents = CardLauncher;
        CardLogo_WithEvents = CardLogo;
        CardMusic_WithEvents = CardMusic;
        CardSwitch_WithEvents = CardSwitch;
        CheckHiddenFunctionHidden_WithEvents = CheckHiddenFunctionHidden;
        CheckHiddenFunctionModUpdate_WithEvents = CheckHiddenFunctionModUpdate;
        CheckHiddenFunctionSelect_WithEvents = CheckHiddenFunctionSelect;
        CheckHiddenOtherAbout_WithEvents = CheckHiddenOtherAbout;
        CheckHiddenOtherFeedback_WithEvents = CheckHiddenOtherFeedback;
        CheckHiddenOtherHelp_WithEvents = CheckHiddenOtherHelp;
        CheckHiddenOtherTest_WithEvents = CheckHiddenOtherTest;
        CheckHiddenOtherVote_WithEvents = CheckHiddenOtherVote;
        CheckHiddenPageDownload_WithEvents = CheckHiddenPageDownload;
        CheckHiddenPageLink_WithEvents = CheckHiddenPageLink;
        CheckHiddenPageOther_WithEvents = CheckHiddenPageOther;
        CheckHiddenPageSetup_WithEvents = CheckHiddenPageSetup;
        CheckHiddenSetupLaunch_WithEvents = CheckHiddenSetupLaunch;
        CheckHiddenSetupLink_WithEvents = CheckHiddenSetupLink;
        CheckHiddenSetupSystem_WithEvents = CheckHiddenSetupSystem;
        CheckHiddenSetupUI_WithEvents = CheckHiddenSetupUI;
        CheckLauncherEmail_WithEvents = CheckLauncherEmail;
        CheckLogoLeft_WithEvents = CheckLogoLeft;
        CheckMusicAuto_WithEvents = CheckMusicAuto;
        CheckMusicRandom_WithEvents = CheckMusicRandom;
        CheckMusicStart_WithEvents = CheckMusicStart;
        CheckMusicStop_WithEvents = CheckMusicStop;
        HintCustom_WithEvents = HintCustom;
        HintCustomWarn_WithEvents = HintCustomWarn;
        LabLauncherDelta_WithEvents = LabLauncherDelta;
        LabLauncherHue_WithEvents = LabLauncherHue;
        LabLauncherLight_WithEvents = LabLauncherLight;
        LabLauncherSat_WithEvents = LabLauncherSat;
        LabLauncherTheme11Click_WithEvents = LabLauncherTheme11Click;
        LabLauncherTheme5Unlock_WithEvents = LabLauncherTheme5Unlock;
        LabLauncherTheme8Copy_WithEvents = LabLauncherTheme8Copy;
        LabLauncherTheme9Copy_WithEvents = LabLauncherTheme9Copy;
        PanBack_WithEvents = PanBack;
        PanBackgroundBlur_WithEvents = PanBackgroundBlur;
        PanBackgroundOpacity_WithEvents = PanBackgroundOpacity;
        PanBackgroundSuit_WithEvents = PanBackgroundSuit;
        PanCustomLocal_WithEvents = PanCustomLocal;
        PanCustomNet_WithEvents = PanCustomNet;
        PanCustomPreset_WithEvents = PanCustomPreset;
        PanLauncherHide_WithEvents = PanLauncherHide;
        PanLauncherTheme_WithEvents = PanLauncherTheme;
        PanLogoChange_WithEvents = PanLogoChange;
        PanLogoText_WithEvents = PanLogoText;
        PanMain_WithEvents = PanMain;
        PanMusicDetail_WithEvents = PanMusicDetail;
        PanMusicVolume_WithEvents = PanMusicVolume;
        RadioCustomType0_WithEvents = RadioCustomType0;
        RadioCustomType1_WithEvents = RadioCustomType1;
        RadioCustomType2_WithEvents = RadioCustomType2;
        RadioCustomType3_WithEvents = RadioCustomType3;
        RadioLauncherTheme0_WithEvents = RadioLauncherTheme0;
        RadioLauncherTheme1_WithEvents = RadioLauncherTheme1;
        RadioLauncherTheme10_WithEvents = RadioLauncherTheme10;
        RadioLauncherTheme11_WithEvents = RadioLauncherTheme11;
        RadioLauncherTheme12_WithEvents = RadioLauncherTheme12;
        RadioLauncherTheme13_WithEvents = RadioLauncherTheme13;
        RadioLauncherTheme14_WithEvents = RadioLauncherTheme14;
        RadioLauncherTheme2_WithEvents = RadioLauncherTheme2;
        RadioLauncherTheme3_WithEvents = RadioLauncherTheme3;
        RadioLauncherTheme4_WithEvents = RadioLauncherTheme4;
        RadioLauncherTheme5_WithEvents = RadioLauncherTheme5;
        RadioLauncherTheme5Gray_WithEvents = RadioLauncherTheme5Gray;
        RadioLauncherTheme6_WithEvents = RadioLauncherTheme6;
        RadioLauncherTheme7_WithEvents = RadioLauncherTheme7;
        RadioLauncherTheme8_WithEvents = RadioLauncherTheme8;
        RadioLauncherTheme9_WithEvents = RadioLauncherTheme9;
        RadioLogoType0_WithEvents = RadioLogoType0;
        RadioLogoType1_WithEvents = RadioLogoType1;
        RadioLogoType2_WithEvents = RadioLogoType2;
        RadioLogoType3_WithEvents = RadioLogoType3;
        SliderBackgroundBlur_WithEvents = SliderBackgroundBlur;
        SliderBackgroundOpacity_WithEvents = SliderBackgroundOpacity;
        SliderLauncherDelta_WithEvents = SliderLauncherDelta;
        SliderLauncherHue_WithEvents = SliderLauncherHue;
        SliderLauncherLight_WithEvents = SliderLauncherLight;
        SliderLauncherSat_WithEvents = SliderLauncherSat;
        SliderLauncherTransparent_WithEvents = SliderLauncherTransparent;
        SliderMusicVolume_WithEvents = SliderMusicVolume;
        TextCustomNet_WithEvents = TextCustomNet;
        TextLogoText_WithEvents = TextLogoText;
    }
}

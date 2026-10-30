using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Windows.Threading;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupLaunch : MyPageRight, IComponentConnector
{
    [Serializable]
    [CompilerGenerated]
    internal sealed class _Closure_0024__
    {
        public static readonly _Closure_0024__ _0024I;

        public static Func<FileInfo, bool> _0024I17_002D0;

        public static MouseButtonEventHandler _0024I18_002D0;

        public static VB_0024AnonymousDelegate_10 _0024I18_002D1;

        public static MyListItem.ClickEventHandler _0024IR18_002D2;

        public static MouseButtonEventHandler _0024I18_002D6;

        static _Closure_0024__()
        {
            _0024I = new _Closure_0024__();
        }

        internal bool _Lambda_0024__17_002D0(FileInfo f)
        {
            return new string[3] { ".jar", ".zip", ".litemod" }.Contains(StringExtensions.Lower(f.Extension));
        }

        internal void _Lambda_0024__18_002D0(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        internal void _Lambda_0024__R18_002D2(object a0, MouseButtonEventArgs a1)
        {
            ((VB_0024AnonymousDelegate_10)(() =>
            {
                ModMain.Hint("点击选项右侧的箭头可以进行排序，以控制 PCL 优先选择哪个 Java！");
            }))();
        }

        internal void _Lambda_0024__18_002D1()
        {
            ModMain.Hint("点击选项右侧的箭头可以进行排序，以控制 PCL 优先选择哪个 Java！");
        }

        internal void _Lambda_0024__18_002D6(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            ModJava.ManuallyImportJava();
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__18_002D0
    {
        public Java _0024VB_0024Local_JavaEntry;

        public PageSetupLaunch _0024VB_0024Me;

        public _Closure_0024__18_002D0(_Closure_0024__18_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_JavaEntry = arg0._0024VB_0024Local_JavaEntry;
            }
        }

        internal void _Lambda_0024__R3(object a0, EventArgs a1)
        {
            _Lambda_0024__2();
        }

        internal void _Lambda_0024__2()
        {
            _0024VB_0024Me.MoveJavaInList(_0024VB_0024Local_JavaEntry, -1);
        }

        internal void _Lambda_0024__R4(object a0, EventArgs a1)
        {
            _Lambda_0024__3();
        }

        internal void _Lambda_0024__3()
        {
            _0024VB_0024Me.MoveJavaInList(_0024VB_0024Local_JavaEntry, 1);
        }

        internal void _Lambda_0024__R5(object a0, EventArgs a1)
        {
            _Lambda_0024__4();
        }

        internal void _Lambda_0024__4()
        {
            ModJava.ManuallyRemoveJava(_0024VB_0024Local_JavaEntry);
        }

        internal void _Lambda_0024__R6(object a0, EventArgs a1)
        {
            _Lambda_0024__5();
        }

        internal void _Lambda_0024__5()
        {
            ModBase.OpenExplorer(_0024VB_0024Local_JavaEntry.JavaExePath);
        }
    }

    private int RamTextLeft;

    private int RamTextRight;

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
    [AccessedThroughProperty("ComboArgumentIndieV2")]
    private MyComboBox _ComboArgumentIndieV2;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboArgumentVisibie")]
    private MyComboBox _ComboArgumentVisibie;

    [CompilerGenerated]
    [AccessedThroughProperty("PanArgumentWindow")]
    private Grid _PanArgumentWindow;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboArgumentWindowType")]
    private MyComboBox _ComboArgumentWindowType;

    [CompilerGenerated]
    [AccessedThroughProperty("TextArgumentWindowWidth")]
    private MyTextBox _TextArgumentWindowWidth;

    [CompilerGenerated]
    [AccessedThroughProperty("LabArgumentWindowMiddle")]
    private TextBlock _LabArgumentWindowMiddle;

    [CompilerGenerated]
    [AccessedThroughProperty("TextArgumentWindowHeight")]
    private MyTextBox _TextArgumentWindowHeight;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioRamType0")]
    private MyRadioBox _RadioRamType0;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioRamType1")]
    private MyRadioBox _RadioRamType1;

    [CompilerGenerated]
    [AccessedThroughProperty("SliderRamCustom")]
    private MySlider _SliderRamCustom;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckArgumentRam")]
    private MyCheckBox _CheckArgumentRam;

    [CompilerGenerated]
    [AccessedThroughProperty("PanRamDisplay")]
    private Grid _PanRamDisplay;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnRamUsed")]
    private ColumnDefinition _ColumnRamUsed;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnRamGame")]
    private ColumnDefinition _ColumnRamGame;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnRamEmpty")]
    private ColumnDefinition _ColumnRamEmpty;

    [CompilerGenerated]
    [AccessedThroughProperty("RectRamUsed")]
    private System.Windows.Shapes.Rectangle _RectRamUsed;

    [CompilerGenerated]
    [AccessedThroughProperty("RectRamGame")]
    private System.Windows.Shapes.Rectangle _RectRamGame;

    [CompilerGenerated]
    [AccessedThroughProperty("RectRamEmpty")]
    private System.Windows.Shapes.Rectangle _RectRamEmpty;

    [CompilerGenerated]
    [AccessedThroughProperty("LabRamUsedTitle")]
    private TextBlock _LabRamUsedTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("LabRamGameTitle")]
    private TextBlock _LabRamGameTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("LabRamUsed")]
    private TextBlock _LabRamUsed;

    [CompilerGenerated]
    [AccessedThroughProperty("LabRamTotal")]
    private TextBlock _LabRamTotal;

    [CompilerGenerated]
    [AccessedThroughProperty("LabRamGame")]
    private TextBlock _LabRamGame;

    [CompilerGenerated]
    [AccessedThroughProperty("CardSkin")]
    private MyCard _CardSkin;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioSkinType0")]
    private MyRadioBox _RadioSkinType0;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioSkinType1")]
    private MyRadioBox _RadioSkinType1;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioSkinType2")]
    private MyRadioBox _RadioSkinType2;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioSkinType3")]
    private MyRadioBox _RadioSkinType3;

    [CompilerGenerated]
    [AccessedThroughProperty("RadioSkinType4")]
    private MyRadioBox _RadioSkinType4;

    [CompilerGenerated]
    [AccessedThroughProperty("PanSkinID")]
    private Grid _PanSkinID;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSkinSave")]
    private MyButton _BtnSkinSave;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSkinCache")]
    private MyButton _BtnSkinCache;

    [CompilerGenerated]
    [AccessedThroughProperty("PanSkinChange")]
    private Grid _PanSkinChange;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSkinChange")]
    private MyButton _BtnSkinChange;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSkinDelete")]
    private MyButton _BtnSkinDelete;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAdvanceJvmReset")]
    private MyIconButton _BtnAdvanceJvmReset;

    [CompilerGenerated]
    [AccessedThroughProperty("TextAdvanceJvm")]
    private MyTextBox _TextAdvanceJvm;

    [CompilerGenerated]
    [AccessedThroughProperty("TextAdvanceGame")]
    private MyTextBox _TextAdvanceGame;

    [CompilerGenerated]
    [AccessedThroughProperty("TextAdvanceRun")]
    private MyTextBox _TextAdvanceRun;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckAdvanceRunWait")]
    private MyCheckBox _CheckAdvanceRunWait;

    [CompilerGenerated]
    [AccessedThroughProperty("PanAdvanceJava")]
    private Grid _PanAdvanceJava;

    [CompilerGenerated]
    [AccessedThroughProperty("ComboAdvanceJava")]
    private MyComboBox _ComboAdvanceJava;

    [CompilerGenerated]
    [AccessedThroughProperty("LabAdvanceJava")]
    private TextBlock _LabAdvanceJava;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAdvanceJavaSearch")]
    private MyIconButton _BtnAdvanceJavaSearch;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSwitch")]
    private MyExtraTextButton _BtnSwitch;

    private bool _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded;

    private StaticLocalInitFlag _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init;

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

    internal virtual MyComboBox ComboArgumentIndieV2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboArgumentIndieV2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = ComboArgumentIndie_SelectionChanged;
            MyComboBox myComboBox = _ComboArgumentIndieV2;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboArgumentIndieV2 = value;
            myComboBox = _ComboArgumentIndieV2;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual MyComboBox ComboArgumentVisibie_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboArgumentVisibie;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = ComboArgumentVisibie_SizeChanged;
            MyComboBox myComboBox = _ComboArgumentVisibie;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboArgumentVisibie = value;
            myComboBox = _ComboArgumentVisibie;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual Grid PanArgumentWindow_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanArgumentWindow;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanArgumentWindow = value;
        }
    }

    internal virtual MyComboBox ComboArgumentWindowType_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboArgumentWindowType;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SelectionChangedEventHandler value2 = (object a0, SelectionChangedEventArgs a1) =>
            {
                WindowTypeUIRefresh();
            };
            MyComboBox myComboBox = _ComboArgumentWindowType;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged -= value2;
            }
            _ComboArgumentWindowType = value;
            myComboBox = _ComboArgumentWindowType;
            if (myComboBox != null)
            {
                myComboBox.SelectionChanged += value2;
            }
        }
    }

    internal virtual MyTextBox TextArgumentWindowWidth_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextArgumentWindowWidth;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextArgumentWindowWidth = value;
        }
    }

    internal virtual TextBlock LabArgumentWindowMiddle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabArgumentWindowMiddle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabArgumentWindowMiddle = value;
        }
    }

    internal virtual MyTextBox TextArgumentWindowHeight_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextArgumentWindowHeight;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextArgumentWindowHeight = value;
        }
    }

    internal virtual MyRadioBox RadioRamType0_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioRamType0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                RefreshRam();
            };
            MyRadioBox myRadioBox = _RadioRamType0;
            if (myRadioBox != null)
            {
                myRadioBox.Check -= obj;
            }
            _RadioRamType0 = value;
            myRadioBox = _RadioRamType0;
            if (myRadioBox != null)
            {
                myRadioBox.Check += obj;
            }
        }
    }

    internal virtual MyRadioBox RadioRamType1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioRamType1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                RefreshRam();
            };
            MyRadioBox myRadioBox = _RadioRamType1;
            if (myRadioBox != null)
            {
                myRadioBox.Check -= obj;
            }
            _RadioRamType1 = value;
            myRadioBox = _RadioRamType1;
            if (myRadioBox != null)
            {
                myRadioBox.Check += obj;
            }
        }
    }

    internal virtual MySlider SliderRamCustom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SliderRamCustom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MySlider.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                RefreshRam();
            };
            MySlider mySlider = _SliderRamCustom;
            if (mySlider != null)
            {
                mySlider.Change -= obj;
            }
            _SliderRamCustom = value;
            mySlider = _SliderRamCustom;
            if (mySlider != null)
            {
                mySlider.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckArgumentRam_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckArgumentRam;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = (object a0, bool a1) =>
            {
                CheckArgumentRam_Change();
            };
            MyCheckBox myCheckBox = _CheckArgumentRam;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckArgumentRam = value;
            myCheckBox = _CheckArgumentRam;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual Grid PanRamDisplay_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanRamDisplay;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanRamDisplay = value;
        }
    }

    internal virtual ColumnDefinition ColumnRamUsed_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnRamUsed;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnRamUsed = value;
        }
    }

    internal virtual ColumnDefinition ColumnRamGame_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnRamGame;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnRamGame = value;
        }
    }

    internal virtual ColumnDefinition ColumnRamEmpty_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnRamEmpty;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnRamEmpty = value;
        }
    }

    internal virtual System.Windows.Shapes.Rectangle RectRamUsed_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RectRamUsed;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RectRamUsed = value;
        }
    }

    internal virtual System.Windows.Shapes.Rectangle RectRamGame_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RectRamGame;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SizeChangedEventHandler value2 = (object a0, SizeChangedEventArgs a1) =>
            {
                RefreshRamText();
            };
            System.Windows.Shapes.Rectangle rectangle = _RectRamGame;
            if (rectangle != null)
            {
                rectangle.SizeChanged -= value2;
            }
            _RectRamGame = value;
            rectangle = _RectRamGame;
            if (rectangle != null)
            {
                rectangle.SizeChanged += value2;
            }
        }
    }

    internal virtual System.Windows.Shapes.Rectangle RectRamEmpty_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RectRamEmpty;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SizeChangedEventHandler value2 = (object a0, SizeChangedEventArgs a1) =>
            {
                RefreshRamText();
            };
            System.Windows.Shapes.Rectangle rectangle = _RectRamEmpty;
            if (rectangle != null)
            {
                rectangle.SizeChanged -= value2;
            }
            _RectRamEmpty = value;
            rectangle = _RectRamEmpty;
            if (rectangle != null)
            {
                rectangle.SizeChanged += value2;
            }
        }
    }

    internal virtual TextBlock LabRamUsedTitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabRamUsedTitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabRamUsedTitle = value;
        }
    }

    internal virtual TextBlock LabRamGameTitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabRamGameTitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabRamGameTitle = value;
        }
    }

    internal virtual TextBlock LabRamUsed_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabRamUsed;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabRamUsed = value;
        }
    }

    internal virtual TextBlock LabRamTotal_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabRamTotal;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabRamTotal = value;
        }
    }

    internal virtual TextBlock LabRamGame_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabRamGame;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SizeChangedEventHandler value2 = (object a0, SizeChangedEventArgs a1) =>
            {
                RefreshRamText();
            };
            TextBlock textBlock = _LabRamGame;
            if (textBlock != null)
            {
                textBlock.SizeChanged -= value2;
            }
            _LabRamGame = value;
            textBlock = _LabRamGame;
            if (textBlock != null)
            {
                textBlock.SizeChanged += value2;
            }
        }
    }

    internal virtual MyCard CardSkin_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardSkin;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardSkin = value;
        }
    }

    internal virtual MyRadioBox RadioSkinType0_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioSkinType0;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioSkinType0 = value;
        }
    }

    internal virtual MyRadioBox RadioSkinType1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioSkinType1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioSkinType1 = value;
        }
    }

    internal virtual MyRadioBox RadioSkinType2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioSkinType2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioSkinType2 = value;
        }
    }

    internal virtual MyRadioBox RadioSkinType3_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioSkinType3;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _RadioSkinType3 = value;
        }
    }

    internal virtual MyRadioBox RadioSkinType4_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _RadioSkinType4;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioBox.PreviewCheckEventHandler obj = RadioSkinType3_Check;
            MyRadioBox myRadioBox = _RadioSkinType4;
            if (myRadioBox != null)
            {
                myRadioBox.PreviewCheck -= obj;
            }
            _RadioSkinType4 = value;
            myRadioBox = _RadioSkinType4;
            if (myRadioBox != null)
            {
                myRadioBox.PreviewCheck += obj;
            }
        }
    }

    internal virtual Grid PanSkinID_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanSkinID;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanSkinID = value;
        }
    }

    internal virtual MyButton BtnSkinSave_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSkinSave;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSkinSave_Click;
            MyButton myButton = _BtnSkinSave;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSkinSave = value;
            myButton = _BtnSkinSave;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnSkinCache_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSkinCache;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSkinCache_Click;
            MyButton myButton = _BtnSkinCache;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSkinCache = value;
            myButton = _BtnSkinCache;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual Grid PanSkinChange_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanSkinChange;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanSkinChange = value;
        }
    }

    internal virtual MyButton BtnSkinChange_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSkinChange;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSkinChange_Click;
            MyButton myButton = _BtnSkinChange;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSkinChange = value;
            myButton = _BtnSkinChange;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnSkinDelete_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSkinDelete;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnSkinDelete_Click;
            MyButton myButton = _BtnSkinDelete;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnSkinDelete = value;
            myButton = _BtnSkinDelete;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyIconButton BtnAdvanceJvmReset_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAdvanceJvmReset;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = BtnAdvanceJvmReset_Click;
            MyIconButton myIconButton = _BtnAdvanceJvmReset;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnAdvanceJvmReset = value;
            myIconButton = _BtnAdvanceJvmReset;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MyTextBox TextAdvanceJvm_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextAdvanceJvm;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            RoutedEventHandler value2 = (object a0, RoutedEventArgs a1) =>
            {
                TextAdvanceJvm_TextChanged();
            };
            TextChangedEventHandler value3 = (object a0, TextChangedEventArgs a1) =>
            {
                ReplaceEnter((MyTextBox)a0, a1);
            };
            MyTextBox myTextBox = _TextAdvanceJvm;
            if (myTextBox != null)
            {
                myTextBox.ValidatedTextChanged -= value2;
                myTextBox.TextChanged -= value3;
            }
            _TextAdvanceJvm = value;
            myTextBox = _TextAdvanceJvm;
            if (myTextBox != null)
            {
                myTextBox.ValidatedTextChanged += value2;
                myTextBox.TextChanged += value3;
            }
        }
    }

    internal virtual MyTextBox TextAdvanceGame_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextAdvanceGame;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            TextChangedEventHandler value2 = (object a0, TextChangedEventArgs a1) =>
            {
                ReplaceEnter((MyTextBox)a0, a1);
            };
            MyTextBox myTextBox = _TextAdvanceGame;
            if (myTextBox != null)
            {
                myTextBox.TextChanged -= value2;
            }
            _TextAdvanceGame = value;
            myTextBox = _TextAdvanceGame;
            if (myTextBox != null)
            {
                myTextBox.TextChanged += value2;
            }
        }
    }

    internal virtual MyTextBox TextAdvanceRun_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextAdvanceRun;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            TextChangedEventHandler value2 = TextAdvanceRun_TextChanged;
            MyTextBox myTextBox = _TextAdvanceRun;
            if (myTextBox != null)
            {
                myTextBox.TextChanged -= value2;
            }
            _TextAdvanceRun = value;
            myTextBox = _TextAdvanceRun;
            if (myTextBox != null)
            {
                myTextBox.TextChanged += value2;
            }
        }
    }

    internal virtual MyCheckBox CheckAdvanceRunWait_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckAdvanceRunWait;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckAdvanceRunWait = value;
        }
    }

    internal virtual Grid PanAdvanceJava_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanAdvanceJava;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanAdvanceJava = value;
        }
    }

    internal virtual MyComboBox ComboAdvanceJava_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ComboAdvanceJava;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ComboAdvanceJava = value;
        }
    }

    internal virtual TextBlock LabAdvanceJava_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabAdvanceJava;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabAdvanceJava = value;
        }
    }

    internal virtual MyIconButton BtnAdvanceJavaSearch_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAdvanceJavaSearch;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = (object a0, EventArgs a1) =>
            {
                BtnAdvanceJavaSearch_Click();
            };
            MyIconButton myIconButton = _BtnAdvanceJavaSearch;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnAdvanceJavaSearch = value;
            myIconButton = _BtnAdvanceJavaSearch;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MyExtraTextButton BtnSwitch_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSwitch;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyExtraTextButton.ClickEventHandler obj = BtnSwitch_Click;
            MyExtraTextButton myExtraTextButton = _BtnSwitch;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click -= obj;
            }
            _BtnSwitch = value;
            myExtraTextButton = _BtnSwitch;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click += obj;
            }
        }
    }

    public PageSetupLaunch()
    {
        Loaded += PageSetupLaunch_Loaded;
        RamTextLeft = 2;
        RamTextRight = 1;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToHome();
        RefreshRam(ShowAnim: false);
        BtnSwitch.Visibility = (((object)ModMinecraft.McInstanceSelected == null) ? Visibility.Collapsed : Visibility.Visible);
        checked
        {
            ModAnimation.AniControlEnabled++;
            Refresh();
            ModAnimation.AniControlEnabled--;
            if (_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init == null)
            {
                Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init, new StaticLocalInitFlag(), null);
            }
            bool lockTaken = false;
            try
            {
                Monitor.Enter(_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init, ref lockTaken);
                if (_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init.State == 0)
                {
                    _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init.State = 2;
                    _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded = false;
                }
                else if (_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init.State == 2)
                {
                    throw new IncompleteInitialization();
                }
            }
            finally
            {
                _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init.State = 1;
                if (lockTaken)
                {
                    Monitor.Exit(_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded_0024Init);
                }
            }
            if (!_0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded)
            {
                _0024STATIC_0024PageSetupLaunch_Loaded_002420211C128135_0024Reloaded = true;
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
                dispatcherTimer.Tick += (object a0, EventArgs a1) =>
                {
                    RefreshRam();
                };
                dispatcherTimer.Start();
            }
        }
    }

    public void Refresh()
    {
        try
        {
            SettingService.RefreshSettings(this);
            UpdateSkinType();
            UpdateRamType();
            UpdateJavaList();
        }
        catch (NullReferenceException ex)
        {
            ProjectData.SetProjectError(ex);
            NullReferenceException ex2 = ex;
            Logger.Error((Exception)ex2, "启动设置项存在异常，已被自动重置", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
            Reset();
            ProjectData.ClearProjectError();
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Error(ex4, "重载启动设置时出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Reset()
    {
        try
        {
            SettingService.ResetSettings(this);
            Settings.Set("LaunchArgumentIndieV2", Settings.GetDefault("LaunchArgumentIndieV2"));
            Configs.JavaList.Reset();
            Configs.JavaRemovedList.Reset();
            ((RedoableWorkerBase<NoType>)(object)ModJava.JavaListRefreshWorker).Start(default(CancellationToken), (ProgressProvider)null);
            ModMain.Hint("已初始化启动设置！", ModMain.HintType.Green);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "初始化启动设置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
            ProjectData.ClearProjectError();
        }
        Refresh();
    }

    private void BtnSkinChange_Click(object sender, EventArgs e)
    {
        ModMinecraft.McSkinInfo skinInfo = ModMinecraft.McSkinSelect();
        if (skinInfo.IsVaild)
        {
            ChangeSkin(skinInfo);
        }
    }

    private void RadioSkinType3_Check(object sender, ModBase.RouteEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0 && e.RaiseByMouse && !FileUtils.Exists(Paths.AppDataThenName + "CustomSkin.png"))
        {
            ModMinecraft.McSkinInfo skinInfo = ModMinecraft.McSkinSelect();
            if (!skinInfo.IsVaild)
            {
                e.Handled = true;
            }
            else if (!ChangeSkin(skinInfo))
            {
                e.Handled = true;
            }
        }
    }

    private bool ChangeSkin(ModMinecraft.McSkinInfo SkinInfo)
    {
        bool result;
        try
        {
            FileUtils.Copy(SkinInfo.LocalFile, Paths.AppDataThenName + "CustomSkin.png");
            MyBitmap myBitmap = new MyBitmap(Paths.AppDataThenName + "CustomSkin.png");
            if (myBitmap.Pic.Width == 64 && myBitmap.Pic.Height == 32)
            {
                System.Drawing.Image image = myBitmap;
                Bitmap bitmap = new Bitmap(64, 64);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImageUnscaled(image, new System.Drawing.Point(0, 0));
                }
                FileUtils.Delete(Paths.AppDataThenName + "CustomSkin.png", false);
                bitmap.Save(Paths.AppDataThenName + "CustomSkin.png");
            }
            Settings.Set("LaunchSkinSlim", SkinInfo.IsSlim);
            result = true;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "改变离线皮肤失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
            result = false;
            ProjectData.ClearProjectError();
        }
        finally
        {
            PageLaunchLeft.SkinLegacy.Start(null, IsForceRestart: true);
        }
        return result;
    }

    private void BtnSkinDelete_Click(object sender, EventArgs e)
    {
        try
        {
            FileUtils.Delete(Paths.AppDataThenName + "CustomSkin.png", false);
            RadioSkinType0.SetChecked(value: true, user: true);
            ModMain.Hint("离线皮肤已清空！", ModMain.HintType.Green);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "清空离线皮肤失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void BtnSkinSave_Click(object sender, EventArgs e)
    {
        MySkin.Save(PageLaunchLeft.SkinLegacy);
    }

    private void BtnSkinCache_Click(object sender, EventArgs e)
    {
        MySkin.RefreshCache();
    }

    public static void UpdateSkinType()
    {
        PageLaunchLeft.SkinLegacy.Start();
        if (ModMain.FrmSetupLaunch != null)
        {
            switch (Settings.Get<int>("LaunchSkinType"))
            {
                case 0:
                case 1:
                case 2:
                    ModMain.FrmSetupLaunch.PanSkinID.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupLaunch.PanSkinChange.Visibility = Visibility.Collapsed;
                    break;
                case 3:
                    ModMain.FrmSetupLaunch.PanSkinID.Visibility = Visibility.Visible;
                    ModMain.FrmSetupLaunch.PanSkinChange.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    ModMain.FrmSetupLaunch.PanSkinID.Visibility = Visibility.Collapsed;
                    ModMain.FrmSetupLaunch.PanSkinChange.Visibility = Visibility.Visible;
                    break;
            }
            ModMain.FrmSetupLaunch.CardSkin.TriggerForceResize();
        }
    }

    public static void UpdateRamType()
    {
        if (ModMain.FrmSetupLaunch?.SliderRamCustom != null)
        {
            ModMain.FrmSetupLaunch.SliderRamCustom.IsEnabled = Settings.Get<int>("LaunchRamType") == 1;
        }
    }

    public void RefreshRam(bool ShowAnim)
    {
        checked
        {
            if (LabRamGame != null && LabRamUsed != null && !(ModMain.FrmMain.PageCurrent != FormMain.PageType.Setup) && ModMain.FrmSetupLeft.PageID == FormMain.PageSubType.Default)
            {
                double num = Math.Round(GetRam(ModMinecraft.McInstanceSelected, UseVersionJavaSetup: false), 5);
                double num2 = Math.Round((double)MyWpfExtension.Computer.Info.TotalPhysicalMemory / 1024.0 / 1024.0 / 1024.0, 1);
                double num3 = Math.Round((double)MyWpfExtension.Computer.Info.AvailablePhysicalMemory / 1024.0 / 1024.0 / 1024.0, 1);
                double num4 = Math.Round(Math.Min(num, num3), 5);
                double num5 = Math.Round(num2 - num3, 5);
                double num6 = Math.Round(MathUtils.Clamp<double>(num2 - num5 - num, 0.0, 1000.0), 1);
                if (num2 <= 1.5)
                {
                    SliderRamCustom.MaxValue = (int)Math.Round(Math.Max(Math.Floor((num2 - 0.3) / 0.1), 1.0));
                }
                else if (num2 <= 8.0)
                {
                    SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 1.5) / 0.5) + 12.0);
                }
                else if (num2 <= 16.0)
                {
                    SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 8.0) / 1.0) + 25.0);
                }
                else
                {
                    SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 16.0) / 2.0) + 33.0);
                }
                LabRamGame.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((num == Math.Floor(num)) ? (Conversions.ToString(num) + ".0") : ((object)num), " GB"), (num != num4) ? Operators.ConcatenateObject(Operators.ConcatenateObject(" (可用 ", (num4 == Math.Floor(num4)) ? (Conversions.ToString(num4) + ".0") : ((object)num4)), " GB)") : ""));
                LabRamUsed.Text = Conversions.ToString(Operators.ConcatenateObject((num5 == Math.Floor(num5)) ? (Conversions.ToString(num5) + ".0") : ((object)num5), " GB"));
                LabRamTotal.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(" / ", (num2 == Math.Floor(num2)) ? (Conversions.ToString(num2) + ".0") : ((object)num2)), " GB"));
                if (ShowAnim)
                {
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                        ModAnimation.AaGridLengthWidth(ColumnRamUsed, num5 - ColumnRamUsed.Width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
                        ModAnimation.AaGridLengthWidth(ColumnRamGame, num4 - ColumnRamGame.Width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
                        ModAnimation.AaGridLengthWidth(ColumnRamEmpty, num6 - ColumnRamEmpty.Width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong))
                    }, "SetupLaunch Ram Grid");
                }
                else
                {
                    ColumnRamUsed.Width = new GridLength(num5, GridUnitType.Star);
                    ColumnRamGame.Width = new GridLength(num4, GridUnitType.Star);
                    ColumnRamEmpty.Width = new GridLength(num6, GridUnitType.Star);
                }
            }
        }
    }

    private void RefreshRam()
    {
        RefreshRam(ShowAnim: true);
    }

    private void RefreshRamText()
    {
        double actualWidth = RectRamUsed.ActualWidth;
        double actualWidth2 = PanRamDisplay.ActualWidth;
        double actualWidth3 = LabRamGame.ActualWidth;
        double actualWidth4 = LabRamUsed.ActualWidth;
        double actualWidth5 = LabRamTotal.ActualWidth;
        double actualWidth6 = LabRamGameTitle.ActualWidth;
        double actualWidth7 = LabRamUsedTitle.ActualWidth;
        int num = ((!(actualWidth - 30.0 < actualWidth4) && !(actualWidth - 30.0 < actualWidth7)) ? ((actualWidth - 25.0 < actualWidth4 + actualWidth5) ? 1 : 2) : 0);
        if (RamTextLeft != num)
        {
            RamTextLeft = num;
            switch (num)
            {
                case 0:
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                    ModAnimation.AaOpacity(LabRamUsed, 0.0 - LabRamUsed.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamTotal, 0.0 - LabRamTotal.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamUsedTitle, 0.0 - LabRamUsedTitle.Opacity, 100)
                    }, "SetupLaunch Ram TextLeft");
                    break;
                case 1:
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                    ModAnimation.AaOpacity(LabRamUsed, 1.0 - LabRamUsed.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamTotal, 0.0 - LabRamTotal.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - LabRamUsedTitle.Opacity, 100)
                    }, "SetupLaunch Ram TextLeft");
                    break;
                case 2:
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                    ModAnimation.AaOpacity(LabRamUsed, 1.0 - LabRamUsed.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamTotal, 1.0 - LabRamTotal.Opacity, 100),
                    ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - LabRamUsedTitle.Opacity, 100)
                    }, "SetupLaunch Ram TextLeft");
                    break;
            }
        }
        int num2 = ((!(actualWidth2 < actualWidth3 + 2.0 + actualWidth) && !(actualWidth2 < actualWidth6 + 2.0 + actualWidth)) ? 1 : 0);
        if (num2 == 0)
        {
            if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("SetupLaunch Ram TextRight")))
            {
                ModAnimation.AniStart(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaX(LabRamGame, actualWidth2 - actualWidth3 - LabRamGame.Margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
                    ModAnimation.AaX(LabRamGameTitle, actualWidth2 - actualWidth6 - LabRamGameTitle.Margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
                }, "SetupLaunch Ram TextRight");
            }
            else
            {
                ModAnimation.AniStop("SetupLaunch Ram TextRight");
                LabRamGame.Margin = new Thickness(actualWidth2 - actualWidth3, 3.0, 0.0, 0.0);
                LabRamGameTitle.Margin = new Thickness(actualWidth2 - actualWidth6, 0.0, 0.0, 5.0);
            }
        }
        else if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("SetupLaunch Ram TextRight")))
        {
            ModAnimation.AniStart(new ModAnimation.AniData[2]
            {
                ModAnimation.AaX(LabRamGame, 2.0 + actualWidth - LabRamGame.Margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
                ModAnimation.AaX(LabRamGameTitle, 2.0 + actualWidth - LabRamGameTitle.Margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
            }, "SetupLaunch Ram TextRight");
        }
        else
        {
            ModAnimation.AniStop("SetupLaunch Ram TextRight");
            LabRamGame.Margin = new Thickness(2.0 + actualWidth, 3.0, 0.0, 0.0);
            LabRamGameTitle.Margin = new Thickness(2.0 + actualWidth, 0.0, 0.0, 5.0);
        }
        RamTextRight = num2;
    }

    public static double GetRam(ModMinecraft.McInstance Instance, bool UseVersionJavaSetup)
    {
        if (Settings.Get<int>("LaunchRamType") == 0)
        {
            double num = Math.Round((double)MyWpfExtension.Computer.Info.AvailablePhysicalMemory / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0;
            if ((object)Instance != null && !Instance.IsLoaded)
            {
                Instance.Load();
            }
            double val;
            double num3;
            double num4;
            double num5;
            if ((object)Instance != null && Instance.Modable)
            {
                DirectoryInfo info = DirectoryUtils.GetInfo(Instance.PathIndie + "mods\\");
                int num2 = (info.Exists ? info.GetFiles().Count((FileInfo f) => new string[3] { ".jar", ".zip", ".litemod" }.Contains(StringExtensions.Lower(f.Extension))) : 0);
                val = 0.5 + (double)num2 / 150.0;
                num3 = 1.5 + (double)num2 / 90.0;
                num4 = 2.7 + (double)num2 / 50.0;
                num5 = 4.5 + (double)num2 / 25.0;
            }
            else if ((object)Instance != null && Instance.Version.HasOptiFine)
            {
                val = 0.5;
                num3 = 1.5;
                num4 = 3.0;
                num5 = 5.0;
            }
            else
            {
                val = 0.5;
                num3 = 1.5;
                num4 = 2.5;
                num5 = 4.0;
            }
            double num6 = num3;
            double num7 = Math.Min(num, num6);
            num -= num6;
            if (!(num < 0.1))
            {
                num6 = num4 - num3;
                num7 += Math.Min(num * 0.7, num6);
                num -= num6 / 0.7;
                if (!(num < 0.1))
                {
                    num6 = num5 - num4;
                    num7 += Math.Min(num * 0.4, num6);
                    num -= num6 / 0.4;
                    if (!(num < 0.1))
                    {
                        num6 = num5;
                        num7 += Math.Min(num * 0.15, num6);
                        num -= num6 / 0.15;
                        _ = 0.1;
                    }
                }
            }
            return Math.Round(Math.Max(num7, val), 1);
        }
        int num8 = Settings.Get<int>("LaunchRamCustom");
        if (num8 <= 12)
        {
            return (double)num8 * 0.1 + 0.3;
        }
        checked
        {
            if (num8 <= 25)
            {
                return (double)(num8 - 12) * 0.5 + 1.5;
            }
            if (num8 <= 33)
            {
                return (num8 - 25) * 1 + 8;
            }
            return (num8 - 33) * 2 + 16;
        }
    }

    public void UpdateJavaList()
    {
        if (ComboAdvanceJava == null || LabAdvanceJava == null || !ComboAdvanceJava.IsLoaded)
        {
            return;
        }
        ComboAdvanceJava.Items.Clear();
        if (((RedoableWorkerBase<NoType>)(object)ModJava.JavaListRefreshWorker).Running)
        {
            BtnAdvanceJavaSearch.IsEnabled = false;
            ComboAdvanceJava.IsEnabled = false;
            LabAdvanceJava.Text = "搜索中\u200a…";
            return;
        }
        BtnAdvanceJavaSearch.IsEnabled = true;
        ComboAdvanceJava.IsEnabled = true;
        int count = Configs.JavaList.Get().Count;
        LabAdvanceJava.Text = ((count > 0) ? $"共有 {count} 个 Java\u200a…" : "未找到 Java，点击以导入已有的 Java");
        checked
        {
            try
            {
                ConcurrentList<Java> val = Configs.JavaList.Get();
                int num = val.Count - 1;
                _Closure_0024__18_002D0 obj = default;
                for (int i = 0; i <= num; i++)
                {
                    obj = new _Closure_0024__18_002D0(obj);
                    obj._0024VB_0024Me = this;
                    obj._0024VB_0024Local_JavaEntry = val[i];
                    MyListItem myListItem = new MyListItem
                    {
                        FontSize = 13.0,
                        Height = 24.0,
                        IsScaleAnimationEnabled = false,
                        Type = MyListItem.CheckType.Clickable,
                        Tag = obj._0024VB_0024Local_JavaEntry,
                        Title = obj._0024VB_0024Local_JavaEntry.ToString()
                    };
                    myListItem.MouseLeftButtonUp += ((_Closure_0024__._0024I18_002D0 == null) ? (_Closure_0024__._0024I18_002D0 = (object sender, MouseButtonEventArgs e) =>
                    {
                        e.Handled = true;
                    }) : _Closure_0024__._0024I18_002D0);
                    myListItem.Click += ((_Closure_0024__._0024IR18_002D2 == null) ? (_Closure_0024__._0024IR18_002D2 = (object a0, System.Windows.Input.MouseButtonEventArgs a1) =>
                    {
                        ModMain.Hint("点击选项右侧的箭头可以进行排序，以控制 PCL 优先选择哪个 Java！");
                    }) : _Closure_0024__._0024IR18_002D2);
                    ComboAdvanceJava.Items.Add(myListItem);
                    List<MyIconButton> list = new List<MyIconButton>();
                    MyIconButton myIconButton = new MyIconButton
                    {
                        Logo = "M554 333V853h-85V333l-228 228-60-60L512 170l331 331-60 60L554 333z",
                        LogoScale = 0.95,
                        Height = 24.0,
                        Width = 24.0
                    };
                    myIconButton.IsEnabled = i > 0;
                    myIconButton.ToolTip = "提高优先级";
                    ToolTipService.SetShowOnDisabled(myIconButton, value: true);
                    myIconButton.Click += obj._Lambda_0024__R3;
                    list.Add(myIconButton);
                    MyIconButton myIconButton2 = new MyIconButton
                    {
                        Logo = "M554 691V171h-85V691L241 463l-60 60L512 854l331-331-60-60L554 691z",
                        LogoScale = 0.95,
                        Height = 24.0,
                        Width = 24.0
                    };
                    myIconButton2.IsEnabled = i < val.Count - 1;
                    myIconButton2.ToolTip = "降低优先级";
                    ToolTipService.SetShowOnDisabled(myIconButton2, value: true);
                    myIconButton2.Click += obj._Lambda_0024__R4;
                    list.Add(myIconButton2);
                    bool flag = StringExtensions.StartsWithF(obj._0024VB_0024Local_JavaEntry.Folder, $"{Paths.AppData}.minecraft\\runtime\\", false);
                    MyIconButton myIconButton3 = new MyIconButton
                    {
                        Logo = "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z",
                        Height = 24.0,
                        Width = 24.0
                    };
                    myIconButton3.IsEnabled = !flag;
                    myIconButton3.ToolTip = (myIconButton3.IsEnabled ? "从列表中移除" : "无法移除官方 Java");
                    myIconButton3.Click += obj._Lambda_0024__R5;
                    ToolTipService.SetShowOnDisabled(myIconButton3, value: true);
                    list.Add(myIconButton3);
                    MyIconButton myIconButton4 = new MyIconButton
                    {
                        Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z",
                        LogoScale = 1.1,
                        Height = 24.0,
                        Width = 24.0
                    };
                    myIconButton4.ToolTip = "打开文件夹";
                    myIconButton4.Click += obj._Lambda_0024__R6;
                    list.Add(myIconButton4);
                    myListItem.Buttons = list;
                }
                MyListItem myListItem2 = new MyListItem
                {
                    FontSize = 13.0,
                    Height = 24.0,
                    IsScaleAnimationEnabled = false,
                    Title = "导入电脑中已有的 Java…",
                    Type = MyListItem.CheckType.Clickable
                };
                myListItem2.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) =>
                {
                    e.Handled = true;
                    ModJava.ManuallyImportJava();
                };
                ComboAdvanceJava.Items.Add(myListItem2);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "更新 Java 列表下拉框失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLaunch.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    private void MoveJavaInList(Java JavaEntry, int Offset)
    {
        Configs.JavaList.Edit((MeloongCore.ConfigEntry<ConcurrentList<Java>>.RefAction)((ref ConcurrentList<Java> List) =>
        {
            int num = List.IndexOf(JavaEntry);
            int num2 = checked(num + Offset);
            if (num >= 0 && num2 >= 0 && num2 < List.Count)
            {
                List.RemoveAt(num);
                List.Insert(num2, JavaEntry);
            }
        }));
        ModJava.UpdateJavaLists();
    }

    private void BtnAdvanceJavaSearch_Click()
    {
        ModJava.ManuallySearchJava();
    }

    private void WindowTypeUIRefresh()
    {
        Visibility visibility = ModBase.ToVisibility(ComboArgumentWindowType.SelectedIndex == 3);
        TextArgumentWindowHeight.Visibility = visibility;
        LabArgumentWindowMiddle.Visibility = visibility;
        TextArgumentWindowWidth.Visibility = visibility;
    }

    private void ComboArgumentVisibie_SizeChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0 && ComboArgumentVisibie.SelectedIndex == 0 && ModMain.MyMsgBox("若在游戏启动后立即关闭启动器，崩溃检测、更改游戏标题等功能将失效。\r\n如果想保留这些功能，可以选择让启动器在游戏启动后隐藏，游戏退出后自动关闭。", "提醒", "继续", "取消") == 2 && e.RemovedItems.Count > 0)
        {
            ComboArgumentVisibie.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
        }
    }

    private void CheckArgumentRam_Change()
    {
        if (ModAnimation.AniControlEnabled == 0 && CheckArgumentRam.Checked && ModMain.MyMsgBox("内存优化会显著延长启动耗时，建议仅在内存不足时开启。\r\n如果你在使用机械硬盘，这还可能导致一小段时间的严重卡顿。" + (WindowsUtils.HasAdminRole() ? "" : string.Format("{0}{1}每次启动游戏，PCL 都需要申请管理员权限以进行内存优化。{2}若想自动授予权限，可以右键 PCL，打开 属性 → 兼容性 → 以管理员身份运行此程序。", "\r\n", "\r\n", "\r\n")), "提醒", "确定", "取消") == 2)
        {
            CheckArgumentRam.Checked = false;
        }
    }

    private void ComboArgumentIndie_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ModAnimation.AniControlEnabled == 0)
        {
            ModMain.MyMsgBox("本设置仅会对之后新安装的版本生效。\r\n如果要修改已安装的版本的隔离方式，请在它的版本独立设置中调整。");
        }
    }

    private void TextAdvanceRun_TextChanged(object sender, TextChangedEventArgs e)
    {
        CheckAdvanceRunWait.Visibility = ((Operators.CompareString(TextAdvanceRun.Text, "", TextCompare: false) == 0) ? Visibility.Collapsed : Visibility.Visible);
    }

    private void TextAdvanceJvm_TextChanged()
    {
        BtnAdvanceJvmReset.Visibility = ((Operators.CompareString(TextAdvanceJvm.Text, Settings.GetDefault("LaunchAdvanceJvm"), TextCompare: false) == 0) ? Visibility.Hidden : Visibility.Visible);
    }

    private void BtnAdvanceJvmReset_Click(object sender, EventArgs e)
    {
        Settings.Reset("LaunchAdvanceJvm");
        Refresh();
    }

    private void ReplaceEnter(MyTextBox sender, TextChangedEventArgs e)
    {
        string text = StringExtensions.ReplaceLineEndings(sender.Text, " ", true);
        if (Operators.CompareString(text, sender.Text, TextCompare: false) != 0)
        {
            int caretIndex = sender.CaretIndex;
            sender.Text = text;
            sender.CaretIndex = Math.Max(0, checked(caretIndex - 1));
        }
    }

    private void BtnSwitch_Click(object sender, MouseButtonEventArgs e)
    {
        ModMinecraft.McInstanceSelected.Load();
        PageInstanceLeft.Instance = ModMinecraft.McInstanceSelected;
        ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup, FormMain.PageSubType.SetupLink);
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnAdvanceJavaSearch_WithEvents = BtnAdvanceJavaSearch;
        BtnAdvanceJvmReset_WithEvents = BtnAdvanceJvmReset;
        BtnSkinCache_WithEvents = BtnSkinCache;
        BtnSkinChange_WithEvents = BtnSkinChange;
        BtnSkinDelete_WithEvents = BtnSkinDelete;
        BtnSkinSave_WithEvents = BtnSkinSave;
        BtnSwitch_WithEvents = BtnSwitch;
        CardArgument_WithEvents = CardArgument;
        CardSkin_WithEvents = CardSkin;
        CheckAdvanceRunWait_WithEvents = CheckAdvanceRunWait;
        CheckArgumentRam_WithEvents = CheckArgumentRam;
        ColumnRamEmpty_WithEvents = ColumnRamEmpty;
        ColumnRamGame_WithEvents = ColumnRamGame;
        ColumnRamUsed_WithEvents = ColumnRamUsed;
        ComboAdvanceJava_WithEvents = ComboAdvanceJava;
        ComboArgumentIndieV2_WithEvents = ComboArgumentIndieV2;
        ComboArgumentVisibie_WithEvents = ComboArgumentVisibie;
        ComboArgumentWindowType_WithEvents = ComboArgumentWindowType;
        LabAdvanceJava_WithEvents = LabAdvanceJava;
        LabArgumentWindowMiddle_WithEvents = LabArgumentWindowMiddle;
        LabRamGame_WithEvents = LabRamGame;
        LabRamGameTitle_WithEvents = LabRamGameTitle;
        LabRamTotal_WithEvents = LabRamTotal;
        LabRamUsed_WithEvents = LabRamUsed;
        LabRamUsedTitle_WithEvents = LabRamUsedTitle;
        PanAdvanceJava_WithEvents = PanAdvanceJava;
        PanArgumentWindow_WithEvents = PanArgumentWindow;
        PanBack_WithEvents = PanBack;
        PanMain_WithEvents = PanMain;
        PanRamDisplay_WithEvents = PanRamDisplay;
        PanSkinChange_WithEvents = PanSkinChange;
        PanSkinID_WithEvents = PanSkinID;
        RadioRamType0_WithEvents = RadioRamType0;
        RadioRamType1_WithEvents = RadioRamType1;
        RadioSkinType0_WithEvents = RadioSkinType0;
        RadioSkinType1_WithEvents = RadioSkinType1;
        RadioSkinType2_WithEvents = RadioSkinType2;
        RadioSkinType3_WithEvents = RadioSkinType3;
        RadioSkinType4_WithEvents = RadioSkinType4;
        RectRamEmpty_WithEvents = RectRamEmpty;
        RectRamGame_WithEvents = RectRamGame;
        RectRamUsed_WithEvents = RectRamUsed;
        SliderRamCustom_WithEvents = SliderRamCustom;
        TextAdvanceGame_WithEvents = TextAdvanceGame;
        TextAdvanceJvm_WithEvents = TextAdvanceJvm;
        TextAdvanceRun_WithEvents = TextAdvanceRun;
        TextArgumentWindowHeight_WithEvents = TextArgumentWindowHeight;
        TextArgumentWindowWidth_WithEvents = TextArgumentWindowWidth;
    }
}

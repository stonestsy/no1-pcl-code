using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class MyMsgSelect : Grid, IComponentConnector
{
    private readonly ModMain.MyMsgBoxConverter MyConverter;

    private readonly int Uuid;

    private int SelectedIndex;

    [CompilerGenerated]
    [AccessedThroughProperty("TransformRotate")]
    private RotateTransform _TransformRotate;

    [CompilerGenerated]
    [AccessedThroughProperty("TransformPos")]
    private TranslateTransform _TransformPos;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBorder")]
    private Border _PanBorder;

    [CompilerGenerated]
    [AccessedThroughProperty("EffectShadow")]
    private DropShadowEffect _EffectShadow;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private Grid _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("LabTitle")]
    private TextBlock _LabTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("ShapeLine")]
    private Rectangle _ShapeLine;

    [CompilerGenerated]
    [AccessedThroughProperty("PanCaption")]
    private MyScrollViewer _PanCaption;

    [CompilerGenerated]
    [AccessedThroughProperty("PanSelection")]
    private StackPanel _PanSelection;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBtn")]
    private StackPanel _PanBtn;

    [CompilerGenerated]
    [AccessedThroughProperty("Btn1")]
    private MyButton _Btn1;

    [CompilerGenerated]
    [AccessedThroughProperty("Btn2")]
    private MyButton _Btn2;

    internal virtual RotateTransform TransformRotate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TransformRotate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TransformRotate = value;
        }
    }

    internal virtual TranslateTransform TransformPos_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TransformPos;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TransformPos = value;
        }
    }

    internal virtual Border PanBorder_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBorder;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = Drag;
            Border border = _PanBorder;
            if (border != null)
            {
                border.MouseLeftButtonDown -= value2;
            }
            _PanBorder = value;
            border = _PanBorder;
            if (border != null)
            {
                border.MouseLeftButtonDown += value2;
            }
        }
    }

    internal virtual DropShadowEffect EffectShadow_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _EffectShadow;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _EffectShadow = value;
        }
    }

    internal virtual Grid PanMain_WithEvents
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

    internal virtual TextBlock LabTitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabTitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = Drag;
            TextBlock textBlock = _LabTitle;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonDown -= value2;
            }
            _LabTitle = value;
            textBlock = _LabTitle;
            if (textBlock != null)
            {
                textBlock.MouseLeftButtonDown += value2;
            }
        }
    }

    internal virtual Rectangle ShapeLine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ShapeLine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ShapeLine = value;
        }
    }

    internal virtual MyScrollViewer PanCaption_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanCaption;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanCaption = value;
        }
    }

    internal virtual StackPanel PanSelection_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanSelection;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanSelection = value;
        }
    }

    internal virtual StackPanel PanBtn_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanBtn;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanBtn = value;
        }
    }

    public virtual MyButton Btn1_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Btn1;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                Btn1_Click();
            };
            MyButton myButton = _Btn1;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _Btn1 = value;
            myButton = _Btn1;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    public virtual MyButton Btn2_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Btn2;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                Btn2_Click();
            };
            MyButton myButton = _Btn2;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _Btn2 = value;
            myButton = _Btn2;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    public MyMsgSelect(ModMain.MyMsgBoxConverter Converter)
    {
        Loaded += Load;
        Uuid = ModBase.GetUuid();
        SelectedIndex = -1;
        try
        {
            InitializeComponent();
            _InitWithEvents();
            Btn1.Name += Conversions.ToString(ModBase.GetUuid());
            Btn2.Name += Conversions.ToString(ModBase.GetUuid());
            MyConverter = Converter;
            LabTitle.Text = Converter.Title;
            Btn1.Text = Converter.Button1;
            if (Converter.IsWarn)
            {
                Btn1.ColorType = MyButton.ColorState.Red;
                LabTitle.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrushRedLight");
            }
            Btn2.Text = Converter.Button2;
            Btn2.Visibility = ((Operators.CompareString(Converter.Button2, "", TextCompare: false) == 0) ? Visibility.Collapsed : Visibility.Visible);
            ShapeLine.StrokeThickness = ModBase.GetWPFSize(1.0);
            Btn1.IsEnabled = false;
            foreach (object item in (IEnumerable)Converter.Content)
            {
                IMyRadio myRadio = (IMyRadio)MyVirtualizingElement.TryInit((FrameworkElement)RuntimeHelpers.GetObjectValue(item));
                PanSelection.Children.Add((UIElement)myRadio);
                myRadio.Check += (object a0, ModBase.RouteEventArgs a1) =>
                {
                    OnChecked((IMyRadio)a0, a1);
                };
                if (myRadio is MyListItem)
                {
                    ((MyListItem)myRadio).Type = MyListItem.CheckType.RadioBox;
                    ((MyListItem)myRadio).MinHeight = 24.0;
                }
                else
                {
                    ((MyRadioBox)myRadio).MinHeight = 24.0;
                }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "选择弹窗初始化失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void Load(object sender, EventArgs e)
    {
        try
        {
            if (Btn2.IsVisible && Btn1.ColorType != MyButton.ColorState.Red)
            {
                Btn1.ColorType = MyButton.ColorState.Highlight;
            }
            Opacity = 0.0;
            ModAnimation.AniStart(ModAnimation.AaColor(ModMain.FrmMain.PanMsg, Panel.BackgroundProperty, (MyConverter.IsWarn ? new ModBase.MyColor(140.0, 80.0, 0.0, 0.0) : new ModBase.MyColor(90.0, 0.0, 0.0, 0.0)) - ModMain.FrmMain.PanMsg.Background, 200), "PanMsg Background");
            ModAnimation.AniStart(new ModAnimation.AniData[3]
            {
                ModAnimation.AaOpacity(this, 1.0, 120, 60),
                ModAnimation.AaDouble((object i) =>
                {
                    TranslateTransform transformPos;
                    (transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject(transformPos.Y, i));
                }, 0.0 - TransformPos.Y, 300, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
                ModAnimation.AaDouble((object i) =>
                {
                    RotateTransform transformRotate;
                    (transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject(transformRotate.Angle, i));
                }, 0.0 - TransformRotate.Angle, 300, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
            }, "MyMsgBox " + Conversions.ToString(Uuid));
            Logger.Info($"选择弹窗：{LabTitle.Text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "选择弹窗加载失败", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void Close()
    {
        MyConverter.WaitFrame.Continue = false;
        ComponentDispatcher.PopModal();
        ModAnimation.AniStart(new ModAnimation.AniData[5]
        {
            ModAnimation.AaCode(() =>
            {
                if (!ModMain.WaitingMyMsgBox.Any())
                {
                    ModAnimation.AniStart(ModAnimation.AaColor(ModMain.FrmMain.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ModMain.FrmMain.PanMsg.Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
                }
            }, 30),
            ModAnimation.AaOpacity(this, 0.0 - Opacity, 80, 20),
            ModAnimation.AaDouble((object i) =>
            {
                TranslateTransform transformPos;
                (transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject(transformPos.Y, i));
            }, 20.0 - TransformPos.Y, 150, 0, new ModAnimation.AniEaseOutFluent()),
            ModAnimation.AaDouble((object i) =>
            {
                RotateTransform transformRotate;
                (transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject(transformRotate.Angle, i));
            }, 6.0 - TransformRotate.Angle, 150, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
            ModAnimation.AaCode(() =>
            {
                ((Grid)Parent).Children.Remove(this);
            }, 0, After: true)
        }, "MyMsgBox " + Conversions.ToString(Uuid));
    }

    public void Btn1_Click()
    {
        if (!MyConverter.IsExited && SelectedIndex != -1)
        {
            MyConverter.IsExited = true;
            MyConverter.Result = SelectedIndex;
            Close();
        }
    }

    public void Btn2_Click()
    {
        if (!MyConverter.IsExited)
        {
            MyConverter.IsExited = true;
            MyConverter.Result = null;
            Close();
        }
    }

    private void OnChecked(IMyRadio sender, EventArgs e)
    {
        Btn1.IsEnabled = true;
        SelectedIndex = PanSelection.Children.IndexOf((UIElement)sender);
    }

    private void Drag(object sender, MouseButtonEventArgs e)
    {
        int try0000_dispatch = -1;
        int num3 = default;
        int num = default;
        int num2 = default;
        while (true)
        {
            try
            {
                switch (try0000_dispatch)
                {
                    default:
                        ProjectData.ClearProjectError();
                        num3 = 1;
                        goto IL_0007;
                    case 86:
                        {
                            num = num2;
                            switch (num3)
                            {
                                case 1:
                                    break;
                                default:
                                    goto end_IL_0000;
                            }
                            int num4 = num + 1;
                            num = 0;
                            switch (num4)
                            {
                                case 1:
                                    break;
                                case 2:
                                    goto IL_0007;
                                case 3:
                                    goto end_IL_0000_2;
                                default:
                                    goto end_IL_0000;
                                case 4:
                                    goto end_IL_0000_3;
                            }
                            goto default;
                        }
                    IL_0007:
                        num2 = 2;
                        if (!(e.GetPosition(ShapeLine).Y <= 2.0))
                        {
                            goto end_IL_0000_3;
                        }
                        break;
                    end_IL_0000_2:
                        break;
                }
                num2 = 3;
                ModMain.FrmMain.DragMove();
                break;
            end_IL_0000:;
            }
            catch (Exception ex) when ((num3 != 0) & (num == 0))
            {
                ProjectData.SetProjectError(ex);
                try0000_dispatch = 86;
                continue;
            }
            throw ProjectData.CreateProjectError(-2146828237);
            continue;
        end_IL_0000_3:
            break;
        }
        if (num != 0)
        {
            ProjectData.ClearProjectError();
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        Btn1_WithEvents = Btn1;
        Btn2_WithEvents = Btn2;
        EffectShadow_WithEvents = EffectShadow;
        LabTitle_WithEvents = LabTitle;
        PanBorder_WithEvents = PanBorder;
        PanBtn_WithEvents = PanBtn;
        PanCaption_WithEvents = PanCaption;
        PanMain_WithEvents = PanMain;
        PanSelection_WithEvents = PanSelection;
        ShapeLine_WithEvents = ShapeLine;
        TransformPos_WithEvents = TransformPos;
        TransformRotate_WithEvents = TransformRotate;
    }
}

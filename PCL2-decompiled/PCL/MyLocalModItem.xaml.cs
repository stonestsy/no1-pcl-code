using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class MyLocalModItem : Grid, IComponentConnector
{
    public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

    public delegate void CheckEventHandler(object sender, ModBase.RouteEventArgs e);

    public delegate void ChangedEventHandler(object sender, ModBase.RouteEventArgs e);

    public int Uuid;

    private string _Title;

    private bool IsMouseDown;

    private static int SwipeStart;

    private static int SwipeEnd;

    private static bool _Swiping = false;

    private static bool SwipToState;

    private bool _Checked;

    private Image ImgState;

    private Border _RectBack;

    public Action<MyLocalModItem, EventArgs> ButtonHandler;

    public FrameworkElement ButtonStack;

    private IEnumerable<MyIconButton> _Buttons;

    private Border _RectCheck;

    private bool HasEnteredViewport;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyLocalModItem _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnPaddingRight")]
    private ColumnDefinition _ColumnPaddingRight;

    [CompilerGenerated]
    [AccessedThroughProperty("PathLogo")]
    private MyImage _PathLogo;

    [CompilerGenerated]
    [AccessedThroughProperty("PanTitle")]
    private Grid _PanTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnTitle")]
    private ColumnDefinition _ColumnTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnSubtitle")]
    private ColumnDefinition _ColumnSubtitle;

    [CompilerGenerated]
    [AccessedThroughProperty("ColumnExtend")]
    private ColumnDefinition _ColumnExtend;

    [CompilerGenerated]
    [AccessedThroughProperty("LabTitle")]
    private TextBlock _LabTitle;

    [CompilerGenerated]
    [AccessedThroughProperty("LabSubtitle")]
    private TextBlock _LabSubtitle;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnUpdate")]
    private MyIconButton _BtnUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("PanTags")]
    private StackPanel _PanTags;

    [CompilerGenerated]
    [AccessedThroughProperty("LabInfo")]
    private TextBlock _LabInfo;

    public string Title
    {
        get
        {
            return _Title;
        }
        set
        {
            LabTitle.TextDecorations = (Entry.IsEnabled ? null : TextDecorations.Strikethrough);
            if (Operators.CompareString(LabTitle.Text, value, TextCompare: false) != 0)
            {
                LabTitle.Text = value;
                _Title = value;
            }
        }
    }

    public string SubTitle
    {
        get
        {
            return LabSubtitle?.Text ?? "";
        }
        set
        {
            if (Operators.CompareString(LabSubtitle.Text, value, TextCompare: false) != 0)
            {
                LabSubtitle.Text = value;
                LabSubtitle.Visibility = ((Operators.CompareString(value, "", TextCompare: false) == 0) ? Visibility.Collapsed : Visibility.Visible);
            }
        }
    }

    public string Description
    {
        get
        {
            return LabInfo.Text;
        }
        set
        {
            if (Operators.CompareString(LabInfo.Text, value, TextCompare: false) != 0)
            {
                LabInfo.Text = value;
            }
        }
    }

    public List<string> Tags
    {
        set
        {
            PanTags.Children.Clear();
            PanTags.Visibility = ((!value.Any()) ? Visibility.Collapsed : Visibility.Visible);
            foreach (string item in value)
            {
                Border border = new Border
                {
                    Background = new ModBase.MyColor("#0A000000"),
                    Padding = new Thickness(3.0, 1.0, 3.0, 1.0),
                    CornerRadius = new CornerRadius(3.0),
                    Margin = new Thickness(0.0, 0.0, 3.0, 0.0),
                    SnapsToDevicePixels = true,
                    UseLayoutRounding = false
                };
                TextBlock child = new TextBlock
                {
                    Text = item,
                    Foreground = new ModBase.MyColor("#B0B0B0"),
                    FontSize = 11.0
                };
                border.Child = child;
                PanTags.Children.Add(border);
            }
        }
    }

    public LocalResourceFile Entry
    {
        get
        {
            return (LocalResourceFile)Tag;
        }
        set
        {
            Tag = value;
        }
    }

    private static bool Swiping
    {
        get
        {
            return _Swiping;
        }
        set
        {
            _Swiping = value;
            ModMain.FrmInstanceMod.CardSelect.IsHitTestVisible = !value;
        }
    }

    public bool Checked
    {
        get
        {
            return _Checked;
        }
        set
        {
            try
            {
                bool flag = _Checked;
                if (value == _Checked)
                {
                    return;
                }
                _Checked = value;
                ModBase.RouteEventArgs e = new ModBase.RouteEventArgs();
                if (IsInitialized)
                {
                    Changed?.Invoke(this, e);
                    if (e.Handled)
                    {
                        _Checked = flag;
                        return;
                    }
                }
                if (value)
                {
                    ModBase.RouteEventArgs e2 = new ModBase.RouteEventArgs();
                    Check?.Invoke(this, e2);
                    if (e2.Handled)
                    {
                        return;
                    }
                }
                if (ModBase.IsVisibleInForm(this))
                {
                    List<ModAnimation.AniData> list = new List<ModAnimation.AniData>();
                    if (Checked)
                    {
                        double num = 32.0 - RectCheck.ActualHeight;
                        list.Add(ModAnimation.AaHeight(RectCheck, num * 0.4, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
                        list.Add(ModAnimation.AaHeight(RectCheck, num * 0.6, 300, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)));
                        list.Add(ModAnimation.AaOpacity(RectCheck, 1.0 - RectCheck.Opacity, 30));
                        RectCheck.VerticalAlignment = VerticalAlignment.Center;
                        RectCheck.Margin = new Thickness(-3.0, 0.0, 0.0, 0.0);
                        list.Add(ModAnimation.AaColor(LabTitle, TextBlock.ForegroundProperty, Entry.IsEnabled ? "ColorBrush2" : "ColorBrush5", 200));
                    }
                    else
                    {
                        list.Add(ModAnimation.AaHeight(RectCheck, 0.0 - RectCheck.ActualHeight, 120, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)));
                        list.Add(ModAnimation.AaOpacity(RectCheck, 0.0 - RectCheck.Opacity, 70, 40));
                        RectCheck.VerticalAlignment = VerticalAlignment.Center;
                        list.Add(ModAnimation.AaColor(LabTitle, TextBlock.ForegroundProperty, (LabTitle.TextDecorations == null) ? "ColorBrush1" : "ColorBrushGray4", 120));
                    }
                    ModAnimation.AniStart(list, "MyLocalModItem Checked " + Conversions.ToString(Uuid));
                }
                else
                {
                    RectCheck.VerticalAlignment = VerticalAlignment.Center;
                    RectCheck.Margin = new Thickness(-3.0, 0.0, 0.0, 0.0);
                    if (Checked)
                    {
                        RectCheck.Height = 32.0;
                        RectCheck.Opacity = 1.0;
                        LabTitle.SetResourceReference(TextBlock.ForegroundProperty, Entry.IsEnabled ? "ColorBrush2" : "ColorBrush5");
                    }
                    else
                    {
                        RectCheck.Height = 0.0;
                        RectCheck.Opacity = 0.0;
                        LabTitle.SetResourceReference(TextBlock.ForegroundProperty, Entry.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
                    }
                    ModAnimation.AniStop("MyLocalModItem Checked " + Conversions.ToString(Uuid));
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "设置 Checked 失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\MyLocalModItem.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    public Border RectBack
    {
        get
        {
            if (_RectBack == null)
            {
                Border border = new Border
                {
                    Name = "RectBack",
                    CornerRadius = new CornerRadius(3.0),
                    RenderTransform = new ScaleTransform(0.8, 0.8),
                    RenderTransformOrigin = new Point(0.5, 0.5),
                    BorderThickness = new Thickness(ModBase.GetWPFSize(1.0)),
                    SnapsToDevicePixels = true,
                    IsHitTestVisible = false,
                    Opacity = 0.0
                };
                border.SetResourceReference(Border.BackgroundProperty, "ColorBrush7");
                border.SetResourceReference(Border.BorderBrushProperty, "ColorBrush6");
                Grid.SetColumnSpan(border, 999);
                Grid.SetRowSpan(border, 999);
                Children.Insert(0, border);
                _RectBack = border;
            }
            return _RectBack;
        }
    }

    public IEnumerable<MyIconButton> Buttons
    {
        get
        {
            return _Buttons;
        }
        set
        {
            _Buttons = value;
            if (ButtonStack != null)
            {
                Children.Remove(ButtonStack);
                ButtonStack = null;
            }
            if (!value.Any())
            {
                return;
            }
            ButtonStack = new StackPanel
            {
                Opacity = 0.0,
                Margin = new Thickness(0.0, 0.0, 5.0, 0.0),
                SnapsToDevicePixels = false,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                UseLayoutRounding = false
            };
            Grid.SetColumnSpan(ButtonStack, 10);
            Grid.SetRowSpan(ButtonStack, 10);
            foreach (MyIconButton item in value)
            {
                if (item.Height.Equals(double.NaN))
                {
                    item.Height = 25.0;
                }
                if (item.Width.Equals(double.NaN))
                {
                    item.Width = 25.0;
                }
                ((StackPanel)ButtonStack).Children.Add(item);
            }
            Children.Add(ButtonStack);
        }
    }

    public Border RectCheck
    {
        get
        {
            if (_RectCheck == null)
            {
                _RectCheck = new Border
                {
                    Width = 5.0,
                    Height = (Checked ? double.NaN : 0.0),
                    CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0),
                    VerticalAlignment = ((!Checked) ? VerticalAlignment.Center : VerticalAlignment.Stretch),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    UseLayoutRounding = false,
                    SnapsToDevicePixels = false,
                    Margin = (Checked ? new Thickness(-3.0, 6.0, 0.0, 6.0) : new Thickness(-3.0, 0.0, 0.0, 0.0))
                };
                _RectCheck.SetResourceReference(Border.BackgroundProperty, "ColorBrush3");
                Grid.SetRowSpan(_RectCheck, 10);
                Children.Add(_RectCheck);
            }
            return _RectCheck;
        }
    }

    internal virtual MyLocalModItem PanBack_WithEvents
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

    internal virtual ColumnDefinition ColumnPaddingRight_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnPaddingRight;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnPaddingRight = value;
        }
    }

    internal virtual MyImage PathLogo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PathLogo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PathLogo = value;
        }
    }

    internal virtual Grid PanTitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanTitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            SizeChangedEventHandler value2 = (object a0, SizeChangedEventArgs a1) =>
            {
                PanTitle_SizeChanged();
            };
            Grid grid = _PanTitle;
            if (grid != null)
            {
                grid.SizeChanged -= value2;
            }
            _PanTitle = value;
            grid = _PanTitle;
            if (grid != null)
            {
                grid.SizeChanged += value2;
            }
        }
    }

    internal virtual ColumnDefinition ColumnTitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnTitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnTitle = value;
        }
    }

    internal virtual ColumnDefinition ColumnSubtitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnSubtitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnSubtitle = value;
        }
    }

    internal virtual ColumnDefinition ColumnExtend_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ColumnExtend;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ColumnExtend = value;
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
            _LabTitle = value;
        }
    }

    internal virtual TextBlock LabSubtitle_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabSubtitle;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabSubtitle = value;
        }
    }

    internal virtual MyIconButton BtnUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = BtnUpdate_PreviewMouseRightButtonUp;
            MyIconButton.ClickEventHandler obj = BtnUpdate_Click;
            MyIconButton myIconButton = _BtnUpdate;
            if (myIconButton != null)
            {
                myIconButton.PreviewMouseRightButtonUp -= value2;
                myIconButton.Click -= obj;
            }
            _BtnUpdate = value;
            myIconButton = _BtnUpdate;
            if (myIconButton != null)
            {
                myIconButton.PreviewMouseRightButtonUp += value2;
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual StackPanel PanTags_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanTags;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanTags = value;
        }
    }

    internal virtual TextBlock LabInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabInfo = value;
        }
    }

    public event ClickEventHandler Click;

    public event CheckEventHandler Check;

    public event ChangedEventHandler Changed;

    private void Button_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (IsMouseDown)
        {
            Click?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
            if (!e.Handled)
            {
                Logger.Info($"按下本地 Mod 列表项：{LabTitle.Text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\MyLocalModItem.xaml.vb");
            }
        }
    }

    private void Button_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (IsMouseDirectlyOver)
        {
            IsMouseDown = true;
            if (ButtonStack != null)
            {
                ButtonStack.IsHitTestVisible = false;
            }
        }
    }

    private void Button_MouseLeave(object sender, object e)
    {
        IsMouseDown = false;
        if (ButtonStack != null)
        {
            ButtonStack.IsHitTestVisible = true;
        }
    }

    private void Button_MouseSwipeStart(object sender, object e)
    {
        if (Parent != null)
        {
            SwipeEnd = (SwipeStart = ((StackPanel)Parent).Children.IndexOf(this));
            Swiping = true;
            SwipToState = !Checked;
        }
    }

    private void Button_MouseSwipe(object sender, object e)
    {
        if (Parent == null)
        {
            return;
        }
        if (Mouse.LeftButton != MouseButtonState.Pressed || !(Mouse.DirectlyOver is MyLocalModItem))
        {
            Swiping = false;
            return;
        }
        UIElementCollection children = ((StackPanel)Parent).Children;
        int val = children.IndexOf(this);
        checked
        {
            SwipeStart = MathUtils.Clamp<int>(Math.Min(SwipeStart, val), 0, children.Count - 1);
            SwipeEnd = MathUtils.Clamp<int>(Math.Max(SwipeEnd, val), 0, children.Count - 1);
            if (SwipeStart != SwipeEnd)
            {
                int swipeStart = SwipeStart;
                int swipeEnd = SwipeEnd;
                for (int i = swipeStart; i <= swipeEnd; i++)
                {
                    MyLocalModItem myLocalModItem = (MyLocalModItem)children[i];
                    myLocalModItem.InitLate(myLocalModItem, (EventArgs)e);
                    myLocalModItem.Checked = SwipToState;
                }
            }
        }
    }

    private string GetUpdateCompareDescription()
    {
        string text = (Entry.ProjectVersion.Version ?? Entry.ProjectVersion.Display).Replace(".jar", "");
        string text2 = (Entry.UpdateFile.Version ?? Entry.UpdateFile.Display).Replace(".jar", "");
        List<string> list = text.Split("-_+ ".ToCharArray()).ToList();
        List<string> list2 = text2.Split("-_+ ".ToCharArray()).ToList();
        bool flag = false;
        foreach (string item in list.ToList())
        {
            if (list2.Contains(item))
            {
                list.Remove(item);
                list2.Remove(item);
                flag = true;
            }
        }
        if (flag && list.Any() && list2.Any())
        {
            text = EnumerableExtensions.Join((IEnumerable)list, "-");
            text2 = EnumerableExtensions.Join((IEnumerable)list2, "-");
            Entry._Version = text;
        }
        return string.Format("当前版本：{0}（{1}）{2}最新版本：{3}（{4}）", text, StringUtils.FormatTimeSpan(Entry.ProjectVersion.ReleaseDate - DateTime.Now, false), "\r\n", text2, StringUtils.FormatTimeSpan(Entry.UpdateFile.ReleaseDate - DateTime.Now, false));
    }

    public MyLocalModItem()
    {
        PreviewMouseLeftButtonUp += Button_MouseUp;
        PreviewMouseLeftButtonDown += Button_MouseDown;
        MouseLeave += Button_MouseLeave;
        PreviewMouseLeftButtonUp += Button_MouseLeave;
        MouseLeftButtonDown += Button_MouseSwipeStart;
        MouseEnter += Button_MouseSwipe;
        MouseLeave += Button_MouseSwipe;
        MouseLeftButtonUp += Button_MouseSwipe;
        MouseEnter += RefreshColor;
        MouseLeave += RefreshColor;
        MouseLeftButtonDown += RefreshColor;
        MouseLeftButtonUp += RefreshColor;
        Changed += RefreshColor;
        Uuid = ModBase.GetUuid();
        IsMouseDown = false;
        _Checked = false;
        _RectBack = null;
        HasEnteredViewport = false;
        InitializeComponent();
        _InitWithEvents();
        LazyLoadBehavior.OnFirstEnterScrollViewerViewport(this, FirstEnterScrollViewerViewport);
    }

    private void FirstEnterScrollViewerViewport()
    {
        HasEnteredViewport = true;
        Refresh();
    }

    public void Refresh()
    {
        if (!HasEnteredViewport)
        {
            return;
        }
        if (Entry.HasUpdate)
        {
            BtnUpdate.Visibility = Visibility.Visible;
            BtnUpdate.ToolTip = string.Format("{0}{1}点击以更新，右键查看更新日志。", GetUpdateCompareDescription(), "\r\n");
        }
        else
        {
            BtnUpdate.Visibility = Visibility.Collapsed;
        }
        string text = StringExtensions.BeforeLast(Entry.File.Name, ".", false);
        string text2;
        if (Settings.Get<int>("ToolModLocalNameStyle") == 1)
        {
            Title = text;
            SubTitle = "";
            if ((object)Entry.Project == null)
            {
                text2 = Entry.Display;
            }
            else
            {
                (string, string) controlTitle = Entry.Project.GetControlTitle(HasModLoaderDescription: false);
                text2 = controlTitle.Item1 + controlTitle.Item2;
            }
            text2 = text2.Replace("  |  ", " / ");
            if (Entry.Version != null)
            {
                text2 += $" ({Entry.Version})";
            }
        }
        else
        {
            if ((object)Entry.Project == null)
            {
                Title = Entry.Display;
                SubTitle = ((Entry.Version == null) ? "" : ("  |  " + Entry.Version));
            }
            else
            {
                (string, string) controlTitle2 = Entry.Project.GetControlTitle(HasModLoaderDescription: false);
                Title = controlTitle2.Item1;
                SubTitle = controlTitle2.Item2 + ((Entry.Version == null) ? "" : ("  |  " + Entry.Version));
            }
            text2 = text;
        }
        if ((object)Entry.Project != null)
        {
            text2 = text2 + ": " + StringExtensions.ReplaceLineEndings(Entry.Project.Description, "", false);
        }
        else if (Entry.Description != null)
        {
            text2 = text2 + ": " + StringExtensions.ReplaceLineEndings(Entry.Description, "", false);
        }
        Description = text2;
        if (Checked)
        {
            LabTitle.SetResourceReference(TextBlock.ForegroundProperty, Entry.IsEnabled ? "ColorBrush2" : "ColorBrush5");
        }
        else
        {
            LabTitle.SetResourceReference(TextBlock.ForegroundProperty, Entry.IsEnabled ? "ColorBrush1" : "ColorBrushGray4");
        }
        if ((object)Entry.Project != null)
        {
            Entry.Project.ApplyLogoToMyImage(PathLogo);
        }
        else
        {
            PathLogo.Source = ModBase.PathImage + "Icons/NoIcon.png";
        }
        if (Entry.IsEnabled)
        {
            if (ImgState != null)
            {
                Children.Remove(ImgState);
                ImgState = null;
            }
        }
        else
        {
            if (ImgState == null)
            {
                ImgState = new Image
                {
                    Width = 20.0,
                    Height = 20.0,
                    Margin = new Thickness(0.0, 0.0, -5.0, -3.0),
                    IsHitTestVisible = false,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom
                };
                RenderOptions.SetBitmapScalingMode(ImgState, BitmapScalingMode.HighQuality);
                Grid.SetColumn(ImgState, 1);
                Grid.SetRow(ImgState, 1);
                Grid.SetRowSpan(ImgState, 2);
                Children.Add(ImgState);
            }
            ImgState.Source = new MyBitmap(ModBase.PathImage + "Icons/Disabled.png");
        }
        if ((object)Entry.Project != null)
        {
            Tags = Entry.Project.Tags;
        }
    }

    public void RefreshColor(object sender, EventArgs e)
    {
        InitLate(RuntimeHelpers.GetObjectValue(sender), e);
        int num = (IsMouseOver ? 120 : 180);
        List<ModAnimation.AniData> list = new List<ModAnimation.AniData>();
        checked
        {
            if (ButtonStack != null)
            {
                if (IsMouseOver)
                {
                    list.Add(ModAnimation.AaOpacity(ButtonStack, 1.0 - ButtonStack.Opacity, (int)Math.Round((double)num * 0.7), (int)Math.Round((double)num * 0.3)));
                    list.Add(ModAnimation.AaDouble((object i) =>
                    {
                        ColumnPaddingRight.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Max", new object[2]
                        {
                            0,
                            Operators.AddObject(ColumnPaddingRight.Width.Value, i)
                        }, null, null, null)));
                    }, (double)(5 + Buttons.Count() * 25) - ColumnPaddingRight.Width.Value, (int)Math.Round((double)num * 0.3), (int)Math.Round((double)num * 0.7)));
                }
                else
                {
                    list.Add(ModAnimation.AaOpacity(ButtonStack, 0.0 - ButtonStack.Opacity, (int)Math.Round((double)num * 0.4)));
                    list.Add(ModAnimation.AaDouble((object i) =>
                    {
                        ColumnPaddingRight.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Max", new object[2]
                        {
                            0,
                            Operators.AddObject(ColumnPaddingRight.Width.Value, i)
                        }, null, null, null)));
                    }, 4.0 - ColumnPaddingRight.Width.Value, (int)Math.Round((double)num * 0.4)));
                }
            }
            if (IsMouseOver || Checked)
            {
                list.AddRange(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaColor(RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrushBg1", num),
                    ModAnimation.AaOpacity(RectBack, 1.0 - RectBack.Opacity, num, 0, new ModAnimation.AniEaseOutFluent())
                });
                if (IsMouseDown)
                {
                    list.Add(ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)RectBack.RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
                }
                else
                {
                    list.Add(ModAnimation.AaScaleTransform(RectBack, 1.0 - ((ScaleTransform)RectBack.RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
                }
            }
            else
            {
                list.AddRange(new ModAnimation.AniData[3]
                {
                    ModAnimation.AaOpacity(RectBack, 0.0 - RectBack.Opacity, num),
                    ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)RectBack.RenderTransform).ScaleX, num, 0, new ModAnimation.AniEaseOutFluent()),
                    ModAnimation.AaScaleTransform(RectBack, -0.196, 1, 0, null, After: true)
                });
            }
            ModAnimation.AniStart(list, "LocalModItem Color " + Conversions.ToString(Uuid));
        }
    }

    private void InitLate(object sender, EventArgs e)
    {
        if (ButtonHandler != null)
        {
            ButtonHandler((MyLocalModItem)sender, e);
            ButtonHandler = null;
        }
    }

    private void BtnUpdate_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        ShowUpdateLog();
    }

    private void ShowUpdateLog()
    {
        string text = Entry.ChangelogUrls.FirstOrDefault((string x) => x.Contains("curseforge.com"));
        string text2 = Entry.ChangelogUrls.FirstOrDefault((string x) => x.Contains("modrinth.com"));
        if (text == null || text2 == null)
        {
            ModBase.OpenWebsite(Entry.ChangelogUrls.First());
            return;
        }
        switch (ModMain.MyMsgBox("要在哪个网站上查看更新日志？", "查看更新日志", "Modrinth", "CurseForge", "取消"))
        {
            case 1:
                ModBase.OpenWebsite(text2);
                break;
            case 2:
                ModBase.OpenWebsite(text);
                break;
        }
    }

    private void BtnUpdate_Click(object sender, EventArgs e)
    {
        switch (ModMain.MyMsgBox(string.Format("是否要更新 {0}？{1}{2}{3}", Entry.Display, "\r\n", "\r\n", GetUpdateCompareDescription()), "Mod 更新确认", "更新", "查看更新日志", "取消"))
        {
            case 1:
                ModMain.FrmInstanceMod.UpdateMods(new LocalResourceFile[1] { Entry });
                break;
            case 2:
                ShowUpdateLog();
                break;
            case 3:
                break;
        }
    }

    private void PanTitle_SizeChanged()
    {
        int num = default;
        switch ((!ColumnExtend.Width.IsStar) ? ((!ColumnTitle.Width.IsStar) ? 1 : 2) : 0)
        {
            case 0:
                if (ColumnExtend.ActualWidth < 0.5)
                {
                    num = ((LabSubtitle.Visibility != Visibility.Collapsed) ? 1 : 2);
                    goto default;
                }
                break;
            case 1:
                if (ColumnSubtitle.ActualWidth < 0.5)
                {
                    num = 2;
                }
                else
                {
                    if (ModBase.IsTextTrimmed(LabSubtitle))
                    {
                        break;
                    }
                    num = 0;
                }
                goto default;
            case 2:
                if (!ModBase.IsTextTrimmed(LabTitle))
                {
                    num = ((LabSubtitle.Visibility != Visibility.Collapsed) ? 1 : 0);
                    goto default;
                }
                break;
            default:
                switch (num)
                {
                    case 0:
                        ColumnTitle.Width = GridLength.Auto;
                        ColumnSubtitle.Width = GridLength.Auto;
                        ColumnExtend.Width = new GridLength(1.0, GridUnitType.Star);
                        break;
                    case 1:
                        ColumnTitle.Width = GridLength.Auto;
                        ColumnSubtitle.Width = new GridLength(1.0, GridUnitType.Star);
                        ColumnExtend.Width = new GridLength(0.0, GridUnitType.Pixel);
                        break;
                    case 2:
                        ColumnTitle.Width = new GridLength(1.0, GridUnitType.Star);
                        ColumnSubtitle.Width = new GridLength(0.0, GridUnitType.Pixel);
                        ColumnExtend.Width = new GridLength(0.0, GridUnitType.Pixel);
                        break;
                }
                break;
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnUpdate_WithEvents = BtnUpdate;
        ColumnExtend_WithEvents = ColumnExtend;
        ColumnPaddingRight_WithEvents = ColumnPaddingRight;
        ColumnSubtitle_WithEvents = ColumnSubtitle;
        ColumnTitle_WithEvents = ColumnTitle;
        LabInfo_WithEvents = LabInfo;
        LabSubtitle_WithEvents = LabSubtitle;
        LabTitle_WithEvents = LabTitle;
        PanBack_WithEvents = PanBack;
        PanTags_WithEvents = PanTags;
        PanTitle_WithEvents = PanTitle;
        PathLogo_WithEvents = PathLogo;
    }
}

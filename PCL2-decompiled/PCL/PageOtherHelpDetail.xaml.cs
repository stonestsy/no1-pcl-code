using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageOtherHelpDetail : MyPageRight, IRefreshable, IComponentConnector
{
    public ModMain.HelpEntry Entry;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanCustom")]
    private StackPanel _PanCustom;

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

    internal virtual StackPanel PanCustom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanCustom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanCustom = value;
        }
    }

    public PageOtherHelpDetail()
    {
        Loaded += PageOtherHelpDetail_Loaded;
        InitializeComponent();
        _InitWithEvents();
    }

    public void Refresh()
    {
        Init(new ModMain.HelpEntry(Entry.RawPath));
    }

    void IRefreshable.Refresh()
    {
        this.Refresh();
    }

    private void PageOtherHelpDetail_Loaded(object sender, RoutedEventArgs e)
    {
        PanBack.ScrollToTop();
    }

    public bool Init(ModMain.HelpEntry Entry)
    {
        string text = Entry.XamlContent ?? "";
        if (Operators.CompareString(text, "", TextCompare: false) == 0)
        {
            throw new Exception("帮助 xaml 文件为空");
        }
        bool result;
        try
        {
            text = ModMain.ArgumentReplace(text, (Func<string, string>)StringUtils.XmlEscape, true);
            while (text.Contains("xmlns"))
            {
                text = StringExtensions.RegexReplace(text, "xmlns[^\"']*(\"|')[^\"']*(\"|')", "", RegexOptions.None).Replace("xmlns", "");
            }
            text = "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:sys=\"clr-namespace:System;assembly=mscorlib\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" xmlns:core=\"clr-namespace:MeloongCore;assembly=MeloongCore\" xmlns:corewpf=\"clr-namespace:MeloongCore.Wpf;assembly=MeloongCore.Wpf\">" + text + "</StackPanel>";
            this.Entry = Entry;
            PanCustom.Children.Clear();
            PanCustom.Children.Add((UIElement)ModBase.GetObjectFromXML(text));
            result = true;
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Info(string.Format("自定义信息内容：{0}{1}", "\r\n", text), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageOther\\PageOtherHelpDetail.xaml.vb");
            Logger.Error(ex2, "加载帮助 XAML 文件失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageOther\\PageOtherHelpDetail.xaml.vb");
            result = false;
            ProjectData.ClearProjectError();
        }
        return result;
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        PanBack_WithEvents = PanBack;
        PanCustom_WithEvents = PanCustom;
    }
}

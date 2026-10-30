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
public partial class MySearchBox : MyCard, IComponentConnector
{
    public delegate void TextChangedEventHandler(object sender, EventArgs e);

    [CompilerGenerated]
    [AccessedThroughProperty("TextBox")]
    private MyTextBox _TextBox;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnClear")]
    private MyIconButton _BtnClear;

    public string HintText
    {
        get
        {
            return TextBox.HintText;
        }
        set
        {
            TextBox.HintText = value;
        }
    }

    public string Text
    {
        get
        {
            return TextBox.Text;
        }
        set
        {
            TextBox.Text = value;
        }
    }

    internal virtual MyTextBox TextBox_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextBox;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            System.Windows.Controls.TextChangedEventHandler value2 = Text_TextChanged;
            MyTextBox myTextBox = _TextBox;
            if (myTextBox != null)
            {
                myTextBox.TextChanged -= value2;
            }
            _TextBox = value;
            myTextBox = _TextBox;
            if (myTextBox != null)
            {
                myTextBox.TextChanged += value2;
            }
        }
    }

    internal virtual MyIconButton BtnClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = BtnClear_Click;
            MyIconButton myIconButton = _BtnClear;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnClear = value;
            myIconButton = _BtnClear;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    public event TextChangedEventHandler TextChanged;

    public MySearchBox()
    {
        Loaded += MySearchBox_Loaded;
        KeyUp += MySearchBox_KeyUp;
        InitializeComponent();
        _InitWithEvents();
    }

    private void MySearchBox_Loaded(object sender, RoutedEventArgs e)
    {
        TextBox.Focus();
    }

    private void Text_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox.Text))
        {
            ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 0.0 - BtnClear.Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
            BtnClear.IsHitTestVisible = false;
        }
        else
        {
            ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 1.0 - BtnClear.Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
            BtnClear.IsHitTestVisible = true;
        }
        TextChanged?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
        TextBox.Text = "";
        TextBox.Focus();
    }

    private void MySearchBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            ModMain.RaiseCustomEvent(this);
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnClear_WithEvents = BtnClear;
        TextBox_WithEvents = TextBox;
    }
}

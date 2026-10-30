using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadResourcePack : MyPageRight, IComponentConnector
{
    [CompilerGenerated]
    [AccessedThroughProperty("Content")]
    private PageResource _Content;

    internal virtual PageResource Content_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Content;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _Content = value;
        }
    }

    public PageDownloadResourcePack()
    {
        InitializeComponent();
        _InitWithEvents();
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        Content_WithEvents = Content;
    }
}

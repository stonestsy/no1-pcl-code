using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadLeft : MyPageLeft, IRefreshable, IComponentConnector
{
    public FormMain.PageSubType PageID;

    [CompilerGenerated]
    [AccessedThroughProperty("PanItem")]
    private StackPanel _PanItem;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemInstall")]
    private MyListItem _ItemInstall;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemMod")]
    private MyListItem _ItemMod;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemPack")]
    private MyListItem _ItemPack;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemDataPack")]
    private MyListItem _ItemDataPack;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemResourcePack")]
    private MyListItem _ItemResourcePack;

    [CompilerGenerated]
    [AccessedThroughProperty("ItemShader")]
    private MyListItem _ItemShader;

    internal virtual StackPanel PanItem_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanItem;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanItem = value;
        }
    }

    internal virtual MyListItem ItemInstall_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemInstall;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem.ClickEventHandler obj2 = ItemInstall_Click;
            MyListItem myListItem = _ItemInstall;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
                myListItem.Click -= obj2;
            }
            _ItemInstall = value;
            myListItem = _ItemInstall;
            if (myListItem != null)
            {
                myListItem.Check += obj;
                myListItem.Click += obj2;
            }
        }
    }

    internal virtual MyListItem ItemMod_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemMod;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem myListItem = _ItemMod;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
            }
            _ItemMod = value;
            myListItem = _ItemMod;
            if (myListItem != null)
            {
                myListItem.Check += obj;
            }
        }
    }

    internal virtual MyListItem ItemPack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemPack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem myListItem = _ItemPack;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
            }
            _ItemPack = value;
            myListItem = _ItemPack;
            if (myListItem != null)
            {
                myListItem.Check += obj;
            }
        }
    }

    internal virtual MyListItem ItemDataPack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemDataPack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem myListItem = _ItemDataPack;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
            }
            _ItemDataPack = value;
            myListItem = _ItemDataPack;
            if (myListItem != null)
            {
                myListItem.Check += obj;
            }
        }
    }

    internal virtual MyListItem ItemResourcePack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemResourcePack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem myListItem = _ItemResourcePack;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
            }
            _ItemResourcePack = value;
            myListItem = _ItemResourcePack;
            if (myListItem != null)
            {
                myListItem.Check += obj;
            }
        }
    }

    internal virtual MyListItem ItemShader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ItemShader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            IMyRadio.CheckEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                PageCheck((FrameworkElement)a0, a1);
            };
            MyListItem myListItem = _ItemShader;
            if (myListItem != null)
            {
                myListItem.Check -= obj;
            }
            _ItemShader = value;
            myListItem = _ItemShader;
            if (myListItem != null)
            {
                myListItem.Check += obj;
            }
        }
    }

    public PageDownloadLeft()
    {
        PageID = FormMain.PageSubType.Default;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageCheck(FrameworkElement sender, ModBase.RouteEventArgs e)
    {
        if (sender.Tag != null)
        {
            PageChange((FormMain.PageSubType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(sender.Tag)))));
        }
    }

    public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
    {
        if (ID == (FormMain.PageSubType)(-1))
        {
            ID = PageID;
        }
        switch (ID)
        {
            case FormMain.PageSubType.Default:
                if (ModMain.FrmDownloadInstall == null)
                {
                    ModMain.FrmDownloadInstall = new PageDownloadInstall();
                }
                return ModMain.FrmDownloadInstall;
            case FormMain.PageSubType.DownloadMod:
                if (ModMain.FrmDownloadMod == null)
                {
                    ModMain.FrmDownloadMod = new PageDownloadMod();
                }
                return ModMain.FrmDownloadMod;
            case FormMain.PageSubType.DownloadPack:
                if (ModMain.FrmDownloadPack == null)
                {
                    ModMain.FrmDownloadPack = new PageDownloadPack();
                }
                return ModMain.FrmDownloadPack;
            case FormMain.PageSubType.DownloadResourcePack:
                if (ModMain.FrmDownloadResourcePack == null)
                {
                    ModMain.FrmDownloadResourcePack = new PageDownloadResourcePack();
                }
                return ModMain.FrmDownloadResourcePack;
            case FormMain.PageSubType.DownloadShader:
                if (ModMain.FrmDownloadShader == null)
                {
                    ModMain.FrmDownloadShader = new PageDownloadShader();
                }
                return ModMain.FrmDownloadShader;
            case FormMain.PageSubType.DownloadDataPack:
                if (ModMain.FrmDownloadDataPack == null)
                {
                    ModMain.FrmDownloadDataPack = new PageDownloadDataPack();
                }
                return ModMain.FrmDownloadDataPack;
            default:
                throw new Exception("未知的下载子页面种类：" + Conversions.ToString((int)ID));
        }
    }

    public void PageChange(FormMain.PageSubType ID)
    {
        if (PageID == ID)
        {
            return;
        }
        checked
        {
            ModAnimation.AniControlEnabled++;
            try
            {
                PageChangeRun((MyPageRight)PageGet(ID));
                PageID = ID;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, $"切换分页面失败（ID {ID}）", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadLeft.xaml.vb");
                ProjectData.ClearProjectError();
            }
            finally
            {
                ModAnimation.AniControlEnabled--;
            }
        }
    }

    private static void PageChangeRun(MyPageRight Target)
    {
        ModAnimation.AniStop("FrmMain PageChangeRight");
        if (Target.Parent != null)
        {
            Target.SetValue(ContentPresenter.ContentProperty, null);
        }
        ModMain.FrmMain.PageRight = Target;
        ((MyPageRight)ModMain.FrmMain.PanMainRight.Child).PageOnExit();
        ModAnimation.AniStart(new ModAnimation.AniData[2]
        {
            ModAnimation.AaCode(() =>
            {
                ((MyPageRight)ModMain.FrmMain.PanMainRight.Child).PageOnForceExit();
                ModMain.FrmMain.PanMainRight.Child = ModMain.FrmMain.PageRight;
                ModMain.FrmMain.PageRight.Opacity = 0.0;
            }, 130),
            ModAnimation.AaCode(() =>
            {
                ModMain.FrmMain.PageRight.Opacity = 1.0;
                ModMain.FrmMain.PageRight.PageOnEnter();
            }, 30, After: true)
        }, "PageLeft PageChange");
    }

    public void Refresh_Click(object sender, EventArgs e)
    {
        Refresh((FormMain.PageSubType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null))))));
    }

    public void Refresh()
    {
        Refresh(ModMain.FrmMain.PageCurrentSub);
    }

    void IRefreshable.Refresh()
    {
        this.Refresh();
    }

    public void Refresh(FormMain.PageSubType SubType)
    {
        ResourceProject.Cache.Clear();
        ResourceVersion.ProjectFilesCache.Clear();
        switch (SubType)
        {
            case FormMain.PageSubType.Default:
                ModDownload.DlClientListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlOptiFineListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlForgeListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlNeoForgeListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlLiteLoaderListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlFabricListLoader.Start(null, IsForceRestart: true);
                ModDownload.DlFabricApiLoader.Start(null, IsForceRestart: true);
                ModDownload.DlOptiFabricLoader.Start(null, IsForceRestart: true);
                ItemInstall.Checked = true;
                break;
            case FormMain.PageSubType.DownloadMod:
                if (ModMain.FrmDownloadMod != null)
                {
                    ModMain.FrmDownloadMod.Content.Storage = new ResourceSearcher.SearchResult();
                    ModMain.FrmDownloadMod.Content.Page = 0;
                    ModMain.FrmDownloadMod.PageLoaderRestart();
                }
                ItemMod.Checked = true;
                break;
            case FormMain.PageSubType.DownloadPack:
                if (ModMain.FrmDownloadPack != null)
                {
                    ModMain.FrmDownloadPack.Content.Storage = new ResourceSearcher.SearchResult();
                    ModMain.FrmDownloadPack.Content.Page = 0;
                    ModMain.FrmDownloadPack.PageLoaderRestart();
                }
                ItemPack.Checked = true;
                break;
            case FormMain.PageSubType.DownloadResourcePack:
                if (ModMain.FrmDownloadResourcePack != null)
                {
                    ModMain.FrmDownloadResourcePack.Content.Storage = new ResourceSearcher.SearchResult();
                    ModMain.FrmDownloadResourcePack.Content.Page = 0;
                    ModMain.FrmDownloadResourcePack.PageLoaderRestart();
                }
                ItemResourcePack.Checked = true;
                break;
            case FormMain.PageSubType.DownloadShader:
                if (ModMain.FrmDownloadShader != null)
                {
                    ModMain.FrmDownloadShader.Content.Storage = new ResourceSearcher.SearchResult();
                    ModMain.FrmDownloadShader.Content.Page = 0;
                    ModMain.FrmDownloadShader.PageLoaderRestart();
                }
                ItemShader.Checked = true;
                break;
            case FormMain.PageSubType.DownloadDataPack:
                if (ModMain.FrmDownloadDataPack != null)
                {
                    ModMain.FrmDownloadDataPack.Content.Storage = new ResourceSearcher.SearchResult();
                    ModMain.FrmDownloadDataPack.Content.Page = 0;
                    ModMain.FrmDownloadDataPack.PageLoaderRestart();
                }
                ItemDataPack.Checked = true;
                break;
        }
        ModMain.Hint("正在刷新……", ModMain.HintType.Blue, Log: false);
    }

    private void ItemInstall_Click(object sender, MouseButtonEventArgs e)
    {
        if (ItemInstall.Checked)
        {
            ModMain.FrmDownloadInstall.ExitSelectPage();
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        ItemDataPack_WithEvents = ItemDataPack;
        ItemInstall_WithEvents = ItemInstall;
        ItemMod_WithEvents = ItemMod;
        ItemPack_WithEvents = ItemPack;
        ItemResourcePack_WithEvents = ItemResourcePack;
        ItemShader_WithEvents = ItemShader;
        PanItem_WithEvents = PanItem;
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceMod : MyPageRight, IRefreshable, IComponentConnector
{
    public enum FilterType
    {
        All,
        Enabled,
        Disabled,
        CanUpdate
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__36_002D0
    {
        public LocalResourceFile _0024VB_0024Local_ModEntity;

        public _Closure_0024__36_002D0(_Closure_0024__36_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
            }
        }

        internal bool _Lambda_0024__0(MyLocalModItem i)
        {
            return i.Entry == _0024VB_0024Local_ModEntity;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__41_002D0
    {
        public LocalResourceFile _0024VB_0024Local_ModEntity;

        public _Closure_0024__41_002D0(_Closure_0024__41_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
            }
        }

        internal bool _Lambda_0024__3(MyLocalModItem i)
        {
            return i.Entry.Equals(_0024VB_0024Local_ModEntity);
        }
    }

    private bool IsLoad;

    public ConcurrentDictionary<string, MyLocalModItem> ModItems;

    private int BottomBarShownCount;

    public List<string> SelectedMods;

    private FilterType _Filter;

    public static List<string> UpdatingInstanceModFolders = new List<string>();

    private List<LocalResourceFile> SearchResult;

    [CompilerGenerated]
    [AccessedThroughProperty("PanAllBack")]
    private Grid _PanAllBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("SearchBox")]
    private MySearchBox _SearchBox;

    [CompilerGenerated]
    [AccessedThroughProperty("PanManage")]
    private MyCard _PanManage;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnManageOpen")]
    private MyButton _BtnManageOpen;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnManageInstall")]
    private MyButton _BtnManageInstall;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnManageDownload")]
    private MyButton _BtnManageDownload;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnManageSelectAll")]
    private MyButton _BtnManageSelectAll;

    [CompilerGenerated]
    [AccessedThroughProperty("PanListBack")]
    private MyCard _PanListBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFilter")]
    private StackPanel _PanFilter;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFilterAll")]
    private MyRadioButton _BtnFilterAll;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFilterEnabled")]
    private MyRadioButton _BtnFilterEnabled;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFilterDisabled")]
    private MyRadioButton _BtnFilterDisabled;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFilterCanUpdate")]
    private MyRadioButton _BtnFilterCanUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("PanList")]
    private StackPanel _PanList;

    [CompilerGenerated]
    [AccessedThroughProperty("PanEmpty")]
    private MyCard _PanEmpty;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnHintDownload")]
    private MyButton _BtnHintDownload;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnHintInstall")]
    private MyButton _BtnHintInstall;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnHintOpen")]
    private MyButton _BtnHintOpen;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLoad")]
    private MyCard _PanLoad;

    [CompilerGenerated]
    [AccessedThroughProperty("Load")]
    private MyLoading _Load;

    [CompilerGenerated]
    [AccessedThroughProperty("CardSelect")]
    private MyCard _CardSelect;

    [CompilerGenerated]
    [AccessedThroughProperty("TransSelect")]
    private TranslateTransform _TransSelect;

    [CompilerGenerated]
    [AccessedThroughProperty("LabSelect")]
    private TextBlock _LabSelect;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSelectUpdate")]
    private MyIconTextButton _BtnSelectUpdate;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSelectEnable")]
    private MyIconTextButton _BtnSelectEnable;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSelectDisable")]
    private MyIconTextButton _BtnSelectDisable;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSelectDelete")]
    private MyIconTextButton _BtnSelectDelete;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnSelectCancel")]
    private MyIconTextButton _BtnSelectCancel;

    public FilterType Filter
    {
        get
        {
            return _Filter;
        }
        set
        {
            if (_Filter != value)
            {
                _Filter = value;
                switch (value)
                {
                    case FilterType.All:
                        BtnFilterAll.Checked = true;
                        break;
                    case FilterType.Enabled:
                        BtnFilterEnabled.Checked = true;
                        break;
                    case FilterType.Disabled:
                        BtnFilterDisabled.Checked = true;
                        break;
                    default:
                        BtnFilterCanUpdate.Checked = true;
                        break;
                }
                RefreshUI();
            }
        }
    }

    public bool IsSearching => !string.IsNullOrWhiteSpace(SearchBox.Text);

    internal virtual Grid PanAllBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanAllBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanAllBack = value;
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

    internal virtual MySearchBox SearchBox_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _SearchBox;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            KeyEventHandler value2 = SearchBox_PreviewKeyDown;
            MySearchBox.TextChangedEventHandler obj = (object a0, EventArgs a1) =>
            {
                SearchRun();
            };
            MySearchBox mySearchBox = _SearchBox;
            if (mySearchBox != null)
            {
                mySearchBox.PreviewKeyDown -= value2;
                mySearchBox.TextChanged -= obj;
            }
            _SearchBox = value;
            mySearchBox = _SearchBox;
            if (mySearchBox != null)
            {
                mySearchBox.PreviewKeyDown += value2;
                mySearchBox.TextChanged += obj;
            }
        }
    }

    internal virtual MyCard PanManage_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanManage;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanManage = value;
        }
    }

    internal virtual MyButton BtnManageOpen_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnManageOpen;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageOpen_Click;
            MyButton myButton = _BtnManageOpen;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnManageOpen = value;
            myButton = _BtnManageOpen;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnManageInstall_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnManageInstall;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageInstall_Click;
            MyButton myButton = _BtnManageInstall;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnManageInstall = value;
            myButton = _BtnManageInstall;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnManageDownload_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnManageDownload;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageDownload_Click;
            MyButton myButton = _BtnManageDownload;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnManageDownload = value;
            myButton = _BtnManageDownload;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnManageSelectAll_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnManageSelectAll;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageSelectAll_Click;
            MyButton myButton = _BtnManageSelectAll;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnManageSelectAll = value;
            myButton = _BtnManageSelectAll;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard PanListBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanListBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanListBack = value;
        }
    }

    internal virtual StackPanel PanFilter_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanFilter;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanFilter = value;
        }
    }

    internal virtual MyRadioButton BtnFilterAll_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFilterAll;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioButton.CheckEventHandler obj = (object a0, bool a1) =>
            {
                ChangeFilter((MyRadioButton)a0, a1);
            };
            MyRadioButton myRadioButton = _BtnFilterAll;
            if (myRadioButton != null)
            {
                myRadioButton.Check -= obj;
            }
            _BtnFilterAll = value;
            myRadioButton = _BtnFilterAll;
            if (myRadioButton != null)
            {
                myRadioButton.Check += obj;
            }
        }
    }

    internal virtual MyRadioButton BtnFilterEnabled_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFilterEnabled;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioButton.CheckEventHandler obj = (object a0, bool a1) =>
            {
                ChangeFilter((MyRadioButton)a0, a1);
            };
            MyRadioButton myRadioButton = _BtnFilterEnabled;
            if (myRadioButton != null)
            {
                myRadioButton.Check -= obj;
            }
            _BtnFilterEnabled = value;
            myRadioButton = _BtnFilterEnabled;
            if (myRadioButton != null)
            {
                myRadioButton.Check += obj;
            }
        }
    }

    internal virtual MyRadioButton BtnFilterDisabled_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFilterDisabled;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioButton.CheckEventHandler obj = (object a0, bool a1) =>
            {
                ChangeFilter((MyRadioButton)a0, a1);
            };
            MyRadioButton myRadioButton = _BtnFilterDisabled;
            if (myRadioButton != null)
            {
                myRadioButton.Check -= obj;
            }
            _BtnFilterDisabled = value;
            myRadioButton = _BtnFilterDisabled;
            if (myRadioButton != null)
            {
                myRadioButton.Check += obj;
            }
        }
    }

    internal virtual MyRadioButton BtnFilterCanUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFilterCanUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyRadioButton.CheckEventHandler obj = (object a0, bool a1) =>
            {
                ChangeFilter((MyRadioButton)a0, a1);
            };
            MyRadioButton myRadioButton = _BtnFilterCanUpdate;
            if (myRadioButton != null)
            {
                myRadioButton.Check -= obj;
            }
            _BtnFilterCanUpdate = value;
            myRadioButton = _BtnFilterCanUpdate;
            if (myRadioButton != null)
            {
                myRadioButton.Check += obj;
            }
        }
    }

    internal virtual StackPanel PanList_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanList;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanList = value;
        }
    }

    internal virtual MyCard PanEmpty_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanEmpty;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanEmpty = value;
        }
    }

    internal virtual MyButton BtnHintDownload_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnHintDownload;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageDownload_Click;
            MyButton myButton = _BtnHintDownload;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnHintDownload = value;
            myButton = _BtnHintDownload;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnHintInstall_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnHintInstall;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageInstall_Click;
            MyButton myButton = _BtnHintInstall;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnHintInstall = value;
            myButton = _BtnHintInstall;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnHintOpen_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnHintOpen;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnManageOpen_Click;
            MyButton myButton = _BtnHintOpen;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnHintOpen = value;
            myButton = _BtnHintOpen;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyCard PanLoad_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLoad;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLoad = value;
        }
    }

    internal virtual MyLoading Load_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _Load;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.ClickEventHandler obj = Load_Click;
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                UnselectedAllWithAnimation();
            };
            MyLoading myLoading = _Load;
            if (myLoading != null)
            {
                myLoading.Click -= obj;
                myLoading.StateChanged -= obj2;
            }
            _Load = value;
            myLoading = _Load;
            if (myLoading != null)
            {
                myLoading.Click += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyCard CardSelect_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardSelect;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardSelect = value;
        }
    }

    internal virtual TranslateTransform TransSelect_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TransSelect;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TransSelect = value;
        }
    }

    internal virtual TextBlock LabSelect_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabSelect;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabSelect = value;
        }
    }

    internal virtual MyIconTextButton BtnSelectUpdate_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSelectUpdate;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconTextButton.ClickEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                BtnSelectUpdate_Click();
            };
            MyIconTextButton myIconTextButton = _BtnSelectUpdate;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click -= obj;
            }
            _BtnSelectUpdate = value;
            myIconTextButton = _BtnSelectUpdate;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click += obj;
            }
        }
    }

    internal virtual MyIconTextButton BtnSelectEnable_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSelectEnable;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconTextButton.ClickEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                BtnSelectED_Click((MyIconTextButton)a0, a1);
            };
            MyIconTextButton myIconTextButton = _BtnSelectEnable;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click -= obj;
            }
            _BtnSelectEnable = value;
            myIconTextButton = _BtnSelectEnable;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click += obj;
            }
        }
    }

    internal virtual MyIconTextButton BtnSelectDisable_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSelectDisable;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconTextButton.ClickEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                BtnSelectED_Click((MyIconTextButton)a0, a1);
            };
            MyIconTextButton myIconTextButton = _BtnSelectDisable;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click -= obj;
            }
            _BtnSelectDisable = value;
            myIconTextButton = _BtnSelectDisable;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click += obj;
            }
        }
    }

    internal virtual MyIconTextButton BtnSelectDelete_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSelectDelete;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconTextButton.ClickEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                BtnSelectDelete_Click();
            };
            MyIconTextButton myIconTextButton = _BtnSelectDelete;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click -= obj;
            }
            _BtnSelectDelete = value;
            myIconTextButton = _BtnSelectDelete;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click += obj;
            }
        }
    }

    internal virtual MyIconTextButton BtnSelectCancel_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnSelectCancel;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconTextButton.ClickEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                BtnSelectCancel_Click();
            };
            MyIconTextButton myIconTextButton = _BtnSelectCancel;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click -= obj;
            }
            _BtnSelectCancel = value;
            myIconTextButton = _BtnSelectCancel;
            if (myIconTextButton != null)
            {
                myIconTextButton.Click += obj;
            }
        }
    }

    public PageInstanceMod()
    {
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            PageOther_Loaded();
        };
        Initialized += (object a0, EventArgs a1) =>
        {
            LoaderInit();
        };
        PageExit += UnselectedAllWithAnimation;
        IsLoad = false;
        ModItems = new ConcurrentDictionary<string, MyLocalModItem>();
        BottomBarShownCount = 0;
        SelectedMods = new List<string>();
        _Filter = FilterType.All;
        InitializeComponent();
        _InitWithEvents();
    }

    public void PageOther_Loaded()
    {
        if (ModMain.FrmMain.PageLast.Page != FormMain.PageType.ResourceDetail)
        {
            PanBack.ScrollToHome();
        }
        checked
        {
            ModAnimation.AniControlEnabled++;
            SelectedMods.Clear();
            ReloadModList();
            ChangeAllSelected(Value: false);
            ModAnimation.AniControlEnabled--;
            if (IsLoad)
            {
                return;
            }
            IsLoad = true;
            ModMain.FrmMain.KeyDown += FrmMain_KeyDown;
            foreach (MyRadioButton child in PanFilter.Children)
            {
                child.LabText.Margin = new Thickness(-2.0, 0.0, 8.0, 0.0);
            }
        }
    }

    public void ReloadModList(bool ForceReload = false)
    {
        if (LoaderRun(ForceReload ? ModLoader.LoaderFolderRunType.ForceRun : ModLoader.LoaderFolderRunType.RunOnUpdated))
        {
            Logger.Info("已刷新 Mod 列表", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            Filter = FilterType.All;
            PanBack.ScrollToHome();
            SearchBox.Text = "";
        }
    }

    private void RefreshSelf()
    {
        Refresh();
    }

    void IRefreshable.Refresh()
    {
        this.RefreshSelf();
    }

    public static void Refresh()
    {
        try
        {
            ResourceProject.Cache.Clear();
            ResourceVersion.ProjectFilesCache.Clear();
            FileUtils.Delete(ModBase.PathTemp + "Cache\\LocalMod.json", false);
            Logger.Info("由于点击刷新按钮，清理本地 Mod 信息缓存", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, "强制刷新时清理本地 Mod 信息缓存失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ProjectData.ClearProjectError();
        }
        if (ModMain.FrmInstanceMod != null)
        {
            ModMain.FrmInstanceMod.ReloadModList(ForceReload: true);
        }
        ModMain.FrmInstanceLeft.ItemMod.Checked = true;
        ModMain.Hint("正在刷新……", ModMain.HintType.Blue, Log: false);
    }

    private void LoaderInit()
    {
        PageLoaderInit(Load, PanLoad, PanAllBack, null, LocalResourceLoaders.LocalResourceLoader, (ModLoader.LoaderTask<string, List<LocalResourceFile>> a0) =>
        {
            LoadUIFromLoaderOutput();
        }, null, AutoRun: false);
    }

    private void Load_Click(object sender, MouseButtonEventArgs e)
    {
        if (LocalResourceLoaders.LocalResourceLoader.State == ModBase.LoadState.Failed)
        {
            LoaderRun(ModLoader.LoaderFolderRunType.ForceRun);
        }
    }

    public bool LoaderRun(ModLoader.LoaderFolderRunType Type)
    {
        return ModLoader.LoaderFolderRun(LocalResourceLoaders.LocalResourceLoader, PageInstanceLeft.Instance.PathIndie + "mods\\", Type);
    }

    private void LoadUIFromLoaderOutput()
    {
        try
        {
            if (LocalResourceLoaders.LocalResourceLoader.Output.Any())
            {
                PanBack.Visibility = Visibility.Visible;
                PanEmpty.Visibility = Visibility.Collapsed;
                ModItems.Clear();
                foreach (LocalResourceFile item in LocalResourceLoaders.LocalResourceLoader.Output)
                {
                    ModItems[item.EnabledName] = McModListItem(item);
                }
                Filter = FilterType.All;
                SearchBox.Text = "";
                RefreshUI();
            }
            else
            {
                PanEmpty.Visibility = Visibility.Visible;
                PanBack.Visibility = Visibility.Collapsed;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "加载 Mod 列表 UI 失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private MyLocalModItem McModListItem(LocalResourceFile Entry)
    {
        checked
        {
            ModAnimation.AniControlEnabled++;
            MyLocalModItem myLocalModItem = new MyLocalModItem
            {
                SnapsToDevicePixels = true,
                Entry = Entry,
                ButtonHandler = McModContent,
                Checked = SelectedMods.Contains(Entry.EnabledName)
            };
            Entry.OnUpdate += (LocalResourceFile a0) =>
            {
                ModBase.RunInUi(myLocalModItem.Refresh);
            };
            ModAnimation.AniControlEnabled--;
            return myLocalModItem;
        }
    }

    private void McModContent(MyLocalModItem sender, EventArgs e)
    {
        sender.Changed += (object a0, ModBase.RouteEventArgs a1) =>
        {
            CheckChanged((MyLocalModItem)a0, a1);
        };
        sender.Click += (object a0, MouseButtonEventArgs a1) =>
        {
            ((VB_0024AnonymousDelegate_16<MyLocalModItem, EventArgs>)((MyLocalModItem ss, EventArgs ee) =>
            {
                ss.Checked = !ss.Checked;
            }))((MyLocalModItem)a0, a1);
        };
        MyIconButton myIconButton = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z",
            Tag = sender
        };
        myIconButton.ToolTip = "打开文件位置";
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            Open_Click((MyIconButton)a0, a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.0,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            Tag = sender
        };
        myIconButton2.ToolTip = "详情";
        myIconButton2.Click += Info_Click;
        sender.MouseRightButtonUp += Info_Click;
        MyIconButton myIconButton3 = new MyIconButton
        {
            LogoScale = 1.0,
            Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z",
            Tag = sender
        };
        myIconButton3.ToolTip = "删除";
        myIconButton3.Click += (object a0, EventArgs a1) =>
        {
            Delete_Click((MyIconButton)a0, a1);
        };
        MyIconButton myIconButton4 = new MyIconButton
        {
            LogoScale = 1.0,
            Logo = (sender.Entry.IsEnabled ? "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z" : "M512 0a512 512 0 1 0 512 512A512 512 0 0 0 512 0z m0 921.6a409.6 409.6 0 1 1 409.6-409.6 409.6 409.6 0 0 1-409.6 409.6z M716.8 339.968l-256 253.44L328.192 460.8A51.2 51.2 0 0 0 256 532.992l168.448 168.96a51.2 51.2 0 0 0 72.704 0l289.28-289.792A51.2 51.2 0 0 0 716.8 339.968z"),
            Tag = sender
        };
        myIconButton4.ToolTip = (sender.Entry.IsEnabled ? "禁用" : "启用");
        myIconButton4.Click += (object a0, EventArgs a1) =>
        {
            ED_Click((MyIconButton)a0, a1);
        };
        sender.Buttons = new MyIconButton[4] { myIconButton2, myIconButton, myIconButton4, myIconButton3 };
    }

    public void RefreshUI()
    {
        if (PanList == null)
        {
            return;
        }
        List<LocalResourceFile> list = (IsSearching ? SearchResult : (LocalResourceLoaders.LocalResourceLoader.Output ?? new List<LocalResourceFile>())).Where((LocalResourceFile m) => CanPassFilter(m)).ToList();
        checked
        {
            ModAnimation.AniControlEnabled++;
            if (list.Any())
            {
                PanList.Visibility = Visibility.Visible;
                PanList.Children.Clear();
                foreach (LocalResourceFile item in list)
                {
                    MyLocalModItem value = null;
                    if (ModItems.TryGetValue(item.EnabledName, out value))
                    {
                        value.Checked = SelectedMods.Contains(item.EnabledName);
                        PanList.Children.Add(value);
                    }
                }
            }
            else
            {
                PanList.Visibility = Visibility.Collapsed;
            }
            ModAnimation.AniControlEnabled--;
            SelectedMods = SelectedMods.Where((string m) => list.Any((LocalResourceFile s) => Operators.CompareString(s.EnabledName, m, TextCompare: false) == 0)).ToList();
            RefreshBars();
        }
    }

    public void RefreshBars()
    {
        int num = 0;
        int num2 = 0;
        int num3 = 0;
        checked
        {
            foreach (LocalResourceFile item in IsSearching ? SearchResult : (LocalResourceLoaders.LocalResourceLoader.Output ?? new List<LocalResourceFile>()))
            {
                num++;
                if (item.HasUpdate)
                {
                    num3++;
                }
                if (item.IsEnabled)
                {
                    num2++;
                }
            }
            int num4 = num - num2;
            BtnFilterAll.Text = (IsSearching ? "搜索结果" : "全部") + $" ({num})";
            BtnFilterCanUpdate.Text = $"可更新 ({num3})";
            BtnFilterCanUpdate.Visibility = ((Filter != FilterType.CanUpdate && num3 <= 0) ? Visibility.Collapsed : Visibility.Visible);
            BtnFilterEnabled.Text = $"启用 ({num2})";
            BtnFilterEnabled.Visibility = ((Filter != FilterType.Enabled && (num2 <= 0 || num2 >= num)) ? Visibility.Collapsed : Visibility.Visible);
            BtnFilterDisabled.Text = $"禁用 ({num4})";
            BtnFilterDisabled.Visibility = ((Filter != FilterType.Disabled && num4 <= 0) ? Visibility.Collapsed : Visibility.Visible);
            int count = SelectedMods.Count;
            bool flag = count > 0;
            if (flag)
            {
                LabSelect.Text = $"已选择 {count} 个文件";
            }
            if (flag)
            {
                bool isEnabled = false;
                bool isEnabled2 = false;
                bool isEnabled3 = false;
                foreach (LocalResourceFile item2 in LocalResourceLoaders.LocalResourceLoader.Output)
                {
                    if (SelectedMods.Contains(item2.EnabledName))
                    {
                        if (item2.HasUpdate)
                        {
                            isEnabled = true;
                        }
                        if (item2.IsEnabled)
                        {
                            isEnabled2 = true;
                        }
                        if (!item2.IsEnabled)
                        {
                            isEnabled3 = true;
                        }
                    }
                }
                BtnSelectDisable.IsEnabled = isEnabled2;
                BtnSelectEnable.IsEnabled = isEnabled3;
                BtnSelectUpdate.IsEnabled = isEnabled;
            }
            if (ModAnimation.AniControlEnabled == 0)
            {
                PanListBack.Margin = new Thickness(0.0, 0.0, 0.0, flag ? 95 : 15);
                if (flag)
                {
                    if (BottomBarShownCount >= count)
                    {
                        BottomBarShownCount = count;
                        return;
                    }
                    BottomBarShownCount = count;
                    CardSelect.Visibility = Visibility.Visible;
                    ModAnimation.AniStart(new ModAnimation.AniData[4]
                    {
                        ModAnimation.AaOpacity(CardSelect, 1.0 - CardSelect.Opacity, 60),
                        ModAnimation.AaTranslateY(CardSelect, -27.0 - TransSelect.Y, 120, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaTranslateY(CardSelect, 3.0, 150, 120, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaTranslateY(CardSelect, -1.0, 90, 270, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak))
                    }, "Mod Sidebar");
                }
                else if (BottomBarShownCount != 0)
                {
                    BottomBarShownCount = 0;
                    ModAnimation.AniStart(new ModAnimation.AniData[3]
                    {
                        ModAnimation.AaOpacity(CardSelect, 0.0 - CardSelect.Opacity, 90),
                        ModAnimation.AaTranslateY(CardSelect, -10.0 - TransSelect.Y, 90, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
                        ModAnimation.AaCode(() =>
                        {
                            CardSelect.Visibility = Visibility.Collapsed;
                        }, 0, After: true)
                    }, "Mod Sidebar");
                }
            }
            else
            {
                ModAnimation.AniStop("Mod Sidebar");
                BottomBarShownCount = count;
                if (flag)
                {
                    CardSelect.Visibility = Visibility.Visible;
                    CardSelect.Opacity = 1.0;
                    TransSelect.Y = -25.0;
                }
                else
                {
                    CardSelect.Visibility = Visibility.Collapsed;
                    CardSelect.Opacity = 0.0;
                    TransSelect.Y = -10.0;
                }
            }
        }
    }

    private void BtnManageOpen_Click(object sender, EventArgs e)
    {
        try
        {
            DirectoryUtils.Create(PageInstanceLeft.Instance.PathIndie + "mods\\");
            ModBase.OpenExplorer(PageInstanceLeft.Instance.PathIndie + "mods\\");
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "打开 Mods 文件夹失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void BtnManageSelectAll_Click(object sender, MouseButtonEventArgs e)
    {
        ChangeAllSelected(SelectedMods.Count < PanList.Children.Count);
    }

    private void BtnManageInstall_Click(object sender, MouseButtonEventArgs e)
    {
        List<string> list = Dialogs.SelectFile("选择要安装的 Mod", true, (string)null, (OneOf<IEnumerable<(string[], string)>, string>)(new (string[], string)[1] { (new string[4] { "jar", "litemod", "disabled", "old" }, "Mod 文件") }));
        if (list.Any())
        {
            InstallMods(list);
        }
    }

    public static bool InstallMods(IEnumerable<string> FilePathList)
    {
        string right = StringExtensions.Lower(StringExtensions.AfterLast(FilePathList.First(), ".", false));
        if (!new string[4] { "jar", "litemod", "disabled", "old" }.Any((string t) => Operators.CompareString(t, right, TextCompare: false) == 0))
        {
            return false;
        }
        Logger.Info("文件为 jar/litemod 格式，尝试作为 Mod 安装", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
        if (FilePathList.First().Contains(":\\$RECYCLE.BIN\\"))
        {
            ModMain.Hint("请先将文件从回收站还原，再尝试安装！", ModMain.HintType.Red);
            return true;
        }
        ModMinecraft.McInstance mcInstance = ModMinecraft.McInstanceSelected;
        if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup)
        {
            mcInstance = PageInstanceLeft.Instance;
        }
        if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect || (object)mcInstance == null || !mcInstance.Modable)
        {
            ModMain.Hint("若要安装 Mod，请先选择一个可以安装 Mod 的版本！");
        }
        else if ((ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadMod) || ModMain.MyMsgBox(string.Format("是否要将这{0}文件作为 Mod 安装到 {1}？", EnumerableExtensions.IsSingle<string>(FilePathList) ? "个" : "些", mcInstance.Name), "Mod 安装确认", "确定", "取消") == 1)
        {
            try
            {
                foreach (string FilePath in FilePathList)
                {
                    string text = PathUtils.GetLastPart(FilePath).Replace(".disabled", "").Replace(".old", "");
                    if (!text.Contains("."))
                    {
                        text += ".jar";
                    }
                    text = mcInstance.PathIndie + "mods\\" + text;
                    if (Operators.CompareString(FilePath, text, TextCompare: false) != 0)
                    {
                        FileUtils.Delete(text, true);
                        FileUtils.Copy(FilePath, text);
                    }
                }
                if (EnumerableExtensions.IsSingle<string>(FilePathList))
                {
                    ModMain.Hint(string.Format("已安装 {0}！", PathUtils.GetLastPart(FilePathList.First()).Replace(".disabled", "").Replace(".old", "")), ModMain.HintType.Green);
                }
                else
                {
                    ModMain.Hint($"已安装 {FilePathList.Count()} 个 Mod！", ModMain.HintType.Green);
                }
                if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadMod)
                {
                    ModLoader.LoaderFolderRun(LocalResourceLoaders.LocalResourceLoader, mcInstance.PathIndie + "mods\\", ModLoader.LoaderFolderRunType.ForceRun);
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "复制 Mod 文件失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
        return true;
    }

    private void BtnManageDownload_Click(object sender, MouseButtonEventArgs e)
    {
        PageResource.TargetInstance = PageInstanceLeft.Instance;
        PageResource.TargetName = SearchBox.Text;
        ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadMod);
    }

    public void CheckChanged(MyLocalModItem sender, ModBase.RouteEventArgs e)
    {
        if (ModAnimation.AniControlEnabled != 0)
        {
            return;
        }
        string enabledName = sender.Entry.EnabledName;
        if (sender.Checked)
        {
            if (!SelectedMods.Contains(enabledName))
            {
                SelectedMods.Add(enabledName);
            }
        }
        else
        {
            SelectedMods.Remove(enabledName);
        }
        RefreshBars();
    }

    private void ChangeAllSelected(bool Value)
    {
        checked
        {
            ModAnimation.AniControlEnabled++;
            SelectedMods.Clear();
            foreach (MyLocalModItem value in ModItems.Values)
            {
                if (value.Checked = Value && PanList.Children.Contains(value))
                {
                    SelectedMods.Add(value.Entry.EnabledName);
                }
            }
            ModAnimation.AniControlEnabled--;
            RefreshBars();
        }
    }

    private void UnselectedAllWithAnimation()
    {
        int aniControlEnabled = ModAnimation.AniControlEnabled;
        ModAnimation.AniControlEnabled = 0;
        ChangeAllSelected(Value: false);
        checked
        {
            ModAnimation.AniControlEnabled += aniControlEnabled;
        }
    }

    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
        if (ModMain.FrmMain.PageRight == this && MyWpfExtension.Computer.Keyboard.CtrlKeyDown && e.Key == Key.A)
        {
            ChangeAllSelected(Value: true);
        }
    }

    private void SearchBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (!SearchBox.Text.Any() && MyWpfExtension.Computer.Keyboard.CtrlKeyDown && e.Key == Key.A)
        {
            PanBack.Focus();
        }
    }

    private bool CanPassFilter(LocalResourceFile CheckingMod)
    {
        return Filter switch
        {
            FilterType.All => true,
            FilterType.Enabled => CheckingMod.IsEnabled,
            FilterType.Disabled => !CheckingMod.IsEnabled,
            FilterType.CanUpdate => CheckingMod.HasUpdate,
            _ => false,
        };
    }

    private void ChangeFilter(MyRadioButton sender, bool raiseByMouse)
    {
        Filter = (FilterType)Conversions.ToInteger(sender.Tag);
        RefreshUI();
    }

    private void BtnSelectED_Click(MyIconTextButton sender, ModBase.RouteEventArgs e)
    {
        EDMods(LocalResourceLoaders.LocalResourceLoader.Output.Where((LocalResourceFile m) => SelectedMods.Contains(m.EnabledName)), !sender.Equals(BtnSelectDisable));
        ChangeAllSelected(Value: false);
    }

    private void EDMods(IEnumerable<LocalResourceFile> ModList, bool IsEnable)
    {
        bool flag = true;
        _Closure_0024__36_002D0 obj = default;
        foreach (LocalResourceFile item in ModList.ToList())
        {
            obj = new _Closure_0024__36_002D0(obj);
            obj._0024VB_0024Local_ModEntity = item;
            string text = null;
            if (obj._0024VB_0024Local_ModEntity.IsEnabled && !IsEnable)
            {
                text = PathUtils.RemoveExtendedPrefix(obj._0024VB_0024Local_ModEntity.File.FullName) + (FileUtils.Exists(obj._0024VB_0024Local_ModEntity.File.FullName + ".old") ? ".old" : ".disabled");
            }
            else
            {
                if (obj._0024VB_0024Local_ModEntity.IsEnabled || !IsEnable)
                {
                    continue;
                }
                text = obj._0024VB_0024Local_ModEntity.EnabledFullName;
            }
            try
            {
                if (!FileUtils.Exists(text))
                {
                    goto IL_0189;
                }
                if (FileUtils.Exists(obj._0024VB_0024Local_ModEntity.File.FullName))
                {
                    if (Operators.CompareString(CryptographyUtils.ComputeFileHash(obj._0024VB_0024Local_ModEntity.File.FullName, (MeloongCore.CryptographyUtils.HashMethod)0), CryptographyUtils.ComputeFileHash(text, (MeloongCore.CryptographyUtils.HashMethod)0), TextCompare: false) == 0)
                    {
                        goto IL_0189;
                    }
                    ModMain.MyMsgBox(string.Format("目前同时存在启用和禁用的两个 Mod 文件：{0} - {1}{2} - {3}{4}{5}注意，这两个文件的内容并不相同。{6}在手动删除或重命名其中一个文件后，才能继续操作。", "\r\n", PathUtils.GetLastPart(text), "\r\n", obj._0024VB_0024Local_ModEntity.File.Name, "\r\n", "\r\n", "\r\n"), "存在文件冲突");
                }
                else
                {
                    Logger.Warn("Mod 的状态已被切换", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                }
                continue;
            IL_0189:
                FileUtils.Move(obj._0024VB_0024Local_ModEntity.File.FullName, text);
                goto IL_022f;
            }
            catch (FileNotFoundException ex)
            {
                ProjectData.SetProjectError(ex);
                FileNotFoundException ex2 = ex;
                Logger.Error((Exception)ex2, string.Format("未找到需要重命名的 Mod（{0}）", obj._0024VB_0024Local_ModEntity.File.FullName ?? "null"), (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                ReloadModList(ForceReload: true);
                ProjectData.ClearProjectError();
                return;
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, string.Format("重命名 Mod 失败（{0}）", obj._0024VB_0024Local_ModEntity.File.FullName ?? "null"), (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                flag = false;
                ProjectData.ClearProjectError();
                goto IL_022f;
            }
            continue;
        IL_022f:
            LocalResourceFile localResourceFile = new LocalResourceFile(text);
            localResourceFile.FromJson(obj._0024VB_0024Local_ModEntity.ToJson());
            if (LocalResourceLoaders.LocalResourceLoader.Output.Contains(obj._0024VB_0024Local_ModEntity))
            {
                int index = LocalResourceLoaders.LocalResourceLoader.Output.IndexOf(obj._0024VB_0024Local_ModEntity);
                LocalResourceLoaders.LocalResourceLoader.Output.RemoveAt(index);
                LocalResourceLoaders.LocalResourceLoader.Output.Insert(index, localResourceFile);
            }
            if (SearchResult != null && SearchResult.Contains(obj._0024VB_0024Local_ModEntity))
            {
                int index2 = SearchResult.IndexOf(obj._0024VB_0024Local_ModEntity);
                SearchResult.Remove(obj._0024VB_0024Local_ModEntity);
                SearchResult.Insert(index2, localResourceFile);
            }
            MyLocalModItem myLocalModItem = McModListItem(localResourceFile);
            ModItems[obj._0024VB_0024Local_ModEntity.EnabledName] = myLocalModItem;
            int num = PanList.Children.IndexOf(PanList.Children.OfType<MyLocalModItem>().FirstOrDefault(obj._Lambda_0024__0));
            if (num != -1)
            {
                PanList.Children.RemoveAt(num);
                PanList.Children.Insert(num, myLocalModItem);
                myLocalModItem.UpdateLayout();
            }
        }
        if (flag)
        {
            RefreshBars();
        }
        else
        {
            ModMain.Hint("由于文件被占用，Mod 的状态切换失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Red);
            ReloadModList(ForceReload: true);
        }
        LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
    }

    private void BtnSelectUpdate_Click()
    {
        List<LocalResourceFile> list = LocalResourceLoaders.LocalResourceLoader.Output.Where((LocalResourceFile m) => SelectedMods.Contains(m.EnabledName) && m.HasUpdate).ToList();
        if (list.Any())
        {
            UpdateMods(list);
            ChangeAllSelected(Value: false);
        }
    }

    public void UpdateMods(IEnumerable<LocalResourceFile> ModList)
    {
        if (!Settings.Get<bool>("HintUpdateMod") || ModList.Count() >= 15)
        {
            if (ModMain.MyMsgBox(string.Format("新版本 Mod 可能不兼容旧存档或者其他 Mod，这可能导致游戏崩溃，甚至永久损坏存档！{0}如果你在游玩整合包，请千万不要自行更新 Mod！{1}{2}在更新前，请先备份存档，并检查 Mod 的更新日志。{3}如果更新后出现问题，你也可以在回收站找回更新前的 Mod。", "\r\n", "\r\n", "\r\n", "\r\n"), "Mod 更新警告", "我已了解风险，继续更新", "取消", "", IsWarn: true) != 1)
            {
                return;
            }
            Settings.Set("HintUpdateMod", true);
        }
        checked
        {
            try
            {
                ModList = ModList.ToList();
                List<ModNet.NetFile> list = new List<ModNet.NetFile>();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (LocalResourceFile Mod in ModList)
                {
                    ResourceVersion updateFile = Mod.UpdateFile;
                    if (updateFile.DownloadAvailable)
                    {
                        string text = Mod.ProjectVersion.FileName.Replace(".jar", "").Replace(".old", "").Replace(".disabled", "");
                        string text2 = Mod.UpdateFile.FileName.Replace(".jar", "").Replace(".old", "").Replace(".disabled", "");
                        List<string> list2 = text.Split('-').ToList();
                        List<string> list3 = text2.Split('-').ToList();
                        bool flag = false;
                        while (list2.Any() && list3.Any() && Operators.CompareString(list2.First(), list3.First(), TextCompare: false) == 0)
                        {
                            list2.RemoveAt(0);
                            list3.RemoveAt(0);
                            flag = true;
                        }
                        while (list2.Any() && list3.Any() && Operators.CompareString(list2.Last(), list3.Last(), TextCompare: false) == 0)
                        {
                            list2.RemoveAt(list2.Count - 1);
                            list3.RemoveAt(list3.Count - 1);
                            flag = true;
                        }
                        if (flag && list2.Any() && list3.Any())
                        {
                            text = EnumerableExtensions.Join((IEnumerable)list2, "-");
                            text2 = EnumerableExtensions.Join((IEnumerable)list3, "-");
                        }
                        string text3 = ModBase.PathTemp + "mods\\" + Mod.File.Name.Replace(text, text2);
                        string value = Path.Combine(PathUtils.RemoveLastPart(Mod.File.FullName), Mod.File.Name.Replace(text, text2));
                        list.Add(updateFile.ToNetFile(text3, ResourceVersion.DownloadReason.Update, PageInstanceLeft.Instance.Version.VanillaName, PageInstanceLeft.Instance.Version.ModLoaders));
                        dictionary[text3] = value;
                    }
                }
                List<ModLoader.LoaderBase> list4 = new List<ModLoader.LoaderBase>();
                List<string> list5 = new List<string>();
                list4.Add(new ModNet.LoaderDownload("下载新版 Mod 文件", list)
                {
                    ProgressWeight = (double)ModList.Count() * 1.5
                });
                list4.Add(new ModLoader.LoaderTask<int, int>("替换旧版 Mod 文件", (Action<ModLoader.LoaderTask<int, int>>)((ModLoader.LoaderTask<int, int> a0) =>
                {
                    try
                    {
                        foreach (LocalResourceFile Mod2 in ModList)
                        {
                            if (FileUtils.Exists(Mod2.File.FullName))
                            {
                                FileUtils.Delete(Mod2.File.FullName, true);
                            }
                            else
                            {
                                Logger.Warn($"未找到更新前的 Mod 文件，跳过对它的删除：{Mod2.File.FullName}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                            }
                        }
                        foreach (KeyValuePair<string, string> item in dictionary)
                        {
                            if (DirectoryUtils.Exists(PathUtils.RemoveLastPart(item.Value)))
                            {
                                FileUtils.Move(item.Key, item.Value);
                                list5.Add(PathUtils.GetLastPart(item.Value));
                            }
                            else
                            {
                                Logger.Warn($"更新后的目标文件夹已被删除：{item.Value}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                            }
                        }
                    }
                    catch (OperationCanceledException ex3)
                    {
                        ProjectData.SetProjectError(ex3);
                        OperationCanceledException ex4 = ex3;
                        Logger.Warn((Exception)ex4, "替换旧版 Mod 文件时被主动取消", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                        ProjectData.ClearProjectError();
                    }
                }), (Func<int>)null, ThreadPriority.Normal));
                ModLoader.LoaderCombo<IEnumerable<LocalResourceFile>> loaderCombo = new ModLoader.LoaderCombo<IEnumerable<LocalResourceFile>>("Mod 更新：" + PageInstanceLeft.Instance.Name, list4);
                string text4 = PageInstanceLeft.Instance.PathIndie + "mods\\";
                loaderCombo.OnStateChanged = (ModLoader.LoaderBase a0) =>
                {
                    switch (loaderCombo.State)
                    {
                        default:
                            return;
                        case ModBase.LoadState.Finished:
                            switch (list5.Count)
                            {
                                case 0:
                                    Logger.Info("没有 Mod 被成功更新", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                                    break;
                                case 1:
                                    ModMain.Hint($"已成功更新 {list5.Single()}！", ModMain.HintType.Green);
                                    break;
                                default:
                                    ModMain.Hint($"已成功更新 {list5.Count} 个 Mod！", ModMain.HintType.Green);
                                    break;
                            }
                            break;
                        case ModBase.LoadState.Failed:
                            ModMain.Hint("Mod 更新失败：" + ExceptionExtensions.GetDisplay(loaderCombo.Error, false), ModMain.HintType.Red);
                            break;
                        case ModBase.LoadState.Canceled:
                            ModMain.Hint("Mod 更新已中止！");
                            break;
                    }
                    Logger.Info($"已从正在进行 Mod 更新的文件夹列表移除：{text4}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                    UpdatingInstanceModFolders.Remove(text4);
                    ModBase.RunInNewThread(() =>
                    {
                        try
                        {
                            foreach (string key in dictionary.Keys)
                            {
                                FileUtils.Delete(key, false);
                            }
                        }
                        catch (Exception ex3)
                        {
                            ProjectData.SetProjectError(ex3);
                            Exception ex4 = ex3;
                            Logger.Warn(ex4, "清理 Mod 更新缓存失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                            ProjectData.ClearProjectError();
                        }
                    }, "Clean Mod Update Cache", ThreadPriority.BelowNormal);
                };
                Logger.Info(string.Format("开始更新 {0} 个 Mod：{1}", ModList.Count(), EnumerableExtensions.Join((IEnumerable)ModList.Select((LocalResourceFile m) => m.File.Name), "，")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                UpdatingInstanceModFolders.Add(text4);
                loaderCombo.Start();
                ModLoader.LoaderTaskbarAdd(loaderCombo);
                ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
                ModMain.FrmMain.BtnExtraDownload.Ribble();
                ReloadModList(ForceReload: true);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "初始化 Mod 更新失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    private void BtnSelectDelete_Click()
    {
        DeleteMods(LocalResourceLoaders.LocalResourceLoader.Output.Where((LocalResourceFile m) => SelectedMods.Contains(m.EnabledName)));
        ChangeAllSelected(Value: false);
    }

    private void DeleteMods(IEnumerable<LocalResourceFile> ModsToDelete)
    {
        try
        {
            bool flag = true;
            bool shiftKeyDown = MyWpfExtension.Computer.Keyboard.ShiftKeyDown;
            List<LocalResourceFile> list = (from m in ModsToDelete.SelectMany((LocalResourceFile Target) => Target.IsEnabled ? new string[2]
                {
                    Target.File.FullName,
                    Target.File.FullName + (FileUtils.Exists(Target.File.FullName + ".old") ? ".old" : ".disabled")
                } : new string[2]
                {
                    Target.File.FullName,
                    Target.EnabledFullName
                }).Distinct()
                                            where FileUtils.Exists(m)
                                            select new LocalResourceFile(m)).ToList();
            using (List<LocalResourceFile>.Enumerator enumerator = list.GetEnumerator())
            {
                _Closure_0024__41_002D0 obj = default;
                while (enumerator.MoveNext())
                {
                    obj = new _Closure_0024__41_002D0(obj);
                    obj._0024VB_0024Local_ModEntity = enumerator.Current;
                    try
                    {
                        FileUtils.Delete(obj._0024VB_0024Local_ModEntity.File.FullName, !shiftKeyDown);
                    }
                    catch (OperationCanceledException ex)
                    {
                        ProjectData.SetProjectError(ex);
                        OperationCanceledException ex2 = ex;
                        Logger.Warn((Exception)ex2, "删除 Mod 被主动取消", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                        ReloadModList(ForceReload: true);
                        ProjectData.ClearProjectError();
                        return;
                    }
                    catch (Exception ex3)
                    {
                        ProjectData.SetProjectError(ex3);
                        Exception ex4 = ex3;
                        Logger.Error(ex4, $"删除 Mod 失败（{obj._0024VB_0024Local_ModEntity.File.FullName}）", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                        flag = false;
                        ProjectData.ClearProjectError();
                    }
                    SelectedMods.Remove(obj._0024VB_0024Local_ModEntity.EnabledName);
                    LocalResourceLoaders.LocalResourceLoader.Output.Remove(obj._0024VB_0024Local_ModEntity);
                    SearchResult?.Remove(obj._0024VB_0024Local_ModEntity);
                    EnumerableExtensions.Remove<string, MyLocalModItem>(ModItems, obj._0024VB_0024Local_ModEntity.EnabledName);
                    int num = PanList.Children.IndexOf(PanList.Children.OfType<MyLocalModItem>().FirstOrDefault(obj._Lambda_0024__3));
                    if (num >= 0)
                    {
                        PanList.Children.RemoveAt(num);
                    }
                }
            }
            RefreshBars();
            if (!flag)
            {
                ModMain.Hint("由于文件被占用，Mod 删除失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Red);
                ReloadModList(ForceReload: true);
            }
            else if (PanList.Children.Count == 0)
            {
                ReloadModList(ForceReload: true);
            }
            else
            {
                RefreshBars();
            }
            if (!flag)
            {
                return;
            }
            if (EnumerableExtensions.IsSingle<LocalResourceFile>((IEnumerable<LocalResourceFile>)list))
            {
                ModMain.Hint($"已删除 {list.Single().File.Name}！", ModMain.HintType.Green);
            }
            else
            {
                ModMain.Hint($"已删除 {list.Count} 个文件！", ModMain.HintType.Green);
            }
        }
        catch (OperationCanceledException ex5)
        {
            ProjectData.SetProjectError(ex5);
            OperationCanceledException ex6 = ex5;
            Logger.Warn((Exception)ex6, "删除 Mod 被主动取消", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ReloadModList(ForceReload: true);
            ProjectData.ClearProjectError();
        }
        catch (Exception ex7)
        {
            ProjectData.SetProjectError(ex7);
            Exception ex8 = ex7;
            Logger.Error(ex8, "删除 Mod 出现未知错误", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ReloadModList(ForceReload: true);
            ProjectData.ClearProjectError();
        }
        LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
    }

    private void BtnSelectCancel_Click()
    {
        ChangeAllSelected(Value: false);
    }

    public void Info_Click(object sender, EventArgs e)
    {
        checked
        {
            try
            {
                LocalResourceFile entry = ((MyLocalModItem)((sender is MyIconButton) ? NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) : sender)).Entry;
                if ((object)entry.Project != null)
                {
                    ModMain.FrmMain.PageChange(new FormMain.PageStackData
                    {
                        Page = FormMain.PageType.ResourceDetail,
                        Additional = new object[5]
                        {
                            entry.Project,
                            new List<string>(),
                            PageInstanceLeft.Instance.Version.VanillaName,
                            PageInstanceLeft.Instance.Version.ModLoaders,
                            (object)(ResourceTypes)1
                        }
                    });
                    return;
                }
                List<string> list = new List<string>();
                if (entry.Description != null)
                {
                    list.Add(entry.Description + "\r\n");
                }
                list.Add("文件：" + entry.File.Name + "（" + StringUtils.FormatByteSize(entry.File.Length) + "）");
                if (entry.Version != null)
                {
                    list.Add("版本：" + entry.Version);
                }
                List<string> list2 = new List<string>();
                if (list2.Any())
                {
                    list.Add("");
                    list.AddRange(list2);
                }
                string text = entry.Display.Replace(" ", "+");
                string text2 = text.Substring(0, 1);
                int num = text.Count() - 1;
                for (int i = 1; i <= num; i++)
                {
                    bool flag = StringExtensions.Lower(text[i - 1].ToString()).Equals(text[i - 1].ToString());
                    bool flag2 = StringExtensions.Lower(text[i].ToString()).Equals(text[i].ToString());
                    if (flag && !flag2)
                    {
                        text2 += "+";
                    }
                    text2 += Conversions.ToString(text[i]);
                }
                text2 = text2.Replace("++", "+").Replace("pti+Fine", "ptiFine");
                if (ModMain.MyMsgBox(EnumerableExtensions.Join((IEnumerable)list, "\r\n"), entry.Display, "百科搜索", "返回") == 1)
                {
                    ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "获取 Mod 详情失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    public void Open_Click(MyIconButton sender, EventArgs e)
    {
        try
        {
            ModBase.OpenExplorer(((MyLocalModItem)sender.Tag).Entry.File.FullName);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "打开 Mod 文件位置失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Delete_Click(MyIconButton sender, EventArgs e)
    {
        MyLocalModItem myLocalModItem = (MyLocalModItem)sender.Tag;
        DeleteMods(new LocalResourceFile[1] { myLocalModItem.Entry });
    }

    public void ED_Click(MyIconButton sender, EventArgs e)
    {
        MyLocalModItem myLocalModItem = (MyLocalModItem)sender.Tag;
        EDMods(new LocalResourceFile[1] { myLocalModItem.Entry }, !myLocalModItem.Entry.IsEnabled);
    }

    public void SearchRun()
    {
        if (IsSearching)
        {
            List<ModBase.SearchEntry<LocalResourceFile>> list = new List<ModBase.SearchEntry<LocalResourceFile>>();
            foreach (LocalResourceFile item in LocalResourceLoaders.LocalResourceLoader.Output)
            {
                List<ModBase.SearchSource> list2 = new List<ModBase.SearchSource>();
                list2.Add(new ModBase.SearchSource(item.Display));
                list2.Add(new ModBase.SearchSource(item.File.Name));
                if (item.Version != null)
                {
                    list2.Add(new ModBase.SearchSource(item.Version, 0.2));
                }
                if (item.Description != null && Operators.CompareString(item.Description, "", TextCompare: false) != 0)
                {
                    list2.Add(new ModBase.SearchSource(item.Description, 0.4));
                }
                if ((object)item.Project != null)
                {
                    if (Operators.CompareString(item.Project.RawName, item.Display, TextCompare: false) != 0)
                    {
                        list2.Add(new ModBase.SearchSource(item.Project.RawName));
                    }
                    if (Operators.CompareString(item.Project.TranslatedName, item.Project.RawName, TextCompare: false) != 0)
                    {
                        list2.Add(new ModBase.SearchSource(item.Project.TranslatedName));
                    }
                    if (Operators.CompareString(item.Project.Description, item.Description, TextCompare: false) != 0)
                    {
                        list2.Add(new ModBase.SearchSource(item.Project.Description, 0.4));
                    }
                    list2.Add(new ModBase.SearchSource(string.Join("", item.Project.Tags), 0.2));
                }
                list.Add(new ModBase.SearchEntry<LocalResourceFile>
                {
                    Item = item,
                    SearchSource = list2
                });
            }
            SearchResult = (from r in ModBase.Search(list, SearchBox.Text, 6, 0.35)
                            select r.Item).ToList();
        }
        RefreshUI();
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnFilterAll_WithEvents = BtnFilterAll;
        BtnFilterCanUpdate_WithEvents = BtnFilterCanUpdate;
        BtnFilterDisabled_WithEvents = BtnFilterDisabled;
        BtnFilterEnabled_WithEvents = BtnFilterEnabled;
        BtnHintDownload_WithEvents = BtnHintDownload;
        BtnHintInstall_WithEvents = BtnHintInstall;
        BtnHintOpen_WithEvents = BtnHintOpen;
        BtnManageDownload_WithEvents = BtnManageDownload;
        BtnManageInstall_WithEvents = BtnManageInstall;
        BtnManageOpen_WithEvents = BtnManageOpen;
        BtnManageSelectAll_WithEvents = BtnManageSelectAll;
        BtnSelectCancel_WithEvents = BtnSelectCancel;
        BtnSelectDelete_WithEvents = BtnSelectDelete;
        BtnSelectDisable_WithEvents = BtnSelectDisable;
        BtnSelectEnable_WithEvents = BtnSelectEnable;
        BtnSelectUpdate_WithEvents = BtnSelectUpdate;
        CardSelect_WithEvents = CardSelect;
        LabSelect_WithEvents = LabSelect;
        Load_WithEvents = Load;
        PanAllBack_WithEvents = PanAllBack;
        PanBack_WithEvents = PanBack;
        PanEmpty_WithEvents = PanEmpty;
        PanFilter_WithEvents = PanFilter;
        PanList_WithEvents = PanList;
        PanListBack_WithEvents = PanListBack;
        PanLoad_WithEvents = PanLoad;
        PanMain_WithEvents = PanMain;
        PanManage_WithEvents = PanManage;
        SearchBox_WithEvents = SearchBox;
        TransSelect_WithEvents = TransSelect;
    }
}

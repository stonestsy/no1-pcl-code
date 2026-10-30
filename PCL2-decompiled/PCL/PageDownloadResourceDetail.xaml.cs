using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadResourceDetail : MyPageRight, IComponentConnector
{
    private class CardSorter : IComparer<string>
    {
        public string Topmost;

        public int Compare(string x, string y)
        {
            if (Operators.CompareString(x, y, TextCompare: false) == 0)
            {
                return 0;
            }
            if (Operators.CompareString(x, Topmost, TextCompare: false) == 0)
            {
                return -1;
            }
            if (Operators.CompareString(y, Topmost, TextCompare: false) == 0)
            {
                return 1;
            }
            bool flag = !x.Contains(".");
            bool flag2 = !y.Contains(".");
            if (flag && flag2)
            {
                return x.CompareTo(y);
            }
            if (flag)
            {
                return 1;
            }
            if (flag2)
            {
                return -1;
            }
            checked
            {
                int num = -ModMinecraft.CompareVersion(x.Replace(StringExtensions.BeforeFirst(x, " ", false) + " ", ""), y.Replace(StringExtensions.BeforeFirst(y, " ", false) + " ", ""));
                if (num != 0)
                {
                    return num;
                }
                return -ModMinecraft.CompareVersion(x, y);
            }
        }

        int IComparer<string>.Compare(string x, string y)
        {
            return this.Compare(x, y);
        }

        public CardSorter(string Topmost = "")
        {
            this.Topmost = "";
            this.Topmost = Topmost ?? "";
        }
    }

    private MyResourceItem ResourceItem;

    private ResourceTypes TargetResourceType;

    private ResourceProject Project;

    private string TargetVersion;

    private ModLoaders TargetLoaders;

    private ModLoader.LoaderTask<int, List<ResourceVersion>> ResourceFileLoader;

    private string VersionFilter;

    private bool GroupedDrop;

    private bool GroupedOld;

    private bool IsFirstInit;

    public static Dictionary<ResourceTypes, string> CachedFolder = new Dictionary<ResourceTypes, string>();

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("CardIntro")]
    private MyCard _CardIntro;

    [CompilerGenerated]
    [AccessedThroughProperty("PanIntro")]
    private StackPanel _PanIntro;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnIntroWeb")]
    private MyButton _BtnIntroWeb;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnIntroWiki")]
    private MyButton _BtnIntroWiki;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnIntroCopy")]
    private MyButton _BtnIntroCopy;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMain")]
    private StackPanel _PanMain;

    [CompilerGenerated]
    [AccessedThroughProperty("HintAlternative")]
    private MyHint _HintAlternative;

    [CompilerGenerated]
    [AccessedThroughProperty("CardFilter")]
    private MyCard _CardFilter;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFilter")]
    private StackPanel _PanFilter;

    [CompilerGenerated]
    [AccessedThroughProperty("PanResults")]
    private StackPanel _PanResults;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLoad")]
    private MyCard _PanLoad;

    [CompilerGenerated]
    [AccessedThroughProperty("Load")]
    private MyLoading _Load;

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

    internal virtual MyCard CardIntro_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardIntro;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardIntro = value;
        }
    }

    internal virtual StackPanel PanIntro_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanIntro;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanIntro = value;
        }
    }

    internal virtual MyButton BtnIntroWeb_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnIntroWeb;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnIntroWeb_Click;
            MyButton myButton = _BtnIntroWeb;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnIntroWeb = value;
            myButton = _BtnIntroWeb;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnIntroWiki_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnIntroWiki;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnIntroWiki_Click;
            MyButton myButton = _BtnIntroWiki;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnIntroWiki = value;
            myButton = _BtnIntroWiki;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnIntroCopy_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnIntroCopy;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = BtnIntroCopy_Click;
            MyButton myButton = _BtnIntroCopy;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnIntroCopy = value;
            myButton = _BtnIntroCopy;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
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

    internal virtual MyHint HintAlternative_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintAlternative;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyHint.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                HintAlternative_Click();
            };
            MyHint myHint = _HintAlternative;
            if (myHint != null)
            {
                myHint.Click -= obj;
            }
            _HintAlternative = value;
            myHint = _HintAlternative;
            if (myHint != null)
            {
                myHint.Click += obj;
            }
        }
    }

    internal virtual MyCard CardFilter_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardFilter;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CardFilter = value;
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

    internal virtual StackPanel PanResults_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanResults;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanResults = value;
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
            MyLoading.StateChangedEventHandler obj = Load_State;
            MyLoading myLoading = _Load;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
            }
            _Load = value;
            myLoading = _Load;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
            }
        }
    }

    public PageDownloadResourceDetail()
    {
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            LoadPageArguments();
        };
        Initialized += PageDownloadResourceDetail_Inited;
        PageEnter += Init;
        ResourceItem = null;
        ResourceFileLoader = new ModLoader.LoaderTask<int, List<ResourceVersion>>("Resource File", (ModLoader.LoaderTask<int, List<ResourceVersion>> Task) =>
        {
            LoadPageArguments();
            List<ResourceVersion> output = ResourceVersion.FromProjectId(Project.Id, Project.Platform);
            if (!Task.IsCanceled)
            {
                Task.Output = output;
            }
        });
        IsFirstInit = true;
        InitializeComponent();
        _InitWithEvents();
    }

    public void LoadPageArguments()
    {
        Project = (ResourceProject)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 0 }, null);
        TargetVersion = Conversions.ToString(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 2 }, null));
        TargetLoaders = (ModLoaders)Conversions.ToInteger(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 3 }, null));
        if ((int)TargetLoaders != 0 && !EnumerableExtensions.IsSingle<ModLoaders>(EnumerableExtensions.Flags<ModLoaders>(TargetLoaders)))
        {
            TargetLoaders = EnumerableExtensions.Flags<ModLoaders>(TargetLoaders).First();
        }
        TargetResourceType = (ResourceTypes)Conversions.ToInteger(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 4 }, null));
    }

    private void PageDownloadResourceDetail_Inited(object sender, EventArgs e)
    {
        LoadPageArguments();
        PageLoaderInit(Load, PanLoad, PanMain, CardIntro, ResourceFileLoader, (ModLoader.LoaderTask<int, List<ResourceVersion>> a0) =>
        {
            Load_OnFinish();
        });
    }

    private void Load_State(object sender, MyLoading.MyLoadingState state, MyLoading.MyLoadingState oldState)
    {
        ModBase.LoadState state2 = ResourceFileLoader.State;
        if (state2 == ModBase.LoadState.Failed)
        {
            string text = "";
            if (ResourceFileLoader.Error != null)
            {
                text = ResourceFileLoader.Error.Message;
            }
            if (text.Contains("不是有效的 json 文件"))
            {
                Logger.Warn("下载的文件 json 列表损坏，已自动重试", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                PageLoaderRestart();
            }
        }
    }

    private List<ResourceVersion> GetResults()
    {
        List<ResourceVersion> list = ResourceFileLoader.Output;
        ResourceTypes targetResourceType = TargetResourceType;
        if ((int)targetResourceType != 4 && (int)targetResourceType != 8)
        {
            list = (((int)targetResourceType != 127) ? list.Where((ResourceVersion r) =>
            {
                return r.ResourceType == TargetResourceType;
            }).ToList() : list.Where((ResourceVersion r) =>
            {
                return (int)r.ResourceType != 32;
            }).ToList());
        }
        return list;
    }

    private void Load_OnFinish()
    {
        List<ResourceVersion> results = GetResults();
        List<string> list = null;
        VB_0024AnonymousDelegate_10 obj = () =>
        {
            list = (from v in results.SelectMany((ResourceVersion v) => v.GameVersions)
                    select GetGroupedVersionName(v, GroupedDrop, GroupedOld)).Distinct().OrderByDescending((string s) => s, new ModMinecraft.VersionComparer()).ToList();
        };
        GroupedDrop = false;
        GroupedOld = false;
        obj();
        if (list.Count >= 9)
        {
            GroupedDrop = true;
            GroupedOld = false;
            obj();
            if (list.Count >= 9)
            {
                GroupedDrop = false;
                GroupedOld = true;
                obj();
                if (list.Count >= 9)
                {
                    GroupedDrop = true;
                    GroupedOld = true;
                    obj();
                }
            }
        }
        PanFilter.Children.Clear();
        if (list.Count < 2)
        {
            CardFilter.Visibility = Visibility.Collapsed;
            VersionFilter = null;
        }
        else
        {
            CardFilter.Visibility = Visibility.Visible;
            list.Insert(0, "全部");
            foreach (string item in list)
            {
                MyRadioButton myRadioButton = new MyRadioButton
                {
                    Text = item,
                    Margin = new Thickness(2.0, 0.0, 2.0, 0.0),
                    ColorType = MyRadioButton.ColorState.Highlight
                };
                myRadioButton.LabText.Margin = new Thickness(-2.0, 0.0, 10.0, 0.0);
                myRadioButton.Check += (object a0, bool a1) =>
                {
                    _Lambda_0024__16_002D4((MyRadioButton)a0, a1);
                };
                PanFilter.Children.Add(myRadioButton);
            }
            MyRadioButton myRadioButton2 = null;
            if (Operators.CompareString(TargetVersion, "", TextCompare: false) != 0 && results.FirstOrDefault((ResourceVersion v) => v.GameVersions.Contains(TargetVersion)) != null)
            {
                string groupedVersionName = GetGroupedVersionName(TargetVersion, GroupedDrop, GroupedOld);
                foreach (MyRadioButton child in PanFilter.Children)
                {
                    if (Operators.CompareString(child.Text, groupedVersionName, TextCompare: false) == 0)
                    {
                        myRadioButton2 = child;
                        break;
                    }
                }
            }
            if (myRadioButton2 == null)
            {
                myRadioButton2 = (MyRadioButton)PanFilter.Children[0];
            }
            myRadioButton2.Checked = true;
        }
        UpdateFilterResult();
    }

    private void UpdateFilterResult()
    {
        List<ResourceVersion> results = GetResults();
        string text = ((Operators.CompareString(TargetVersion, "", TextCompare: false) != 0 || (int)TargetLoaders != 0) ? string.Format("{0}{1}（所选版本）", ((int)TargetLoaders != 0) ? (((Enum)TargetLoaders).ToString() + " ") : "", TargetVersion) : "");
        SortedDictionary<string, List<ResourceVersion>> sortedDictionary = new SortedDictionary<string, List<ResourceVersion>>(new CardSorter(text));
        sortedDictionary.Add("其他", new List<ResourceVersion>());
        foreach (ResourceVersion item in results)
        {
            foreach (string gameVersion in item.GameVersions)
            {
                if (VersionFilter != null && Operators.CompareString(GetGroupedVersionName(gameVersion, GroupedDrop, GroupedOld), VersionFilter, TextCompare: false) != 0)
                {
                    continue;
                }
                string groupedVersionName = GetGroupedVersionName(gameVersion, GroupedByDrop: false, FoldOld: false);
                List<string> list = new List<string>();
                if (EnumerableExtensions.Flags<ModLoaders>(Project.ModLoaders).Count() > 1 && (int)item.ResourceType == 1 && ModMinecraft.McVersion.IsFormatFit(groupedVersionName))
                {
                    list.AddRange(from f in EnumerableExtensions.Flags<ModLoaders>(item.ModLoaders)
                                  select ((Enum)f).ToString() + " ");
                }
                if (!list.Any())
                {
                    list.Add("");
                }
                foreach (string item2 in list)
                {
                    string key = item2 + groupedVersionName;
                    if (!sortedDictionary.ContainsKey(key))
                    {
                        sortedDictionary.Add(key, new List<ResourceVersion>());
                    }
                    if (!sortedDictionary[key].Contains(item))
                    {
                        sortedDictionary[key].Add(item);
                    }
                }
            }
        }
        if (Operators.CompareString(text, "", TextCompare: false) != 0 && (VersionFilter == null || StringExtensions.StartsWithF(GetGroupedVersionName(TargetVersion, GroupedDrop, GroupedOld), VersionFilter, false)))
        {
            sortedDictionary.Add(text, new List<ResourceVersion>());
            foreach (ResourceVersion item3 in results)
            {
                if (item3.GameVersions.Contains(TargetVersion) && ((int)TargetLoaders == 0 || EnumerableExtensions.Flags<ModLoaders>(TargetLoaders).Intersect(EnumerableExtensions.Flags<ModLoaders>(item3.ModLoaders)).Any()) && (VersionFilter == null || item3.GameVersions.Any((string v) => Operators.CompareString(GetGroupedVersionName(v, GroupedDrop, GroupedOld), VersionFilter, TextCompare: false) == 0)) && !sortedDictionary[text].Contains(item3))
                {
                    sortedDictionary[text].Add(item3);
                }
            }
        }
        try
        {
            PanResults.Children.Clear();
            foreach (KeyValuePair<string, List<ResourceVersion>> item4 in sortedDictionary)
            {
                if (item4.Value.Any() && Operators.CompareString(item4.Key, text.Replace("（所选版本）", ""), TextCompare: false) != 0)
                {
                    MyCard myCard = new MyCard
                    {
                        Title = item4.Key,
                        Margin = new Thickness(0.0, 0.0, 0.0, 15.0),
                        SwapType = (((int)TargetResourceType == 2) ? 9 : 8)
                    };
                    StackPanel Stack = new StackPanel
                    {
                        Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
                        VerticalAlignment = VerticalAlignment.Top,
                        RenderTransform = new TranslateTransform(0.0, 0.0),
                        Tag = item4.Value
                    };
                    myCard.Children.Add(Stack);
                    myCard.SwapControl = Stack;
                    PanResults.Children.Add(myCard);
                    if (Operators.CompareString(item4.Key, text, TextCompare: false) == 0 || (ModMain.FrmMain.PageCurrent.Additional != null && ((List<string>)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 1 }, null)).Contains(myCard.Title)))
                    {
                        MyCard.StackInstall(ref Stack, ((int)TargetResourceType == 2) ? 9 : 8, item4.Key);
                    }
                    else
                    {
                        myCard.IsSwapped = true;
                    }
                    if (Operators.CompareString(item4.Key, "其他", TextCompare: false) == 0)
                    {
                        Stack.Children.Add(new MyHint
                        {
                            Text = "由于版本信息更新缓慢，可能无法识别刚更新的 MC 版本。几天后即可正常识别。",
                            Theme = MyHint.Themes.Yellow,
                            Margin = new Thickness(5.0, 0.0, 0.0, 8.0)
                        });
                    }
                }
            }
            if (PanResults.Children.Count == 1)
            {
                ((MyCard)PanResults.Children[0]).IsSwapped = false;
            }
            if ((int)Project.Types == 17 && ((int)TargetResourceType == 1 || (int)TargetResourceType == 16))
            {
                HintAlternative.Visibility = Visibility.Visible;
                HintAlternative.Text = (((int)TargetResourceType == 1) ? "以下是该项目的 Mod 版本。点击这里查看其数据包版本。" : "以下是该项目的数据包版本。点击这里查看其 Mod 版本。");
            }
            else
            {
                HintAlternative.Visibility = Visibility.Collapsed;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化工程下载列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private string GetGroupedVersionName(string Name, bool GroupedByDrop, bool FoldOld)
    {
        int num = ModMinecraft.McVersion.VersionToDrop(Name);
        if (Name == null)
        {
            return "其他";
        }
        if (Name.Contains("w") || num == 209)
        {
            return "快照版";
        }
        if (!ModMinecraft.McVersion.IsFormatFit(Name) || (FoldOld && num < 120))
        {
            return "远古版";
        }
        if (GroupedByDrop)
        {
            return ModMinecraft.McVersion.DropToVersion(num);
        }
        return Name;
    }

    public void Init()
    {
        checked
        {
            ModAnimation.AniControlEnabled++;
            Project = (ResourceProject)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[1] { 0 }, null);
            PanBack.ScrollToHome();
            if (IsFirstInit)
            {
                IsFirstInit = false;
            }
            else
            {
                PageLoaderRestart();
            }
            if (ResourceItem != null)
            {
                PanIntro.Children.Remove(ResourceItem);
            }
            ResourceItem = Project.ToResourceItem(ShowMcVersionDesc: true, ShowLoaderDesc: true).Init();
            ResourceItem.CanInteraction = false;
            ResourceItem.Margin = new Thickness(-7.0, -7.0, 0.0, 8.0);
            PanIntro.Children.Insert(0, ResourceItem);
            BtnIntroWeb.Text = $"转到 {Project.Platform}";
            BtnIntroWiki.Visibility = ((Project.WikiId == 0) ? Visibility.Collapsed : Visibility.Visible);
            ModAnimation.AniControlEnabled--;
        }
    }

    public void Install_Click(MyListItem sender, EventArgs e)
    {
        try
        {
            ResourceVersion resourceVersion = (ResourceVersion)sender.Tag;
            string name = $"{Project.Platform} 整合包下载：{Project.TranslatedName} ";
            string text = Project.TranslatedName.Replace(".zip", "").Replace(".rar", "").Replace(".mrpack", "")
                .Replace("\\", "＼")
                .Replace("/", "／")
                .Replace("|", "｜")
                .Replace(":", "：")
                .Replace("<", "＜")
                .Replace(">", "＞")
                .Replace("*", "＊")
                .Replace("?", "？")
                .Replace("\"", "")
                .Replace("： ", "：");
            ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
            if (Operators.CompareString(validateFolderName.Validate(text), "", TextCompare: false) != 0)
            {
                text = "";
            }
            string text2 = ModMain.MyMsgBoxInput("输入版本名称", "", text, new Collection<ValidateBase> { validateFolderName });
            if (string.IsNullOrEmpty(text2))
            {
                return;
            }
            List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
            string text3 = string.Format("{0}versions\\{1}\\原始整合包.{2}", ModMinecraft.McFolderSelected, text2, ((int)Project.Platform == 1) ? "zip" : "mrpack");
            string actualSource = ResourceItem.PathLogo.ActualSource;
            list.Add(new ModNet.LoaderDownload("下载整合包文件", new ModNet.NetFile[1] { resourceVersion.ToNetFile(text3, ResourceVersion.DownloadReason.Standalone, resourceVersion.GameVersions.FirstOrDefault(), resourceVersion.ModLoaders) })
            {
                ProgressWeight = 10.0,
                Block = true
            });
            list.Add(new ModLoader.LoaderTask<int, int>("准备安装整合包", (Action<ModLoader.LoaderTask<int, int>>)((ModLoader.LoaderTask<int, int> a0) =>
            {
                ModModpack.ModpackInstall(text3, text2, FileUtils.Exists(actualSource) ? actualSource : null);
            }), (Func<int>)null, ThreadPriority.Normal)
            {
                ProgressWeight = 0.1
            });
            ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(name, list);
            loaderCombo.OnStateChanged = (ModLoader.LoaderBase MyLoader) =>
            {
                switch (MyLoader.State)
                {
                    case ModBase.LoadState.Failed:
                        ModMain.Hint(MyLoader.Name + "失败：" + ExceptionExtensions.GetDisplay(MyLoader.Error, false), ModMain.HintType.Red);
                        break;
                    case ModBase.LoadState.Canceled:
                        ModMain.Hint(MyLoader.Name + "已取消！");
                        break;
                    case ModBase.LoadState.Loading:
                        return;
                }
                ModDownloadLib.McInstallFailedClearFolder(MyLoader);
            };
            loaderCombo.Start(ModMinecraft.McFolderSelected + "versions\\" + text2 + "\\");
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "下载资源整合包失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Save_Click(object sender, EventArgs e)
    {
        ResourceVersion resourceVersion = (ResourceVersion)NewLateBinding.LateGet((sender is MyListItem) ? sender : NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null);
        ModBase.RunInNewThread(() =>
        {
            try
            {
                string text = null;
                ResourceTypes resourceType = resourceVersion.ResourceType;
                switch ((int)resourceType - 1)
                {
                    default:
                        if ((int)resourceType != 8)
                        {
                            if ((int)resourceType == 16)
                            {
                                text = "数据包";
                            }
                        }
                        else
                        {
                            text = "光影包";
                        }
                        break;
                    case 1:
                        text = "整合包";
                        break;
                    case 0:
                        text = "Mod ";
                        break;
                    case 3:
                        text = "资源包";
                        break;
                    case 2:
                        break;
                }
                string text2 = null;
                if ((int)resourceVersion.ResourceType != 2)
                {
                    string arg = null;
                    ResourceTypes resourceType2 = resourceVersion.ResourceType;
                    if ((int)resourceType2 <= 4)
                    {
                        if ((int)resourceType2 != 1)
                        {
                            if ((int)resourceType2 == 4)
                            {
                                arg = "resourcepacks\\";
                            }
                        }
                        else
                        {
                            arg = "mods\\";
                        }
                    }
                    else if ((int)resourceType2 != 8)
                    {
                        if ((int)resourceType2 == 16)
                        {
                            arg = "";
                        }
                    }
                    else
                    {
                        arg = "shaderpacks\\";
                    }
                    Func<ModMinecraft.McInstance, bool> func = null;
                    ModLoaders val = (ModLoaders)0;
                    if ((int)resourceVersion.ModLoaders != 0)
                    {
                        val = resourceVersion.ModLoaders;
                    }
                    else if ((int)Project.ModLoaders != 0)
                    {
                        val = Project.ModLoaders;
                    }
                    Logger.Info($"{text}要求的加载器种类：{val}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                    func = (ModMinecraft.McInstance Instance) =>
                    {
                        if (!Instance.IsLoaded)
                        {
                            Instance.Load();
                        }
                        return (((int)resourceVersion.ResourceType != 1 && (int)resourceVersion.ResourceType != 16) || resourceVersion.GameVersions.Any((string FileVersion) =>
                        {
                            bool flag2 = FileVersion.Contains("预览版") || !FileVersion.Contains(".");
                            bool flag3 = Instance.Version.VanillaName.Contains("snapshot") || !Instance.Version.VanillaName.Contains(".");
                            if (flag2 != flag3)
                            {
                                return false;
                            }
                            if (!flag2 && !flag3)
                            {
                                return Operators.CompareString(FileVersion, Instance.Version.VanillaName, TextCompare: false) == 0;
                            }
                            bool flag4 = FileVersion.Contains(".") && ModBase.Val(StringExtensions.BeforeFirst(FileVersion, ".", false)) > 1.0;
                            bool flag5 = Instance.Version.Drop > 250;
                            if (flag4 != flag5)
                            {
                                return false;
                            }
                            if (flag4 && flag5)
                            {
                                return Operators.CompareString(StringExtensions.BeforeFirst(FileVersion, " ", false), StringExtensions.BeforeFirst(Instance.Version.VanillaName, "-", false), TextCompare: false) == 0;
                            }
                            return !FileVersion.Contains("w") || !Instance.Version.VanillaName.Contains("w") || Operators.CompareString(FileVersion, Instance.Version.VanillaName, TextCompare: false) == 0;
                        })) && ((int)val == 0 || EnumerableExtensions.Flags<ModLoaders>(val).Intersect(EnumerableExtensions.Flags<ModLoaders>(Instance.Version.ModLoaders)).Any());
                    };
                    if (CachedFolder.ContainsKey(resourceVersion.ResourceType))
                    {
                        text2 = CachedFolder[resourceVersion.ResourceType];
                        Logger.Info($"使用上次下载时的文件夹作为默认下载位置：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                    }
                    else if ((object)ModMinecraft.McInstanceSelected != null && func(ModMinecraft.McInstanceSelected))
                    {
                        text2 = $"{ModMinecraft.McInstanceSelected.PathIndie}{arg}";
                        DirectoryUtils.Create(text2);
                        Logger.Info($"使用当前版本作为默认下载位置：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                    }
                    else
                    {
                        bool flag = ModMinecraft.McInstanceListLoader.State != ModBase.LoadState.Finished;
                        if (flag)
                        {
                            ModMain.Hint("正在查找适合的游戏版本……");
                            ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.McFolderSelected, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", WaitForExit: true);
                        }
                        IEnumerable<DirectoryInfo> source = from v in ModMinecraft.McInstanceList.Values.SelectMany((List<ModMinecraft.McInstance> l) => l)
                                                            where func(v)
                                                            select DirectoryUtils.GetInfo($"{v.PathIndie}{arg}");
                        if (source.Any())
                        {
                            DirectoryInfo directoryInfo = (from Dir in source
                                                           orderby (!Dir.Exists) ? DateTime.MinValue : Dir.LastWriteTimeUtc descending, (!Dir.Exists) ? (-1) : Dir.GetFiles().Length descending
                                                           select Dir).First();
                            text2 = PathUtils.RemoveExtendedPrefix(directoryInfo.FullName);
                            DirectoryUtils.Create(text2);
                            Logger.Info($"使用适合的游戏版本作为默认下载位置：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                        }
                        else
                        {
                            text2 = ModMinecraft.McFolderSelected;
                            if (flag)
                            {
                                ModMain.Hint("当前 MC 文件夹中没有找到合适的版本！");
                            }
                            else
                            {
                                Logger.Info("由于当前版本不兼容，使用当前的 MC 文件夹作为默认下载位置", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                            }
                        }
                    }
                }
                string text3;
                if (Operators.CompareString(Project.TranslatedName, Project.RawName, TextCompare: false) == 0)
                {
                    text3 = resourceVersion.FileName;
                }
                else
                {
                    string text4 = StringExtensions.BeforeFirst(StringExtensions.BeforeFirst(Project.TranslatedName, " (", false), " - ", false).Replace("\\", "＼").Replace("/", "／")
                        .Replace("|", "｜")
                        .Replace(":", "：")
                        .Replace("<", "＜")
                        .Replace(">", "＞")
                        .Replace("*", "＊")
                        .Replace("?", "？")
                        .Replace("\"", "")
                        .Replace("： ", "：");
                    switch (Settings.Get<int>("ToolDownloadTranslateV2"))
                    {
                        case 0:
                            text3 = $"【{text4}】{resourceVersion.FileName}";
                            break;
                        case 1:
                            text3 = $"[{text4}] {resourceVersion.FileName}";
                            break;
                        case 2:
                            text3 = $"{text4}-{resourceVersion.FileName}";
                            break;
                        case 3:
                            text3 = $"{resourceVersion.FileName}-{text4}";
                            break;
                        default:
                            text3 = resourceVersion.FileName;
                            break;
                    }
                }
                if ((int)resourceVersion.ResourceType == 1)
                {
                    text3 = text3.Replace("~", "-");
                }
                ModBase.RunInUi(() =>
                {
                    string item = (((int)resourceVersion.ResourceType != 1) ? (StringExtensions.EndsWithF(resourceVersion.FileName, ".mrpack", false) ? "mrpack" : "zip") : (StringExtensions.EndsWithF(resourceVersion.FileName, ".litemod", false) ? "litemod" : "jar"));
                    string text5 = Dialogs.SaveFile("选择保存位置", text3, text2, (IEnumerable<(string, string)>)new (string, string)[1] { (item, text + "文件") });
                    if (text5 != null)
                    {
                        string name = text + "下载：" + PathUtils.GetFileNameWithoutExtension(text5) + " ";
                        if (Operators.CompareString(text5, text2, TextCompare: false) != 0)
                        {
                            CachedFolder[resourceVersion.ResourceType] = PathUtils.RemoveLastPart(text5);
                        }
                        ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>(name, new List<ModLoader.LoaderBase>
                        {
                            new ModNet.LoaderDownload("下载文件", new ModNet.NetFile[1] { resourceVersion.ToNetFile(text5, ((int)TargetResourceType == 127) ? ResourceVersion.DownloadReason.Dependency : ResourceVersion.DownloadReason.Standalone, null, (ModLoaders)0) })
                            {
                                ProgressWeight = 6.0,
                                Block = true
                            }
                        });
                        loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
                        loaderCombo.Start(1);
                        ModLoader.LoaderTaskbarAdd(loaderCombo);
                        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
                        ModMain.FrmMain.BtnExtraDownload.Ribble();
                    }
                });
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "保存资源文件失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }, "Download Resource Detail Save");
    }

    private void BtnIntroWeb_Click(object sender, EventArgs e)
    {
        ModBase.OpenWebsite(Project.Website);
    }

    private void BtnIntroWiki_Click(object sender, EventArgs e)
    {
        ModBase.OpenWebsite("https://www.mcmod.cn/class/" + Conversions.ToString(Project.WikiId) + ".html");
    }

    private void BtnIntroCopy_Click(object sender, EventArgs e)
    {
        ModBase.ClipboardSet(ResourceItem.LabTitle.Text + ResourceItem.LabTitleRaw.Text);
    }

    private void HintAlternative_Click()
    {
        TargetResourceType = (ResourceTypes)(((int)TargetResourceType != 1) ? 1 : 16);
        NewLateBinding.LateIndexSet(ModMain.FrmMain.PageCurrent.Additional, new object[2] { 4, TargetResourceType }, null);
        PageLoaderRestart();
    }

    public static void ResourceFilesCardPreload(StackPanel Stack, List<ResourceVersion> Files)
    {
        List<string> list = Files.SelectMany((ResourceVersion f) => f.Dependencies).Distinct().ToList();
        list.Sort();
        if (!list.Any())
        {
            return;
        }
        list = list.Where((string dep) =>
        {
            if (!ResourceProject.Cache.ContainsKey(dep))
            {
                Logger.Warn($"未找到 ID {dep} 的前置信息", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\Resource\\PageDownloadCompDetail.xaml.vb");
            }
            return ResourceProject.Cache.ContainsKey(dep);
        }).ToList();
        Stack.Children.Add(new TextBlock
        {
            Text = "前置资源",
            FontSize = 14.0,
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(6.0, 2.0, 0.0, 5.0)
        });
        foreach (string item in list)
        {
            MyVirtualizingElement<MyResourceItem> element = ResourceProject.Cache[item].ToResourceItem(ShowMcVersionDesc: false, ShowLoaderDesc: false);
            Stack.Children.Add(element);
        }
        Stack.Children.Add(new TextBlock
        {
            Text = "版本列表",
            FontSize = 14.0,
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(6.0, 12.0, 0.0, 5.0)
        });
    }


    [CompilerGenerated]
    private void _Lambda_0024__16_002D4(MyRadioButton sender, bool raiseByMouse)
    {
        VersionFilter = ((Operators.CompareString(sender.Text, "全部", TextCompare: false) == 0) ? null : sender.Text);
        UpdateFilterResult();
    }

    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnIntroCopy_WithEvents = BtnIntroCopy;
        BtnIntroWeb_WithEvents = BtnIntroWeb;
        BtnIntroWiki_WithEvents = BtnIntroWiki;
        CardFilter_WithEvents = CardFilter;
        CardIntro_WithEvents = CardIntro;
        HintAlternative_WithEvents = HintAlternative;
        Load_WithEvents = Load;
        PanBack_WithEvents = PanBack;
        PanFilter_WithEvents = PanFilter;
        PanIntro_WithEvents = PanIntro;
        PanLoad_WithEvents = PanLoad;
        PanMain_WithEvents = PanMain;
        PanResults_WithEvents = PanResults;
    }
}

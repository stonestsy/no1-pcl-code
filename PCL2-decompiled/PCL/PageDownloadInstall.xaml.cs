using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadInstall : MyPageRight, IComponentConnector
{
    [Serializable]
    [CompilerGenerated]
    internal new sealed class _Closure_0024__
    {
        public static readonly _Closure_0024__ _0024I;

        public static Func<JObject, DateTime> _0024I32_002D0;

        public static VB_0024AnonymousDelegate_10 _0024I32_002D1;

        public static MyListItem.ClickEventHandler _0024IR32_002D4;

        public static Func<ModDownload.DlOptiFineListEntry, ModDownload.DlOptiFineListEntry, bool> _0024I37_002D0;

        public static Func<ModDownload.DlForgeVersionEntry, ModDownload.DlForgeVersionEntry> _0024I47_002D1;

        public static Func<ResourceVersion, DateTime> _0024I64_002D0;

        public static Func<ResourceVersion, DateTime> _0024I71_002D0;

        static _Closure_0024__()
        {
            _0024I = new _Closure_0024__();
        }

        internal DateTime _Lambda_0024__32_002D0(JObject j)
        {
            return Extensions.Value<DateTime>((IEnumerable<JToken>)j["releaseTime"]);
        }

        internal void _Lambda_0024__R32_002D4(object a0, MouseButtonEventArgs a1)
        {
            ((VB_0024AnonymousDelegate_10)(() =>
            {
            }))();
        }

        internal void _Lambda_0024__32_002D1()
        {
        }

        internal bool _Lambda_0024__37_002D0(ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right)
        {
            if (!Left.IsPreview && Right.IsPreview)
            {
                return true;
            }
            if (Left.IsPreview && !Right.IsPreview)
            {
                return false;
            }
            return ModMinecraft.CompareVersionGE(Left.DisplayName, Right.DisplayName);
        }

        internal ModDownload.DlForgeVersionEntry _Lambda_0024__47_002D1(ModDownload.DlForgeVersionEntry v)
        {
            return v;
        }

        internal DateTime _Lambda_0024__64_002D0(ResourceVersion v)
        {
            return v.ReleaseDate;
        }

        internal DateTime _Lambda_0024__71_002D0(ResourceVersion v)
        {
            return v.ReleaseDate;
        }
    }

    private bool IsLoad;

    public bool IsInSelectPage;

    private bool IsFirstLoaded;

    private string VanillaName;

    private JObject VanillaData;

    private string VanillaIcon;

    private ModDownload.DlOptiFineListEntry SelectedOptiFine;

    private ModDownload.DlLiteLoaderListEntry SelectedLiteLoader;

    private ModDownload.DlForgeVersionEntry SelectedForge;

    private ModDownload.DlNeoForgeListEntry SelectedNeoForge;

    private string SelectedFabric;

    private ResourceVersion SelectedFabricApi;

    private ResourceVersion SelectedOptiFabric;

    private bool IsSelectNameEdited;

    private bool IsSelectNameChanging;

    public static string VersionWaitingSelect = null;

    private bool AutoSelectedFabricApi;

    private bool AutoSelectedOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("PanAllBack")]
    private Grid _PanAllBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanInner")]
    private Grid _PanInner;

    [CompilerGenerated]
    [AccessedThroughProperty("PanMinecraft")]
    private StackPanel _PanMinecraft;

    [CompilerGenerated]
    [AccessedThroughProperty("PanSelect")]
    private StackPanel _PanSelect;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnBack")]
    private MyIconButton _BtnBack;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgLogo")]
    private MyImage _ImgLogo;

    [CompilerGenerated]
    [AccessedThroughProperty("TextSelectName")]
    private MyTextBox _TextSelectName;

    [CompilerGenerated]
    [AccessedThroughProperty("HintFabricAPI")]
    private MyHint _HintFabricAPI;

    [CompilerGenerated]
    [AccessedThroughProperty("HintOptiFabric")]
    private MyHint _HintOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("HintOptiFabricOld")]
    private MyHint _HintOptiFabricOld;

    [CompilerGenerated]
    [AccessedThroughProperty("HintModOptiFine")]
    private MyHint _HintModOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("CardForge")]
    private MyCard _CardForge;

    [CompilerGenerated]
    [AccessedThroughProperty("PanForge")]
    private StackPanel _PanForge;

    [CompilerGenerated]
    [AccessedThroughProperty("PanForgeInfo")]
    private Grid _PanForgeInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgForge")]
    private Image _ImgForge;

    [CompilerGenerated]
    [AccessedThroughProperty("LabForge")]
    private TextBlock _LabForge;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnForgeClear")]
    private Grid _BtnForgeClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnForgeClearInner")]
    private Path _BtnForgeClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardNeoForge")]
    private MyCard _CardNeoForge;

    [CompilerGenerated]
    [AccessedThroughProperty("PanNeoForge")]
    private StackPanel _PanNeoForge;

    [CompilerGenerated]
    [AccessedThroughProperty("PanNeoForgeInfo")]
    private Grid _PanNeoForgeInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgNeoForge")]
    private Image _ImgNeoForge;

    [CompilerGenerated]
    [AccessedThroughProperty("LabNeoForge")]
    private TextBlock _LabNeoForge;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnNeoForgeClear")]
    private Grid _BtnNeoForgeClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnNeoForgeClearInner")]
    private Path _BtnNeoForgeClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardFabric")]
    private MyCard _CardFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFabric")]
    private StackPanel _PanFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFabricInfo")]
    private Grid _PanFabricInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgFabric")]
    private Image _ImgFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("LabFabric")]
    private TextBlock _LabFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFabricClear")]
    private Grid _BtnFabricClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFabricClearInner")]
    private Path _BtnFabricClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardFabricApi")]
    private MyCard _CardFabricApi;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFabricApi")]
    private StackPanel _PanFabricApi;

    [CompilerGenerated]
    [AccessedThroughProperty("PanFabricApiInfo")]
    private Grid _PanFabricApiInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgFabricApi")]
    private Image _ImgFabricApi;

    [CompilerGenerated]
    [AccessedThroughProperty("LabFabricApi")]
    private TextBlock _LabFabricApi;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFabricApiClear")]
    private Grid _BtnFabricApiClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnFabricApiClearInner")]
    private Path _BtnFabricApiClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardOptiFine")]
    private MyCard _CardOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptiFine")]
    private StackPanel _PanOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptiFineInfo")]
    private Grid _PanOptiFineInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgOptiFine")]
    private Image _ImgOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("LabOptiFine")]
    private TextBlock _LabOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnOptiFineClear")]
    private Grid _BtnOptiFineClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnOptiFineClearInner")]
    private Path _BtnOptiFineClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardOptiFabric")]
    private MyCard _CardOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptiFabric")]
    private StackPanel _PanOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptiFabricInfo")]
    private Grid _PanOptiFabricInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgOptiFabric")]
    private Image _ImgOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("LabOptiFabric")]
    private TextBlock _LabOptiFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnOptiFabricClear")]
    private Grid _BtnOptiFabricClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnOptiFabricClearInner")]
    private Path _BtnOptiFabricClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("CardLiteLoader")]
    private MyCard _CardLiteLoader;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLiteLoader")]
    private StackPanel _PanLiteLoader;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLiteLoaderInfo")]
    private Grid _PanLiteLoaderInfo;

    [CompilerGenerated]
    [AccessedThroughProperty("ImgLiteLoader")]
    private Image _ImgLiteLoader;

    [CompilerGenerated]
    [AccessedThroughProperty("LabLiteLoader")]
    private TextBlock _LabLiteLoader;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLiteLoaderClear")]
    private Grid _BtnLiteLoaderClear;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnLiteLoaderClearInner")]
    private Path _BtnLiteLoaderClearInner;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnStart")]
    private MyExtraTextButton _BtnStart;

    [CompilerGenerated]
    [AccessedThroughProperty("PanLoad")]
    private MyCard _PanLoad;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadMinecraft")]
    private MyLoading _LoadMinecraft;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadOptiFine")]
    private MyLoading _LoadOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadForge")]
    private MyLoading _LoadForge;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadNeoForge")]
    private MyLoading _LoadNeoForge;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadLiteLoader")]
    private MyLoading _LoadLiteLoader;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadFabric")]
    private MyLoading _LoadFabric;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadFabricApi")]
    private MyLoading _LoadFabricApi;

    [CompilerGenerated]
    [AccessedThroughProperty("LoadOptiFabric")]
    private MyLoading _LoadOptiFabric;

    private bool _0024STATIC_0024ReloadSelected_00242001_0024Ongoing;

    private StaticLocalInitFlag _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init;

    private int VanillaDrop => ModMinecraft.McVersion.VersionToDrop(VanillaName);

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

    internal virtual Grid PanInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanInner = value;
        }
    }

    internal virtual StackPanel PanMinecraft_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanMinecraft;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanMinecraft = value;
        }
    }

    internal virtual StackPanel PanSelect_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanSelect;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanSelect = value;
        }
    }

    internal virtual MyIconButton BtnBack_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnBack;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyIconButton.ClickEventHandler obj = (object a0, EventArgs a1) =>
            {
                ExitSelectPage();
            };
            MyIconButton myIconButton = _BtnBack;
            if (myIconButton != null)
            {
                myIconButton.Click -= obj;
            }
            _BtnBack = value;
            myIconButton = _BtnBack;
            if (myIconButton != null)
            {
                myIconButton.Click += obj;
            }
        }
    }

    internal virtual MyImage ImgLogo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgLogo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgLogo = value;
        }
    }

    internal virtual MyTextBox TextSelectName_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextSelectName;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            TextChangedEventHandler value2 = TextSelectName_TextChanged;
            MyTextBox.ValidateChangedEventHandler obj = TextSelectName_ValidateChanged;
            KeyEventHandler value3 = TextSelectName_KeyDown;
            MyTextBox myTextBox = _TextSelectName;
            if (myTextBox != null)
            {
                myTextBox.TextChanged -= value2;
                MyTextBox.ValidateChanged -= obj;
                myTextBox.KeyDown -= value3;
            }
            _TextSelectName = value;
            myTextBox = _TextSelectName;
            if (myTextBox != null)
            {
                myTextBox.TextChanged += value2;
                MyTextBox.ValidateChanged += obj;
                myTextBox.KeyDown += value3;
            }
        }
    }

    internal virtual MyHint HintFabricAPI_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintFabricAPI;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintFabricAPI = value;
        }
    }

    internal virtual MyHint HintOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintOptiFabric = value;
        }
    }

    internal virtual MyHint HintOptiFabricOld_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintOptiFabricOld;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintOptiFabricOld = value;
        }
    }

    internal virtual MyHint HintModOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintModOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintModOptiFine = value;
        }
    }

    internal virtual MyCard CardForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardForge_PreviewSwap;
            MyCard myCard = _CardForge;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardForge = value;
            myCard = _CardForge;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanForge = value;
        }
    }

    internal virtual Grid PanForgeInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanForgeInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanForgeInfo = value;
        }
    }

    internal virtual Image ImgForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgForge = value;
        }
    }

    internal virtual TextBlock LabForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabForge = value;
        }
    }

    internal virtual Grid BtnForgeClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnForgeClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = Forge_Clear;
            Grid grid = _BtnForgeClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnForgeClear = value;
            grid = _BtnForgeClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnForgeClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnForgeClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnForgeClearInner = value;
        }
    }

    internal virtual MyCard CardNeoForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardNeoForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardNeoForge_PreviewSwap;
            MyCard myCard = _CardNeoForge;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardNeoForge = value;
            myCard = _CardNeoForge;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanNeoForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanNeoForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanNeoForge = value;
        }
    }

    internal virtual Grid PanNeoForgeInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanNeoForgeInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanNeoForgeInfo = value;
        }
    }

    internal virtual Image ImgNeoForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgNeoForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgNeoForge = value;
        }
    }

    internal virtual TextBlock LabNeoForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabNeoForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabNeoForge = value;
        }
    }

    internal virtual Grid BtnNeoForgeClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnNeoForgeClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = NeoForge_Clear;
            Grid grid = _BtnNeoForgeClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnNeoForgeClear = value;
            grid = _BtnNeoForgeClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnNeoForgeClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnNeoForgeClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnNeoForgeClearInner = value;
        }
    }

    internal virtual MyCard CardFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardFabric_PreviewSwap;
            MyCard myCard = _CardFabric;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardFabric = value;
            myCard = _CardFabric;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanFabric = value;
        }
    }

    internal virtual Grid PanFabricInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanFabricInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanFabricInfo = value;
        }
    }

    internal virtual Image ImgFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgFabric = value;
        }
    }

    internal virtual TextBlock LabFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabFabric = value;
        }
    }

    internal virtual Grid BtnFabricClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFabricClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = Fabric_Clear;
            Grid grid = _BtnFabricClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnFabricClear = value;
            grid = _BtnFabricClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnFabricClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFabricClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnFabricClearInner = value;
        }
    }

    internal virtual MyCard CardFabricApi_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardFabricApi;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardFabricApi_PreviewSwap;
            MyCard myCard = _CardFabricApi;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardFabricApi = value;
            myCard = _CardFabricApi;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanFabricApi_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanFabricApi;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanFabricApi = value;
        }
    }

    internal virtual Grid PanFabricApiInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanFabricApiInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanFabricApiInfo = value;
        }
    }

    internal virtual Image ImgFabricApi_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgFabricApi;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgFabricApi = value;
        }
    }

    internal virtual TextBlock LabFabricApi_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabFabricApi;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabFabricApi = value;
        }
    }

    internal virtual Grid BtnFabricApiClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFabricApiClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = FabricApi_Clear;
            Grid grid = _BtnFabricApiClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnFabricApiClear = value;
            grid = _BtnFabricApiClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnFabricApiClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnFabricApiClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnFabricApiClearInner = value;
        }
    }

    internal virtual MyCard CardOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardOptiFine_PreviewSwap;
            MyCard myCard = _CardOptiFine;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardOptiFine = value;
            myCard = _CardOptiFine;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptiFine = value;
        }
    }

    internal virtual Grid PanOptiFineInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptiFineInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptiFineInfo = value;
        }
    }

    internal virtual Image ImgOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgOptiFine = value;
        }
    }

    internal virtual TextBlock LabOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabOptiFine = value;
        }
    }

    internal virtual Grid BtnOptiFineClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnOptiFineClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = OptiFine_Clear;
            Grid grid = _BtnOptiFineClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnOptiFineClear = value;
            grid = _BtnOptiFineClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnOptiFineClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnOptiFineClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnOptiFineClearInner = value;
        }
    }

    internal virtual MyCard CardOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardOptiFabric_PreviewSwap;
            MyCard myCard = _CardOptiFabric;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardOptiFabric = value;
            myCard = _CardOptiFabric;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptiFabric = value;
        }
    }

    internal virtual Grid PanOptiFabricInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptiFabricInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptiFabricInfo = value;
        }
    }

    internal virtual Image ImgOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgOptiFabric = value;
        }
    }

    internal virtual TextBlock LabOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabOptiFabric = value;
        }
    }

    internal virtual Grid BtnOptiFabricClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnOptiFabricClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = OptiFabric_Clear;
            Grid grid = _BtnOptiFabricClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnOptiFabricClear = value;
            grid = _BtnOptiFabricClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnOptiFabricClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnOptiFabricClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnOptiFabricClearInner = value;
        }
    }

    internal virtual MyCard CardLiteLoader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardLiteLoader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCard.SwapEventHandler obj = (object a0, ModBase.RouteEventArgs a1) =>
            {
                ReloadSelected();
            };
            MyCard.PreviewSwapEventHandler obj2 = CardLiteLoader_PreviewSwap;
            MyCard myCard = _CardLiteLoader;
            if (myCard != null)
            {
                myCard.Swap -= obj;
                myCard.PreviewSwap -= obj2;
            }
            _CardLiteLoader = value;
            myCard = _CardLiteLoader;
            if (myCard != null)
            {
                myCard.Swap += obj;
                myCard.PreviewSwap += obj2;
            }
        }
    }

    internal virtual StackPanel PanLiteLoader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLiteLoader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLiteLoader = value;
        }
    }

    internal virtual Grid PanLiteLoaderInfo_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanLiteLoaderInfo;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanLiteLoaderInfo = value;
        }
    }

    internal virtual Image ImgLiteLoader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _ImgLiteLoader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _ImgLiteLoader = value;
        }
    }

    internal virtual TextBlock LabLiteLoader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LabLiteLoader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LabLiteLoader = value;
        }
    }

    internal virtual Grid BtnLiteLoaderClear_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLiteLoaderClear;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = LiteLoader_Clear;
            Grid grid = _BtnLiteLoaderClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp -= value2;
            }
            _BtnLiteLoaderClear = value;
            grid = _BtnLiteLoaderClear;
            if (grid != null)
            {
                grid.MouseLeftButtonUp += value2;
            }
        }
    }

    internal virtual Path BtnLiteLoaderClearInner_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnLiteLoaderClearInner;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnLiteLoaderClearInner = value;
        }
    }

    internal virtual MyExtraTextButton BtnStart_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnStart;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyExtraTextButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                BtnStart_Click();
            };
            MyExtraTextButton myExtraTextButton = _BtnStart;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click -= obj;
            }
            _BtnStart = value;
            myExtraTextButton = _BtnStart;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click += obj;
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

    internal virtual MyLoading LoadMinecraft_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadMinecraft;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _LoadMinecraft = value;
        }
    }

    internal virtual MyLoading LoadOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                OptiFine_Loaded();
            };
            MyLoading myLoading = _LoadOptiFine;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadOptiFine = value;
            myLoading = _LoadOptiFine;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                Forge_Loaded();
            };
            MyLoading myLoading = _LoadForge;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadForge = value;
            myLoading = _LoadForge;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadNeoForge_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadNeoForge;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                NeoForge_Loaded();
            };
            MyLoading myLoading = _LoadNeoForge;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadNeoForge = value;
            myLoading = _LoadNeoForge;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadLiteLoader_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadLiteLoader;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                LiteLoader_Loaded();
            };
            MyLoading myLoading = _LoadLiteLoader;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadLiteLoader = value;
            myLoading = _LoadLiteLoader;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                Fabric_Loaded();
            };
            MyLoading myLoading = _LoadFabric;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadFabric = value;
            myLoading = _LoadFabric;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadFabricApi_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadFabricApi;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                FabricApi_Loaded();
            };
            MyLoading myLoading = _LoadFabricApi;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadFabricApi = value;
            myLoading = _LoadFabricApi;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    internal virtual MyLoading LoadOptiFabric_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _LoadOptiFabric;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyLoading.StateChangedEventHandler obj = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                ReloadSelected();
            };
            MyLoading.StateChangedEventHandler obj2 = (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
            {
                OptiFabric_Loaded();
            };
            MyLoading myLoading = _LoadOptiFabric;
            if (myLoading != null)
            {
                myLoading.StateChanged -= obj;
                myLoading.StateChanged -= obj2;
            }
            _LoadOptiFabric = value;
            myLoading = _LoadOptiFabric;
            if (myLoading != null)
            {
                myLoading.StateChanged += obj;
                myLoading.StateChanged += obj2;
            }
        }
    }

    public PageDownloadInstall()
    {
        Initialized += (object a0, EventArgs a1) =>
        {
            LoaderInit();
        };
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            Init();
        };
        IsLoad = false;
        IsInSelectPage = false;
        IsFirstLoaded = false;
        SelectedOptiFine = null;
        SelectedLiteLoader = null;
        SelectedForge = null;
        SelectedNeoForge = null;
        SelectedFabric = null;
        SelectedFabricApi = null;
        SelectedOptiFabric = null;
        IsSelectNameEdited = false;
        IsSelectNameChanging = false;
        AutoSelectedFabricApi = false;
        AutoSelectedOptiFabric = false;
        InitializeComponent();
        _InitWithEvents();
    }

    private void LoaderInit()
    {
        DisabledPageAnimControls.Add(BtnStart);
        PageLoaderInit(LoadMinecraft, PanLoad, PanAllBack, null, ModDownload.DlClientListLoader, (ModLoader.LoaderTask<string, ModDownload.DlClientListResult> a0) =>
        {
            LoadMinecraft_OnFinish();
        });
    }

    private void Init()
    {
        PanBack.ScrollToHome();
        ModDownload.DlOptiFineListLoader.Start();
        ModDownload.DlLiteLoaderListLoader.Start();
        ModDownload.DlFabricListLoader.Start();
        ModDownload.DlNeoForgeListLoader.Start();
        TextSelectName.ValidateRules = new Collection<ValidateBase>
        {
            new ValidateFolderName(ModMinecraft.McFolderSelected + "versions")
        };
        TextSelectName.Validate();
        ReloadSelected();
        if (!IsLoad)
        {
            IsLoad = true;
            ModDownloadLib.McDownloadForgeRecommendedRefresh();
            LoadOptiFine.State = ModDownload.DlOptiFineListLoader;
            LoadLiteLoader.State = ModDownload.DlLiteLoaderListLoader;
            LoadFabric.State = ModDownload.DlFabricListLoader;
            LoadFabricApi.State = ModDownload.DlFabricApiLoader;
            LoadNeoForge.State = ModDownload.DlNeoForgeListLoader;
            LoadOptiFabric.State = ModDownload.DlOptiFabricLoader;
        }
    }

    private void EnterSelectPage()
    {
        if (IsInSelectPage)
        {
            return;
        }
        IsInSelectPage = true;
        PanInner.Margin = new Thickness(25.0, 10.0, 25.0, 40.0);
        AutoSelectedFabricApi = false;
        AutoSelectedOptiFabric = false;
        IsSelectNameEdited = false;
        PanSelect.Visibility = Visibility.Visible;
        PanSelect.IsHitTestVisible = true;
        PanMinecraft.IsHitTestVisible = false;
        PanBack.IsHitTestVisible = false;
        PanBack.ScrollToHome();
        DisabledPageAnimControls.Remove(BtnStart);
        BtnStart.Show = true;
        CardOptiFine.IsSwapped = true;
        CardLiteLoader.IsSwapped = true;
        CardForge.IsSwapped = true;
        CardNeoForge.IsSwapped = true;
        CardFabric.IsSwapped = true;
        CardFabricApi.IsSwapped = true;
        CardOptiFabric.IsSwapped = true;
        foreach (FrameworkElement allAnimControl in GetAllAnimControls(PanSelect))
        {
            allAnimControl.Opacity = 1.0;
            if (allAnimControl.RenderTransform == null || allAnimControl.RenderTransform is TranslateTransform)
            {
                allAnimControl.RenderTransform = new TranslateTransform();
            }
        }
        if (ModMinecraft.McVersion.IsFormatFit(VanillaName))
        {
            ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion " + VanillaName, ModDownload.DlForgeVersionMain);
            LoadForge.State = loaderTask;
            loaderTask.Start(VanillaName);
        }
        ModDownload.DlFabricApiLoader.Start();
        ModDownload.DlOptiFabricLoader.Start();
        ModAnimation.AniStart(new ModAnimation.AniData[6]
        {
            ModAnimation.AaOpacity(PanMinecraft, 0.0 - PanMinecraft.Opacity, 70, 10),
            ModAnimation.AaTranslateX(PanMinecraft, -50.0 - ((TranslateTransform)PanMinecraft.RenderTransform).X, 90, 10),
            ModAnimation.AaCode(() =>
            {
                PanBack.ScrollToHome();
                TextSelectName.Validate();
                OptiFine_Loaded();
                LiteLoader_Loaded();
                Forge_Loaded();
                NeoForge_Loaded();
                Fabric_Loaded();
                FabricApi_Loaded();
                OptiFabric_Loaded();
                ReloadSelected();
                PanMinecraft.Visibility = Visibility.Collapsed;
            }, 0, After: true),
            ModAnimation.AaOpacity(PanSelect, 1.0 - PanSelect.Opacity, 70, 100),
            ModAnimation.AaTranslateX(PanSelect, 0.0 - ((TranslateTransform)PanSelect.RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
            ModAnimation.AaCode(() =>
            {
                PanBack.IsHitTestVisible = true;
                if (!IsFirstLoaded)
                {
                    IsFirstLoaded = true;
                    BtnOptiFineClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardOptiFine.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnLiteLoaderClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardLiteLoader.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnForgeClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardForge.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnNeoForgeClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardNeoForge.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnFabricClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardFabric.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnFabricApiClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardFabricApi.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                    BtnOptiFabricClearInner.SetBinding(Shape.FillProperty, new Binding("Foreground")
                    {
                        Source = CardOptiFabric.MainTextBlock,
                        Mode = BindingMode.OneWay
                    });
                }
            }, 0, After: true)
        }, "FrmDownloadInstall SelectPageSwitch", RefreshTime: true);
    }

    public void ExitSelectPage()
    {
        if (IsInSelectPage)
        {
            IsInSelectPage = false;
            PanInner.Margin = new Thickness(25.0, 10.0, 25.0, 25.0);
            DisabledPageAnimControls.Add(BtnStart);
            BtnStart.Show = false;
            ClearSelected();
            PanMinecraft.Visibility = Visibility.Visible;
            PanSelect.IsHitTestVisible = false;
            PanMinecraft.IsHitTestVisible = true;
            PanBack.IsHitTestVisible = false;
            PanBack.ScrollToHome();
            ModAnimation.AniStart(new ModAnimation.AniData[6]
            {
                ModAnimation.AaOpacity(PanSelect, 0.0 - PanSelect.Opacity, 70, 10),
                ModAnimation.AaTranslateX(PanSelect, 50.0 - ((TranslateTransform)PanSelect.RenderTransform).X, 90, 10),
                ModAnimation.AaCode(() =>
                {
                    PanBack.ScrollToHome();
                }, 0, After: true),
                ModAnimation.AaOpacity(PanMinecraft, 1.0 - PanMinecraft.Opacity, 70, 100),
                ModAnimation.AaTranslateX(PanMinecraft, 0.0 - ((TranslateTransform)PanMinecraft.RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
                ModAnimation.AaCode(() =>
                {
                    PanSelect.Visibility = Visibility.Collapsed;
                    PanBack.IsHitTestVisible = true;
                }, 0, After: true)
            }, "FrmDownloadInstall SelectPageSwitch");
        }
    }

    public void MinecraftSelected(MyListItem sender, MouseButtonEventArgs e)
    {
        VanillaName = sender.Title;
        VanillaData = (JObject)sender.Tag;
        VanillaIcon = sender.Logo;
        EnterSelectPage();
    }

    private void ReloadSelected()
    {
        if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init == null)
        {
            Interlocked.CompareExchange(ref _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init, new StaticLocalInitFlag(), null);
        }
        bool lockTaken = false;
        try
        {
            Monitor.Enter(_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init, ref lockTaken);
            if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State == 0)
            {
                _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State = 2;
                _0024STATIC_0024ReloadSelected_00242001_0024Ongoing = false;
            }
            else if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State == 2)
            {
                throw new IncompleteInitialization();
            }
        }
        finally
        {
            _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State = 1;
            if (lockTaken)
            {
                Monitor.Exit(_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init);
            }
        }
        if (VanillaName == null || _0024STATIC_0024ReloadSelected_00242001_0024Ongoing)
        {
            return;
        }
        _0024STATIC_0024ReloadSelected_00242001_0024Ongoing = true;
        SelectNameUpdate();
        ImgLogo.Source = GetSelectLogo();
        string text = LoadOptiFineGetError();
        CardOptiFine.MainSwap.Visibility = ((text != null) ? Visibility.Collapsed : Visibility.Visible);
        if (text != null)
        {
            CardOptiFine.IsSwapped = true;
        }
        SetPanelVisibility(PanOptiFineInfo, CardOptiFine.IsSwapped);
        if (SelectedOptiFine == null)
        {
            BtnOptiFineClear.Visibility = Visibility.Collapsed;
            ImgOptiFine.Visibility = Visibility.Collapsed;
            LabOptiFine.Text = text ?? "可以添加";
            LabOptiFine.Foreground = ModSecret.ColorGray4;
        }
        else
        {
            BtnOptiFineClear.Visibility = Visibility.Visible;
            ImgOptiFine.Visibility = Visibility.Visible;
            LabOptiFine.Text = SelectedOptiFine.DisplayName.Replace(VanillaName + " ", "");
            LabOptiFine.Foreground = ModSecret.ColorGray1;
        }
        if (VanillaDrop >= 130)
        {
            CardLiteLoader.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardLiteLoader.Visibility = Visibility.Visible;
            string text2 = LoadLiteLoaderGetError();
            CardLiteLoader.MainSwap.Visibility = ((text2 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text2 != null)
            {
                CardLiteLoader.IsSwapped = true;
            }
            SetPanelVisibility(PanLiteLoaderInfo, CardLiteLoader.IsSwapped);
            if (SelectedLiteLoader == null)
            {
                BtnLiteLoaderClear.Visibility = Visibility.Collapsed;
                ImgLiteLoader.Visibility = Visibility.Collapsed;
                LabLiteLoader.Text = text2 ?? "可以添加";
                LabLiteLoader.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnLiteLoaderClear.Visibility = Visibility.Visible;
                ImgLiteLoader.Visibility = Visibility.Visible;
                LabLiteLoader.Text = SelectedLiteLoader.Inherit;
                LabLiteLoader.Foreground = ModSecret.ColorGray1;
            }
        }
        if (!ModMinecraft.McVersion.IsFormatFit(VanillaName))
        {
            CardForge.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardForge.Visibility = Visibility.Visible;
            string text3 = LoadForgeGetError();
            CardForge.MainSwap.Visibility = ((text3 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text3 != null)
            {
                CardForge.IsSwapped = true;
            }
            SetPanelVisibility(PanForgeInfo, CardForge.IsSwapped);
            if (SelectedForge == null)
            {
                BtnForgeClear.Visibility = Visibility.Collapsed;
                ImgForge.Visibility = Visibility.Collapsed;
                LabForge.Text = text3 ?? "可以添加";
                LabForge.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnForgeClear.Visibility = Visibility.Visible;
                ImgForge.Visibility = Visibility.Visible;
                LabForge.Text = SelectedForge.VersionName;
                LabForge.Foreground = ModSecret.ColorGray1;
            }
        }
        if (DateTime.Compare(VanillaData["releaseTime"].ToObject<DateTime>(), new DateTime(2023, 6, 11)) < 0)
        {
            CardNeoForge.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardNeoForge.Visibility = Visibility.Visible;
            string text4 = LoadNeoForgeGetError();
            CardNeoForge.MainSwap.Visibility = ((text4 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text4 != null)
            {
                CardNeoForge.IsSwapped = true;
            }
            SetPanelVisibility(PanNeoForgeInfo, CardNeoForge.IsSwapped);
            if (SelectedNeoForge == null)
            {
                BtnNeoForgeClear.Visibility = Visibility.Collapsed;
                ImgNeoForge.Visibility = Visibility.Collapsed;
                LabNeoForge.Text = text4 ?? "可以添加";
                LabNeoForge.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnNeoForgeClear.Visibility = Visibility.Visible;
                ImgNeoForge.Visibility = Visibility.Visible;
                LabNeoForge.Text = SelectedNeoForge.VersionName;
                LabNeoForge.Foreground = ModSecret.ColorGray1;
            }
        }
        if (VanillaDrop <= 130)
        {
            CardFabric.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardFabric.Visibility = Visibility.Visible;
            string text5 = LoadFabricGetError();
            CardFabric.MainSwap.Visibility = ((text5 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text5 != null)
            {
                CardFabric.IsSwapped = true;
            }
            SetPanelVisibility(PanFabricInfo, CardFabric.IsSwapped);
            if (SelectedFabric == null)
            {
                BtnFabricClear.Visibility = Visibility.Collapsed;
                ImgFabric.Visibility = Visibility.Collapsed;
                LabFabric.Text = text5 ?? "可以添加";
                LabFabric.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnFabricClear.Visibility = Visibility.Visible;
                ImgFabric.Visibility = Visibility.Visible;
                LabFabric.Text = SelectedFabric.Replace("+build", "");
                LabFabric.Foreground = ModSecret.ColorGray1;
            }
        }
        if (SelectedFabric == null)
        {
            CardFabricApi.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardFabricApi.Visibility = Visibility.Visible;
            string text6 = LoadFabricApiGetError();
            CardFabricApi.MainSwap.Visibility = ((text6 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text6 != null || SelectedFabric == null)
            {
                CardFabricApi.IsSwapped = true;
            }
            SetPanelVisibility(PanFabricApiInfo, CardFabricApi.IsSwapped);
            if (SelectedFabricApi == null)
            {
                BtnFabricApiClear.Visibility = Visibility.Collapsed;
                ImgFabricApi.Visibility = Visibility.Collapsed;
                LabFabricApi.Text = text6 ?? "可以添加";
                LabFabricApi.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnFabricApiClear.Visibility = Visibility.Visible;
                ImgFabricApi.Visibility = Visibility.Visible;
                LabFabricApi.Text = StringExtensions.Split(StringExtensions.Split(SelectedFabricApi.Display, "]", false)[1].Replace("Fabric API ", "").Replace(" build ", "."), "+", false).First().Trim();
                LabFabricApi.Foreground = ModSecret.ColorGray1;
            }
        }
        if (SelectedFabric == null || SelectedOptiFine == null)
        {
            CardOptiFabric.Visibility = Visibility.Collapsed;
        }
        else
        {
            CardOptiFabric.Visibility = Visibility.Visible;
            string text7 = LoadOptiFabricGetError();
            CardOptiFabric.MainSwap.Visibility = ((text7 != null) ? Visibility.Collapsed : Visibility.Visible);
            if (text7 != null || SelectedFabric == null)
            {
                CardOptiFabric.IsSwapped = true;
            }
            SetPanelVisibility(PanOptiFabricInfo, CardOptiFabric.IsSwapped);
            if (SelectedOptiFabric == null)
            {
                BtnOptiFabricClear.Visibility = Visibility.Collapsed;
                ImgOptiFabric.Visibility = Visibility.Collapsed;
                LabOptiFabric.Text = text7 ?? "可以添加";
                LabOptiFabric.Foreground = ModSecret.ColorGray4;
            }
            else
            {
                BtnOptiFabricClear.Visibility = Visibility.Visible;
                ImgOptiFabric.Visibility = Visibility.Visible;
                LabOptiFabric.Text = StringExtensions.Lower(SelectedOptiFabric.Display).Replace("optifabric-", "").Replace(".jar", "")
                    .Trim()
                    .TrimStart('v');
                LabOptiFabric.Foreground = ModSecret.ColorGray1;
            }
        }
        if (SelectedFabric != null && SelectedFabricApi == null)
        {
            HintFabricAPI.Visibility = Visibility.Visible;
        }
        else
        {
            HintFabricAPI.Visibility = Visibility.Collapsed;
        }
        if (SelectedFabric != null && SelectedOptiFine != null && SelectedOptiFabric == null)
        {
            if (VanillaDrop >= 140 && VanillaDrop <= 150)
            {
                HintOptiFabric.Visibility = Visibility.Collapsed;
                HintOptiFabricOld.Visibility = Visibility.Visible;
            }
            else
            {
                HintOptiFabric.Visibility = Visibility.Visible;
                HintOptiFabricOld.Visibility = Visibility.Collapsed;
            }
        }
        else
        {
            HintOptiFabric.Visibility = Visibility.Collapsed;
            HintOptiFabricOld.Visibility = Visibility.Collapsed;
        }
        if (VanillaDrop >= 160 && SelectedOptiFine != null && (SelectedForge != null || SelectedFabric != null))
        {
            HintModOptiFine.Visibility = Visibility.Visible;
        }
        else
        {
            HintModOptiFine.Visibility = Visibility.Collapsed;
        }
        _0024STATIC_0024ReloadSelected_00242001_0024Ongoing = false;
    }

    private void ClearSelected()
    {
        VanillaName = null;
        VanillaData = null;
        VanillaIcon = null;
        SelectedOptiFine = null;
        SelectedLiteLoader = null;
        SelectedForge = null;
        SelectedNeoForge = null;
        SelectedFabric = null;
        SelectedFabricApi = null;
        SelectedOptiFabric = null;
        IsSelectNameEdited = false;
    }

    private void SetPanelVisibility(Grid Panel, bool IsVisible)
    {
        if (!Operators.ConditionalCompareObjectEqual(Panel.Tag, IsVisible.ToString(), TextCompare: false))
        {
            Panel.Tag = IsVisible.ToString();
            if (IsVisible)
            {
                ModAnimation.AniStart(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaTranslateY(Panel, 0.0 - ((TranslateTransform)Panel.RenderTransform).Y, 150, 0, new ModAnimation.AniEaseOutFluent()),
                    ModAnimation.AaOpacity(Panel, 1.0 - Panel.Opacity, 60)
                }, "PageDownloadInstall Visibility " + Panel.Name);
            }
            else
            {
                ModAnimation.AniStart(new ModAnimation.AniData[2]
                {
                    ModAnimation.AaTranslateY(Panel, 6.0 - ((TranslateTransform)Panel.RenderTransform).Y, 60),
                    ModAnimation.AaOpacity(Panel, 0.0 - Panel.Opacity, 60)
                }, "PageDownloadInstall Visibility " + Panel.Name);
            }
        }
    }

    private string GetSelectLogo()
    {
        if (SelectedFabric != null)
        {
            return "pack://application:,,,/images/Blocks/Fabric.png";
        }
        if (SelectedForge != null)
        {
            return "pack://application:,,,/images/Blocks/Anvil.png";
        }
        if (SelectedNeoForge != null)
        {
            return "pack://application:,,,/images/Blocks/NeoForge.png";
        }
        if (SelectedLiteLoader != null)
        {
            return "pack://application:,,,/images/Blocks/Egg.png";
        }
        if (SelectedOptiFine != null)
        {
            return "pack://application:,,,/images/Blocks/GrassPath.png";
        }
        return VanillaIcon;
    }

    private string GetSelectName()
    {
        string text = VanillaName;
        if (SelectedFabric != null)
        {
            text = text + "-Fabric " + StringExtensions.BeforeFirst(SelectedFabric, "+", false);
        }
        if (SelectedForge != null)
        {
            text = text + "-Forge_" + SelectedForge.VersionName;
        }
        if (SelectedNeoForge != null)
        {
            text = text + "-NeoForge_" + StringExtensions.BeforeFirst(SelectedNeoForge.VersionName, "+", false);
        }
        if (SelectedLiteLoader != null)
        {
            text += "-LiteLoader";
        }
        if (SelectedOptiFine != null)
        {
            text = text + "-OptiFine_" + SelectedOptiFine.DisplayName.Replace(VanillaName + " ", "").Replace(" ", "_");
        }
        return text;
    }

    private void SelectNameUpdate()
    {
        if (!IsSelectNameEdited && !IsSelectNameChanging)
        {
            IsSelectNameChanging = true;
            TextSelectName.Text = GetSelectName();
            IsSelectNameChanging = false;
        }
    }

    private void TextSelectName_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!IsSelectNameChanging)
        {
            IsSelectNameEdited = true;
            ReloadSelected();
        }
    }

    private void TextSelectName_ValidateChanged(object sender, EventArgs e)
    {
        BtnStart.IsEnabled = TextSelectName.IsValidated;
    }

    private void LoadMinecraft_OnFinish()
    {
        ExitSelectPage();
        try
        {
            Dictionary<string, List<JObject>> dictionary = new Dictionary<string, List<JObject>>
            {
                {
                    "正式版",
                    new List<JObject>()
                },
                {
                    "预览版",
                    new List<JObject>()
                },
                {
                    "远古版",
                    new List<JObject>()
                },
                {
                    "愚人节版",
                    new List<JObject>()
                }
            };
            JArray val = (JArray)ModDownload.DlClientListLoader.Output.Value["versions"];
            foreach (JObject item in val)
            {
                JObject val2 = item;
                string key;
                switch ((string)val2["type"])
                {
                    case "release":
                        key = "正式版";
                        break;
                    case "snapshot":
                        key = "预览版";
                        if (StringExtensions.StartsWithF(val2["id"].ToString(), "1.", false) && !StringExtensions.Lower(val2["id"].ToString()).Contains("combat") && !StringExtensions.Lower(val2["id"].ToString()).Contains("rc") && !StringExtensions.Lower(val2["id"].ToString()).Contains("experimental") && !StringExtensions.Lower(val2["id"].ToString()).Contains("pre"))
                        {
                            key = "正式版";
                            val2["type"] = (JToken)("release");
                        }
                        switch (StringExtensions.Lower(val2["id"].ToString()))
                        {
                            case "20w14infinite":
                            case "20w14∞":
                                key = "愚人节版";
                                val2["id"] = (JToken)("20w14∞");
                                val2["type"] = (JToken)("special");
                                val2.Add("lore", (JToken)(ModMinecraft.GetMcFoolName((string)val2["id"])));
                                break;
                            case "3d shareware v1.34":
                            case "1.rv-pre1":
                            case "15w14a":
                            case "2.0":
                            case "22w13oneblockatatime":
                            case "23w13a_or_b":
                            case "24w14potato":
                            case "25w14craftmine":
                            case "26w14a":
                                key = "愚人节版";
                                val2["type"] = (JToken)("special");
                                val2.Add("lore", (JToken)(ModMinecraft.GetMcFoolName((string)val2["id"])));
                                break;
                            default:
                                {
                                    DateTime dateTime = Extensions.Value<DateTime>((IEnumerable<JToken>)val2["releaseTime"]).ToUniversalTime().AddHours(2.0);
                                    if (dateTime.Month == 4 && dateTime.Day == 1)
                                    {
                                        key = "愚人节版";
                                        val2["type"] = (JToken)("special");
                                    }
                                    break;
                                }
                        }
                        break;
                    case "special":
                        key = "愚人节版";
                        break;
                    default:
                        key = "远古版";
                        break;
                }
                dictionary[key].Add(val2);
            }
            foreach (KeyValuePair<string, List<JObject>> item2 in dictionary.ToList())
            {
                dictionary[item2.Key] = item2.Value.OrderByDescending((_Closure_0024__._0024I32_002D0 == null) ? (_Closure_0024__._0024I32_002D0 = (JObject j) => Extensions.Value<DateTime>((IEnumerable<JToken>)j["releaseTime"])) : _Closure_0024__._0024I32_002D0).ToList();
            }
            PanMinecraft.Children.Clear();
            MyCard myCard = new MyCard
            {
                Title = "最新版本",
                Margin = new Thickness(0.0, 15.0, 0.0, 15.0),
                SwapType = 2
            };
            List<JObject> list = new List<JObject>();
            JObject val3 = (JObject)((JToken)dictionary["正式版"][0]).DeepClone();
            val3["lore"] = (JToken)("最新正式版，发布于 " + Extensions.Value<DateTime>((IEnumerable<JToken>)val3["releaseTime"]).ToString("yyyy'/'MM'/'dd HH':'mm"));
            list.Add(val3);
            if (DateTime.Compare(Extensions.Value<DateTime>((IEnumerable<JToken>)dictionary["正式版"][0]["releaseTime"]), Extensions.Value<DateTime>((IEnumerable<JToken>)dictionary["预览版"][0]["releaseTime"])) < 0)
            {
                JObject val4 = (JObject)((JToken)dictionary["预览版"][0]).DeepClone();
                val4["lore"] = (JToken)("最新预览版，发布于 " + Extensions.Value<DateTime>((IEnumerable<JToken>)val4["releaseTime"]).ToString("yyyy'/'MM'/'dd HH':'mm"));
                list.Add(val4);
            }
            StackPanel Stack = new StackPanel
            {
                Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
                VerticalAlignment = VerticalAlignment.Top,
                RenderTransform = new TranslateTransform(0.0, 0.0),
                Tag = list
            };
            MyCard.StackInstall(ref Stack, 7);
            myCard.Children.Add(Stack);
            PanMinecraft.Children.Insert(0, myCard);
            foreach (KeyValuePair<string, List<JObject>> item3 in dictionary)
            {
                if (item3.Value.Any())
                {
                    MyCard myCard2 = new MyCard
                    {
                        Title = item3.Key,
                        Margin = new Thickness(0.0, 0.0, 0.0, 15.0),
                        SwapType = 7
                    };
                    StackPanel stackPanel = new StackPanel
                    {
                        Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
                        VerticalAlignment = VerticalAlignment.Top,
                        RenderTransform = new TranslateTransform(0.0, 0.0),
                        Tag = item3.Value
                    };
                    myCard2.Children.Add(stackPanel);
                    myCard2.SwapControl = stackPanel;
                    myCard2.IsSwapped = true;
                    PanMinecraft.Children.Add(myCard2);
                }
            }
            if (VersionWaitingSelect == null)
            {
                return;
            }
            Logger.Info($"自动选择 MC 版本：{VersionWaitingSelect}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            foreach (JObject item4 in val)
            {
                JObject val5 = item4;
                if (Operators.CompareString(val5["id"].ToString(), VersionWaitingSelect, TextCompare: false) == 0)
                {
                    MyListItem sender = ModDownloadLib.McDownloadListItem(val5, (MyListItem.ClickEventHandler)((object a0, System.Windows.Input.MouseButtonEventArgs a1) =>
                    {
                    }), false).Init();
                    MinecraftSelected(sender, null);
                    VersionWaitingSelect = null;
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private string LoadOptiFineGetError()
    {
        if (SelectedNeoForge != null)
        {
            return "与 NeoForge 不兼容";
        }
        if (SelectedForge != null && ModMinecraft.CompareVersion(VanillaName, "1.13") >= 0 && ModMinecraft.CompareVersion("1.14.3", VanillaName) >= 0)
        {
            return "与 Forge 不兼容";
        }
        if (SelectedFabric != null && ModMinecraft.CompareVersion(VanillaName, "1.20.4") > 0)
        {
            return "与 Fabric 不兼容";
        }
        if (GetLoaderError(LoadOptiFine) != null)
        {
            return GetLoaderError(LoadOptiFine);
        }
        bool flag = false;
        bool flag2 = false;
        foreach (ModDownload.DlOptiFineListEntry item in ModDownload.DlOptiFineListLoader.Output.Value)
        {
            if (StringExtensions.StartsWithF(item.DisplayName, VanillaName + " ", false))
            {
                flag = true;
                if (SelectedForge == null)
                {
                    return null;
                }
                if (Conversions.ToBoolean(IsOptiFineSuitForForge(item, SelectedForge)))
                {
                    return null;
                }
                if (item.RequiredForgeVersion != null)
                {
                    flag2 = true;
                }
            }
        }
        if (!flag)
        {
            return "无";
        }
        if (flag2)
        {
            return "仅兼容特定版本的 Forge";
        }
        return "与 Forge 不兼容";
    }

    private object IsOptiFineSuitForForge(ModDownload.DlOptiFineListEntry OptiFine, ModDownload.DlForgeVersionEntry Forge)
    {
        if (Operators.CompareString(Forge.Inherit, OptiFine.Inherit, TextCompare: false) != 0)
        {
            return false;
        }
        if (OptiFine.RequiredForgeVersion == null)
        {
            return false;
        }
        if (string.IsNullOrWhiteSpace(OptiFine.RequiredForgeVersion))
        {
            return true;
        }
        if (OptiFine.RequiredForgeVersion.Contains("."))
        {
            return ModMinecraft.CompareVersion(Forge.Version.ToString(), OptiFine.RequiredForgeVersion) == 0;
        }
        return (double)Forge.Version.Revision == Conversions.ToDouble(OptiFine.RequiredForgeVersion);
    }

    private void CardOptiFine_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadOptiFineGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void OptiFine_Loaded()
    {
        try
        {
            if (ModDownload.DlOptiFineListLoader.State != ModBase.LoadState.Finished)
            {
                return;
            }
            List<ModDownload.DlOptiFineListEntry> list = new List<ModDownload.DlOptiFineListEntry>();
            foreach (ModDownload.DlOptiFineListEntry item in ModDownload.DlOptiFineListLoader.Output.Value)
            {
                if (!Conversions.ToBoolean(SelectedForge != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(item, SelectedForge)))) && StringExtensions.StartsWithF(item.DisplayName, VanillaName + " ", false))
                {
                    list.Add(item);
                }
            }
            if (!list.Any())
            {
                return;
            }
            list = ModBase.SortByComparison(list, (ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right) =>
            {
                if (!Left.IsPreview && Right.IsPreview)
                {
                    return true;
                }
                return (!Left.IsPreview || Right.IsPreview) && ModMinecraft.CompareVersionGE(Left.DisplayName, Right.DisplayName);
            });
            PanOptiFine.Children.Clear();
            foreach (ModDownload.DlOptiFineListEntry item2 in list)
            {
                PanOptiFine.Children.Add(ModDownloadLib.OptiFineDownloadListItem(item2, (object a0, MouseButtonEventArgs a1) =>
                {
                    OptiFine_Selected((MyListItem)a0, a1);
                }, IsSaveOnly: false));
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 OptiFine 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void OptiFine_Selected(MyListItem sender, EventArgs e)
    {
        SelectedOptiFine = (ModDownload.DlOptiFineListEntry)sender.Tag;
        if (Conversions.ToBoolean(SelectedForge != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge)))))
        {
            SelectedForge = null;
        }
        OptiFabric_Loaded();
        Forge_Loaded();
        NeoForge_Loaded();
        CardOptiFine.IsSwapped = true;
        ReloadSelected();
    }

    private void OptiFine_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedOptiFine = null;
        SelectedOptiFabric = null;
        AutoSelectedOptiFabric = false;
        CardOptiFine.IsSwapped = true;
        e.Handled = true;
        Forge_Loaded();
        NeoForge_Loaded();
        ReloadSelected();
    }

    private string LoadLiteLoaderGetError()
    {
        if (GetLoaderError(LoadLiteLoader) != null)
        {
            return GetLoaderError(LoadLiteLoader);
        }
        return ModDownload.DlLiteLoaderListLoader.Output.Value.Any((ModDownload.DlLiteLoaderListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0) ? null : "无";
    }

    private void CardLiteLoader_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadLiteLoaderGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void LiteLoader_Loaded()
    {
        try
        {
            if (ModDownload.DlLiteLoaderListLoader.State != ModBase.LoadState.Finished)
            {
                return;
            }
            List<ModDownload.DlLiteLoaderListEntry> list = new List<ModDownload.DlLiteLoaderListEntry>();
            foreach (ModDownload.DlLiteLoaderListEntry item in ModDownload.DlLiteLoaderListLoader.Output.Value)
            {
                if (Operators.CompareString(item.Inherit, VanillaName, TextCompare: false) == 0)
                {
                    list.Add(item);
                }
            }
            if (!list.Any())
            {
                return;
            }
            PanLiteLoader.Children.Clear();
            foreach (ModDownload.DlLiteLoaderListEntry item2 in list)
            {
                PanLiteLoader.Children.Add(ModDownloadLib.LiteLoaderDownloadListItem(item2, (object a0, MouseButtonEventArgs a1) =>
                {
                    LiteLoader_Selected((MyListItem)a0, a1);
                }, IsSaveOnly: false));
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 LiteLoader 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void LiteLoader_Selected(MyListItem sender, EventArgs e)
    {
        SelectedLiteLoader = (ModDownload.DlLiteLoaderListEntry)sender.Tag;
        CardLiteLoader.IsSwapped = true;
        ReloadSelected();
    }

    private void LiteLoader_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedLiteLoader = null;
        CardLiteLoader.IsSwapped = true;
        e.Handled = true;
        ReloadSelected();
    }

    private string LoadForgeGetError()
    {
        if (ModMinecraft.CompareVersionGE("1.5.1", VanillaName) && ModMinecraft.CompareVersionGE(VanillaName, "1.1"))
        {
            return "无";
        }
        if (GetLoaderError(LoadForge) != null)
        {
            return GetLoaderError(LoadForge);
        }
        ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
        if (Operators.CompareString(VanillaName, loaderTask.Input, TextCompare: false) != 0)
        {
            return "获取中……";
        }
        foreach (ModDownload.DlForgeVersionEntry item in loaderTask.Output)
        {
            if (Operators.CompareString(item.Category, "universal", TextCompare: false) != 0 && Operators.CompareString(item.Category, "client", TextCompare: false) != 0)
            {
                if (SelectedNeoForge != null)
                {
                    return "与 NeoForge 不兼容";
                }
                if (SelectedFabric != null)
                {
                    return "与 Fabric 不兼容";
                }
                if (SelectedOptiFine != null && ModMinecraft.CompareVersionGE(VanillaName, "1.13") && ModMinecraft.CompareVersionGE("1.14.3", VanillaName))
                {
                    return "与 OptiFine 不兼容";
                }
                if (!Conversions.ToBoolean(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, item)))))
                {
                    return null;
                }
            }
        }
        return "与 OptiFine 不兼容";
    }

    private void CardForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadForgeGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void Forge_Loaded()
    {
        try
        {
            if (!LoadForge.State.IsLoader)
            {
                return;
            }
            ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
            if (Operators.CompareString(VanillaName, loaderTask.Input, TextCompare: false) != 0 || loaderTask.State != ModBase.LoadState.Finished)
            {
                return;
            }
            List<ModDownload.DlForgeVersionEntry> source = loaderTask.Output.ToList();
            if (!loaderTask.Output.Any())
            {
                return;
            }
            PanForge.Children.Clear();
            source = (from v in source.Where((ModDownload.DlForgeVersionEntry v) =>
                {
                    if (Operators.CompareString(v.Category, "universal", TextCompare: false) == 0 || Operators.CompareString(v.Category, "client", TextCompare: false) == 0)
                    {
                        return false;
                    }
                    return !Conversions.ToBoolean(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, v))));
                })
                      orderby v descending
                      select v).ToList();
            ModDownloadLib.ForgeDownloadListItemPreload(PanForge, source, (object a0, MouseButtonEventArgs a1) =>
            {
                Forge_Selected((MyListItem)a0, a1);
            }, IsSaveOnly: false);
            foreach (ModDownload.DlForgeVersionEntry item in source)
            {
                PanForge.Children.Add(ModDownloadLib.ForgeDownloadListItem(item, (object a0, MouseButtonEventArgs a1) =>
                {
                    Forge_Selected((MyListItem)a0, a1);
                }, IsSaveOnly: false));
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 Forge 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void Forge_Selected(MyListItem sender, EventArgs e)
    {
        SelectedForge = (ModDownload.DlForgeVersionEntry)sender.Tag;
        CardForge.IsSwapped = true;
        if (Conversions.ToBoolean(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge)))))
        {
            SelectedOptiFine = null;
        }
        OptiFine_Loaded();
        ReloadSelected();
    }

    private void Forge_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedForge = null;
        CardForge.IsSwapped = true;
        e.Handled = true;
        OptiFine_Loaded();
        ReloadSelected();
    }

    private string LoadNeoForgeGetError()
    {
        if (SelectedOptiFine != null)
        {
            return "与 OptiFine 不兼容";
        }
        if (SelectedForge != null)
        {
            return "与 Forge 不兼容";
        }
        if (SelectedFabric != null)
        {
            return "与 Fabric 不兼容";
        }
        if (GetLoaderError(LoadNeoForge) != null)
        {
            return GetLoaderError(LoadNeoForge);
        }
        return ModDownload.DlNeoForgeListLoader.Output.Value.Any((ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0) ? null : "无";
    }

    private void CardNeoForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadNeoForgeGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void NeoForge_Loaded()
    {
        try
        {
            if (ModDownload.DlNeoForgeListLoader.State != ModBase.LoadState.Finished)
            {
                return;
            }
            List<ModDownload.DlNeoForgeListEntry> list = ModDownload.DlNeoForgeListLoader.Output.Value.Where((ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0).ToList();
            if (!list.Any())
            {
                return;
            }
            PanNeoForge.Children.Clear();
            ModDownloadLib.NeoForgeDownloadListItemPreload(PanNeoForge, list, (object a0, MouseButtonEventArgs a1) =>
            {
                NeoForge_Selected((MyListItem)a0, a1);
            }, IsSaveOnly: false);
            foreach (ModDownload.DlNeoForgeListEntry item in list)
            {
                PanNeoForge.Children.Add(ModDownloadLib.NeoForgeDownloadListItem(item, (object a0, MouseButtonEventArgs a1) =>
                {
                    NeoForge_Selected((MyListItem)a0, a1);
                }, IsSaveOnly: false));
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 NeoForge 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void NeoForge_Selected(MyListItem sender, EventArgs e)
    {
        SelectedNeoForge = (ModDownload.DlNeoForgeListEntry)sender.Tag;
        CardNeoForge.IsSwapped = true;
        OptiFine_Loaded();
        ReloadSelected();
    }

    private void NeoForge_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedNeoForge = null;
        CardNeoForge.IsSwapped = true;
        e.Handled = true;
        OptiFine_Loaded();
        ReloadSelected();
    }

    private string LoadFabricGetError()
    {
        if (SelectedOptiFine != null && ModMinecraft.CompareVersionGE(VanillaName, "1.20.5"))
        {
            return "与 OptiFine 不兼容";
        }
        if (GetLoaderError(LoadFabric) != null)
        {
            return GetLoaderError(LoadFabric);
        }
        foreach (JObject item in (IEnumerable<JToken>)ModDownload.DlFabricListLoader.Output.Value["game"])
        {
            if (Operators.CompareString(item["version"].ToString(), VanillaName.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3"), TextCompare: false) == 0)
            {
                if (SelectedForge != null)
                {
                    return "与 Forge 不兼容";
                }
                if (SelectedNeoForge != null)
                {
                    return "与 NeoForge 不兼容";
                }
                return null;
            }
        }
        return "无";
    }

    private void CardFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadFabricGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void Fabric_Loaded()
    {
        try
        {
            if (ModDownload.DlFabricListLoader.State == ModBase.LoadState.Finished)
            {
                JArray val = (JArray)ModDownload.DlFabricListLoader.Output.Value["loader"];
                if (((IEnumerable<JToken>)val).Any())
                {
                    PanFabric.Children.Clear();
                    PanFabric.Tag = val;
                    CardFabric.SwapControl = PanFabric;
                    CardFabric.SwapType = 12;
                }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 Fabric 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    public void Fabric_Selected(MyListItem sender, EventArgs e)
    {
        SelectedFabric = NewLateBinding.LateIndexGet(sender.Tag, new object[1] { "version" }, null).ToString();
        FabricApi_Loaded();
        OptiFabric_Loaded();
        CardFabric.IsSwapped = true;
        ReloadSelected();
    }

    private void Fabric_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedFabric = null;
        SelectedFabricApi = null;
        AutoSelectedFabricApi = false;
        SelectedOptiFabric = null;
        AutoSelectedOptiFabric = false;
        CardFabric.IsSwapped = true;
        e.Handled = true;
        ReloadSelected();
    }

    public bool IsFabricApiCompatible(ResourceVersion FabricApi)
    {
        string text = FabricApi.Display;
        checked
        {
            bool result;
            try
            {
                if (text == null || VanillaName == null)
                {
                    result = false;
                }
                else
                {
                    text = StringExtensions.Lower(text);
                    string text2 = StringExtensions.Lower(VanillaName.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3"));
                    if (StringExtensions.StartsWithF(text, "[" + text2 + "]", false))
                    {
                        result = true;
                    }
                    else if (!text.Contains("/") || !text.Contains("]"))
                    {
                        result = false;
                    }
                    else
                    {
                        string[] array = StringExtensions.Split(StringExtensions.BeforeFirst(text, "]", false).TrimStart('['), "/", false);
                        int num = 0;
                        while (true)
                        {
                            if (num < array.Length)
                            {
                                if (Operators.CompareString(array[num], text2, TextCompare: false) == 0)
                                {
                                    result = true;
                                    break;
                                }
                                num++;
                                continue;
                            }
                            List<string> list = StringExtensions.RegexSearch(StringExtensions.BeforeFirst(text, "]", false), "[a-z/]+|[0-9/]+", RegexOptions.None).ToList();
                            List<string> list2 = StringExtensions.RegexSearch(StringExtensions.BeforeFirst(text2, "]", false), "[a-z/]+|[0-9/]+", RegexOptions.None).ToList();
                            int num2 = 0;
                            while (true)
                            {
                                if (list.Count - 1 < num2 && list2.Count - 1 < num2)
                                {
                                    result = true;
                                    break;
                                }
                                string text3 = ((list.Count - 1 < num2) ? "-1" : list[num2]);
                                string text4 = ((list2.Count - 1 < num2) ? "-1" : list2[num2]);
                                if (!text3.Contains("/"))
                                {
                                    if (Operators.CompareString(text3, text4, TextCompare: false) != 0)
                                    {
                                        result = false;
                                        break;
                                    }
                                }
                                else if (!text3.Contains(text4))
                                {
                                    result = false;
                                    break;
                                }
                                num2++;
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, $"判断 Fabric API 版本适配性出错（{text}, {VanillaName}）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        }
    }

    private string LoadFabricApiGetError()
    {
        if (GetLoaderError(LoadFabricApi) != null)
        {
            return GetLoaderError(LoadFabricApi);
        }
        if (ModDownload.DlFabricApiLoader.Output == null)
        {
            return (SelectedFabric == null) ? "需要安装 Fabric" : "获取中……";
        }
        if (ModDownload.DlFabricApiLoader.Output.Any((ResourceVersion f) => IsFabricApiCompatible(f)))
        {
            return (SelectedFabric == null) ? "需要安装 Fabric" : null;
        }
        return "无";
    }

    private void CardFabricApi_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadFabricApiGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void FabricApi_Loaded()
    {
        try
        {
            if (ModDownload.DlFabricApiLoader.State != ModBase.LoadState.Finished || VanillaName == null || SelectedFabric == null)
            {
                return;
            }
            List<ResourceVersion> list = new List<ResourceVersion>();
            foreach (ResourceVersion item in ModDownload.DlFabricApiLoader.Output)
            {
                if (IsFabricApiCompatible(item))
                {
                    if (!StringExtensions.StartsWithF(item.Display, "[", false))
                    {
                        Logger.Warn($"已特判修改 Fabric API 显示名：{item.Display}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
                        item.Display = "[" + VanillaName + "] " + item.Display;
                    }
                    list.Add(item);
                }
            }
            if (!list.Any())
            {
                return;
            }
            list = list.OrderByDescending((ResourceVersion v) => v.ReleaseDate).ToList();
            PanFabricApi.Children.Clear();
            foreach (ResourceVersion item2 in list)
            {
                if (IsFabricApiCompatible(item2))
                {
                    PanFabricApi.Children.Add(ModDownloadLib.FabricApiDownloadListItem(item2, (object a0, MouseButtonEventArgs a1) =>
                    {
                        FabricApi_Selected((MyListItem)a0, a1);
                    }));
                }
            }
            if (!AutoSelectedFabricApi)
            {
                AutoSelectedFabricApi = true;
                MyListItem myListItem = (MyListItem)MyVirtualizingElement.TryInit((FrameworkElement)PanFabricApi.Children[0]);
                Logger.Info($"已自动选择 Fabric API：{myListItem.Title}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
                FabricApi_Selected(myListItem, null);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 Fabric API 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void FabricApi_Selected(MyListItem sender, EventArgs e)
    {
        SelectedFabricApi = (ResourceVersion)sender.Tag;
        CardFabricApi.IsSwapped = true;
        ReloadSelected();
    }

    private void FabricApi_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedFabricApi = null;
        CardFabricApi.IsSwapped = true;
        e.Handled = true;
        ReloadSelected();
    }

    private bool IsOptiFabricCompatible(ResourceVersion ModFile)
    {
        bool result;
        try
        {
            result = VanillaName != null && ModFile.GameVersions.Contains(VanillaName);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, $"判断 OptiFabric 版本适配性出错（{VanillaName}）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            result = false;
            ProjectData.ClearProjectError();
        }
        return result;
    }

    private string LoadOptiFabricGetError()
    {
        if (VanillaDrop >= 140 && VanillaDrop <= 150)
        {
            return "不兼容老版本 Fabric，请手动下载 OptiFabric Origins";
        }
        if (GetLoaderError(LoadOptiFabric) != null)
        {
            return GetLoaderError(LoadOptiFabric);
        }
        if (ModDownload.DlOptiFabricLoader.Output == null)
        {
            if (SelectedFabric == null && SelectedOptiFine == null)
            {
                return "需要安装 OptiFine 与 Fabric";
            }
            if (SelectedFabric == null)
            {
                return "需要安装 Fabric";
            }
            if (SelectedOptiFine == null)
            {
                return "需要安装 OptiFine";
            }
            return "获取中……";
        }
        foreach (ResourceVersion item in ModDownload.DlOptiFabricLoader.Output)
        {
            if (IsOptiFabricCompatible(item))
            {
                if (SelectedFabric == null && SelectedOptiFine == null)
                {
                    return "需要安装 OptiFine 与 Fabric";
                }
                if (SelectedFabric == null)
                {
                    return "需要安装 Fabric";
                }
                if (SelectedOptiFine == null)
                {
                    return "需要安装 OptiFine";
                }
                return null;
            }
        }
        return "无";
    }

    private void CardOptiFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
    {
        if (LoadOptiFabricGetError() != null)
        {
            e.Handled = true;
        }
    }

    private void OptiFabric_Loaded()
    {
        try
        {
            if (ModDownload.DlOptiFabricLoader.State != ModBase.LoadState.Finished || VanillaName == null || SelectedFabric == null || SelectedOptiFine == null)
            {
                return;
            }
            List<ResourceVersion> list = new List<ResourceVersion>();
            foreach (ResourceVersion item in ModDownload.DlOptiFabricLoader.Output)
            {
                if (IsOptiFabricCompatible(item))
                {
                    list.Add(item);
                }
            }
            if (!list.Any())
            {
                return;
            }
            list = list.OrderByDescending((ResourceVersion v) => v.ReleaseDate).ToList();
            PanOptiFabric.Children.Clear();
            foreach (ResourceVersion item2 in list)
            {
                if (IsOptiFabricCompatible(item2))
                {
                    PanOptiFabric.Children.Add(ModDownloadLib.OptiFabricDownloadListItem(item2, (object a0, MouseButtonEventArgs a1) =>
                    {
                        OptiFabric_Selected((MyListItem)a0, a1);
                    }));
                }
            }
            if (!AutoSelectedOptiFabric && (VanillaDrop < 140 || VanillaDrop > 150))
            {
                AutoSelectedOptiFabric = true;
                MyListItem myListItem = (MyListItem)MyVirtualizingElement.TryInit((FrameworkElement)PanOptiFabric.Children[0]);
                Logger.Info($"已自动选择 OptiFabric：{myListItem.Title}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
                OptiFabric_Selected(myListItem, null);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "可视化 OptiFabric 安装版本列表出错", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void OptiFabric_Selected(MyListItem sender, EventArgs e)
    {
        SelectedOptiFabric = (ResourceVersion)sender.Tag;
        CardOptiFabric.IsSwapped = true;
        ReloadSelected();
    }

    private void OptiFabric_Clear(object sender, MouseButtonEventArgs e)
    {
        SelectedOptiFabric = null;
        CardOptiFabric.IsSwapped = true;
        e.Handled = true;
        ReloadSelected();
    }

    private void TextSelectName_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return && IsInSelectPage && BtnStart.IsEnabled)
        {
            BtnStart_Click();
        }
    }

    private void BtnStart_Click()
    {
        if ((SelectedForge == null && SelectedNeoForge == null && SelectedFabric == null) || (Settings.Get<int>("LaunchArgumentIndieV2") != 0 && Settings.Get<int>("LaunchArgumentIndieV2") != 2) || ModMain.MyMsgBox("你尚未开启版本隔离，多个 MC 版本会共用同一个 Mod 文件夹。\r\n因此，游戏可能会因为读取到与当前版本不符的 Mod 而崩溃。\r\n推荐先在 设置 → 启动选项 → 默认版本隔离 中开启版本隔离！", "版本隔离提示", "取消下载", "继续") != 1)
        {
            string text = TextSelectName.Text;
            if (ModDownloadLib.McInstall(new ModDownloadLib.McInstallRequest
            {
                NewInstanceName = text,
                VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{text}\\",
                MinecraftJson = VanillaData["url"].ToString(),
                MinecraftName = VanillaName,
                OptiFineEntry = SelectedOptiFine,
                ForgeEntry = SelectedForge,
                NeoForgeEntry = SelectedNeoForge,
                FabricVersion = SelectedFabric,
                FabricApi = SelectedFabricApi,
                OptiFabric = SelectedOptiFabric,
                LiteLoaderEntry = SelectedLiteLoader
            }))
            {
                ExitSelectPage();
            }
        }
    }

    private string GetLoaderError(MyLoading Loader)
    {
        if (Loader == null)
        {
            return "获取中……";
        }
        if (!Loader.State.IsLoader)
        {
            return "获取中……";
        }
        switch (Loader.State.LoadingState)
        {
            case MyLoading.MyLoadingState.Run:
                return "获取中……";
            case MyLoading.MyLoadingState.Error:
                {
                    string message = ((ModLoader.LoaderBase)Loader.State).Error.Message;
                    return (Operators.CompareString(message, "无", TextCompare: false) == 0) ? "无" : ("获取失败：" + message);
                }
            case MyLoading.MyLoadingState.Unloaded:
                return "未知错误，状态为 Unloaded";
            default:
                return null;
        }
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnBack_WithEvents = BtnBack;
        BtnFabricApiClear_WithEvents = BtnFabricApiClear;
        BtnFabricApiClearInner_WithEvents = BtnFabricApiClearInner;
        BtnFabricClear_WithEvents = BtnFabricClear;
        BtnFabricClearInner_WithEvents = BtnFabricClearInner;
        BtnForgeClear_WithEvents = BtnForgeClear;
        BtnForgeClearInner_WithEvents = BtnForgeClearInner;
        BtnLiteLoaderClear_WithEvents = BtnLiteLoaderClear;
        BtnLiteLoaderClearInner_WithEvents = BtnLiteLoaderClearInner;
        BtnNeoForgeClear_WithEvents = BtnNeoForgeClear;
        BtnNeoForgeClearInner_WithEvents = BtnNeoForgeClearInner;
        BtnOptiFabricClear_WithEvents = BtnOptiFabricClear;
        BtnOptiFabricClearInner_WithEvents = BtnOptiFabricClearInner;
        BtnOptiFineClear_WithEvents = BtnOptiFineClear;
        BtnOptiFineClearInner_WithEvents = BtnOptiFineClearInner;
        BtnStart_WithEvents = BtnStart;
        CardFabric_WithEvents = CardFabric;
        CardFabricApi_WithEvents = CardFabricApi;
        CardForge_WithEvents = CardForge;
        CardLiteLoader_WithEvents = CardLiteLoader;
        CardNeoForge_WithEvents = CardNeoForge;
        CardOptiFabric_WithEvents = CardOptiFabric;
        CardOptiFine_WithEvents = CardOptiFine;
        HintFabricAPI_WithEvents = HintFabricAPI;
        HintModOptiFine_WithEvents = HintModOptiFine;
        HintOptiFabric_WithEvents = HintOptiFabric;
        HintOptiFabricOld_WithEvents = HintOptiFabricOld;
        ImgFabric_WithEvents = ImgFabric;
        ImgFabricApi_WithEvents = ImgFabricApi;
        ImgForge_WithEvents = ImgForge;
        ImgLiteLoader_WithEvents = ImgLiteLoader;
        ImgLogo_WithEvents = ImgLogo;
        ImgNeoForge_WithEvents = ImgNeoForge;
        ImgOptiFabric_WithEvents = ImgOptiFabric;
        ImgOptiFine_WithEvents = ImgOptiFine;
        LabFabric_WithEvents = LabFabric;
        LabFabricApi_WithEvents = LabFabricApi;
        LabForge_WithEvents = LabForge;
        LabLiteLoader_WithEvents = LabLiteLoader;
        LabNeoForge_WithEvents = LabNeoForge;
        LabOptiFabric_WithEvents = LabOptiFabric;
        LabOptiFine_WithEvents = LabOptiFine;
        LoadFabric_WithEvents = LoadFabric;
        LoadFabricApi_WithEvents = LoadFabricApi;
        LoadForge_WithEvents = LoadForge;
        LoadLiteLoader_WithEvents = LoadLiteLoader;
        LoadMinecraft_WithEvents = LoadMinecraft;
        LoadNeoForge_WithEvents = LoadNeoForge;
        LoadOptiFabric_WithEvents = LoadOptiFabric;
        LoadOptiFine_WithEvents = LoadOptiFine;
        PanAllBack_WithEvents = PanAllBack;
        PanBack_WithEvents = PanBack;
        PanFabric_WithEvents = PanFabric;
        PanFabricApi_WithEvents = PanFabricApi;
        PanFabricApiInfo_WithEvents = PanFabricApiInfo;
        PanFabricInfo_WithEvents = PanFabricInfo;
        PanForge_WithEvents = PanForge;
        PanForgeInfo_WithEvents = PanForgeInfo;
        PanInner_WithEvents = PanInner;
        PanLiteLoader_WithEvents = PanLiteLoader;
        PanLiteLoaderInfo_WithEvents = PanLiteLoaderInfo;
        PanLoad_WithEvents = PanLoad;
        PanMinecraft_WithEvents = PanMinecraft;
        PanNeoForge_WithEvents = PanNeoForge;
        PanNeoForgeInfo_WithEvents = PanNeoForgeInfo;
        PanOptiFabric_WithEvents = PanOptiFabric;
        PanOptiFabricInfo_WithEvents = PanOptiFabricInfo;
        PanOptiFine_WithEvents = PanOptiFine;
        PanOptiFineInfo_WithEvents = PanOptiFineInfo;
        PanSelect_WithEvents = PanSelect;
        TextSelectName_WithEvents = TextSelectName;
    }
}

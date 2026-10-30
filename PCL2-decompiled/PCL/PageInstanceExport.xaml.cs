using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceExport : MyPageRight, IRefreshable, IComponentConnector
{
    [Serializable]
    [CompilerGenerated]
    internal new sealed class _Closure_0024__
    {
        public static readonly _Closure_0024__ _0024I;

        public static Func<DirectoryInfo, DateTime> _0024I7_002D1;

        public static Func<FileInfo, string> _0024I8_002D3;

        public static Func<LocalResourceFile, string> _0024I25_002D6;

        public static Func<LocalResourceFile, uint> _0024I25_002D8;

        public static Func<string, bool> _0024I25_002D11;

        static _Closure_0024__()
        {
            _0024I = new _Closure_0024__();
        }

        internal DateTime _Lambda_0024__7_002D1(DirectoryInfo f)
        {
            return f.LastWriteTime;
        }

        internal string _Lambda_0024__8_002D3(FileInfo f)
        {
            return f.Name;
        }

        internal string _Lambda_0024__25_002D6(LocalResourceFile m)
        {
            return m.ModrinthHash;
        }

        internal uint _Lambda_0024__25_002D8(LocalResourceFile m)
        {
            return m.CurseForgeHash;
        }

        internal bool _Lambda_0024__25_002D11(string u)
        {
            return u.Contains("modrinth.com");
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__25_002D2
    {
        public string _0024VB_0024Local_RelativePath;

        public _Closure_0024__25_002D2(_Closure_0024__25_002D2 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_RelativePath = arg0._0024VB_0024Local_RelativePath;
            }
        }

        internal bool _Lambda_0024__3(string s)
        {
            return _0024VB_0024Local_RelativePath.Contains(s);
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__25_002D4
    {
        public JObject _0024VB_0024Local_File;

        public _Closure_0024__25_002D4(_Closure_0024__25_002D4 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_File = arg0._0024VB_0024Local_File;
            }
        }

        internal bool _Lambda_0024__9(LocalResourceFile m)
        {
            return m.CurseForgeHash == _0024VB_0024Local_File["fileFingerprint"].ToObject<uint>();
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__7_002D0
    {
        public FileInfo _0024VB_0024Local_File;

        public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_File = arg0._0024VB_0024Local_File;
            }
        }

        internal bool _Lambda_0024__0(string b)
        {
            return _0024VB_0024Local_File.Name.Contains(b);
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__7_002D1
    {
        public DirectoryInfo _0024VB_0024Local_SubFolder;

        public _Closure_0024__7_002D1(_Closure_0024__7_002D1 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
            }
        }

        internal bool _Lambda_0024__2(string b)
        {
            return _0024VB_0024Local_SubFolder.Name.Contains(b);
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__8_002D1
    {
        public DirectoryInfo _0024VB_0024Local_SubFolder;

        public _Closure_0024__8_002D1(_Closure_0024__8_002D1 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
            }
        }

        internal string _Lambda_0024__4(FileInfo f)
        {
            return $"{_0024VB_0024Local_SubFolder.Name}\\{f.Name}";
        }

        internal string _Lambda_0024__5(DirectoryInfo d)
        {
            return $"{_0024VB_0024Local_SubFolder.Name}\\{d.Name}\\";
        }
    }

    private string CurrentInstance;

    private string[] SubOptionBlackList;

    private const string Sperator = "==============================================================";

    private List<string> _RulesOverrides;

    private List<string> ExtraFiles;

    private string ConfigPackPath;

    [CompilerGenerated]
    [AccessedThroughProperty("PanAllBack")]
    private Grid _PanAllBack;

    [CompilerGenerated]
    [AccessedThroughProperty("PanBack")]
    private MyScrollViewer _PanBack;

    [CompilerGenerated]
    [AccessedThroughProperty("HintOptiFine")]
    private MyHint _HintOptiFine;

    [CompilerGenerated]
    [AccessedThroughProperty("HintJava")]
    private MyHint _HintJava;

    [CompilerGenerated]
    [AccessedThroughProperty("TextExportName")]
    private MyTextBox _TextExportName;

    [CompilerGenerated]
    [AccessedThroughProperty("TextExportVersion")]
    private MyTextBox _TextExportVersion;

    [CompilerGenerated]
    [AccessedThroughProperty("CardOptions")]
    private MyCard _CardOptions;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnOverrideCancel")]
    private MyIconTextButton _BtnOverrideCancel;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptions")]
    private StackPanel _PanOptions;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsBasic")]
    private MyCheckBox _CheckOptionsBasic;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsOptions")]
    private MyCheckBox _CheckOptionsOptions;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsMod")]
    private MyCheckBox _CheckOptionsMod;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsResourcePacks")]
    private MyCheckBox _CheckOptionsResourcePacks;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptionsResourcePacks")]
    private StackPanel _PanOptionsResourcePacks;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsShaderPacks")]
    private MyCheckBox _CheckOptionsShaderPacks;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsShaderPackSettings")]
    private MyCheckBox _CheckOptionsShaderPackSettings;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptionsShaderPacks")]
    private StackPanel _PanOptionsShaderPacks;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsSaves")]
    private MyCheckBox _CheckOptionsSaves;

    [CompilerGenerated]
    [AccessedThroughProperty("PanOptionsSaves")]
    private StackPanel _PanOptionsSaves;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsJava")]
    private MyCheckBox _CheckOptionsJava;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsPcl")]
    private MyCheckBox _CheckOptionsPcl;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckOptionsPclCustom")]
    private MyCheckBox _CheckOptionsPclCustom;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckAdvancedInclude")]
    private MyCheckBox _CheckAdvancedInclude;

    [CompilerGenerated]
    [AccessedThroughProperty("CheckAdvancedModrinth")]
    private MyCheckBox _CheckAdvancedModrinth;

    [CompilerGenerated]
    [AccessedThroughProperty("HintModrinthFormat")]
    private MyHint _HintModrinthFormat;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAdvancedImport")]
    private MyButton _BtnAdvancedImport;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAdvancedExport")]
    private MyButton _BtnAdvancedExport;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnAdvancedHelp")]
    private MyButton _BtnAdvancedHelp;

    [CompilerGenerated]
    [AccessedThroughProperty("BtnExport")]
    private MyExtraTextButton _BtnExport;

    private List<string> RulesOverrides
    {
        get
        {
            return _RulesOverrides;
        }
        set
        {
            _RulesOverrides = value;
            if (value == null)
            {
                BtnOverrideCancel.Visibility = Visibility.Collapsed;
                PanOptions.Visibility = Visibility.Visible;
                CardOptions.Inlines.Clear();
                CardOptions.Inlines.Add(new Run("导出内容列表")
                {
                    FontWeight = FontWeights.Bold
                });
            }
            else
            {
                BtnOverrideCancel.Visibility = Visibility.Visible;
                PanOptions.Visibility = Visibility.Collapsed;
                CardOptions.Inlines.Clear();
                CardOptions.Inlines.Add(new Run("导出内容列表:\u200a\u200a\u200a\u200a")
                {
                    FontWeight = FontWeights.Bold
                });
                CardOptions.Inlines.Add(new Run("从配置文件中读取")
                {
                    FontWeight = FontWeights.Normal
                });
            }
        }
    }

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

    internal virtual MyHint HintOptiFine_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintOptiFine;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintOptiFine = value;
        }
    }

    internal virtual MyHint HintJava_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintJava;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintJava = value;
        }
    }

    internal virtual MyTextBox TextExportName_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextExportName;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            RoutedEventHandler value2 = (object a0, RoutedEventArgs a1) =>
            {
                TextExportName_GotFocus();
            };
            MyTextBox myTextBox = _TextExportName;
            if (myTextBox != null)
            {
                myTextBox.GotFocus -= value2;
            }
            _TextExportName = value;
            myTextBox = _TextExportName;
            if (myTextBox != null)
            {
                myTextBox.GotFocus += value2;
            }
        }
    }

    internal virtual MyTextBox TextExportVersion_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _TextExportVersion;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _TextExportVersion = value;
        }
    }

    internal virtual MyCard CardOptions_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CardOptions;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MouseButtonEventHandler value2 = (object a0, MouseButtonEventArgs a1) =>
            {
                CardOptions_MouseLeftButtonDown();
            };
            MyCard myCard = _CardOptions;
            if (myCard != null)
            {
                myCard.MouseLeftButtonDown -= value2;
            }
            _CardOptions = value;
            myCard = _CardOptions;
            if (myCard != null)
            {
                myCard.MouseLeftButtonDown += value2;
            }
        }
    }

    internal virtual MyIconTextButton BtnOverrideCancel_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnOverrideCancel;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnOverrideCancel = value;
        }
    }

    internal virtual StackPanel PanOptions_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptions;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptions = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsBasic_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsBasic;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsBasic = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsOptions_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsOptions;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsOptions = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsMod_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsMod;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsMod = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsResourcePacks_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsResourcePacks;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsResourcePacks = value;
        }
    }

    internal virtual StackPanel PanOptionsResourcePacks_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptionsResourcePacks;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptionsResourcePacks = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsShaderPacks_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsShaderPacks;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsShaderPacks = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsShaderPackSettings_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsShaderPackSettings;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsShaderPackSettings = value;
        }
    }

    internal virtual StackPanel PanOptionsShaderPacks_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptionsShaderPacks;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptionsShaderPacks = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsSaves_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsSaves;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsSaves = value;
        }
    }

    internal virtual StackPanel PanOptionsSaves_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _PanOptionsSaves;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _PanOptionsSaves = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsJava_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsJava;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsJava = value;
        }
    }

    internal virtual MyCheckBox CheckOptionsPcl_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsPcl;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = CheckAdvancedModrinth_Change;
            MyCheckBox myCheckBox = _CheckOptionsPcl;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckOptionsPcl = value;
            myCheckBox = _CheckOptionsPcl;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckOptionsPclCustom_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckOptionsPclCustom;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _CheckOptionsPclCustom = value;
        }
    }

    internal virtual MyCheckBox CheckAdvancedInclude_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckAdvancedInclude;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = CheckAdvancedInclude_Change;
            MyCheckBox myCheckBox = _CheckAdvancedInclude;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckAdvancedInclude = value;
            myCheckBox = _CheckAdvancedInclude;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyCheckBox CheckAdvancedModrinth_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _CheckAdvancedModrinth;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyCheckBox.ChangeEventHandler obj = CheckAdvancedModrinth_Change;
            MyCheckBox myCheckBox = _CheckAdvancedModrinth;
            if (myCheckBox != null)
            {
                myCheckBox.Change -= obj;
            }
            _CheckAdvancedModrinth = value;
            myCheckBox = _CheckAdvancedModrinth;
            if (myCheckBox != null)
            {
                myCheckBox.Change += obj;
            }
        }
    }

    internal virtual MyHint HintModrinthFormat_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _HintModrinthFormat;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _HintModrinthFormat = value;
        }
    }

    internal virtual MyButton BtnAdvancedImport_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAdvancedImport;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                ImportConfig();
            };
            MyButton myButton = _BtnAdvancedImport;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnAdvancedImport = value;
            myButton = _BtnAdvancedImport;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnAdvancedExport_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAdvancedExport;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                ExportConfig();
            };
            MyButton myButton = _BtnAdvancedExport;
            if (myButton != null)
            {
                myButton.Click -= obj;
            }
            _BtnAdvancedExport = value;
            myButton = _BtnAdvancedExport;
            if (myButton != null)
            {
                myButton.Click += obj;
            }
        }
    }

    internal virtual MyButton BtnAdvancedHelp_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnAdvancedHelp;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            _BtnAdvancedHelp = value;
        }
    }

    internal virtual MyExtraTextButton BtnExport_WithEvents
    {
        [CompilerGenerated]
        get
        {
            return _BtnExport;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            MyExtraTextButton.ClickEventHandler obj = (object a0, MouseButtonEventArgs a1) =>
            {
                StartExport();
            };
            MyExtraTextButton myExtraTextButton = _BtnExport;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click -= obj;
            }
            _BtnExport = value;
            myExtraTextButton = _BtnExport;
            if (myExtraTextButton != null)
            {
                myExtraTextButton.Click += obj;
            }
        }
    }

    public PageInstanceExport()
    {
        Initialized += PageInstanceExport_Initialized;
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            PageInstanceExport_Loaded();
        };
        Loaded += (object a0, RoutedEventArgs a1) =>
        {
            RefreshJavaInfo();
        };
        CurrentInstance = "";
        SubOptionBlackList = new string[3] { "Quark Programmer Art.zip", "+ EuphoriaPatches_", "PCL2 Skin.zip" };
        _RulesOverrides = null;
        ExtraFiles = null;
        ConfigPackPath = null;
        InitializeComponent();
        _InitWithEvents();
    }

    private void PageInstanceExport_Initialized(object sender, EventArgs e)
    {
        ((RedoableWorkerBase<Java>)(object)PageInstanceLeft.CurrentJavaWorker).Stopped += () =>
        {
            ModBase.RunInUi(RefreshJavaInfo);
        };
    }

    private void PageInstanceExport_Loaded()
    {
        checked
        {
            ModAnimation.AniControlEnabled++;
            if (Operators.CompareString(CurrentInstance, PageInstanceLeft.Instance.PathVersion, TextCompare: false) != 0)
            {
                RefreshAll();
            }
            CustomEventService.SetEventData(BtnAdvancedHelp, "指南/整合包制作 - Public.json");
            ModAnimation.AniControlEnabled--;
        }
    }

    public void RefreshAll()
    {
        Logger.Info("刷新导出页面", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
        HintOptiFine.Visibility = ((!PageInstanceLeft.Instance.Version.HasOptiFine) ? Visibility.Collapsed : Visibility.Visible);
        CurrentInstance = PageInstanceLeft.Instance.PathVersion;
        TextExportName.Text = "";
        TextExportName.HintText = PageInstanceLeft.Instance.Name;
        TextExportVersion.Text = "";
        TextExportVersion.HintText = "1.0.0";
        CheckAdvancedInclude.Checked = false;
        CheckAdvancedModrinth.Checked = false;
        GetExportOption(CheckOptionsBasic).Description = PageInstanceLeft.Instance.VersionDisplayName();
        ResetConfigOverrides();
        ReloadAllSubOptions();
        RefreshAllOptionsUI();
        RefreshJavaInfo();
        PanBack.ScrollToHome();
    }

    void IRefreshable.Refresh()
    {
        this.RefreshAll();
    }

    private void ReloadAllSubOptions()
    {
        ReloadSubOptions(PanOptionsResourcePacks, true, true, "resourcepacks", "texturepacks");
        ReloadSubOptions(PanOptionsSaves, false, true, "saves");
        ReloadSubOptions(PanOptionsShaderPacks, true, true, "shaderpacks");
    }

    private void ReloadSubOptions(StackPanel Panel, bool AcceptCompressedFile, bool AcceptFolder, params string[] Folders)
    {
        Panel.Children.Clear();
        _Closure_0024__7_002D0 obj = default;
        _Closure_0024__7_002D1 obj2 = default;
        foreach (string text in Folders)
        {
            DirectoryInfo info = DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + text);
            if (!info.Exists)
            {
                continue;
            }
            if (AcceptCompressedFile)
            {
                using IEnumerator<FileInfo> enumerator = info.EnumerateFiles("*.zip").Concat(info.EnumerateFiles("*.rar")).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    obj = new _Closure_0024__7_002D0(obj);
                    obj._0024VB_0024Local_File = enumerator.Current;
                    if (!SubOptionBlackList.Any(obj._Lambda_0024__0))
                    {
                        Panel.Children.Add(new MyCheckBox
                        {
                            Tag = new ExportOption
                            {
                                Title = obj._0024VB_0024Local_File.Name,
                                DefaultChecked = true,
                                Rules = StringUtils.LikePatternEscape($"{text}/{obj._0024VB_0024Local_File.Name}")
                            }
                        });
                    }
                }
            }
            if (!AcceptFolder)
            {
                continue;
            }
            using IEnumerator<DirectoryInfo> enumerator2 = (from f in info.EnumerateDirectories()
                                                            orderby f.LastWriteTime descending
                                                            select f).GetEnumerator();
            while (enumerator2.MoveNext())
            {
                obj2 = new _Closure_0024__7_002D1(obj2);
                obj2._0024VB_0024Local_SubFolder = enumerator2.Current;
                if (!SubOptionBlackList.Any(obj2._Lambda_0024__2) && obj2._0024VB_0024Local_SubFolder.EnumerateFileSystemInfos().Any())
                {
                    MyCheckBox myCheckBox = new MyCheckBox
                    {
                        Tag = new ExportOption
                        {
                            Title = obj2._0024VB_0024Local_SubFolder.Name,
                            DefaultChecked = true,
                            Rules = StringUtils.LikePatternEscape($"{text}/{obj2._0024VB_0024Local_SubFolder.Name}/")
                        }
                    };
                    if (AcceptCompressedFile)
                    {
                        GetExportOption(myCheckBox).Description = "文件夹";
                    }
                    if (Panel == PanOptionsSaves)
                    {
                        GetExportOption(myCheckBox).Description = obj2._0024VB_0024Local_SubFolder.LastWriteTime.ToString("yyyy'/'MM'/'dd HH':'mm");
                    }
                    Panel.Children.Add(myCheckBox);
                }
            }
        }
    }

    private void RefreshAllOptionsUI()
    {
        List<string> list = new List<string>();
        VB_0024AnonymousDelegate_14<DirectoryInfo, bool> obj = (DirectoryInfo Folder) =>
        {
            bool result;
            try
            {
                result = Folder.Exists && Folder.EnumerateFileSystemInfos().Any((FileSystemInfo i) => !SubOptionBlackList.Any((string b) => i.Name.Contains(b)));
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                result = false;
                ProjectData.ClearProjectError();
            }
            return result;
        };
        DirectoryInfo info = DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie);
        list.AddRange(from f in info.EnumerateFiles()
                      select f.Name);
        IEnumerator<DirectoryInfo> enumerator = default;
        try
        {
            IEnumerable<DirectoryInfo> source = info.EnumerateDirectories();
            VB_0024AnonymousDelegate_14<DirectoryInfo, bool> obj2 = obj;
            enumerator = source.Where((obj2 == null) ? null : new Func<DirectoryInfo, bool>(obj2.Invoke)).GetEnumerator();
            _Closure_0024__8_002D1 obj3 = default;
            while (enumerator.MoveNext())
            {
                obj3 = new _Closure_0024__8_002D1(obj3);
                obj3._0024VB_0024Local_SubFolder = enumerator.Current;
                list.Add($"{obj3._0024VB_0024Local_SubFolder.Name}\\");
                list.AddRange(obj3._0024VB_0024Local_SubFolder.EnumerateFiles().Select(obj3._Lambda_0024__4));
                List<string> list2 = list;
                IEnumerable<DirectoryInfo> source2 = obj3._0024VB_0024Local_SubFolder.EnumerateDirectories();
                obj2 = obj;
                list2.AddRange(source2.Where((obj2 == null) ? null : new Func<DirectoryInfo, bool>(obj2.Invoke)).Select(obj3._Lambda_0024__5));
            }
        }
        finally
        {
            enumerator?.Dispose();
        }
        Logger.Info($"共发现 {list.Count} 个可行的二级文件/文件夹", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
        VB_0024AnonymousDelegate_15<ExportOption, bool> obj4 = (ExportOption TargetOption) =>
        {
            if (TargetOption.RequireOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine)
            {
                return false;
            }
            if (TargetOption.RequireModLoader && !PageInstanceLeft.Instance.Modable)
            {
                return false;
            }
            return (!TargetOption.RequireModLoaderOrOptiFine || PageInstanceLeft.Instance.Version.HasOptiFine || PageInstanceLeft.Instance.Modable) && StandardizeLines((TargetOption.Rules ?? TargetOption.ShowRules).Split('|'), AddSuffixStarToFolderPath: true).Any((string Rule) =>
            {
                bool result;
                if (StringExtensions.StartsWithF(Rule, "!", false))
                {
                    result = false;
                }
                else
                {
                    try
                    {
                        if (list.Any((string Entry) => LikeOperator.LikeString(StringExtensions.Lower(Entry), StringExtensions.Lower(Rule), CompareMethod.Binary)))
                        {
                            result = true;
                            goto IL_0105;
                        }
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        Exception ex2 = ex;
                        Logger.Error(ex2, $"错误的规则：{Rule}", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                        result = false;
                        ProjectData.ClearProjectError();
                        goto IL_0105;
                    }
                    Rule = Rule.Trim("*?".ToCharArray());
                    result = StringExtensions.Split(Rule, '\\', true).Count() >= 3 && ((!StringExtensions.EndsWithF(Rule, "\\", false)) ? FileUtils.Exists(PageInstanceLeft.Instance.PathIndie + Rule) : obj(DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + Rule)));
                }
                goto IL_0105;
            IL_0105:
                return result;
            });
        };
        foreach (MyCheckBox allOption in GetAllOptions(IncludeHidden: true))
        {
            ExportOption exportOption = GetExportOption(allOption);
            if (string.IsNullOrEmpty(exportOption.Rules) && string.IsNullOrEmpty(exportOption.ShowRules))
            {
                allOption.Visibility = Visibility.Visible;
                allOption.Checked = exportOption.DefaultChecked;
            }
            else
            {
                bool flag = obj4(exportOption);
                allOption.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
                allOption.Checked = exportOption.DefaultChecked && flag;
            }
            allOption.Inlines.Clear();
            if (allOption.Visibility == Visibility.Visible)
            {
                allOption.Inlines.Add(new Run(exportOption.Title));
                if (!string.IsNullOrEmpty(exportOption.Description))
                {
                    allOption.Inlines.Add(new Run("   " + exportOption.Description)
                    {
                        Foreground = ModSecret.ColorGray5
                    });
                }
            }
        }
    }

    private IEnumerable<string> StandardizeLines(IEnumerable<string> Raw, bool AddSuffixStarToFolderPath)
    {
        foreach (string item in Raw)
        {
            string current = item.Trim();
            if (Operators.CompareString(current, "", TextCompare: false) != 0 && !StringExtensions.StartsWithF(current, "#", false) && !StringExtensions.StartsWithF(current, "=", false))
            {
                current = current.Replace("/", "\\");
                yield return current + ((StringExtensions.EndsWithF(current, "\\", false) && AddSuffixStarToFolderPath) ? "*" : "");
            }
        }
    }

    private IEnumerable<MyCheckBox> GetAllOptions(bool IncludeHidden)
    {
        foreach (object child in PanOptions.Children)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(child);
            if (!IncludeHidden && Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "Visibility", new object[0], null, null, null), Visibility.Visible, TextCompare: false))
            {
                continue;
            }
            if (objectValue is MyCheckBox)
            {
                yield return (MyCheckBox)objectValue;
            }
            else
            {
                if (!(objectValue is StackPanel))
                {
                    continue;
                }
                foreach (object child2 in ((StackPanel)objectValue).Children)
                {
                    object objectValue2 = RuntimeHelpers.GetObjectValue(child2);
                    if ((IncludeHidden || !Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, null, "Visibility", new object[0], null, null, null), Visibility.Visible, TextCompare: false)) && objectValue2 is MyCheckBox)
                    {
                        yield return (MyCheckBox)objectValue2;
                    }
                }
            }
        }
    }

    private ExportOption GetExportOption(MyCheckBox CheckBox)
    {
        return (ExportOption)CheckBox.Tag;
    }

    private IEnumerable<string> GetAllRules()
    {
        if (RulesOverrides != null)
        {
            foreach (string rulesOverride in RulesOverrides)
            {
                yield return rulesOverride;
            }
            yield break;
        }
        yield return "";
        yield return "# 修改下方的规则以控制需要导出的内容。";
        yield return "# 以 ! 开头以反选。可以使用 *、?、[] 通配符。靠后的行覆盖靠前的。";
        yield return "";
        foreach (MyCheckBox allOption in GetAllOptions(IncludeHidden: false))
        {
            if (!allOption.Checked)
            {
                continue;
            }
            ExportOption exportOption = GetExportOption(allOption);
            List<string> list = exportOption.Rules?.Split('|').ToList() ?? new List<string>();
            if (allOption == CheckOptionsShaderPackSettings)
            {
                foreach (MyCheckBox item in PanOptionsShaderPacks.Children.OfType<MyCheckBox>())
                {
                    if (item.Checked)
                    {
                        string text = GetExportOption(item).Rules.TrimEnd('/') + ".txt";
                        if (FileUtils.Exists(Path.Combine(PageInstanceLeft.Instance.PathIndie, text)))
                        {
                            list.Add(StringUtils.LikePatternEscape($"shaderpacks/{text}"));
                        }
                    }
                }
            }
            if (!list.Any())
            {
                continue;
            }
            yield return $"# {exportOption.Title}";
            foreach (string item2 in list)
            {
                yield return item2;
            }
            yield return "";
        }
        yield return "# 排除的文件";
        yield return "!*.log";
        yield return "!*.dat_old";
        yield return "!*.BakaCoreInfo";
        yield return "!hmclversion.cfg";
        yield return "!log4j2.xml";
        yield return "";
    }

    private IEnumerable<string> GetExtraFileLines()
    {
        if (ExtraFiles != null)
        {
            foreach (string extraFile in ExtraFiles)
            {
                yield return extraFile;
            }
            yield break;
        }
        yield return "";
        yield return "# 如果想将额外的文件自动放到压缩包根目录中，可以将它们的路径写在下方。";
        yield return "# 必须是完整路径。每行中，若以 \\ 结尾则代表是文件夹，不以 \\ 结尾则代表是文件。";
        yield return "";
    }

    private void ResetConfigOverrides()
    {
        RulesOverrides = null;
        ConfigPackPath = null;
        ExtraFiles = null;
        PanBack.ScrollToHome();
    }

    private void CardOptions_MouseLeftButtonDown()
    {
        if (RulesOverrides != null)
        {
            ResetConfigOverrides();
        }
    }

    private void ExportConfig()
    {
        try
        {
            string text = Dialogs.SaveFile("选择文件位置", "export_config.txt", Settings.Get<string>("CacheExportConfig"), (IEnumerable<(string, string)>)new (string, string)[1] { ("txt", "整合包导出配置") });
            if (text != null)
            {
                Settings.Set("CacheExportConfig", text);
                List<string> list = new List<string>();
                list.Add("Name:" + TextExportName.Text);
                list.Add("Version:" + TextExportVersion.Text);
                list.Add("");
                list.Add($"# 当版本设置中选择了 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ} 时，是否打包版本文件夹中的 Java。");
                list.Add("IncludeJava:" + Conversions.ToString(CheckOptionsJava.Checked));
                list.Add("");
                list.Add("# 是否打包正式版 PCL，以便没有启动器的玩家安装整合包。");
                list.Add("IncludeLauncher:" + Conversions.ToString(CheckOptionsPcl.Checked));
                list.Add("");
                list.Add("# 是否打包 PCL 个性化内容，例如功能隐藏设置、主页、背景音乐和图片等。");
                list.Add("IncludeLauncherCustom:" + Conversions.ToString(CheckOptionsPclCustom.Checked));
                list.Add("");
                list.Add("# 是否将 Mod、资源包、光影包的文件直接放入整合包中，这样在导入时就无需联网下载它们。");
                list.Add("# 建议仅在无法稳定连接 CurseForge 或 Modrinth 时才考虑启用。");
                list.Add("# 二次分发可能违反使用协议，请尽量不要公开发布包含资源文件的整合包！");
                list.Add("DontCheckHostedAssets:" + Conversions.ToString(CheckAdvancedInclude.Checked));
                list.Add("");
                list.Add("# 若资源未在 Modrinth 上托管，则将其原始文件直接放入整合包中。");
                list.Add("# 如果你想将整合包上传到 Modrinth，这能帮助你分辨哪些文件未在 Modrinth 上托管。");
                list.Add("# 此选项与 DontCheckHostedAssets 冲突。");
                list.Add("ModrinthUploadMode:" + Conversions.ToString(CheckAdvancedModrinth.Checked));
                list.Add("");
                list.Add("# 导出的文件的存放位置。");
                list.Add("# 若设置了此项，在导出时会直接将文件放到此路径，不会弹窗要求选择。");
                list.Add("# 若 IncludeLauncher 为 True，应以 .zip 结尾；若为 False，应以 .mrpack 结尾。");
                list.Add("PackPath:" + ConfigPackPath);
                list.Add("");
                list.Add("==============================================================");
                list.AddRange(GetAllRules());
                list.Add("==============================================================");
                list.AddRange(GetExtraFileLines());
                FileUtils.Write(text, EnumerableExtensions.Join((IEnumerable)list, "\r\n"), (Encoding)null);
                ModMain.Hint("已保存配置文件：" + text, ModMain.HintType.Green);
                ModBase.OpenExplorer(text);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "保存配置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
            ProjectData.ClearProjectError();
        }
    }

    private void ImportConfig()
    {
        checked
        {
            try
            {
                string text = Dialogs.SelectFile("选择配置文件", false, Settings.Get<string>("CacheExportConfig"), (OneOf<IEnumerable<(string[], string)>, string>)(new (string[], string)[1] { (new string[1] { "txt" }, "整合包导出配置") })).FirstOrDefault();
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                Settings.Set("CacheExportConfig", text);
                string[] array = StringExtensions.Split(FileUtils.ReadAsString(text, (Encoding)null, (Type)null), "==============================================================", false);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string[] array2 = StringExtensions.SplitLines(array[0], true);
                for (int i = 0; i < array2.Length; i++)
                {
                    string text2 = array2[i];
                    text2 = text2.Trim();
                    if (Operators.CompareString(text2, "", TextCompare: false) != 0 && !StringExtensions.StartsWithF(text2, "#", false) && !StringExtensions.StartsWithF(text2, "=", false))
                    {
                        int num = StringExtensions.IndexOfF(text2, ":", false);
                        if (num > 0)
                        {
                            dictionary[text2.Substring(0, num)] = text2.Substring(num + 1);
                        }
                    }
                }
                TextExportName.Text = EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "Name", "");
                TextExportVersion.Text = EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "Version", "");
                CheckOptionsJava.Checked = Conversions.ToBoolean(EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "IncludeJava", Conversions.ToString(Value: true)));
                CheckOptionsPcl.Checked = Conversions.ToBoolean(EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "IncludeLauncher", Conversions.ToString(Value: true)));
                CheckOptionsPclCustom.Checked = Conversions.ToBoolean(EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "IncludeLauncherCustom", Conversions.ToString(Value: true)));
                CheckAdvancedInclude.Checked = Conversions.ToBoolean(EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "DontCheckHostedAssets", Conversions.ToString(Value: false)));
                if (!CheckAdvancedInclude.Checked)
                {
                    CheckAdvancedModrinth.Checked = Conversions.ToBoolean(EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "ModrinthUploadMode", Conversions.ToString(Value: false)));
                }
                ConfigPackPath = EnumerableExtensions.GetOrDefault<string, string>((IDictionary<string, string>)dictionary, "PackPath", (string)null);
                RulesOverrides = StringExtensions.SplitLines(array[1], true).ToList();
                if (array.Length > 2)
                {
                    ExtraFiles = StringExtensions.SplitLines(array[2], true).ToList();
                }
                else
                {
                    ExtraFiles = null;
                }
                ModMain.Hint("已读取配置文件：" + text, ModMain.HintType.Green);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Error(ex2, "读取配置失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                ProjectData.ClearProjectError();
            }
        }
    }

    private void StartExport()
    {
        string text = (string.IsNullOrEmpty(TextExportName.Text) ? TextExportName.HintText : TextExportName.Text);
        string text2 = (string.IsNullOrEmpty(TextExportVersion.Text) ? "1.0.0" : TextExportVersion.Text);
        string text3 = "导出整合包：" + text;
        foreach (ModLoader.LoaderBase item in ModLoader.LoaderTaskbar)
        {
            if (Operators.CompareString(item.Name, text3, TextCompare: false) == 0)
            {
                ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
                return;
            }
        }
        string text4 = null;
        if (!string.IsNullOrWhiteSpace(ConfigPackPath) && !StringExtensions.EndsWithF(ConfigPackPath, "\\", false) && !StringExtensions.EndsWithF(ConfigPackPath, "/", false))
        {
            try
            {
                DirectoryUtils.Create(PathUtils.RemoveLastPart(ConfigPackPath));
                text4 = ConfigPackPath;
                Logger.Info($"使用配置文件中指定的导出路径：{ConfigPackPath}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, $"无法使用配置文件中指定的导出路径（{ConfigPackPath}）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                if (ModMain.MyMsgBox(string.Format("指定的路径：{0}{1}{2}{3}", ConfigPackPath, "\r\n", "\r\n", ExceptionExtensions.GetDisplay(ex2, true)), "无法使用配置文件中指定的导出路径", "确定", "取消") == 2)
                {
                    ProjectData.ClearProjectError();
                    return;
                }
                ProjectData.ClearProjectError();
            }
        }
        if (text4 == null)
        {
            List<(string, string)> list = new List<(string, string)>();
            if (!CheckOptionsPcl.Checked && CheckAdvancedModrinth.Checked)
            {
                list.Add(("mrpack", "Modrinth 整合包文件"));
            }
            list.Add(("zip", "压缩文件"));
            if (!CheckOptionsPcl.Checked && !CheckAdvancedModrinth.Checked)
            {
                list.Add(("mrpack", "Modrinth 整合包文件"));
            }
            text4 = Dialogs.SaveFile("选择导出位置", text + (string.IsNullOrEmpty(TextExportVersion.Text) ? "" : (" " + TextExportVersion.Text)), (string)null, (IEnumerable<(string, string)>)list);
            Logger.Info($"手动指定的导出路径：{text4}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
        }
        if (text4 == null)
        {
            return;
        }
        string text5 = ModMain.RequestTaskTempFolder();
        string text6 = text5 + "modpack\\overrides\\";
        ModMinecraft.McInstance instance = PageInstanceLeft.Instance;
        bool flag = (RulesOverrides == null && CheckOptionsJava.Visibility == Visibility.Visible && CheckOptionsJava.Checked) || (RulesOverrides != null && CheckOptionsJava.Checked && Settings.Get<int>("VersionArgumentJavaV2", instance) == 2);
        string pathIndie = instance.PathIndie;
        bool flag2 = !CheckAdvancedInclude.Checked;
        bool flag3 = CheckAdvancedModrinth.Checked;
        bool flag4 = CheckOptionsPcl.Checked;
        bool flag5 = flag4 && CheckOptionsPclCustom.Checked;
        List<string> list2 = StandardizeLines(GetAllRules(), AddSuffixStarToFolderPath: true).ToList();
        List<string> list3 = StandardizeLines(GetExtraFileLines(), AddSuffixStarToFolderPath: false).ToList();
        Logger.Info($"准备导出整合包，共有 {list2.Count} 条规则，{list3.Count} 条追加内容行", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
        List<ModLoader.LoaderBase> list4 = new List<ModLoader.LoaderBase>();
        checked
        {
            list4.Add(new ModLoader.LoaderTask<int, List<LocalResourceFile>>("复制导出内容", (ModLoader.LoaderTask<int, List<LocalResourceFile>> Loader) =>
            {
                Loader.Output = new List<LocalResourceFile>();
                int num = 0;
                Action<DirectoryInfo> action = null;
                action = (DirectoryInfo Folder) =>
            {
                foreach (DirectoryInfo item2 in Folder.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    if ((!new string[3] { "assets", "versions", "libraries" }.Contains(item2.Name) || Operators.CompareString(pathIndie, PathUtils.RemoveExtendedPrefix(Folder.FullName), TextCompare: false) != 0) && !new string[5] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }.Contains(item2.Name))
                    {
                        action(item2);
                    }
                }
                _Closure_0024__25_002D2 obj = default;
                foreach (FileInfo item3 in Folder.EnumerateFiles("*", SearchOption.TopDirectoryOnly))
                {
                    obj = new _Closure_0024__25_002D2(obj);
                    obj._0024VB_0024Local_RelativePath = StringExtensions.AfterFirst(item3.FullName, pathIndie, false);
                    bool flag6 = false;
                    foreach (string item4 in list2)
                    {
                        bool flag7 = StringExtensions.StartsWithF(item4, "!", false);
                        if (LikeOperator.LikeString(StringExtensions.Lower(obj._0024VB_0024Local_RelativePath), StringExtensions.Lower(item4.TrimStart('!')), CompareMethod.Binary))
                        {
                            flag6 = !flag7;
                        }
                    }
                    if (flag6)
                    {
                        string text10 = text6 + obj._0024VB_0024Local_RelativePath;
                        FileUtils.Copy(item3.FullName, text10);
                        if (flag2 && new string[5] { ".zip", ".rar", ".jar", ".disabled", ".old" }.Contains(StringExtensions.Lower(item3.Extension)) && new string[4] { "mods", "packs", "openloader", "resource" }.Any(obj._Lambda_0024__3))
                        {
                            LocalResourceFile localResourceFile = new LocalResourceFile(text10);
                            _ = localResourceFile.ModrinthHash;
                            Conversions.ToString(localResourceFile.CurseForgeHash);
                            Loader.Output.Add(localResourceFile);
                        }
                        num++;
                        if (num == 25)
                        {
                            Loader.Progress += (0.84 - Loader.Progress) * 0.012;
                            num = 0;
                        }
                    }
                }
            };
                action(DirectoryUtils.GetInfo(pathIndie));
                Logger.Info($"复制 overrides 文件完成，有 {Loader.Output.Count} 个文件需要联网检查", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                Loader.Progress = 0.85;
                if (flag)
                {
                    string text7 = PathUtils.RemoveLastPart((ModJava.SelectOrDownloadJava((OneOf<ValueRange<Version>, ModMinecraft.McInstance>)(instance), TryFixOrHint: false, Loader.CreateCancellationToken(), Loader.CreateSyncProgressProvider(0.85, 0.93)) ?? throw new FileNotFoundException("版本文件夹中没有找到可导出的 Java。")).Folder);
                    string text8 = Path.Combine(text6, StringExtensions.AfterFirst(text7, instance.PathVersion, true));
                    DirectoryUtils.Copy(text7, text8);
                    Logger.Info($"已复制版本文件夹中的 Java：{text7} → {text8}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                }
                Loader.Progress = 0.95;
                string text9 = (flag4 ? text5 : (text5 + "modpack\\"));
                foreach (string item5 in list3)
                {
                    if (StringExtensions.EndsWithF(item5, "\\", false) || StringExtensions.EndsWithF(item5, "/", false))
                    {
                        if (DirectoryUtils.Exists(item5))
                        {
                            DirectoryUtils.Copy(item5, text9 + PathUtils.GetLastPart(item5) + "\\");
                        }
                        else
                        {
                            ModMain.Hint($"未找到配置文件中指定的文件夹：{item5}", ModMain.HintType.Red);
                        }
                    }
                    else if (FileUtils.Exists(item5))
                    {
                        FileUtils.Copy(item5, text9 + PathUtils.GetLastPart(item5));
                    }
                    else
                    {
                        ModMain.Hint($"未找到配置文件中指定的单个文件：{item5}", ModMain.HintType.Red);
                    }
                }
                Loader.Progress = 0.97;
                if (DirectoryUtils.Exists(instance.PathVersion + "PCL\\"))
                {
                    DirectoryUtils.Copy(instance.PathVersion + "PCL\\", text6 + "PCL\\");
                }
                ModBase.WriteIni(text6 + "PCL\\Setup.ini", "IsStar", Conversions.ToString(Value: false));
                if (flag4)
                {
                    FileUtils.Copy(ModBase.PathExe, text5 + "Plain Craft Launcher.exe");
                }
                if (flag5)
                {
                    if (DirectoryUtils.Exists(Paths.Base + "PCL\\Pictures\\"))
                    {
                        DirectoryUtils.Copy(Paths.Base + "PCL\\Pictures\\", text5 + "PCL\\Pictures\\");
                    }
                    if (DirectoryUtils.Exists(Paths.Base + "PCL\\Musics\\"))
                    {
                        DirectoryUtils.Copy(Paths.Base + "PCL\\Musics\\", text5 + "PCL\\Musics\\");
                    }
                    if (DirectoryUtils.Exists(Paths.Base + "PCL\\Help\\"))
                    {
                        DirectoryUtils.Copy(Paths.Base + "PCL\\Help\\", text5 + "PCL\\Help\\");
                    }
                    if (FileUtils.Exists(Paths.Base + "PCL\\Custom.xaml"))
                    {
                        FileUtils.Copy(Paths.Base + "PCL\\Custom.xaml", text5 + "PCL\\Custom.xaml");
                    }
                    if (FileUtils.Exists(Paths.Base + "PCL\\Setup.ini"))
                    {
                        FileUtils.Copy(Paths.Base + "PCL\\Setup.ini", text5 + "PCL\\Setup.ini");
                    }
                    if (FileUtils.Exists(Paths.Base + "PCL\\hints.txt"))
                    {
                        FileUtils.Copy(Paths.Base + "PCL\\hints.txt", text5 + "PCL\\hints.txt");
                    }
                    if (FileUtils.Exists(Paths.Base + "PCL\\Logo.png"))
                    {
                        FileUtils.Copy(Paths.Base + "PCL\\Logo.png", text5 + "PCL\\Logo.png");
                    }
                }
            })
            {
                ProgressWeight = 5.0
            });
            list4.Add(new ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>>("联网获取文件信息", (ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>> Loader) =>
            {
                Loader.Output = new Dictionary<LocalResourceFile, List<string>>();
                if (!flag2)
                {
                    Logger.Info("要求跳过联网获取步骤", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                }
                else if (!Loader.Input.Any())
                {
                    Logger.Info("没有需要联网检查的文件，跳过联网获取步骤", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                }
                else
                {
                    int num = 0;
                    List<Exception> list5 = new List<Exception>();
                    ModBase.RunInNewThread(() =>
                    {
                        try
                        {
                            IEnumerable<string> enumerable = Loader.Input.Select((LocalResourceFile m) => m.ModrinthHash);
                            JObject val = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", EnumerableExtensions.Join((IEnumerable)enumerable, "\",\"")), "application/json");
                            foreach (LocalResourceFile item6 in Loader.Input)
                            {
                                if (val.ContainsKey(item6.ModrinthHash))
                                {
                                    JToken val2 = val[item6.ModrinthHash];
                                    object obj;
                                    if (val2 == null)
                                    {
                                        obj = null;
                                    }
                                    else
                                    {
                                        JToken val3 = val2[(object)"files"];
                                        if (val3 == null)
                                        {
                                            obj = null;
                                        }
                                        else
                                        {
                                            JToken val4 = val3[(object)0][(object)"hashes"];
                                            obj = ((val4 != null) ? val4[(object)"sha1"] : null);
                                        }
                                    }
                                    if (!((string)(JToken)obj != item6.ModrinthHash))
                                    {
                                        EnumerableExtensions.AddIntoValueCollection<LocalResourceFile, string>((IDictionary<LocalResourceFile, List<string>>)Loader.Output, item6, (string)val[item6.ModrinthHash][(object)"files"][(object)0][(object)"url"]);
                                    }
                                }
                            }
                            Logger.Info($"从 Modrinth 获取到 {((JContainer)val).Count} 个本地资源项的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                        }
                        catch (Exception ex3)
                        {
                            ProjectData.SetProjectError(ex3);
                            Exception ex4 = ex3;
                            Logger.Warn(ex4, "从 Modrinth 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                            list5.Add(ex4);
                            ProjectData.ClearProjectError();
                        }
                        finally
                        {
                            num++;
                            Loader.Progress += 0.45;
                        }
                    }, "Modrinth - " + text3);
                    ModBase.RunInNewThread(() =>
                    {
                        try
                        {
                            if (!flag3)
                            {
                                IEnumerable<uint> enumerable = Loader.Input.Select((LocalResourceFile m) => m.CurseForgeHash);
                                JContainer val = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)enumerable, ",")), "application/json")[(object)"data"][(object)"exactMatches"];
                                _Closure_0024__25_002D4 obj = default;
                                foreach (JObject item7 in (IEnumerable<JToken>)val)
                                {
                                    JObject val2 = item7;
                                    obj = new _Closure_0024__25_002D4(obj);
                                    if (val2.ContainsKey("file"))
                                    {
                                        obj._0024VB_0024Local_File = (JObject)val2["file"];
                                        if (!string.IsNullOrEmpty((string)obj._0024VB_0024Local_File["downloadUrl"]))
                                        {
                                            LocalResourceFile localResourceFile = Loader.Input.FirstOrDefault(obj._Lambda_0024__9);
                                            if (localResourceFile != null)
                                            {
                                                foreach (string item8 in ResourceVersion.ParseCurseForgeDownloadUrls(obj._0024VB_0024Local_File["downloadUrl"].ToString()))
                                                {
                                                    EnumerableExtensions.AddIntoValueCollection<LocalResourceFile, string>((IDictionary<LocalResourceFile, List<string>>)Loader.Output, localResourceFile, item8);
                                                }
                                            }
                                        }
                                    }
                                }
                                Logger.Info($"从 CurseForge 获取到 {val.Count} 个本地资源项的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                            }
                        }
                        catch (Exception ex3)
                        {
                            ProjectData.SetProjectError(ex3);
                            Exception ex4 = ex3;
                            Logger.Warn(ex4, "从 CurseForge 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
                            list5.Add(ex4);
                            ProjectData.ClearProjectError();
                        }
                        finally
                        {
                            num++;
                            Loader.Progress += 0.45;
                        }
                    }, "CurseForge - " + text3);
                    while (true)
                    {
                        if (num == 2)
                        {
                            if (list5.Count == 1)
                            {
                                if (ModMain.MyMsgBox("联网获取部分文件信息失败，是否继续导出？\r\n\r\n若继续，无法获取信息的文件将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "部分文件信息获取失败", "继续", "取消") != 2)
                                {
                                    break;
                                }
                                throw list5.First();
                            }
                            if (list5.Count <= 1 || ModMain.MyMsgBox("联网获取文件信息失败，是否继续导出？\r\n\r\n若继续，所有文件都将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "文件信息获取失败", "继续", "取消") != 2)
                            {
                                break;
                            }
                            throw list5.First();
                        }
                        if (Loader.IsCanceled)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                    }
                }
            })
            {
                Show = flag2,
                ProgressWeight = (flag2 ? 2.0 : 0.01)
            });
            list4.Add(new ModLoader.LoaderTask<Dictionary<LocalResourceFile, List<string>>, int>("生成压缩包", (ModLoader.LoaderTask<Dictionary<LocalResourceFile, List<string>>, int> Loader) =>
            {
                JArray val = new JArray();
                foreach (KeyValuePair<LocalResourceFile, List<string>> item9 in Loader.Input)
                {
                    LocalResourceFile key = item9.Key;
                    JObject val2 = new JObject();
                    val2.Add("path", (JToken)(StringExtensions.AfterFirst(PathUtils.RemoveExtendedPrefix(key.File.FullName), text6, false).Replace("\\", "/")));
                    JObject val3 = new JObject();
                    val3.Add("sha1", (JToken)(key.ModrinthHash));
                    val3.Add("sha512", (JToken)(CryptographyUtils.ComputeFileHash(key.File.FullName, (MeloongCore.CryptographyUtils.HashMethod)3)));
                    val2.Add("hashes", (JToken)val3);
                    val2.Add("downloads", (JToken)new JArray((object)item9.Value.OrderBy((_Closure_0024__._0024I25_002D11 == null) ? (_Closure_0024__._0024I25_002D11 = (string u) => u.Contains("modrinth.com")) : _Closure_0024__._0024I25_002D11)));
                    val2.Add("fileSize", (JToken)(key.File.Length));
                    val.Add((JToken)val2);
                    key.File.Delete();
                }
                Loader.Progress = 0.2;
                JObject val4 = new JObject();
                val4.Add("minecraft", (JToken)(instance.Version.VanillaName));
                JObject val5 = val4;
                if (instance.Version.HasForge)
                {
                    val5.Add("forge", (JToken)(instance.Version.Forge));
                }
                if (instance.Version.HasFabric)
                {
                    val5.Add("fabric-loader", (JToken)(instance.Version.Fabric));
                }
                if (instance.Version.HasNeoForge)
                {
                    val5.Add("neoforge", (JToken)(instance.Version.NeoForge));
                }
                JObject val6 = new JObject();
                val6.Add("game", (JToken)("minecraft"));
                val6.Add("formatVersion", (JToken)(1));
                val6.Add("versionId", (JToken)(text2));
                val6.Add("name", (JToken)(text));
                val6.Add("summary", (JToken)(instance.Info));
                val6.Add("files", (JToken)(object)val);
                val6.Add("dependencies", (JToken)(object)val5);
                JObject val7 = val6;
                FileUtils.Write(text5 + "modpack\\modrinth.index.json", ((JToken)val7).ToString((Formatting)1, new JsonConverter[0]), (Encoding)null);
                if (flag4)
                {
                    FileUtils.CreateZipFromDirectory(text5 + "modpack.mrpack", text5 + "modpack\\");
                    Loader.Progress = 0.5;
                    DirectoryUtils.Delete(text5 + "modpack\\", false);
                    Loader.Progress = 0.6;
                    FileUtils.CreateZipFromDirectory(text4, text5);
                    Loader.Progress = 0.9;
                }
                else
                {
                    FileUtils.CreateZipFromDirectory(text4, text5 + "modpack\\");
                    Loader.Progress = 0.8;
                }
                ModBase.OpenExplorer(text4);
            })
            {
                ProgressWeight = 6.0
            });
            ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text3, list4);
            loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
            loaderCombo.Start();
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
            ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
        }
    }

    private void RefreshJavaInfo()
    {
        int num = Settings.Get<int>("VersionArgumentJavaV2", PageInstanceLeft.Instance);
        RedoableWorker<Java> currentJavaWorker = PageInstanceLeft.CurrentJavaWorker;
        Java val = ((num == 2 && ((RedoableWorkerBase<Java>)(object)currentJavaWorker).LastSucceeded && !((RedoableWorkerBase<Java>)(object)currentJavaWorker).Running) ? ((RedoableWorkerBase<Java>)(object)currentJavaWorker).LastResult : null);
        if (val == null)
        {
            CheckOptionsJava.Visibility = Visibility.Collapsed;
        }
        else
        {
            CheckOptionsJava.Visibility = Visibility.Visible;
            CheckOptionsJava.Inlines.Clear();
            CheckOptionsJava.Inlines.Add(new Run(GetExportOption(CheckOptionsJava).Title));
            CheckOptionsJava.Inlines.Add(new Run("   " + string.Format("Java {0} ({1})：{2}", val.Version.Major, val.Version, PathUtils.AddSlashSuffix(PathUtils.RemoveLastPart(val.Folder.Replace(PathUtils.RemoveLastPart(PathUtils.RemoveLastPart(PageInstanceLeft.Instance.PathVersion)), ""))).TrimStart('\\')))
            {
                Foreground = ModSecret.ColorGray5
            });
        }
        switch (num)
        {
            case 3:
                BtnExport.IsEnabled = true;
                HintJava.Visibility = Visibility.Visible;
                HintJava.Theme = MyHint.Themes.Yellow;
                HintJava.Text = $"该版本设置要求 {ModBase.vbLQ}使用指定的 Java{ModBase.vbRQ}，这在导出后很可能会失效。建议修改为 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ}。";
                return;
            case 2:
                if (((RedoableWorkerBase<Java>)(object)currentJavaWorker).HasSucceeded && ((RedoableWorkerBase<Java>)(object)currentJavaWorker).LastResult == null)
                {
                    BtnExport.IsEnabled = false;
                    HintJava.Visibility = Visibility.Visible;
                    HintJava.Theme = MyHint.Themes.Red;
                    HintJava.Text = $"该版本设置要求 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ}，但版本文件夹中没能找到任何 Java。";
                    return;
                }
                break;
        }
        BtnExport.IsEnabled = true;
        HintJava.Visibility = Visibility.Collapsed;
    }

    private void TextExportName_GotFocus()
    {
        if (Operators.CompareString(TextExportName.Text, "", TextCompare: false) == 0)
        {
            TextExportName.Text = TextExportName.HintText;
            TextExportName.SelectionStart = TextExportName.Text.Length;
        }
    }

    private void CheckAdvancedInclude_Change(object sender, bool user)
    {
        if (CheckAdvancedInclude.Checked)
        {
            CheckAdvancedModrinth.Checked = false;
        }
        CheckAdvancedModrinth.IsEnabled = !CheckAdvancedInclude.Checked;
    }

    private void CheckAdvancedModrinth_Change(object sender, bool user)
    {
        HintModrinthFormat.Visibility = ModBase.ToVisibility(CheckAdvancedModrinth.Checked && CheckOptionsPcl.Checked);
    }


    private bool _withEventsInitialized;
    private void _InitWithEvents()
    {
        if (_withEventsInitialized) { return; }
        _withEventsInitialized = true;
        BtnAdvancedExport_WithEvents = BtnAdvancedExport;
        BtnAdvancedHelp_WithEvents = BtnAdvancedHelp;
        BtnAdvancedImport_WithEvents = BtnAdvancedImport;
        BtnExport_WithEvents = BtnExport;
        BtnOverrideCancel_WithEvents = BtnOverrideCancel;
        CardOptions_WithEvents = CardOptions;
        CheckAdvancedInclude_WithEvents = CheckAdvancedInclude;
        CheckAdvancedModrinth_WithEvents = CheckAdvancedModrinth;
        CheckOptionsBasic_WithEvents = CheckOptionsBasic;
        CheckOptionsJava_WithEvents = CheckOptionsJava;
        CheckOptionsMod_WithEvents = CheckOptionsMod;
        CheckOptionsOptions_WithEvents = CheckOptionsOptions;
        CheckOptionsPcl_WithEvents = CheckOptionsPcl;
        CheckOptionsPclCustom_WithEvents = CheckOptionsPclCustom;
        CheckOptionsResourcePacks_WithEvents = CheckOptionsResourcePacks;
        CheckOptionsSaves_WithEvents = CheckOptionsSaves;
        CheckOptionsShaderPacks_WithEvents = CheckOptionsShaderPacks;
        CheckOptionsShaderPackSettings_WithEvents = CheckOptionsShaderPackSettings;
        HintJava_WithEvents = HintJava;
        HintModrinthFormat_WithEvents = HintModrinthFormat;
        HintOptiFine_WithEvents = HintOptiFine;
        PanAllBack_WithEvents = PanAllBack;
        PanBack_WithEvents = PanBack;
        PanOptions_WithEvents = PanOptions;
        PanOptionsResourcePacks_WithEvents = PanOptionsResourcePacks;
        PanOptionsSaves_WithEvents = PanOptionsSaves;
        PanOptionsShaderPacks_WithEvents = PanOptionsShaderPacks;
        TextExportName_WithEvents = TextExportName;
        TextExportVersion_WithEvents = TextExportVersion;
    }
}

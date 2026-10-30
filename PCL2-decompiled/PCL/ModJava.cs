using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[StandardModule]
public sealed class ModJava
{
    private class JavaDownloadInfo
    {
        public string ComponentName { get; set; }

        public JObject Java { get; set; }

        public Version JavaVersion { get; set; }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__16_002D0
    {
        public string _0024VB_0024Local_BaseDir;

        public _Closure_0024__16_002D0(_Closure_0024__16_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_BaseDir = arg0._0024VB_0024Local_BaseDir;
            }
        }

        internal void _Lambda_0024__R1(ModLoader.LoaderBase a0)
        {
            _Lambda_0024__0((ModLoader.LoaderCombo<int>)a0);
        }

        internal void _Lambda_0024__0(ModLoader.LoaderCombo<int> RawLoader)
        {
            if (RawLoader.State == ModBase.LoadState.Failed || RawLoader.State == ModBase.LoadState.Canceled)
            {
                Logger.Warn($"由于 Java 下载未完成，清理未下载完成的 Java 文件夹：{_0024VB_0024Local_BaseDir}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                DirectoryUtils.Delete(_0024VB_0024Local_BaseDir, false);
            }
        }
    }

    [CompilerGenerated]
    [AccessedThroughProperty("JavaListRefreshWorker")]
    private static RedoableWorker _JavaListRefreshWorker;

    private static readonly object JavaLock;

    private static RedoableWorker<List<JavaDownloadInfo>> _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker;

    private static StaticLocalInitFlag _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init;

    public static RedoableWorker JavaListRefreshWorker
    {
        [CompilerGenerated]
        get
        {
            return _JavaListRefreshWorker;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        [CompilerGenerated]
        set
        {
            Action action = UpdateJavaLists;
            Action action2 = UpdateJavaLists;
            RedoableWorker javaListRefreshWorker = _JavaListRefreshWorker;
            if (javaListRefreshWorker != null)
            {
                ((RedoableWorkerBase<NoType>)(object)javaListRefreshWorker).Started -= action;
                ((RedoableWorkerBase<NoType>)(object)javaListRefreshWorker).Stopped -= action2;
            }
            _JavaListRefreshWorker = value;
            javaListRefreshWorker = _JavaListRefreshWorker;
            if (javaListRefreshWorker != null)
            {
                ((RedoableWorkerBase<NoType>)(object)javaListRefreshWorker).Started += action;
                ((RedoableWorkerBase<NoType>)(object)javaListRefreshWorker).Stopped += action2;
            }
        }
    }

    static ModJava()
    {
        JavaListRefreshWorker = new RedoableWorker((Action<CancellationToken?, ProgressProvider>)((CancellationToken? c, ProgressProvider p) =>
        {
            MeloongCore.Extensions.TaskExtensions.Run(JavaUtils.RefreshListAsync(c.Value, p));
        }), "JavaListRefreshWorker");
        JavaLock = RuntimeHelpers.GetObjectValue(new object());
    }

    public static void JavaInit()
    {
        try
        {
            if (Configs.JavaConfigVersion.Get() == 0)
            {
                try
                {
                    Logger.Warn("正在从老版本迁移 Java 列表", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    List<Java> list = ((IEnumerable<JToken>)StringExtensions.DeserializeJson<JArray>(Settings.Get<string>("LaunchArgumentJavaAll"))).Select((Func<JToken, Java>)((JToken JavaObject) =>
                    {
                        return new Java(JavaObject[(object)"Path"].ToString(), (Version)null);
                    })).ToList();
                    list = MeloongCore.Extensions.TaskExtensions.Run<List<Java>>(JavaUtils.SortAsync(list, default(CancellationToken), (ProgressProvider)null));
                    Logger.Info($"已从老版本设置中发现 {list.Count} 个 Java", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    string text = Settings.Get<string>("LaunchArgumentJavaSelect");
                    string value = (StringExtensions.StartsWithF(text, "{", false) ? StringExtensions.DeserializeJson<JObject>(text)["Path"].ToString() : "");
                    Java val = list.FirstOrDefault((Java j) => j.Folder.Equals(value, StringComparison.OrdinalIgnoreCase));
                    if (val != null)
                    {
                        list.Remove(val);
                        list.Insert(0, val);
                        Logger.Info($"已将老版本设置中强制选择的 Java 置顶：{val}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    }
                    Configs.JavaList.Set(new ConcurrentList<Java>((IEnumerable<Java>)list));
                    Configs.JavaConfigVersion.Set(1);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Error(ex2, "从老版本 PCL 迁移 Java 列表失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    ProjectData.ClearProjectError();
                }
            }
            ConcurrentList<Java> val2 = Configs.JavaList.Get();
            if (((IEnumerable<Java>)val2).Any())
            {
                Logger.Info(string.Format("共有 {0} 个可用的 Java：{1}- {2}", val2.Count, "\r\n", EnumerableExtensions.Join((IEnumerable)((IEnumerable<Java>)val2).Select((Java j) => j.ToString()), "\r\n- ")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
            }
            else
            {
                Logger.Warn("初始化未找到可用的 Java，将自动触发搜索", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                ((RedoableWorkerBase<NoType>)(object)JavaListRefreshWorker).Start(default(CancellationToken), (ProgressProvider)null);
            }
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Error(ex4, "初始化 Java 列表失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
            Configs.JavaList.Reset();
            ProjectData.ClearProjectError();
        }
    }

    public static void UpdateJavaLists()
    {
        ModBase.RunInUi(() =>
        {
            ModMain.FrmSetupLaunch?.UpdateJavaList();
            ModMain.FrmInstanceSetup?.UpdateJavaList();
        });
    }

    public static void ManuallyImportJava()
    {
        string text = Dialogs.SelectFile("选择 java.exe（可能在 bin 文件夹中）", false, (string)null, (OneOf<IEnumerable<(string[], string)>, string>)("java.exe|java.exe")).FirstOrDefault();
        if (string.IsNullOrEmpty(text))
        {
            return;
        }
        Java val = new Java(PathUtils.RemoveLastPart(text), (Version)null);
        if (!MeloongCore.Extensions.TaskExtensions.Run<bool>(val.CheckAsync(default(CancellationToken))))
        {
            ModMain.Hint("该 Java 存在异常，无法使用", ModMain.HintType.Red);
            return;
        }
        Configs.JavaRemovedList.Edit((MeloongCore.ConfigEntry<List<string>>.RefAction)((ref List<string> List) =>
        {
            EnumerableExtensions.RemoveIf<string>((ICollection<string>)List, (Func<string, bool>)((string f) => f.Equals(val.Folder, StringComparison.OrdinalIgnoreCase)));
        }));
        Configs.JavaList.Edit((MeloongCore.ConfigEntry<ConcurrentList<Java>>.RefAction)((ref ConcurrentList<Java> List) =>
        {
            List.Remove(val);
            List.Insert(0, val);
        }));
        ModMain.Hint($"已将 Java 加入列表：{text}", ModMain.HintType.Green);
        UpdateJavaLists();
    }

    public static void ManuallyRemoveJava(Java JavaEntry)
    {
        Configs.JavaList.Edit((MeloongCore.ConfigEntry<ConcurrentList<Java>>.RefAction)((ref ConcurrentList<Java> List) =>
        {
            List.Remove(JavaEntry);
        }));
        Configs.JavaRemovedList.Edit((Func<List<string>, List<string>>)((List<string> List) => EnumerableExtensions.DistinctBy<string, string>(List.Append(JavaEntry.Folder), (Func<string, string>)((string s) => StringExtensions.Lower(s))).ToList()));
        ModMain.Hint($"已将 Java 移除出列表：{JavaEntry}", ModMain.HintType.Green);
        UpdateJavaLists();
        PageInstanceLeft.ReloadCurrentJava();
    }

    public static void ManuallySearchJava(CancellationToken CancellationToken = default(CancellationToken))
    {
        ModBase.RunInThread(() =>
        {
            EnumerableExtensions.ForAll<Java>((IEnumerable<Java>)Configs.JavaList.Get(), (Action<Java>)((Java java) =>
            {
                java.InvalidateChecked();
            }));
            ((RedoableWorkerBase<NoType>)(object)JavaListRefreshWorker).Start(CancellationToken, (ProgressProvider)null);
            MeloongCore.Extensions.TaskExtensions.Run<bool>(((RedoableWorkerBase<NoType>)(object)JavaListRefreshWorker).WaitIfRunningAsync(-1, CancellationToken));
            if (((IEnumerable<Java>)Configs.JavaList.Get()).Any())
            {
                ModMain.Hint("已找到 " + Conversions.ToString(Configs.JavaList.Get().Count) + " 个 Java！", ModMain.HintType.Green);
            }
            else
            {
                ModMain.Hint("未找到可用的 Java！", ModMain.HintType.Red);
            }
        });
    }

    public static (ValueRange<Version> Range, string RecommendedComponent) GetJavaRequirement(ModMinecraft.McInstance Instance)
    {
        if (Settings.Get<int>("VersionArgumentJavaV2", Instance) == 1)
        {
            try
            {
                ValueRange<Version> item = ValueRange<Version>.FromString(Settings.Get<string>("VersionArgumentJavaRange", Instance), (Func<string, Version>)((string s) => StringUtils.ParseVersionWithDefaults(s)));
                return (Range: item, RecommendedComponent: null);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(string.Format("版本设置中指定的 Java 版本范围有误（{0}），这可能是因为首次修改此设置，尚未初始化", Settings.Get<string>("VersionArgumentJavaRange", Instance)), (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                ProjectData.ClearProjectError();
            }
        }
        ValueRange<Version> val = ValueRange<Version>.All();
        VB_0024AnonymousDelegate_4<ValueRange<Version>> obj = (ValueRange<Version> Constraint) =>
        {
            val = val?.Intersect(Constraint);
            if (val.IsEmpty())
            {
                Logger.Warn($"Java 版本要求冲突，若启动失败请在版本设置手动指定 Java：当前追加的要求为 {Constraint}，游戏版本为 {Instance.VersionDisplayName()}", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                val = Constraint;
            }
        };
        if ((!Instance.Version.Vaild && DateTime.Compare(Instance.ReleaseTime, new DateTime(2024, 4, 2)) >= 0) || (Instance.Version.Vaild && Instance.Version.Vanilla >= new Version(20, 0, 5)))
        {
            obj(ValueRange<Version>.AtLeast(new Version(21, 0)));
        }
        else if ((!Instance.Version.Vaild && DateTime.Compare(Instance.ReleaseTime, new DateTime(2021, 11, 16)) >= 0) || (Instance.Version.Vaild && Instance.Version.Vanilla.Major >= 18))
        {
            obj(ValueRange<Version>.AtLeast(new Version(17, 0)));
        }
        else if ((!Instance.Version.Vaild && DateTime.Compare(Instance.ReleaseTime, new DateTime(2021, 5, 11)) >= 0) || (Instance.Version.Vaild && Instance.Version.Vanilla.Major >= 17))
        {
            obj(ValueRange<Version>.AtLeast(new Version(16, 0)));
        }
        else if (Instance.ReleaseTime.Year >= 2017)
        {
            obj(ValueRange<Version>.AtLeast(new Version(8, 0)));
        }
        else if (DateTime.Compare(Instance.ReleaseTime, new DateTime(2013, 5, 1)) <= 0 && Instance.ReleaseTime.Year >= 2001)
        {
            obj(ValueRange<Version>.LessThan(new Version(9, 0)));
        }
        string text = null;
        JObject jsonObject = Instance.JsonObject;
        int? num;
        if (jsonObject == null)
        {
            num = null;
        }
        else
        {
            JToken val2 = jsonObject["javaVersion"];
            if (val2 == null)
            {
                num = null;
            }
            else
            {
                JToken val3 = val2[(object)"majorVersion"];
                num = ((val3 != null) ? new int?(val3.ToObject<int>()) : ((int?)null));
            }
        }
        int? num2 = num;
        int? num3 = num;
        int valueOrDefault;
        if (!num3.HasValue)
        {
            JObject jsonVersion = Instance.JsonVersion;
            int? num4;
            if (jsonVersion == null)
            {
                num4 = null;
            }
            else
            {
                JToken val4 = jsonVersion["java_version"];
                num4 = ((val4 != null) ? new int?(val4.ToObject<int>()) : ((int?)null));
            }
            num3 = num4;
            valueOrDefault = num3.GetValueOrDefault();
        }
        else
        {
            valueOrDefault = num2.GetValueOrDefault();
        }
        int num5 = valueOrDefault;
        if (num5 >= 22)
        {
            Logger.Info("Mojang 要求至少使用 Java " + Conversions.ToString(num5), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
            obj(ValueRange<Version>.AtLeast(new Version(num5, 0)));
            JObject jsonObject2 = Instance.JsonObject;
            object obj2;
            if (jsonObject2 == null)
            {
                obj2 = null;
            }
            else
            {
                JToken val5 = jsonObject2["javaVersion"];
                if (val5 == null)
                {
                    obj2 = null;
                }
                else
                {
                    JToken val6 = val5[(object)"component"];
                    obj2 = ((val6 != null) ? val6.ToString() : null);
                }
            }
            if (obj2 == null)
            {
                JObject jsonVersion2 = Instance.JsonVersion;
                if (jsonVersion2 == null)
                {
                    obj2 = null;
                }
                else
                {
                    JToken val7 = jsonVersion2["java_component"];
                    obj2 = ((val7 != null) ? val7.ToString() : null);
                }
            }
            text = (string)obj2;
            if (Operators.CompareString(text, "", TextCompare: false) == 0)
            {
                text = null;
            }
        }
        if (Instance.Version.HasOptiFine && Instance.Version.Vaild)
        {
            if (Instance.Version.Vanilla.Major < 7)
            {
                obj(ValueRange<Version>.LessThan(new Version(9, 0)));
            }
            else if (Instance.Version.Vanilla.Major >= 8 && Instance.Version.Vanilla.Major < 12)
            {
                obj(ValueRange<Version>.ClosedOpen(new Version(8, 0), new Version(9, 0)));
            }
            else if (Instance.Version.Vanilla.Major == 12)
            {
                obj(ValueRange<Version>.LessThan(new Version(9, 0)));
            }
        }
        if (Instance.Version.HasForge)
        {
            if (Instance.Version.Vanilla >= new Version(6, 0, 1) && Instance.Version.Vanilla <= new Version(7, 0, 2))
            {
                obj(ValueRange<Version>.ClosedOpen(new Version(7, 0), new Version(8, 0)));
            }
            else if (Instance.Version.Vanilla.Major <= 12 || !Instance.Version.Vaild)
            {
                obj(ValueRange<Version>.LessThan(new Version(9, 0)));
            }
            else if (Instance.Version.Vanilla.Major <= 14)
            {
                obj(ValueRange<Version>.ClosedOpen(new Version(8, 0), new Version(11, 0)));
            }
            else if (Instance.Version.Vanilla.Major == 15)
            {
                obj(ValueRange<Version>.ClosedOpen(new Version(8, 0), new Version(16, 0)));
            }
            else if (ModMinecraft.CompareVersionGE(Instance.Version.Forge, "34.0.0") && ModMinecraft.CompareVersionGE("36.2.25", Instance.Version.Forge))
            {
                obj(ValueRange<Version>.AtMost(new Version(8, 0, 320)));
            }
            else if (ModMinecraft.CompareVersionGE(Instance.Version.Forge, "36.2.26") && ModMinecraft.CompareVersionGE("36.999999.999999", Instance.Version.Forge))
            {
                obj(ValueRange<Version>.LessThan(new Version(24, 0)));
            }
            else if (ModMinecraft.CompareVersionGE(Instance.Version.Forge, "37.0.0") && ModMinecraft.CompareVersionGE("37.0.79", Instance.Version.Forge))
            {
                obj(ValueRange<Version>.LessThan(new Version(17, 0)));
            }
            else if (Instance.Version.Vanilla.Major == 18 && Instance.Version.HasOptiFine)
            {
                obj(ValueRange<Version>.LessThan(new Version(19, 0)));
            }
            else if (ModMinecraft.CompareVersionGE(Instance.Version.Forge, "45.0.21") && ModMinecraft.CompareVersionGE("45.0.65", Instance.Version.Forge))
            {
                obj(ValueRange<Version>.LessThan(new Version(20, 0)));
            }
            else if (ModMinecraft.CompareVersionGE(Instance.Version.Forge, "45.0.66") && ModMinecraft.CompareVersionGE("47.4.8", Instance.Version.Forge))
            {
                obj(ValueRange<Version>.LessThan(new Version(22, 0)));
            }
        }
        if (Instance.Version.HasNeoForge && (Instance.Version.Vanilla == new Version(20, 0, 1) || (ModMinecraft.CompareVersionGE("20.2.62-beta", Instance.Version.NeoForge) && !Instance.Version.NeoForge.Contains("25w14craftmine"))))
        {
            obj(ValueRange<Version>.LessThan(new Version(22, 0)));
        }
        if (Instance.Version.HasFabric && Instance.Version.Vaild)
        {
            if (Instance.Version.Vanilla.Major >= 15 && Instance.Version.Vanilla.Major <= 16)
            {
                obj(ValueRange<Version>.AtLeast(new Version(8, 0)));
            }
            else if (Instance.Version.Vanilla.Major >= 18)
            {
                obj(ValueRange<Version>.AtLeast(new Version(17, 0)));
            }
        }
        if (Instance.Version.HasLiteLoader && Instance.Version.Vaild)
        {
            obj(ValueRange<Version>.LessThan(new Version(9, 0)));
        }
        if (Settings.Get<ModLaunch.McLoginType>("LoginType") == ModLaunch.McLoginType.Nide)
        {
            obj(ValueRange<Version>.AtLeast(new Version(8, 0, 141)));
        }
        return (Range: val, RecommendedComponent: text);
    }

    public static Java SelectOrDownloadJava(OneOf<ValueRange<Version>, ModMinecraft.McInstance> Target, bool TryFixOrHint, CancellationToken c = default(CancellationToken), ProgressProvider p = null)
    {
        checked
        {
            Java result;
            try
            {
                if (Target.Is<ModMinecraft.McInstance>())
                {
                    MigrateInstanceJavaSettings(Target.As<ModMinecraft.McInstance>(), c, (p != null) ? p.SplitTo(0.2) : null);
                }
                ModMinecraft.McInstance mcInstance = (Target.Is<ModMinecraft.McInstance>() ? Target.As<ModMinecraft.McInstance>() : null);
                switch (((object)mcInstance != null) ? Settings.Get<int>("VersionArgumentJavaV2", mcInstance) : 0)
                {
                    case 2:
                        {
                            Logger.Info($"版本设置要求使用版本文件夹中的 Java：{mcInstance.PathVersion}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                            Java val3 = MeloongCore.Extensions.TaskExtensions.Run<List<Java>>(JavaUtils.SearchFoldersAsync(true, (IEnumerable<string>)new string[1] { mcInstance.PathVersion }, c, (p != null) ? p.SplitTo(1.0) : null)).FirstOrDefault();
                            if (val3 != null)
                            {
                                Logger.Info($"已发现版本文件夹中的 Java：{val3}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                result = val3;
                                break;
                            }
                            if (TryFixOrHint)
                            {
                                SwitchToInstanceSetup(mcInstance);
                                ModMain.MyMsgBox(string.Format("该版本的版本设置选择了 {0}使用版本文件夹中的 Java{1}，但版本文件夹里没能找到 Java。{2}请先修改启动选项中的 Java 设置，或在版本文件夹中放一个 Java，然后再试。", ModBase.vbLQ, ModBase.vbRQ, "\r\n"), "未找到 Java", "确定", "", "", IsWarn: true, HighLight: true, ForceWait: true);
                            }
                            result = null;
                            break;
                        }
                    case 3:
                        {
                            Java val4 = Configs.JavaForced.Get((IConfigProvider)(object)mcInstance.Config);
                            Logger.Info($"版本设置中强制指定的 Java：{mcInstance.PathVersion} → {val4}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                            if (val4 == null)
                            {
                                if (TryFixOrHint)
                                {
                                    SwitchToInstanceSetup(mcInstance);
                                    ModMain.MyMsgBox(string.Format("该版本的版本设置选择了 {0}使用指定的 Java{1}，但还没有指定任何 Java。{2}请先选择你想使用的 Java，然后再试。", ModBase.vbLQ, ModBase.vbRQ, "\r\n"), "未选择 Java", "确定", "", "", IsWarn: true, HighLight: true, ForceWait: true);
                                }
                                if (p != null)
                                {
                                    p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
                                }
                                result = null;
                            }
                            else if (!Configs.JavaList.Get().Contains(val4))
                            {
                                Configs.JavaForced.Reset((IConfigProvider)(object)mcInstance.Config);
                                UpdateJavaLists();
                                if (TryFixOrHint)
                                {
                                    SwitchToInstanceSetup(mcInstance);
                                    Logger.Error("版本设置中指定的 Java 不在 Java 列表中，请重新选择一个 Java！", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                }
                                if (p != null)
                                {
                                    p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
                                }
                                result = null;
                            }
                            else if (!MeloongCore.Extensions.TaskExtensions.Run<bool>(val4.CheckAsync(c)))
                            {
                                Configs.JavaForced.Reset((IConfigProvider)(object)mcInstance.Config);
                                UpdateJavaLists();
                                if (TryFixOrHint)
                                {
                                    SwitchToInstanceSetup(mcInstance);
                                    Logger.Error("版本设置中指定的 Java 已无法使用，请重新选择一个 Java，然后再试。", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                }
                                else
                                {
                                    Logger.Error("版本设置中指定的 Java 已无法使用，请重新选择一个 Java！", (LogBehavior)2, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                }
                                if (p != null)
                                {
                                    p.Finish((MeloongCore.ProgressProvider.ChildrenAction)1);
                                }
                                result = null;
                            }
                            else
                            {
                                if (p != null)
                                {
                                    p.Finish((MeloongCore.ProgressProvider.ChildrenAction)1);
                                }
                                result = val4;
                            }
                            break;
                        }
                    default:
                        {
                            ValueRange<Version> val = (Target.Is<ModMinecraft.McInstance>() ? GetJavaRequirement(mcInstance).Range : Target.As<ValueRange<Version>>());
                            string text = (Target.Is<ModMinecraft.McInstance>() ? GetJavaRequirement(mcInstance).RecommendedComponent : null);
                            Logger.Info($"自动选择以下范围的 Java：{val} {text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                            if (val.IsEmpty())
                            {
                                throw new Exception("Java 版本需求存在冲突，导致没有任何可能适配的 Java，请查看 PCL 的日志了解详细信息！");
                            }
                            VB_0024AnonymousDelegate_5<Java> obj = () =>
                            {
                                ((RedoableWorkerBase<NoType>)(object)JavaListRefreshWorker).WaitIfRunning(-1, default(CancellationToken));
                                foreach (Java item in Configs.JavaList.Get())
                                {
                                    if (!MeloongCore.Extensions.TaskExtensions.Run<bool>(item.CheckAsync(c)))
                                    {
                                        Logger.Warn($"Java 检查失败，将尝试列表中的下一个 Java：{item}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                    }
                                    else if ((object)item.Version != null && val.Contains(item.Version))
                                    {
                                        Logger.Info($"已选定 Java：{item}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                        return item;
                                    }
                                }
                                return (Java)null;
                            };
                            if (p != null)
                            {
                                p.Set(0.25, false, (MeloongCore.ProgressProvider.ChildrenAction)1);
                            }
                            Java val2 = obj();
                            if (val2 != null)
                            {
                                if (p != null)
                                {
                                    p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
                                }
                                result = val2;
                                break;
                            }
                            object javaLock = JavaLock;
                            ObjectFlowControl.CheckForSyncLockOnValueType(javaLock);
                            bool lockTaken = false;
                            try
                            {
                                Monitor.Enter(javaLock, ref lockTaken);
                                Logger.Warn("既有列表中没有合适的 Java，重新触发搜索", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                ((RedoableWorkerBase<NoType>)(object)JavaListRefreshWorker).Start(c, (p != null) ? p.SplitTo(0.3) : null);
                                val2 = obj();
                                if (val2 != null)
                                {
                                    if (p != null)
                                    {
                                        p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
                                    }
                                    result = val2;
                                    break;
                                }
                                if (!TryFixOrHint)
                                {
                                    result = null;
                                    break;
                                }
                                Logger.Warn("电脑中没有合适的 Java，开始获取 Mojang 提供的 Java 下载列表", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                if (_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init == null)
                                {
                                    Interlocked.CompareExchange(ref _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init, new StaticLocalInitFlag(), null);
                                }
                                bool lockTaken2 = false;
                                try
                                {
                                    Monitor.Enter(_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init, ref lockTaken2);
                                    if (_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init.State == 0)
                                    {
                                        _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init.State = 2;
                                        _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker = new RedoableWorker<List<JavaDownloadInfo>>((Func<CancellationToken?, List<JavaDownloadInfo>>)((CancellationToken? cancellationToken) =>
                                        {
                                            string text2 = ModNet.NetRequestByLoader(ModDownload.DlVersionListOrder(new string[1] { "https://piston-meta.mojang.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json" }, new string[1] { "https://bmclapi2.bangbang93.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json" }), 45000, IsJson: true);
                                            cancellationToken?.ThrowIfCancellationRequested();
                                            List<JavaDownloadInfo> list = new List<JavaDownloadInfo>();
                                            foreach (JProperty item2 in (IEnumerable<JToken>)StringExtensions.DeserializeJson<JObject>(text2)["windows-x64"])
                                            {
                                                JProperty val5 = item2;
                                                cancellationToken?.ThrowIfCancellationRequested();
                                                if (Operators.CompareString(val5.Name, "minecraft-java-exe", TextCompare: false) != 0)
                                                {
                                                    try
                                                    {
                                                        JToken val6 = ((IEnumerable<JToken>)val5.Value).FirstOrDefault();
                                                        if (val6 != null)
                                                        {
                                                            string text3 = val6[(object)"version"][(object)"name"].ToString();
                                                            if (text3.Contains("."))
                                                            {
                                                                string[] array = StringExtensions.Split(text3, ".", false);
                                                                list.Add(new JavaDownloadInfo
                                                                {
                                                                    ComponentName = val5.Name,
                                                                    Java = (JObject)val6,
                                                                    JavaVersion = new Version((int)Math.Round(ModBase.Val(array[0])), (int)Math.Round(ModBase.Val(array[1])), (int)Math.Round((array.Length >= 3) ? ModBase.Val(array[2]) : 0.0), (int)Math.Round((array.Length >= 4) ? ModBase.Val(array[3]) : 0.0))
                                                                });
                                                            }
                                                            else if (StringExtensions.StartsWithF(text3, "8u51-", false))
                                                            {
                                                                list.Add(new JavaDownloadInfo
                                                                {
                                                                    ComponentName = val5.Name,
                                                                    Java = (JObject)val6,
                                                                    JavaVersion = new Version(8, 0, 51, 0)
                                                                });
                                                            }
                                                            else
                                                            {
                                                                list.Add(new JavaDownloadInfo
                                                                {
                                                                    ComponentName = val5.Name,
                                                                    Java = (JObject)val6,
                                                                    JavaVersion = new Version((int)Math.Round(ModBase.Val(StringExtensions.BeforeFirstOfAny(text3, (IEnumerable<string>)new string[2] { "u", "." }, false))), 0, 0, 0)
                                                                });
                                                            }
                                                        }
                                                    }
                                                    catch (Exception ex3)
                                                    {
                                                        ProjectData.SetProjectError(ex3);
                                                        Exception ex4 = ex3;
                                                        Logger.Warn(ex4, $"解析 Mojang 提供的 Java 列表项失败，已跳过（{val5.Name}）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                                        ProjectData.ClearProjectError();
                                                    }
                                                }
                                            }
                                            return list;
                                        }), "SelectOrDownloadJava");
                                    }
                                    else if (_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init.State == 2)
                                    {
                                        throw new IncompleteInitialization();
                                    }
                                }
                                finally
                                {
                                    _0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init.State = 1;
                                    if (lockTaken2)
                                    {
                                        Monitor.Exit(_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker_0024Init);
                                    }
                                }
                                if (!((RedoableWorkerBase<List<JavaDownloadInfo>>)(object)_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker).HasSucceeded)
                                {
                                    ((RedoableWorkerBase<List<JavaDownloadInfo>>)(object)_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker).Start(c, (p != null) ? p.SplitTo(0.4) : null);
                                }
                                ((RedoableWorkerBase<List<JavaDownloadInfo>>)(object)_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker).WaitIfRunning(-1, c);
                                if (p != null)
                                {
                                    p.Set(0.4, true, (MeloongCore.ProgressProvider.ChildrenAction)1);
                                }
                                List<JavaDownloadInfo> lastResult = ((RedoableWorkerBase<List<JavaDownloadInfo>>)(object)_0024STATIC_0024SelectOrDownloadJava_0024041282351511824521512823D11282411287982118239128249_0024DownloadListWorker).LastResult;
                                JavaDownloadInfo javaDownloadInfo = lastResult.FirstOrDefault((JavaDownloadInfo Comp) => Operators.CompareString(Comp.Java["version"][(object)"name"].ToString(), text, TextCompare: false) == 0) ?? lastResult.FirstOrDefault((JavaDownloadInfo Comp) => val.Contains(Comp.JavaVersion));
                                if (javaDownloadInfo == null)
                                {
                                    Logger.Warn("Mojang 提供的 Java 列表中没有合适的 Java，无法自动下载", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                                    bool flag = val.HasLower && val.IsLowerInclusive && val.Lower.Minor <= 0 && val.Lower.Build <= 0 && val.Lower.Revision <= 0;
                                    bool flag2 = val.HasUpper && !val.IsUpperInclusive && val.Upper.Minor <= 0 && val.Upper.Build <= 0 && val.Upper.Revision <= 0;
                                    string arg;
                                    if (val.HasLower && val.HasUpper)
                                    {
                                        if (!flag || !flag2)
                                        {
                                            arg = $" Java {val}";
                                        }
                                        else
                                        {
                                            arg = ((val.Lower.Major != val.Upper.Major - 1) ? $" Java {val.Lower.Major} ~ {val.Upper.Major - 1}" : $" Java {val.Lower.Major}");
                                        }
                                    }
                                    else if (val.HasLower)
                                    {
                                        if (flag)
                                        {
                                            arg = $" Java {val.Lower.Major} 或更高版本的 Java";
                                        }
                                        else
                                        {
                                            arg = ((!val.IsLowerInclusive) ? $"版本高于 {val.Lower} 的 Java" : $" Java {val.Lower} 或更高版本的 Java");
                                        }
                                    }
                                    else if (flag2)
                                    {
                                        arg = $" Java {val.Upper.Major - 1} 或更低版本的 Java";
                                    }
                                    else
                                    {
                                        arg = ((!val.IsUpperInclusive) ? $"版本低于 {val.Upper} 的 Java" : $" Java {val.Upper} 或更低版本的 Java");
                                    }
                                    ModMain.MyMsgBox(string.Format("PCL 没能找到合适的 Java。{0}请在网上搜索并手动安装{1}， 然后在【设置 → 启动 → 高级选项 → Java 列表】中导入它。", "\r\n", arg), "需要手动安装 Java");
                                    result = null;
                                    break;
                                }
                                ModLoader.LoaderCombo<int> loaderCombo = CreateJavaDownloadLoader(javaDownloadInfo);
                                try
                                {
                                    loaderCombo.WaitForExit(null, null, IsForceRestart: true, c, (p != null) ? p.SplitTo(0.95) : null);
                                }
                                finally
                                {
                                    loaderCombo.Cancel();
                                }
                                val2 = obj();
                                if (val2 != null)
                                {
                                    if (p != null)
                                    {
                                        p.Finish((MeloongCore.ProgressProvider.ChildrenAction)1);
                                    }
                                    result = val2;
                                    break;
                                }
                                throw new Exception($"下载 Java {javaDownloadInfo.ComponentName} 后仍然无法找到合适的 Java");
                            }
                            finally
                            {
                                if (lockTaken)
                                {
                                    Monitor.Exit(javaLock);
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ExceptionExtensions.ThrowIfCanceled(ex2);
                Logger.Error(ex2, "选择 Java 时出现异常", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                if (p != null)
                {
                    p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
                }
                result = null;
                ProjectData.ClearProjectError();
            }
            return result;
        }
    }

    private static void SwitchToInstanceSetup(ModMinecraft.McInstance Instance)
    {
        ModBase.RunInUi(() =>
        {
            PageInstanceLeft.Instance = Instance;
            ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup, FormMain.PageSubType.SetupLink);
        });
    }

    private static void MigrateInstanceJavaSettings(ModMinecraft.McInstance Instance, CancellationToken c = default(CancellationToken), ProgressProvider p = null)
    {
        if (Configs.JavaMigrated.Get((IConfigProvider)(object)Instance.Config))
        {
            if (p != null)
            {
                p.Skip((MeloongCore.ProgressProvider.ChildrenAction)2);
            }
            return;
        }
        if (ModMain.FrmInstanceSetup != null)
        {
            ModBase.RunInUiWait(() =>
            {
                ModMain.FrmInstanceSetup.ComboArgumentJava.IsEnabled = false;
            });
        }
        try
        {
            Logger.Info($"正在尝试迁移版本独立的 Java 设置（{Instance.Name}）", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
            string text = Settings.Get<string>("VersionArgumentJavaSelect", Instance);
            if (!StringExtensions.StartsWithF(text, "{", false))
            {
                if (p != null)
                {
                    p.Set(0.4, true, (MeloongCore.ProgressProvider.ChildrenAction)1);
                }
            }
            else
            {
                Java val = new Java(StringExtensions.DeserializeJson<JObject>(text)["Path"].ToString(), (Version)null);
                if (MeloongCore.Extensions.TaskExtensions.Run<bool>(val.CheckAsync(c)))
                {
                    Logger.Info($"将版本独立设置改为老版本中强制指定的 Java：{val}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    if (!Configs.JavaList.Get().Contains(val))
                    {
                        Configs.JavaList.Edit((MeloongCore.ConfigEntry<ConcurrentList<Java>>.RefAction)((ref ConcurrentList<Java> List) =>
                        {
                            List.Add(val);
                        }));
                        Logger.Info($"已将强制指定的 Java 加入 Java 列表底部：{val}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                    }
                    Configs.JavaForced.Set(val, (IConfigProvider)(object)Instance.Config);
                    Settings.Set("VersionArgumentJavaV2", 3, Instance);
                    UpdateJavaLists();
                    Configs.JavaMigrated.Set(true, (IConfigProvider)(object)Instance.Config);
                    if (p != null)
                    {
                        p.Finish((MeloongCore.ProgressProvider.ChildrenAction)1);
                    }
                    return;
                }
                ModMain.Hint("该版本的设置中强制指定的 Java 存在异常，该设置已重置", ModMain.HintType.Red);
                if (p != null)
                {
                    p.Set(0.4, false, (MeloongCore.ProgressProvider.ChildrenAction)1);
                }
            }
            List<Java> list = MeloongCore.Extensions.TaskExtensions.Run<List<Java>>(JavaUtils.SearchFoldersAsync(true, (IEnumerable<string>)new string[1] { Instance.PathVersion }, c, (p != null) ? p.SplitTo(1.0) : null));
            if (list.Any())
            {
                Logger.Info($"在版本文件夹中发现了 Java，将版本独立设置改为优先使用版本文件夹的 Java：{list}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                Settings.Set("VersionArgumentJavaV2", 2, Instance);
            }
            else
            {
                Logger.Info("没有需要迁移的内容，自动选择 Java", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
                Settings.Set("VersionArgumentJavaV2", 0, Instance);
            }
            Configs.JavaMigrated.Set(true, (IConfigProvider)(object)Instance.Config);
        }
        finally
        {
            if (ModMain.FrmInstanceSetup != null)
            {
                ModBase.RunInUiWait(() =>
                {
                    SettingService.RefreshSettings(ModMain.FrmInstanceSetup.ComboArgumentJava);
                    SettingService.RefreshSettings(ModMain.FrmInstanceSetup.ComboArgumentJavaSelect);
                    ModMain.FrmInstanceSetup.ComboArgumentJava.IsEnabled = true;
                });
            }
        }
    }

    private static ModLoader.LoaderCombo<int> CreateJavaDownloadLoader(JavaDownloadInfo Target)
    {
        _Closure_0024__16_002D0 arg = default;
        _Closure_0024__16_002D0 CS_0024_003C_003E8__locals4 = new _Closure_0024__16_002D0(arg);
        string text = (string)Target.Java["manifest"][(object)"url"];
        Logger.Info(string.Format("准备下载 Java {0}（{1}）：{2}", Target.Java["version"][(object)"name"], Target.ComponentName, text), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
        string text2 = ModNet.NetRequestByLoader(ModDownload.DlSourceOrder(new string[1] { text }, new string[1] { text.Replace("piston-meta.mojang.com", "bmclapi2.bangbang93.com") }), 45000, IsJson: true);
        CS_0024_003C_003E8__locals4._0024VB_0024Local_BaseDir = $"{Paths.AppData}.minecraft\\runtime\\{Target.ComponentName}\\";
        List<ModNet.NetFile> list = new List<ModNet.NetFile>();
        foreach (JProperty item in (IEnumerable<JToken>)((JObject)StringExtensions.DeserializeJson(text2))["files"])
        {
            JProperty val = item;
            JToken val2 = ((JObject)val.Value)["downloads"];
            if (((val2 != null) ? val2[(object)"raw"] : null) != null)
            {
                JObject val3 = (JObject)((JObject)val.Value)["downloads"][(object)"raw"];
                FileChecker val4 = new FileChecker
                {
                    ActualSize = (long)val3["size"],
                    Hash = (string)val3["sha1"]
                };
                if (Operators.CompareString(val4.Hash, "12976a6c2b227cbac58969c1455444596c894656", TextCompare: false) != 0 && Operators.CompareString(val4.Hash, "c80e4bab46e34d02826eab226a4441d0970f2aba", TextCompare: false) != 0 && Operators.CompareString(val4.Hash, "84d2102ad171863db04e7ee22a259d1f6c5de4a5", TextCompare: false) != 0)
                {
                    string text3 = (string)val3["url"];
                    list.Add(new ModNet.NetFile(ModDownload.DlSourceOrder(new string[1] { text3 }, new string[1] { text3.Replace("piston-data.mojang.com", "bmclapi2.bangbang93.com") }), CS_0024_003C_003E8__locals4._0024VB_0024Local_BaseDir + val.Name, val4));
                }
            }
        }
        Logger.Info($"该 Java 需要下载 {list.Count} 个文件，目标文件夹：{CS_0024_003C_003E8__locals4._0024VB_0024Local_BaseDir}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModJava.vb");
        return new ModLoader.LoaderCombo<int>("下载 Java", new ModLoader.LoaderBase[2]
        {
            new ModNet.LoaderDownload("下载 Java 文件", list)
            {
                ProgressWeight = 10.0
            },
            new ModLoader.LoaderWorker("刷新 Java 列表", (IWorker)(object)JavaListRefreshWorker)
        })
        {
            OnStateChanged = (ModLoader.LoaderBase a0) =>
            {
                CS_0024_003C_003E8__locals4._Lambda_0024__0((ModLoader.LoaderCombo<int>)a0);
            }
        };
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[StandardModule]
public sealed class ModDownloadLib
{
    public class McInstallRequest
    {
        public string NewInstanceName;

        public string VersionFolder;

        public string MinecraftName;

        public string MinecraftJson;

        public string OptiFineVersion;

        public ModDownload.DlOptiFineListEntry OptiFineEntry;

        public string ForgeVersion;

        public ModDownload.DlForgeVersionEntry ForgeEntry;

        public string NeoForgeVersion;

        public ModDownload.DlNeoForgeListEntry NeoForgeEntry;

        public string FabricVersion;

        public ResourceVersion FabricApi;

        public ResourceVersion OptiFabric;

        public ModDownload.DlLiteLoaderListEntry LiteLoaderEntry;

        public McInstallRequest()
        {
            MinecraftName = null;
            MinecraftJson = null;
            OptiFineVersion = null;
            OptiFineEntry = null;
            ForgeVersion = null;
            ForgeEntry = null;
            NeoForgeVersion = null;
            NeoForgeEntry = null;
            FabricVersion = null;
            FabricApi = null;
            OptiFabric = null;
            LiteLoaderEntry = null;
        }
    }

    [Serializable]
    [CompilerGenerated]
    internal sealed class _Closure_0024__
    {
        public static readonly _Closure_0024__ _0024I;

        public static MyIconButton.ClickEventHandler _0024IR5_002D1;

        public static MyIconButton.ClickEventHandler _0024IR5_002D2;

        public static MyIconButton.ClickEventHandler _0024IR6_002D3;

        public static MyIconButton.ClickEventHandler _0024IR6_002D4;

        public static MyIconButton.ClickEventHandler _0024IR6_002D5;

        public static Func<ModLoader.LoaderBase, bool> _0024I13_002D2;

        public static Func<ModLoader.LoaderBase, bool> _0024I13_002D3;

        public static Func<ModLoader.LoaderBase, bool> _0024I13_002D4;

        public static MyIconButton.ClickEventHandler _0024IR16_002D8;

        public static MyIconButton.ClickEventHandler _0024IR17_002D9;

        public static MyIconButton.ClickEventHandler _0024IR17_002D10;

        public static MyIconButton.ClickEventHandler _0024IR23_002D11;

        public static MyIconButton.ClickEventHandler _0024IR24_002D12;

        public static MyIconButton.ClickEventHandler _0024IR24_002D13;

        public static Func<string, bool> _0024I28_002D2;

        public static Func<ModLoader.LoaderBase, bool> _0024I30_002D4;

        public static Func<ModLoader.LoaderBase, bool> _0024I30_002D5;

        public static Func<ModLoader.LoaderBase, bool> _0024I30_002D6;

        public static Func<string, DirectoryInfo> _0024I30_002D9;

        public static Func<DirectoryInfo, bool> _0024I30_002D10;

        public static Func<DirectoryInfo, string> _0024I30_002D11;

        public static Func<string, bool> _0024I32_002D1;

        public static MyIconButton.ClickEventHandler _0024IR33_002D16;

        public static MyIconButton.ClickEventHandler _0024IR33_002D17;

        public static MyIconButton.ClickEventHandler _0024IR34_002D18;

        public static Action _0024I37_002D0;

        public static MyIconButton.ClickEventHandler _0024IR42_002D19;

        public static MyIconButton.ClickEventHandler _0024IR42_002D20;

        public static MyIconButton.ClickEventHandler _0024IR43_002D21;

        public static Func<string, string> _0024I57_002D0;

        static _Closure_0024__()
        {
            _0024I = new _Closure_0024__();
        }

        internal void _Lambda_0024__R5_002D1(object a0, EventArgs a1)
        {
            McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R5_002D2(object a0, EventArgs a1)
        {
            McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R6_002D3(object a0, EventArgs a1)
        {
            McDownloadMenuSave(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R6_002D4(object a0, EventArgs a1)
        {
            McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R6_002D5(object a0, EventArgs a1)
        {
            McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal bool _Lambda_0024__13_002D2(ModLoader.LoaderBase l)
        {
            if (Operators.CompareString(l.Name, "下载原版支持库文件", TextCompare: false) != 0)
            {
                return Operators.CompareString(l.Name, "下载原版 json 文件", TextCompare: false) == 0;
            }
            return true;
        }

        internal bool _Lambda_0024__13_002D3(ModLoader.LoaderBase l)
        {
            return l.State != ModBase.LoadState.Finished;
        }

        internal bool _Lambda_0024__13_002D4(ModLoader.LoaderBase l)
        {
            return l.State != ModBase.LoadState.Finished;
        }

        internal void _Lambda_0024__R16_002D8(object a0, EventArgs a1)
        {
            OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R17_002D9(object a0, EventArgs a1)
        {
            OptiFineSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R17_002D10(object a0, EventArgs a1)
        {
            OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R23_002D11(object a0, EventArgs a1)
        {
            LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R24_002D12(object a0, EventArgs a1)
        {
            LiteLoaderSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R24_002D13(object a0, EventArgs a1)
        {
            LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal bool _Lambda_0024__28_002D2(string l)
        {
            return Operators.CompareString(l, "true", TextCompare: false) == 0;
        }

        internal bool _Lambda_0024__30_002D4(ModLoader.LoaderBase l)
        {
            if (Operators.CompareString(l.Name, "下载原版支持库文件", TextCompare: false) != 0)
            {
                return Operators.CompareString(l.Name, "下载原版 json 文件", TextCompare: false) == 0;
            }
            return true;
        }

        internal bool _Lambda_0024__30_002D5(ModLoader.LoaderBase l)
        {
            return l.State != ModBase.LoadState.Finished;
        }

        internal bool _Lambda_0024__30_002D6(ModLoader.LoaderBase l)
        {
            return l.State != ModBase.LoadState.Finished;
        }

        internal DirectoryInfo _Lambda_0024__30_002D9(string f)
        {
            return DirectoryUtils.GetInfo(f);
        }

        internal bool _Lambda_0024__30_002D10(DirectoryInfo l)
        {
            if (StringExtensions.ContainsIgnoreCase(l.Name, "forge"))
            {
                return l.EnumerateFiles().Any();
            }
            return false;
        }

        internal string _Lambda_0024__30_002D11(DirectoryInfo d)
        {
            return d.Name;
        }

        internal bool _Lambda_0024__32_002D1(string d)
        {
            return Operators.CompareString(d, "", TextCompare: false) != 0;
        }

        internal void _Lambda_0024__R33_002D16(object a0, EventArgs a1)
        {
            ForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R33_002D17(object a0, EventArgs a1)
        {
            ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R34_002D18(object a0, EventArgs a1)
        {
            ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__37_002D0()
        {
            try
            {
                Logger.Info("刷新 Forge 推荐版本缓存开始", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                string text = ModNet.NetRequestByClientRetry("https://bmclapi2.bangbang93.com/forge/promos", null, null, null, null, "*/*", null, RequireJson: true);
                if (text.Length < 1000)
                {
                    throw new Exception("获取的结果过短（" + text + "）");
                }
                JContainer val = (JContainer)StringExtensions.DeserializeJson(text);
                List<string> list = new List<string>();
                foreach (JObject item in (IEnumerable<JToken>)val)
                {
                    JObject val2 = item;
                    if (val2["name"] != null && val2["build"] != null)
                    {
                        string text2 = (string)val2["name"];
                        if (StringExtensions.EndsWithF(text2, "-recommended", false))
                        {
                            list.Add("\"" + text2.Replace("-recommended", "\":\"" + val2["build"][(object)"version"].ToString() + "\""));
                        }
                    }
                }
                if (list.Count < 5)
                {
                    throw new Exception("获取的推荐版本数过少（" + text + "）");
                }
                string text3 = "{" + EnumerableExtensions.Join((IEnumerable)list, ",") + "}";
                FileUtils.Write(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json", text3, (Encoding)null);
                Logger.Info("刷新 Forge 推荐版本缓存成功", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "刷新 Forge 推荐版本缓存失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
        }

        internal void _Lambda_0024__R42_002D19(object a0, EventArgs a1)
        {
            NeoForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R42_002D20(object a0, EventArgs a1)
        {
            NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal void _Lambda_0024__R43_002D21(object a0, EventArgs a1)
        {
            NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        }

        internal string _Lambda_0024__57_002D0(string l)
        {
            return l.Trim();
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__12_002D0
    {
        public AutoResetEvent _0024VB_0024Local_outputWaitHandle;

        public _Closure_0024__12_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

        public _Closure_0024__12_002D0(_Closure_0024__12_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_outputWaitHandle = arg0._0024VB_0024Local_outputWaitHandle;
            }
        }

        internal void _Lambda_0024__R6(object a0, DataReceivedEventArgs a1)
        {
            _Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
        }

        internal object _Lambda_0024__0(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null)
                {
                    _0024VB_0024Local_outputWaitHandle.Set();
                }
                else
                {
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult = e.Data;
                    Logger.Trace(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength = checked(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength + 1);
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 9.999999999999999E-05;
                }
            }
            catch (ObjectDisposedException ex)
            {
                ProjectData.SetProjectError(ex);
                ObjectDisposedException ex2 = ex;
                ProjectData.ClearProjectError();
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, "读取 OptiFine 安装器信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            try
            {
                if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Canceled && !_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                {
                    Logger.Info("由于任务取消，已中止 OptiFine 安装", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            return null;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__12_002D1
    {
        public string _0024VB_0024Local_LastResult;

        public int _0024VB_0024Local_TotalLength;

        public Process _0024VB_0024Local_process;

        public _Closure_0024__12_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

        public _Closure_0024__12_002D1(_Closure_0024__12_002D1 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_LastResult = arg0._0024VB_0024Local_LastResult;
                _0024VB_0024Local_TotalLength = arg0._0024VB_0024Local_TotalLength;
                _0024VB_0024Local_process = arg0._0024VB_0024Local_process;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__12_002D2
    {
        public ModLoader.LoaderTask<List<ModNet.NetFile>, bool> _0024VB_0024Local_Task;

        public _Closure_0024__12_002D2(_Closure_0024__12_002D2 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__12_002D3
    {
        public AutoResetEvent _0024VB_0024Local_errorWaitHandle;

        public _Closure_0024__12_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

        public _Closure_0024__12_002D3(_Closure_0024__12_002D3 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_errorWaitHandle = arg0._0024VB_0024Local_errorWaitHandle;
            }
        }

        internal void _Lambda_0024__R7(object a0, DataReceivedEventArgs a1)
        {
            _Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
        }

        internal object _Lambda_0024__1(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null)
                {
                    _0024VB_0024Local_errorWaitHandle.Set();
                }
                else
                {
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult = e.Data;
                    Logger.Trace(_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength = checked(_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength + 1);
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 9.999999999999999E-05;
                }
            }
            catch (ObjectDisposedException ex)
            {
                ProjectData.SetProjectError(ex);
                ObjectDisposedException ex2 = ex;
                ProjectData.ClearProjectError();
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, "读取 OptiFine 安装器错误信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            try
            {
                if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Canceled && !_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                {
                    Logger.Info("由于任务取消，已中止 OptiFine 安装", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            return null;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__28_002D0
    {
        public AutoResetEvent _0024VB_0024Local_outputWaitHandle;

        public _Closure_0024__28_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

        public _Closure_0024__28_002D0(_Closure_0024__28_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_outputWaitHandle = arg0._0024VB_0024Local_outputWaitHandle;
            }
        }

        internal void _Lambda_0024__R14(object a0, DataReceivedEventArgs a1)
        {
            _Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
        }

        internal object _Lambda_0024__0(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null)
                {
                    _0024VB_0024Local_outputWaitHandle.Set();
                }
                else
                {
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Enqueue(e.Data);
                    if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count > 100)
                    {
                        _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Dequeue();
                    }
                    ForgelikeInjectorLine(e.Data, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task);
                }
            }
            catch (ObjectDisposedException ex)
            {
                ProjectData.SetProjectError(ex);
                ObjectDisposedException ex2 = ex;
                ProjectData.ClearProjectError();
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, $"读取 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            try
            {
                if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Canceled && !_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                {
                    Logger.Info($"由于任务取消，已中止 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            return null;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__28_002D1
    {
        public Queue<string> _0024VB_0024Local_LastResults;

        public string _0024VB_0024Local_LoaderName;

        public Process _0024VB_0024Local_process;

        public _Closure_0024__28_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

        public _Closure_0024__28_002D1(_Closure_0024__28_002D1 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_LastResults = arg0._0024VB_0024Local_LastResults;
                _0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
                _0024VB_0024Local_process = arg0._0024VB_0024Local_process;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__28_002D2
    {
        public ModLoader.LoaderTask<bool, bool> _0024VB_0024Local_Task;

        public _Closure_0024__28_002D2(_Closure_0024__28_002D2 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__28_002D3
    {
        public AutoResetEvent _0024VB_0024Local_errorWaitHandle;

        public _Closure_0024__28_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

        public _Closure_0024__28_002D3(_Closure_0024__28_002D3 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_errorWaitHandle = arg0._0024VB_0024Local_errorWaitHandle;
            }
        }

        internal void _Lambda_0024__R15(object a0, DataReceivedEventArgs a1)
        {
            _Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
        }

        internal object _Lambda_0024__1(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (e.Data == null)
                {
                    _0024VB_0024Local_errorWaitHandle.Set();
                }
                else
                {
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Enqueue(e.Data);
                    if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count > 100)
                    {
                        _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Dequeue();
                    }
                    ForgelikeInjectorLine(e.Data, _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task);
                }
            }
            catch (ObjectDisposedException ex)
            {
                ProjectData.SetProjectError(ex);
                ObjectDisposedException ex2 = ex;
                ProjectData.ClearProjectError();
            }
            catch (Exception ex3)
            {
                ProjectData.SetProjectError(ex3);
                Exception ex4 = ex3;
                Logger.Warn(ex4, $"读取 {_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器错误信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            try
            {
                if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Canceled && !_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                {
                    Logger.Info($"由于任务取消，已中止 {_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
                }
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            return null;
        }
    }

    private const string McDownloadClientLibName = "下载原版支持库文件";

    private const string McDownloadClientJsonName = "下载原版 json 文件";

    private static bool IsForgeRecommendedRefreshed = false;

    private static object InstallSyncLock = RuntimeHelpers.GetObjectValue(new object());

    private static object VanillaSyncLock = RuntimeHelpers.GetObjectValue(new object());

    private static List<ModLoader.LoaderBase> McDownloadClientLoader(string Id, string JsonUrl = null, string InstanceName = null)
    {
        InstanceName = InstanceName ?? Id;
        string text = ModMinecraft.McFolderSelected + "versions\\" + InstanceName + "\\";
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        ModMinecraft.McInstance mcInstance = null;
        if (JsonUrl == null)
        {
            list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取原版 json 文件下载地址", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
            {
                string original = Conversions.ToString(ModDownload.DlClientListGet(Id));
                Task.Output = new List<ModNet.NetFile>
                {
                    new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), text + InstanceName + ".json")
                };
            })
            {
                ProgressWeight = 2.0,
                Show = false
            });
        }
        list.Add(new ModNet.LoaderDownload("下载原版 json 文件", new List<ModNet.NetFile>
        {
            new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(JsonUrl ?? ""), text + InstanceName + ".json", new FileChecker
            {
                IsJson = true
            })
        })
        {
            ProgressWeight = 3.0
        });
        list.Add(new ModLoader.LoaderTask<string, string>("读取 json 文件", (ModLoader.LoaderTask<string, string> Task) =>
        {
            mcInstance = new ModMinecraft.McInstance(text);
            mcInstance.Load();
        })
        {
            ProgressWeight = 0.0,
            Show = false
        });
        List<ModLoader.LoaderBase> list2 = new List<ModLoader.LoaderBase>();
        list2.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析原版支持库文件（副加载器）", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            Logger.Info($"开始分析原版支持库文件：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            Task.Output = ModMinecraft.McLibNetFilesFromInstance(mcInstance);
        })
        {
            ProgressWeight = 1.0,
            Show = false
        });
        list2.Add(new ModNet.LoaderDownload("下载原版支持库文件（副加载器）", new List<ModNet.NetFile>())
        {
            ProgressWeight = 13.0,
            Show = false
        });
        list.Add(new ModLoader.LoaderCombo<string>("下载原版支持库文件", list2)
        {
            Block = false,
            ProgressWeight = 14.0
        });
        List<ModLoader.LoaderBase> list3 = new List<ModLoader.LoaderBase>();
        list3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址（副加载器）", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            try
            {
                ModNet.NetFile netFile = ModDownload.DlClientAssetIndexGet(mcInstance);
                Task.Output = ((netFile == null) ? new List<ModNet.NetFile>() : new List<ModNet.NetFile> { netFile });
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception innerException = ex;
                throw new Exception("分析资源文件索引地址失败", innerException);
            }
            try
            {
                JObject val = (JObject)FileUtils.ReadAsJson(text + InstanceName + ".json", (Encoding)null, (Type)null);
                val.Add("clientVersion", (JToken)(Id));
                FileUtils.Write($"{text}{InstanceName}.json", ((JToken)val).ToString(), (Encoding)null);
            }
            catch (Exception ex2)
            {
                ProjectData.SetProjectError(ex2);
                Exception innerException2 = ex2;
                throw new Exception("添加客户端版本失败", innerException2);
            }
        })
        {
            ProgressWeight = 1.0,
            Show = false
        });
        list3.Add(new ModNet.LoaderDownload("下载资源文件索引（副加载器）", new List<ModNet.NetFile>())
        {
            ProgressWeight = 3.0,
            Show = false
        });
        list3.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析所需资源文件（副加载器）", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
            ModMinecraft.McInstance instance = mcInstance;
            ModLoader.LoaderBase ProgressFeed = Task;
            List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList(instance, CheckHash: true, ref ProgressFeed);
            Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)ProgressFeed;
            loaderTask.Output = output;
        })
        {
            ProgressWeight = 0.01,
            Show = false
        });
        list3.Add(new ModNet.LoaderDownload("下载资源文件（副加载器）", new List<ModNet.NetFile>())
        {
            ProgressWeight = 14.0,
            Show = false
        });
        list.Add(new ModLoader.LoaderCombo<string>("下载原版资源文件", list3)
        {
            Block = false,
            ProgressWeight = 18.0
        });
        return list;
    }

    public static MyVirtualizingElement<MyListItem> McDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            JToken val = Entry["type"];
            string logo = (((string)val == "release") ? (ModBase.PathImage + "Blocks/Grass.png") : (((string)val == "snapshot") ? (ModBase.PathImage + "Blocks/CommandBlock.png") : ((!((string)val == "special")) ? (ModBase.PathImage + "Blocks/CobbleStone.png") : (ModBase.PathImage + "Blocks/GoldBlock.png"))));
            MyListItem myListItem = new MyListItem
            {
                Logo = logo,
                SnapsToDevicePixels = true,
                Title = Entry["id"].ToString(),
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Entry
            };
            if (Entry["lore"] == null)
            {
                myListItem.Info = Extensions.Value<DateTime>((IEnumerable<JToken>)Entry["releaseTime"]).ToString("yyyy'/'MM'/'dd HH':'mm");
            }
            else
            {
                myListItem.Info = Entry["lore"].ToString();
            }
            if (Entry["url"].ToString().Contains("pcl"))
            {
                myListItem.Info = "[PCL 特供下载] " + myListItem.Info;
            }
            myListItem.Click += OnClick;
            if (IsSaveOnly)
            {
                myListItem.ContentHandler = McDownloadSaveMenuBuild;
            }
            else
            {
                myListItem.ContentHandler = McDownloadMenuBuild;
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    private static void McDownloadSaveMenuBuild(object sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.0,
            Logo = "M224 160a64 64 0 0 0-64 64v576a64 64 0 0 0 64 64h576a64 64 0 0 0 64-64V224a64 64 0 0 0-64-64H224z m0 384h576v256H224v-256z m192 96v64h320v-64H416z m-128 0v64h64v-64H288zM224 224h576v256H224V224z m192 96v64h320v-64H416z m-128 0v64h64v-64H288z",
            ToolTip = "下载服务端"
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        NewLateBinding.LateSet(sender, null, "Buttons", new object[1] { new MyIconButton[2] { myIconButton2, myIconButton } }, null, null);
    }

    private static void McDownloadMenuBuild(object sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
            ToolTip = "另存为"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            McDownloadMenuSave(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton3 = new MyIconButton
        {
            LogoScale = 1.0,
            Logo = "M224 160a64 64 0 0 0-64 64v576a64 64 0 0 0 64 64h576a64 64 0 0 0 64-64V224a64 64 0 0 0-64-64H224z m0 384h576v256H224v-256z m192 96v64h320v-64H416z m-128 0v64h64v-64H288zM224 224h576v256H224V224z m192 96v64h320v-64H416z m-128 0v64h64v-64H288z",
            ToolTip = "下载服务端"
        };
        myIconButton3.Click += (object a0, EventArgs a1) =>
        {
            McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        NewLateBinding.LateSet(sender, null, "Buttons", new object[1] { new MyIconButton[3] { myIconButton, myIconButton2, myIconButton3 } }, null, null);
    }

    private static void McDownloadMenuLog(object sender, RoutedEventArgs e)
    {
        JToken instanceJson;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            instanceJson = (JToken)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            instanceJson = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        McUpdateLogShow(instanceJson);
    }

    private static void McDownloadMenuSaveServer(object sender, RoutedEventArgs e)
    {
        MyListItem myListItem;
        if (sender is MyListItem)
        {
            myListItem = (MyListItem)sender;
        }
        else
        {
            myListItem = ((!(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null) is MyListItem)) ? ((MyListItem)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null)) : ((MyListItem)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)));
        }
        try
        {
            string title = myListItem.Title;
            string original = NewLateBinding.LateIndexGet(myListItem.Tag, new object[1] { "url" }, null).ToString();
            string text = Dialogs.SelectFolder("选择目标文件夹", false, (string)null).FirstOrDefault();
            if (text == null)
            {
                return;
            }
            text = text + title + "\\";
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"Minecraft {title} 服务端下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该服务端正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
            list.Add(new ModNet.LoaderDownload("下载版本 JSON 文件", new List<ModNet.NetFile>
            {
                new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), text + title + ".json", new FileChecker
                {
                    IsJson = true
                })
            })
            {
                ProgressWeight = 2.0
            });
            list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("构建服务端", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
            {
                ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(text);
                if (mcInstance.JsonObject["downloads"] == null || mcInstance.JsonObject["downloads"][(object)"server"] == null || mcInstance.JsonObject["downloads"][(object)"server"][(object)"url"] == null)
                {
                    FileUtils.Delete(text + title + ".json", false);
                    if (!DirectoryUtils.GetInfo(text).GetFileSystemInfos().Any())
                    {
                        DirectoryUtils.Delete(text, false);
                    }
                    Task.Output = new List<ModNet.NetFile>();
                    ModMain.Hint($"Mojang 没有给 Minecraft {title} 提供官方服务端下载，没法下，撤退！", ModMain.HintType.Red);
                    Thread.Sleep(2000);
                    Task.Cancel();
                }
                else
                {
                    string original2 = (string)mcInstance.JsonObject["downloads"][(object)"server"][(object)"url"];
                    FileChecker checker = new FileChecker
                    {
                        MinSize = 1024L,
                        ActualSize = (long)(mcInstance.JsonObject["downloads"][(object)"server"][(object)"size"] ?? (JToken)(-1)),
                        Hash = (string)mcInstance.JsonObject["downloads"][(object)"server"][(object)"sha1"]
                    };
                    Task.Output = new List<ModNet.NetFile>
                    {
                        new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original2), text + title + "-server.jar", checker)
                    };
                    string text2 = $"@echo off\r\ntitle {title} 原版服务端\r\necho 如果服务端立即停止，请右键编辑该脚本，将下一行开头的 java 替换为适合该 Minecraft 版本的完整 java.exe 的路径。\r\necho 你可以在 PCL 的 [设置 → 启动选项] 中查看已安装的 java，所需的 java.exe 一般在其中的 bin 文件夹下。\r\necho ------------------------------\r\necho 如果提示 \"You need to agree to the EULA in order to run the server\"，请打开 eula.txt，按说明阅读并同意 Minecraft EULA 后，将该文件最后一行中的 eula=false 改为 eula=true。\r\necho ------------------------------\r\n\"java\" -server -XX:+UseG1GC -Xmx6144M -Xms1024M -jar {title}-server.jar nogui\r\necho ----------------------\r\necho 服务端已停止。\r\npause";
                    FileUtils.Write(text + "Launch Server.bat", text2, Encoding.Default.Equals(Encoding.UTF8) ? Encoding.UTF8 : Encoding.GetEncoding("GB18030"));
                    FileUtils.Delete(text + title + ".json", false);
                }
            })
            {
                ProgressWeight = 0.5,
                Show = false
            });
            list.Add(new ModNet.LoaderDownload("下载服务端文件", new List<ModNet.NetFile>())
            {
                ProgressWeight = 5.0
            });
            ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + title + " 服务端下载", list);
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(title);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始 Minecraft 服务端下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    public static void McDownloadMenuSave(object sender, RoutedEventArgs e)
    {
        MyListItem myListItem;
        if (sender is MyListItem)
        {
            myListItem = (MyListItem)sender;
        }
        else
        {
            myListItem = ((!(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null) is MyListItem)) ? ((MyListItem)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null)) : ((MyListItem)NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null)));
        }
        try
        {
            string title = myListItem.Title;
            string original = NewLateBinding.LateIndexGet(myListItem.Tag, new object[1] { "url" }, null).ToString();
            string text = Dialogs.SelectFolder("选择目标文件夹", false, (string)null).FirstOrDefault();
            if (text == null)
            {
                return;
            }
            text = text + title + "\\";
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"Minecraft {title} 下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该版本正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
            list.Add(new ModNet.LoaderDownload("下载版本 JSON 文件", new List<ModNet.NetFile>
            {
                new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), text + title + ".json", new FileChecker
                {
                    IsJson = true
                })
            })
            {
                ProgressWeight = 2.0
            });
            list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析核心 JAR 文件下载地址", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
            {
                Task.Output = new List<ModNet.NetFile> { ModDownload.DlClientJarGet(new ModMinecraft.McInstance(text), ReturnNothingOnFileUseable: false) };
            })
            {
                ProgressWeight = 0.5,
                Show = false
            });
            list.Add(new ModNet.LoaderDownload("下载核心 JAR 文件", new List<ModNet.NetFile>())
            {
                ProgressWeight = 5.0
            });
            ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + title + " 下载", list);
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(title);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始 Minecraft 下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    public static void McUpdateLogShow(JToken InstanceJson)
    {
        string text = StringExtensions.Lower(InstanceJson[(object)"id"].ToString());
        string text2;
        switch (text)
        {
            case "3d shareware v1.34":
                text2 = "3D_Shareware_v1.34";
                break;
            case "2.0":
                text2 = "Java版2.0";
                break;
            case "1.rv-pre1":
                text2 = "Java版1.RV-Pre1";
                break;
            default:
                if (!text.Contains("combat-1") && !text.Contains("combat-212796"))
                {
                    if (Operators.CompareString(text, "combat test 2", TextCompare: false) == 0 || text.Contains("combat-2") || text.Contains("combat-0"))
                    {
                        text2 = "Java版Combat_Test_2";
                        break;
                    }
                    switch (text)
                    {
                        case "combat test 3":
                        case "1.14_combat-3":
                            text2 = "Java版Combat_Test_3";
                            break;
                        case "combat test 4":
                        case "1.15_combat-1":
                            text2 = "Java版Combat_Test_4";
                            break;
                        case "combat test 5":
                        case "1.15_combat-6":
                            text2 = "Java版Combat_Test_5";
                            break;
                        case "combat test 6":
                        case "1.16_combat-0":
                            text2 = "Java版Combat_Test_6";
                            break;
                        case "combat test 7c":
                        case "1.16_combat-3":
                            text2 = "Java版Combat_Test_7c";
                            break;
                        case "combat test 8b":
                        case "1.16_combat-5":
                            text2 = "Java版Combat_Test_8b";
                            break;
                        case "combat test 8c":
                        case "1.16_combat-6":
                            text2 = "Java版Combat_Test_8c";
                            break;
                        case "1.0.0-rc2-2":
                            text2 = "Java版RC2";
                            break;
                        default:
                            if (StringExtensions.StartsWithF(text, "1.19_deep_dark_experimental_snapshot-", false) || StringExtensions.StartsWithF(text, "1_19_deep_dark_experimental_snapshot-", false))
                            {
                                text2 = text.Replace("1_19", "1.19").Replace("1.19_deep_dark_experimental_snapshot-", "Java版Deep_Dark_Experimental_Snapshot_");
                                break;
                            }
                            if (Operators.CompareString(text, "b1.9-pre6", TextCompare: false) == 0)
                            {
                                text2 = "Java版Beta_1.9_Prerelease_6";
                                break;
                            }
                            if (text.Contains("b1.9"))
                            {
                                text2 = "Java版Beta_1.9_Prerelease";
                                break;
                            }
                            if ((string)InstanceJson[(object)"type"] == "release" || (string)InstanceJson[(object)"type"] == "snapshot" || (string)InstanceJson[(object)"type"] == "special")
                            {
                                text2 = (text.Contains("w") ? "" : "Java版") + text.Replace(" Pre-Release ", "-pre");
                                break;
                            }
                            if (StringExtensions.StartsWithF(text, "b", false))
                            {
                                text2 = "Java版" + text.TrimEnd('a', 'b', 'c', 'd', 'e').Replace("b", "Beta_");
                                break;
                            }
                            if (StringExtensions.StartsWithF(text, "a", false))
                            {
                                text2 = "Java版" + text.TrimEnd('a', 'b', 'c', 'd', 'e').Replace("a", "Alpha_v");
                                break;
                            }
                            switch (text)
                            {
                                case "inf-20100618":
                                    text2 = "Java版Infdev_20100618";
                                    break;
                                default:
                                    if (!text.Contains("生存测试"))
                                    {
                                        if (StringExtensions.StartsWithF(text, "c0.31", false))
                                        {
                                            text2 = "Java版Indev_0.31_20100130";
                                            break;
                                        }
                                        if (StringExtensions.StartsWithF(text, "c", false))
                                        {
                                            text2 = "Java版" + text.Replace("c", "Classic_");
                                            break;
                                        }
                                        if (StringExtensions.StartsWithF(text, "rd-", false))
                                        {
                                            text2 = "Java版Pre-classic_" + text;
                                            break;
                                        }
                                        Logger.Error($"未知的版本格式：{text}。", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                                        return;
                                    }
                                    goto case "c0.30_01c";
                                case "c0.30_01c":
                                case "c0.30_survival":
                                    text2 = "Java版Classic_0.30（生存模式）";
                                    break;
                            }
                            break;
                    }
                    break;
                }
                goto case "combat test 1";
            case "combat test 1":
                text2 = "Java版1.14.3_-_Combat_Test";
                break;
        }
        ModBase.OpenWebsite("https://zh.minecraft.wiki/w/" + text2.Replace("_experimental-snapshot-", "-exp"));
    }

    private static void McDownloadOptiFineSave(ModDownload.DlOptiFineListEntry DownloadInfo)
    {
        try
        {
            _ = DownloadInfo.InstanceName;
            string text = Dialogs.SaveFile("选择保存位置", DownloadInfo.FileName, (string)null, (IEnumerable<(string, string)>)new (string, string)[1] { ("jar", "OptiFine Jar") });
            if (text == null)
            {
                return;
            }
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"OptiFine {DownloadInfo.DisplayName} 下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该版本正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry>("OptiFine " + DownloadInfo.DisplayName + " 下载", McDownloadOptiFineSaveLoader(DownloadInfo, text));
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(DownloadInfo);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始 OptiFine 下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    private static void McDownloadOptiFineInstall(string BaseMcFolderHome, string Target, ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task, bool UseJavaWrapper)
    {
        _Closure_0024__12_002D2 obj = new _Closure_0024__12_002D2(null);
        obj._0024VB_0024Local_Task = Task;
        ValueRange<Version> val = ValueRange<Version>.AtLeast(new Version(21, 0));
        checked
        {
            try
            {
                using ZipArchive zipArchive = FileUtils.OpenZip(Target, default(CancellationToken));
                using Stream input = (zipArchive.GetEntry("optifine/Installer.class") ?? throw new FileNotFoundException("未找到 optifine/Installer.class")).Open();
                using BinaryReader binaryReader = new BinaryReader(input);
                byte[] array = binaryReader.ReadBytes(8);
                if (array.Length < 8)
                {
                    throw new IOException("Installer.class 长度不足");
                }
                if (array[0] != 202 || array[1] != 254 || array[2] != 186 || array[3] != 190)
                {
                    throw new InvalidDataException("Installer.class 文件头无效");
                }
                int num = array[6] * 256 + array[7];
                if (num < 49)
                {
                    throw new InvalidDataException("Installer.class 版本过低");
                }
                if (num > 100)
                {
                    throw new InvalidDataException("Installer.class 版本过高");
                }
                val = ValueRange<Version>.AtLeast(new Version(num - 44, 0));
                Logger.Info($"OptiFine 安装器 class 版本：{num}，需要 Java {val}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "读取 OptiFine 安装器 Java 版本失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            Java val2 = ModJava.SelectOrDownloadJava((OneOf<ValueRange<Version>, ModMinecraft.McInstance>)(val), TryFixOrHint: true, obj._0024VB_0024Local_Task.CreateCancellationToken(), obj._0024VB_0024Local_Task.CreateSyncProgressProvider(0.0, 0.2));
            if (obj._0024VB_0024Local_Task.IsCanceled)
            {
                return;
            }
            if (val2 == null)
            {
                throw new OperationCanceledException();
            }
            string text = ((!UseJavaWrapper || Settings.Get<bool>("LaunchAdvanceDisableJLW")) ? $"-Duser.home=\"{BaseMcFolderHome.TrimEnd('\\')}\" -cp \"{Target}\" optifine.Installer" : string.Format("-Doolloo.jlw.tmpdir=\"{0}\" -Duser.home=\"{1}\" -cp \"{2}\" -jar \"{3}\" optifine.Installer", ModBase.PathPure.Value.TrimEnd('\\'), BaseMcFolderHome.TrimEnd('\\'), Target, LaunchUtils.ExtractPatch("Launch\\JavaWrapper.jar", ModBase.PathPure.Value)));
            if (val2.Version.Major >= 9)
            {
                text = "--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED " + text;
            }
            object installSyncLock = InstallSyncLock;
            ObjectFlowControl.CheckForSyncLockOnValueType(installSyncLock);
            bool lockTaken = false;
            try
            {
                Monitor.Enter(installSyncLock, ref lockTaken);
                _Closure_0024__12_002D1 obj2 = new _Closure_0024__12_002D1(null);
                obj2._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = val2.JavaExePath,
                    Arguments = text,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = PathUtils.ToShortPath(BaseMcFolderHome)
                };
                if (processStartInfo.EnvironmentVariables.ContainsKey("appdata"))
                {
                    processStartInfo.EnvironmentVariables["appdata"] = BaseMcFolderHome;
                }
                else
                {
                    processStartInfo.EnvironmentVariables.Add("appdata", BaseMcFolderHome);
                }
                Logger.Info($"开始安装 OptiFine：{Target}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                obj2._0024VB_0024Local_TotalLength = 0;
                obj2._0024VB_0024Local_process = new Process
                {
                    StartInfo = processStartInfo
                };
                obj2._0024VB_0024Local_LastResult = "";
                _Closure_0024__12_002D0 obj3 = new _Closure_0024__12_002D0(null);
                obj3._0024VB_0024NonLocal__0024VB_0024Closure_3 = obj2;
                obj3._0024VB_0024Local_outputWaitHandle = new AutoResetEvent(initialState: false);
                try
                {
                    _Closure_0024__12_002D3 arg = default;
                    _Closure_0024__12_002D3 CS_0024_003C_003E8__locals18 = new _Closure_0024__12_002D3(arg);
                    CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4 = obj3;
                    CS_0024_003C_003E8__locals18._0024VB_0024Local_errorWaitHandle = new AutoResetEvent(initialState: false);
                    try
                    {
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.OutputDataReceived += (object a0, DataReceivedEventArgs a1) =>
                        {
                            CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
                        };
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.ErrorDataReceived += (object a0, DataReceivedEventArgs a1) =>
                        {
                            CS_0024_003C_003E8__locals18._Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
                        };
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Start();
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginOutputReadLine();
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginErrorReadLine();
                        while (!CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                        {
                            Thread.Sleep(10);
                        }
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_outputWaitHandle.WaitOne(10000);
                        CS_0024_003C_003E8__locals18._0024VB_0024Local_errorWaitHandle.WaitOne(10000);
                        CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Dispose();
                        if (CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength < 1000 || CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult.Contains("at "))
                        {
                            throw new Exception("安装器运行出错，末行为 " + CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult);
                        }
                    }
                    finally
                    {
                        if (CS_0024_003C_003E8__locals18._0024VB_0024Local_errorWaitHandle != null)
                        {
                            ((IDisposable)CS_0024_003C_003E8__locals18._0024VB_0024Local_errorWaitHandle).Dispose();
                        }
                    }
                }
                finally
                {
                    if (obj3._0024VB_0024Local_outputWaitHandle != null)
                    {
                        ((IDisposable)obj3._0024VB_0024Local_outputWaitHandle).Dispose();
                    }
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(installSyncLock);
                }
            }
        }
    }

    private static List<ModLoader.LoaderBase> McDownloadOptiFineLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string McFolder, ModLoader.LoaderCombo<string> ClientDownloadLoader, string ClientFolder)
    {
        bool flag = Operators.CompareString(McFolder, ModMinecraft.McFolderSelected, TextCompare: false) != 0;
        string instanceName = DownloadInfo.InstanceName;
        string text = McFolder + "versions\\" + instanceName + "\\";
        bool flag2 = DownloadInfo.Inherit.Contains("w") || ModMinecraft.McVersion.VersionToDrop(DownloadInfo.Inherit) >= 140;
        string text2 = (flag2 ? $"{ModMain.RequestTaskTempFolder()}OptiFine.jar" : string.Format("{0}libraries\\optifine\\OptiFine\\{1}\\{2}", McFolder, DownloadInfo.FileName.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""), DownloadInfo.FileName.Replace("OptiFine_", "OptiFine-").Replace("preview_", "")));
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 OptiFine 主文件下载地址", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            List<string> list2 = new List<string>();
            string text3 = DownloadInfo.Inherit;
            if (Operators.CompareString(text3, "1.8", TextCompare: false) == 0 || Operators.CompareString(text3, "1.9", TextCompare: false) == 0)
            {
                text3 += ".0";
            }
            if (DownloadInfo.IsPreview)
            {
                list2.Add("https://bmclapi2.bangbang93.com/optifine/" + text3 + "/HD_U_" + DownloadInfo.DisplayName.Replace(DownloadInfo.Inherit + " ", "").Replace(" ", "/"));
            }
            else
            {
                list2.Add("https://bmclapi2.bangbang93.com/optifine/" + text3 + "/HD_U/" + DownloadInfo.DisplayName.Replace(DownloadInfo.Inherit + " ", ""));
            }
            try
            {
                string text4 = ModNet.NetRequestByClientRetry("https://optifine.net/adloadx?f=" + DownloadInfo.FileName, null, null, null, null, "text/html", null, RequireJson: false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), SimulateBrowserHeaders: true);
                Task.Progress = 0.8;
                list2.Add("https://optifine.net/" + StringExtensions.RegexSearch(text4, "downloadx\\?f=[^\"']+", RegexOptions.None).First());
                Logger.Info($"OptiFine {DownloadInfo.DisplayName} 官方下载地址：{list2.Last()}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, $"获取 OptiFine {DownloadInfo.DisplayName} 官方下载地址失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
            Task.Output = new List<ModNet.NetFile>
            {
                new ModNet.NetFile(list2.ToArray(), text2, new FileChecker
                {
                    MinSize = 307200L
                })
            };
        })
        {
            ProgressWeight = 8.0
        });
        list.Add(new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
        {
            ProgressWeight = 8.0
        });
        list.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("等待原版下载", (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
        {
            List<ModLoader.LoaderBase> source = (from l in ClientDownloadLoader.GetLoaderList()
                                                 where Operators.CompareString(l.Name, "下载原版支持库文件", TextCompare: false) == 0 || Operators.CompareString(l.Name, "下载原版 json 文件", TextCompare: false) == 0
                                                 where l.State != ModBase.LoadState.Finished
                                                 select l).ToList();
            if (source.Any())
            {
                Logger.Info("OptiFine 安装正在等待原版文件下载完成", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            while (source.Any() && !Task.IsCanceled)
            {
                source = source.Where((_Closure_0024__._0024I13_002D4 == null) ? (_Closure_0024__._0024I13_002D4 = (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I13_002D4).ToList();
                Thread.Sleep(50);
            }
            if (!Task.IsCanceled && flag)
            {
                object vanillaSyncLock = VanillaSyncLock;
                ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
                bool lockTaken = false;
                try
                {
                    Monitor.Enter(vanillaSyncLock, ref lockTaken);
                    string lastPart = PathUtils.GetLastPart(ClientFolder);
                    DirectoryUtils.Create(McFolder + "versions\\" + DownloadInfo.Inherit);
                    if (!FileUtils.Exists(McFolder + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".json"))
                    {
                        FileUtils.Copy($"{ClientFolder}{lastPart}.json", $"{McFolder}versions\\{DownloadInfo.Inherit}\\{DownloadInfo.Inherit}.json");
                    }
                    if (!FileUtils.Exists(McFolder + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".jar"))
                    {
                        FileUtils.Copy($"{ClientFolder}{lastPart}.jar", $"{McFolder}versions\\{DownloadInfo.Inherit}\\{DownloadInfo.Inherit}.jar");
                    }
                }
                finally
                {
                    if (lockTaken)
                    {
                        Monitor.Exit(vanillaSyncLock);
                    }
                }
            }
        })
        {
            ProgressWeight = 0.1,
            Show = false
        });
        if (flag2)
        {
            Logger.Info($"检测为新版 OptiFine：{DownloadInfo.Inherit}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            list.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 A）", (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
            {
                string text3 = ModMain.RequestTaskTempFolder();
                string text4 = text3 + ".minecraft\\";
                try
                {
                    if (DirectoryUtils.Exists(text4 + "versions\\" + DownloadInfo.Inherit))
                    {
                        DirectoryUtils.Delete(text4 + "versions\\" + DownloadInfo.Inherit, false);
                    }
                    DirectoryUtils.Create(text4 + "versions\\" + DownloadInfo.Inherit + "\\");
                    ModMinecraft.McFolderLauncherProfilesJsonCreate(text4);
                    FileUtils.Copy(McFolder + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".json", text4 + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".json");
                    FileUtils.Copy(McFolder + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".jar", text4 + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".jar");
                    Task.Progress = 0.06;
                    bool flag3 = true;
                    while (true)
                    {
                        try
                        {
                            McDownloadOptiFineInstall(text3, text2, Task, flag3);
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            Exception ex2 = ex;
                            if (!flag3)
                            {
                                throw new Exception("运行 OptiFine 安装器失败", ex2);
                            }
                            Logger.Warn(ex2, "使用 JavaWrapper 安装 OptiFine 失败，将不使用 JavaWrapper 并重试", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                            flag3 = false;
                            ProjectData.ClearProjectError();
                            continue;
                        }
                        break;
                    }
                    Task.Progress = 0.96;
                    FileUtils.Delete(text4 + "launcher_profiles.json", false);
                    DirectoryUtils.Copy(text4, McFolder);
                    Task.Progress = 0.98;
                    FileUtils.Delete(text2, false);
                    DirectoryUtils.Delete(text3, false);
                }
                catch (Exception ex3)
                {
                    ProjectData.SetProjectError(ex3);
                    Exception innerException = ex3;
                    throw new Exception("安装 OptiFine（方式 A）失败", innerException);
                }
            })
            {
                ProgressWeight = 8.0
            });
        }
        else
        {
            Logger.Info($"检测为旧版 OptiFine：{DownloadInfo.Inherit}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            list.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 B）", (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
            {
                try
                {
                    FileUtils.Copy(McFolder + "versions\\" + DownloadInfo.Inherit + "\\" + DownloadInfo.Inherit + ".jar", text + instanceName + ".jar");
                    Task.Progress = 0.7;
                    ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(McFolder + "versions\\" + DownloadInfo.Inherit);
                    string text3 = "{\r\n    \"id\": \"" + instanceName + "\",\r\n    \"inheritsFrom\": \"" + DownloadInfo.Inherit + "\",\r\n    \"time\": \"" + ((Operators.CompareString(DownloadInfo.ReleaseTime, "", TextCompare: false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : DownloadInfo.ReleaseTime.Replace("/", "-")) + "T23:33:33+08:00\",\r\n    \"releaseTime\": \"" + ((Operators.CompareString(DownloadInfo.ReleaseTime, "", TextCompare: false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : DownloadInfo.ReleaseTime.Replace("/", "-")) + "T23:33:33+08:00\",\r\n    \"type\": \"release\",\r\n    \"libraries\": [\r\n        {\"name\": \"optifine:OptiFine:" + DownloadInfo.FileName.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", "") + "\"},\r\n        {\"name\": \"net.minecraft:launchwrapper:1.12\"}\r\n    ],\r\n    \"mainClass\": \"net.minecraft.launchwrapper.Launch\",";
                    Task.Progress = 0.8;
                    text3 = ((!mcInstance.IsOldJson) ? (text3 + "\r\n    \"minimumLauncherVersion\": \"21\",\r\n    \"arguments\": {\r\n        \"game\": [\r\n            \"--tweakClass\",\r\n            \"optifine.OptiFineTweaker\"\r\n        ]\r\n    }\r\n}") : (text3 + "\r\n    \"minimumLauncherVersion\": 18,\r\n    \"minecraftArguments\": \"" + mcInstance.JsonObject["minecraftArguments"].ToString() + "  --tweakClass optifine.OptiFineTweaker\"\r\n}"));
                    FileUtils.Write(text + instanceName + ".json", text3, (Encoding)null);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception innerException = ex;
                    throw new Exception("安装 OptiFine（方式 B）失败", innerException);
                }
            })
            {
                ProgressWeight = 1.0
            });
        }
        return list;
    }

    private static List<ModLoader.LoaderBase> McDownloadOptiFineSaveLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string TargetFolder)
    {
        return new List<ModLoader.LoaderBase>
        {
            new ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>>("获取 OptiFine 下载地址", (ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>> Task) =>
            {
                List<string> list = new List<string>();
                string text = DownloadInfo.Inherit;
                if (Operators.CompareString(text, "1.8", TextCompare: false) == 0 || Operators.CompareString(text, "1.9", TextCompare: false) == 0)
                {
                    text += ".0";
                }
                if (DownloadInfo.IsPreview)
                {
                    list.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U_" + DownloadInfo.DisplayName.Replace(DownloadInfo.Inherit + " ", "").Replace(" ", "/"));
                }
                else
                {
                    list.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U/" + DownloadInfo.DisplayName.Replace(DownloadInfo.Inherit + " ", ""));
                }
                try
                {
                    string text2 = ModNet.NetRequestByClientRetry("https://optifine.net/adloadx?f=" + DownloadInfo.FileName, null, null, null, null, "text/html", null, RequireJson: false, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), SimulateBrowserHeaders: true);
                    Task.Progress = 0.8;
                    list.Add("https://optifine.net/" + StringExtensions.RegexSearch(text2, "downloadx\\?f=[^\"']+", RegexOptions.None).First());
                    Logger.Info($"OptiFine {DownloadInfo.DisplayName} 官方下载地址：{list.Last()}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Warn(ex2, $"获取 OptiFine {DownloadInfo.DisplayName} 官方下载地址失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    ProjectData.ClearProjectError();
                }
                Task.Progress = 0.9;
                Task.Output = new List<ModNet.NetFile>
                {
                    new ModNet.NetFile(list.ToArray(), TargetFolder, new FileChecker
                    {
                        MinSize = 65536L
                    })
                };
            })
            {
                ProgressWeight = 6.0
            },
            new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
            {
                ProgressWeight = 10.0,
                Block = true
            }
        };
    }

    public static MyVirtualizingElement<MyListItem> OptiFineDownloadListItem(ModDownload.DlOptiFineListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem
            {
                Title = Entry.DisplayName,
                SnapsToDevicePixels = true,
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Entry,
                Info = (Entry.IsPreview ? "测试版" : "正式版") + ((Operators.CompareString(Entry.ReleaseTime, "", TextCompare: false) == 0) ? "" : ("，发布于 " + Entry.ReleaseTime)) + ((Entry.RequiredForgeVersion == null) ? "，不兼容 Forge" : ((Operators.CompareString(Entry.RequiredForgeVersion, "", TextCompare: false) == 0) ? "" : ("，兼容 Forge " + Entry.RequiredForgeVersion))),
                Logo = ModBase.PathImage + "Blocks/GrassPath.png"
            };
            myListItem.Click += OnClick;
            if (IsSaveOnly)
            {
                myListItem.ContentHandler = OptiFineSaveContMenuBuild;
            }
            else
            {
                myListItem.ContentHandler = OptiFineContMenuBuild;
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    private static void OptiFineSaveContMenuBuild(object sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        NewLateBinding.LateSet(sender, null, "Buttons", new object[1] { new MyIconButton[1] { myIconButton } }, null, null);
    }

    private static void OptiFineContMenuBuild(object sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
            ToolTip = "另存为"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            OptiFineSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        NewLateBinding.LateSet(sender, null, "Buttons", new object[1] { new MyIconButton[2] { myIconButton, myIconButton2 } }, null, null);
    }

    private static void OptiFineLog_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlOptiFineListEntry dlOptiFineListEntry;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            dlOptiFineListEntry = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            dlOptiFineListEntry = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        ModBase.OpenWebsite("https://optifine.net/changelog?f=" + dlOptiFineListEntry.FileName);
    }

    public static void OptiFineSave_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlOptiFineListEntry downloadInfo;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            downloadInfo = (ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            downloadInfo = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        McDownloadOptiFineSave(downloadInfo);
    }

    private static void McDownloadLiteLoaderSave(ModDownload.DlLiteLoaderListEntry DownloadInfo)
    {
        try
        {
            string inherit = DownloadInfo.Inherit;
            string text = Dialogs.SaveFile("选择保存位置", DownloadInfo.FileName.Replace("-SNAPSHOT", ""), (string)null, (IEnumerable<(string, string)>)new (string, string)[1] { ("jar", "LiteLoader 安装器") });
            if (text == null)
            {
                return;
            }
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"LiteLoader {inherit} 下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该版本正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
            List<string> list2 = new List<string>();
            if (DownloadInfo.IsLegacy)
            {
                switch (DownloadInfo.Inherit)
                {
                    case "1.7.10":
                        list2.Add("https://dl.liteloader.com/redist/1.7.10/liteloader-installer-1.7.10-04.jar");
                        break;
                    case "1.7.2":
                        list2.Add("https://dl.liteloader.com/redist/1.7.2/liteloader-installer-1.7.2-04.jar");
                        break;
                    case "1.6.4":
                        list2.Add("https://dl.liteloader.com/redist/1.6.4/liteloader-installer-1.6.4-01.jar");
                        break;
                    case "1.6.2":
                        list2.Add("https://dl.liteloader.com/redist/1.6.2/liteloader-installer-1.6.2-04.jar");
                        break;
                    case "1.5.2":
                        list2.Add("https://dl.liteloader.com/redist/1.5.2/liteloader-installer-1.5.2-01.jar");
                        break;
                    default:
                        throw new NotSupportedException("未知的 Minecraft 版本（" + DownloadInfo.Inherit + "）");
                }
            }
            else
            {
                list2.Add("http://jenkins.liteloader.com/job/LiteLoaderInstaller%20" + DownloadInfo.Inherit + "/lastSuccessfulBuild/artifact/" + ((Operators.CompareString(DownloadInfo.Inherit, "1.8", TextCompare: false) == 0) ? "ant/dist/" : "build/libs/") + DownloadInfo.FileName);
            }
            list.Add(new ModNet.LoaderDownload("下载主文件", new List<ModNet.NetFile>
            {
                new ModNet.NetFile(list2.ToArray(), text, new FileChecker
                {
                    MinSize = 1048576L
                })
            })
            {
                ProgressWeight = 15.0
            });
            ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry>("LiteLoader " + inherit + " 安装器下载", list);
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(DownloadInfo);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始 LiteLoader 安装器下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    private static List<ModLoader.LoaderBase> McDownloadLiteLoaderLoader(ModDownload.DlLiteLoaderListEntry DownloadInfo, string McFolder)
    {
        Operators.CompareString(McFolder, ModMinecraft.McFolderSelected, TextCompare: false);
        string inherit = DownloadInfo.Inherit;
        _ = ModBase.PathTemp + "Download\\" + inherit + "-Liteloader.jar";
        string text = DownloadInfo.Inherit + "-LiteLoader";
        string text2 = McFolder + "versions\\" + text + "\\";
        return new List<ModLoader.LoaderBase>
        {
            new ModLoader.LoaderTask<string, string>("安装 LiteLoader", (ModLoader.LoaderTask<string, string> Task) =>
            {
                try
                {
                    JObject val = new JObject();
                    val.Add("id", (JToken)(text));
                    val.Add("time", (JToken)(DateTime.ParseExact(DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)));
                    val.Add("releaseTime", (JToken)(DateTime.ParseExact(DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture)));
                    val.Add("type", (JToken)("release"));
                    val.Add("arguments", StringExtensions.DeserializeJson("{\"game\":[\"--tweakClass\",\"" + DownloadInfo.JsonToken[(object)"tweakClass"].ToString() + "\"]}"));
                    val.Add("libraries", DownloadInfo.JsonToken[(object)"libraries"]);
                    ((JContainer)val["libraries"]).Add((object)StringExtensions.DeserializeJson("{\"name\": \"com.mumfrey:liteloader:" + DownloadInfo.JsonToken[(object)"version"].ToString() + "\",\"url\": \"https://dl.liteloader.com/versions/\"}"));
                    val.Add("mainClass", (JToken)("net.minecraft.launchwrapper.Launch"));
                    val.Add("minimumLauncherVersion", (JToken)(18));
                    val.Add("inheritsFrom", (JToken)(DownloadInfo.Inherit));
                    val.Add("jar", (JToken)(DownloadInfo.Inherit));
                    FileUtils.Write(text2 + text + ".json", ((JToken)val).ToString(), (Encoding)null);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception innerException = ex;
                    throw new Exception("安装新 LiteLoader 版本失败", innerException);
                }
            })
            {
                ProgressWeight = 1.0
            }
        };
    }

    public static MyVirtualizingElement<MyListItem> LiteLoaderDownloadListItem(ModDownload.DlLiteLoaderListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem
            {
                Title = Entry.Inherit,
                SnapsToDevicePixels = true,
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Entry,
                Info = (Entry.IsPreview ? "测试版" : "稳定版") + ((Operators.CompareString(Entry.ReleaseTime, "", TextCompare: false) == 0) ? "" : ("，发布于 " + Entry.ReleaseTime)),
                Logo = ModBase.PathImage + "Blocks/Egg.png"
            };
            myListItem.Click += OnClick;
            if (IsSaveOnly)
            {
                myListItem.ContentHandler = LiteLoaderSaveContMenuBuild;
            }
            else
            {
                myListItem.ContentHandler = LiteLoaderContMenuBuild;
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    private static void LiteLoaderSaveContMenuBuild(MyListItem sender, EventArgs e)
    {
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender.Tag, null, "IsLegacy", new object[0], null, null, null)))
        {
            sender.Buttons = new MyIconButton[0];
            return;
        }
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z",
            ToolTip = "查看全部版本",
            Tag = sender
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[1] { myIconButton };
    }

    private static void LiteLoaderContMenuBuild(MyListItem sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
            ToolTip = "保存安装器",
            Tag = sender
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            LiteLoaderSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        if (Conversions.ToBoolean(NewLateBinding.LateGet(sender.Tag, null, "IsLegacy", new object[0], null, null, null)))
        {
            sender.Buttons = new MyIconButton[1] { myIconButton };
            return;
        }
        MyIconButton myIconButton2 = new MyIconButton
        {
            Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z",
            ToolTip = "查看全部版本",
            Tag = sender
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[2] { myIconButton, myIconButton2 };
    }

    private static void LiteLoaderAll_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlLiteLoaderListEntry dlLiteLoaderListEntry = ((!(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) is ModDownload.DlLiteLoaderListEntry)) ? ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
        ModBase.OpenWebsite("https://jenkins.liteloader.com/view/" + dlLiteLoaderListEntry.Inherit);
    }

    public static void LiteLoaderSave_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlLiteLoaderListEntry downloadInfo = ((!(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) is ModDownload.DlLiteLoaderListEntry)) ? ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null)));
        McDownloadLiteLoaderSave(downloadInfo);
    }

    public static void McDownloadForgelikeSave(ModDownload.DlForgelikeEntry Info)
    {
        try
        {
            string text = Dialogs.SaveFile("选择保存位置", $"{Info.LoaderName}-{Info.Inherit}-{Info.VersionName}.{Info.FileExtension}", (string)null, (IEnumerable<(string, string)>)new (string, string)[1] { (Info.FileExtension, $"{Info.LoaderName} 安装器") });
            if (text == null)
            {
                return;
            }
            string text2 = $"{Info.LoaderName} {Info.Inherit} - {Info.VersionName}";
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"{text2} 下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该版本正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            List<ModNet.NetFile> list = new List<ModNet.NetFile>();
            if (Info.IsNeoForge)
            {
                string text3 = ((ModDownload.DlNeoForgeListEntry)Info).UrlBase + "-installer.jar";
                list.Add(new ModNet.NetFile(new string[2]
                {
                    text3.Replace("maven.neoforged.net/releases", "bmclapi2.bangbang93.com/maven"),
                    text3
                }, text, new FileChecker
                {
                    MinSize = 65536L
                }));
            }
            else
            {
                ModDownload.DlForgeVersionEntry dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)Info;
                list.Add(new ModNet.NetFile(new string[2]
                {
                    $"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.FileVersion}/forge-{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.FileVersion}-{dlForgeVersionEntry.Category}.{dlForgeVersionEntry.FileExtension}",
                    $"https://files.minecraftforge.net/maven/net/minecraftforge/forge/{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.FileVersion}/forge-{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.FileVersion}-{dlForgeVersionEntry.Category}.{dlForgeVersionEntry.FileExtension}"
                }, text, new FileChecker
                {
                    MinSize = 65536L,
                    Hash = dlForgeVersionEntry.Hash
                }));
            }
            List<ModLoader.LoaderBase> list2 = new List<ModLoader.LoaderBase>();
            list2.Add(new ModNet.LoaderDownload("下载主文件", list)
            {
                ProgressWeight = 6.0
            });
            ModLoader.LoaderCombo<ModDownload.DlForgelikeEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlForgelikeEntry>(text2 + " 下载", list2);
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(Info);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, $"开始 {Info.LoaderName} 安装器下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    private static void ForgelikeInjector(string Target, ModLoader.LoaderTask<bool, bool> Task, string McFolder, bool UseJavaWrapper, bool IsNeoForge)
    {
        _Closure_0024__28_002D2 obj = new _Closure_0024__28_002D2(null);
        obj._0024VB_0024Local_Task = Task;
        Java val = ModJava.SelectOrDownloadJava((OneOf<ValueRange<Version>, ModMinecraft.McInstance>)(ValueRange<Version>.AtLeast(new Version(8, 0, 60))), TryFixOrHint: true, obj._0024VB_0024Local_Task.CreateCancellationToken(), obj._0024VB_0024Local_Task.CreateSyncProgressProvider(0.0, 0.2));
        if (obj._0024VB_0024Local_Task.IsCanceled)
        {
            return;
        }
        if (val == null)
        {
            throw new OperationCanceledException();
        }
        string text = ((!UseJavaWrapper || Settings.Get<bool>("LaunchAdvanceDisableJLW")) ? $"-cp \"{ModBase.PathTemp}Cache\\forge_installer.jar;{Target}\" com.bangbang93.ForgeInstaller \"{McFolder}" : string.Format("-Doolloo.jlw.tmpdir=\"{0}\" -cp \"{1}Cache\\forge_installer.jar;{2}\" -jar \"{3}\" com.bangbang93.ForgeInstaller \"{4}", ModBase.PathPure.Value.TrimEnd('\\'), ModBase.PathTemp, Target, LaunchUtils.ExtractPatch("Launch\\JavaWrapper.jar", ModBase.PathPure.Value), McFolder));
        if (val.Version.Major >= 9)
        {
            text = "--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED " + text;
        }
        object installSyncLock = InstallSyncLock;
        ObjectFlowControl.CheckForSyncLockOnValueType(installSyncLock);
        bool lockTaken = false;
        checked
        {
            try
            {
                Monitor.Enter(installSyncLock, ref lockTaken);
                _Closure_0024__28_002D1 obj2 = new _Closure_0024__28_002D1(null);
                obj2._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = val.JavaExePath,
                    Arguments = text,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                obj2._0024VB_0024Local_LoaderName = (IsNeoForge ? "NeoForge" : "Forge");
                Logger.Info($"开始安装 {obj2._0024VB_0024Local_LoaderName}：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                obj2._0024VB_0024Local_process = new Process
                {
                    StartInfo = startInfo
                };
                obj2._0024VB_0024Local_LastResults = new Queue<string>();
                _Closure_0024__28_002D0 obj3 = new _Closure_0024__28_002D0(null);
                obj3._0024VB_0024NonLocal__0024VB_0024Closure_3 = obj2;
                obj3._0024VB_0024Local_outputWaitHandle = new AutoResetEvent(initialState: false);
                try
                {
                    _Closure_0024__28_002D3 arg = default;
                    _Closure_0024__28_002D3 CS_0024_003C_003E8__locals21 = new _Closure_0024__28_002D3(arg);
                    CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4 = obj3;
                    CS_0024_003C_003E8__locals21._0024VB_0024Local_errorWaitHandle = new AutoResetEvent(initialState: false);
                    try
                    {
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.OutputDataReceived += (object a0, DataReceivedEventArgs a1) =>
                        {
                            CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
                        };
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.ErrorDataReceived += (object a0, DataReceivedEventArgs a1) =>
                        {
                            CS_0024_003C_003E8__locals21._Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
                        };
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Start();
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginOutputReadLine();
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginErrorReadLine();
                        while (!CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
                        {
                            Thread.Sleep(10);
                        }
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_outputWaitHandle.WaitOne(10000);
                        CS_0024_003C_003E8__locals21._0024VB_0024Local_errorWaitHandle.WaitOne(10000);
                        CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Dispose();
                        if (CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Reverse().Take(5).Any((string l) => Operators.CompareString(l, "true", TextCompare: false) == 0))
                        {
                            return;
                        }
                        Logger.Warn(EnumerableExtensions.Join((IEnumerable)CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults, "\r\n"), (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                        string text2 = "";
                        int num = Math.Max(0, CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count - 5);
                        int num2 = CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count - 1;
                        for (int num3 = num; num3 <= num2; num3++)
                        {
                            text2 = text2 + "\r\n" + CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.ElementAtOrDefault(num3);
                        }
                        throw new Exception($"{CS_0024_003C_003E8__locals21._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器出错，日志结束部分为：" + text2);
                    }
                    finally
                    {
                        if (CS_0024_003C_003E8__locals21._0024VB_0024Local_errorWaitHandle != null)
                        {
                            ((IDisposable)CS_0024_003C_003E8__locals21._0024VB_0024Local_errorWaitHandle).Dispose();
                        }
                    }
                }
                finally
                {
                    if (obj3._0024VB_0024Local_outputWaitHandle != null)
                    {
                        ((IDisposable)obj3._0024VB_0024Local_outputWaitHandle).Dispose();
                    }
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(installSyncLock);
                }
            }
        }
    }

    private static void ForgelikeInjectorLine(string Content, ModLoader.LoaderTask<bool, bool> Task)
    {
        switch (Content)
        {
            case "Extracting json":
                Task.Progress = 0.27;
                break;
            case "Downloading libraries":
                Task.Progress = 0.28;
                break;
            case "  File exists: Checksum validated.":
                Task.Progress += 0.003;
                break;
            case "Building Processors":
                Task.Progress = 0.38;
                break;
            case "Task: DOWNLOAD_MOJMAPS":
                Task.Progress = 0.4;
                break;
            case "Task: MERGE_MAPPING":
                Task.Progress = 0.5;
                break;
            case "Splitting: ":
                Task.Progress = 0.55;
                break;
            case "Parameter Annotations":
                Task.Progress = 0.6;
                break;
            case "Processing Complete":
                Task.Progress = 0.67;
                break;
            case "log: null":
                Task.Progress = 0.67;
                break;
            case "Sorting":
                Task.Progress = 0.8;
                break;
            case "Remapping final jar":
                Task.Progress = 0.85;
                break;
            case "Remapping jar... 50%":
                Task.Progress = 0.9;
                break;
            case "Remapping jar... 100%":
                Task.Progress = 0.95;
                break;
            case "Injecting profile":
                Task.Progress = 0.98;
                break;
            default:
                Logger.Trace(Content, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                return;
        }
        Logger.Info(Content, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
    }

    private static List<ModLoader.LoaderBase> McDownloadForgelikeLoader(bool IsNeoForge, string LoaderVersion, string NewInstanceName, string Inherit, ModDownload.DlForgelikeEntry Info, string McFolder, ModLoader.LoaderCombo<string> ClientDownloadLoader, string ClientFolder)
    {
        McFolder = McFolder ?? ModMinecraft.McFolderSelected;
        if (IsNeoForge && Info == null)
        {
            if (Operators.CompareString(Inherit, "1.20.1", TextCompare: false) == 0 && !StringExtensions.StartsWithF(LoaderVersion, "1.20.1-", false))
            {
                Info = new ModDownload.DlNeoForgeListEntry("1.20.1-" + LoaderVersion);
            }
            else
            {
                Info = new ModDownload.DlNeoForgeListEntry(LoaderVersion);
            }
        }
        if (!IsNeoForge && StringExtensions.StartsWithF(LoaderVersion, "1.", false) && LoaderVersion.Contains("-"))
        {
            Inherit = StringExtensions.BeforeFirst(LoaderVersion, "-", false);
            LoaderVersion = StringExtensions.AfterLast(LoaderVersion, "-", false);
        }
        string text = (IsNeoForge ? "NeoForge" : "Forge");
        bool flag = Operators.CompareString(McFolder, ModMinecraft.McFolderSelected, TextCompare: false) != 0;
        string text2 = ModMain.RequestTaskTempFolder() + "forge_installer.jar";
        string text3 = $"{McFolder}versions\\{NewInstanceName}\\";
        _ = $"{text} {Inherit} - {LoaderVersion}";
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        _ = $"{ModMinecraft.McFolderSelected}versions\\{NewInstanceName}\\";
        if (Info == null)
        {
            list.Add(new ModLoader.LoaderTask<string, string>($"获取 {text} 详细信息", (ModLoader.LoaderTask<string, string> Task) =>
            {
                ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("McDownloadForgeLoader " + Inherit, ModDownload.DlForgeVersionMain);
                loaderTask.WaitForExit(Inherit);
                Task.Progress = 0.8;
                foreach (ModDownload.DlForgeVersionEntry item in loaderTask.Output)
                {
                    if (ModMinecraft.CompareVersion(item.Version.ToString(), LoaderVersion) == 0)
                    {
                        Info = item;
                        return;
                    }
                }
                throw new Exception($"未能找到 {text} " + Inherit + "-" + LoaderVersion + " 的详细信息！");
            })
            {
                ProgressWeight = 3.0
            });
        }
        list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>($"准备下载 {text}", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            List<ModNet.NetFile> list3 = new List<ModNet.NetFile>();
            if (Info.IsNeoForge)
            {
                string text4 = ((ModDownload.DlNeoForgeListEntry)Info).UrlBase + "-installer.jar";
                list3.Add(new ModNet.NetFile(new string[2]
                {
                    text4.Replace("maven.neoforged.net/releases", "bmclapi2.bangbang93.com/maven"),
                    text4
                }, text2, new FileChecker
                {
                    MinSize = 65536L
                }));
            }
            else
            {
                ModDownload.DlForgeVersionEntry dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)Info;
                string arg = string.Format("{0}-{1}/forge-{2}-{3}-{4}.{5}", dlForgeVersionEntry.Inherit.Replace("-", "_"), dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Inherit.Replace("-", "_"), dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Category, dlForgeVersionEntry.FileExtension);
                list3.Add(new ModNet.NetFile(new string[2]
                {
                    $"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/{arg}",
                    $"https://files.minecraftforge.net/maven/net/minecraftforge/forge/{arg}"
                }, text2, new FileChecker
                {
                    MinSize = 65536L,
                    Hash = dlForgeVersionEntry.Hash
                }));
            }
            Task.Output = list3;
        })
        {
            ProgressWeight = 0.5,
            Show = false
        });
        list.Add(new ModNet.LoaderDownload($"下载 {text} 主文件", new List<ModNet.NetFile>())
        {
            ProgressWeight = 9.0
        });
        if (IsNeoForge || Conversions.ToDouble(StringExtensions.BeforeFirst(LoaderVersion, ".", false)) >= 20.0)
        {
            Logger.Info(string.Format("检测为{0}Forge：{1}", IsNeoForge ? " Neo" : "新版 ", LoaderVersion), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            List<ModMinecraft.McLibEntry> list2 = null;
            list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>($"分析 {text} 支持库文件", checked((ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
            {
                Task.Output = new List<ModNet.NetFile>();
                ZipArchive zipArchive = null;
                try
                {
                    zipArchive = FileUtils.OpenZip(text2, default(CancellationToken));
                    Task.Progress = 0.2;
                    JObject val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry("install_profile.json").Open(), (Encoding)null));
                    JObject val2 = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry("version.json").Open(), (Encoding)null));
                    ((JContainer)val).Merge((object)val2);
                    list2 = ModMinecraft.McLibListGetWithJson(val, KeepSameNameDifferentVersionResult: true);
                    if (val["data"] != null && val["data"][(object)"MOJMAPS"] != null)
                    {
                        Task.Progress = 0.4;
                        JObject val3 = (JObject)StringExtensions.DeserializeJson(ModNet.NetRequestByLoader(ModDownload.DlSourceLauncherOrMetaGet(Conversions.ToString(ModDownload.DlClientListGet(Inherit))), 45000, IsJson: true));
                        string text4 = StringExtensions.BeforeFirst(val["data"][(object)"MOJMAPS"][(object)"client"].ToString().Trim("[]".ToCharArray()), "@", false);
                        string localPath = ModMinecraft.McLibGet(text4).Replace(".jar", "." + StringExtensions.Split(val["data"][(object)"MOJMAPS"][(object)"client"].ToString().Trim("[]".ToCharArray()), "@", false)[1]);
                        JToken val4 = val3["downloads"][(object)"client_mappings"];
                        list2.Add(new ModMinecraft.McLibEntry
                        {
                            IsNatives = false,
                            LocalPath = localPath,
                            OriginalName = text4,
                            Url = (string)val4[(object)"url"],
                            Size = (long)val4[(object)"size"],
                            SHA1 = (string)val4[(object)"sha1"]
                        });
                        Logger.Info(string.Format("需要下载 Mappings：{0} (SHA1: {1})", val4[(object)"url"], val4[(object)"sha1"]), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    }
                    Task.Progress = 0.8;
                    int num = list2.Count - 1;
                    for (int i = 0; i <= num; i++)
                    {
                        if (StringExtensions.EndsWithF(list2[i].LocalPath, $"{StringExtensions.Lower(text)}-{Inherit}-{LoaderVersion}.jar", false) || StringExtensions.EndsWithF(list2[i].LocalPath, $"{StringExtensions.Lower(text)}-{Inherit}-{LoaderVersion}-client.jar", false))
                        {
                            Logger.Warn($"已从待下载 {text} 支持库中移除：{list2[i].LocalPath}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                            list2.RemoveAt(i);
                            break;
                        }
                    }
                    Task.Output = ModMinecraft.McLibNetFilesFromTokens(list2, ModMinecraft.McFolderSelected);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception innerException = ex;
                    throw new Exception(string.Format("获取{0}Forge 支持库列表失败", IsNeoForge ? " Neo" : "新版 "), innerException);
                }
                finally
                {
                    zipArchive?.Dispose();
                }
            }))
            {
                ProgressWeight = 1.0
            });
            list.Add(new ModNet.LoaderDownload($"下载 {text} 支持库文件", new List<ModNet.NetFile>())
            {
                ProgressWeight = 12.0
            });
            list.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>($"获取 {text} 支持库文件", (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
            {
                if (flag)
                {
                    foreach (ModMinecraft.McLibEntry item2 in list2)
                    {
                        string text4 = item2.LocalPath.Replace(ModMinecraft.McFolderSelected, McFolder);
                        if (!FileUtils.Exists(text4))
                        {
                            FileUtils.Copy(item2.LocalPath, text4);
                        }
                        Logger.Trace($"复制的 {text} 支持库文件：{item2.LocalPath}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    }
                }
                List<ModLoader.LoaderBase> source = (from l in ClientDownloadLoader.GetLoaderList()
                                                     where Operators.CompareString(l.Name, "下载原版支持库文件", TextCompare: false) == 0 || Operators.CompareString(l.Name, "下载原版 json 文件", TextCompare: false) == 0
                                                     where l.State != ModBase.LoadState.Finished
                                                     select l).ToList();
                if (source.Any())
                {
                    Logger.Info($"{text} 安装正在等待原版文件下载完成", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                }
                while (source.Any() && !Task.IsCanceled)
                {
                    source = source.Where((_Closure_0024__._0024I30_002D6 == null) ? (_Closure_0024__._0024I30_002D6 = (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I30_002D6).ToList();
                    Thread.Sleep(50);
                }
                if (!Task.IsCanceled && flag)
                {
                    object vanillaSyncLock = VanillaSyncLock;
                    ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
                    bool lockTaken = false;
                    try
                    {
                        Monitor.Enter(vanillaSyncLock, ref lockTaken);
                        string lastPart = PathUtils.GetLastPart(ClientFolder);
                        DirectoryUtils.Create(McFolder + "versions\\" + Inherit);
                        if (!FileUtils.Exists(McFolder + "versions\\" + Inherit + "\\" + Inherit + ".json"))
                        {
                            FileUtils.Copy(ClientFolder + lastPart + ".json", McFolder + "versions\\" + Inherit + "\\" + Inherit + ".json");
                        }
                        if (!FileUtils.Exists(McFolder + "versions\\" + Inherit + "\\" + Inherit + ".jar"))
                        {
                            FileUtils.Copy(ClientFolder + lastPart + ".jar", McFolder + "versions\\" + Inherit + "\\" + Inherit + ".jar");
                        }
                    }
                    finally
                    {
                        if (lockTaken)
                        {
                            Monitor.Exit(vanillaSyncLock);
                        }
                    }
                }
            })
            {
                ProgressWeight = 0.1,
                Show = false
            });
            list.Add(new ModLoader.LoaderTask<bool, bool>(IsNeoForge ? "安装 NeoForge" : "安装 Forge（方式 A）", (ModLoader.LoaderTask<bool, bool> Task) =>
            {
                ZipArchive zipArchive = null;
                try
                {
                    Logger.Info($"开始进行 Forgelike 安装：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    List<string> list3 = DirectoryUtils.EnumerateDirectories(McFolder + "versions\\", false, "*").ToList();
                    zipArchive = FileUtils.OpenZip(text2, default(CancellationToken));
                    _ = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry("install_profile.json").Open(), (Encoding)null));
                    DirectoryUtils.Create(text3);
                    Task.Progress = 0.04;
                    ModMinecraft.McFolderLauncherProfilesJsonCreate(McFolder);
                    Task.Progress = 0.05;
                    bool flag2 = true;
                    while (true)
                    {
                        try
                        {
                            ModBase.ExtractResources(ModBase.PathTemp + "Cache\\forge_installer.jar", "ForgeInstaller");
                            Task.Progress = 0.06;
                            ForgelikeInjector(text2, Task, McFolder, flag2, IsNeoForge);
                            Task.Progress = 0.97;
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            Exception ex2 = ex;
                            if (!flag2)
                            {
                                throw new Exception($"运行 {text} 安装器失败", ex2);
                            }
                            Logger.Warn(ex2, $"使用 JavaWrapper 安装 {text} 失败，将不使用 JavaWrapper 并重试", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                            flag2 = false;
                            ProjectData.ClearProjectError();
                            continue;
                        }
                        break;
                    }
                    List<DirectoryInfo> list4 = (from f in DirectoryUtils.EnumerateDirectories(McFolder + "versions\\", false, "*").SkipWhile((string i) => list3.Contains(i))
                                                 select DirectoryUtils.GetInfo(f)).ToList();
                    if (list4.Count > 1)
                    {
                        list4 = list4.Where((DirectoryInfo l) => StringExtensions.ContainsIgnoreCase(l.Name, "forge") && l.EnumerateFiles().Any()).ToList();
                    }
                    if (list4.Count == 1)
                    {
                        FileInfo fileInfo = list4[0].EnumerateFiles().First();
                        FileUtils.Copy(fileInfo.FullName, text3 + NewInstanceName + ".json");
                        Logger.Info($"已复制新增的版本 JSON 文件：{fileInfo.FullName} -> {text3}{NewInstanceName}.json", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    }
                    else if (list4.Count > 1)
                    {
                        Logger.Info(string.Format("有多个疑似的新增版本，无法确定：{0}", EnumerableExtensions.Join((IEnumerable)list4.Select((DirectoryInfo d) => d.Name), ";")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    }
                    else
                    {
                        Logger.Info("未找到新增的版本文件夹", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    }
                }
                catch (Exception ex3)
                {
                    ProjectData.SetProjectError(ex3);
                    Exception innerException = ex3;
                    throw new Exception($"安装新 {text} 版本失败", innerException);
                }
                finally
                {
                    try
                    {
                        zipArchive?.Dispose();
                        FileUtils.Delete(text2, false);
                    }
                    catch (Exception ex4)
                    {
                        ProjectData.SetProjectError(ex4);
                        Exception ex5 = ex4;
                        Logger.Warn(ex5, $"安装 {text} 清理文件时出错", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                        ProjectData.ClearProjectError();
                    }
                }
            })
            {
                ProgressWeight = 10.0
            });
        }
        else
        {
            Logger.Info($"检测为非新版 Forge：{LoaderVersion}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            list.Add(new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>($"安装 {text}（方式 B）", (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
            {
                ZipArchive zipArchive = null;
                try
                {
                    zipArchive = FileUtils.OpenZip(text2, default(CancellationToken));
                    Task.Progress = 0.2;
                    JObject val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry("install_profile.json").Open(), (Encoding)null));
                    Task.Progress = 0.4;
                    DirectoryUtils.Create(text3);
                    Task.Progress = 0.5;
                    if (val["install"] == null)
                    {
                        Logger.Info($"开始进行 Forge 安装，Legacy 方式 1：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                        JObject val2 = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry(val["json"].ToString().TrimStart('/')).Open(), (Encoding)null));
                        val2["id"] = (JToken)(NewInstanceName);
                        FileUtils.Write(text3 + NewInstanceName + ".json", ((JToken)val2).ToString(), (Encoding)null);
                        Task.Progress = 0.6;
                        zipArchive.Dispose();
                        FileUtils.ExtractToDirectory(text2, text2 + "_unrar\\", default(CancellationToken), (ProgressProvider)null);
                        if (DirectoryUtils.Exists(text2 + "_unrar\\maven\\"))
                        {
                            DirectoryUtils.Copy(text2 + "_unrar\\maven\\", McFolder + "libraries\\");
                        }
                        DirectoryUtils.Delete(text2 + "_unrar\\", false);
                    }
                    else
                    {
                        Logger.Info($"开始进行 Forge 安装，Legacy 方式 2：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                        FileUtils.Write(ModMinecraft.McLibGet((string)val["install"][(object)"path"], WithHead: true, IgnoreLiteLoader: false, McFolder), zipArchive.GetEntry((string)val["install"][(object)"filePath"]).Open());
                        Task.Progress = 0.9;
                        val["versionInfo"][(object)"id"] = (JToken)(NewInstanceName);
                        if (val["versionInfo"][(object)"inheritsFrom"] == null)
                        {
                            ((JObject)val["versionInfo"]).Add("inheritsFrom", (JToken)(Inherit));
                        }
                        FileUtils.Write(text3 + NewInstanceName + ".json", val["versionInfo"].ToString(), (Encoding)null);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception innerException = ex;
                    throw new Exception("非新版方式安装 Forge 失败", innerException);
                }
                finally
                {
                    try
                    {
                        zipArchive?.Dispose();
                        FileUtils.Delete(text2, false);
                        DirectoryUtils.Delete(text2 + "_unrar\\", false);
                    }
                    catch (Exception ex2)
                    {
                        ProjectData.SetProjectError(ex2);
                        Exception ex3 = ex2;
                        Logger.Warn(ex3, "非新版方式安装 Forge 清理文件时出错", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                        ProjectData.ClearProjectError();
                    }
                }
            })
            {
                ProgressWeight = 1.0
            });
        }
        return list;
    }

    public static void ForgeDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlForgeVersionEntry> Entries, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        if (EnumerableExtensions.IsSingle<ModDownload.DlForgeVersionEntry>((IEnumerable<ModDownload.DlForgeVersionEntry>)Entries))
        {
            return;
        }
        ModDownload.DlForgeVersionEntry dlForgeVersionEntry = null;
        if (Entries.Any())
        {
            dlForgeVersionEntry = Entries[0];
        }
        else
        {
            Logger.Info("未找到可用的 Forge 版本", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        ModDownload.DlForgeVersionEntry dlForgeVersionEntry2 = null;
        foreach (ModDownload.DlForgeVersionEntry Entry in Entries)
        {
            if (Entry.IsRecommended)
            {
                dlForgeVersionEntry2 = Entry;
            }
        }
        if (dlForgeVersionEntry != null && dlForgeVersionEntry == dlForgeVersionEntry2)
        {
            dlForgeVersionEntry = null;
        }
        if (dlForgeVersionEntry2 != null)
        {
            MyListItem myListItem = ForgeDownloadListItem(dlForgeVersionEntry2, OnClick, IsSaveOnly).Init();
            myListItem.Info = "推荐版" + ((Operators.CompareString(myListItem.Info, "", TextCompare: false) == 0) ? "" : ("，" + myListItem.Info));
            Stack.Children.Add(myListItem);
        }
        if (dlForgeVersionEntry != null)
        {
            MyListItem myListItem2 = ForgeDownloadListItem(dlForgeVersionEntry, OnClick, IsSaveOnly).Init();
            myListItem2.Info = "最新版" + ((Operators.CompareString(myListItem2.Info, "", TextCompare: false) == 0) ? "" : ("，" + myListItem2.Info));
            Stack.Children.Add(myListItem2);
        }
        Stack.Children.Add(new TextBlock
        {
            Text = "全部版本 (" + Conversions.ToString(Entries.Count) + ")",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
        });
    }

    public static MyVirtualizingElement<MyListItem> ForgeDownloadListItem(ModDownload.DlForgeVersionEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem
            {
                Title = Entry.VersionName,
                SnapsToDevicePixels = true,
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Entry,
                Info = EnumerableExtensions.Join((IEnumerable)new string[2]
                {
                    (Operators.CompareString(Entry.ReleaseTime, "", TextCompare: false) == 0) ? "" : ("发布于 " + Entry.ReleaseTime),
                    ModBase.ModeDebug ? ("种类：" + Entry.Category) : ""
                }.Where((string d) => Operators.CompareString(d, "", TextCompare: false) != 0), "，"),
                Logo = ModBase.PathImage + "Blocks/Anvil.png"
            };
            myListItem.Click += OnClick;
            if (IsSaveOnly)
            {
                myListItem.ContentHandler = ForgeSaveContMenuBuild;
            }
            else
            {
                myListItem.ContentHandler = ForgeContMenuBuild;
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    private static void ForgeContMenuBuild(MyListItem sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
            ToolTip = "另存为"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            ForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[2] { myIconButton, myIconButton2 };
    }

    private static void ForgeSaveContMenuBuild(MyListItem sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[1] { myIconButton };
    }

    private static void ForgeLog_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlForgeVersionEntry dlForgeVersionEntry;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            dlForgeVersionEntry = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        ModBase.OpenWebsite($"https://files.minecraftforge.net/maven/net/minecraftforge/forge/{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.VersionName}/forge-{dlForgeVersionEntry.Inherit}-{dlForgeVersionEntry.VersionName}-changelog.txt");
    }

    public static void ForgeSave_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlForgeVersionEntry info;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            info = (ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            info = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        McDownloadForgelikeSave(info);
    }

    public static void McDownloadForgeRecommendedRefresh()
    {
        if (IsForgeRecommendedRefreshed)
        {
            return;
        }
        IsForgeRecommendedRefreshed = true;
        ModBase.RunInNewThread(() =>
        {
            try
            {
                Logger.Info("刷新 Forge 推荐版本缓存开始", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                string text = ModNet.NetRequestByClientRetry("https://bmclapi2.bangbang93.com/forge/promos", null, null, null, null, "*/*", null, RequireJson: true);
                if (text.Length < 1000)
                {
                    throw new Exception("获取的结果过短（" + text + "）");
                }
                JContainer val = (JContainer)StringExtensions.DeserializeJson(text);
                List<string> list = new List<string>();
                foreach (JObject item in (IEnumerable<JToken>)val)
                {
                    JObject val2 = item;
                    if (val2["name"] != null && val2["build"] != null)
                    {
                        string text2 = (string)val2["name"];
                        if (StringExtensions.EndsWithF(text2, "-recommended", false))
                        {
                            list.Add("\"" + text2.Replace("-recommended", "\":\"" + val2["build"][(object)"version"].ToString() + "\""));
                        }
                    }
                }
                if (list.Count < 5)
                {
                    throw new Exception("获取的推荐版本数过少（" + text + "）");
                }
                string text3 = "{" + EnumerableExtensions.Join((IEnumerable)list, ",") + "}";
                FileUtils.Write(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json", text3, (Encoding)null);
                Logger.Info("刷新 Forge 推荐版本缓存成功", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "刷新 Forge 推荐版本缓存失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                ProjectData.ClearProjectError();
            }
        }, "ForgeRecommendedRefresh");
    }

    public static string McDownloadForgeRecommendedGet(string McVersion)
    {
        string result;
        try
        {
            if (McVersion == null)
            {
                result = null;
            }
            else
            {
                string text = FileUtils.TryReadAsString(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json", (Encoding)null, (Type)null);
                if (string.IsNullOrEmpty(text))
                {
                    Logger.Info("没有 Forge 推荐版本缓存文件", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    result = null;
                }
                else
                {
                    JObject val = (JObject)StringExtensions.DeserializeJson(text);
                    result = ((val != null && (McVersion ?? "").Contains(".") && val.ContainsKey(McVersion)) ? (val[McVersion] ?? (JToken)("")).ToString() : null);
                }
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, string.Format("获取 Forge 推荐版本失败（{0}）", McVersion ?? "null"), (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            result = null;
            ProjectData.ClearProjectError();
        }
        return result;
    }

    public static void NeoForgeDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlNeoForgeListEntry> Entries, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        if (EnumerableExtensions.IsSingle<ModDownload.DlNeoForgeListEntry>((IEnumerable<ModDownload.DlNeoForgeListEntry>)Entries))
        {
            return;
        }
        ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry = null;
        ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry2 = null;
        if (Entries.Any())
        {
            foreach (ModDownload.DlNeoForgeListEntry item in Entries.ToList())
            {
                if (item.IsBeta)
                {
                    if (dlNeoForgeListEntry2 == null)
                    {
                        dlNeoForgeListEntry2 = item;
                    }
                    continue;
                }
                dlNeoForgeListEntry = item;
                break;
            }
        }
        else
        {
            Logger.Warn("未找到可用的 NeoForge 版本", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        if (dlNeoForgeListEntry != null)
        {
            MyListItem myListItem = NeoForgeDownloadListItem(dlNeoForgeListEntry, OnClick, IsSaveOnly).Init();
            myListItem.Info = ((Operators.CompareString(myListItem.Info, "", TextCompare: false) == 0) ? "最新稳定版" : ("最新" + myListItem.Info));
            Stack.Children.Add(myListItem);
        }
        if (dlNeoForgeListEntry2 != null)
        {
            MyListItem myListItem2 = NeoForgeDownloadListItem(dlNeoForgeListEntry2, OnClick, IsSaveOnly).Init();
            myListItem2.Info = ((Operators.CompareString(myListItem2.Info, "", TextCompare: false) == 0) ? "最新测试版" : ("最新" + myListItem2.Info));
            Stack.Children.Add(myListItem2);
        }
        Stack.Children.Add(new TextBlock
        {
            Text = "全部版本 (" + Conversions.ToString(Entries.Count) + ")",
            HorizontalAlignment = HorizontalAlignment.Left,
            Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
        });
    }

    public static MyVirtualizingElement<MyListItem> NeoForgeDownloadListItem(ModDownload.DlNeoForgeListEntry Info, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem
            {
                Title = Info.VersionName,
                SnapsToDevicePixels = true,
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Info,
                Info = (Info.IsBeta ? "测试版" : "稳定版"),
                Logo = ModBase.PathImage + "Blocks/NeoForge.png"
            };
            myListItem.Click += OnClick;
            if (IsSaveOnly)
            {
                myListItem.ContentHandler = NeoForgeSaveContMenuBuild;
            }
            else
            {
                myListItem.ContentHandler = NeoForgeContMenuBuild;
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    private static void NeoForgeContMenuBuild(MyListItem sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
            ToolTip = "另存为"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            NeoForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        MyIconButton myIconButton2 = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton2.Click += (object a0, EventArgs a1) =>
        {
            NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[2] { myIconButton, myIconButton2 };
    }

    private static void NeoForgeSaveContMenuBuild(MyListItem sender, EventArgs e)
    {
        MyIconButton myIconButton = new MyIconButton
        {
            LogoScale = 1.05,
            Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
            ToolTip = "更新日志"
        };
        myIconButton.Click += (object a0, EventArgs a1) =>
        {
            NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
        };
        sender.Buttons = new MyIconButton[1] { myIconButton };
    }

    private static void NeoForgeLog_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            dlNeoForgeListEntry = (ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            dlNeoForgeListEntry = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        ModBase.OpenWebsite(dlNeoForgeListEntry.UrlBase + "-changelog.txt");
    }

    public static void NeoForgeSave_Click(object sender, RoutedEventArgs e)
    {
        ModDownload.DlNeoForgeListEntry info;
        if (NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) != null)
        {
            info = (ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null);
        }
        else
        {
            info = ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null) == null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)) : ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, null, "Parent", new object[0], null, null, null), null, "Tag", new object[0], null, null, null)));
        }
        McDownloadForgelikeSave(info);
    }

    public static void McDownloadFabricLoaderSave(JObject DownloadInfo)
    {
        try
        {
            string text = DownloadInfo["url"].ToString();
            string lastPart = PathUtils.GetLastPart(text);
            string lastPart2 = PathUtils.GetLastPart(DownloadInfo["version"].ToString());
            string text2 = Dialogs.SaveFile("选择保存位置", lastPart, (string)null, (IEnumerable<(string, string)>)new (string, string)[1] { ("jar", "Fabric 安装器") });
            if (text2 == null)
            {
                return;
            }
            foreach (ModLoader.LoaderBase item in ((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).ToList())
            {
                if (Operators.CompareString(item.Name, $"Fabric {lastPart2} 安装器下载", TextCompare: false) == 0)
                {
                    ModMain.Hint("该版本正在下载中！", ModMain.HintType.Red);
                    return;
                }
            }
            List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
            List<string> list2 = new List<string>();
            list2.Add(text);
            list.Add(new ModNet.LoaderDownload("下载主文件", new List<ModNet.NetFile>
            {
                new ModNet.NetFile(list2.ToArray(), text2, new FileChecker
                {
                    MinSize = 65536L
                })
            })
            {
                ProgressWeight = 15.0
            });
            ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("Fabric " + lastPart2 + " 安装器下载", list);
            loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
            loaderCombo.Start(DownloadInfo);
            ModLoader.LoaderTaskbarAdd(loaderCombo);
            ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
            ModMain.FrmMain.BtnExtraDownload.Ribble();
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始 Fabric 安装器下载失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    private static List<ModLoader.LoaderBase> McDownloadFabricLoader(string FabricVersion, string MinecraftName, string McFolder)
    {
        Operators.CompareString(McFolder, ModMinecraft.McFolderSelected, TextCompare: false);
        string text = "fabric-loader-" + FabricVersion + "-" + MinecraftName;
        string text2 = McFolder + "versions\\" + text + "\\";
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        MinecraftName = MinecraftName.Replace("∞", "infinite");
        list.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 Fabric 主文件下载地址", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
        {
            Task.Output = new List<ModNet.NetFile>
            {
                new ModNet.NetFile(new string[2]
                {
                    "https://bmclapi2.bangbang93.com/fabric-meta/v2/versions/loader/" + MinecraftName + "/" + FabricVersion + "/profile/json",
                    "https://meta.fabricmc.net/v2/versions/loader/" + MinecraftName + "/" + FabricVersion + "/profile/json"
                }, text2 + text + ".json", new FileChecker
                {
                    IsJson = true
                })
            };
        })
        {
            ProgressWeight = 0.5
        });
        list.Add(new ModNet.LoaderDownload("下载 Fabric 主文件", new List<ModNet.NetFile>())
        {
            ProgressWeight = 2.5
        });
        return list;
    }

    public static MyVirtualizingElement<MyListItem> FabricDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem();
            myListItem.Title = Entry["version"].ToString().Replace("+build", "");
            myListItem.SnapsToDevicePixels = true;
            myListItem.Height = 42.0;
            myListItem.Type = MyListItem.CheckType.Clickable;
            myListItem.Tag = Entry;
            myListItem.Info = (Entry["stable"].ToObject<bool>() ? "稳定版" : "测试版");
            myListItem.Logo = ModBase.PathImage + "Blocks/Fabric.png";
            myListItem.Click += OnClick;
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    public static MyVirtualizingElement<MyListItem> FabricApiDownloadListItem(ResourceVersion Entry, MyListItem.ClickEventHandler OnClick)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem();
            myListItem.Title = StringExtensions.BeforeFirst(StringExtensions.Split(Entry.Display, "]", false)[1].Replace("Fabric API ", "").Replace(" build ", "."), "+", false).Trim();
            myListItem.SnapsToDevicePixels = true;
            myListItem.Height = 42.0;
            myListItem.Type = MyListItem.CheckType.Clickable;
            myListItem.Tag = Entry;
            myListItem.Info = Entry.ReleaseTypeDisplay + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm");
            myListItem.Logo = ModBase.PathImage + "Blocks/Fabric.png";
            myListItem.Click += OnClick;
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    public static MyVirtualizingElement<MyListItem> OptiFabricDownloadListItem(ResourceVersion Entry, MyListItem.ClickEventHandler OnClick)
    {
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem
            {
                Title = StringExtensions.Lower(Entry.Display).Replace("optifabric-", "").Replace(".jar", "")
                    .Trim()
                    .TrimStart('v'),
                SnapsToDevicePixels = true,
                Height = 42.0,
                Type = MyListItem.CheckType.Clickable,
                Tag = Entry,
                Info = Entry.ReleaseTypeDisplay + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm"),
                Logo = ModBase.PathImage + "Blocks/OptiFabric.png"
            };
            myListItem.Click += OnClick;
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    public static void LoaderStateChangedHintOnly(ModLoader.LoaderBase Loader)
    {
        switch (Loader.State)
        {
            case ModBase.LoadState.Finished:
                ModMain.Hint(Loader.Name + "成功！", ModMain.HintType.Green);
                break;
            case ModBase.LoadState.Failed:
                ModMain.Hint(Loader.Name + "失败：" + ExceptionExtensions.GetDisplay(Loader.Error, false), ModMain.HintType.Red);
                break;
            case ModBase.LoadState.Canceled:
                ModMain.Hint(Loader.Name + "已取消！");
                break;
        }
    }

    public static void McInstallState(ModLoader.LoaderBase Loader)
    {
        switch (Loader.State)
        {
            case ModBase.LoadState.Finished:
                ModBase.WriteIni(ModMinecraft.McFolderSelected + "PCL.ini", "InstanceCache", "");
                ModMain.Hint(Loader.Name + "成功！", ModMain.HintType.Green);
                break;
            case ModBase.LoadState.Failed:
                ModMain.MyMsgBox(ExceptionExtensions.GetDisplay(Loader.Error, true), Loader.Name + "失败", "确定", "", "", IsWarn: true);
                break;
            case ModBase.LoadState.Canceled:
                ModMain.Hint(Loader.Name + "已取消！");
                break;
            case ModBase.LoadState.Loading:
                return;
        }
        McInstallFailedClearFolder(Loader);
        ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.McFolderSelected, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
    }

    public static void McInstallFailedClearFolder(object Loader)
    {
        try
        {
            Thread.Sleep(1000);
            if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Failed, TextCompare: false) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, null, "State", new object[0], null, null, null), ModBase.LoadState.Canceled, TextCompare: false))
            {
                if (DirectoryUtils.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null), "saves\\"))) || DirectoryUtils.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null), "versions\\"))))
                {
                    Logger.Warn(string.Format("由于版本已被独立启动，不清理版本文件夹：{0}", RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null))), (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                    return;
                }
                Logger.Warn(string.Format("由于下载失败或取消，清理版本文件夹：{0}", RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null))), (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
                DirectoryUtils.Delete(Conversions.ToString(NewLateBinding.LateGet(Loader, null, "Input", new object[0], null, null, null)), false);
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Warn(ex2, "下载失败或取消后清理版本文件夹失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            ProjectData.ClearProjectError();
        }
    }

    public static bool McInstall(McInstallRequest Request)
    {
        bool result;
        try
        {
            List<ModLoader.LoaderBase> list = McInstallLoader(Request);
            if (list == null)
            {
                result = false;
            }
            else
            {
                ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(Request.NewInstanceName + " 安装", list);
                loaderCombo.OnStateChanged = McInstallState;
                loaderCombo.Start(Request.VersionFolder);
                ModLoader.LoaderTaskbarAdd(loaderCombo);
                ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
                ModMain.FrmMain.BtnExtraDownload.Ribble();
                result = true;
            }
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception ex2 = ex;
            Logger.Error(ex2, "开始合并安装失败", (LogBehavior)4, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            result = false;
            ProjectData.ClearProjectError();
        }
        return result;
    }

    public static List<ModLoader.LoaderBase> McInstallLoader(McInstallRequest Request)
    {
        string text = ModMain.RequestTaskTempFolder(Request.OptiFineEntry != null || Request.ForgeEntry != null || Request.NeoForgeEntry != null);
        string text2 = ModMinecraft.McFolderSelected + "versions\\" + Request.NewInstanceName + "\\";
        if (DirectoryUtils.Exists(text))
        {
            DirectoryUtils.Delete(text, false);
        }
        string text3 = null;
        if (Request.OptiFineVersion != null)
        {
            if (Request.OptiFineVersion.Contains("_HD_U_"))
            {
                Request.OptiFineVersion = "HD_U_" + StringExtensions.AfterLast(Request.OptiFineVersion, "_HD_U_", false);
            }
            Request.OptiFineEntry = new ModDownload.DlOptiFineListEntry
            {
                DisplayName = Request.MinecraftName + " " + Request.OptiFineVersion.Replace("HD_U_", "").Replace("_", "").Replace("pre", " pre"),
                Inherit = Request.MinecraftName,
                IsPreview = StringExtensions.ContainsIgnoreCase(Request.OptiFineVersion, "pre"),
                InstanceName = Request.MinecraftName + "-OptiFine_" + Request.OptiFineVersion,
                FileName = (StringExtensions.ContainsIgnoreCase(Request.OptiFineVersion, "pre") ? "preview_" : "") + "OptiFine_" + Request.MinecraftName + "_" + Request.OptiFineVersion + ".jar"
            };
        }
        if (Request.OptiFineEntry != null)
        {
            text3 = text + "versions\\" + Request.OptiFineEntry.InstanceName;
        }
        string text4 = null;
        if (Request.ForgeEntry != null)
        {
            Request.ForgeVersion = Request.ForgeVersion ?? Request.ForgeEntry.VersionName;
        }
        if (Request.ForgeVersion != null)
        {
            text4 = text + "versions\\forge-" + Request.ForgeVersion;
        }
        string text5 = null;
        if (Request.NeoForgeEntry != null)
        {
            Request.NeoForgeVersion = Request.NeoForgeVersion ?? Request.NeoForgeEntry.VersionName;
        }
        if (Request.NeoForgeVersion != null)
        {
            text5 = text + "versions\\neoforge-" + Request.NeoForgeVersion;
        }
        string text6 = null;
        if (Request.FabricVersion != null)
        {
            text6 = text + "versions\\fabric-loader-" + Request.FabricVersion + "-" + Request.MinecraftName;
        }
        string text7 = null;
        if (Request.LiteLoaderEntry != null)
        {
            text7 = text + "versions\\" + Request.MinecraftName + "-LiteLoader";
        }
        bool flag = Request.FabricVersion != null || Request.ForgeEntry != null || Request.NeoForgeEntry != null || Request.LiteLoaderEntry != null;
        string text8 = text + "mods\\";
        bool flag2 = Request.OptiFineEntry != null && flag;
        if (flag2)
        {
            Logger.Info("OptiFine 将作为 Mod 进行下载", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            if (Request.LiteLoaderEntry != null)
            {
                text3 = text8 + Request.MinecraftName + "\\";
            }
            else
            {
                text3 = text8;
            }
        }
        if (text3 != null)
        {
            Logger.Info($"OptiFine 缓存：{text3}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        if (text4 != null)
        {
            Logger.Info($"Forge 缓存：{text4}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        if (text5 != null)
        {
            Logger.Info($"NeoForge 缓存：{text5}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        if (text6 != null)
        {
            Logger.Info($"Fabric 缓存：{text6}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        if (text7 != null)
        {
            Logger.Info($"LiteLoader 缓存：{text7}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
        Logger.Info($"对应的原版版本：{Request.MinecraftName}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        if (FileUtils.Exists($"{text2}{Request.NewInstanceName}.json"))
        {
            ModMain.Hint("版本 " + Request.NewInstanceName + " 已经存在！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<int, int>("添加忽略标识", (Action<ModLoader.LoaderTask<int, int>>)((ModLoader.LoaderTask<int, int> a0) =>
        {
            FileUtils.Write(text2 + ".pclignore", "用于临时地在 PCL 的版本列表中屏蔽此版本。", (Encoding)null);
        }), (Func<int>)null, ThreadPriority.Normal)
        {
            Show = false,
            Block = false
        });
        if (Request.FabricApi != null)
        {
            list.Add(new ModNet.LoaderDownload("下载 Fabric API", new List<ModNet.NetFile> { Request.FabricApi.ToNetFile(text8, ResourceVersion.DownloadReason.Dependency, Request.MinecraftName, (ModLoaders)4) })
            {
                ProgressWeight = 3.0,
                Block = false
            });
        }
        if (Request.OptiFabric != null)
        {
            list.Add(new ModNet.LoaderDownload("下载 OptiFabric", new List<ModNet.NetFile> { Request.OptiFabric.ToNetFile(text8, ResourceVersion.DownloadReason.Dependency, Request.MinecraftName, (ModLoaders)4) })
            {
                ProgressWeight = 3.0,
                Block = false
            });
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("下载原版 " + Request.MinecraftName, McDownloadClientLoader(Request.MinecraftName, Request.MinecraftJson, Request.NewInstanceName))
        {
            Show = false,
            ProgressWeight = 39.0,
            Block = (Request.ForgeVersion == null && Request.NeoForgeVersion == null && Request.OptiFineEntry == null && Request.FabricVersion == null && Request.LiteLoaderEntry == null)
        };
        list.Add(loaderCombo);
        if (Request.OptiFineEntry != null)
        {
            if (flag2)
            {
                list.Add(new ModLoader.LoaderCombo<string>("下载 OptiFine " + Request.OptiFineEntry.DisplayName, McDownloadOptiFineSaveLoader(Request.OptiFineEntry, text3 + Request.OptiFineEntry.FileName))
                {
                    Show = false,
                    ProgressWeight = 16.0,
                    Block = (Request.ForgeVersion == null && Request.NeoForgeVersion == null && Request.FabricVersion == null && Request.LiteLoaderEntry == null)
                });
            }
            else
            {
                list.Add(new ModLoader.LoaderCombo<string>("下载 OptiFine " + Request.OptiFineEntry.DisplayName, McDownloadOptiFineLoader(Request.OptiFineEntry, text, loaderCombo, Request.VersionFolder))
                {
                    Show = false,
                    ProgressWeight = 24.0,
                    Block = (Request.ForgeVersion == null && Request.NeoForgeVersion == null && Request.FabricVersion == null && Request.LiteLoaderEntry == null)
                });
            }
        }
        if (Request.ForgeVersion != null)
        {
            list.Add(new ModLoader.LoaderCombo<string>("下载 Forge " + Request.ForgeVersion, McDownloadForgelikeLoader(IsNeoForge: false, Request.ForgeVersion, "forge-" + Request.ForgeVersion, Request.MinecraftName, Request.ForgeEntry, text, loaderCombo, Request.VersionFolder))
            {
                Show = false,
                ProgressWeight = 25.0,
                Block = (Request.FabricVersion == null && Request.LiteLoaderEntry == null && Request.NeoForgeEntry == null)
            });
        }
        if (Request.NeoForgeVersion != null)
        {
            list.Add(new ModLoader.LoaderCombo<string>("下载 NeoForge " + Request.NeoForgeVersion, McDownloadForgelikeLoader(IsNeoForge: true, Request.NeoForgeVersion, "neoforge-" + Request.NeoForgeVersion, Request.MinecraftName, Request.NeoForgeEntry, text, loaderCombo, Request.VersionFolder))
            {
                Show = false,
                ProgressWeight = 25.0,
                Block = (Request.ForgeEntry == null && Request.FabricVersion == null && Request.LiteLoaderEntry == null)
            });
        }
        if (Request.LiteLoaderEntry != null)
        {
            list.Add(new ModLoader.LoaderCombo<string>("下载 LiteLoader " + Request.MinecraftName, McDownloadLiteLoaderLoader(Request.LiteLoaderEntry, text))
            {
                Show = false,
                ProgressWeight = 1.0,
                Block = (Request.FabricVersion == null)
            });
        }
        if (Request.FabricVersion != null)
        {
            list.Add(new ModLoader.LoaderCombo<string>("下载 Fabric " + Request.FabricVersion, McDownloadFabricLoader(Request.FabricVersion, Request.MinecraftName, text))
            {
                Show = false,
                ProgressWeight = 2.0,
                Block = true
            });
        }
        list.Add(new ModLoader.LoaderTask<string, string>("安装游戏", (ModLoader.LoaderTask<string, string> Task) =>
        {
            MergeJson(text2, text2, text3, flag2, text4, Request.ForgeVersion, text5, Request.NeoForgeVersion, text6, text7);
            Task.Progress = 0.2;
            DirectoryUtils.Copy(text + "libraries", ModMinecraft.McFolderSelected + "libraries");
            Task.Progress = 0.8;
            string text9 = new ModMinecraft.McInstance(text2).PathIndie + "mods\\";
            if (DirectoryUtils.Exists(text8))
            {
                DirectoryUtils.Copy(text8, text9);
            }
            else if (flag)
            {
                DirectoryUtils.Create(text9);
                Logger.Info($"自动创建 Mod 文件夹：{text9}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
            }
            string text10 = new ModMinecraft.McInstance(text2).PathIndie + "resourcepacks\\";
            DirectoryUtils.Create(text10);
            Logger.Info($"自动创建资源包文件夹：{text10}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        })
        {
            ProgressWeight = 2.0,
            Block = true
        });
        if (Request.OptiFineEntry != null || (Request.ForgeVersion != null && Conversions.ToDouble(StringExtensions.BeforeFirst(Request.ForgeVersion, ".", false)) >= 20.0) || Request.NeoForgeVersion != null || Request.FabricVersion != null || Request.LiteLoaderEntry != null)
        {
            List<ModLoader.LoaderBase> list2 = new List<ModLoader.LoaderBase>();
            list2.Add(new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
            {
                Task.Output = ModMinecraft.McLibNetFilesFromInstance(new ModMinecraft.McInstance(text2));
            })
            {
                ProgressWeight = 1.0,
                Show = false
            });
            list2.Add(new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
            {
                ProgressWeight = 7.0,
                Show = false
            });
            list.Add(new ModLoader.LoaderCombo<string>("下载游戏支持库文件", list2)
            {
                ProgressWeight = 8.0
            });
        }
        list.Add(new ModLoader.LoaderTask<int, int>("删除忽略标识", (Action<ModLoader.LoaderTask<int, int>>)((ModLoader.LoaderTask<int, int> a0) =>
        {
            FileUtils.Delete(text2 + ".pclignore", false);
        }), (Func<int>)null, ThreadPriority.Normal)
        {
            Show = false
        });
        return list;
    }

    private static void MergeJson(string OutputFolder, string MinecraftFolder, string OptiFineFolder = null, bool OptiFineAsMod = false, string ForgeFolder = null, string ForgeVersion = null, string NeoForgeFolder = null, string NeoForgeVersion = null, string FabricFolder = null, string LiteLoaderFolder = null)
    {
        Logger.Info($"开始进行版本合并，输出：{OutputFolder}，Minecraft：{MinecraftFolder}" + ((OptiFineFolder != null) ? ("，OptiFine：" + OptiFineFolder) : "") + ((ForgeFolder != null) ? ("，Forge：" + ForgeFolder) : "") + ((NeoForgeFolder != null) ? ("，NeoForge：" + NeoForgeFolder) : "") + ((LiteLoaderFolder != null) ? ("，LiteLoader：" + LiteLoaderFolder) : "") + ((FabricFolder != null) ? ("，Fabric：" + FabricFolder) : ""), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        DirectoryUtils.Create(OutputFolder);
        bool flag = OptiFineFolder != null && !OptiFineAsMod;
        bool flag2 = ForgeFolder != null;
        bool flag3 = NeoForgeFolder != null;
        bool flag4 = LiteLoaderFolder != null;
        bool flag5 = FabricFolder != null;
        string text = null;
        string text2 = null;
        string text3 = null;
        string text4 = null;
        string text5 = null;
        if (!StringExtensions.EndsWithF(OutputFolder, "\\", false))
        {
            OutputFolder += "\\";
        }
        string lastPart = PathUtils.GetLastPart(OutputFolder);
        string text6 = OutputFolder + lastPart + ".json";
        string text7 = OutputFolder + lastPart + ".jar";
        if (!StringExtensions.EndsWithF(MinecraftFolder, "\\", false))
        {
            MinecraftFolder += "\\";
        }
        string lastPart2 = PathUtils.GetLastPart(MinecraftFolder);
        string text8 = MinecraftFolder + lastPart2 + ".json";
        string text9 = MinecraftFolder + lastPart2 + ".jar";
        if (flag)
        {
            if (!StringExtensions.EndsWithF(OptiFineFolder, "\\", false))
            {
                OptiFineFolder += "\\";
            }
            string lastPart3 = PathUtils.GetLastPart(OptiFineFolder);
            text = OptiFineFolder + lastPart3 + ".json";
        }
        if (flag2)
        {
            if (!StringExtensions.EndsWithF(ForgeFolder, "\\", false))
            {
                ForgeFolder += "\\";
            }
            string lastPart4 = PathUtils.GetLastPart(ForgeFolder);
            text2 = ForgeFolder + lastPart4 + ".json";
        }
        if (flag3)
        {
            if (!StringExtensions.EndsWithF(NeoForgeFolder, "\\", false))
            {
                NeoForgeFolder += "\\";
            }
            string lastPart5 = PathUtils.GetLastPart(NeoForgeFolder);
            text3 = NeoForgeFolder + lastPart5 + ".json";
        }
        if (flag4)
        {
            if (!StringExtensions.EndsWithF(LiteLoaderFolder, "\\", false))
            {
                LiteLoaderFolder += "\\";
            }
            string lastPart6 = PathUtils.GetLastPart(LiteLoaderFolder);
            text4 = LiteLoaderFolder + lastPart6 + ".json";
        }
        if (flag5)
        {
            if (!StringExtensions.EndsWithF(FabricFolder, "\\", false))
            {
                FabricFolder += "\\";
            }
            string lastPart7 = PathUtils.GetLastPart(FabricFolder);
            text5 = FabricFolder + lastPart7 + ".json";
        }
        JObject val = null;
        JObject val2 = null;
        JObject val3 = null;
        JObject val4 = null;
        JObject val5 = null;
        string text10 = FileUtils.TryReadAsString(text8, (Encoding)null, (Type)null) ?? "";
        if (!StringExtensions.StartsWithF(text10, "{", false))
        {
            throw new Exception("Minecraft json 有误，地址：" + text8 + "，前段内容：" + text10.Substring(0, Math.Min(text10.Length, 1000)));
        }
        JObject val6 = (JObject)StringExtensions.DeserializeJson(text10);
        if (flag)
        {
            string text11 = FileUtils.TryReadAsString(text, (Encoding)null, (Type)null) ?? "";
            if (!StringExtensions.StartsWithF(text11, "{", false))
            {
                throw new Exception("OptiFine json 有误，地址：" + text + "，前段内容：" + text11.Substring(0, Math.Min(text11.Length, 1000)));
            }
            val = (JObject)StringExtensions.DeserializeJson(text11);
        }
        if (flag2)
        {
            string text12 = FileUtils.TryReadAsString(text2, (Encoding)null, (Type)null) ?? "";
            if (!StringExtensions.StartsWithF(text12, "{", false))
            {
                throw new Exception("Forge json 有误，地址：" + text2 + "，前段内容：" + text12.Substring(0, Math.Min(text12.Length, 1000)));
            }
            val2 = (JObject)StringExtensions.DeserializeJson(text12);
        }
        if (flag3)
        {
            string text13 = FileUtils.TryReadAsString(text3, (Encoding)null, (Type)null) ?? "";
            if (!StringExtensions.StartsWithF(text13, "{", false))
            {
                throw new Exception("NeoForge json 有误，地址：" + text3 + "，前段内容：" + text13.Substring(0, Math.Min(text13.Length, 1000)));
            }
            val3 = (JObject)StringExtensions.DeserializeJson(text13);
        }
        if (flag4)
        {
            string text14 = FileUtils.TryReadAsString(text4, (Encoding)null, (Type)null) ?? "";
            if (!StringExtensions.StartsWithF(text14, "{", false))
            {
                throw new Exception("LiteLoader json 有误，地址：" + text4 + "，前段内容：" + text14.Substring(0, Math.Min(text14.Length, 1000)));
            }
            val4 = (JObject)StringExtensions.DeserializeJson(text14);
        }
        if (flag5)
        {
            string text15 = FileUtils.TryReadAsString(text5, (Encoding)null, (Type)null) ?? "";
            if (!StringExtensions.StartsWithF(text15, "{", false))
            {
                throw new Exception("Fabric json 有误，地址：" + text5 + "，前段内容：" + text15.Substring(0, Math.Min(text15.Length, 1000)));
            }
            val5 = (JObject)StringExtensions.DeserializeJson(text15);
        }
        List<string> list = (from l in StringExtensions.Split((val6["minecraftArguments"] ?? (JToken)(" ")).ToString() + " " + ((val != null) ? (val["minecraftArguments"] ?? (JToken)(" ")).ToString() : " ") + " " + ((val2 != null) ? (val2["minecraftArguments"] ?? (JToken)(" ")).ToString() : " ") + " " + ((val3 != null) ? (val3["minecraftArguments"] ?? (JToken)(" ")).ToString() : " ") + " " + ((val4 != null) ? (val4["minecraftArguments"] ?? (JToken)(" ")).ToString() : " "), " ", true)
                             select l.Trim()).ToList();
        List<string> list2 = new List<string>();
        checked
        {
            int num = list.Count - 1;
            for (int num2 = 0; num2 <= num; num2++)
            {
                if (StringExtensions.StartsWithF(list[num2], "-", false))
                {
                    list2.Add(list[num2]);
                }
                else if (list2.Any() && StringExtensions.StartsWithF(list2.Last(), "-", false) && !list2.Last().Contains(" "))
                {
                    list2[list2.Count - 1] = list2.Last() + " " + list[num2];
                }
                else
                {
                    list2.Add(list[num2]);
                }
            }
            string text16 = EnumerableExtensions.Join((IEnumerable)list2.Distinct(), " ");
            JObject val7 = val6;
            if (flag)
            {
                val.Remove("releaseTime");
                val.Remove("time");
                ((JContainer)val7).Merge((object)val);
            }
            if (flag2)
            {
                val2.Remove("releaseTime");
                val2.Remove("time");
                ((JContainer)val7).Merge((object)val2);
            }
            if (flag3)
            {
                val3.Remove("releaseTime");
                val3.Remove("time");
                ((JContainer)val7).Merge((object)val3);
            }
            if (flag4)
            {
                val4.Remove("releaseTime");
                val4.Remove("time");
                ((JContainer)val7).Merge((object)val4);
            }
            if (flag5)
            {
                val5.Remove("releaseTime");
                val5.Remove("time");
                ((JContainer)val7).Merge((object)val5);
            }
            if (text16 != null && Operators.CompareString(text16.Replace(" ", ""), "", TextCompare: false) != 0)
            {
                val7["minecraftArguments"] = (JToken)(text16);
            }
            val7.Remove("_comment_");
            val7.Remove("inheritsFrom");
            val7.Remove("jar");
            val7["id"] = (JToken)(lastPart);
            FileUtils.Write(text6, ((JToken)val7).ToString(), (Encoding)null);
            FileUtils.Copy(text9, text7);
            Logger.Info($"版本合并 {lastPart} 完成", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\ModDownloadLib.vb");
        }
    }
}

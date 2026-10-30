using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[StandardModule]
public sealed class LocalResourceLoaders
{
    [CompilerGenerated]
    internal sealed class _Closure_0024__2_002D0
    {
        public LocalResourceFile _0024VB_0024Local_ModEntry;

        public _Closure_0024__2_002D0(_Closure_0024__2_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_ModEntry = arg0._0024VB_0024Local_ModEntry;
            }
        }

        internal bool _Lambda_0024__4(LocalResourceFile m)
        {
            return Operators.CompareString(m.EnabledName, _0024VB_0024Local_ModEntry.EnabledName, TextCompare: false) == 0;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D0
    {
        public List<LocalResourceFile> _0024VB_0024Local_Mods;

        public ModLoader.LoaderTask<(List<LocalResourceFile> ModList, JObject Cache, ModMinecraft.McVersion Target), int> _0024VB_0024Local_Loader;

        public Thread _0024VB_0024Local_CurrentTaskThread;

        public string _0024VB_0024Local_VanillaVersion;

        public bool _0024VB_0024Local_IsFailed;

        public int _0024VB_0024Local_EndedThreadCount;

        public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Mods = arg0._0024VB_0024Local_Mods;
                _0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
                _0024VB_0024Local_CurrentTaskThread = arg0._0024VB_0024Local_CurrentTaskThread;
                _0024VB_0024Local_VanillaVersion = arg0._0024VB_0024Local_VanillaVersion;
                _0024VB_0024Local_IsFailed = arg0._0024VB_0024Local_IsFailed;
                _0024VB_0024Local_EndedThreadCount = arg0._0024VB_0024Local_EndedThreadCount;
            }
        }

        internal void _Lambda_0024__2()
        {
            checked
            {
                try
                {
                    List<string> list = _0024VB_0024Local_Mods.Select((LocalResourceFile m) => m.ModrinthHash).ToList();
                    JObject val = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", EnumerableExtensions.Join((IEnumerable)list, "\",\"")), "application/json");
                    Logger.Info($"从 Modrinth 获取到 {((JContainer)val).Count} 个本地 Mod 的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (((JContainer)val).Count == 0)
                    {
                        return;
                    }
                    Dictionary<string, List<LocalResourceFile>> dictionary = new Dictionary<string, List<LocalResourceFile>>();
                    Dictionary<LocalResourceFile, List<string>> dictionary2 = new Dictionary<LocalResourceFile, List<string>>();
                    foreach (LocalResourceFile item in _0024VB_0024Local_Mods)
                    {
                        if (val.ContainsKey(item.ModrinthHash) && !((string)val[item.ModrinthHash][(object)"files"][(object)0][(object)"hashes"][(object)"sha1"] != item.ModrinthHash))
                        {
                            string key = val[item.ModrinthHash][(object)"project_id"].ToString();
                            if (ResourceProject.Cache.ContainsKey(key) && (object)item.Project == null)
                            {
                                item.Project = ResourceProject.Cache[key];
                            }
                            if (!dictionary.ContainsKey(key))
                            {
                                dictionary[key] = new List<LocalResourceFile>();
                            }
                            dictionary[key].Add(item);
                            ResourceVersion resourceVersion = ResourceVersion.FromPlatformJson((JObject)val[item.ModrinthHash], (ResourceTypes)1);
                            dictionary2[item] = (from l in ((IEnumerable<JToken>)val[item.ModrinthHash][(object)"loaders"]).Select((JToken l) => StringExtensions.Lower(l.ToString())).Distinct()
                                                 orderby l
                                                 select l).ToList();
                            if (item.ProjectVersion == null || DateTime.Compare(item.ProjectVersion.ReleaseDate, resourceVersion.ReleaseDate) < 0)
                            {
                                item.ProjectVersion = resourceVersion;
                            }
                            else
                            {
                                item.ProjectVersion.Version = resourceVersion.Version;
                            }
                        }
                    }
                    if (_0024VB_0024Local_Loader.IsCanceledWithThread(_0024VB_0024Local_CurrentTaskThread))
                    {
                        return;
                    }
                    Logger.Info($"需要从 Modrinth 获取 {dictionary.Count} 个本地 Mod 的工程信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (!dictionary.Any())
                    {
                        return;
                    }
                    JArray val2 = (JArray)ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", EnumerableExtensions.Join((IEnumerable)dictionary.Keys, "\",\"")));
                    foreach (JToken item2 in val2)
                    {
                        ResourceProject resourceProject = new ResourceProject((JObject)item2);
                        foreach (LocalResourceFile item3 in dictionary[resourceProject.Id])
                        {
                            item3.Project = resourceProject;
                        }
                    }
                    Logger.Info("已从 Modrinth 获取本地 Mod 信息，继续获取更新信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    List<LocalResourceFile> source = dictionary.SelectMany((KeyValuePair<string, List<LocalResourceFile>> l) => l.Value).ToList();
                    if (!source.Any())
                    {
                        return;
                    }
                    string arg = EnumerableExtensions.Join((IEnumerable)source.Select((LocalResourceFile m) => string.Format("{{\"hash\": \"{0}\", \"loaders\": [\"{1}\"], \"game_versions\": [\"{2}\"]}}", m.ModrinthHash, EnumerableExtensions.Join((IEnumerable)dictionary2[m], "\",\""), _0024VB_0024Local_VanillaVersion)), ",");
                    JObject val3 = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files/update_individual", HttpMethod.Post, $"{{\"algorithm\": \"sha1\", \"hashes\": [{arg}]}}", "application/json");
                    using (List<LocalResourceFile>.Enumerator enumerator4 = _0024VB_0024Local_Mods.GetEnumerator())
                    {
                        _Closure_0024__4_002D2 obj = default;
                        _Closure_0024__4_002D3 obj2 = default;
                        while (enumerator4.MoveNext())
                        {
                            obj = new _Closure_0024__4_002D2(obj);
                            obj._0024VB_0024Local_Entry = enumerator4.Current;
                            obj2 = new _Closure_0024__4_002D3(obj2);
                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3 = obj;
                            if (!val3.ContainsKey(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash) || obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion == null)
                            {
                                continue;
                            }
                            obj2._0024VB_0024Local_UpdateFile = ResourceVersion.FromPlatformJson((JObject)val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash], (ResourceTypes)1);
                            if (!obj2._0024VB_0024Local_UpdateFile.DownloadAvailable || !(from l in ((IEnumerable<JToken>)val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"loaders"]).Select((JToken l) => StringExtensions.Lower(l.ToString())).Distinct()
                                                                                          orderby l
                                                                                          select l).ToList().SequenceEqual(dictionary2[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry]))
                            {
                                continue;
                            }
                            Logger.Trace((Func<string>)obj2._Lambda_0024__10, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                            if (DateTime.Compare(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion.ReleaseDate, obj2._0024VB_0024Local_UpdateFile.ReleaseDate) < 0 && Operators.CompareString(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion.Hash, obj2._0024VB_0024Local_UpdateFile.Hash, TextCompare: false) != 0)
                            {
                                if (obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile != null && Operators.CompareString(obj2._0024VB_0024Local_UpdateFile.Hash, obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.Hash, TextCompare: false) == 0)
                                {
                                    obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ChangelogUrls.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"project_id"], _0024VB_0024Local_VanillaVersion));
                                    obj2._0024VB_0024Local_UpdateFile.DownloadUrls.AddRange(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.DownloadUrls);
                                    obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile = obj2._0024VB_0024Local_UpdateFile;
                                }
                                else if (obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile == null || DateTime.Compare(obj2._0024VB_0024Local_UpdateFile.ReleaseDate, obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.ReleaseDate) >= 0)
                                {
                                    obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ChangelogUrls = new List<string> { string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"project_id"], _0024VB_0024Local_VanillaVersion) };
                                    obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile = obj2._0024VB_0024Local_UpdateFile;
                                }
                            }
                        }
                    }
                    Logger.Info("从 Modrinth 获取本地 Mod 信息结束", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Warn(ex2, "从 Modrinth 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    _0024VB_0024Local_IsFailed = true;
                    ProjectData.ClearProjectError();
                }
                finally
                {
                    _0024VB_0024Local_EndedThreadCount++;
                }
            }
        }

        internal void _Lambda_0024__11()
        {
            try
            {
                _Closure_0024__4_002D4 obj = new _Closure_0024__4_002D4(null);
                obj._0024VB_0024NonLocal__0024VB_0024Closure_4 = this;
                List<uint> list = new List<uint>();
                foreach (LocalResourceFile item in _0024VB_0024Local_Mods)
                {
                    list.Add(item.CurseForgeHash);
                    if (_0024VB_0024Local_Loader.IsCanceledWithThread(_0024VB_0024Local_CurrentTaskThread))
                    {
                        return;
                    }
                }
                JContainer val = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)list, ",")), "application/json")[(object)"data"][(object)"exactMatches"];
                Logger.Info($"从 CurseForge 获取到 {val.Count} 个本地 Mod 的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                if (!((IEnumerable<JToken>)val).Any())
                {
                    return;
                }
                Dictionary<int, List<LocalResourceFile>> dictionary = new Dictionary<int, List<LocalResourceFile>>();
                obj._0024VB_0024Local_CurseForgeLoaders = new Dictionary<LocalResourceFile, ModLoaders>();
                foreach (JToken item2 in (IEnumerable<JToken>)val)
                {
                    string text = item2[(object)"id"].ToString();
                    uint num = (uint)item2[(object)"file"][(object)"fileFingerprint"];
                    foreach (LocalResourceFile item3 in _0024VB_0024Local_Mods)
                    {
                        if (item3.CurseForgeHash == num)
                        {
                            if (ResourceProject.Cache.ContainsKey(text) && (object)item3.Project == null)
                            {
                                item3.Project = ResourceProject.Cache[text];
                            }
                            EnumerableExtensions.AddIntoValueCollection<int, LocalResourceFile>((IDictionary<int, List<LocalResourceFile>>)dictionary, Conversions.ToInteger(text), item3);
                            ResourceVersion resourceVersion = ResourceVersion.FromPlatformJson((JObject)item2[(object)"file"], (ResourceTypes)1);
                            obj._0024VB_0024Local_CurseForgeLoaders[item3] = resourceVersion.ModLoaders;
                            if (item3.ProjectVersion == null || DateTime.Compare(item3.ProjectVersion.ReleaseDate, resourceVersion.ReleaseDate) < 0)
                            {
                                item3.ProjectVersion = resourceVersion;
                            }
                        }
                    }
                }
                if (_0024VB_0024Local_Loader.IsCanceledWithThread(_0024VB_0024Local_CurrentTaskThread))
                {
                    return;
                }
                Logger.Info($"需要从 CurseForge 获取 {dictionary.Count} 个本地 Mod 的工程信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                if (!dictionary.Any())
                {
                    return;
                }
                JToken val2 = ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", HttpMethod.Post, string.Format("{{\"modIds\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)dictionary.Keys, ",")), "application/json")[(object)"data"];
                Dictionary<int, List<LocalResourceFile>> dictionary2 = new Dictionary<int, List<LocalResourceFile>>();
                Dictionary<int, string> dictionary3 = new Dictionary<int, string>();
                _Closure_0024__4_002D5 obj2 = default;
                foreach (JToken item4 in (IEnumerable<JToken>)val2)
                {
                    if (item4[(object)"isAvailable"] != null && !item4[(object)"isAvailable"].ToObject<bool>())
                    {
                        continue;
                    }
                    ResourceProject resourceProject = new ResourceProject((JObject)item4);
                    using List<LocalResourceFile>.Enumerator enumerator5 = dictionary[Conversions.ToInteger(resourceProject.Id)].GetEnumerator();
                    while (enumerator5.MoveNext())
                    {
                        obj2 = new _Closure_0024__4_002D5(obj2);
                        obj2._0024VB_0024NonLocal__0024VB_0024Closure_5 = obj;
                        obj2._0024VB_0024Local_LocalFile = enumerator5.Current;
                        ResourceProject project = obj2._0024VB_0024Local_LocalFile.Project;
                        if ((object)project != null && (int)project.Platform == 2)
                        {
                            obj2._0024VB_0024Local_LocalFile.Project = obj2._0024VB_0024Local_LocalFile.Project;
                        }
                        else
                        {
                            obj2._0024VB_0024Local_LocalFile.Project = resourceProject;
                        }
                        List<JToken> list2 = EnumerableExtensions.MaxByAll<JToken, string>(((IEnumerable<JToken>)item4[(object)"latestFilesIndexes"]).Where(obj2._Lambda_0024__12), (Func<JToken, string>)((JToken Entry) => Entry[(object)"gameVersion"].ToString()), (IComparer<string>)new ModMinecraft.VersionComparer());
                        foreach (JToken item5 in list2)
                        {
                            int key = item5[(object)"fileId"].ToObject<int>();
                            if (!dictionary2.ContainsKey(key))
                            {
                                dictionary2[key] = new List<LocalResourceFile>();
                            }
                            dictionary2[key].Add(obj2._0024VB_0024Local_LocalFile);
                            dictionary3[key] = resourceProject.Slug;
                        }
                    }
                }
                Logger.Info($"已从 CurseForge 获取本地 Mod 信息，需要获取 {dictionary2.Count} 个用于检查更新的文件信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                if (!dictionary2.Any())
                {
                    return;
                }
                JToken val3 = ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", HttpMethod.Post, string.Format("{{\"fileIds\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)dictionary2.Keys, ",")), "application/json")[(object)"data"];
                Dictionary<LocalResourceFile, ResourceVersion> dictionary4 = new Dictionary<LocalResourceFile, ResourceVersion>();
                foreach (JObject item6 in (IEnumerable<JToken>)val3)
                {
                    ResourceVersion resourceVersion2 = ResourceVersion.FromPlatformJson(item6, (ResourceTypes)1);
                    if (!resourceVersion2.DownloadAvailable)
                    {
                        continue;
                    }
                    foreach (LocalResourceFile item7 in dictionary2[Conversions.ToInteger(resourceVersion2.Id)])
                    {
                        if (resourceVersion2.ModLoaders != obj._0024VB_0024Local_CurseForgeLoaders[item7])
                        {
                            Logger.Warn($"从 CurseForge 获取到的更新文件 {resourceVersion2.FileName} 加载器为 {resourceVersion2.ModLoaders}，与本地文件 {item7.File.Name} 的加载器 {obj._0024VB_0024Local_CurseForgeLoaders[item7]} 不一致，已忽略", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                        }
                        else if (!dictionary4.ContainsKey(item7) || DateTime.Compare(dictionary4[item7].ReleaseDate, resourceVersion2.ReleaseDate) < 0)
                        {
                            dictionary4[item7] = resourceVersion2;
                        }
                    }
                }
                _Closure_0024__4_002D6 obj3 = default;
                foreach (KeyValuePair<LocalResourceFile, ResourceVersion> item8 in dictionary4)
                {
                    obj3 = new _Closure_0024__4_002D6(obj3);
                    obj3._0024VB_0024Local_Entry = item8.Key;
                    obj3._0024VB_0024Local_UpdateFile = item8.Value;
                    Logger.Trace((Func<string>)obj3._Lambda_0024__14, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (DateTime.Compare(obj3._0024VB_0024Local_Entry.ProjectVersion.ReleaseDate, obj3._0024VB_0024Local_UpdateFile.ReleaseDate) < 0 && Operators.CompareString(obj3._0024VB_0024Local_Entry.ProjectVersion.Hash, obj3._0024VB_0024Local_UpdateFile.Hash, TextCompare: false) != 0)
                    {
                        if (obj3._0024VB_0024Local_Entry.UpdateFile != null && Operators.CompareString(obj3._0024VB_0024Local_UpdateFile.Hash, obj3._0024VB_0024Local_Entry.UpdateFile.Hash, TextCompare: false) == 0)
                        {
                            obj3._0024VB_0024Local_Entry.ChangelogUrls.Add($"https://www.curseforge.com/minecraft/mc-mods/{dictionary3[Conversions.ToInteger(obj3._0024VB_0024Local_UpdateFile.Id)]}/files/{obj3._0024VB_0024Local_UpdateFile.Id}");
                            obj3._0024VB_0024Local_Entry.UpdateFile.DownloadUrls.AddRange(obj3._0024VB_0024Local_UpdateFile.DownloadUrls);
                        }
                        else if (obj3._0024VB_0024Local_Entry.UpdateFile == null || DateTime.Compare(obj3._0024VB_0024Local_UpdateFile.ReleaseDate, obj3._0024VB_0024Local_Entry.UpdateFile.ReleaseDate) > 0)
                        {
                            obj3._0024VB_0024Local_Entry.ChangelogUrls = new List<string> { $"https://www.curseforge.com/minecraft/mc-mods/{dictionary3[Conversions.ToInteger(obj3._0024VB_0024Local_UpdateFile.Id)]}/files/{obj3._0024VB_0024Local_UpdateFile.Id}" };
                            obj3._0024VB_0024Local_Entry.UpdateFile = obj3._0024VB_0024Local_UpdateFile;
                        }
                    }
                }
                Logger.Info("从 CurseForge 获取 Mod 更新信息结束", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "从 CurseForge 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                _0024VB_0024Local_IsFailed = true;
                ProjectData.ClearProjectError();
            }
            finally
            {
                checked
                {
                    _0024VB_0024Local_EndedThreadCount++;
                }
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D2
    {
        public LocalResourceFile _0024VB_0024Local_Entry;

        public _Closure_0024__4_002D2(_Closure_0024__4_002D2 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Entry = arg0._0024VB_0024Local_Entry;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D3
    {
        public ResourceVersion _0024VB_0024Local_UpdateFile;

        public _Closure_0024__4_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_3;

        public _Closure_0024__4_002D3(_Closure_0024__4_002D3 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_UpdateFile = arg0._0024VB_0024Local_UpdateFile;
            }
        }

        internal string _Lambda_0024__10()
        {
            return $"本地文件 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion.FileName} 在 Modrinth 上的最新版为 {_0024VB_0024Local_UpdateFile.FileName}";
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D4
    {
        public Dictionary<LocalResourceFile, ModLoaders> _0024VB_0024Local_CurseForgeLoaders;

        public _Closure_0024__4_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

        public _Closure_0024__4_002D4(_Closure_0024__4_002D4 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_CurseForgeLoaders = arg0._0024VB_0024Local_CurseForgeLoaders;
            }
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D5
    {
        public LocalResourceFile _0024VB_0024Local_LocalFile;

        public _Closure_0024__4_002D4 _0024VB_0024NonLocal__0024VB_0024Closure_5;

        public _Closure_0024__4_002D5(_Closure_0024__4_002D5 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_LocalFile = arg0._0024VB_0024Local_LocalFile;
            }
        }

        internal bool _Lambda_0024__12(JToken Entry)
        {
            ModLoaders val = (ModLoaders)((Entry[(object)"modLoader"] != null) ? ((int)Resource.FromCurseForgeModLoaderType(Entry[(object)"modLoader"].ToObject<int>())) : 0);
            if ((int)_0024VB_0024NonLocal__0024VB_0024Closure_5._0024VB_0024Local_CurseForgeLoaders[_0024VB_0024Local_LocalFile] == 0)
            {
                if ((int)val != 0)
                {
                    return false;
                }
            }
            else if (!EnumUtils.HasFlagF<ModLoaders>(_0024VB_0024NonLocal__0024VB_0024Closure_5._0024VB_0024Local_CurseForgeLoaders[_0024VB_0024Local_LocalFile], val))
            {
                return false;
            }
            string text = (string)Entry[(object)"gameVersion"];
            return text != null && Operators.CompareString(text, _0024VB_0024NonLocal__0024VB_0024Closure_5._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_VanillaVersion, TextCompare: false) == 0;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__4_002D6
    {
        public LocalResourceFile _0024VB_0024Local_Entry;

        public ResourceVersion _0024VB_0024Local_UpdateFile;

        public _Closure_0024__4_002D6(_Closure_0024__4_002D6 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Entry = arg0._0024VB_0024Local_Entry;
                _0024VB_0024Local_UpdateFile = arg0._0024VB_0024Local_UpdateFile;
            }
        }

        internal string _Lambda_0024__14()
        {
            return $"本地文件 {_0024VB_0024Local_Entry.ProjectVersion.FileName} 在 CurseForge 上的最新版为 {_0024VB_0024Local_UpdateFile.FileName}";
        }
    }

    public static ModLoader.LoaderTask<string, List<LocalResourceFile>> LocalResourceLoader = new ModLoader.LoaderTask<string, List<LocalResourceFile>>("LocalResourceLoader", LocalResourceFileLoad);

    public static ModLoader.LoaderTask<(List<LocalResourceFile> ModList, JObject Cache, ModMinecraft.McVersion Target), int> LocalResourceOnlineLoader = new ModLoader.LoaderTask<(List<LocalResourceFile>, JObject, ModMinecraft.McVersion), int>("LocalResourceOnlineLoader", LocalResourceOnlineLoad);

    private static Func<string, bool> _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile;

    private static StaticLocalInitFlag _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init;

    private static void LocalResourceFileLoad(ModLoader.LoaderTask<string, List<LocalResourceFile>> Loader)
    {
        try
        {
            ModBase.RunInUiWait(() =>
            {
                if (ModMain.FrmInstanceMod != null)
                {
                    ModMain.FrmInstanceMod.Load.ShowProgress = false;
                }
            });
            if (PageInstanceMod.UpdatingInstanceModFolders.Contains(Loader.Input))
            {
                Logger.Info($"等待 Mod 更新完成后才能继续加载 Mod 列表：{Loader.Input}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                try
                {
                    ModBase.RunInUiWait(() =>
                    {
                        if (ModMain.FrmInstanceMod != null)
                        {
                            ModMain.FrmInstanceMod.Load.Text = "正在更新 Mod";
                        }
                    });
                    while (PageInstanceMod.UpdatingInstanceModFolders.Contains(Loader.Input))
                    {
                        if (Loader.IsCanceled)
                        {
                            return;
                        }
                        Thread.Sleep(100);
                    }
                }
                finally
                {
                    ModBase.RunInUiWait(() =>
                    {
                        if (ModMain.FrmInstanceMod != null)
                        {
                            ModMain.FrmInstanceMod.Load.Text = "正在加载 Mod 列表";
                        }
                    });
                }
                ModMain.FrmInstanceMod.LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
            }
            List<string> list = new List<string>();
            if (DirectoryUtils.Exists(Loader.Input))
            {
                string right = StringExtensions.Lower(Loader.Input);
                foreach (string item in DirectoryUtils.EnumerateFiles(Loader.Input, true, "*"))
                {
                    if (Operators.CompareString(StringExtensions.Lower(StringExtensions.BeforeLast(item, "\\", false)) + "\\", right, TextCompare: false) != 0 && ((object)PageInstanceLeft.Instance == null || !PageInstanceLeft.Instance.Version.HasForge || PageInstanceLeft.Instance.Version.Vanilla.Major >= 13 || Operators.CompareString(PathUtils.GetLastPart(PathUtils.RemoveLastPart(item)), $"1.{PageInstanceLeft.Instance.Version.Vanilla.Major}.{PageInstanceLeft.Instance.Version.Vanilla.Build}", TextCompare: false) != 0))
                    {
                        continue;
                    }
                    if (_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init == null)
                    {
                        Interlocked.CompareExchange(ref _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init, new StaticLocalInitFlag(), null);
                    }
                    bool lockTaken = false;
                    try
                    {
                        Monitor.Enter(_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init, ref lockTaken);
                        if (_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init.State == 0)
                        {
                            _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init.State = 2;
                            _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile = (string FullName) =>
                            {
                                if (FullName == null || !FullName.Contains("."))
                                {
                                    return false;
                                }
                                FullName = StringExtensions.Lower(FullName);
                                return (StringExtensions.EndsWithF(FullName, ".jar", true) || StringExtensions.EndsWithF(FullName, ".zip", true) || StringExtensions.EndsWithF(FullName, ".litemod", true) || StringExtensions.EndsWithF(FullName, ".jar.disabled", true) || StringExtensions.EndsWithF(FullName, ".zip.disabled", true) || StringExtensions.EndsWithF(FullName, ".litemod.disabled", true) || StringExtensions.EndsWithF(FullName, ".jar.old", true) || StringExtensions.EndsWithF(FullName, ".zip.old", true) || StringExtensions.EndsWithF(FullName, ".litemod.old", true)) ? true : false;
                            };
                        }
                        else if (_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init.State == 2)
                        {
                            throw new IncompleteInitialization();
                        }
                    }
                    finally
                    {
                        _0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init.State = 1;
                        if (lockTaken)
                        {
                            Monitor.Exit(_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile_0024Init);
                        }
                    }
                    if (_0024STATIC_0024LocalResourceFileLoad_0024011151286AC2E1512815D11280C8_0024IsModFile(item))
                    {
                        list.Add(item);
                    }
                }
            }
            string text = ModBase.PathTemp + "Cache\\LocalMod.json";
            JObject val = new JObject();
            try
            {
                string text2 = FileUtils.TryReadAsString(text, (Encoding)null, (Type)null);
                if (!string.IsNullOrWhiteSpace(text2))
                {
                    val = (JObject)StringExtensions.DeserializeJson(text2);
                    if (!val.ContainsKey("version") || val["version"].ToObject<int>() != 19)
                    {
                        Logger.Warn("本地 Mod 信息缓存版本已过期，将弃用这些缓存信息", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                        val = new JObject();
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                Logger.Warn(ex2, "读取本地 Mod 信息缓存失败，已重置", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                val = new JObject();
                ProjectData.ClearProjectError();
            }
            val["version"] = (JToken)(19);
            List<LocalResourceFile> list2 = new List<LocalResourceFile>();
            _Closure_0024__2_002D0 obj = default;
            foreach (string item2 in list)
            {
                obj = new _Closure_0024__2_002D0(obj);
                if (Loader.IsCanceled)
                {
                    return;
                }
                obj._0024VB_0024Local_ModEntry = new LocalResourceFile(item2);
                LocalResourceFile localResourceFile = list2.FirstOrDefault(obj._Lambda_0024__4);
                if (localResourceFile != null)
                {
                    LocalResourceFile localResourceFile2 = (localResourceFile.IsEnabled ? obj._0024VB_0024Local_ModEntry : localResourceFile);
                    Logger.Warn($"重复的 Mod 文件：{localResourceFile.File.Name} 与 {obj._0024VB_0024Local_ModEntry.File.Name}，已忽略 {localResourceFile2.File.Name}", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (localResourceFile2 == obj._0024VB_0024Local_ModEntry)
                    {
                        continue;
                    }
                    list2.Remove(localResourceFile2);
                }
                list2.Add(obj._0024VB_0024Local_ModEntry);
            }
            Logger.Info($"共发现 {list2.Count} 个 Mod", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
            list2 = list2.OrderBy((LocalResourceFile m) => m.File.Name).ToList();
            if (!Loader.IsCanceled)
            {
                Loader.Output = list2;
                LocalResourceOnlineLoader.Start((list2, val, PageInstanceLeft.Instance.Version), IsForceRestart: true);
            }
        }
        catch (Exception ex3)
        {
            ProjectData.SetProjectError(ex3);
            Exception ex4 = ex3;
            Logger.Warn(ex4, "Mod 列表加载失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
            throw;
        }
    }

    private static void LocalResourceOnlineLoad(ModLoader.LoaderTask<(List<LocalResourceFile> ModList, JObject Cache, ModMinecraft.McVersion Target), int> Loader)
    {
        List<LocalResourceFile> list = new List<LocalResourceFile>();
        JObject item = Loader.Input.Cache;
        ModLoaders modLoaders = Loader.Input.Target.ModLoaders;
        foreach (LocalResourceFile item3 in Loader.Input.ModList)
        {
            if (Loader.IsCanceled)
            {
                return;
            }
            string text = item3.ModrinthHash + Loader.Input.Target.VanillaName + Conversions.ToString((int)modLoaders);
            if (item.ContainsKey(text))
            {
                item3.FromJson((JObject)item[text]);
                if (item3.OnlineDataLoaded && DateTime.Now - item[text][(object)"Project"][(object)"CacheTime"].ToObject<DateTime>() < new TimeSpan(6, 0, 0))
                {
                    continue;
                }
            }
            list.Add(item3);
        }
        Logger.Info($"有 {list.Where((LocalResourceFile m) => (object)m.Project == null).Count()} 个 Mod 需要联网获取信息，{list.Where((LocalResourceFile m) => (object)m.Project != null).Count()} 个 Mod 需要更新信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
        if (!list.Any())
        {
            return;
        }
        ModMinecraft.McVersion item2 = Loader.Input.Target;
        string vanillaName = item2.VanillaName;
        Logger.Info($"正在检查 Mod 信息的版本：{vanillaName}，加载器 {modLoaders}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
        int num = 0;
        bool flag = false;
        Thread currentThread = Thread.CurrentThread;
        checked
        {
            ModBase.RunInNewThread(() =>
            {
                try
                {
                    List<string> list2 = list.Select((LocalResourceFile m) => m.ModrinthHash).ToList();
                    JObject val = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", EnumerableExtensions.Join((IEnumerable)list2, "\",\"")), "application/json");
                    Logger.Info($"从 Modrinth 获取到 {((JContainer)val).Count} 个本地 Mod 的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (((JContainer)val).Count != 0)
                    {
                        Dictionary<string, List<LocalResourceFile>> dictionary = new Dictionary<string, List<LocalResourceFile>>();
                        Dictionary<LocalResourceFile, List<string>> dictionary2 = new Dictionary<LocalResourceFile, List<string>>();
                        foreach (LocalResourceFile item4 in list)
                        {
                            if (val.ContainsKey(item4.ModrinthHash) && !((string)val[item4.ModrinthHash][(object)"files"][(object)0][(object)"hashes"][(object)"sha1"] != item4.ModrinthHash))
                            {
                                string key = val[item4.ModrinthHash][(object)"project_id"].ToString();
                                if (ResourceProject.Cache.ContainsKey(key) && (object)item4.Project == null)
                                {
                                    item4.Project = ResourceProject.Cache[key];
                                }
                                if (!dictionary.ContainsKey(key))
                                {
                                    dictionary[key] = new List<LocalResourceFile>();
                                }
                                dictionary[key].Add(item4);
                                ResourceVersion resourceVersion = ResourceVersion.FromPlatformJson((JObject)val[item4.ModrinthHash], (ResourceTypes)1);
                                dictionary2[item4] = (from l in ((IEnumerable<JToken>)val[item4.ModrinthHash][(object)"loaders"]).Select((JToken l) => StringExtensions.Lower(l.ToString())).Distinct()
                                                      orderby l
                                                      select l).ToList();
                                if (item4.ProjectVersion == null || DateTime.Compare(item4.ProjectVersion.ReleaseDate, resourceVersion.ReleaseDate) < 0)
                                {
                                    item4.ProjectVersion = resourceVersion;
                                }
                                else
                                {
                                    item4.ProjectVersion.Version = resourceVersion.Version;
                                }
                            }
                        }
                        if (!Loader.IsCanceledWithThread(currentThread))
                        {
                            Logger.Info($"需要从 Modrinth 获取 {dictionary.Count} 个本地 Mod 的工程信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                            if (dictionary.Any())
                            {
                                JArray val2 = (JArray)ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", EnumerableExtensions.Join((IEnumerable)dictionary.Keys, "\",\"")));
                                foreach (JToken item5 in val2)
                                {
                                    ResourceProject resourceProject = new ResourceProject((JObject)item5);
                                    foreach (LocalResourceFile item6 in dictionary[resourceProject.Id])
                                    {
                                        item6.Project = resourceProject;
                                    }
                                }
                                Logger.Info("已从 Modrinth 获取本地 Mod 信息，继续获取更新信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                List<LocalResourceFile> source = dictionary.SelectMany((KeyValuePair<string, List<LocalResourceFile>> l) => l.Value).ToList();
                                if (source.Any())
                                {
                                    string arg = EnumerableExtensions.Join((IEnumerable)source.Select((LocalResourceFile m) => string.Format("{{\"hash\": \"{0}\", \"loaders\": [\"{1}\"], \"game_versions\": [\"{2}\"]}}", m.ModrinthHash, EnumerableExtensions.Join((IEnumerable)dictionary2[m], "\",\""), vanillaName)), ",");
                                    JObject val3 = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files/update_individual", HttpMethod.Post, $"{{\"algorithm\": \"sha1\", \"hashes\": [{arg}]}}", "application/json");
                                    using (List<LocalResourceFile>.Enumerator enumerator6 = list.GetEnumerator())
                                    {
                                        _Closure_0024__4_002D2 obj = default;
                                        _Closure_0024__4_002D3 obj2 = default;
                                        while (enumerator6.MoveNext())
                                        {
                                            obj = new _Closure_0024__4_002D2(obj);
                                            obj._0024VB_0024Local_Entry = enumerator6.Current;
                                            obj2 = new _Closure_0024__4_002D3(obj2);
                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3 = obj;
                                            if (val3.ContainsKey(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash) && obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion != null)
                                            {
                                                obj2._0024VB_0024Local_UpdateFile = ResourceVersion.FromPlatformJson((JObject)val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash], (ResourceTypes)1);
                                                if (obj2._0024VB_0024Local_UpdateFile.DownloadAvailable && (from l in ((IEnumerable<JToken>)val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"loaders"]).Select((JToken l) => StringExtensions.Lower(l.ToString())).Distinct()
                                                                                                            orderby l
                                                                                                            select l).ToList().SequenceEqual(dictionary2[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry]))
                                                {
                                                    Logger.Trace((Func<string>)obj2._Lambda_0024__10, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                                    if (DateTime.Compare(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion.ReleaseDate, obj2._0024VB_0024Local_UpdateFile.ReleaseDate) < 0 && Operators.CompareString(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ProjectVersion.Hash, obj2._0024VB_0024Local_UpdateFile.Hash, TextCompare: false) != 0)
                                                    {
                                                        if (obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile != null && Operators.CompareString(obj2._0024VB_0024Local_UpdateFile.Hash, obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.Hash, TextCompare: false) == 0)
                                                        {
                                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ChangelogUrls.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"project_id"], vanillaName));
                                                            obj2._0024VB_0024Local_UpdateFile.DownloadUrls.AddRange(obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.DownloadUrls);
                                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile = obj2._0024VB_0024Local_UpdateFile;
                                                        }
                                                        else if (obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile == null || DateTime.Compare(obj2._0024VB_0024Local_UpdateFile.ReleaseDate, obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile.ReleaseDate) >= 0)
                                                        {
                                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ChangelogUrls = new List<string> { string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", val3[obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.ModrinthHash][(object)"project_id"], vanillaName) };
                                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_Entry.UpdateFile = obj2._0024VB_0024Local_UpdateFile;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    Logger.Info("从 Modrinth 获取本地 Mod 信息结束", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Warn(ex2, "从 Modrinth 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    flag = true;
                    ProjectData.ClearProjectError();
                }
                finally
                {
                    num++;
                }
            }, "Mod List Detail Loader Modrinth");
            _Closure_0024__4_002D0 CS_0024_003C_003E8__locals0 = default(_Closure_0024__4_002D0);
            ModBase.RunInNewThread(() =>
            {
                try
                {
                    _Closure_0024__4_002D4 obj = new _Closure_0024__4_002D4(null);
                    obj._0024VB_0024NonLocal__0024VB_0024Closure_4 = CS_0024_003C_003E8__locals0;
                    List<uint> list2 = new List<uint>();
                    foreach (LocalResourceFile item7 in list)
                    {
                        list2.Add(item7.CurseForgeHash);
                        if (Loader.IsCanceledWithThread(currentThread))
                        {
                            return;
                        }
                    }
                    JContainer val = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)list2, ",")), "application/json")[(object)"data"][(object)"exactMatches"];
                    Logger.Info($"从 CurseForge 获取到 {val.Count} 个本地 Mod 的对应信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    if (((IEnumerable<JToken>)val).Any())
                    {
                        Dictionary<int, List<LocalResourceFile>> dictionary = new Dictionary<int, List<LocalResourceFile>>();
                        obj._0024VB_0024Local_CurseForgeLoaders = new Dictionary<LocalResourceFile, ModLoaders>();
                        foreach (JToken item8 in (IEnumerable<JToken>)val)
                        {
                            string text2 = item8[(object)"id"].ToString();
                            uint num2 = (uint)item8[(object)"file"][(object)"fileFingerprint"];
                            foreach (LocalResourceFile item9 in list)
                            {
                                if (item9.CurseForgeHash == num2)
                                {
                                    if (ResourceProject.Cache.ContainsKey(text2) && (object)item9.Project == null)
                                    {
                                        item9.Project = ResourceProject.Cache[text2];
                                    }
                                    EnumerableExtensions.AddIntoValueCollection<int, LocalResourceFile>((IDictionary<int, List<LocalResourceFile>>)dictionary, Conversions.ToInteger(text2), item9);
                                    ResourceVersion resourceVersion = ResourceVersion.FromPlatformJson((JObject)item8[(object)"file"], (ResourceTypes)1);
                                    obj._0024VB_0024Local_CurseForgeLoaders[item9] = resourceVersion.ModLoaders;
                                    if (item9.ProjectVersion == null || DateTime.Compare(item9.ProjectVersion.ReleaseDate, resourceVersion.ReleaseDate) < 0)
                                    {
                                        item9.ProjectVersion = resourceVersion;
                                    }
                                }
                            }
                        }
                        if (!Loader.IsCanceledWithThread(currentThread))
                        {
                            Logger.Info($"需要从 CurseForge 获取 {dictionary.Count} 个本地 Mod 的工程信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                            if (dictionary.Any())
                            {
                                JToken val2 = ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", HttpMethod.Post, string.Format("{{\"modIds\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)dictionary.Keys, ",")), "application/json")[(object)"data"];
                                Dictionary<int, List<LocalResourceFile>> dictionary2 = new Dictionary<int, List<LocalResourceFile>>();
                                Dictionary<int, string> dictionary3 = new Dictionary<int, string>();
                                _Closure_0024__4_002D5 obj2 = default;
                                foreach (JToken item10 in (IEnumerable<JToken>)val2)
                                {
                                    if (item10[(object)"isAvailable"] == null || item10[(object)"isAvailable"].ToObject<bool>())
                                    {
                                        ResourceProject resourceProject = new ResourceProject((JObject)item10);
                                        using List<LocalResourceFile>.Enumerator enumerator7 = dictionary[Conversions.ToInteger(resourceProject.Id)].GetEnumerator();
                                        while (enumerator7.MoveNext())
                                        {
                                            obj2 = new _Closure_0024__4_002D5(obj2);
                                            obj2._0024VB_0024NonLocal__0024VB_0024Closure_5 = obj;
                                            obj2._0024VB_0024Local_LocalFile = enumerator7.Current;
                                            ResourceProject project = obj2._0024VB_0024Local_LocalFile.Project;
                                            if ((object)project != null && unchecked((int)project.Platform) == 2)
                                            {
                                                obj2._0024VB_0024Local_LocalFile.Project = obj2._0024VB_0024Local_LocalFile.Project;
                                            }
                                            else
                                            {
                                                obj2._0024VB_0024Local_LocalFile.Project = resourceProject;
                                            }
                                            List<JToken> list3 = EnumerableExtensions.MaxByAll<JToken, string>(((IEnumerable<JToken>)item10[(object)"latestFilesIndexes"]).Where(obj2._Lambda_0024__12), (Func<JToken, string>)((JToken Entry) => Entry[(object)"gameVersion"].ToString()), (IComparer<string>)new ModMinecraft.VersionComparer());
                                            foreach (JToken item11 in list3)
                                            {
                                                int key = item11[(object)"fileId"].ToObject<int>();
                                                if (!dictionary2.ContainsKey(key))
                                                {
                                                    dictionary2[key] = new List<LocalResourceFile>();
                                                }
                                                dictionary2[key].Add(obj2._0024VB_0024Local_LocalFile);
                                                dictionary3[key] = resourceProject.Slug;
                                            }
                                        }
                                    }
                                }
                                Logger.Info($"已从 CurseForge 获取本地 Mod 信息，需要获取 {dictionary2.Count} 个用于检查更新的文件信息", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                if (dictionary2.Any())
                                {
                                    JToken val3 = ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", HttpMethod.Post, string.Format("{{\"fileIds\": [{0}]}}", EnumerableExtensions.Join((IEnumerable)dictionary2.Keys, ",")), "application/json")[(object)"data"];
                                    Dictionary<LocalResourceFile, ResourceVersion> dictionary4 = new Dictionary<LocalResourceFile, ResourceVersion>();
                                    foreach (JObject item12 in (IEnumerable<JToken>)val3)
                                    {
                                        ResourceVersion resourceVersion2 = ResourceVersion.FromPlatformJson(item12, (ResourceTypes)1);
                                        if (resourceVersion2.DownloadAvailable)
                                        {
                                            foreach (LocalResourceFile item13 in dictionary2[Conversions.ToInteger(resourceVersion2.Id)])
                                            {
                                                if (resourceVersion2.ModLoaders != obj._0024VB_0024Local_CurseForgeLoaders[item13])
                                                {
                                                    Logger.Warn($"从 CurseForge 获取到的更新文件 {resourceVersion2.FileName} 加载器为 {resourceVersion2.ModLoaders}，与本地文件 {item13.File.Name} 的加载器 {obj._0024VB_0024Local_CurseForgeLoaders[item13]} 不一致，已忽略", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                                }
                                                else if (!dictionary4.ContainsKey(item13) || DateTime.Compare(dictionary4[item13].ReleaseDate, resourceVersion2.ReleaseDate) < 0)
                                                {
                                                    dictionary4[item13] = resourceVersion2;
                                                }
                                            }
                                        }
                                    }
                                    _Closure_0024__4_002D6 obj3 = default;
                                    foreach (KeyValuePair<LocalResourceFile, ResourceVersion> item14 in dictionary4)
                                    {
                                        obj3 = new _Closure_0024__4_002D6(obj3);
                                        obj3._0024VB_0024Local_Entry = item14.Key;
                                        obj3._0024VB_0024Local_UpdateFile = item14.Value;
                                        Logger.Trace((Func<string>)obj3._Lambda_0024__14, (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                        if (DateTime.Compare(obj3._0024VB_0024Local_Entry.ProjectVersion.ReleaseDate, obj3._0024VB_0024Local_UpdateFile.ReleaseDate) < 0 && Operators.CompareString(obj3._0024VB_0024Local_Entry.ProjectVersion.Hash, obj3._0024VB_0024Local_UpdateFile.Hash, TextCompare: false) != 0)
                                        {
                                            if (obj3._0024VB_0024Local_Entry.UpdateFile != null && Operators.CompareString(obj3._0024VB_0024Local_UpdateFile.Hash, obj3._0024VB_0024Local_Entry.UpdateFile.Hash, TextCompare: false) == 0)
                                            {
                                                obj3._0024VB_0024Local_Entry.ChangelogUrls.Add($"https://www.curseforge.com/minecraft/mc-mods/{dictionary3[Conversions.ToInteger(obj3._0024VB_0024Local_UpdateFile.Id)]}/files/{obj3._0024VB_0024Local_UpdateFile.Id}");
                                                obj3._0024VB_0024Local_Entry.UpdateFile.DownloadUrls.AddRange(obj3._0024VB_0024Local_UpdateFile.DownloadUrls);
                                            }
                                            else if (obj3._0024VB_0024Local_Entry.UpdateFile == null || DateTime.Compare(obj3._0024VB_0024Local_UpdateFile.ReleaseDate, obj3._0024VB_0024Local_Entry.UpdateFile.ReleaseDate) > 0)
                                            {
                                                obj3._0024VB_0024Local_Entry.ChangelogUrls = new List<string> { $"https://www.curseforge.com/minecraft/mc-mods/{dictionary3[Conversions.ToInteger(obj3._0024VB_0024Local_UpdateFile.Id)]}/files/{obj3._0024VB_0024Local_UpdateFile.Id}" };
                                                obj3._0024VB_0024Local_Entry.UpdateFile = obj3._0024VB_0024Local_UpdateFile;
                                            }
                                        }
                                    }
                                    Logger.Info("从 CurseForge 获取 Mod 更新信息结束", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    Logger.Warn(ex2, "从 CurseForge 获取本地 Mod 信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
                    flag = true;
                    ProjectData.ClearProjectError();
                }
                finally
                {
                    num++;
                }
            }, "Mod List Detail Loader CurseForge");
        }
        do
        {
            if (num != 2)
            {
                Thread.Sleep(10);
                continue;
            }
            list = list.Where((LocalResourceFile m) => (object)m.Project != null).ToList();
            Logger.Info($"联网获取本地 Mod 信息完成，为 {list.Count} 个 Mod 更新缓存", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\LocalResourceLoaders.vb");
            if (!list.Any() || Loader.IsCanceled)
            {
                break;
            }
            foreach (LocalResourceFile item15 in list)
            {
                item15.OnlineDataLoaded = !flag;
                item[item15.ModrinthHash + vanillaName + Conversions.ToString((int)modLoaders)] = (JToken)(object)item15.ToJson();
            }
            FileUtils.Write(ModBase.PathTemp + "Cache\\LocalMod.json", ((JToken)item).ToString((Formatting)(ModBase.ModeDebug ? 1 : 0), new JsonConverter[0]), (Encoding)null);
            if (Loader.IsCanceled)
            {
                break;
            }
            PageInstanceMod frmInstanceMod = ModMain.FrmInstanceMod;
            if (frmInstanceMod != null && frmInstanceMod.Filter == PageInstanceMod.FilterType.CanUpdate)
            {
                ModBase.RunInUi(() =>
                {
                    ModMain.FrmInstanceMod?.RefreshUI();
                });
            }
            else
            {
                ModBase.RunInUi(() =>
                {
                    ModMain.FrmInstanceMod?.RefreshBars();
                });
            }
            break;
        }
        while (!Loader.IsCanceled);
    }
}

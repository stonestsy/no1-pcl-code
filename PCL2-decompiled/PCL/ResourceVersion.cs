using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

public class ResourceVersion
{
    public enum ReleaseTypes
    {
        Release = 1,
        Beta,
        Alpha
    }

    public enum DownloadReason
    {
        Standalone,
        Dependency,
        ModPack,
        Update
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__27_002D0
    {
        public bool _0024VB_0024Local_IsBadDisplay;

        public MyListItem.ClickEventHandler _0024VB_0024Local_ClickHandler;

        public MyIconButton.ClickEventHandler _0024VB_0024Local_SaveAsButtonHandler;

        public ResourceVersion _0024VB_0024Me;

        internal MyListItem _Lambda_0024__0()
        {
            MyListItem myListItem = new MyListItem();
            _Closure_0024__27_002D1 obj = new _Closure_0024__27_002D1();
            obj._0024VB_0024NonLocal__0024VB_0024Closure_3 = this;
            obj._0024W2 = myListItem;
            obj._0024W2.SnapsToDevicePixels = true;
            obj._0024W2.Height = 42.0;
            obj._0024W2.Type = MyListItem.CheckType.Clickable;
            obj._0024W2.Tag = _0024VB_0024Me;
            obj._0024W2.Title = StringExtensions.BeforeLastOfAny(_0024VB_0024Local_IsBadDisplay ? _0024VB_0024Me.FileName : _0024VB_0024Me.Display, (IEnumerable<string>)new string[4] { ".zip", ".jar", ".mrpack", ".litemod" }, true);
            obj._0024W2.Logo = $"{ModBase.PathImage}ReleaseTypes/{_0024VB_0024Me.ReleaseType}.png";
            obj._0024W2.Click += _0024VB_0024Local_ClickHandler;
            obj._0024W2.Info = EnumerableExtensions.Join((IEnumerable)obj._Lambda_0024__1(), '，');
            if (_0024VB_0024Local_SaveAsButtonHandler != null)
            {
                MyIconButton myIconButton = new MyIconButton
                {
                    Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
                    ToolTip = "另存为"
                };
                myIconButton.Click += _0024VB_0024Local_SaveAsButtonHandler;
                obj._0024W2.Buttons = new MyIconButton[1] { myIconButton };
            }
            return myListItem;
        }
    }

    [CompilerGenerated]
    internal sealed class _Closure_0024__27_002D1
    {
        public MyListItem _0024W2;

        public _Closure_0024__27_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

        internal IEnumerable<string> _Lambda_0024__1()
        {
            if ((int)_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.ModLoaders != 0)
            {
                yield return EnumerableExtensions.Join((IEnumerable)EnumerableExtensions.Flags<ModLoaders>(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.ModLoaders), '、');
            }
            if (Operators.CompareString(_0024W2.Title, StringExtensions.BeforeLast(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.FileName, ".", false), TextCompare: false) != 0)
            {
                yield return StringExtensions.BeforeLast(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.FileName, ".", false);
            }
            if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.Dependencies.Any())
            {
                yield return $"{_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.Dependencies.Count} 项前置";
            }
            if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.GameVersions.All((string v) => !v.Contains(".") || new string[6] { "w", "snapshot", "rc", "pre", "experimental", "-" }.Any((string s) => StringExtensions.ContainsIgnoreCase(v, s))))
            {
                yield return $"游戏版本 {EnumerableExtensions.Join((IEnumerable)_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.GameVersions, '、')}";
            }
            if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.DownloadCount > 0)
            {
                yield return string.Format("下载 {0}次", (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.DownloadCount > 100000) ? (Conversions.ToString(Math.Round((double)_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.DownloadCount / 10000.0)) + " 万") : (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.DownloadCount + " "));
            }
            yield return $"更新于 {StringUtils.FormatTimeSpan(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.ReleaseDate - DateTime.Now, false)}";
            if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.ReleaseType != ReleaseTypes.Release)
            {
                yield return _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.ReleaseTypeDisplay;
            }
        }
    }

    public string Id;

    public ResourceTypes ResourceType;

    public string Display;

    public DateTime ReleaseDate;

    public int DownloadCount;

    public string Version;

    public ModLoaders ModLoaders;

    public List<string> GameVersions;

    public ReleaseTypes ReleaseType;

    public string FileName;

    public List<string> DownloadUrls;

    public string Hash;

    public int Size;

    private List<string> RawDependencies;

    public List<string> Dependencies;

    protected internal static Dictionary<string, List<ResourceVersion>> ProjectFilesCache = new Dictionary<string, List<ResourceVersion>>();

    public string ReleaseTypeDisplay => ReleaseType switch
    {
        ReleaseTypes.Release => "正式版",
        ReleaseTypes.Beta => ModBase.ModeDebug ? "Beta 版" : "测试版",
        _ => ModBase.ModeDebug ? "Alpha 版" : "早期测试版",
    };

    public bool DownloadAvailable
    {
        get
        {
            if (FileName != null)
            {
                return DownloadUrls != null;
            }
            return false;
        }
    }

    public ResourceVersion()
    {
        ModLoaders = (ModLoaders)0;
        FileName = null;
        Hash = null;
        Size = -1;
        RawDependencies = new List<string>();
        Dependencies = new List<string>();
    }

    public static ResourceVersion FromPlatformJson(JObject Data, ResourceTypes ExpectedResourceType)
    {
        ResourceVersion resourceVersion = new ResourceVersion();
        ResourceVersion resourceVersion2 = resourceVersion;
        resourceVersion2.ResourceType = ExpectedResourceType;
        if (Data.ContainsKey("gameId"))
        {
            resourceVersion2.Id = (string)Data["id"];
            resourceVersion2.Display = Data["displayName"].ToString().Replace("\t", "").Trim(' ');
            resourceVersion2.Version = null;
            resourceVersion2.ReleaseDate = (DateTime)Data["fileDate"];
            resourceVersion2.ReleaseType = (ReleaseTypes)Data["releaseType"].ToObject<int>();
            resourceVersion2.DownloadCount = (int)Data["downloadCount"];
            resourceVersion2.FileName = (string)Data["fileName"];
            resourceVersion2.Size = (int)Data["fileLength"];
            ResourceVersion resourceVersion3 = resourceVersion2;
            JToken val = ((IEnumerable<JToken>)(JArray)Data["hashes"]).ToList().FirstOrDefault((JToken s) => s[(object)"algo"].ToObject<int>() == 1);
            resourceVersion3.Hash = (string)((val != null) ? val[(object)"value"] : null);
            if (resourceVersion2.Hash == null)
            {
                ResourceVersion resourceVersion4 = resourceVersion2;
                JToken val2 = ((IEnumerable<JToken>)(JArray)Data["hashes"]).ToList().FirstOrDefault((JToken s) => s[(object)"algo"].ToObject<int>() == 2);
                resourceVersion4.Hash = (string)((val2 != null) ? val2[(object)"value"] : null);
            }
            string text = Data["downloadUrl"].ToString();
            if (Operators.CompareString(text, "", TextCompare: false) == 0)
            {
                text = $"https://edge.forgecdn.net/files/{Conversions.ToInteger(resourceVersion2.Id.ToString().Substring(0, 4))}/{Conversions.ToInteger(resourceVersion2.Id.ToString().Substring(4))}/{resourceVersion2.FileName}";
            }
            resourceVersion2.DownloadUrls = ParseCurseForgeDownloadUrls(text.Replace(resourceVersion2.FileName, StringUtils.UrlEscape(resourceVersion2.FileName)));
            resourceVersion2.DownloadUrls.Add(ModDownload.DlSourceModGet(text));
            resourceVersion2.DownloadUrls = resourceVersion2.DownloadUrls.Distinct().ToList();
            if (Data.ContainsKey("dependencies"))
            {
                resourceVersion2.RawDependencies = (from d in (IEnumerable<JToken>)Data["dependencies"]
                                                    where d[(object)"relationType"].ToObject<int>() == 3 && d[(object)"modId"].ToObject<int>() != 306612 && d[(object)"modId"].ToObject<int>() != 634179
                                                    select d[(object)"modId"].ToString()).ToList();
            }
            List<string> list = ((IEnumerable<JToken>)Data["gameVersions"]).Select((JToken t) => StringExtensions.Lower(t.ToString().Trim())).ToList();
            resourceVersion2.GameVersions = (from v in list
                                             where ModMinecraft.McVersion.IsFormatFit(v)
                                             select v.Replace("-snapshot", " 预览版")).Distinct().ToList();
            if (EnumerableExtensions.IsSingle<string>((IEnumerable<string>)resourceVersion2.GameVersions))
            {
                resourceVersion2.GameVersions = resourceVersion2.GameVersions.ToList();
            }
            else if (resourceVersion2.GameVersions.Count > 1)
            {
                resourceVersion2.GameVersions = ModBase.SortByComparison(resourceVersion2.GameVersions, ModMinecraft.CompareVersionGE).ToList();
                if ((int)resourceVersion2.ResourceType == 2)
                {
                    resourceVersion2.GameVersions = new string[1] { resourceVersion2.GameVersions[0] }.ToList();
                }
            }
            else
            {
                resourceVersion2.GameVersions = new List<string> { "未知版本" };
            }
            resourceVersion2.ModLoaders = (ModLoaders)0;
            foreach (ModLoaders allFlag in EnumUtils.GetAllFlags<ModLoaders>())
            {
                if (list.Contains(StringExtensions.Lower(((Enum)allFlag).ToString())))
                {
                    resourceVersion2.ModLoaders |= allFlag;
                }
            }
        }
        else
        {
            resourceVersion2.Id = (string)Data["id"];
            resourceVersion2.Display = Data["name"].ToString().Replace("\t", "").Trim(' ');
            resourceVersion2.Version = (string)Data["version_number"];
            resourceVersion2.ReleaseDate = (DateTime)Data["date_published"];
            resourceVersion2.ReleaseType = ((Operators.CompareString(Data["version_type"].ToString(), "release", TextCompare: false) == 0) ? ReleaseTypes.Release : ((Operators.CompareString(Data["version_type"].ToString(), "beta", TextCompare: false) == 0) ? ReleaseTypes.Beta : ReleaseTypes.Alpha));
            resourceVersion2.DownloadCount = (int)Data["downloads"];
            if (((IEnumerable<JToken>)(JArray)Data["files"]).Any())
            {
                JToken val3 = Data["files"][(object)0];
                resourceVersion2.FileName = (string)val3[(object)"filename"];
                resourceVersion2.DownloadUrls = new List<string>
                {
                    (string)val3[(object)"url"],
                    ModDownload.DlSourceModGet((string)val3[(object)"url"])
                }.Distinct().ToList();
                resourceVersion2.Size = (int)val3[(object)"size"];
                resourceVersion2.Hash = (string)val3[(object)"hashes"][(object)"sha1"];
            }
            List<string> list2 = ((IEnumerable<JToken>)Data["loaders"]).Select((JToken v) => v.ToString()).ToList();
            resourceVersion2.ModLoaders = (ModLoaders)0;
            foreach (ModLoaders allFlag2 in EnumUtils.GetAllFlags<ModLoaders>())
            {
                if (list2.Contains(StringExtensions.Lower(((Enum)allFlag2).ToString())))
                {
                    resourceVersion2.ModLoaders |= allFlag2;
                }
            }
            if (EnumUtils.HasFlagF<ResourceTypes>(resourceVersion2.ResourceType, (ResourceTypes)1) || EnumUtils.HasFlagF<ResourceTypes>(resourceVersion2.ResourceType, (ResourceTypes)16))
            {
                if (list2.Intersect(new string[5] { "bukkit", "folia", "paper", "purpur", "spigot" }).Any())
                {
                    resourceVersion2.ResourceType = (ResourceTypes)32;
                }
                if (list2.Contains("datapack"))
                {
                    resourceVersion2.ResourceType = (ResourceTypes)16;
                }
                if (EnumerableExtensions.Flags<ModLoaders>(resourceVersion2.ModLoaders).Any())
                {
                    resourceVersion2.ResourceType = (ResourceTypes)1;
                }
            }
            if (Data.ContainsKey("dependencies"))
            {
                resourceVersion2.RawDependencies = (from d in (IEnumerable<JToken>)Data["dependencies"]
                                                    where (string)d[(object)"dependency_type"] == "required" && (string)d[(object)"project_id"] != "P7dR8mSH" && (string)d[(object)"project_id"] != "qvIfYCYJ" && d[(object)"project_id"].ToString().Length > 0
                                                    select d[(object)"project_id"].ToString()).ToList();
            }
            List<string> source = ((IEnumerable<JToken>)Data["game_versions"]).Select((JToken t) => StringExtensions.Lower(t.ToString().Trim())).ToList();
            resourceVersion2.GameVersions = source.Where((string v) => v.Contains(".")).Select((string v) =>
            {
                string result = ((!v.Contains("-")) ? ((!StringExtensions.StartsWithF(v, "b1.", false)) ? v : "远古版本") : (StringExtensions.BeforeFirst(v, "-", false) + " 预览版"));
                return result;
            }).Distinct()
                .ToList();
            if (!EnumerableExtensions.IsSingle<string>((IEnumerable<string>)resourceVersion2.GameVersions))
            {
                if (resourceVersion2.GameVersions.Count > 1)
                {
                    resourceVersion2.GameVersions = ModBase.SortByComparison(resourceVersion2.GameVersions, ModMinecraft.CompareVersionGE).ToList();
                    if ((int)resourceVersion2.ResourceType == 2)
                    {
                        resourceVersion2.GameVersions = new List<string> { resourceVersion2.GameVersions[0] };
                    }
                }
                else if (source.Any((string v) => StringExtensions.RegexCheck(v, "[0-9]{2}w[0-9]{2}[a-z]", RegexOptions.None)))
                {
                    resourceVersion2.GameVersions = source.Where((string v) => StringExtensions.RegexCheck(v, "[0-9]{2}w[0-9]{2}[a-z]", RegexOptions.None)).ToList();
                }
                else
                {
                    resourceVersion2.GameVersions = new List<string> { "未知版本" };
                }
            }
        }
        resourceVersion2 = null;
        return resourceVersion;
    }

    public static List<ResourceVersion> FromProjectId(string ProjectId, ResourcePlatforms Platform, bool LoadDependencies = true)
    {
        if (!EnumerableExtensions.IsSingle<ResourcePlatforms>(EnumerableExtensions.Flags<ResourcePlatforms>(Platform)))
        {
            throw new ArgumentException($"必须指定单一平台，当前值为 {Platform}");
        }
        ResourceProject resourceProject = ResourceProject.FromProjectId(ProjectId, Platform);
        if (!ProjectFilesCache.ContainsKey(ProjectId))
        {
            Logger.Info($"开始获取项目版本列表：{ProjectId}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceVersion.vb");
            JArray source = null;
            if ((int)Platform == 1)
            {
                int num = 0;
                checked
                {
                    do
                    {
                        JObject val = (JObject)ModDownload.DlModRequest($"https://api.curseforge.com/v1/mods/{ProjectId}/files?pageSize=" + Conversions.ToString(10000 + num));
                        if (val["pagination"][(object)"resultCount"].ToObject<int>() == val["pagination"][(object)"totalCount"].ToObject<int>())
                        {
                            source = (JArray)val["data"];
                            break;
                        }
                        if (num < 2)
                        {
                            Logger.Warn($"CurseForge 返回的资源版本列表存在缺失，即将进行第 {num + 1} 次重试", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceVersion.vb");
                            Logger.Info(string.Format("返回的原始内容如下：{0}{1}", "\r\n", val), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceVersion.vb");
                            num++;
                            continue;
                        }
                        Logger.Info(string.Format("CurseForge 返回的资源版本列表存在缺失，返回的原始内容如下：{0}{1}", "\r\n", val), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceVersion.vb");
                        throw new Exception("CurseForge 返回的资源版本列表存在缺失");
                    }
                    while (num <= 2);
                }
            }
            else
            {
                source = (JArray)ModDownload.DlModRequest($"https://api.modrinth.com/v2/project/{ProjectId}/version?include_changelog=false");
            }
            ProjectFilesCache[ProjectId] = EnumerableExtensions.DistinctBy<ResourceVersion, string>(from a in ((IEnumerable<JToken>)source).Select((JToken a) =>
                {
                    return FromPlatformJson((JObject)a, resourceProject.Types);
                })
                                                                                                    where a.DownloadAvailable
                                                                                                    select a, (Func<ResourceVersion, string>)((ResourceVersion a) => a.Id)).ToList();
        }
        List<ResourceVersion> list = ProjectFilesCache[ProjectId];
        if (!LoadDependencies)
        {
            return list;
        }
        List<string> list2 = list.SelectMany((ResourceVersion f) => f.RawDependencies).Distinct().ToList();
        if (list2.Any())
        {
            Logger.Info(string.Format("项目 {0} 中需要加载的前置：{1}", ProjectId, EnumerableExtensions.Join((IEnumerable)list2, "，")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceVersion.vb");
            foreach (ResourceProject item in ResourceProject.FromProjectIds(list2, resourceProject.Platform))
            {
                foreach (ResourceVersion item2 in list)
                {
                    if (item2.RawDependencies.Contains(item.Id) && Operators.CompareString(item.Id, ProjectId, TextCompare: false) != 0 && !item2.Dependencies.Contains(item.Id))
                    {
                        item2.Dependencies.Add(item.Id);
                    }
                }
            }
        }
        return list;
    }

    public static ResourceVersion FromCacheJson(JObject Data)
    {
        ResourceVersion resourceVersion;
        ResourceVersion result = (resourceVersion = new ResourceVersion());
        resourceVersion.ResourceType = Data["ResourceType"].ToObject<ResourceTypes>();
        resourceVersion.Id = Data["Id"].ToString();
        resourceVersion.Display = Data["DisplayName"].ToString();
        if (Data.ContainsKey("Version"))
        {
            resourceVersion.Version = Data["Version"].ToString();
        }
        resourceVersion.ReleaseDate = Data["ReleaseDate"].ToObject<DateTime>();
        resourceVersion.DownloadCount = Data["DownloadCount"].ToObject<int>();
        resourceVersion.ReleaseType = Data["ReleaseType"].ToObject<ReleaseTypes>();
        if (Data.ContainsKey("FileName"))
        {
            resourceVersion.FileName = Data["FileName"].ToString();
        }
        if (Data.ContainsKey("DownloadUrls"))
        {
            resourceVersion.DownloadUrls = Data["DownloadUrls"].ToObject<List<string>>();
        }
        if (Data.ContainsKey("ModLoaders"))
        {
            resourceVersion.ModLoaders = Data["ModLoaders"].ToObject<ModLoaders>();
        }
        if (Data.ContainsKey("Size"))
        {
            resourceVersion.Size = Data["Size"].ToObject<int>();
        }
        if (Data.ContainsKey("Hash"))
        {
            resourceVersion.Hash = Data["Hash"].ToString();
        }
        if (Data.ContainsKey("GameVersions"))
        {
            resourceVersion.GameVersions = Data["GameVersions"].ToObject<List<string>>();
        }
        if (Data.ContainsKey("RawDependencies"))
        {
            resourceVersion.RawDependencies = Data["RawDependencies"].ToObject<List<string>>();
        }
        if (Data.ContainsKey("Dependencies"))
        {
            resourceVersion.Dependencies = Data["Dependencies"].ToObject<List<string>>();
        }
        resourceVersion = null;
        return result;
    }

    public JObject ToCacheJson()
    {
        JObject val = new JObject();
        JObject val2 = val;
        val2.Add("ResourceType", (JToken)((int)ResourceType));
        val2.Add("Id", (JToken)(Id));
        if (Version != null)
        {
            val2.Add("Version", (JToken)(Version));
        }
        val2.Add("DisplayName", (JToken)(Display));
        val2.Add("ReleaseDate", (JToken)(ReleaseDate));
        val2.Add("DownloadCount", (JToken)(DownloadCount));
        val2.Add("ModLoaders", (JToken)((int)ModLoaders));
        val2.Add("GameVersions", (JToken)new JArray((object)GameVersions));
        val2.Add("ReleaseType", (JToken)((int)ReleaseType));
        if (FileName != null)
        {
            val2.Add("FileName", (JToken)(FileName));
        }
        if (DownloadUrls != null)
        {
            val2.Add("DownloadUrls", (JToken)new JArray((object)DownloadUrls));
        }
        if (Hash != null)
        {
            val2.Add("Hash", (JToken)(Hash));
        }
        if (Size >= 0)
        {
            val2.Add("Size", (JToken)(Size));
        }
        val2.Add("RawDependencies", (JToken)new JArray((object)RawDependencies));
        val2.Add("Dependencies", (JToken)new JArray((object)Dependencies));
        val2 = null;
        return val;
    }

    public MyVirtualizingElement<MyListItem> ToListItem(MyListItem.ClickEventHandler ClickHandler, MyIconButton.ClickEventHandler SaveAsButtonHandler = null, bool IsBadDisplay = false)
    {
        _Closure_0024__27_002D0 CS_0024_003C_003E8__locals0 = default(_Closure_0024__27_002D0);
        return new MyVirtualizingElement<MyListItem>(() =>
        {
            MyListItem myListItem = new MyListItem();
            _Closure_0024__27_002D1 obj = new _Closure_0024__27_002D1();
            obj._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals0;
            obj._0024W2 = myListItem;
            obj._0024W2.SnapsToDevicePixels = true;
            obj._0024W2.Height = 42.0;
            obj._0024W2.Type = MyListItem.CheckType.Clickable;
            obj._0024W2.Tag = this;
            obj._0024W2.Title = StringExtensions.BeforeLastOfAny(IsBadDisplay ? FileName : Display, (IEnumerable<string>)new string[4] { ".zip", ".jar", ".mrpack", ".litemod" }, true);
            obj._0024W2.Logo = $"{ModBase.PathImage}ReleaseTypes/{ReleaseType}.png";
            obj._0024W2.Click += ClickHandler;
            obj._0024W2.Info = EnumerableExtensions.Join((IEnumerable)obj._Lambda_0024__1(), '，');
            if (SaveAsButtonHandler != null)
            {
                MyIconButton myIconButton = new MyIconButton
                {
                    Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z",
                    ToolTip = "另存为"
                };
                myIconButton.Click += SaveAsButtonHandler;
                obj._0024W2.Buttons = new MyIconButton[1] { myIconButton };
            }
            return myListItem;
        })
        {
            Height = 42.0
        };
    }

    public ModNet.NetFile ToNetFile(string LocalFileOrFolder, DownloadReason? TrackDownloadReason = null, string TrackGameVersion = null, ModLoaders TrackLoader = (ModLoaders)0)
    {
        return new ModNet.NetFile(ParseModrinthTrackArguments(DownloadUrls, TrackDownloadReason, TrackGameVersion, TrackLoader), LocalFileOrFolder + (StringExtensions.EndsWithF(LocalFileOrFolder, "\\", false) ? FileName : ""), new FileChecker
        {
            Hash = Hash,
            ActualSize = Size
        }, SimulateBrowserHeaders: true);
    }

    public static IEnumerable<string> ParseModrinthTrackArguments(List<string> Urls, DownloadReason? TrackDownloadReason = null, string TrackGameVersion = null, ModLoaders TrackLoader = (ModLoaders)0)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        if (TrackDownloadReason.HasValue)
        {
            dictionary.Add("mr_download_reason", StringExtensions.Lower(TrackDownloadReason.ToString()));
        }
        if (TrackGameVersion != null)
        {
            dictionary.Add("mr_game_version", TrackGameVersion);
        }
        if (EnumerableExtensions.Flags<ModLoaders>(TrackLoader).Any())
        {
            dictionary.Add("mr_loader", StringExtensions.Lower(((Enum)EnumerableExtensions.Flags<ModLoaders>(TrackLoader).First()).ToString()));
        }
        string arg = EnumerableExtensions.Join((IEnumerable)dictionary.Select((KeyValuePair<string, string> a) => $"{a.Key}={a.Value}"), "&");
        foreach (string Url in Urls)
        {
            if (!StringExtensions.ContainsIgnoreCase(Url, "cdn.modrinth.com/"))
            {
                yield return Url;
            }
            yield return string.Format("{0}{1}{2}", Url, Url.Contains("?") ? "&" : "?", arg);
        }
    }

    public static List<string> ParseCurseForgeDownloadUrls(string Url)
    {
        return new string[5]
        {
            Url.Replace("-service.overwolf.wtf", ".forgecdn.net").Replace("://edge.", "://mediafilez.").Replace("://media.", "://mediafilez."),
            Url.Replace("://edge.", "://mediafilez.").Replace("://media.", "://mediafilez."),
            Url.Replace("-service.overwolf.wtf", ".forgecdn.net"),
            Url.Replace("://media.", "://edge."),
            Url
        }.Distinct().ToList();
    }

    public override string ToString()
    {
        return $"{Id}: {FileName}";
    }
}

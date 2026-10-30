using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[StandardModule]
public sealed class ModModpack
{
    [CompilerGenerated]
    internal sealed class _Closure_0024__5_002D2
    {
        public (int ProjectId, int FileId) _0024VB_0024Local_Missing;

        public _Closure_0024__5_002D2(_Closure_0024__5_002D2 arg0)
        {
            if (arg0 != null)
            {
                _0024VB_0024Local_Missing = arg0._0024VB_0024Local_Missing;
            }
        }

        internal bool _Lambda_0024__6(ResourceProject p)
        {
            return Conversions.ToDouble(p.Id) == (double)_0024VB_0024Local_Missing.ProjectId;
        }
    }

    public static void ModpackInstall()
    {
        string text = Dialogs.SelectFile("选择整合包压缩文件", false, (string)null, (OneOf<IEnumerable<(string[], string)>, string>)(new (string[], string)[1] { (new string[3] { "rar", "zip", "mrpack" }, "整合包文件") })).FirstOrDefault();
        if (string.IsNullOrEmpty(text))
        {
            return;
        }
        ModBase.RunInThread(() =>
        {
            try
            {
                ModpackInstall(text);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ExceptionExtensions.ThrowIfCanceled(ex2);
                Logger.Error(ex2, "手动安装整合包失败", (LogBehavior)3, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                ProjectData.ClearProjectError();
            }
        });
    }

    public static ModLoader.LoaderCombo<string> ModpackInstall(string File, string InstanceName = null, string Logo = null)
    {
        Logger.Info(string.Format("整合包安装请求：{0}", File ?? "null"), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
        ZipArchive zipArchive = null;
        string archiveBaseFolder = "";
        try
        {
            string text = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\";
            if (text.Contains("!") || text.Contains(";"))
            {
                ModMain.Hint("游戏路径中不能含有感叹号或分号：" + text, ModMain.HintType.Red);
                throw new OperationCanceledException();
            }
            int num = -1;
            try
            {
                zipArchive = FileUtils.OpenZip(File, default(CancellationToken));
                if (zipArchive.GetEntry("mcbbs.packmeta") != null)
                {
                    num = 3;
                }
                else if (zipArchive.GetEntry("mmc-pack.json") != null)
                {
                    num = 2;
                }
                else if (zipArchive.GetEntry("modrinth.index.json") != null)
                {
                    num = 4;
                }
                else if (zipArchive.GetEntry("manifest.json") != null)
                {
                    num = ((((JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchive.GetEntry("manifest.json").Open(), Encoding.UTF8)))["addons"] != null) ? 3 : 0);
                }
                else if (zipArchive.GetEntry("modpack.json") != null)
                {
                    num = 1;
                }
                else if (zipArchive.GetEntry("modpack.zip") != null || zipArchive.GetEntry("modpack.mrpack") != null)
                {
                    num = 9;
                }
                else
                {
                    foreach (ZipArchiveEntry entry in zipArchive.Entries)
                    {
                        string[] array = StringExtensions.Split(entry.FullName, "/", false);
                        archiveBaseFolder = array[0] + "/";
                        if (array.Count() != 2)
                        {
                            continue;
                        }
                        if (Operators.CompareString(array[1], "mcbbs.packmeta", TextCompare: false) == 0)
                        {
                            num = 3;
                            break;
                        }
                        if (Operators.CompareString(array[1], "mmc-pack.json", TextCompare: false) == 0)
                        {
                            num = 2;
                            break;
                        }
                        if (Operators.CompareString(array[1], "modrinth.index.json", TextCompare: false) == 0)
                        {
                            num = 4;
                            break;
                        }
                        if (Operators.CompareString(array[1], "manifest.json", TextCompare: false) == 0)
                        {
                            if (((JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(entry.Open(), Encoding.UTF8)))["addons"] == null)
                            {
                                num = 0;
                                break;
                            }
                            num = 3;
                            archiveBaseFolder = "overrides/";
                            break;
                        }
                        if (Operators.CompareString(array[1], "modpack.json", TextCompare: false) == 0)
                        {
                            num = 1;
                            break;
                        }
                        if (Operators.CompareString(array[1], "modpack.zip", TextCompare: false) == 0 || Operators.CompareString(array[1], "modpack.mrpack", TextCompare: false) == 0)
                        {
                            num = 9;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                if (ExceptionExtensions.GetDisplay(ex2, true).Contains("Error.WinIOError"))
                {
                    throw new Exception("打开整合包文件失败", ex2);
                }
                if (StringExtensions.EndsWithF(File, ".rar", true))
                {
                    throw new Exception("PCL 无法处理 rar 格式的压缩包，请在解压后重新压缩为 zip 格式再试", ex2);
                }
                throw new Exception("打开整合包文件失败，文件可能损坏或为不支持的压缩包格式", ex2);
            }
            switch (num)
            {
                case 0:
                    Logger.Info("整合包种类：CurseForge", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackCurseForge(File, zipArchive, archiveBaseFolder, InstanceName, Logo);
                case 1:
                    Logger.Info("整合包种类：HMCL", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackHMCL(File, zipArchive, archiveBaseFolder);
                case 2:
                    Logger.Info("整合包种类：MMC", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackMMC(File, zipArchive, archiveBaseFolder);
                case 3:
                    Logger.Info("整合包种类：MCBBS", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackMCBBS(File, zipArchive, archiveBaseFolder, InstanceName);
                case 4:
                    Logger.Info("整合包种类：Modrinth", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackModrinth(File, zipArchive, archiveBaseFolder, InstanceName, Logo);
                case 9:
                    Logger.Info("整合包种类：带启动器的压缩包", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackLauncherPack(File, zipArchive, archiveBaseFolder);
                default:
                    Logger.Info("整合包种类：未能识别，假定为压缩包", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    return InstallPackCompress(File, zipArchive);
            }
        }
        finally
        {
            zipArchive?.Dispose();
        }
    }

    private static void ExtractModpackFiles(string InstallTemp, string FileAddress, CancellationToken c = default(CancellationToken), ProgressProvider p = null)
    {
        DirectoryUtils.Delete(InstallTemp, false);
        c.ThrowIfCancellationRequested();
        FileUtils.ExtractToDirectory(FileAddress, InstallTemp, c, p);
    }

    private static void CopyOverrideDirectory(string OverridesFolder, string VersionFolder, ModLoader.LoaderBase Loader)
    {
        if (!StringExtensions.EndsWithF(OverridesFolder, "\\", false))
        {
            OverridesFolder += "\\";
        }
        if (!StringExtensions.EndsWithF(VersionFolder, "\\", false))
        {
            VersionFolder += "\\";
        }
        if (DirectoryUtils.Exists(OverridesFolder))
        {
            Logger.Info($"处理整合包覆写文件夹：{OverridesFolder} → {VersionFolder}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
            DirectoryUtils.Copy(OverridesFolder, VersionFolder);
        }
        else
        {
            Logger.Info($"整合包中没有覆写文件夹：{OverridesFolder}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
        }
        string text = $"{OverridesFolder}PCL\\Setup.ini";
        string text2 = $"{VersionFolder}PCL\\Setup.ini";
        if (FileUtils.Exists(text))
        {
            ModBase.WriteIni(text, "VersionArgumentIndie", Conversions.ToString(1));
            ModBase.WriteIni(text, "VersionArgumentIndieV2", Conversions.ToString(Value: true));
            ModBase.WriteIni(text, "IsStar", Conversions.ToString(Value: false));
            FileUtils.Copy(text, text2);
        }
        else
        {
            ModBase.WriteIni(text2, "VersionArgumentIndie", Conversions.ToString(1));
            ModBase.WriteIni(text2, "VersionArgumentIndieV2", Conversions.ToString(Value: true));
        }
        ModBase.IniClearCache(text2);
    }

    private static void NotifyIncompatibleLoader(string LoaderName)
    {
        if (ModMain.MyMsgBox(string.Format("整合包中存在不兼容的加载器：{0}{1}如果你知道如何手动安装它，可以先选择跳过，然后在整合包下载结束后手动安装。", LoaderName, "\r\n"), "不兼容的加载器", "取消", $"不安装 {LoaderName} 并继续") == 1)
        {
            throw new OperationCanceledException();
        }
    }

    private static ModLoader.LoaderCombo<string> InstallPackCurseForge(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null, string Logo = null)
    {
        JObject val;
        try
        {
            val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(Archive.GetEntry(ArchiveBaseFolder + "manifest.json").Open(), (Encoding)null));
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception innerException = ex;
            throw new Exception("CurseForge 整合包安装信息存在问题", innerException);
        }
        if (val["minecraft"] == null || val["minecraft"][(object)"version"] == null)
        {
            throw new Exception("CurseForge 整合包未提供 Minecraft 版本信息");
        }
        if (InstanceName == null)
        {
            InstanceName = (string)(val["name"] ?? (JToken)(""));
            ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
            if (Operators.CompareString(validateFolderName.Validate(InstanceName), "", TextCompare: false) != 0)
            {
                InstanceName = "";
            }
            if (Operators.CompareString(InstanceName, "", TextCompare: false) == 0)
            {
                InstanceName = ModMain.MyMsgBoxInput("输入版本名称", "", "", new Collection<ValidateBase> { validateFolderName });
            }
            if (string.IsNullOrEmpty(InstanceName))
            {
                throw new OperationCanceledException();
            }
        }
        ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion();
        mcVersion.VanillaName = val["minecraft"][(object)"version"].ToString();
        foreach (JToken item in (IEnumerable<JToken>)(val["minecraft"][(object)"modLoaders"] ?? (JToken)(new byte[0])))
        {
            string text = StringExtensions.Lower((item[(object)"id"] ?? (JToken)("")).ToString());
            if (StringExtensions.StartsWithF(text, "forge-", false))
            {
                if (text.Contains("recommended"))
                {
                    throw new Exception("该整合包版本过老，已不支持进行安装！");
                }
                Logger.Info($"整合包 Forge 版本：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                mcVersion.Forge = text.Replace("forge-", "");
            }
            else if (StringExtensions.StartsWithF(text, "neoforge-", false))
            {
                Logger.Info($"整合包 NeoForge 版本：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                mcVersion.NeoForge = text.Replace("neoforge-", "");
            }
            else if (StringExtensions.StartsWithF(text, "fabric-", false))
            {
                Logger.Info($"整合包 Fabric 版本：{text}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                mcVersion.Fabric = text.Replace("fabric-", "");
            }
            else
            {
                NotifyIncompatibleLoader(text);
            }
        }
        string text2 = ModMain.RequestTaskTempFolder();
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        string text3 = (string)(val["overrides"] ?? (JToken)(""));
        if (Operators.CompareString(text3, "", TextCompare: false) != 0)
        {
            list.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", (ModLoader.LoaderTask<string, int> Task) =>
            {
                ExtractModpackFiles(text2, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.6));
                CopyOverrideDirectory(text2 + ArchiveBaseFolder + ((Operators.CompareString(text3, ".", TextCompare: false) == 0 || Operators.CompareString(text3, "./", TextCompare: false) == 0) ? "" : text3), $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}", Task);
            })
            {
                ProgressWeight = (double)FileUtils.GetInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
                Block = false
            });
        }
        List<int> list2 = new List<int>();
        List<int> list3 = new List<int>();
        foreach (JToken item2 in (IEnumerable<JToken>)(val["files"] ?? (JToken)(new byte[0])))
        {
            if (item2[(object)"projectID"] == null || item2[(object)"fileID"] == null)
            {
                ModMain.Hint("某项 Mod 缺少必要信息，已跳过：" + item2.ToString());
                continue;
            }
            list2.Add((int)item2[(object)"fileID"]);
            if (item2[(object)"required"] != null && !item2[(object)"required"].ToObject<bool>())
            {
                list3.Add((int)item2[(object)"fileID"]);
            }
        }
        if (list2.Any())
        {
            List<ModLoader.LoaderBase> list4 = new List<ModLoader.LoaderBase>();
            list4.Add(new ModLoader.LoaderTask<int, JArray>("获取 Mod 下载信息", (ModLoader.LoaderTask<int, JArray> Task) =>
            {
                Task.Output = (JArray)ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", HttpMethod.Post, "{\"fileIds\": [" + EnumerableExtensions.Join((IEnumerable)list2, ",") + "]}", "application/json")[(object)"data"];
                if (list2.Count != ((JContainer)Task.Output).Count)
                {
                    List<int> list7 = list2.Except(((IEnumerable<JToken>)Task.Output).Select((JToken j) => j[(object)"id"].ToObject<int>())).ToList();
                    Logger.Info(string.Format("缺失的 fileIds：{0}", EnumerableExtensions.Join((IEnumerable)list7, "、")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    List<(int, int)> list8 = list7.Select((int id) =>
                    {
                        return (((JObject)((IEnumerable<JToken>)val["files"]).AsEnumerable().First((JToken f) => f[(object)"fileID"].ToObject<int>() == id))["projectID"].ToObject<int>(), id);
                    }).ToList();
                    Logger.Info(string.Format("缺失项：{0}", EnumerableExtensions.Join((IEnumerable)list8, "、")), (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    List<ResourceProject> source = new List<ResourceProject>();
                    try
                    {
                        source = ResourceProject.FromProjectIds(list8.Select(((int ProjectId, int FileId) e) => e.ProjectId.ToString()), (ResourcePlatforms)1).ToList();
                    }
                    catch (Exception ex2)
                    {
                        ProjectData.SetProjectError(ex2);
                        Exception ex3 = ex2;
                        Logger.Warn(ex3, "获取缺失的工程信息失败", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                        ProjectData.ClearProjectError();
                    }
                    List<string> list9 = new List<string>();
                    using (List<(int, int)>.Enumerator enumerator3 = list8.GetEnumerator())
                    {
                        _Closure_0024__5_002D2 obj = default;
                        while (enumerator3.MoveNext())
                        {
                            obj = new _Closure_0024__5_002D2(obj);
                            obj._0024VB_0024Local_Missing = enumerator3.Current;
                            ResourceProject resourceProject = source.FirstOrDefault(obj._Lambda_0024__6);
                            if ((object)resourceProject == null)
                            {
                                list9.Add($"未知 CurseForge 项目 (项目 ID {obj._0024VB_0024Local_Missing.ProjectId}，文件 ID {obj._0024VB_0024Local_Missing.FileId})");
                            }
                            else
                            {
                                list9.Add($"{resourceProject.TranslatedName} (文件 ID {obj._0024VB_0024Local_Missing.FileId})");
                            }
                        }
                    }
                    if (ModMain.MyMsgBox(string.Format("未找到该整合包所需的以下内容，它们可能已被原作者删除：{0}- {1}{2}{3}是否继续安装？缺失这些内容可能导致整合包出现异常！", "\r\n", EnumerableExtensions.Join((IEnumerable)list9, "\r\n- "), "\r\n", "\r\n"), "整合包内容缺失", "继续", "取消", "", IsWarn: true) == 2)
                    {
                        Task.Cancel();
                    }
                }
            })
            {
                ProgressWeight = (double)list2.Count / 10.0
            });
            list4.Add(new ModLoader.LoaderTask<JArray, List<ModNet.NetFile>>("构造 Mod 下载信息", (ModLoader.LoaderTask<JArray, List<ModNet.NetFile>> Task) =>
            {
                Dictionary<int, ModNet.NetFile> dictionary = new Dictionary<int, ModNet.NetFile>();
                foreach (JToken item3 in Task.Input)
                {
                    int num = item3[(object)"id"].ToObject<int>();
                    if (dictionary.ContainsKey(num) || (list3.Contains(num) && ModMain.MyMsgBox("是否要下载整合包中的可选文件 " + item3[(object)"displayName"].ToString() + "？", "下载可选文件", "是", "否") == 2))
                    {
                        continue;
                    }
                    string arg;
                    ResourceTypes expectedResourceType;
                    if (((IEnumerable<JToken>)item3[(object)"modules"]).Any())
                    {
                        List<string> list7 = ((IEnumerable<JToken>)(JArray)item3[(object)"modules"]).Select((JToken l) => l[(object)"name"].ToString()).ToList();
                        if (list7.Contains("META-INF") || list7.Contains("mcmod.info") || list7.Contains("fabric.mod.json"))
                        {
                            goto IL_0136;
                        }
                        if (item3 != null)
                        {
                            JToken val2 = item3[(object)"FileName"];
                            if (val2 != null && StringExtensions.EndsWithF(val2.ToString(), ".jar", true))
                            {
                                goto IL_0136;
                            }
                        }
                        if (list7.Contains("pack.mcmeta"))
                        {
                            arg = "resourcepacks";
                            expectedResourceType = (ResourceTypes)4;
                        }
                        else if (list7.Contains("shaders"))
                        {
                            arg = "shaderpacks";
                            expectedResourceType = (ResourceTypes)8;
                        }
                        else
                        {
                            arg = "saves";
                            expectedResourceType = (ResourceTypes)64;
                        }
                    }
                    else
                    {
                        arg = "mods";
                        expectedResourceType = (ResourceTypes)1;
                    }
                    goto IL_018d;
                IL_0136:
                    arg = "mods";
                    expectedResourceType = (ResourceTypes)1;
                    goto IL_018d;
                IL_018d:
                    ResourceVersion resourceVersion = ResourceVersion.FromPlatformJson((JObject)item3, expectedResourceType);
                    if (resourceVersion.DownloadAvailable)
                    {
                        dictionary.Add(num, resourceVersion.ToNetFile($"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\{arg}\\", ResourceVersion.DownloadReason.ModPack, mcVersion.VanillaName, mcVersion.ModLoaders));
                        Task.Progress += 1.0 / (double)checked(1 + list2.Count);
                    }
                }
                Task.Output = dictionary.Values.ToList();
            })
            {
                ProgressWeight = (double)list2.Count / 200.0,
                Show = false
            });
            list4.Add(new ModNet.LoaderDownload("下载 Mod", new List<ModNet.NetFile>())
            {
                ProgressWeight = (double)list2.Count * 1.5
            });
            list.Add(new ModLoader.LoaderCombo<int>("下载 Mod（主加载器）", list4)
            {
                Show = false,
                ProgressWeight = list4.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
            });
        }
        ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
        {
            NewInstanceName = InstanceName,
            VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\",
            MinecraftName = mcVersion.VanillaName,
            ForgeVersion = mcVersion.Forge,
            NeoForgeVersion = mcVersion.NeoForge,
            FabricVersion = mcVersion.Fabric
        };
        List<ModLoader.LoaderBase> list5 = ModDownloadLib.McInstallLoader(mcInstallRequest);
        List<ModLoader.LoaderBase> list6 = new List<ModLoader.LoaderBase>();
        list6.Add(new ModLoader.LoaderCombo<string>("整合包安装", list)
        {
            Show = false,
            Block = false,
            ProgressWeight = list.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list6.Add(new ModLoader.LoaderCombo<string>("游戏安装", list5)
        {
            Show = false,
            ProgressWeight = list5.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list6.Add(new ModLoader.LoaderTask<string, string>("最终整理文件", (ModLoader.LoaderTask<string, string> Task) =>
        {
            string text5 = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\";
            if (Logo != null && FileUtils.Exists(Logo))
            {
                FileUtils.Copy(Logo, text5 + "PCL\\Logo.png");
                ModBase.WriteIni(text5 + "PCL\\Setup.ini", "Logo", "PCL\\Logo.png");
                ModBase.WriteIni(text5 + "PCL\\Setup.ini", "LogoCustom", "True");
                Logger.Info($"已设置整合包 Logo：{Logo}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
            }
            string text6 = $"{text5}saves\\";
            foreach (string item4 in DirectoryUtils.EnumerateFiles(text6, false, "*.zip"))
            {
                FileUtils.ExtractToDirectory(item4, text6, Task.CreateCancellationToken(), (ProgressProvider)null);
                FileUtils.Delete(item4, false);
            }
            string[] array = new string[2]
            {
                text5 + "原始整合包.zip",
                text5 + "原始整合包.mrpack"
            };
            foreach (string text7 in array)
            {
                if (FileUtils.Exists(text7))
                {
                    Logger.Info($"删除原始整合包文件：{text7}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    FileUtils.Delete(text7, false);
                }
            }
            if (FileUtils.Exists(FileAddress) && Operators.CompareString(PathUtils.GetFileNameWithoutExtension(FileAddress), "modpack", TextCompare: false) == 0)
            {
                Logger.Info($"删除安装整合包文件：{FileAddress}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                FileUtils.Delete(FileAddress, false);
            }
        })
        {
            ProgressWeight = 0.1,
            Show = false
        });
        string text4 = "CurseForge 整合包安装：" + InstanceName + " ";
        if (((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Any((ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text4, TextCompare: false) == 0))
        {
            ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text4, list6);
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(mcInstallRequest.VersionFolder);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackModrinth(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null, string Logo = null)
    {
        JObject val;
        try
        {
            val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(Archive.GetEntry(ArchiveBaseFolder + "modrinth.index.json").Open(), (Encoding)null));
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception innerException = ex;
            throw new Exception("Modrinth 整合包安装信息存在问题", innerException);
        }
        if (val["dependencies"] == null || val["dependencies"][(object)"minecraft"] == null)
        {
            throw new Exception("Modrinth 整合包未提供 Minecraft 版本信息");
        }
        ModMinecraft.McVersion mcVersion = new ModMinecraft.McVersion();
        foreach (JProperty item in (IEnumerable<JToken>)(val["dependencies"] ?? (JToken)(new byte[0])))
        {
            JProperty val2 = item;
            switch (StringExtensions.Lower(val2.Name))
            {
                case "minecraft":
                    mcVersion.VanillaName = val2.Value.ToString();
                    break;
                case "forge":
                    mcVersion.Forge = val2.Value.ToString();
                    Logger.Info($"整合包 Forge 版本：{mcVersion.Forge}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    break;
                case "neoforge":
                case "neo-forge":
                    mcVersion.NeoForge = val2.Value.ToString();
                    Logger.Info($"整合包 NeoForge 版本：{mcVersion.NeoForge}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    break;
                case "fabric-loader":
                    mcVersion.Fabric = val2.Value.ToString();
                    Logger.Info($"整合包 Fabric 版本：{mcVersion.Fabric}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    break;
                default:
                    NotifyIncompatibleLoader(val2.Name);
                    break;
            }
        }
        if (InstanceName == null)
        {
            InstanceName = (string)(val["name"] ?? (JToken)(""));
            ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
            if (Operators.CompareString(validateFolderName.Validate(InstanceName), "", TextCompare: false) != 0)
            {
                InstanceName = "";
            }
            if (Operators.CompareString(InstanceName, "", TextCompare: false) == 0)
            {
                InstanceName = ModMain.MyMsgBoxInput("输入版本名称", "", "", new Collection<ValidateBase> { validateFolderName });
            }
            if (string.IsNullOrEmpty(InstanceName))
            {
                throw new OperationCanceledException();
            }
        }
        string text = ModMain.RequestTaskTempFolder();
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", (ModLoader.LoaderTask<string, int> Task) =>
        {
            ExtractModpackFiles(text, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.5));
            CopyOverrideDirectory(text + ArchiveBaseFolder + "overrides", ModMinecraft.McFolderSelected + "versions\\" + InstanceName, Task);
            CopyOverrideDirectory(text + ArchiveBaseFolder + "client-overrides", ModMinecraft.McFolderSelected + "versions\\" + InstanceName, Task);
        })
        {
            ProgressWeight = (double)FileUtils.GetInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
            Block = false
        });
        List<ModNet.NetFile> list2 = new List<ModNet.NetFile>();
        foreach (JToken item2 in (IEnumerable<JToken>)(val["files"] ?? (JToken)(new byte[0])))
        {
            if (item2[(object)"env"] != null)
            {
                string left = item2[(object)"env"][(object)"client"].ToString();
                if (Operators.CompareString(left, "optional", TextCompare: false) != 0)
                {
                    if (Operators.CompareString(left, "unsupported", TextCompare: false) == 0)
                    {
                        continue;
                    }
                }
                else if (ModMain.MyMsgBox("是否要下载可选文件 " + PathUtils.GetLastPart(item2[(object)"path"].ToString()) + "？", "下载可选文件", "是", "否") == 2)
                {
                    continue;
                }
            }
            List<string> list3 = ((IEnumerable<JToken>)item2[(object)"downloads"]).SelectMany((JToken t) => ResourceVersion.ParseCurseForgeDownloadUrls(t.ToString())).ToList();
            list3.AddRange(list3.Select((string u) => ModDownload.DlSourceModGet(u)).ToList());
            list3 = ResourceVersion.ParseModrinthTrackArguments(list3, ResourceVersion.DownloadReason.ModPack, mcVersion.VanillaName, mcVersion.ModLoaders).ToList();
            list3 = list3.Distinct().ToList();
            string text2 = Path.Combine(ModMinecraft.McFolderSelected, "versions", InstanceName, item2[(object)"path"].ToString().TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            if (!PathUtils.IsParentOf($"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\", text2))
            {
                ModMain.MyMsgBox(string.Format("整合包的文件路径超出了版本文件夹，请向整合包作者反馈此问题！{0}目标：{1}{2}错误的文件：{3}", "\r\n", Path.GetFullPath(text2), "\r\n", text2), "文件路径校验失败", "确定", "", "", IsWarn: true);
                throw new OperationCanceledException();
            }
            list2.Add(new ModNet.NetFile(list3, text2, new FileChecker
            {
                Hash = item2[(object)"hashes"][(object)"sha1"].ToString()
            }, SimulateBrowserHeaders: true));
        }
        if (list2.Any())
        {
            list.Add(new ModNet.LoaderDownload("下载额外文件", list2)
            {
                ProgressWeight = (double)list2.Count * 1.5
            });
        }
        ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
        {
            NewInstanceName = InstanceName,
            VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\",
            MinecraftName = mcVersion.VanillaName,
            ForgeVersion = mcVersion.Forge,
            NeoForgeVersion = mcVersion.NeoForge,
            FabricVersion = mcVersion.Fabric
        };
        List<ModLoader.LoaderBase> list4 = ModDownloadLib.McInstallLoader(mcInstallRequest);
        List<ModLoader.LoaderBase> list5 = new List<ModLoader.LoaderBase>();
        list5.Add(new ModLoader.LoaderCombo<string>("整合包安装", list)
        {
            Show = false,
            Block = false,
            ProgressWeight = list.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list5.Add(new ModLoader.LoaderCombo<string>("游戏安装", list4)
        {
            Show = false,
            ProgressWeight = list4.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list5.Add(new ModLoader.LoaderTask<string, string>("最终整理文件", (ModLoader.LoaderTask<string, string> Task) =>
        {
            string text4 = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\";
            if (Logo != null && FileUtils.Exists(Logo))
            {
                FileUtils.Copy(Logo, text4 + "PCL\\Logo.png");
                ModBase.WriteIni(text4 + "PCL\\Setup.ini", "Logo", "PCL\\Logo.png");
                ModBase.WriteIni(text4 + "PCL\\Setup.ini", "LogoCustom", "True");
                Logger.Info($"已设置整合包 Logo：{Logo}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
            }
            string[] array = new string[2]
            {
                text4 + "原始整合包.zip",
                text4 + "原始整合包.mrpack"
            };
            foreach (string text5 in array)
            {
                if (FileUtils.Exists(text5))
                {
                    Logger.Info($"删除原始整合包文件：{text5}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    FileUtils.Delete(text5, false);
                }
            }
            if (FileUtils.Exists(FileAddress) && Operators.CompareString(PathUtils.GetFileNameWithoutExtension(FileAddress), "modpack", TextCompare: false) == 0)
            {
                Logger.Info($"删除安装整合包文件：{FileAddress}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                FileUtils.Delete(FileAddress, false);
            }
        })
        {
            ProgressWeight = 0.1,
            Show = false
        });
        string text3 = $"Modrinth 整合包安装：{InstanceName} ";
        if (((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Any((ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text3, TextCompare: false) == 0))
        {
            ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text3, list5);
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(mcInstallRequest.VersionFolder);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackHMCL(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
    {
        JObject val;
        try
        {
            val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(Archive.GetEntry(ArchiveBaseFolder + "modpack.json").Open(), Encoding.UTF8));
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception innerException = ex;
            throw new Exception("HMCL 整合包安装信息存在问题", innerException);
        }
        string text = (string)(val["name"] ?? (JToken)(""));
        ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
        if (Operators.CompareString(validateFolderName.Validate(text), "", TextCompare: false) != 0)
        {
            text = "";
        }
        if (Operators.CompareString(text, "", TextCompare: false) == 0)
        {
            text = ModMain.MyMsgBoxInput("输入版本名称", "", "", new Collection<ValidateBase> { validateFolderName });
        }
        if (string.IsNullOrEmpty(text))
        {
            throw new OperationCanceledException();
        }
        string text2 = ModMain.RequestTaskTempFolder();
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", (ModLoader.LoaderTask<string, int> Task) =>
        {
            ExtractModpackFiles(text2, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.6));
            CopyOverrideDirectory(text2 + ArchiveBaseFolder + "minecraft", ModMinecraft.McFolderSelected + "versions\\" + text, Task);
        })
        {
            ProgressWeight = (double)FileUtils.GetInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
            Block = false
        });
        if (val["gameVersion"] == null)
        {
            throw new Exception("该 HMCL 整合包未提供游戏版本信息，无法安装！");
        }
        ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
        {
            NewInstanceName = text,
            VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{text}\\",
            MinecraftName = val["gameVersion"].ToString()
        };
        List<ModLoader.LoaderBase> list2 = ModDownloadLib.McInstallLoader(mcInstallRequest);
        List<ModLoader.LoaderBase> loaders = new List<ModLoader.LoaderBase>
        {
            new ModLoader.LoaderCombo<string>("整合包安装", list)
            {
                Show = false,
                Block = false,
                ProgressWeight = list.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
            },
            new ModLoader.LoaderCombo<string>("游戏安装", list2)
            {
                Show = false,
                ProgressWeight = list2.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
            }
        };
        string text3 = "HMCL 整合包安装：" + text + " ";
        if (((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Any((ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text3, TextCompare: false) == 0))
        {
            ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text3, loaders);
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(mcInstallRequest.VersionFolder);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackMMC(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
    {
        JObject val;
        string text;
        try
        {
            val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(Archive.GetEntry(ArchiveBaseFolder + "mmc-pack.json").Open(), Encoding.UTF8));
            text = StringExtensions.ReadString(Archive.GetEntry(ArchiveBaseFolder + "instance.cfg").Open(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception innerException = ex;
            throw new Exception("MMC 整合包安装信息存在问题", innerException);
        }
        string text2 = StringExtensions.RegexSeek(text, "(?<=\\nname\\=)[^\\n]+", RegexOptions.None) ?? "";
        ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
        if (Operators.CompareString(validateFolderName.Validate(text2), "", TextCompare: false) != 0)
        {
            text2 = "";
        }
        if (Operators.CompareString(text2, "", TextCompare: false) == 0)
        {
            text2 = ModMain.MyMsgBoxInput("输入版本名称", "", "", new Collection<ValidateBase> { validateFolderName });
        }
        if (string.IsNullOrEmpty(text2))
        {
            throw new OperationCanceledException();
        }
        string text3 = ModMain.RequestTaskTempFolder();
        string fileName = $"{ModMinecraft.McFolderSelected}versions\\{text2}\\PCL\\Setup.ini";
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", (ModLoader.LoaderTask<string, int> Task) =>
        {
            ExtractModpackFiles(text3, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.55));
            CopyOverrideDirectory(text3 + ArchiveBaseFolder + ".minecraft", ModMinecraft.McFolderSelected + "versions\\" + text2, Task);
            try
            {
                string text6 = text3 + ArchiveBaseFolder + "instance.cfg";
                if (FileUtils.Exists(text6))
                {
                    List<string> list4 = new List<string>();
                    string[] array = FileUtils.ReadAsLines(text6, true, (Encoding)null, (Type)null);
                    foreach (string text7 in array)
                    {
                        if (text7.Contains("="))
                        {
                            list4.Add(StringExtensions.BeforeFirst(text7, "=", false) + ":" + StringExtensions.AfterFirst(text7, "=", false));
                        }
                    }
                    FileUtils.Write(text6, EnumerableExtensions.Join((IEnumerable)list4, "\r\n"), (Encoding)null);
                    if (Conversions.ToBoolean(ModBase.ReadIni(text6, "OverrideCommands", Conversions.ToString(Value: false))))
                    {
                        string text8 = ModBase.ReadIni(text6, "PreLaunchCommand");
                        if (Operators.CompareString(text8, "", TextCompare: false) != 0)
                        {
                            text8 = text8.Replace("\\\"", "\"").Replace("$INST_JAVA", "{java}java.exe").Replace("$INST_MC_DIR\\", "{minecraft}")
                                .Replace("$INST_MC_DIR", "{minecraft}")
                                .Replace("$INST_DIR\\", "{verpath}")
                                .Replace("$INST_DIR", "{verpath}")
                                .Replace("$INST_ID", "{name}")
                                .Replace("$INST_NAME", "{name}");
                            ModBase.WriteIni(fileName, "VersionAdvanceRun", text8);
                            Logger.Info($"迁移 MultiMC 版本独立设置：启动前执行命令：{text8}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                        }
                    }
                    if (Conversions.ToBoolean(ModBase.ReadIni(text6, "JoinServerOnLaunch", Conversions.ToString(Value: false))))
                    {
                        string text9 = ModBase.ReadIni(text6, "JoinServerOnLaunchAddress").Replace("\\\"", "\"");
                        ModBase.WriteIni(fileName, "VersionServerEnter", text9);
                        Logger.Info($"迁移 MultiMC 版本独立设置：自动进入服务器：{text9}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    }
                    string text10 = ModBase.ReadIni(text6, "iconKey");
                    if (Operators.CompareString(text10, "", TextCompare: false) != 0 && FileUtils.Exists($"{text3}{ArchiveBaseFolder}{text10}.png"))
                    {
                        ModBase.WriteIni(fileName, "LogoCustom", Conversions.ToString(Value: true));
                        ModBase.WriteIni(fileName, "Logo", "PCL\\Logo.png");
                        FileUtils.Copy($"{text3}{ArchiveBaseFolder}{text10}.png", $"{ModMinecraft.McFolderSelected}versions\\{text2}\\PCL\\Logo.png");
                        Logger.Info($"迁移 MultiMC 版本独立设置：版本图标（{text10}.png）", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    }
                    string text11 = ModBase.ReadIni(text6, "JvmArgs");
                    if (Operators.CompareString(text11, "", TextCompare: false) != 0)
                    {
                        if (Conversions.ToBoolean(ModBase.ReadIni(text6, "OverrideJavaArgs", Conversions.ToString(Value: false))))
                        {
                            ModBase.WriteIni(fileName, "VersionAdvanceJvm", text11);
                            Logger.Info($"迁移 MultiMC 版本独立设置：JVM 参数（覆盖）：{text11}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                        }
                        else
                        {
                            text11 = text11 + " " + Settings.Get<string>("LaunchAdvanceJvm");
                            ModBase.WriteIni(fileName, "VersionAdvanceJvm", text11);
                            Logger.Info($"迁移 MultiMC 版本独立设置：JVM 参数（追加）：{text11}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                        }
                    }
                }
            }
            catch (Exception ex2)
            {
                ProjectData.SetProjectError(ex2);
                Exception ex3 = ex2;
                Logger.Warn(ex3, $"读取 MMC 配置文件失败（{text3}{ArchiveBaseFolder}instance.cfg）", (LogBehavior)1, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                ProjectData.ClearProjectError();
            }
        })
        {
            ProgressWeight = (double)FileUtils.GetInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
            Block = false
        });
        if (val["components"] == null)
        {
            throw new Exception("该 MMC 整合包未提供游戏版本信息，无法安装！");
        }
        ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
        {
            NewInstanceName = text2,
            VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{text2}\\"
        };
        foreach (JObject item in (IEnumerable<JToken>)val["components"])
        {
            JObject val2 = item;
            if (!val2.ContainsKey("uid"))
            {
                continue;
            }
            string text4 = val2["uid"].ToString();
            switch (text4)
            {
                case "net.minecraft":
                    mcInstallRequest.MinecraftName = (string)val2["version"];
                    continue;
                case "net.minecraftforge":
                    mcInstallRequest.ForgeVersion = (string)val2["version"];
                    continue;
                case "net.neoforged":
                    mcInstallRequest.NeoForgeVersion = (string)val2["version"];
                    continue;
                case "net.fabricmc.fabric-loader":
                    mcInstallRequest.FabricVersion = (string)val2["version"];
                    continue;
            }
            if (StringExtensions.StartsWithF(text4, "org.lwjgl", false))
            {
                Logger.Info($"已跳过 LWJGL 项：{text4}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
            }
            else
            {
                NotifyIncompatibleLoader(text4);
            }
        }
        List<ModLoader.LoaderBase> list2 = ModDownloadLib.McInstallLoader(mcInstallRequest);
        List<ModLoader.LoaderBase> list3 = new List<ModLoader.LoaderBase>();
        list3.Add(new ModLoader.LoaderCombo<string>("整合包安装", list)
        {
            Show = false,
            Block = false,
            ProgressWeight = list.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list3.Add(new ModLoader.LoaderCombo<string>("游戏安装", list2)
        {
            Show = false,
            ProgressWeight = list2.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        string text5 = "MMC 整合包安装：" + text2 + " ";
        if (((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Any((ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text5, TextCompare: false) == 0))
        {
            ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text5, list3);
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(mcInstallRequest.VersionFolder);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackMCBBS(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null)
    {
        JObject val;
        try
        {
            ZipArchiveEntry zipArchiveEntry = Archive.GetEntry(ArchiveBaseFolder + "mcbbs.packmeta") ?? Archive.GetEntry(ArchiveBaseFolder + "manifest.json");
            val = (JObject)StringExtensions.DeserializeJson(StringExtensions.ReadString(zipArchiveEntry.Open(), Encoding.UTF8));
        }
        catch (Exception ex)
        {
            ProjectData.SetProjectError(ex);
            Exception innerException = ex;
            throw new Exception("MCBBS 整合包安装信息存在问题", innerException);
        }
        if (InstanceName == null)
        {
            InstanceName = (string)(val["name"] ?? (JToken)(""));
            ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.McFolderSelected + "versions");
            if (Operators.CompareString(validateFolderName.Validate(InstanceName), "", TextCompare: false) != 0)
            {
                InstanceName = "";
            }
            if (Operators.CompareString(InstanceName, "", TextCompare: false) == 0)
            {
                InstanceName = ModMain.MyMsgBoxInput("输入版本名称", "", "", new Collection<ValidateBase> { validateFolderName });
            }
            if (string.IsNullOrEmpty(InstanceName))
            {
                throw new OperationCanceledException();
            }
        }
        string text = ModMain.RequestTaskTempFolder();
        string fileName = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\PCL\\Setup.ini";
        List<ModLoader.LoaderBase> list = new List<ModLoader.LoaderBase>();
        list.Add(new ModLoader.LoaderTask<string, int>("解压整合包文件", (ModLoader.LoaderTask<string, int> Task) =>
        {
            ExtractModpackFiles(text, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.6));
            CopyOverrideDirectory(text + ArchiveBaseFolder + "overrides", ModMinecraft.McFolderSelected + "versions\\" + InstanceName, Task);
            if (val["launchInfo"] != null)
            {
                JObject val2 = (JObject)val["launchInfo"];
                if (val2.ContainsKey("javaArgument"))
                {
                    ModBase.WriteIni(fileName, "VersionAdvanceJvm", string.Join(" ", (IEnumerable<JToken>)val2["javaArgument"]));
                }
                if (val2.ContainsKey("launchArgument"))
                {
                    ModBase.WriteIni(fileName, "VersionAdvanceGame", string.Join(" ", (IEnumerable<JToken>)val2["launchArgument"]));
                }
            }
        })
        {
            ProgressWeight = (double)FileUtils.GetInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
            Block = false
        });
        if (val["addons"] == null)
        {
            throw new Exception("该 MCBBS 整合包未提供游戏版本附加信息，无法安装！");
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (JToken item in (IEnumerable<JToken>)val["addons"])
        {
            dictionary.Add((string)item[(object)"id"], (string)item[(object)"version"]);
        }
        if (!dictionary.ContainsKey("game"))
        {
            throw new Exception("该 MCBBS 整合包未提供游戏版本信息，无法安装！");
        }
        if (dictionary.ContainsKey("quilt"))
        {
            ModMain.Hint("PCL 不支持安装 Quilt 整合包！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
        {
            NewInstanceName = InstanceName,
            VersionFolder = $"{ModMinecraft.McFolderSelected}versions\\{InstanceName}\\",
            MinecraftName = dictionary["game"],
            OptiFineVersion = (dictionary.ContainsKey("optifine") ? dictionary["optifine"] : null),
            ForgeVersion = (dictionary.ContainsKey("forge") ? dictionary["forge"] : null),
            NeoForgeVersion = (dictionary.ContainsKey("neoforge") ? dictionary["neoforge"] : null),
            FabricVersion = (dictionary.ContainsKey("fabric") ? dictionary["fabric"] : null)
        };
        List<ModLoader.LoaderBase> list2 = ModDownloadLib.McInstallLoader(mcInstallRequest);
        List<ModLoader.LoaderBase> list3 = new List<ModLoader.LoaderBase>();
        list3.Add(new ModLoader.LoaderCombo<string>("整合包安装", list)
        {
            Show = false,
            Block = false,
            ProgressWeight = list.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        list3.Add(new ModLoader.LoaderCombo<string>("游戏安装", list2)
        {
            Show = false,
            ProgressWeight = list2.Sum((ModLoader.LoaderBase l) => l.ProgressWeight)
        });
        string text2 = "MCBBS 整合包安装：" + InstanceName + " ";
        if (((IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Any((ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text2, TextCompare: false) == 0))
        {
            ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text2, list3);
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(mcInstallRequest.VersionFolder);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackLauncherPack(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
    {
        ModMain.MyMsgBox("接下来请选择一个空文件夹，它会被安装到这个文件夹里。", "安装", "继续", "", "", IsWarn: false, HighLight: true, ForceWait: true);
        string text = Dialogs.SelectFolder("选择安装目标（必须是一个空文件夹）", false, (string)null).FirstOrDefault();
        if (text == null)
        {
            throw new OperationCanceledException();
        }
        if (!DirectoryUtils.IsEmpty(text))
        {
            ModMain.Hint("请选择一个空文件夹作为安装目标！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("解压压缩包", new ModLoader.LoaderBase[1]
        {
            new ModLoader.LoaderTask<string, int>("解压压缩包", (ModLoader.LoaderTask<string, int> Task) =>
            {
                ExtractModpackFiles(text, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.9));
                ModBase.OpenExplorer(text);
                Thread.Sleep(400);
                string text2 = null;
                foreach (string item in DirectoryUtils.EnumerateFiles(text, false, "*.exe"))
                {
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(item);
                    Logger.Info($"文件 {item} 的产品名标识为 {versionInfo.ProductName}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    if (Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher", TextCompare: false) == 0)
                    {
                        text2 = item;
                        Logger.Info($"发现整合包附带的 PCL 启动器：{item}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    }
                    else if ((StringExtensions.ContainsIgnoreCase(versionInfo.ProductName, "Launcher") || versionInfo.ProductName.Contains("启动")) && Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher Admin Manager", TextCompare: false) != 0 && text2 == null)
                    {
                        text2 = item;
                        Logger.Info($"发现整合包附带的疑似第三方启动器：{item}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    }
                }
                Task.Progress = 0.95;
                if (text2 != null)
                {
                    Logger.Info($"找到压缩包中附带的启动器：{text2}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                    if (ModMain.MyMsgBox(string.Format("整合包里似乎自带了启动器，是否换用它继续安装？{0}即将打开：{1}", "\r\n", text2), "换用整合包启动器？", "换用", "不换用") == 1)
                    {
                        ModBase.StartProcess(text2, "--wait");
                        Logger.Info("为换用整合包中的启动器启动，强制结束程序", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                        ModMain.FrmMain.EndProgram(SendWarning: false);
                        return;
                    }
                }
                else
                {
                    Logger.Info("未找到压缩包中附带的启动器", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                }
                string lastPart = PathUtils.GetLastPart(text);
                DirectoryUtils.Create(text + ".minecraft\\");
                PageSelectLeft.AddFolder(text + ".minecraft\\" + ArchiveBaseFolder.Replace("/", "\\").TrimStart('\\'), lastPart, ShowHint: false);
                string text3 = DirectoryUtils.EnumerateFiles(text, true, "modpack.*").First();
                Logger.Info($"调用 modpack 文件继续安装：{text3}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
                ModpackInstall(text3);
            })
        });
        loaderCombo.Start(text);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        ModMain.FrmMain.BtnExtraDownload.Ribble();
        return loaderCombo;
    }

    private static ModLoader.LoaderCombo<string> InstallPackCompress(string FileAddress, ZipArchive Archive)
    {
        Match match = null;
        Regex regex = new Regex("^.*\\/(?=versions\\/(?<ver>[^\\/]+)\\/(\\k<ver>)\\.json$)", RegexOptions.IgnoreCase);
        foreach (ZipArchiveEntry entry in Archive.Entries)
        {
            Match match2 = regex.Match("/" + entry.FullName);
            if (match2.Success)
            {
                match = match2;
                break;
            }
        }
        if (match == null)
        {
            throw new Exception("文件结构不匹配，这可能不是 Minecraft 客户端压缩包？");
        }
        string text = match.Value.Replace("/", "\\").TrimStart('\\');
        Logger.Info($"检测到压缩包的 .minecraft 根目录：{text}，命中的版本名：{match.Groups[1].Value}", (LogBehavior)0, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Minecraft\\ModModpack.vb");
        ModMain.MyMsgBox("接下来请选择一个空文件夹，它会被安装到这个文件夹里。", "安装", "继续", "", "", IsWarn: false, HighLight: true, ForceWait: true);
        string text2 = Dialogs.SelectFolder("选择安装目标（必须是一个空文件夹）", false, (string)null).FirstOrDefault();
        if (text2 == null)
        {
            throw new OperationCanceledException();
        }
        if (text2.Contains("!") || text2.Contains(";"))
        {
            ModMain.Hint("Minecraft 文件夹路径中不能含有感叹号或分号！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        if (!DirectoryUtils.IsEmpty(text2))
        {
            ModMain.Hint("请选择一个空文件夹作为安装目标！", ModMain.HintType.Red);
            throw new OperationCanceledException();
        }
        ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("解压压缩包", new ModLoader.LoaderBase[1]
        {
            new ModLoader.LoaderTask<string, int>("解压压缩包", (ModLoader.LoaderTask<string, int> Task) =>
            {
                ExtractModpackFiles(text2, FileAddress, Task.CreateCancellationToken(), Task.CreateSyncProgressProvider(0.0, 0.95));
                PageSelectLeft.AddFolder(text2 + text, PathUtils.GetLastPart(text2), ShowHint: false);
                Thread.Sleep(400);
                ModBase.RunInUi(() =>
                {
                    ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
                });
            })
        });
        loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
        loaderCombo.Start(text2);
        ModLoader.LoaderTaskbarAdd(loaderCombo);
        ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
        ModMain.FrmMain.BtnExtraDownload.Ribble();
        return loaderCombo;
    }
}

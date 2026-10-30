# PCL2 反编译源码（v2.13.1.1）

由 `Plain Craft Launcher 2.exe`（PCL 正式版 2.13.1.1）经 ILSpy 反编译整理得到的可编译 C# 工程，目标框架 .NET Framework 4.8。

> 源码版权归原作者（成都瓜皮龙科技有限公司 / [Meloong-Git/PCL](https://github.com/Meloong-Git/PCL)）所有。
> 本仓库仅用于学习与研究，请勿用于商业用途或二次分发。

## 目录结构

```
PCL2-decompiled/
├── PCL/                      # 主体源码：163 个 .cs + 61 个 .xaml（BAML 已还原）
├── lib/                      # 从程序内嵌资源提取的依赖 DLL（仅编译期引用）
├── images/ resources/        # 图片、字体等 WPF 资源
├── PCL.Resources.resx        # 4.4 MB，内嵌依赖 DLL 与文本资源
├── app.manifest / app.ico
├── VB-AnonymousDelegate_*.cs # 编译器生成的匿名委托，已按元数据还原签名
└── Plain Craft Launcher 2.csproj
```

## 构建

环境要求：.NET SDK（`Microsoft.NETFramework.ReferenceAssemblies` 会自动还原，无需安装 .NET Framework 4.8 开发包）。

```powershell
dotnet build "PCL2-decompiled/Plain Craft Launcher 2.csproj"
```

产物：`PCL2-decompiled/bin/Debug/net48/Plain Craft Launcher 2.exe`

依赖处理：`lib/*.dll` 在工程中以 `Private=False` 引用，不复制到输出目录；运行时由程序自身的 `AssemblyResolve` 从 `PCL.Resources` 内嵌资源加载，保持原版的单文件形态。

## 已修复的反编译问题

| 问题 | 处理 |
|---|---|
| XAML 生成字段与 VB `WithEvents` 属性重名（60 个页面） | 属性改名 `X_WithEvents`，在 `InitializeComponent()` 后回灌，事件绑定语义不变 |
| XAML 中 `assembly=Plain Craft Launcher 2` URI 非法 | 移除自引用程序集限定 |
| ILSpy 将 `JToken` 空引用判断误译为 `(int)` 强转 | 还原为 `== null`（`ResourceProject` 的 `game_versions`、`ModLaunch` 的 UUID 请求） |
| `LoaderTask.InputDelegate` 被推断为 `Func<object>` | 改回 `Func<TIn>`，避免值类型元组运行期强转失败 |
| `PclLogger` 中 `MyBase.Format/HandleBehavior` 被译为虚调用 | 改为 `base.…`，修复无限递归（栈溢出） |
| `VB$AnonymousDelegate_N` 委托类型缺失 | 依据元数据反射还原 27 个签名 |

## 源码标准化

- 移除 `//IL_xxxx` 偏移注释、`[SpecialName]` 标记与 ILSpy 专用注释
- `dotnet format whitespace` 统一缩进与间距，清理未使用 `using`
- 保留 `goto IL_xxxx` 标签：其为 VB `On Error` 异常处理的真实控制流，非注释

## 已验证

- `dotnet build` 0 错误
- 程序启动、主窗口正常
- Modrinth / CurseForge 搜索、工程与版本列表接口
- 依赖解析（CurseForge 与 Modrinth）
- 文件下载（大小与 SHA-1 校验一致）
- 整合包（.mrpack）清单解析与下载地址生成
- 日志轮转（Log1→Log2→Log3→Log4）

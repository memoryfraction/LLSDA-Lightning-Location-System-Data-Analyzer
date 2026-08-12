[<kbd>中文</kbd>]() | [<kbd>English</kbd>](readme-en.md)

# 闪电定位系统数据分析器 (LLSDA)

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/LightningLocationSystemDataAnalyzer-LLDSA.svg)](https://www.nuget.org/packages/LightningLocationSystemDataAnalyzer-LLDSA/)
[![Version](https://img.shields.io/badge/Version-v1.4.1-brightgreen.svg)](#版本记录)
[![.NET](https://img.shields.io/badge/.NET-Framework%204.8%20%7C%20Standard%202.0-green.svg)](https://dotnet.microsoft.com)

> **开源、跨平台闪电定位系统数据分析类库**
> 提供闪电时空分布的统计分析与可视化功能。

---

## 目录

* [特性](#特性)
* [安装方法](#安装方法)
* [快速开始 — 分步教程](#快速开始----分步教程)
* [面向对象设计与架构](#面向对象设计与架构)
* [学术支撑](#学术支撑)
* [作者](#作者)
* [版本记录](#版本记录)
* [知识产权](#知识产权)
* [贡献](#贡献)
* [鸣谢](#鸣谢)

---

## 效果图

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/PrintScreen---Lightning-Location-System-Data-Analyzer---Desktop-Application.png" alt="主程序窗口" style="max-width:80%;">
</p>

## 简介

**LLSDA** (*Lightning Location System Data Analyzer*) 是一个开源、跨平台的类库，用于分析闪电定位系统数据。
它提供了闪电时空分布统计分析和可视化的核心功能。

- **避免重复劳动**：为不同研究团队提供统一的基础分析库
- **提高开发效率**：防雷工程师和气象学者可快速集成到自己的项目中
- **开源贡献**：回馈开源社区和防雷行业

## 特性

| 特性 | 状态 |
|------|------|
| 跨平台 (.NET Framework 4.8 / .NET Standard 2.0) | :white_check_mark: |
| 多格式闪电文件解析 (ADTD/GLD360/WWLLN) | :white_check_mark: |
| 时间分布分析（年/月/时） | :white_check_mark: |
| 空间分布统计（方格网/同心圆） | :white_check_mark: |
| 基于经纬度的点分析 | :white_check_mark: |
| 自定义区域分析 | :white_check_mark: |
| 雷电玫瑰图 | :white_check_mark: |
| 雷电流强度概率图 | :white_check_mark: |
| GIS / Shapefile 叠加支持 (通过 MeteoInfo) | :white_check_mark: |

## 安装方法

**NuGet Package Manager Console:**

```powershell
Install-Package LightningLocationSystemDataAnalyzer-LLDSA
```

**.NET CLI:**

```bash
dotnet add package LightningLocationSystemDataAnalyzer-LLDSA
```

**PackageReference (添加到 .csproj):**

```xml
<PackageReference Include="LightningLocationSystemDataAnalyzer-LLDSA" Version="1.4.1" />
```

---

## 快速开始 — 分步教程

> **前提条件**: 你需要一个闪电定位数据文件（`.txt` 格式，来自 ADTD 或类似 LLS）。
> 示例数据文件可在本仓库的 [`Documents/Sample Source Data/`](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/tree/master/Documents/Sample%20Source%20Data) 中获取。
> 示例文件 `2008_07_09.txt` 包含 2008 年的雷击记录。

### 第一步：解析闪电数据文件

读取中国 LLS 数据文件的核心类是 `ADTDFileProcessor`。它将文本格式的雷电记录转换为强类型对象。

```csharp
using LLDSA;
using LLDSA.Entities.FileOperator.LLSFileProcessor.ADTD;
using System.Collections.Generic;
using System.IO;
using System.Text;

// 1. 指定数据文件路径
string dataFilePath = @"data\2008_07_09.txt";

if (!File.Exists(dataFilePath))
{
    Console.WriteLine("未找到数据文件: " + dataFilePath);
    return;
}

// 2. 创建文件处理器并解析所有记录
var processor = new ADTDFileProcessor();
processor.SourceLlsFilePathName = dataFilePath;
processor.Province = "";  // 全国性数据留空
processor.Encode = Encoding.UTF8;

// 解析并获取所有雷击记录
List<BaseStrikeChina> strikes = processor.ReturnStrikesChinaByProcess().ToList();

Console.WriteLine($"成功解析 {strikes.Count} 条雷击记录。");

// 每条记录包含以下信息：
foreach (var strike in strikes.Take(3))
{
    Console.WriteLine($"时间: {strike.DateAndTime}, " +
        $"纬度: {strike.Latitude}, 经度: {strike.Longitude}, " +
        $"电流强度: {strike.Intensity} A");
}
```

**支持的文件格式:**

| 格式 | 处理类 | 命名空间 |
|------|--------|---------|
| ADTD (中国 LLS) | `ADTDFileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.ADTD` |
| GLD360 (全球) | `GLD360FileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.GLD360` |
| WWLLN (全球) | `WWLLNFileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.WWLLN` |

### 第二步：时间分布分析

分析闪电在一年中、每月和每时的发生分布。这对于理解季节性模式和每日活动规律非常有用。

```csharp
using LLDSA.Service;
using System.Linq;

// 创建统计服务实例
var statisticService = new StrikesDistributionStatisticService();

// --- 年分布 ---
// 返回: Dictionary<年份, 雷击次数>
Dictionary<int, int> yearDist = statisticService.CalcuYearDistribution(strikes);
Console.WriteLine("=== 年雷击分布 ===");
foreach (var kvp in yearDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  {kvp.Key}年: {kvp.Value} 次");
}

// --- 月分布 ---
// 返回: Dictionary<月份(1-12), 雷击次数>
Dictionary<int, int> monthDist = statisticService.CalcuMonthDistribution(strikes);
Console.WriteLine("\n=== 月雷击分布 ===");
foreach (var kvp in monthDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  {kvp.Key}月: {kvp.Value} 次");
}

// --- 时分布 ---
// 返回: Dictionary<小时(0-23), 雷击次数>
Dictionary<int, int> hourDist = statisticService.CalcuHourDistribution(strikes);
Console.WriteLine("\n=== 时雷击分布 ===");
foreach (var kvp in hourDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  {kvp.Key}:00 - {kvp.Value} 次");
}

// --- 生成自动文字报告 ---
string yearReport = statisticService.GenerateYearDistributionText(strikes);
string monthReport = statisticService.GenerateMonthDistributionText(strikes);
string hourReport = statisticService.GenerateHourDistributionText(strikes);

Console.WriteLine("\n=== 自动生成的年分布报告 ===");
Console.WriteLine(yearReport);
```

### 第三步：空间分布 — 方格网分析

将中心点周围的区域划分为方格网格，统计每个单元格的雷击次数。这是闪电密度映射最常用的空间分析方法。

```csharp
using LLDSA.Entities.CommonEntities;
using System.Linq;

// 创建以特定点为中心的方格网
// 参数: 中心经度, 中心纬度, 每格边长(km), 每边格子数
// 这创建一个 9x9 网格，每个单元格为 5km x 5km
double centerX = 118.85; // 北京经度
double centerY = 31.20;  // 北京纬度

using (var analysis = new StrikesAnalysis_Square(centerX, centerY, 5.0, 9))
{
    // 处理每条雷击记录——它会被分配到所在的网格单元
    foreach (var strike in strikes)
    {
        analysis.ProcessStrikes(strike);
    }

    // 获取每个网格单元的统计结果
    var shapes = analysis.Shapes;
    Console.WriteLine($"=== 方格网分析: 9x9, 每格5km ===");
    Console.WriteLine($"中心点: ({centerX}, {centerY})");
    Console.WriteLine($"有雷击的单元格数量: {shapes.Count(s => s.StrikeCount > 0)}");

    // 找出雷击最多的单元格（热点区域）
    var maxCell = shapes.OrderByDescending(s => s.StrikeCount).FirstOrDefault();
    if (maxCell != null)
    {
        Console.WriteLine($"热点单元格: {maxCell.StrikeCount} 次雷击");
    }

    // 打印所有单元格的统计信息
    foreach (var shape in shapes)
    {
        if (shape.StrikeCount > 0)
        {
            Console.WriteLine($"单元格 [{shape.Index}, {shape.LineIndex}] " +
                $"中心:({shape.Center.Longitude},{shape.Center.Latitude}), " +
                $"雷击数: {shape.StrikeCount}");
        }
    }
}
```

**参数说明:**

| 参数 | 说明 | 典型值 |
|------|------|-------|
| `centerLongitude` | 中心点经度 | 东部中国: 110.0 ~ 125.0 |
| `centerLatitude` | 中心点纬度 | 中国大陆: 20.0 ~ 45.0 |
| `eachBoxLength` | 每个网格单元的边长 (km) | 3 ~ 10 km |
| `eachSideBoxNum` | 每边的格子数 | 9, 11, 13（建议使用奇数） |

### 第四步：空间分布 — 同心圆分析

以某点为中心的同心圆环内分析雷电密度。适用于特定地点的径向分布研究和风险评估。

```csharp
using LLDSA.Entities.CommonEntities;
using System.Linq;

// 创建同心圆分析
// 参数: 中心经度, 中心纬度, 每环半径(km), 环数
double centerX = 118.85;
double centerY = 31.20;

using (var analysis = new StrikesAnalysis_Circle(centerX, centerY, 3.0, 9))
{
    // 处理所有雷击记录
    foreach (var strike in strikes)
    {
        analysis.ProcessStrikes(strike);
    }

    // 获取每个环的统计结果
    var shapes = analysis.Shapes;
    Console.WriteLine($"=== 同心圆分析: 9环, 半径3km ===");

    foreach (var shape in shapes)
    {
        if (shape.StrikeCount > 0)
        {
            Console.WriteLine($"环 {shape.Index}: {shape.StrikeCount} 次雷击, " +
                $"半径范围: {shape.RadiusInner}~{shape.RadiusOuter} km");
        }
    }
}
```

### 第五步：雷电统计汇总

计算综合统计数据，包括最大/最小电流强度、雷电日和闪电密度 (Ng)。

```csharp
using LLDSA.Service;
using System.Linq;

var statisticService = new StrikesDistributionStatisticService();

// --- 电流强度统计 ---
double maxPositiveIntensity = statisticService.CalcuMaxPositiveIntensity(strikes);
double maxNegativeIntensity = statisticService.CalcuMaxNegativeIntensity(strikes);
double avgAbsoluteIntensity = statisticService.CalcuAbsAvgIntensity(strikes);

Console.WriteLine($"=== 雷电流强度汇总 ===");
Console.WriteLine($"最大正闪强度: {maxPositiveIntensity} A");
Console.WriteLine($"最大负闪强度: {maxNegativeIntensity} A");
Console.WriteLine($"平均绝对强度: {avgAbsoluteIntensity} A");

// --- 计数统计 ---
long totalStrikes = statisticService.CalcuSumNum(strikes);
long positiveStrikes = statisticService.CalcuPositiveSumNum(strikes);
long negativeStrikes = statisticService.CalcuNegativeSumNum(strikes);

Console.WriteLine($"\n=== 雷击次数汇总 ===");
Console.WriteLine($"总雷击次数: {totalStrikes}");
Console.WriteLine($"正闪 (CG+): {positiveStrikes}");
Console.WriteLine($"负闪 (CG-): {negativeStrikes}");

// --- 雷电日 ---
// 计算某地区的雷电日数
var strikeDays = statisticService.GetLightningStrikesDays(strikes, "中国");
Console.WriteLine($"\n=== 雷电日 ===");
Console.WriteLine($"行政区域: {strikeDays.AdministrativeName}");
Console.WriteLine($"总雷电日数: {strikeDays.LightningStrikeDays}");

// --- 闪电密度 (Ng) ---
// Ng = 年均地闪密度 (次/km²/年)
double ngValue = statisticService.CalcuNg(totalStrikes, 1000.0, 5.0);
Console.WriteLine($"\n=== 闪电密度 ===");
Console.WriteLine($"Ng: {ngValue:F2} 次/km²/年 (基于 1000 km² 区域, 5年)");

// --- 雷电流累计概率分布 ---
var probabilityDist = statisticService.CalcuProbabilityDistribution(strikes);
Console.WriteLine($"\n=== 雷电流累计概率 ===");
foreach (var kvp in probabilityDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"强度 >= {kvp.Key} A: {(kvp.Value * 100):F2}%");
}

// --- 雷电流强度区间概率 ---
var intensityRange = statisticService.CalcuIntensityProbabilityDistribution(strikes);
Console.WriteLine($"\n=== 强度区间分布 ===");
foreach (var kvp in intensityRange)
{
    Console.WriteLine($"区间 {kvp.Key}: {(kvp.Value * 100):F2}%");
}
```

### 第六步：雷电公报报告生成

为特定行政区域生成完整的雷电公报报告。

```csharp
using LLDSA.Service;

var statisticService = new StrikesDistributionStatisticService();

// 为指定区域生成完整的雷电公报描述
string bulletinText = statisticService.ProcessLightningBulletinDesc(
    strikes, 
    "湖南省"  // 替换为你的目标区域名称
);

Console.WriteLine("=== 雷电公报报告 ===");
Console.WriteLine(bulletinText);
```

### 第七步：按行政区域的闪电分布统计

按行政划分（地级市/县级）统计雷击次数分布。

```csharp
using LLDSA.Service;

var statisticService = new StrikesDistributionStatisticService();

// 获取地级市级别的闪电分布
var cityDist = statisticService.ProcessAreaDistribution(
    strikes, 
    AdministrativeLevel.Chi  // 地级市级别
);

Console.WriteLine("=== 按城市闪电分布 ===");
foreach (var kvp in cityDist.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value} 次");
}
```

---

## 面向对象设计与架构

### OOP 设计图

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/ObjectOrientedDesign.jpg" alt="OOP 设计" style="max-width:90%;">
</p>

### 架构设计图

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Architecture.png" alt="架构" style="max-width:90%;">
</p>

## 学术支撑

### 论文摘要

[![摘要1](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/%E6%91%98%E8%A6%81.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8E%E8%8D%A3.pdf)

[![摘要2](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Design-and-Implementation-of-Lightning-Analysis-Software-Based-on-Lightning-Location-System-Data--Abstract.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Design%20and%20Implementation%20of%20Lightning%20Analysis%20Software%20Based%20on%20Lightning%20Location%20System%20Data.pdf)

[![TechRxiv](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/LLSDA-TechRxiv-paper-abstract.png)](https://www.techrxiv.org/articles/preprint/LLSDA_Design_and_implementation_of_lightning_location_data_analysis_and_visualization/23615019)

### 引用格式 (BibTeX)

```bibtex
@misc{fan2023llsda,
  author = {Rong Fan and JingXiao Li and MingYuan Liu},
  title = {{LLSDA}: Design and Implementation of Lightning Location Data Analysis and Visualization},
  year = {2023},
  doi = {10.36227/techrxiv.23615019.v1},
  publisher = {TechRxiv}
}
```

## 作者

| **樊荣 Rong Fan** |
|:--:|
| <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/avatar-rong-fan.jpg" width="128" alt="Rong Fan"> |
| **Email**: [fanrong1985@126.com](mailto:fanrong1985@126.com) |
| [百度学术](https://xueshu.baidu.com/scholarID/CN-BM75JUJJ) / [Google Scholar](https://scholar.google.com/citations?user=Zxn84ckAAAAJ&hl=en) |

## 版本记录

| 版本 | 日期 | 更新内容 |
|------|------|----------|
| v1.0.0 | 2019-06-04 | 初始发布 - 雷电击相关类 |
| v1.0.1 | 2019-06-05 | 新增 StrikesDistributionStatistic 类，含多种时空统计方法 |
| v1.0.3 | 2019-06-10 | 新增文件操作类，用于识别 LLS 数据库文件 |
| v1.0.4 | 2019-06-11 | 添加角度、形状相关类 |
| v1.0.5 | 2019-06-13 | 新增点分析模块 |
| v1.0.6 | 2019-06-16 | 新增自定义分析模块 |
| v1.0.7 | 2019-06-23 | 遵循 SOLID 原则，重构为接口驱动 |
| v1.1.0 | 2019-06-24 | 新增面向对象设计图和架构设计图 |
| v1.2.0 | 2019-07-18 | 实现小时分布和月分布图 |
| v1.2.1 | 2019-07-23 | 新增年分布功能 |
| v1.2.1 | 2020-05-22 | 新增学术论文 |
| v1.2.2 | 2020-12-06 | 升级到 .NET Standard 2.1 / .NET 5.0；添加单元测试 |
| v1.2.3 | 2021-01-06 | 新增雷电流累计概率分布图、雷电玫瑰分布图 |
| v1.3.0 | 2021-09-05 | 多框架支持 (.NET 4.8 + .NET Standard 2.0)；Winform 客户端集成 MeteoInfo GIS |
| v1.4.0 | 2023-07-25 | TechRxiv 学术论文发表 (DOI: [10.36227/techrxiv.23615019.v1](https://doi.org/10.36227/techrxiv.23615019.v1)) |
| v1.4.1 | 2026-08-12 | README 大修；System.Drawing.Common 升级至稳定版；部署 GitHub Pages |

## 知识产权

* **代码部分**: [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0)
* **非代码部分**: [Creative Commons BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/deed.zh)
* 著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。

## 声明

由于知识有限、精力有限，不对开源版本提供任何使用质量保障和服务。
欢迎在 [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues) 区提出问题和意见建议。

## 贡献

我们欢迎社区贡献！如果您有意向成为项目的贡献者：

- **提交代码**：欢迎直接 Fork 本仓库并提交 PR
- **报告问题**：在 [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues) 区提交问题或建议
- **学术合作**：对雷电研究感兴趣？联系邮箱 [fanrong1985@126.com](mailto:fanrong1985@126.com)

## 鸣谢

* 肖稳安、高燚、陈鸿兵
* [南京信息工程大学 (NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [南京雷德尔信息科技有限公司](http://www.leader-tech.net)


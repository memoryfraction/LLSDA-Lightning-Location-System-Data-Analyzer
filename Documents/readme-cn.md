[<kbd>中文</kbd>]() | [<kbd>English</kbd>](readme-en.md)

# 闪电定位系统数据分析器 (LLSDA)

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/LightningLocationSystemDataAnalyzer-LLDSA.svg)](https://www.nuget.org/packages/LightningLocationSystemDataAnalyzer-LLDSA/)
[![Version](https://img.shields.io/badge/Version-1.4.1-brightgreen.svg)]()
[![.NET](https://img.shields.io/badge/.NET-Framework%204.8%20%7C%20Standard%202.0-green.svg)](https://dotnet.microsoft.com)

> **开源、跨平台闪电定位系统数据分析类库**
> 提供闪电时空分布的统计分析与可视化功能。

---

## 目录

* [特性](#特性)
* [安装方法](#安装方法)
* [快速开始](#快速开始)
* [面向对象设计与架构](#面向对象设计与架构)
* [学术支撑](#学术支撑)
* [作者](#作者)
* [版本记录](#版本记录)
* [知识产权](#知识产权)
* [合作伙伴](#合作伙伴)
* [鸣谢](#鸣谢)

---

## 效果图

![主程序窗口](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/PrintScreen---Lightning-Location-System-Data-Analyzer---Desktop-Application.png)

## 简介

**LLSDA** (*Lightning Location System Data Analyzer*) 是一个开源、跨平台的类库，用于分析闪电定位系统数据。
它提供了闪电时空分布统计分析和可视化的核心功能。

- **避免重复劳动**：为不同研究团队提供统一的基础分析库
- **提高开发效率**：防雷工程师和气象学者可快速集成
- **开源贡献**：回馈开源社区和防雷行业

## 特性

| 特性 | 状态 |
|------|------|
| 跨平台 (.NET Framework 4.8 / .NET Standard 2.0) | :white_check_mark: |
| 多格式闪电文件解析 | :white_check_mark: |
| 时间分布分析（年/月/时） | :white_check_mark: |
| 空间分布统计 | :white_check_mark: |
| 基于经纬度的点分析 | :white_check_mark: |
| 自定义区域分析 | :white_check_mark: |
| 雷电玫瑰图 | :white_check_mark: |
| 电流强度概率图 | :white_check_mark: |
| GIS / Shapefile 叠加支持 | :white_check_mark: |

## 安装方法

**NuGet Package Manager Console:**

```powershell
Install-Package LightningLocationSystemDataAnalyzer-LLDSA
```

**.NET CLI:**

```bash
dotnet add package LightningLocationSystemDataAnalyzer-LLDSA
```

**PackageReference:**

```xml
<PackageReference Include="LightningLocationSystemDataAnalyzer-LLDSA" Version="*" />
```

## 快速开始

```csharp
using LLDSA;
using LLDSA.Entities.FileOperator;
using System.Collections.Generic;
using System.IO;
using System.Text;

var strikes = new List<BaseStrikeChina>();
var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\\2008_07_09.txt");

if (File.Exists(srcFile1))
{
    var fileProcessor = new LlsFileProcessor(srcFile1, Encoding.UTF8);
    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
}
```

> 更多示例请参考 [LLSDA.Client](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/tree/master/Code/LLSDA.Client).

## 面向对象设计与架构

### OOP 设计图

![OOP 设计](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/ObjectOrientedDesign.jpg)

### 架构设计图

![架构](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Architecture.png)

## 学术支撑

### 论文摘要

[![摘要1](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/%E6%91%98%E8%A6%81.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8A%E8%8D%A3.pdf)

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
| <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/avatar-rong-fan.jpg" width="128" height="150" alt="Rong Fan"> |
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
欢迎在 [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues) 区提出.

## 合作伙伴

如您对雷电有兴趣，正在攻读相关学位，从事相关研究，或有意向成为项目的贡献者：

- **提交代码**：欢迎直接 Fork 本仓库并提交 PR
- **报告问题**：在 [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues) 区提交问题或建议
- **学术合作**：联系邮箱 [fanrong1985@126.com](mailto:fanrong1985@126.com)

## 鸣谢

* 肖稳安、高燚、陈鸿兵
* [南京信息工程大学 (NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [南京雷德尔信息科技有限公司](http://www.leader-tech.net)

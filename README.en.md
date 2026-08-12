<a href="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer"><img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/LLSDA-Icon.png" align="right" width="64" height="64"></a>

[<kbd>English</kbd>]() | [<kbd>中文</kbd>](README.zh-CN.md)

# LLSDA - Lightning Location System Data Analyzer

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/LightningLocationSystemDataAnalyzer-LLDSA.svg)](https://www.nuget.org/packages/LightningLocationSystemDataAnalyzer-LLDSA/)
[![.NET](https://img.shields.io/badge/.NET-Framework%204.8%20%7C%20Standard%202.0-green.svg)](https://dotnet.microsoft.com)

> **An open-source, cross-platform class library for analyzing lightning location system data**
> providing statistical analysis and visualization of lightning time/space distribution.

---

## Demo Screenshot

[![Screenshot](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/PrintScreen%20-%20Lightning%20Location%20System%20Data%20Analyzer%20-%20Desktop%20Application.png))

## Brief Introduction

**LLSDA** (*Lightning Location System Data Analyzer*) is an open-source, cross-platform class library
for analyzing lightning location system data. It provides essential statistical analysis and
visualization capabilities for lightning time and spatial distribution studies.

- Prevents duplication of effort across research groups
- Improves development efficiency for lightning protection engineers and meteorologists
- Contributes to the open-source community and the lightning protection industry

## Table of Contents

* [Features](#features)
* [Installation](#installation)
* [Quick Start](#quick-start)
* [Design & Architecture](#design--architecture)
* [Academic Publications](#academic-publications)
* [Author](#author)
* [Changelog](#changelog)
* [License](#license)
* [Contributing](#contributing)
* [Acknowledgements](#acknowledgements)

---

## Features

| Feature | Status |
|---------|--------|
| Cross-platform (.NET Framework 4.8 / .NET Standard 2.0) | :white_check_mark: |
| Lightning file parsing (multiple formats) | :white_check_mark: |
| Time distribution analysis (year/month/hour) | :white_check_mark: |
| Spatial distribution statistics | :white_check_mark: |
| Point analysis (lat/lng based queries) | :white_check_mark: |
| User-defined analysis regions | :white_check_mark: |
| Rose diagram chart | :white_check_mark: |
| Intensity probability chart | :white_check_mark: |
| GIS / Shapefile overlay support | :white_check_mark: |

## Installation

**Via NuGet Package Manager Console:**

```powershell
Install-Package LightningLocationSystemDataAnalyzer-LLDSA
```

**Via .NET CLI:**

```bash
dotnet add package LightningLocationSystemDataAnalyzer-LLDSA
```

**Via PackageReference:**

```xml
<PackageReference Include="LightningLocationSystemDataAnalyzer-LLDSA" Version="*" />
```

## Quick Start

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

> For more examples, refer to [LLSDA.Client](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/tree/master/Code/LLSDA.Client)

## Design & Architecture

### Object-Oriented Design

![OOP Design](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/ObjectOrientedDesign.jpg)

### Software Architecture

![Architecture](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Architecture.png)

## Academic Publications

### Paper Abstracts

[![Abstract 1](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Abstract.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8A%E8%8D%A3.pdf)

[![Abstract 2](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Design%20and%20Implementation%20of%20Lightning%20Analysis%20Software%20Based%20on%20Lightning%20Location%20System%20Data--Abstract.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Design%20and%20Implementation%20of%20Lightning%20Analysis%20Software%20Based%20on%20Lightning%20Location%20System%20Data.pdf)

[![TechRxiv](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/LLSDA%20TechRxiv%20paper%20abstract.png)](https://www.techrxiv.org/articles/preprint/LLSDA_Design_and_implementation_of_lightning_location_data_analysis_and_visualization/23615019)

### Citation (BibTeX)

```bibtex
@misc{fan2023llsda,
  author = {Rong Fan and JingXiao Li and MingYuan Liu},
  title = {{LLSDA}: Design and Implementation of Lightning Location Data Analysis and Visualization},
  year = {2023},
  doi = {10.36227/techrxiv.23615019.v1},
  publisher = {TechRxiv}
}
```

## Author

| **Rong Fan / 樊荣** |
|:--:|
| <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/avatar-rong-fan.jpg" width="128" height="150" alt="Rong Fan"> |
| **Email**: [fanrong1985@126.com](mailto:fanrong1985@126.com) |
| [**百度学术 - 樊荣**](https://xueshu.baidu.com/scholarID/CN-BM75JUJJ) |
| [**Google Scholar - Rong Fan**](https://scholar.google.com/citations?user=Zxn84ckAAAAJ&hl=en) |

## Changelog

| Version | Date | Changes |
|---------|------|---------|
| v1.0.0 | 2019-06-04 | Initial release - Lightning strike related classes |
| v1.0.1 | 2019-06-05 | Added StrikesDistributionStatistic class with time/spatial statistics |
| v1.0.3 | 2019-06-10 | Added file operator classes for LLS database parsing |
| v1.0.4 | 2019-06-11 | Added angle, shape, and shapeType classes |
| v1.0.5 | 2019-06-13 | Added point analysis module |
| v1.0.6 | 2019-06-16 | Added user-defined analysis module |
| v1.0.7 | 2019-06-23 | Refactored to follow SOLID principle (interface-based) |
| v1.1.0 | 2019-06-24 | New OOP design and architecture diagrams |
| v1.2.0 | 2019-07-18 | Hour and month distribution charts |
| v1.2.1 | 2019-07-23 | Year distribution feature |
| v1.2.1 | 2020-05-22 | Academic paper added |
| v1.2.2 | 2020-12-06 | Upgraded to .NET Standard 2.1 / .NET 5.0; unit tests added |
| v1.2.3 | 2021-01-06 | Intensity probability chart; rose diagram chart |
| v1.3.0 | 2021-09-05 | Multi-target: .NET 4.8 + .NET Standard 2.0; Winform app with GIS support |
| v1.4.0 | 2023-07-25 | Academic paper on TechRxiv (DOI: [10.36227/techrxiv.23615019.v1](https://doi.org/10.36227/techrxiv.23615019.v1)) |
| v1.4.1 | 2026-08-12 | README overhaul; System.Drawing.Common upgraded to stable; GitHub Pages deployed |

## License

* **Code**: [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0)
* **Non-code assets**: [Creative Commons BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/deed.en)

## Contributing

We welcome contributions from the community!

- **Feature requests / Bug reports**: Please open an [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues).
- **Pull Requests**: If you'd like to contribute code, feel free to fork the repository and submit a PR directly.
- **Academic collaboration**: Interested in lightning research? Contact: [fanrong1985@126.com](mailto:fanrong1985@126.com)

## Acknowledgements

* Xiao Wen'an, Gao Yi, Chen Hongbing
* [Nanjing University of Information Science & Technology (NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [Nanjing Leader Technology Co., Ltd.](http://www.leader-tech.net)
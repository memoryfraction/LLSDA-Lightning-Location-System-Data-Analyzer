[<kbd>English</kbd>]() | [<kbd>中文</kbd>](readme-cn.md)

# LLSDA - Lightning Location System Data Analyzer

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![NuGet](https://img.shields.io/nuget/v/LightningLocationSystemDataAnalyzer-LLDSA.svg)](https://www.nuget.org/packages/LightningLocationSystemDataAnalyzer-LLDSA/)
[![Version](https://img.shields.io/badge/Version-v1.4.1-brightgreen.svg)](#changelog)
[![.NET](https://img.shields.io/badge/.NET-Framework%204.8%20%7C%20Standard%202.0-green.svg)](https://dotnet.microsoft.com)

> **An open-source, cross-platform class library for analyzing lightning location system data**
> providing statistical analysis and visualization of lightning time/space distribution.

---

## Table of Contents

* [Features](#features)
* [Installation](#installation)
* [Quick Start — Step by Step](#quick-start----step-by-step)
* [Design & Architecture](#design--architecture)
* [Academic Publications](#academic-publications)
* [Author](#author)
* [Changelog](#changelog)
* [License](#license)
* [Contributing](#contributing)
* [Acknowledgements](#acknowledgements)

---

## Demo Screenshot

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/PrintScreen---Lightning-Location-System-Data-Analyzer---Desktop-Application.png" alt="Main Application Window" style="max-width:80%;">
</p>

## Brief Introduction

**LLSDA** (*Lightning Location System Data Analyzer*) is an open-source, cross-platform class library
for analyzing lightning location system data. It provides essential statistical analysis and
visualization capabilities for lightning time and spatial distribution studies.

- **Avoid duplication of effort** across research groups by providing a unified foundation library
- **Improve development efficiency** for lightning protection engineers and meteorologists
- **Contribute to open-source community** and the lightning protection industry

## Features

| Feature | Status |
|---------|--------|
| Cross-platform (.NET Framework 4.8 / .NET Standard 2.0) | :white_check_mark: |
| Lightning file parsing (multiple formats: ADTD, GLD360, WWLLN) | :white_check_mark: |
| Time distribution analysis (year/month/hour) | :white_check_mark: |
| Spatial distribution statistics (square grid / concentric circles) | :white_check_mark: |
| Point analysis (lat/lng based queries) | :white_check_mark: |
| User-defined analysis regions | :white_check_mark: |
| Lightning rose diagram | :white_check_mark: |
| Intensity probability chart | :white_check_mark: |
| GIS / Shapefile overlay support (via MeteoInfo) | :white_check_mark: |

## Installation

**Via NuGet Package Manager Console:**

```powershell
Install-Package LightningLocationSystemDataAnalyzer-LLDSA
```

**Via .NET CLI:**

```bash
dotnet add package LightningLocationSystemDataAnalyzer-LLDSA
```

**Via PackageReference (add to your .csproj):**

```xml
<PackageReference Include="LightningLocationSystemDataAnalyzer-LLDSA" Version="1.4.1" />
```

---

## Quick Start — Step by Step

> **Prerequisite**: You need a lightning location data file (`.txt` format from ADTD or similar LLS). 
> Sample data files are available in [`Documents/Sample Source Data/`](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/tree/master/Documents/Sample%20Source%20Data) in this repository.
> The sample file `2008_07_09.txt` contains lightning records from 2008.

### Step 1: Parse Lightning Data Files

The core class for reading Chinese LLS data files is `ADTDFileProcessor`. It reads text-formatted 
lightning records and converts them into strongly-typed objects.

```csharp
using LLDSA;
using LLDSA.Entities.FileOperator.LLSFileProcessor.ADTD;
using System.Collections.Generic;
using System.IO;
using System.Text;

// 1. Specify the data file path
string dataFilePath = @"data\2008_07_09.txt";

if (!File.Exists(dataFilePath))
{
    Console.WriteLine("Data file not found: " + dataFilePath);
    return;
}

// 2. Create the file processor and parse all records
var processor = new ADTDFileProcessor();
processor.SourceLlsFilePathName = dataFilePath;
processor.Province = "";  // Leave empty for national-level data
processor.Encode = Encoding.UTF8;

// Parse and get all lightning strike records
List<BaseStrikeChina> strikes = processor.ReturnStrikesChinaByProcess().ToList();

Console.WriteLine($"Successfully parsed {strikes.Count} lightning strike records.");

// Each record contains:
foreach (var strike in strikes.Take(3))
{
    Console.WriteLine($"Time: {strike.DateAndTime}, " +
        $"Lat: {strike.Latitude}, Lng: {strike.Longitude}, " +
        $"Intensity: {strike.Intensity} A");
}
```

**Supported File Formats:**

| Format | Processor Class | Namespace |
|--------|----------------|-----------|
| ADTD (China LLS) | `ADTDFileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.ADTD` |
| GLD360 (Global) | `GLD360FileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.GLD360` |
| WWLLN (Global) | `WWLLNFileProcessor` | `LLDSA.Entities.FileOperator.LLSFileProcessor.WWLLN` |

### Step 2: Time Distribution Analysis

Analyze when lightning strikes occur throughout the year, by month, and by hour. This is useful for 
understanding seasonal patterns and daily activity cycles.

```csharp
using LLDSA.Service;
using System.Linq;

// Create the statistics service
var statisticService = new StrikesDistributionStatisticService();

// --- Year Distribution ---
// Returns: Dictionary<year, count_of_strikes>
Dictionary<int, int> yearDist = statisticService.CalcuYearDistribution(strikes);
Console.WriteLine("=== Year Lightning Strike Distribution ===");
foreach (var kvp in yearDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value} strikes");
}

// --- Month Distribution ---
// Returns: Dictionary<month(1-12), count_of_strikes>
Dictionary<int, int> monthDist = statisticService.CalcuMonthDistribution(strikes);
Console.WriteLine("\n=== Month Lightning Strike Distribution ===");
foreach (var kvp in monthDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  Month {kvp.Key}: {kvp.Value} strikes");
}

// --- Hour Distribution ---
// Returns: Dictionary<hour(0-23), count_of_strikes>
Dictionary<int, int> hourDist = statisticService.CalcuHourDistribution(strikes);
Console.WriteLine("\n=== Hour Lightning Strike Distribution ===");
foreach (var kvp in hourDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"  {kvp.Key}:00 - {kvp.Value} strikes");
}

// --- Generate Human-Readable Text Reports ---
string yearReport = statisticService.GenerateYearDistributionText(strikes);
string monthReport = statisticService.GenerateMonthDistributionText(strikes);
string hourReport = statisticService.GenerateHourDistributionText(strikes);

Console.WriteLine("\n=== Auto-Generated Year Report ===");
Console.WriteLine(yearReport);
```

### Step 3: Spatial Distribution — Square Grid Analysis

Divide the area around a center point into a grid of squares and count strikes per cell. 
This is the most common spatial analysis method for lightning density mapping.

```csharp
using LLDSA.Entities.CommonEntities;
using System.Linq;

// Create a square grid centered at a specific coordinate
// Parameters: centerLongitude, centerLatitude, eachBoxLength(km), eachSideBoxNum
// This creates a 9x9 grid with each cell being 5km x 5km
double centerX = 118.85; // Beijing longitude
double centerY = 31.20;  // Beijing latitude

using (var analysis = new StrikesAnalysis_Square(centerX, centerY, 5.0, 9))
{
    // Process each strike — it will be assigned to the grid cell it falls in
    foreach (var strike in strikes)
    {
        analysis.ProcessStrikes(strike);
    }

    // Get results from each grid cell
    var shapes = analysis.Shapes;
    Console.WriteLine($"=== Square Grid Analysis: 9x9, 5km per cell ===");
    Console.WriteLine($"Center: ({centerX}, {centerY})");
    Console.WriteLine($"Total cells with strikes: {shapes.Count(s => s.StrikeCount > 0)}");

    // Find the cell with the most strikes (hotspot)
    var maxCell = shapes.OrderByDescending(s => s.StrikeCount).FirstOrDefault();
    if (maxCell != null)
    {
        Console.WriteLine($"Hotspot cell: {maxCell.StrikeCount} strikes");
    }

    // Print all cell statistics
    foreach (var shape in shapes)
    {
        if (shape.StrikeCount > 0)
        {
            Console.WriteLine($"Cell [{shape.Index}, {shape.LineIndex}] " +
                $"Center:({shape.Center.Longitude},{shape.Center.Latitude}), " +
                $"Strikes: {shape.StrikeCount}");
        }
    }
}
```

**Parameters Explained:**

| Parameter | Description | Typical Values |
|-----------|-------------|----------------|
| `centerLongitude` | Center point longitude | 110.0 ~ 125.0 for Eastern China |
| `centerLatitude` | Center point latitude | 20.0 ~ 45.0 for mainland China |
| `eachBoxLength` | Side length of each grid cell (km) | 3 ~ 10 km |
| `eachSideBoxNum` | Number of cells per side | 9, 11, 13 (odd numbers recommended) |

### Step 4: Spatial Distribution — Concentric Circle Analysis

Analyze lightning density in concentric circles around a center point. Useful for 
radial distribution studies and risk assessment at specific locations.

```csharp
using LLDSA.Entities.CommonEntities;
using System.Linq;

// Create a concentric circle analysis
// Parameters: centerLongitude, centerLatitude, radius_km, num_rings
double centerX = 118.85;
double centerY = 31.20;

using (var analysis = new StrikesAnalysis_Circle(centerX, centerY, 3.0, 9))
{
    // Process all strikes
    foreach (var strike in strikes)
    {
        analysis.ProcessStrikes(strike);
    }

    // Get results from each ring
    var shapes = analysis.Shapes;
    Console.WriteLine($"=== Circle Analysis: 9 rings, radius 3km ===");

    foreach (var shape in shapes)
    {
        if (shape.StrikeCount > 0)
        {
            Console.WriteLine($"Ring {shape.Index}: {shape.StrikeCount} strikes, " +
                $"Radius range: {shape.RadiusInner}~{shape.RadiusOuter} km");
        }
    }
}
```

### Step 5: Lightning Statistics Summary

Calculate comprehensive statistics including max/min intensity, lightning days, 
and flash density (Ng).

```csharp
using LLDSA.Service;
using System.Linq;

var statisticService = new StrikesDistributionStatisticService();

// --- Intensity Statistics ---
double maxPositiveIntensity = statisticService.CalcuMaxPositiveIntensity(strikes);
double maxNegativeIntensity = statisticService.CalcuMaxNegativeIntensity(strikes);
double avgAbsoluteIntensity = statisticService.CalcuAbsAvgIntensity(strikes);

Console.WriteLine($"=== Lightning Intensity Summary ===");
Console.WriteLine($"Max positive intensity: {maxPositiveIntensity} A");
Console.WriteLine($"Max negative intensity: {maxNegativeIntensity} A");
Console.WriteLine($"Average absolute intensity: {avgAbsoluteIntensity} A");

// --- Count Statistics ---
long totalStrikes = statisticService.CalcuSumNum(strikes);
long positiveStrikes = statisticService.CalcuPositiveSumNum(strikes);
long negativeStrikes = statisticService.CalcuNegativeSumNum(strikes);

Console.WriteLine($"\n=== Strike Count Summary ===");
Console.WriteLine($"Total strikes: {totalStrikes}");
Console.WriteLine($"Positive (CG+): {positiveStrikes}");
Console.WriteLine($"Negative (CG-): {negativeStrikes}");

// --- Lightning Days ---
// Calculate the number of lightning days for a region
var strikeDays = statisticService.GetLightningStrikesDays(strikes, "China");
Console.WriteLine($"\n=== Lightning Days ===");
Console.WriteLine($"Administrative region: {strikeDays.AdministrativeName}");
Console.WriteLine($"Total lightning days: {strikeDays.LightningStrikeDays}");

// --- Flash Density (Ng) ---
// Ng = annual ground flash density (flashes / km² / year)
double ngValue = statisticService.CalcuNg(totalStrikes, 1000.0, 5.0);
Console.WriteLine($"\n=== Flash Density ===");
Console.WriteLine($"Ng: {ngValue:F2} flashes/km²/year (over 1000 km², 5 years)");

// --- Intensity Probability Distribution ---
var probabilityDist = statisticService.CalcuProbabilityDistribution(strikes);
Console.WriteLine($"\n=== Cumulative Intensity Probability ===");
foreach (var kvp in probabilityDist.OrderBy(x => x.Key))
{
    Console.WriteLine($"Intensity >= {kvp.Key} A: {(kvp.Value * 100):F2}%");
}

// --- Intensity Range Probability ---
var intensityRange = statisticService.CalcuIntensityProbabilityDistribution(strikes);
Console.WriteLine($"\n=== Intensity Range Distribution ===");
foreach (var kvp in intensityRange)
{
    Console.WriteLine($"Range {kvp.Key}: {(kvp.Value * 100):F2}%");
}
```

### Step 6: Lightning Bulletin Report Generation

Generate a comprehensive lightning bulletin report for a specific administrative region.

```csharp
using LLDSA.Service;

var statisticService = new StrikesDistributionStatisticService();

// Generate a complete lightning bulletin description for a region
string bulletinText = statisticService.ProcessLightningBulletinDesc(
    strikes, 
    "Hunan Province"  // Replace with your target region name
);

Console.WriteLine("=== Lightning Bulletin Report ===");
Console.WriteLine(bulletinText);
```

### Step 7: Area Distribution by Administrative Region

Count lightning strikes grouped by administrative subdivisions (prefecture/county level).

```csharp
using LLDSA.Service;

var statisticService = new StrikesDistributionStatisticService();

// Get distribution by prefecture-level cities
var cityDist = statisticService.ProcessAreaDistribution(
    strikes, 
    AdministrativeLevel.Chi  // City/prefecture level
);

Console.WriteLine("=== Lightning Distribution by City ===");
foreach (var kvp in cityDist.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value} strikes");
}
```

---

## Design & Architecture

### Object-Oriented Design

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/ObjectOrientedDesign.jpg" alt="OOP Design" style="max-width:90%;">
</p>

### Software Architecture

<p align="center">
  <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Architecture.png" alt="Architecture" style="max-width:90%;">
</p>

## Academic Publications

### Paper Abstracts

[![Abstract 1](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Abstract.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8E%E8%8D%A3.pdf)

[![Abstract 2](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/Design-and-Implementation-of-Lightning-Analysis-Software-Based-on-Lightning-Location-System-Data--Abstract.png)](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/blob/master/Documents/Design%20and%20Implementation%20of%20Lightning%20Analysis%20Software%20Based%20on%20Lightning%20Location%20System%20Data.pdf)

[![TechRxiv](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/LLSDA-TechRxiv-paper-abstract.png)](https://www.techrxiv.org/articles/preprint/LLSDA_Design_and_implementation_of_lightning_location_data_analysis_and_visualization/23615019)

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
| <img src="https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/raw/master/Images/avatar-rong-fan.jpg" width="128" alt="Rong Fan"> |
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

## Disclaimer

Due to limited knowledge and capacity, no usage quality guarantee or service is provided for the open-source version.
Feel free to raise questions or suggestions in [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues).

## Contributing

We welcome contributions from the community! If you would like to become a contributor, feel free to submit a PR directly, or report issues and suggestions via GitHub Issues.

- **Feature requests / Bug reports**: Please open an [Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues).
- **Pull Requests**: If you'd like to contribute code, feel free to fork the repository and submit a PR directly.
- **Academic collaboration**: Interested in lightning research? Contact: [fanrong1985@126.com](mailto:fanrong1985@126.com)

## Acknowledgements

* Xiao Wen'an, Gao Yi, Chen Hongbing
* [Nanjing University of Information Science & Technology (NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [Nanjing Leader Technology Co., Ltd.](http://www.leader-tech.net)


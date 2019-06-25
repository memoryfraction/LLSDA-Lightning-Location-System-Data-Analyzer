# LLSDA - Lightning Location System Data Analyzer

Readme: English | [中文](#简介)

## Part of the Result | 部分效果图
![image](/Images/LightningTimeDistributionChart-%E9%9B%B7%E7%94%B5%E6%97%B6%E9%97%B4%E5%88%86%E5%B8%83%E5%9B%BE.png)


## Brief Introduction
LLSDA is a public benefit project helps lightning protection engineer and lightning scientist to analyze lightning distribution. 
LLSDA(Lightning Location System Data Analyzer) is an cross platform class library for lightning location system using C# following .NET Standard 2.0 . It is the necessary part of all lightning time and spatial distribution analysis software.

## Introduction
Lightning is a violent and sudden electrostatic discharge where two electrically charged regions in the atmosphere temporarily equalize themselves, usually during a thunderstorm.

Lightning location meter, also known as lightning monitoring location meter, refers to the use of the sound, light, electromagnetic characteristics of the lightning return stroke radiation to telemetry lightning return stroke discharge parameters of an automatic weather detection equipment, it can detect the occurrence of lightning time, location, intensity, polarity, etc..People have been devoted to the research of lightning detection and early detection and prediction techniques and methods of thunderstorm disaster.

Lightning location system data analyzer, is basic data analysis library. The data development based on lightning location system will depend on the basic class library development of lightning location system.In order to prevent duplication of efforts, improve development efficiency, and make personal contributions to the open source community and lightning protection industry. I contribute this library to open source community.

Glad you like it.

## Features
* Build passing
* Based on .NET STANDARD 2.0 
* Cross platform


## Dependencies
* .NET Standard 2.0
* Newtonsoft
* Nuget: System.Drawing.Common


## How to use it
* download source code and compile
* go to bin, debug and find the *.dll file
* copy *.dll file to the target address and use it

## TODO List
* LLSDA.App (Plan to use Avalonia)

## Change Log
* V1.0.0(2019-6-4)
Lightning strike related classes

* V1.0.1(2019-6-5)
StrikesDistributionStatistic class added, which contains dozens of distribution statistic methods

* V1.0.3(2019-6-10)
Add File Operator classes

* V1.0.4(2019-6-11)
Add angle classes, shape, shapeType

* V1.0.5(2019-6-13)
Add PointAnalysis

* V1.0.6(2019-6-16)
Add UserDefinedAnalysis

* V1.0.7(2019-6-23)
Follow SOLID Principle to rely on Interfaces instead of Entities

* V1.1.0(2019-6-24)
New added OOP Design and Architecture

## OOP Design
![image](/Images/ObjectOrientedDesign.jpg)

## Architecture
![image](/Images/Architecture.png)

## Reference & Academic support
* Abstract
[![image](/Images/Abstract.png)](/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8A%E8%8D%A3.pdf)

## License
[Attribution-NonCommercial 4.0 International (CC BY-NC 4.0)](https://creativecommons.org/licenses/by-nc/4.0/)


## Donation
* Paypal: rong.fan1031@gmail.com
* You are welcome to buy me a coffee.

## Thanks to
* Wen'an Xiao(Supervisor)
* [Nanjing University of Information Science and Technology(NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [LeaderTech Co., Ltd](http://www.leader-tech.net)


## 简介
闪电，在大气科学中指大气中的强放电现象。在夏季的雷雨天气，雷电现象较为常见。它的发生与云层中气流的运动强度有关。有资料显示，冬季下雪时也可能发生雷电现象，即雷雪，但是发生机会相当微小。若有严重的火山爆发时，或是原子弹爆炸产生蘑菇云时，空中可能因短路而发生闪电。

闪电定位仪又称雷电监测定位仪，是指利用闪电回击辐射的声、光、电磁场特性来遥测闪电回击放电参数的一种监测雷电发生的自动化的气象探测设备，它可检测雷电发生的时间、位置、强度、极性等。人们一直在致力于闪电探测设各与雷暴灾害早期检侧、预报技术和方法的研究。

LLSDA(闪电定位系统数据分析器), 一款服务于雷电相关工作者的数据分析的基础类库。 基于闪电定位系统的数据开发的软件将必不可少的依赖于闪电定位系统的基础类库开发。 可以大幅度提高开发效率、避免重复劳动。

## 特性
* 编译通过
* 基于 .NET STANDARD 2.0 
* 跨平台


## 依赖项
* .NET Core 2.0版本及以上
* Newtonsoft
* Nuget: System.Drawing.Common


## 使用方法
* 下载源码并编译
* bin文件夹，Debug子文件夹，找到“LLSDA.dll”
* 复制“LLSDA.dll”到目标项目，添加引用，并使用


## 版本
* V1.0.0(2019-6-4)
新增LightningStrike相关类;

* V1.0.1(2019-6-5)
新增StrikesDistributionStatistic 类, 内含多种时间、空间统计方法;

* V1.0.3(2019-6-10)
新增文件操作类，用于识别LLS数据库文件; 和持久化内存数据到硬盘;

* V1.0.4(2019-6-11)
添加以下类: angle classes, shape 和 shapeType;

* V1.0.5(2019-6-13)
新增点分析相关类。 点分析，用于输入经纬度点后得到相关分析结果;

* V1.0.6(2019-6-16)
新增 UserDefinedAnalysis;

* V1.0.7(2019-6-23)
遵循SOLID原则，依赖于接口，而不是依赖于实体。 有利于解耦和开发、维护

* V1.1.0(2019-6-24)
新增面向对象设计图和架构设计图;

## 待完成
* LLSDA.App (范例代码项目。 计划使用跨平台UI:Avalonia，调用LLSDA.Entities来生成产品图。 欢迎推荐其他的跨平台UI项目。)

## 学术支撑
* Abstract
[![image](/Images/%E6%91%98%E8%A6%81.png)](/Documents/Calculation%20and%20Software%20Implementation%20of%20Ground%20Lightning-Flash%20Density-%E9%9B%B7%E5%87%BB%E5%A4%A7%E5%9C%B0%E5%AF%86%E5%BA%A6%E7%9A%84%E8%AE%A1%E7%AE%97%E4%B8%8E%E8%BD%AF%E4%BB%B6%E5%AE%9E%E7%8E%B0-Rong%20Fan-%E6%A8%8A%E8%8D%A3.pdf)


## 知识产权
[署名-非商业性使用 4.0 国际 (CC BY-NC 4.0)](https://creativecommons.org/licenses/by-nc/4.0/deed.zh)
* 解释: [谈谈创作共用许可证（Creative Commons licenses）- 阮一峰](http://www.ruanyifeng.com/blog/2008/04/creative_commons_licenses.html)


## 声明
由于知识有限，时间有限，不对开源版本提供任何使用质量保障和服务。
欢迎在[Issue](https://github.com/memoryfraction/LLSDA-Lightning-Location-System-Data-Analyzer/issues)区提出，我会尽力解答您的问题。


## 捐赠与支持
[支付宝二维码](/Images/%E6%94%AF%E4%BB%98%E5%AE%9D%E4%BA%8C%E7%BB%B4%E7%A0%81.JPG)


## 合作伙伴
如您对雷电有兴趣， 正在攻读相关学位，从事相关研究，相关行业从业人员或有意向成为项目的贡献者， 欢迎联系我: 1470269034@qq.com



## 鸣谢
* 导师：肖稳安
* [南京信息工程大学(NUIST)](https://en.nuist.edu.cn/)
* [Maharishi University of Management](https://www.mum.edu/)
* [南京雷德尔信息科技有限公司](http://www.leader-tech.net)

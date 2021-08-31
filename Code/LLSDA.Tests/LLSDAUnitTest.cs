using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LLSDA.Entities;
using LLSDA.Interface;
using NUnit.Framework;

namespace LLSDA.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadStrikesTest_Should_Work()
        {
            var strikes = new List<BaseStrikeChina>();
            var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , @"data\2008_07_09.txt");
            if (File.Exists(srcFile1))
            {
                var fileProcessor = new LlsFileProcessor(srcFile1, Encoding.UTF8);
                strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
            }
            Assert.IsTrue(strikes.Count > 0);
        }

    }
}
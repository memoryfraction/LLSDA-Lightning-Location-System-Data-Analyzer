using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LLDSA.Entities.FileOperator.LLSFileProcessor;
using LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike;
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
            var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory , @"data\LLS\ADTD\2008_07_09.txt");
            if (File.Exists(srcFile1))
            {
                var fileProcessor = new ADTDFileProcessor(srcFile1, Encoding.UTF8);
                strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
            }
            Assert.IsTrue(strikes.Count > 0);
        }


        [Test]
        public void LoadStrikesGLD360_Test_Should_Work()
        {
            var strikes = new List<LightningStrike_GLD360>();
            var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\LLS\GLD360\GLD360 2018_09_24_0800_24h 35N_43N_113E_119E.csv");
            if (File.Exists(srcFile1))
            {
                var fileProcessor = new GLD360FileProcessor(srcFile1, Encoding.UTF8);
                strikes.AddRange(fileProcessor.ReturnStrikes());
            }
            Assert.IsTrue(strikes.Count > 0);
        }

    }
}
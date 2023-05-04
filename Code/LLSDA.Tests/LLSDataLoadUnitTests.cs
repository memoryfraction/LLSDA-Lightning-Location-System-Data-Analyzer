using LLDSA.Entities.FileOperator.LLSFileProcessor.ADTD;
using LLDSA.Entities.FileOperator.LLSFileProcessor.GLD360;
using LLDSA.Entities.LightningStrikeLibrary.LightningLocationSystemData.Strike;
using LLSDA.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LLSDA.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadADTDStrikes_Test_Should_Work()
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
        public void LoadGLD360Strikes_Test_Should_Work()
        {
            var strikes = new List<LightningStrike_GLD360>();
            var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\LLS\GLD360\GLD360 2018_09_24_0800_24h 35N_43N_113E_119E.csv");
            if (File.Exists(srcFile1))
            {
                var fileProcessor = new GLD360FileProcessor(srcFile1, Encoding.UTF8);
                strikes.AddRange(fileProcessor.ReturnStrikes(skipTheFirstRow:true));
            }
            Assert.IsTrue(strikes.Count > 0);
        }

        [Test]
        public void LoadWWLLNStrikes_Test_Should_Work()
        {
            var strikes = new List<LightningStrike_WWLLN>();
            var srcFile1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\LLS\WWLLN\A20160820.loc");
            if (File.Exists(srcFile1))
            {
                var fileProcessor = new WWLLNFileProcessor(srcFile1, Encoding.UTF8);
                strikes.AddRange(fileProcessor.ReturnStrikes(skipTheFirstRow: false));
            }
            Assert.IsTrue(strikes.Count > 0);
        }

    }
}
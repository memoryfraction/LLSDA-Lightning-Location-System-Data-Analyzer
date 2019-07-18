﻿using LLSDA.Entities;
using LLSDA.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLSDA.Client.Winform
{
    public partial class Form1 : Form
    {
        List<BaseStrikeChina> strikes;
        public event EventHandler SrcFileLoadCompleted;
        public Form1()
        {
            InitializeComponent();
            SrcFileLoadCompleted += Form1_srcFileLoadCompleted;
            strikes  = ReadDataAsync().Result;      
        }

        private void Form1_srcFileLoadCompleted(object sender, EventArgs e)
        {
            // Enable buttons
            button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DrawMonthDistributionChart();
        }

        /// <summary>
        /// 读取源文件，并获取数据到内存;
        /// </summary>
        private Task<List<BaseStrikeChina>> ReadDataAsync()
        {
            return Task<List<BaseStrikeChina>>.Run(() => {
                var strikes = new List<BaseStrikeChina>();
                var str = System.AppDomain.CurrentDomain.BaseDirectory;
                var srcFile1 = (new System.IO.DirectoryInfo(str)).Parent.Parent.Parent.Parent.Parent.FullName + @"\Documents\Sample Source Data\2008_07_09.txt";
                var srcFile2 = (new System.IO.DirectoryInfo(str)).Parent.Parent.Parent.Parent.Parent.FullName + @"\Documents\Sample Source Data\2008_07_09.txt";
                if (File.Exists(srcFile1))
                {
                    var fileProcessor = new LlsFileProcessor(srcFile1, Encoding.UTF8);
                    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
                }

                if (File.Exists(srcFile2))
                {
                    var fileProcessor = new LlsFileProcessor(srcFile2, Encoding.UTF8);
                    strikes.AddRange(fileProcessor.ReturnStrikesChinaByProcess());
                }
                SrcFileLoadCompleted(this, new EventArgs());
                return strikes;
            });
        }

        private Dictionary<int, int> GetMonthDistributionPositive(IEnumerable<BaseStrikeChina> strikes)
        {
            // todo
            return null;
        }

        private Dictionary<int, int> GetMonthDistributionNegative(IEnumerable<BaseStrikeChina> strikes)
        {
            // todo
            return null;
        }

        private Dictionary<int, int> GetMonthDistribution(IEnumerable<BaseStrikeChina> strikes)
        {
            // todo
            return null;
        }

        private void DrawMonthDistributionChart()
        {
            if (strikes != null && strikes.Count > 0)
            {
                var positiveDistribution = GetMonthDistributionPositive(strikes);
                var negativeDistribution = GetMonthDistributionNegative(strikes);
                var Distribution = GetMonthDistribution(strikes);

                //todo draw chart and show
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissEphNet.Samples.WinForms46
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbProgress.Visible = false;
        }

        void RunTest()
        {
            var provider = new WinFormsTestProvider();
            using (var swetest = new SwephTest(provider))
            {
                swetest.RunTest();
                tbResult.Text = provider.OutputContent.ToString();
            }
        }
        void RunTestLoadAsync()
        {
            var provider = new WinFormsTestProviderAsync();
            using (var swetest = new SwephTest(provider))
            {
                swetest.RunTest();
                tbResult.Text = provider.OutputContent.ToString();
            }
        }
        async Task RunTestAsync()
        {
            var provider = new WinFormsTestProviderAsync();
            using (var swetest = new SwephTest(provider))
            {
                await Task.Run(() => swetest.RunTest());
                tbResult.Text = provider.OutputContent.ToString();
            }
        }

        private void StartRun()
        {
            btnRunTest.Enabled = false;
            btnRunTestLoadAsync.Enabled = false;
            btnRunTestAsync.Enabled = false;
            pbProgress.Visible = true;
            tbResult.Clear();
        }

        private void EndRun()
        {
            btnRunTest.Enabled = true;
            btnRunTestLoadAsync.Enabled = true;
            btnRunTestAsync.Enabled = true;
            pbProgress.Visible = false;
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            try
            {
                StartRun();
                RunTest();
            }
            finally
            {
                EndRun();
            }
        }

        private void btnRunTestLoadAsync_Click(object sender, EventArgs e)
        {
            try
            {
                StartRun();
                RunTestLoadAsync();
            }
            finally
            {
                EndRun();
            }
        }

        private async void btnRunTestAsync_Click(object sender, EventArgs e)
        {
            try
            {
                StartRun();
                await RunTestAsync();
            }
            finally
            {
                EndRun();
            }
        }
    }
}

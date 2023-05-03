using LLSDA.Interface;
using LLSDA.Service;
using LlsDataanalyzer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using MeteoInfoControlLibrary;

namespace LLSDA.Client.WinformApp
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            // IOC
            var services = new ServiceCollection();
            services.AddScoped<Form1>();
            services.AddScoped<MainForm>();
            services.AddScoped<DetailParamForm>();
            services.AddScoped<IStrikeFormatConvertService, StrikeFormatConvertService>();
            services.AddScoped<IStrikesDistributionStatisticService, StrikesDistributionStatisticService>();

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form1 = serviceProvider.GetRequiredService<Form1>();
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(form1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLU自动健康打卡
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        static void startLogin()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += timer_Elapsed;

            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Interval = 1000;
            Console.Read();
        }
            static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 得到 hour minute second  如果等于某个值就开始执行
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;
            // 定制时间,在00：00：00 的时候执行
            int iHour = 19;
            int iMinute = 29;
            int iSecond = 00;
            // 设置 每天的00：00：00开始执行程序
            if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            {
                //调用你要更新的方法
                System.Diagnostics.Process.Start("jlu-daily-reporter.exe");
            }
        }
    }
}

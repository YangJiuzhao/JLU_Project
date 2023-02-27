using BaseNetwork;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace JLU自动健康打卡
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine("a");
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("b");
        }

        private void Label_password_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("c");
        }

        private void Label_password_Click_1(object sender, EventArgs e)
        {
            //Console.WriteLine("d");
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            ehall = new Ehall
            {
                //Proxy = "127.0.0.1:8888"
            };
            ehall.Init();
            string user = this.textBox_account.Text;
            string psw = this.textBox_password.Text;
            label_result.Visible = true;
            label_result.Text = "登陆中...";
            if (ehall.Login(user, psw))
                label_result.Text = "登录成功!!!开始打卡...";
            else
            {
                label_result.Text = "登陆失败,请重试...";
                return;
            }
            string updata_time = this.textBox_time.Text;
            updata_times = Regex.Split(updata_time,"[:：]",RegexOptions.IgnoreCase);
            for (int i = 0; i < updata_times.Length; i++)
                updata_times[i] = Regex.Match(updata_times[i], "[1-9]+[0]*").Groups[0].Value;
            if (updata_times[0] != "")
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += timer_Elapsed;
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Interval = 1000;
            }
            else
                judge(ehall.UpData());
        }
        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // 得到 hour minute second  如果等于某个值就开始执行
            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;
            switch (updata_times.Length)
            {
                case 0:judge(ehall.UpData());break;
                case 1:
                    if (intHour.ToString() == updata_times[0] && intMinute == 0 && intSecond == 0)
                    {
                        judge(ehall.UpData());
                    }
                    else if (updata_times[0] == "")
                        judge(ehall.UpData());
                    break;
                case 2:
                    if (intHour.ToString() == updata_times[0] && intMinute.ToString() == updata_times[1] && intSecond == 0)
                    {
                        judge(ehall.UpData());
                    }
                    break;
                case 3:
                    if (intHour.ToString() == updata_times[0] && intMinute.ToString() == updata_times[1] && intSecond.ToString() == updata_times[2])
                    {
                        judge(ehall.UpData());
                    }
                    break;
                default:
                    judge(5);
                    break;
            }
        }
        static void judge(int flag)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            switch (flag)
            {
                case 0:
                    label_result.Text = "打卡成功!";
                     break;
                case 1: label_result.Text = "token获取失败!"; break;
                case 2: label_result.Text = "未到打卡时间!"; break;
                case 3: label_result.Text = "学生信息获取失败!"; break;
                case 4: label_result.Text = "学生信息提交失败!"; break;
                default: label_result.Text = "打卡时间错误!"; break;
            }
        }
        private static string[] updata_times;
        private static Ehall ehall;
    }
}

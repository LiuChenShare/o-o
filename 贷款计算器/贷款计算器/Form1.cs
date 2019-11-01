using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 贷款计算器
{
    public partial class Form1 : Form
    {
        private double Interest = 0;

        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;//设置视图
            //listView1.SmallImageList = imageList;//设置图标

            //添加列
            listView1.Columns.Add("期数", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("金额", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("利息", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("本金", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("剩余本金", 80, HorizontalAlignment.Left);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////添加行
            //var item = new ListViewItem();
            //item.ImageIndex = 1;
            //item.Text = "123"; //期数
            //item.SubItems.Add("30000"); //金额
            //item.SubItems.Add("100"); //利息
            //item.SubItems.Add("300"); //本金
            //item.SubItems.Add("9999"); //剩余本金

            //this.listView1.BeginUpdate();
            //listView1.Items.Add(item);
            //listView1.Items[listView1.Items.Count - 1].EnsureVisible();//滚动到最
            //this.listView1.EndUpdate();


            this.listView1.BeginUpdate();
            listView1.Items.Clear();
            var result = LoanCalculation(double.Parse(textBox1.Text), int.Parse(textBox3.Text), double.Parse(textBox2.Text));
            foreach (var item in result)
            {
                listView1.Items.Add(item);
            }
            label5.Text = Interest.ToString();
            //listView1.Items[listView1.Items.Count - 1].EnsureVisible();//滚动到最后
            this.listView1.EndUpdate();
        }

        /// <summary>
        /// 窗体变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_Resize(object sender, EventArgs e)
        {
            listView1.Height = this.ClientSize.Height - 180;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loanceiling">贷款总额</param>
        /// <param name="countMonth">贷款月数</param>
        /// <param name="lilv">年利率</param>
        /// <returns></returns>
        private List<ListViewItem> LoanCalculation(double loanceiling, int countMonth,double lilv)
        {
            List<ListViewItem> result = new List<ListViewItem>();

            double newlilv = lilv / 100 / 12;//月利率
            double Loan = loanceiling;//贷款总额
            double Total = 0;//还款总额
            double monthlypayments = 0;//月供
            double interest = 0;//总利息

            monthlypayments = Math.Round(Loan * newlilv * Math.Pow(1 + newlilv, countMonth) / (Math.Pow(1 + newlilv, countMonth) - 1), 2);//月供
            
            Total = Math.Round(monthlypayments * countMonth, 2);
            interest = Math.Round(Total - Loan, 2);
            Interest = interest;


            double capital = loanceiling;
            for (int i = 1; i<= countMonth;i++)
            {
                var aaaaa = capital * newlilv;//当期利息
                var bbbbb = monthlypayments - aaaaa;//当期本金
                var ccccc = capital - bbbbb;//剩余本金
                capital = ccccc;

                //添加行
                var item = new ListViewItem();
                item.ImageIndex = 1;
                item.Text = i.ToString(); //期数
                item.SubItems.Add(monthlypayments.ToString()); //金额
                item.SubItems.Add(aaaaa.ToString()); //利息
                item.SubItems.Add(bbbbb.ToString()); //本金
                item.SubItems.Add(ccccc.ToString()); //剩余本金
                result.Add(item);
            }
            return result;
        }


        /// <summary>
        /// 商业贷款-根据贷款总额计算
        /// </summary>
        /// <param name="loanceiling">贷款总额</param>
        /// <param name="countYears">按揭年数</param>
        /// <param name="lilv">年利率</param>
        /// <param name="paymentType">还款方式</param>
        /// <returns></returns>
        private string returnResult(double loanceiling, int countYears, double lilv, string paymentType)
        {
            StringBuilder json = new StringBuilder();
            double newlilv = lilv / 100 / 12;//月利率
            double Loan = loanceiling;//贷款总额
            double monthlypayments = 0;//平均月供
            double Total = 0;//还款总额
            double Interest = 0;//总利息
            switch (paymentType.Trim())
            {
                case "debx"://等额本息
                    monthlypayments = Math.Round((Loan * newlilv * Math.Pow(1 + newlilv, countYears * 12)) / (Math.Pow(1 + newlilv, countYears * 12) - 1), 2);

                    Total = Math.Round(monthlypayments * countYears * 12, 2);
                    Interest = Math.Round(Total - Loan, 2);
                    json.Append("{\"purchase\":\"略\",\"Loan\":\"" + Loan.ToString() + "\",\"Forthemonth\":\"" + monthlypayments.ToString() + "\",\"Total\":\"" + Total.ToString() + "\",\"Interest\":\"" + Interest.ToString() + "\",\"Shoufu\":\"0\",\"months\":\"" + countYears * 12 + "(月)" + "\"}");
                    break;
                case "debj"://等额本金
                    string monthsPay = string.Empty;
                    for (int i = 0; i < countYears * 12; i++)
                    {
                        monthlypayments = Loan / (countYears * 12) + (Loan - Loan / (countYears * 12) * i) * newlilv;
                        monthsPay += "第" + (i + 1) + "个月," + Math.Round(monthlypayments, 2) + "(元)\\r\\n";//月均金额
                        Total = monthlypayments + Total;//还款总额
                    }
                    Interest = Math.Round(Total - Loan, 2);
                    json.Append("{\"purchase\":\"略\",\"Loan\":\"" + Math.Round(Loan, 2) + "\",\"Forthemonth\":\"" + monthsPay.ToString() + "\",\"Total\":\"" + Math.Round(Total, 2) + "\",\"Interest\":\"" + Interest.ToString() + "\",\"Shoufu\":\"0\",\"months\":\"" + countYears * 12 + "(月)" + "\"}");
                    break;
            }
            return json.ToString();
        }

    }
}

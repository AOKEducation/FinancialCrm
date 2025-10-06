using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Model;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            //var totalBalance = db.Banks.Select (x=>x.BankBalance).Sum();
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + " ₺";

            // Son geelen havale

            var lastBankProcessAmount= db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).Select(y=>y.Amount ).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString() +" ₺";

            var lastBankDescription = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Description).FirstOrDefault();
            lblDescription.Text = "( "+lastBankDescription.ToString() +" )";

            // Chart 1 Kodları
            var bankData= db.Banks.Select(x=> new
            {
                x.BankTitle ,
                x.BankBalance
            }).ToList ();

            chart1.Series.Clear();

            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            // Chart 2 Kodları
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount
            }).ToList ();
            chart2.Series.Clear();
            
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            
            foreach (var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount );

            }


        }

        #region Buton aktiviteleri

        private void btnCategories_Click(object sender, EventArgs e)
        {
            FrmCategories frmCategories = new FrmCategories();
            frmCategories.Show();
            this.Hide();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void btnSpendings_Click(object sender, EventArgs e)
        {
            FrmSpendings frm = new FrmSpendings();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcess_Click(object sender, EventArgs e)
        {
            FrmBankProcess frmBankProcess = new FrmBankProcess();
            frmBankProcess.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
        #endregion



        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            //lblBillTitle.Text = count.ToString();
            if (count % 4 == 1)
            {
                var fatura = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası 2").Select(y => y.BillAmount).FirstOrDefault();

                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text =fatura.ToString () + " ₺";
            }
            if (count % 4 == 2)
            {
                var fatura = db.Bills.Where(x => x.BillTitle == "Doğalgaz").Select(y => y.BillAmount).FirstOrDefault();

                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = fatura.ToString() + " ₺";
            }
            if (count % 4 == 3)
            {
                var fatura = db.Bills.Where(x => x.BillTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();

                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = fatura.ToString() + " ₺";
            }
            if (count % 4 == 0)
            {
                var fatura = db.Bills.Where(x => x.BillTitle == "Internet Faturası").Select(y => y.BillAmount).FirstOrDefault();

                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = fatura.ToString() + " ₺";
            }
        }
    }
}
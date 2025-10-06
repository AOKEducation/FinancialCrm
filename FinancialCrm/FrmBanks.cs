using FinancialCrm.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace FinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1 ();
        
        private void FrmBanks_Load(object sender, EventArgs e)
        {
            #region Banka Bakiyeleri

            var ziraatBankBalance =
                     db.Banks
                    .Where(b => b.BankTitle == "Ziraat Bankası")
                    .Select(b => b.BankBalance)      
                    .FirstOrDefault();

            var vakifBankBalance =
                     db.Banks
                    .Where(b => b.BankTitle == "Vakıfbank")
                    .Select(b => b.BankBalance)
                    .FirstOrDefault();

            var isBankasiBalance =
                     db.Banks
                    .Where(b => b.BankTitle == "İş Bankası")
                    .Select(b => b.BankBalance)
                    .FirstOrDefault();

            lblbZiraatBankBalance.Text= string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:N2} ₺", ziraatBankBalance);

            lblVakifBankBalance.Text= string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:N2} ₺", vakifBankBalance);

            lblIsBankasiBalance.Text= string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:N2} ₺", isBankasiBalance);

            #endregion

            #region Banka Hareketleri

            var bankProcess1=db.BankProcesses.OrderByDescending(x=>x.BankProcessId).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;


            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;

            #endregion

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
            // Zaten bu formdayız, herhangi bir işlem yapmaya gerek yok

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
    }
}

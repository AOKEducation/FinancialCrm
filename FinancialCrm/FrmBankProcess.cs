using FinancialCrm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{

    public partial class FrmBankProcess : Form
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        bool process = false;
        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;

            var banks = db.Banks.Select(b => new { b.BankId, b.BankTitle }).ToList();

            cmbBanks.DataSource = banks;
            cmbBanks.DisplayMember = "BankTitle"; 
            cmbBanks.ValueMember = "BankId";
            process = true;
            cmbBanks.SelectedIndex=0;
            cmbBanks_SelectedIndexChanged(sender, e);
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
            // Zaten bu formdayız, herhangi bir işlem yapmaya gerek yok

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

        private void cmbBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBanks.SelectedValue != null && process)
            {
                int selectedBankId = Convert.ToInt32(cmbBanks.SelectedValue);

                var bankProcesses = db.BankProcesses
                                          .Where(bp => bp.BankId == selectedBankId)
                                          .Select(bp => new
                                          {
                                              bp.Description,
                                              bp.ProcessDate,
                                              bp.ProcessType,
                                              bp.Amount
                                          })
                                          .ToList();

                dataGridView1.DataSource = bankProcesses;
            }

        }
    }
}

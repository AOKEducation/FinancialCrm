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
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            InitializeComponent();
        }
        private void DataGridYenile()
        {
            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        FinancialCrmDbEntities1 db = new FinancialCrmDbEntities1();
        private void FrmCategories_Load(object sender, EventArgs e)
        {
            DataGridYenile();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            DataGridYenile();
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text;

            Categories categories = new Categories();
            categories.CategoryName = categoryName;
            db.Categories.Add(categories);
            db.SaveChanges();

            MessageBox.Show("Kategori Başarılı Bir Şekilde Sisteme Eklendi", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataGridYenile();
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);

            var removeValue = db.Categories.Find(id);

            db.Categories.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show("Silme İşlemi Başarılı Bir Şekilde Gerçekleşti", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            DataGridYenile();

        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            string categoryName = txtCategoryName.Text;




            var values = db.Categories.Find(id);

            values.CategoryName = categoryName;
            db.SaveChanges();

            MessageBox.Show("Kategori Başarılı Bir Şekilde Güncellendi", "Kategori İşlemleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            DataGridYenile();
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

    }
}

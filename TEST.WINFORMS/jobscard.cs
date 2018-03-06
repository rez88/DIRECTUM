using System;
using System.Linq;
using System.Windows.Forms;
using TEST.WINFORMS.validating;

namespace TEST.WINFORMS
{
    public partial class jobscard : Form
    {
        public jobscard()
        {
            InitializeComponent();
            txtFamily
                .ValidateControl()
                .IsNotNullOrWhitespace();
            txtName
               .ValidateControl()
               .IsNotNullOrWhitespace();
            gbSex
                .ValidateControl()
                .IsTrue(ctl => rbfemale.Checked || rbmale.Checked, "необходимо указать пол");
            dbdateBirth
                .ValidateControl()
                .IsTrue(ctl =>ctl.Value<=DateTime.Now,"укажите дату рождения");
            mtbserpass
                .ValidateControl()
                .IsNotNullOrWhitespace();
            mtbnumpass
               .ValidateControl()
               .IsNotNullOrWhitespace();
            txtmvd
                .ValidateControl()
               .IsNotNullOrWhitespace();
           dtpdatemvd
                .ValidateControl()
                .IsTrue(ctl => ctl.Value <= DateTime.Now, "укажите дату выдачи");
            mtbindreg
                 .ValidateControl()
                 .IsNotNullOrWhitespace();
            txtrgreg
                .ValidateControl()
                .IsNotNullOrWhitespace();
            txtcity
                .ValidateControl()
               .IsNotNullOrWhitespace();
            txtstrreg
                .ValidateControl()
               .IsNotNullOrWhitespace();
            txthomereg
                .ValidateControl()
               .IsNotNullOrWhitespace();

            if (dgvfamily.Rows.Count!=0)
            {
                txtFIO
               .ValidateControl()
               .IsNotNullOrWhitespace();
                txtrelative
                    .ValidateControl()
               .IsNotNullOrWhitespace();
                dtbirthrel
                .ValidateControl()
                .IsTrue(ctl => ctl.Value <= DateTime.Now, "укажите дату рождения");
            }
            
            if (dgvjobs.Rows.Count!=0)
            {
                txtplace
                    .ValidateControl()
                    .IsNotNullOrWhitespace();
                txtpos
                    .ValidateControl()
                    .IsNotNullOrWhitespace();
                mtbexp
                    .ValidateControl()
                    .IsNotNullOrWhitespace();
            }


            butSave
                 .ValidateControl()
                 .EnableByValidationResult();
        }

        private void btnfamily_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvfamily);
            row.Cells[0].Value = txtFIO.Text;
            row.Cells[1].Value = txtrelative.Text;
            row.Cells[2].Value = dtbirthrel.Value.ToString(@"dd\/MM\/yyyy");
            dgvfamily.Rows.Add(row);
            
           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvjobs);
            row.Cells[0].Value = txtplace.Text;
            row.Cells[1].Value = txtpos.Text;
            row.Cells[2].Value = mtbexp.Text;
            dgvjobs.Rows.Add(row);

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            var buttons = gbSex.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            MessageBox.Show(
                lbFamily.Text+": "+txtFamily.Text+"\n"+
                lbName.Text+": "+txtName.Text+"\n"+
                lbSurname.Text+": "+txtSurname.Text+"\n"+
                lbSex.Text+": "+buttons.Text+"\n"+
                lbdatebirth.Text+": "+dbdateBirth.Value.ToString(@"dd.MM.yyyy") +"\n" +
                lbserpass.Text+": "+mtbserpass.Text+ "\n" +
                lbnumpass.Text+": "+mtbnumpass.Text+ "\n" +
                lbmvd.Text+": "+txtmvd.Text+ "\n" +
                lbdatemvd.Text+": "+dtpdatemvd.Value.ToString(@"dd.MM.yyyy")+ "\n" +
                lbinn.Text+": "+mtbinn.Text+ "\n"+
                lbindreg.Text+": "+mtbindreg.Text+"\n"+
                lbrgreg.Text+": "+txtrgreg.Text+"\n"+
                lbcity.Text+": "+txtcity.Text+"\n"+
                lbstrreg.Text+": "+txtstrreg.Text+"\n"+
                lbhomereg.Text+": "+txthomereg.Text+ "\n"+
                lbhosreg.Text + ": " + txthosreg.Text + "\n" +
                lbapreg.Text + ": " + txtapreg.Text + "\n" +
                lbindres.Text + ": " + mtbindres.Text + "\n" +
                lbrgres.Text + ": " + txtrgres.Text + "\n" +
                lbcityres.Text + ": " + txtcityres.Text + "\n" +
                lbstrres.Text + ": " + txtstrres.Text + "\n" +
                lbhomres.Text + ": " + txthomres.Text + "\n" +
                lbhosre.Text + ": " + txthosres.Text + "\n" +
                lbapres.Text + ": " + txtapres.Text + "\n"
                , "Карточка сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

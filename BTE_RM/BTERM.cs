using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using System.IO;
using System.Threading;

namespace BTE_RM
{
    public partial class BTERM : Form
    {
       
     
      
        OmrCreate omr_create = new OmrCreate();
        Thread save;
        Upload_OMR updOmr = new Upload_OMR();
       
        public int desimaltoint = 0;
      
        int Get_Progracess_valu;
      public  int break_for = 0;

        private static BTERM userBTERM;

        public static BTERM getBTER
        {
            get
            {
                if (userBTERM == null)
                    userBTERM = new BTERM();
                return userBTERM;
            }
        }

        public BTERM()
        {
            InitializeComponent();
            panelProfile.Visible = false;
            panelProfileSerch.Visible = true;
        }
    
        public PictureBox barpic
        {
            get { return pictureBoxbarprogra; }
            set { pictureBoxbarprogra = value; }
        }

        public BackgroundWorker backwork
        {
            get { return backgroundWorker1; }
            set { backgroundWorker1 = value; }
            
        }
        public Label lablfari
        {
            get { return labelfarid; }
            set { labelfarid = value; }
        }
        public Panel getpanelmainwindo
        {
            get { return this.panelmainwindo; }
            set { this.panelmainwindo = value; }
        }
        public TabControl gettap
        {
            get { return tabControl1; }
        }
        public Button getdeveloperbutton
        {
            get { return devloperbutton; }
        }
        private void devloperbutton_Click(object sender, EventArgs e)
        {
            getpanelmainwindo.Controls.Clear();
            About_Developer aba = new About_Developer();
            getpanelmainwindo.Controls.Add(aba);
        }

        private void BTERM_Load(object sender, EventArgs e)
        { 
            userBTERM = this;


            updOmr.initcamera();
            omr_create.barprogpic();

        }

        private void Start_Click(object sender, EventArgs e)
        {
            labeldelet.Text = "";
            break_for = 0;
            decimal data;
            if (!decimal.TryParse(textBox1.Text.Trim(), out data))
            {
                MessageBox.Show("Please Enter Decimal Number!!");
            }
            else
            {
                desimaltoint = (int)data;
            }
            omr_create.brak();
            omr_create.select_folder();
         

            backgroundWorker1.RunWorkerAsync();
            

        }

        private void Search_button_Profile_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;
            panelProfileSerch.Visible = false;

          
        }

        private void buttonRefreshP_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonRefreshP_Click_1(object sender, EventArgs e)
        {
            panelProfile.Visible = false;
            panelProfileSerch.Visible = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          
           omr_create.bar(e.ProgressPercentage);

            Get_Progracess_valu = e.ProgressPercentage;

            labelPrograses.Text = string.Format("Processing..{0}/{1}", e.ProgressPercentage, desimaltoint);
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            string message = null;
            if (Get_Progracess_valu != desimaltoint)
            {
                message = " Processing uncompleted...!!!!";
                labelPrograses.Text = string.Format("Processing..{0}/{1}{2}", Get_Progracess_valu, desimaltoint, message);

            }
            if (Get_Progracess_valu == desimaltoint)
            {
                
                labelPrograses.Text = "Don!!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            labeldelet.Text = "";
            break_for = 1;
            omr_create.brak();


        }

   
        private void buttonViewPDF_Click(object sender, EventArgs e)
        {
            omr_create.l = 0;
            omr_create.k = 0;
            printPreviewDialog1.Document = omr_create.pdf_view();
            printPreviewDialog1.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           if (omr_create.Folder!= null)
            {
             
                omr_create.OMR_Image();
               
            }
          else
            {
                MessageBox.Show("Plase select Folder");
            }
        }

       

        private void buttonSavePDF_Click_1(object sender, EventArgs e)
        {
            omr_create.l = 0;
            omr_create.k = 0;
            save = new Thread(omr_create.pdf_save);
            save.Start();
           
        }

        private void buttonPrintPDF_Click(object sender, EventArgs e)
        {
            omr_create.l = 0;
            omr_create.k = 0;
            omr_create.pdf_print();

        }


        private void buttonDeletFile_Click(object sender, EventArgs e)
        {
            try
            {

                string sa =omr_create.Folder;

                foreach (string get in Directory.GetFiles(sa, "*.jpg"))
                {
                  
                        File.Delete(get);

                    // backgroundWorker1.ReportProgress(l);

                }
                // string sa = folder + "OMR0.jpg";        

               labeldelet.Text = "delet success";
            }
            catch (Exception)
            {
                MessageBox.Show("fill not found");

            }
        }

        private void BTERM_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                updOmr.stopcamera();
                timer1.Stop();

            }catch(Exception)
            { }

            try
            {


               omr_create.print.Abort();
                save.Abort();
               
            }catch(Exception)
            { }
              
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            omr_create.l = 0;
            omr_create.k = 0;
            save = new Thread(omr_create.pdf_barcode_save);
            save.Start();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panelmainwindo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Start_omer_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Start();
            updOmr.cameraActive();
        }

        private void pictureBoxbarcodechaker2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updOmr.timer_cheek();
        }
    }
}

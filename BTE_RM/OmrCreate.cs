using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Threading;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
namespace BTE_RM
{

    class OmrCreate
    {
        Random random_barcode;
        Bitmap progrbar;
        Graphics bgrap;
        public int bw, bh;
      public  int l = 0, k = 0;
        PrintDocument Pdf_save;
        PrintDocument Pdf_Print;
        PrintDocument Pdf_view;
        Image barimage;
        Image barimage1;
        Image barimage2;
        public  Thread print;

   

        string folder;
        int getdesimaltoint;
        int getbreak;
     
        public string Folder
        {
            get { return folder; }
            set { folder = value; }
        }

        public void valu()
        {
            getdesimaltoint = BTERM.getBTER.desimaltoint;
          
        }
     public void brak()
        {
           
   getbreak = BTERM.getBTER.break_for;
        }

        
        public PrintDocument pdf_view()
        {
            try
            {
                Pdf_view = new PrintDocument();

                Pdf_view.PrintPage += new PrintPageEventHandler(this.Pdf_view_PrintPage);
  
            }catch(Exception)
            {
                MessageBox.Show("Pdf viewing problem!!");
            }
            return Pdf_view;
        }

        private void Pdf_view_PrintPage(object sender, PrintPageEventArgs e)
        {
           
            Image pic = Properties.Resources.OMRBarcode;

            for (int o = l; o < getdesimaltoint + 1; o++)
            {
                k++;
                if (k <= 1)
                {
                    l++;
                    if (l <= getdesimaltoint)
                    {
                        try
                        {


                            //  string sa = folder + "OMR" + l.ToString() + ".jpg";

                            string barim = folder + "Bar1" + l.ToString() + ".jpg";
                            string barim1 = folder + "Bar2" + l.ToString() + ".jpg";
                            string barim2 = folder + "Bar3" + l.ToString() + ".jpg";

                            e.Graphics.DrawImage(pic, 175, 25);

                            barimage = Image.FromFile(barim);
                            barimage1 = Image.FromFile(barim1);
                            barimage2 = Image.FromFile(barim2);
                            e.Graphics.DrawImage(barimage, 220, 15);
                      
                            e.Graphics.DrawImage(barimage1, 220, 560);//old 525
                        
                            e.Graphics.DrawImage(barimage2, 220, 1035);///old 960

                            // string sa = folder + "OMR0.jpg";


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("fill not found");
                            break;
                        }

                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    k= 0;

                    e.HasMorePages = true;
                    return;
                }

            }


        }

        private void PDF_print()
        {
            try
            {
                Pdf_Print = new PrintDocument();

                Pdf_Print.PrintPage += new PrintPageEventHandler(this.Pdf_view_PrintPage);
                Pdf_Print.Print();
            }catch(Exception)
            {

            }
            
        }

        private void Pdf_Print_PrintPage(object sender, PrintPageEventArgs e)
        {

            Image pic = Properties.Resources.OMRBarcode;

            for (int o = l; o < getdesimaltoint + 1; o++)
            {
                k++;
                if (k <= 1)
                {
                    l++;
                    if (l <= getdesimaltoint)
                    {
                        try
                        {


                            //  string sa = folder + "OMR" + l.ToString() + ".jpg";

                            string barim = folder + "Bar1" + l.ToString() + ".jpg";
                            string barim1 = folder + "Bar2" + l.ToString() + ".jpg";
                            string barim2 = folder + "Bar3" + l.ToString() + ".jpg";

                            e.Graphics.DrawImage(pic, 175, 25);

                            barimage = Image.FromFile(barim);
                            barimage1 = Image.FromFile(barim1);
                            barimage2 = Image.FromFile(barim2);
                            e.Graphics.DrawImage(barimage, 220, 15);

                            e.Graphics.DrawImage(barimage1, 220, 560);//old 525

                            e.Graphics.DrawImage(barimage2, 220, 1035);///old 960


                            // string sa = folder + "OMR0.jpg";


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("fill not found");
                            break;
                        }

                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    k = 0;

                    e.HasMorePages = true;
                    return;
                }

            }

        }

        private void Pdf_pdf_barcode_save_PrintPage(object sender, PrintPageEventArgs e)
        {

          //  Image pic = Properties.Resources.OMRBarcode;

            for (int o = l; o < getdesimaltoint + 1; o++)
            {
                k++;
                if (k <= 1)
                {
                    l++;
                    if (l <= getdesimaltoint)
                    {
                        try
                        {


                            //  string sa = folder + "OMR" + l.ToString() + ".jpg";

                            string barim = folder + "Bar1" + l.ToString() + ".jpg";
                            string barim1 = folder + "Bar2" + l.ToString() + ".jpg";
                            string barim2 = folder + "Bar3" + l.ToString() + ".jpg";

                       //     e.Graphics.DrawImage(pic, 175, 25);

                            barimage = Image.FromFile(barim);
                            barimage1 = Image.FromFile(barim1);
                            barimage2 = Image.FromFile(barim2);
                            e.Graphics.DrawImage(barimage, 220, 15);

                            e.Graphics.DrawImage(barimage1, 220, 560);//old 525

                            e.Graphics.DrawImage(barimage2, 220, 1035);///old 960


                            // string sa = folder + "OMR0.jpg";


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("fill not found");
                            break;
                        }

                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    k = 0;

                    e.HasMorePages = true;
                    return;
                }

            }

        }

        public void pdf_save()
        {
            Pdf_save = new PrintDocument();
            Pdf_save.PrintPage += new PrintPageEventHandler(this.Pdf_Print_PrintPage);

            Pdf_save.Print();

        }

        public void pdf_barcode_save()
        {
            Pdf_save = new PrintDocument();
            Pdf_save.PrintPage += new PrintPageEventHandler(this.Pdf_pdf_barcode_save_PrintPage);

            Pdf_save.Print();

        }

        public void pdf_print()
        {


            PrintDialog printDialog = new PrintDialog(); // to choose printer
            printDialog.Document = Pdf_Print;
            try
            {
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    print = new Thread(PDF_print);
                    print.Start();

                }
            }catch(Exception)
            {
                MessageBox.Show("printing problem!!");
            }
          
        }

        public void barprogpic()
        {
          

            bw =  BTERM.getBTER.barpic.Width;
            bh = BTERM.getBTER.barpic.Height;
            progrbar = new Bitmap(bw, bh);
        }

      public void select_folder()
        {
            try
            {

          
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.SelectedPath = @"C:\Users\farid\Desktop\New folder (2)";
            fb.Description = "select project folder";
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    Folder = fb.SelectedPath + "\\";
                }
            }catch(Exception)
            {
                MessageBox.Show("Folder not Selected!!");
            }
        }


       public void Qrcode(int i)
        {
            for (int kp = 1; kp < 4; kp++)
            {


                try
                {
                    string code = kp.ToString() + i.ToString();

                    IBarcodeWriter writer = new BarcodeWriter
                    { Format = BarcodeFormat.QR_CODE };
                    Bitmap result = writer.Write(code);
                    Bitmap barcodeBitmap = new Bitmap(result, 100, 100);
                    string sa = "Bar"+ kp.ToString()+ i.ToString() + ".jpg";
                
                    try
                    {
                        barcodeBitmap.Save(Folder + sa);
                      
                    }
                    catch (Exception)
                    { }

                }
                catch (Exception)
                {
                    MessageBox.Show("QRcode createing problem!!");
                }

            }
        }

    


      public void OMR_Image()
        {
            valu();

            int j=0,l;
            random_barcode = new Random();
            try
            {
                for (l = 1; l <= getdesimaltoint; l++)
                {

                   try
                    { 
                        Qrcode(l);

                    }catch(Exception)
                    { }
                   
                    BTERM.getBTER.backwork.ReportProgress(l);

                    if (getbreak == 1)
                        break;
                }
                

            }
            catch (Exception)
            {

                MessageBox.Show("OMR creating problem!!");
            }

        }


     public void bar(int j)
        {
            try
            {

         
            bgrap = Graphics.FromImage(progrbar);
            bgrap.Clear(Color.White);
            bgrap.FillRectangle(Brushes.BlueViolet, new Rectangle(0, 0, (j * bw) / getdesimaltoint, bh));
            bgrap.DrawString(j + "%", new Font("Arial", bh / 2), Brushes.Black, new Point(bw / 2 - bh, bh / 10));

      
            BTERM.getBTER.barpic.Image = progrbar;
        }catch(Exception)
            {
                MessageBox.Show("progressBar Problem!!");
            }

         }



    }
}

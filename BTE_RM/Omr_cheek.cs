using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTE_RM
{
    class Omr_cheek
    {


        Graphics imageprocessing;
        Bitmap myimage;
        int reClolor1;
        int reClolor;
        Bitmap imagesize;
        Bitmap imageresize;

        int pixelCk;
        int imagewidth;
        int imageheight;
        int picboxheght;
        int picboxwidgh;

        bool right_wring = true;
        bool right_wring1 = true;

        List<circul_point> CirCul_POINT = new List<circul_point>();
        List<Point> circulPoint = new List<Point>();
        private bool V = true;
        private bool V1 = true;

        int cheackX = 0, cheackY = 0;
        int countX, countY, countValue, countValue1;
        int YcounterMAX1 = 0;
        int XcounterMAX1 = 0;
        private string fil;

        public void initi()
        {
           
            right_wring1 = false;
            right_wring = false;
            XcounterMAX1 = 0;
            countValue = 0;
            countValue1 = 0;
            countX = 0;
            YcounterMAX1 = 0;
          
            cheackX = 0; cheackY = 0;
            countX = 0; countY = 0;
          

            circulPoint.Clear();
            CirCul_POINT.Clear();
            OpenFileDialog pic = new OpenFileDialog();
            if (pic.ShowDialog().Equals(DialogResult.OK))
            {
                fil = pic.FileName;

            }
        }


        private void image()
        {

            for (int Imageheight = 0; Imageheight < picboxheght; Imageheight++)
            {

                for (int Imagewidgh = 1; Imagewidgh < picboxwidgh; Imagewidgh++)
                {
                    pixelCk = Imagewidgh - 1;

                    Color mainpixColor = imageresize.GetPixel(pixelCk, Imageheight);

                    // colorto = (int)Convert.ToInt32(mainpixColor);

                    int r = mainpixColor.R;
                    int g = mainpixColor.G;
                    int b = mainpixColor.B;
                    reClolor = (byte)(.299 * r + .587 * g + .114 * b);
                    //   reClolor = (byte)(r + g + b);

                    r = reClolor;
                    g = reClolor;
                    b = reClolor;
                    Color cc = Color.FromArgb(r, g, b);

                    if (reClolor >= 0 && reClolor < 15)
                    {
                        right_wring = true;
                        imageProceccing5(Imageheight, pixelCk);
                        right_wring1 = false;
                    }
                    else
                    {
                        if (right_wring)
                        {
                            right_wring1 = true;
                            right_wring = false;
                        }
                    }
                
                }
            }
        }


        public void imageProceccing5(int h, int w)
        {

            if (V)
                CirCul_POINT.Add(new circul_point(w, h));

            if (right_wring1)
            {

                if (V1)
                {
                    cheackX++;
                    V1 = false;
                    foreach (Point cp in circulPoint)
                    {
                        CirCul_POINT[XcounterMAX1].circul(cp.X, cp.Y);

                    }
                }
                else
                {
                    CirCul_POINT.Add(new circul_point(circulPoint[0].X, circulPoint[0].Y));

                    foreach (Point cp in circulPoint)
                    {
                        CirCul_POINT[CirCul_POINT.Count - 1].circul(cp.X, cp.Y);

                    }

                }

                circulPoint.Clear();
            }
            circulPoint.Add(new Point(w, h));


            for (int g = 0; g < CirCul_POINT.Count; g++)
            {
                if (CirCul_POINT[g].get_set(w, h))
                {
                    XcounterMAX1 = g;
                    V1 = true;

                }
            }


            V = false;

            countValue = 0;

        }


        public void maincalculation()
        {
            int valu = 0, valu1 = 0;
            int xcsmal = BTERM.getBTER.pictureBoxbarcodechaker.Width, xcbig = 0;
            int ycsmal = BTERM.getBTER.pictureBoxbarcodechaker.Height, ycbig = 0;
            int xb = 0, yb = 0, XY = 0, XY1 = 0;
            int xcsmal1 = BTERM.getBTER.pictureBoxbarcodechaker.Width, xcbig1 = 0;
            int ycsmal1 = BTERM.getBTER.pictureBoxbarcodechaker.Height, ycbig1 = 0, ycbig2 = 0;
            int ycbig3 = 0, ycsmal3 = BTERM.getBTER.pictureBoxbarcodechaker.Height;
            int ck = 0, ck1 = 0, ck2 = 0, ck3 = 0;
            #region fast
            Startagine:
            for (int po = CirCul_POINT.Count - 1; po >= 0; po--)
            {

                xcsmal = BTERM.getBTER.pictureBoxbarcodechaker.Width; xcbig = 0;
                ycsmal = BTERM.getBTER.pictureBoxbarcodechaker.Height; ycbig = 0;
                xb = 0; yb = 0; XY = 0; XY1 = 0;
                xcsmal1 = BTERM.getBTER.pictureBoxbarcodechaker.Width; xcbig1 = 0;
                ycsmal1 = BTERM.getBTER.pictureBoxbarcodechaker.Height; ycbig1 = 0; ycbig2 = 0;
                ycbig3 = 0; ycsmal3 = BTERM.getBTER.pictureBoxbarcodechaker.Height;
                ck = 0; ck1 = 0; ck2 = 0; ck3 = 0;

                if (CirCul_POINT[po].circul_Point.Count > 15 & CirCul_POINT[po].circul_Point.Count < 200)
                {
                  

                    for (int k = CirCul_POINT[po].circul_Point.Count - 1; k >= 0; k--)
                    {
                        ycbig1++;
                        //xxx
                        if (xcbig < CirCul_POINT[po].circul_Point[k].X)
                        {
                            xb = k;
                            xcbig = CirCul_POINT[po].circul_Point[k].X;
                        }
                        if (xcsmal > CirCul_POINT[po].circul_Point[k].X)
                        {
                            XY = k;
                            xcsmal = CirCul_POINT[po].circul_Point[k].X;
                        }

                        //yyy
                        if (ycbig < CirCul_POINT[po].circul_Point[k].Y)
                        {
                            xcbig1 = CirCul_POINT[po].circul_Point[k].X;

                            ycbig = CirCul_POINT[po].circul_Point[k].Y;

                        }
                        if (ycsmal > CirCul_POINT[po].circul_Point[k].Y)
                        {
                            ycbig2 = CirCul_POINT[po].circul_Point[k].X;

                            ycsmal = CirCul_POINT[po].circul_Point[k].Y;
                        }
                        //yy1

                        if (ycbig3 <= CirCul_POINT[po].circul_Point[k].Y)
                        {
                            yb = CirCul_POINT[po].circul_Point[k].X;

                            ycbig3 = CirCul_POINT[po].circul_Point[k].Y;
                        }
                        if (ycsmal3 >= CirCul_POINT[po].circul_Point[k].Y)
                        {
                            XY1 = CirCul_POINT[po].circul_Point[k].X;

                            ycsmal3 = CirCul_POINT[po].circul_Point[k].Y;
                        }

                    }
                }
                else
                {
                    CirCul_POINT.RemoveAt(po);
                    goto Startagine;
                }



                ck = ycbig2 - xcsmal;
                ck1 = xcbig - XY1;

                ck2 = xcbig1 - xcsmal;

                ck3 = xcbig - yb;

                if (ck != 0 & ck1 != 0 & ck2 != 0 & ck3 != 0)
                {

                  
                    //   ck=
                }
                else
                    CirCul_POINT.RemoveAt(po);

            }

            #endregion fast


            int big =BTERM.getBTER.pictureBoxbarcodechaker.Width;
            int big2 =BTERM.getBTER.pictureBoxbarcodechaker.Height;
            int big1 = 0;
            #region repalece
            /*

            ///xy repalece

            for (int po = 0; po< CirCul_POINT.Count ; po++)
            {


                for(int bp= po;bp < CirCul_POINT.Count; bp++)
                {
                    if( big2 >= CirCul_POINT[bp].circul_Point[0].Y)
                    {

                        big = CirCul_POINT[bp].circul_Point[0].X;
                        big2 = CirCul_POINT[bp].circul_Point[0].Y;

                        big1 = bp;
                    }
                    
                }
                

                CirCul_POINT[big1].circul_Point[0]= new Point(CirCul_POINT[po].circul_Point[0].X, CirCul_POINT[po].circul_Point[0].Y);
                CirCul_POINT[po].circul_Point[0] = new Point(big , big2);
                big = pictureBox1.Width;
                big2 = pictureBox1.Height;
            
            }
             */
            #endregion repalece


            big =BTERM.getBTER.pictureBoxbarcodechaker.Width;
            big2 = 0;

            int big3 =BTERM.getBTER.pictureBoxbarcodechaker.Height;
            big1 = 0;
            int c = 0;

            #region repalece1
            ///xy repalece1

            for (int po = 0; po < 25; po++)
            {

                big2 = CirCul_POINT[po].circul_Point[0].Y;
                big = CirCul_POINT[po].circul_Point[0].X;


                for (int bp = po; bp < 25; bp++)
                {

                    if (big2 <= CirCul_POINT[bp].circul_Point[0].Y)
                    {

                        c = CirCul_POINT[bp].circul_Point[0].Y - big2;
                        big2 = CirCul_POINT[bp].circul_Point[0].Y;
                    }
                    if (c >= 0 & c <= 4)
                    {

                        if (big >= CirCul_POINT[bp].circul_Point[0].X)
                        {

                            big = CirCul_POINT[bp].circul_Point[0].X;
                            big3 = CirCul_POINT[bp].circul_Point[0].Y;
                            big1 = bp;
                        }
                    }
                    else
                    {
                        goto startcountinu;
                    }
                }
                startcountinu:
                CirCul_POINT[big1].circul_Point[0] = new Point(CirCul_POINT[po].circul_Point[0].X, CirCul_POINT[po].circul_Point[0].Y);
                CirCul_POINT[po].circul_Point[0] = new Point(big, big3);
                big =BTERM.getBTER.pictureBoxbarcodechaker.Width;
                big3 =BTERM.getBTER.pictureBoxbarcodechaker.Height;
            }
            #endregion repalece1

            big =BTERM.getBTER.pictureBoxbarcodechaker.Width;
            big2 = 0;

            big3 = 0;
            big1 = 0;
            c = 0;

            #region repalece2
            ///xy repalece1

            for (int po = 25; po < CirCul_POINT.Count; po++)
            {
                big2 = CirCul_POINT[po].circul_Point[0].X;
                big3 = CirCul_POINT[po].circul_Point[0].Y;

                for (int bp = po; bp < CirCul_POINT.Count; bp++)
                {

                    if (big2 >= CirCul_POINT[bp].circul_Point[0].X)
                    {
                        big3 = CirCul_POINT[bp].circul_Point[0].Y;
                        big1 = bp;
                        big2 = CirCul_POINT[bp].circul_Point[0].X;
                    }
                }

                CirCul_POINT[big1].circul_Point[0] = new Point(CirCul_POINT[po].circul_Point[0].X, CirCul_POINT[po].circul_Point[0].Y);
                CirCul_POINT[po].circul_Point[0] = new Point(big2, big3);

            }
            #endregion repalece2

            big =BTERM.getBTER.pictureBoxbarcodechaker.Width;
            big2 = 0;

            big3 = 0;
            big1 = 0;
            c = 0;

            #region repalece3
            ///xy repalece1

            for (int po = 25; po < CirCul_POINT.Count; po++)
            {
                big2 = CirCul_POINT[po].circul_Point[0].X;
                big3 = CirCul_POINT[po].circul_Point[0].Y;

                for (int bp = po; bp < CirCul_POINT.Count; bp++)
                {

                    if (big2 <= CirCul_POINT[bp].circul_Point[0].X)
                    {
                        c = CirCul_POINT[bp].circul_Point[0].X - big2;

                        big2 = CirCul_POINT[bp].circul_Point[0].X;
                    }
                    if (c >= 0 & c < 6)
                    {
                        if (big3 >= CirCul_POINT[bp].circul_Point[0].Y)
                        {


                            big3 = CirCul_POINT[bp].circul_Point[0].Y;
                            big = CirCul_POINT[bp].circul_Point[0].X;
                            big1 = bp;
                        }

                    }
                    else
                        goto XYG;
                }
                XYG:
                CirCul_POINT[big1].circul_Point[0] = new Point(CirCul_POINT[po].circul_Point[0].X, CirCul_POINT[po].circul_Point[0].Y);
                CirCul_POINT[po].circul_Point[0] = new Point(big, big3);

            }
            #endregion repalece3

            #region count
            int CX = 0, CY = 0, CX1 = 0, CY1 = 0;
            int[] getcount = new int[50];
           
            for (int f = 0; f < 25; f++)
            {

                CX = CirCul_POINT[f + 35].circul_Point[0].X;
                CY = CirCul_POINT[f + 35].circul_Point[0].Y;

                for (int ff = 25; ff < 35; ff++)
                {
                    if ((CX >= CirCul_POINT[f].circul_Point[0].X - 5) & (CX <= CirCul_POINT[f].circul_Point[0].X + 5) & (CY >= CirCul_POINT[ff].circul_Point[0].Y - 5) & (CY <= CirCul_POINT[ff].circul_Point[0].Y + 5))
                    {

                        if (f == 0 & ff == 25)
                        {
                            CX1 = 1;
                        }
                        if (f == 0 & ff == 26)
                        {
                            CX1 = 2;
                        }
                        if (f == 0 & ff == 27)
                        {
                            CX1 = 3;
                        }
                        if (f == 0 & ff == 28)
                        {
                            CX1 = 4;
                        }
                        if (f == 0 & ff == 29)
                        {
                            CX1 = 5;
                        }
                        if (f == 0 & ff == 30)
                        {
                            CX1 = 6;
                        }
                        if (f == 0 & ff == 31)
                        {
                            CX1 = 7;
                        }
                        if (f == 0 & ff == 32)
                        {
                            CX1 = 8;
                        }
                        //end semester
                        //start rrsetc
                        if (f == 1 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 1 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 1 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 1 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 1 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 1 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 1 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 1 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 1 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 1 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 2
                        //star 3
                        if (f == 2 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 2 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 2 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 2 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 2 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 2 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 2 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 2 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 2 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 2 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 3
                        //star 4
                        if (f == 3 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 3 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 3 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 3 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 3 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 3 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 3 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 3 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 3 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 3 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 4
                        //star 5
                        if (f == 4 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 4 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 4 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 4 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 4 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 4 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 4 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 4 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 4 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 4 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 5                
                        //star 6
                        if (f == 5 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 5 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 5 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 5 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 5 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 5 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 5 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 5 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 5 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 5 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 6
                        //star 7
                        if (f == 6 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 6 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 6 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 6 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 6 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 6 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 6 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 6 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 6 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 6 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 7
                        //start 8
                        if (f == 7 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 7 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 7 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 7 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 7 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 7 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 7 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 7 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 7 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 7 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 8
                        //start 9
                        if (f == 8 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 8 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 8 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 8 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 8 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 8 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 8 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 8 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 8 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 8 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 9
                        //star 10
                        if (f == 9 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 9 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 9 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 9 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 9 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 9 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 9 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 9 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 9 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 9 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 10
                        //star 11
                        if (f == 10 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 10 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 10 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 10 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 10 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 10 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 10 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 10 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 10 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 10 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 11
                        //star 12
                        if (f == 11 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 11 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 11 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 11 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 11 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 11 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 11 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 11 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 11 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 11 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 12
                        //star 13
                        if (f == 12 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 12 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 12 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 12 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 12 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 12 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 12 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 12 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 12 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 12 & ff == 34)
                        {
                            CX1 = 9;
                        }

                        //end 13
                        //star 14

                        if (f == 13 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 13 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 13 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 13 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 13 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 13 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 13 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 13 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 13 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 13 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 14
                        //star 15
                        if (f == 14 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 14 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 14 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 14 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 14 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 14 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 14 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 14 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 14 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 14 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 15
                        //star 16
                        if (f == 15 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 15 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 15 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 15 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 15 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 15 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 15 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 15 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 15 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 15 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 16
                        //star 17
                        if (f == 16 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 16 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 16 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 16 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 16 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 16 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 16 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 16 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 16 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 16 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 17
                        //star 18
                        if (f == 17 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 17 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 17 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 17 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 17 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 17 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 17 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 17 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 17 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 17 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 18
                        //star 19
                        if (f == 18 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 18 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 18 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 18 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 18 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 18 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 18 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 18 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 18 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 18 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 19
                        //star 20
                        if (f == 19 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 19 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 19 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 19 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 19 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 19 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 19 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 19 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 19 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 19 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 20
                        //star 21
                        if (f == 20 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 20 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 20 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 20 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 20 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 20 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 20 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 20 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 20 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 20 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 21
                        //star 22
                        if (f == 21 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 21 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 21 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 21 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 21 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 21 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 21 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 21 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 21 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 21 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 22
                        //star 23
                        if (f == 22 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 22 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 22 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 22 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 22 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 22 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 22 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 22 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 22 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 22 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 23
                        //star 24
                        if (f == 23 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 23 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 23 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 23 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 23 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 23 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 23 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 23 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 23 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 23 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 24
                        //star 25
                        if (f == 24 & ff == 25)
                        {
                            CX1 = 0;
                        }
                        if (f == 24 & ff == 26)
                        {
                            CX1 = 1;
                        }
                        if (f == 24 & ff == 27)
                        {
                            CX1 = 2;
                        }
                        if (f == 24 & ff == 28)
                        {
                            CX1 = 3;
                        }
                        if (f == 24 & ff == 29)
                        {
                            CX1 = 4;
                        }
                        if (f == 24 & ff == 30)
                        {
                            CX1 = 5;
                        }
                        if (f == 24 & ff == 31)
                        {
                            CX1 = 6;
                        }
                        if (f == 24 & ff == 32)
                        {
                            CX1 = 7;
                        }
                        if (f == 24 & ff == 33)
                        {
                            CX1 = 8;
                        }
                        if (f == 24 & ff == 34)
                        {
                            CX1 = 9;
                        }
                        //end 25
                        getcount[CY1] = CX1;
                        CY1++;

                        Font drawFont = new Font("Arial", 5);
                        imageprocessing.DrawString(CX1.ToString(), drawFont, Brushes.Red, CirCul_POINT[f + 35].circul_Point[0].X, CirCul_POINT[f + 35].circul_Point[0].Y);

                    }
                }
            }
            string sem = null, kar = null, tec = null, roll = null, reg = null, ses = null, sub = null;
            #endregion count
            foreach (int i in getcount)
            {
                valu++;
                //semester
                if (valu == 1)
                    sem += i.ToString();
                //karikulam
                if (valu >= 2 & valu <= 3)
                    kar += i.ToString();
                //tecnology
                if (valu >= 4 & valu <= 5)
                    tec += i.ToString();
                //roll
                if (valu >= 6 & valu <= 11)
                    roll += i.ToString();
                //registration
                if (valu >= 12 & valu <= 17)
                    reg += i.ToString();
                //sesion
                if (valu >= 18 & valu <= 21)
                    ses += i.ToString();
                //sub code
                if (valu >= 22 & valu <= 25)
                    sub += i.ToString();
                if (valu == 25)
                    break;
            }
        }





    }

    public class circul_point
    {
        public List<Point> circul_Point = new List<Point>();
        public Point get_set_circul;

        bool tr = true;
        int k = 0;
        int l = 0, j = 0;
        bool ret = false;
        public circul_point(int w, int h)
        {
            get_set_circul = new Point(w, h);
            k = w;
            j = h;
        }

        public void circul(int x, int y)
        {
            circul_Point.Add(new Point(x, y));
        }

        public bool get_set(int w, int h)
        {
            ret = false;

            l = h - j;
            if (k == w & (l >= 0 & l <= 2))
            {
                j = h;
                k = w;
                ret = true;
            }

            return ret;
        }
    }
    }

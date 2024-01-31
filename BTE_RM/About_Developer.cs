using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTE_RM
{
    public partial class About_Developer : UserControl
    {


        private static About_Developer userBTERM;

        public static About_Developer getBTER
        {
            get
            {
                if (userBTERM == null)
                    userBTERM = new About_Developer();
                return userBTERM;
            }
        }


        public About_Developer()
        {
            InitializeComponent();
        }

        private void HOME_Click(object sender, EventArgs e)
        {
            BTERM.getBTER.getpanelmainwindo.Controls.Clear();
            BTERM.getBTER.getpanelmainwindo.Controls.Add(BTERM.getBTER.getdeveloperbutton);
            BTERM.getBTER.getpanelmainwindo.Controls.Add(BTERM.getBTER.gettap);
        
        }

       
    }
}

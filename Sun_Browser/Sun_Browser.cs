using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sun_Browser
{
    public partial class Sun_Browser : Form
    {
        public Sun_Browser()
        {
            InitializeComponent();

            webBrowser1.CanGoBackChanged +=
                new EventHandler(WbCanChanged);


        }

        #region 브라우저 이동
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddress.Text != "")
                {
                    webBrowser1.Navigate(txtAddress.Text);  // 주소창에 있는 주소를 기준으로 이동
                }
                else // 주소창이 비워져 있으면
                {
                    Debug.Print("현재 주소 : " + txtAddress.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 앞으로/뒤로가기 
        private void GoBackPage(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        private void WbCanChanged(object sender, EventArgs e)
        {
            btnBack.Enabled = webBrowser1.CanGoBack;    // Back Button을 누를 수 있을 때만 활성화
        }
        #endregion



    }
}

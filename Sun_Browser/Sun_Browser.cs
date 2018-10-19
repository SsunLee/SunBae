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

            webBrowser1.ScriptErrorsSuppressed = true;

            txtAddress.Text = @"about:blank";

            webBrowser1.CanGoBackChanged +=
                new EventHandler(Web_CanBack);
            webBrowser1.CanGoForwardChanged +=
                new EventHandler(Web_CanForward);

            webBrowser1.GoHome();

        }

        #region 브라우저 이동
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddress.Text != "")
                {
                    Navigate(txtAddress.Text);  // 주소창에 있는 주소를 기준으로 이동
                    txtLog.AppendText(ExportLog(txtAddress.Text));
                    
                }
                else // 주소창이 비워져 있으면
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Debug.Print("현재 주소 : " + txtAddress.Text);
            }
        }

        // Enter 쳤을 때
        private void EnterKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigate(txtAddress.Text);
                txtLog.AppendText( ExportLog(txtAddress.Text));
            }
        }

        // URL 가공
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
                
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // Load 저장하기
        private string ExportLog(String AddText)
        {
            string temp = null;

            temp = @"(접속)" + " " + DateTime.Now.ToString(@"yyyy/MM/dd/hh:mm:ss") + @" " + AddText + " " + "\n";

            return temp;

        }


        #endregion

        #region 앞으로/뒤로가기/홈화면
        private void GoBackPage(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        private void Web_CanBack(object sender, EventArgs e)
        {
            btnBack.Enabled = webBrowser1.CanGoBack;    // Back Button을 누를 수 있을 때만 활성화
        }
        private void GoForwardPage(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        private void Web_CanForward(object sender, EventArgs e)
        {
            btnForward.Enabled = webBrowser1.CanGoForward;    // Back Button을 누를 수 있을 때만 활성화
        }
        private void GoHomePage(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        #endregion

        #region 주소표시줄에 주소 표시
        private void ShowAddress(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtAddress.Text = webBrowser1.Url.ToString();
        }

        #endregion

    }
}

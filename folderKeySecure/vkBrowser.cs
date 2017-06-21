using System;
using System.Windows.Forms;

namespace folderKeySecure
{
    public partial class vkBrowser : Form
    {
        public vkBrowser()
        {
            InitializeComponent();

            authBrowser.Navigate(new Uri("https://oauth.vk.com/authorize?client_id="+work.util.id+"&redirect_uri=https://oauth.vk.com/blank.html&response_type=token"));
        }

        private void authBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tryThisUrlAsId(authBrowser.Url.ToString());
        }

        private void tryThisUrlAsId(string url)
        {
            if (url.Contains("user_id"))
            {
                authBrowser.Navigate(new Uri("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())"));
                new work.core().request("no_pass", url);
            }
        }
    }
}

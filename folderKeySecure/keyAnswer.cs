using System;
using System.Windows.Forms;

namespace folderKeySecure
{
    public partial class keyAsker : Form
    {
        public keyAsker()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            new work.core().request(password.Text, "no_vk");
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                new work.core().request(password.Text, "no_vk");
            }
        }

        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                {
                    return lang;
                }
            }
            return null;
        }
        private void password_Enter(object sender, EventArgs e)
        {
            SetKeyboardLayout(GetInputLanguageByName("eng"));
        }

        private void vkAuthRequest_Click(object sender, EventArgs e)
        {
            new vkBrowser().Show();
        }
        private void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }
    }
}

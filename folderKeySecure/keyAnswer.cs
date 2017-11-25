using folderKeySecure.work;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace folderKeySecure{
    public partial class keyAsker : Form {
        public string[] database_text = null;
        public keyAsker() {
           
            InitializeComponent();
        }

        private void keyAsker_Load(object sender, EventArgs e){
             // Получение доступа и запись информации в файл
            try {
                database_text = System.IO.File.ReadAllLines(util.pathApp + "base.ini");
            } catch (System.IO.DirectoryNotFoundException) {
                if (MessageBox.Show("Файл с базами данных паролей не найден на прежнем месте.", "Программа будет закрыта", MessageBoxButtons.OK) ==
                    DialogResult.OK){
                    Environment.Exit(0);
                };
            }
        }

        // Авторизация по нажатию кнопки
        private void authButton(object sender, EventArgs e){
            // Передача пароля
            string data = new work.core().open(database_text, password.Text);
                if (data == null) {
                    informer.Text = "Ошибка: Пароль неверный. Повторите попытку.";
                } else {
                    string[] splited = data.Split(':');
                    string open = splited[0];
                    informer.Text = "Пароль введен верно. Папка "+ splited[1] +" открыта.";
                    Process.Start(open);
                    password.Visible = false;
                    passwordChangerButton.Visible = true;
                    buttonAuthOpen.Visible = false;
                }
        }

        // Авторизация по нажатию Enter'а
        private void KeyPressed(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char) 13){
                string data = new work.core().open(database_text, password.Text);
                if (data == null) {
                    informer.Text = "Ошибка: Пароль неверный. Повторите попытку.";
                } else {
                    string[] splited = data.Split(':');
                    string open = splited[0];
                    informer.Text = "Пароль введен верно. Папка "+ splited[1] +" открыта.";
                    Process.Start(open);
                    password.Visible = false;
                    passwordChangerButton.Visible = true;
                    buttonAuthOpen.Visible = false;
                }
            }
        }

        // Определение eng мапы при открытии программы
        public static InputLanguage GetInputLanguageByName(string inputName){
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages){
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName)){
                    return lang;
                }
            }
            return null;
        }

        // Установка английского языка
        private void password_Enter(object sender, EventArgs e){
            InputLanguage.CurrentInputLanguage = GetInputLanguageByName("eng");
        }

        private void CloseMethod(object sender, EventArgs e) {
            Application.Exit();
        }

        private void showPasswordChangerDialog(object sender, EventArgs e)
        {
            
        }
    }
}

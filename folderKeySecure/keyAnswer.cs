using folderKeySecure.work;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace folderKeySecure{
    public partial class keyAsker : Form {

        public string[] database_text = null;
        Core init = new Core();
        int session_error = 0;

        public keyAsker() {
            InitializeComponent();
        }
        
        private void keyAsker_Load(object sender, EventArgs e) {
            try {
                // Попытка получить доступ к файлу и запись его в database_text
                database_text = System.IO.File.ReadAllLines(util.pathApp + "base.ini");
            } catch (System.IO.IOException) {
                // Если нажата OK -- программа закрывается
                if (MessageBox.Show("Файл с базами данных паролей не найден на прежнем месте.",
                    "Программа будет закрыта", MessageBoxButtons.OK) ==
                    DialogResult.OK){
                    Environment.Exit(1);
                };
            }
        }

        // Авторизация по нажатию кнопки
        private void authButton(object sender, EventArgs e) {
            // Передача пароля
            TryAuth(password);
        }

        // Авторизация по нажатию Enter'а
        private void KeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char) 13) {
                TryAuth(password);
            }
        }

        private void TryAuth(TextBox pass) {
            string[] data = init.Open(database_text, pass.Text);
            if (data == null) {
                session_error++;
                if (session_error >= 3) {
                    init.Log("\t ! Неверный пароль введен три или более раз. Закрытие программы.");
                    Application.Exit();
                }
                informer.Text = "Ошибка: Пароль неверный. Повторите попытку.";
            } else {
                try {
                    if (checkBoxToEditDb.Checked) {
                        new dataBaseEditor(database_text, data[1]).Show();
                        informer.Text = "Открыто редактирование БД.";
                    } else {
                        Process.Start(data[0]);
                        informer.Text = "Пароль введен верно. Папка " + data[1] + " открыта.";
                        Application.Exit();
                    }
                } catch (System.ComponentModel.Win32Exception) {
                    informer.Text = "Папка " + data[1] + " не найдена.\r\nОбратись к Игнатову Олегу за помощью с определением своей папки.";
                    init.Log("\t! Не найдена папка " + data[0]);
                }
                pass.Visible = false;
                buttonAuthOpen.Visible = false;
                showTimer.Tick -= showCheckButton;
                hideTimer.Start();
                this.TopMost = false;
            }
        }

        // Определение eng мапы при открытии программы
        public static InputLanguage GetInputLanguageByName(string inputName) {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages) {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName)) {
                    return lang;
                }
            }
            return null;
        }

        // Установка английского языка
        private void password_Enter(object sender, EventArgs e) {
            InputLanguage.CurrentInputLanguage = GetInputLanguageByName("eng");
        }

        private void showCheckButton(object sender, EventArgs e) {
            this.Height += 5;
            if (this.Height > this.MaximumSize.Height) {
                showTimer.Stop();
            }
        }

        private void keyAsker_MouseEnter(object sender, EventArgs e) {
            showTimer.Start();
        }

        private void hideCheckButton(object sender, EventArgs e) {
            this.Height -= 5;
            if (this.Height < this.MinimumSize.Height) {
                hideTimer.Stop();
            }
        }
    }
}

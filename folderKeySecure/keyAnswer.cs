﻿using folderKeySecure.work;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace folderKeySecure{
    public partial class keyAsker : Form {

        public string[] database_text = null;
        Core init = new Core();

        public keyAsker() {
            InitializeComponent();
        }

        /// <summary>
        /// Получение файла для работы в программе или закрытие программы с предупреждением о невозможности её работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyAsker_Load(object sender, EventArgs e){
            try {
                // Попытка получить доступ к файлу и запись его в database_text
                database_text = System.IO.File.ReadAllLines(util.pathApp + "base.ini");
            } catch (System.IO.DirectoryNotFoundException) {
                // Если нажата OK -- программа закрывается
                if (MessageBox.Show("Файл с базами данных паролей не найден на прежнем месте.",
                    "Программа будет закрыта", MessageBoxButtons.OK) ==
                    DialogResult.OK){
                    Environment.Exit(0);
                };
            }
        }

        // Авторизация по нажатию кнопки
        private void authButton(object sender, EventArgs e){
            // Передача пароля
            string[] data = init.Open(database_text, password.Text);
            if (data == null) {
                informer.Text = "Ошибка: Пароль неверный. Повторите попытку.";
            } else {
                informer.Text = "Пароль введен верно. Папка "+ data[1] +" открыта.";
                Process.Start(data[0]);
                password.Visible = false;
                passwordChangerButton.Visible = true;
                buttonAuthOpen.Visible = false;
            }
        }

        // Авторизация по нажатию Enter'а
        private void KeyPressed(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char) 13){
                string[] data = init.Open(database_text, password.Text);
               if (data == null) {
                    informer.Text = "Ошибка: Пароль неверный. Повторите попытку.";
                } else {
                    informer.Text = "Пароль введен верно. Папка "+ data[1] +" открыта.";
                    Process.Start(data[0]);
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

        private void showPasswordChangerDialog(object sender, EventArgs e)
        {
            
        }
    }
}

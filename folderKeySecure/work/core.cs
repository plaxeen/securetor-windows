using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace folderKeySecure.work
{
    class core
    {
        public void request(string password, string vkId)
        {
            string[] data = System.IO.File.ReadAllLines(util.pathApp + "base.ini");

            bool check = true;

            for (int i = 0; data.Length > i; i++)
            {
                string folder_temp, password_temp, username_temp, identifyVK_temp;

                byte[] decoding = Convert.FromBase64String(data[i]);
                data[i] = Encoding.UTF8.GetString(decoding);

                //получение конструкции типа — папка:пароль:имя:id
                string[] data_array = data[i].Split(':');
                folder_temp = data_array[0];
                password_temp = data_array[1];
                username_temp = data_array[2];
                identifyVK_temp = data_array[3];

                if (password.Contains(password_temp) | vkId.Contains(identifyVK_temp))
                {
                    open(folder_temp);
                    Console.WriteLine(vkId);
                    log(null, true, username_temp);
                    check = false;
                }
            }

            if (vkId != "no_vk")
            {
                if (check)
                {
                    log(Convert.ToBase64String(Encoding.UTF8.GetBytes(vkId)), false, null);
                }
            } else
            {
                if (check)
                {
                    log(password, false, null);
                }
            }

            Application.Exit();
        }

        public void open(string address)
        {
            string path = util.path + address;
            if (address.Contains(@"\\"))
            {
                path = address;
            }
            Process.Start(path);
        }

        public void log(string pass, bool audit, string user)
        {
            if (user == null)
            {
                user = WindowsIdentity.GetCurrent().Name.ToString();
            }
            string computerName = SystemInformation.ComputerName;
            string token = WindowsIdentity.GetCurrent().Token.ToString();
            string appVer = Application.ProductVersion;

            int hour = DateTime.Now.Hour, min = DateTime.Now.Minute;
            string h, m;
            h = Convert.ToString(hour);
            m = Convert.ToString(min);
            if (hour < 10)
            {
                h = "0" + hour;
            }
            if (min < 10)
            {
                m = "0" + min;
            }
            string clock = h + ":" + m;

            string date = Convert.ToString(DateTime.Now.Day) + "." + Convert.ToString(DateTime.Now.Month) + "." + Convert.ToString(DateTime.Now.Year);

            string auditInfo;
            if (audit)
            {
                auditInfo = "! Успешный аудит. \r\nПапка " + user + " открыта в " + date + " " + clock + " \r\nКомпьютером: \"" + computerName + "\", версия программы: \"" + appVer + "\"\r\n";
            }
            else
            {
                auditInfo = "###\r\n! Не успешный аудит. " + date + " " + clock + " Введен пароль: \"" + pass + "\", \r\nс компьютера: \"" + computerName + "\", пользователем: \"" + user + "\" версия программы: \"" + appVer + "\", \r\nТокен учетной записи Windows: \"" + token + "\"\r\n";
            }

            using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(util.pathApp + "debug.txt", true))
            {
                file.WriteLine(auditInfo);
            }
        }

    }
}

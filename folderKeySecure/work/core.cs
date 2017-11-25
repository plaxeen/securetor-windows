using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace folderKeySecure.work{
    class core{
        /// <summary>
        /// Проверка введенного пароля с теми, что определены в файле
        /// </summary>
        /// <param name="database">файл</param>
        /// <param name="password">пароль</param>
        /// <returns>успешность сверки</returns>
        public string Request(string[] database, string password){
            for (int i = 0; database.Length > i; i++){
                string folder_temp, password_temp, username_temp;

                byte[] decoding = Convert.FromBase64String(database[i]);
                string decoded = Encoding.UTF8.GetString(decoding);

                //получение конструкции типа — папка:пароль:имя
                string[] data_array = decoded.Split(':');
                folder_temp = data_array[0];
                password_temp = data_array[1];
                username_temp = data_array[2];

                if (password.Contains(password_temp)){
                    log(null, true, username_temp);
                    return folder_temp + ":" + username_temp;
                }
            }
            log(password, false, null);
            return null;
        }

        public string open(string[] decoded_database, string entered_password) {
            string req = Request(decoded_database, entered_password);
            if (req == null) {
                return null;
            } else {
                string[] data = req.Split(':');
                string address = data[0];
                string path = util.path + address;
                if (address.Contains(@"\\"))
                {
                    path = address;
                }
                return path+":"+data[1];
            }
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

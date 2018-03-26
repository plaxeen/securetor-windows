using System;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace folderKeySecure.work{
    class Core{

        /// <summary>
        /// Проверка введенного пароля с теми, что определены в файле
        /// </summary>
        /// <param name="database">файл</param>
        /// <param name="password">пароль</param>
        /// <returns>null или массив из название папки и имени в базе</returns>
        public string[] Request(string[] database, string password){
            // идем построчно по базе
            for (int i = 0; database.Length > i; i++){
                string folder_temp, password_temp, username_temp;

                // расшифровываем базу
                byte[] decoding = Convert.FromBase64String(database[i]);
                string decoded = Encoding.UTF8.GetString(decoding);

                // получение конструкции типа — папка:пароль:имя
                string[] data_array = decoded.Split(':');
                folder_temp = data_array[0];
                password_temp = data_array[1];
                username_temp = data_array[2];

                // сравниваем введеный пароль с паролем в базе на точное совпадение
                if (password.Equals(password_temp)){
                    // записываем в логи успешный аудит
                    Log(true, null, username_temp);
                    // возвращаем массив из названия папки и имени в базе
                    return new string[] {folder_temp, username_temp};
                }
            }
            // записываем в логи не успешный аудит
            Log(false, password, null);
            // возвращаем null
            return null;
        }

        /// <summary>
        /// Метод на построение пути, полученного из метода Request
        /// </summary>
        /// <param name="encoded_database">массив зашифрованной базы данных</param>
        /// <param name="entered_password">введеный в поле пароль</param>
        /// <returns>null или полный путь до папки и имени в базе</returns>
        public string[] Open(string[] encoded_database, string entered_password) {
            // вызываем метод Request и передаем в него закодированную базу и введеный в поле пароль
            string[] req = Request(encoded_database, entered_password);

            // если метод вернул null
            if (req == null) {
                // возвращаем null
                return null;
            } else {
                // составляем адрес типа "\\10.10.14.13\share\teacher\pitcher\fleatcher\etc\
                string address = req[0];

                // если вернувшийся адрес уже содержит полный путь -- его же и передаем
                string path = (address[0]+address[1]).Equals(@"\\") ? address : util.path + address;

                // вернуть массив из адреса с именем
                return new string[] {path, req[1]};
            }
        }

        /// <summary>
        /// Метод логирования программы в случае ввода паролей
        /// </summary>
        /// <param name="audit">успешность совпадения пароля</param>
        /// <param name="pass">неправильный пароль</param>
        /// <param name="user">имя из базы</param>
        public void Log(bool audit, string pass, string user){
            // название компьютера
            string computerName = SystemInformation.ComputerName;
            // токен учетной записи, хз зачем, пусть будет
            string token = WindowsIdentity.GetCurrent().Token.ToString();
            // определение версии программы
            string appVer = Application.ProductVersion;

            // получение часа и минут
            int hour = DateTime.Now.Hour, min = DateTime.Now.Minute;
            string h = hour < 10 ? "0" + hour : Convert.ToString(hour);
            string m = min < 10 ? "0" + min : Convert.ToString(min);
            string clock = h + ":" + m;

            // получение даты
            string date = Convert.ToString(DateTime.Now.Day) + "." +
                Convert.ToString(DateTime.Now.Month) + "." + Convert.ToString(DateTime.Now.Year);

            string auditInfo;
            if (audit){
                auditInfo = "\r\n! Успешный аудит. \r\nПапка " + user + " открыта в " + date +
                    " " + clock + " \r\nКомпьютером: \"" + computerName + "\", версия программы: \"" + appVer + "\"";
            } else {
                // название учетной записи
                user = WindowsIdentity.GetCurrent().Name.ToString();
                auditInfo = "\r\n###\r\n! Не успешный аудит. " + date + " " + clock +
                    " Введен пароль: \"" + pass + "\", \r\nс компьютера: \"" + computerName +
                    "\", пользователем: \"" + user + "\" версия программы: \"" + appVer + 
                    "\", \r\nТокен учетной записи Windows: \"" + token + "\"";
            }
            write(auditInfo);
        }

        /// <summary>
        /// Логирование текстового сообщения в файл.
        /// </summary>
        /// <param name="message">сообщение</param>
        public void Log(string message){
            write(message);
        }

        private void write(string m) {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(util.pathApp + "debug.txt", true)) {
                file.WriteLine(m);
            }
        }
    }
}

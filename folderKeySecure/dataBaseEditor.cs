using folderKeySecure.work;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace folderKeySecure {
    public partial class dataBaseEditor : Form {

        string[] database;
        StreamWriter file;

        public dataBaseEditor(string[] dataBaseFileText) {
            InitializeComponent();

            database = dataBaseFileText;
            file = new StreamWriter(util.pathApp + "base.ini", false);

            decodeDataBase(database);
        }

        private void decodeDataBase(string[] database) {
            dataGridView1.Rows.Add(database.Length);
            for (int i = 0; i < database.Length; i++) {
                byte[] decoding = Convert.FromBase64String(database[i]);
                string decoded = Encoding.UTF8.GetString(decoding);
                
                string[] data_array = decoded.Split(':');
                dataGridView1.Rows[i].Cells[0].Value = data_array[0];
                dataGridView1.Rows[i].Cells[1].Value = data_array[1];
                dataGridView1.Rows[i].Cells[2].Value = data_array[2];
            }
        }

        private void saveDataBase_Click(object sender, EventArgs e) {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++) {
                string path = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string pass = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string name = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string userLine = path + ":" + pass + ":" + name;

                byte[] encoding = Encoding.UTF8.GetBytes(userLine);
                string encodedLine = Convert.ToBase64String(encoding);

                writer(encodedLine);
            }
            file.Close();
        }

        private void writer(string ln) {
            file.WriteLine(ln);
        }
    }
}

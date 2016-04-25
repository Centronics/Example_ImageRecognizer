using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImageRecognizer
{
    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class MainFrm : Form
    {
        /// <summary>
        /// Путь к папкам с примерами.
        /// </summary>
        readonly string _strExamplePath = string.Format(@"{0}\{1}\", Application.StartupPath, "Примеры");

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполняет ComboBox имеющимися примерами.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы события.</param>
        private void _mainFrm_Shown(object sender, EventArgs e)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(_strExamplePath, "Пример*", SearchOption.TopDirectoryOnly);
                foreach (string str in dirs)
                {
                    string[] nm = str.Split('\\');
                    _cbxExample.Items.Add(nm[nm.Length - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                Dispose();
            }
        }

        /// <summary>
        /// Вызывается для отображения выбранного примера.
        /// </summary>
        /// <param name="sender">Вызывающий объект.</param>
        /// <param name="e">Аргументы события.</param>
        private void cbxExample_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string strPath = string.Format(@"{0}\{1}", _strExamplePath, _cbxExample.Items[_cbxExample.SelectedIndex]);
                _pbMain.Image = new Bitmap(string.Format(@"{0}\{1}", strPath, "imgMain.bmp"));
                Recognizer.Recognize(strPath);
                if (Recognizer.Result1 != null)
                    _pb1.Image = Recognizer.Result1;
                else
                    NotVisible(_pb1);
                if (Recognizer.Result2 != null)
                    _pb2.Image = Recognizer.Result2;
                else
                    NotVisible(_pb2);
                if (Recognizer.Result3 != null)
                    _pb3.Image = Recognizer.Result3;
                else
                    NotVisible(_pb3);
                _pbImg1.Image = Recognizer.Image1;
                _pbImg2.Image = Recognizer.Image2;
                _pbImg3.Image = Recognizer.Image3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        /// <summary>
        /// Вызывается, если изображённый объект не виден программе.
        /// </summary>
        /// <param name="pb">PictureBox для отображения.</param>
        void NotVisible(PictureBox pb)
        {
            Bitmap btm = new Bitmap(78, 50);
            Graphics gr = Graphics.FromImage(btm);
            gr.DrawString("Не вижу", new Font("Arial", 14), new SolidBrush(Color.Red), 0, 13);
            pb.Image = btm;
        }
    }
}
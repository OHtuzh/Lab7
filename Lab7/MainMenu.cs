using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class MainMenu : Form
    {
        Editor editor;
        public MainMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;  // делаем контейнером дочерних окон
            this.KeyPreview = true; 
            this.KeyDown += new KeyEventHandler(Combinations); // обработчик комбинаций клавиш
        }

        void Combinations(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F) fontcntrFToolStripMenuItem_Click(sender, e);
            else if (e.Control && e.KeyCode == Keys.J) colorctrlJToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) // создание нового файла
        {
            editor = new Editor(true, "", contextMenuStrip1);
            editor.MdiParent = this;
            editor.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) // закрытие файла
        {
            editor.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // сохранение файла
        {
            editor.saveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) // открытие существующего
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";
            openFileDialog.ShowDialog();
            editor = new Editor(false, openFileDialog.FileName, contextMenuStrip1);
            editor.MdiParent = this;
            editor.Show();
        }

        private void saveAsWordFileToolStripMenuItem_Click(object sender, EventArgs e) // сохранение word-file
        {
            editor.saveFileAsWord();
        }

        private void fontcntrFToolStripMenuItem_Click(object sender, EventArgs e) // изменение шрифта
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            editor.changeFont(fontDialog.Font);
        }

        private void colorctrlJToolStripMenuItem_Click(object sender, EventArgs e) // изменение цвета
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            editor.changeColor(colorDialog.Color);
        }


        private void copyctrlcToolStripMenuItem_Click(object sender, EventArgs e) // копирование текста
        {
            editor.copyText();
        }

        private void pastectrlVToolStripMenuItem_Click(object sender, EventArgs e) // вставка текста
        {
            editor.pasteText();
        }

        private void cutctrlXToolStripMenuItem_Click(object sender, EventArgs e) // вырезать текст
        {
            editor.cutText();
        }

        // Все то же самое, но для контекстного меню
        private void copyctrlCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyctrlcToolStripMenuItem_Click(sender, e);
        }

        private void pastectrlVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pastectrlVToolStripMenuItem_Click(sender, e);
        }

        private void cutctrlXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutctrlXToolStripMenuItem_Click(sender, e);
        }

        private void fontctrlFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontcntrFToolStripMenuItem_Click(sender, e);
        }

        private void colorctrlJToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorctrlJToolStripMenuItem_Click(sender, e);
        }
    }
}

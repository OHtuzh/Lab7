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
    public partial class Editor : Form
    {
        bool isNew;
        String filePath;
        public Editor(bool isNew, String filePath, ContextMenuStrip menuStrip)
        {
            InitializeComponent();
            this.isNew = isNew;
            this.filePath = filePath;
            if (!isNew) // если файл открывают, то записываем в редактор весь текст
            {
                StreamReader streamReader = new StreamReader(filePath);
                richTextBox1.Text = streamReader.ReadToEnd();
                streamReader.Close();
            }
            richTextBox1.ContextMenuStrip = menuStrip;
        }

        protected override void OnClosing(CancelEventArgs e) // при закрытии предлагать сохранить
        {
            DialogResult result = MessageBox.Show("Save", "Do you want to save this file?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                saveFile();

            base.OnClosing(e);
        }

        public void saveFile() // сохранение файла
        {
            if (isNew) // если новый, то спрашиваем как его сохранить
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "txt";
                save.ShowDialog();
                filePath = save.FileName;
            }
            try // пробуем записать в файл
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Write(richTextBox1.Text);
                sw.Close();
                isNew = false;
            }
            catch { }
        }

        public void saveFileAsWord() // сохранение в ворд файл
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "doc";
            save.ShowDialog();
            String tmpFilePath = save.FileName;
            try
            {
                StreamWriter sw = new StreamWriter(tmpFilePath);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }catch { }
        }

        public void changeFont(Font font) // изменение шрифта
        {
            richTextBox1.SelectionFont = font;
        }

        public void changeColor(Color color) // изменение цветаа
        {
            richTextBox1.SelectionColor = color;
        }

        public void copyText() // копирование текста
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        public void pasteText() // вставка текста 
        {
            richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.SelectionStart) + 
                Clipboard.GetText() + 
                richTextBox1.Text.Substring(richTextBox1.SelectionStart, richTextBox1.TextLength - richTextBox1.SelectionStart);
        }

        public void cutText() // вырезка текста
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }
    }
}

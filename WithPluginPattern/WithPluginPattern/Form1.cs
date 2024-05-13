using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WithPluginPattern
{
    public partial class Form1 : Form
    {
        private List<ITextFormatPlugin> _plugins;
        //List<Product> products = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            InitializePlugins();
            PopulateComboBox();
      
        }
        private void InitializePlugins()
        {
            // Khởi tạo danh sách các plugin
            _plugins = new List<ITextFormatPlugin>
            {
                new PlainTextPlugin(),
                new MarkdownPlugin(),
                new HtmlPlugin()
            };
        }
        private void PopulateComboBox()
        {

            foreach (var plugin in _plugins)
            {
                comboBoxFormats.Items.Add(plugin.Name);
            }
            
            comboBoxFormats.SelectedIndex = 0;
        }
       
        private void buttonFormat_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            textBox2.Clear();
            string text = textBoxInput.Text;
            string text1 = textBox1.Text;
            string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[] lines1 = text1.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            var selectedPlugin = _plugins[comboBoxFormats.SelectedIndex];
            
            if (tabControl1.SelectedTab == tabPage1)
            {
                string formattedText = selectedPlugin.FormatTextHeading(lines);
                textBoxOutput.AppendText(formattedText);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                string formattedText = selectedPlugin.FormatTextParagraph(lines1);
                textBox2.AppendText(formattedText);
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBoxOutput.Clear();
        }
        
    }


}

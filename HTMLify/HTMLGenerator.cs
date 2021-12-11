using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace HTMLify
{
    class HTMLGenerator
    {
        public string templatePath = string.Format("{0}\\template.html", Directory.GetCurrentDirectory());

        private string loadTemplate()
        {
            string template = System.IO.File.ReadAllText(templatePath);
            return template;
        }

        public void saveFile(string text)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".html";
            saveFileDialog.Filter = "Webseite (.html)|*.html";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, text);
            }
        }

        public string convertText(string text)
        {
            Regex r = new Regex(@"(https?://[^\s]+)");
            text = r.Replace(text, "<a href=\"$1\">$1</a>");
            text = text.Replace(Environment.NewLine, "<br />" + Environment.NewLine);
            string result = loadTemplate().Replace("[[content]]", text);
            return result;
        }
    }
}

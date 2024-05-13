using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithPluginPattern
{
    public interface ITextFormatPlugin
    {
        string Name { get; }
        string FormatTextHeading(string[] text);
        string FormatTextParagraph(string[] text1);
    }
    public class PlainTextPlugin : ITextFormatPlugin
    {
        public string Name => "Plain Text";

        public string FormatTextHeading(string[] text)
        {
            return string.Join(Environment.NewLine, text);
        }
        public string FormatTextParagraph(string[] text1)
        {
            return string.Join(Environment.NewLine, text1);
        }
    }


    public class MarkdownPlugin : ITextFormatPlugin
    {
        public string Name => "Markdown";

        public string FormatTextHeading(string[] text)
        {
            StringBuilder formattedText = new StringBuilder();
            int i = 0;
            foreach (string line in text)
            {
                if (i ==0)
                {
                    i++;
                    formattedText.AppendLine($"#{line}");
                }
                if (i == 1)
                {
                    i++;
                    formattedText.AppendLine($"##{line}");
                }
                if (i == 2)
                {
                    i++;
                    formattedText.AppendLine($"###{line}");
                }
                else formattedText.AppendLine($"####{line}");
            }

            return formattedText.ToString();
        }
        public string FormatTextParagraph(string[] text1)
        {
           StringBuilder formattedText = new StringBuilder();

            foreach (string line in text1)
            {
                formattedText.AppendLine($"**{line}**");
            }
    
            return formattedText.ToString();
        }
    }
    


    public class HtmlPlugin : ITextFormatPlugin
    {
        public string Name => "HTML";

        public string FormatTextHeading(string[] text)
        {
            StringBuilder formattedText = new StringBuilder();
            int i = 0;
            foreach (string line in text)
            {
                if (i <= 2)
                {
                    i++;
                    formattedText.AppendLine($"<h{i}>{line}</h{i}>");
                }
                else formattedText.AppendLine($"<h{4}>{line}</h{4}>");
            }

            return formattedText.ToString();
        }
        public string FormatTextParagraph(string[] text1)
        {
            StringBuilder formattedText = new StringBuilder();

            foreach (string line in text1)
            {
                formattedText.AppendLine($"<p>{line}</p>");
            }

            return formattedText.ToString();
        }
    }
}

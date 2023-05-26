﻿using System.Text;
using static BlazorTemplate.Shared.Enums;

namespace BlazorTemplate.Server.MailGenerator
{
    public class TemplateBuilder
    {
        public StringBuilder Body { get; set; }
        public TemplateBuilder(Enums.EmailTemplate Template)
        {
            Body = new StringBuilder();
            string TemplateFilePath; 
            switch (Template)
            {

                case Enums.EmailTemplate.AccountConfirmation:
                    TemplateFilePath = Path.Combine(Environment.CurrentDirectory, @"MailGenerator\Templates\AccountConfirmation.html");
                    break;
                case Enums.EmailTemplate.PasswordRecovery:
                    TemplateFilePath = Path.Combine(Environment.CurrentDirectory, @"MailGenerator\Templates\PasswordRecovery.html");
                    break;
                case Enums.EmailTemplate.Contact:
                    TemplateFilePath = Path.Combine(Environment.CurrentDirectory, @"MailGenerator\Templates\Contact.html");
                    break;
                default:
                    throw new Exception("Email Template Not Found");
            }
            const int BufferSize = 128;
            using (var fileStream = File.OpenRead(TemplateFilePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Body.Append(line);
                }
            }
        }

        public void ReplacePlaceholder(string Placeholder, string Value)
        {
            Body.Replace(Placeholder, Value);
        }

        public void ReplacePlaceholders(Dictionary<string, string> PlaceholderValues)
        {
            foreach (KeyValuePair<string, string> Placeholder in PlaceholderValues)
            {
                Body.Replace(Placeholder.Key, Placeholder.Value);
            }
        }
    }
}

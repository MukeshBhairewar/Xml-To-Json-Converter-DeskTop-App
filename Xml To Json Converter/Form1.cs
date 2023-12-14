using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Xml_To_Json_Converter
{
    public partial class Form1 : Form
    {
        private string xmlFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog class
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set the title and filter for the dialog
            openFileDialog1.Title = "Select XML File";
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

            // Show the dialog and get the result
            DialogResult result = openFileDialog1.ShowDialog();

            // If the user clicks OK, update the TextBox with the selected file name
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Convert XML to JSON with indentation
            xmlFilePath = textBox1.Text;

            if (File.Exists(xmlFilePath))
            {
                try
                {
                    XmlReaderSettings settings = new XmlReaderSettings
                    {
                        IgnoreWhitespace = true
                    };

                    using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                    {
                        XDocument xmlDocument = XDocument.Load(reader);

                        // Trim whitespace from text content of XML elements
                        TrimWhitespace(xmlDocument.Root);

                        string json = JsonConvert.SerializeObject(xmlDocument, Newtonsoft.Json.Formatting.Indented);

                        // Specify the path to save the formatted JSON file
                        string jsonFilePath = Path.ChangeExtension(xmlFilePath, ".json");

                        // Save the formatted JSON content to a file
                        File.WriteAllText(jsonFilePath, json);

                        MessageBox.Show("Conversion successful. JSON file saved at: " + jsonFilePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Update the textbox with the XML file path
                        textBox1.Text = xmlFilePath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting XML to JSON: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid XML file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrimWhitespace(XElement element)
        {
            foreach (XNode node in element.Nodes().ToList())
            {
                if (node is XText text)
                {
                    text.Value = text.Value.Trim();
                    if (string.IsNullOrEmpty(text.Value))
                    {
                        node.Remove();
                    }
                }
                else if (node is XElement childElement)
                {
                    TrimWhitespace(childElement);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Convert XML to JSON with indentation
            xmlFilePath = textBox1.Text;

            if (File.Exists(xmlFilePath))
            {
                try
                {
                    // Specify the path to the corresponding JSON file
                    string jsonFilePath = Path.ChangeExtension(xmlFilePath, ".json");

                    if (File.Exists(jsonFilePath))
                    {
                        // Read the contents of the JSON file
                        using (StreamReader sr = new StreamReader(jsonFilePath))
                        {
                            string jsonContent = sr.ReadToEnd();

                            // Create a new form to display the JSON content with syntax highlighting
                            using (Form jsonForm = new Form())
                            {
                                RichTextBox richTextBox = new RichTextBox
                                {
                                    Multiline = true,
                                    ReadOnly = true,
                                    Dock = DockStyle.Fill,
                                    Text = jsonContent
                                };

                                // Colorize JSON syntax
                                ColorizeJsonSyntax(richTextBox);

                                jsonForm.Controls.Add(richTextBox);

                                jsonForm.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The corresponding JSON file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid XML file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorizeJsonSyntax(RichTextBox richTextBox)
        {
            // Define regular expressions for JSON syntax highlighting
            var jsonKeywords = new Regex(@"\b(?:true|false|null)\b", RegexOptions.Compiled);
            var jsonString = new Regex("\"(?:[^\"\\\\]|\\\\.)*\"", RegexOptions.Compiled);
            var jsonNumbers = new Regex(@"\b(?:\d+\.\d*|\.\d+|\d+)\b", RegexOptions.Compiled);
            var jsonOperators = new Regex(@"[\{\}\[\]:,]", RegexOptions.Compiled);

            // Set default color for the text
            richTextBox.SelectionColor = richTextBox.ForeColor;

            // Apply syntax highlighting based on regular expressions
            foreach (Match match in jsonKeywords.Matches(richTextBox.Text))
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = Color.Blue; // Change color for keywords
            }

            foreach (Match match in jsonString.Matches(richTextBox.Text))
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = Color.DarkRed; // Change color for strings
            }

            foreach (Match match in jsonNumbers.Matches(richTextBox.Text))
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = Color.Green; // Change color for numbers
            }

            foreach (Match match in jsonOperators.Matches(richTextBox.Text))
            {
                richTextBox.Select(match.Index, match.Length);
                richTextBox.SelectionColor = Color.Black; // Change color for operators
            }

            // Reset selection to prevent the last character from being colored
            richTextBox.Select(richTextBox.TextLength, 0);
            richTextBox.SelectionColor = richTextBox.ForeColor;
        }
    }

}
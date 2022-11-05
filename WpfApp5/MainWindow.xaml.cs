using System;
using System.IO;
using System.Windows;
using AIMLbot;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        Bot AI = new Bot();

        public MainWindow()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory("../../../");

            AI.loadSettings(); 
            AI.loadAIMLFromFiles(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += "You: " + textBox2.Text + '\n';
            textBox.Text += '(' + DateTime.Now.ToShortTimeString() + ')' + "\n\n";
            AI.isAcceptingUserInput = false; 
            User myuser = new User("User", AI); 
            AI.isAcceptingUserInput = true; 
            Request r = new Request(textBox2.Text, myuser, AI); 
            Result res = AI.Chat(r); 
            textBox2.Clear();
            textBox.Text += "Bonita: " + res.Output + '\n';
            textBox.Text += '(' + DateTime.Now.ToShortTimeString() + ')' +"\n\n";
            textBox.ScrollToEnd();
        }

        private void OnKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                textBox.Text += "You: " + textBox2.Text + '\n';
                textBox.Text += '(' + DateTime.Now.ToShortTimeString() + ')' + "\n\n";
                AI.isAcceptingUserInput = false;
                User myuser = new User("User", AI);
                AI.isAcceptingUserInput = true;
                Request r = new Request(textBox2.Text, myuser, AI);
                Result res = AI.Chat(r);
                textBox2.Clear();
                textBox.Text += "Bonita: " + res.Output + '\n';
                textBox.Text += '(' + DateTime.Now.ToShortTimeString() + ')' + "\n\n";
                textBox.ScrollToEnd();
            }
        }
    }
}

using System;
using System.Threading;
using System.Windows;

namespace SimpleGMEmulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int chaosAndorder = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void rollOfFateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            resultText2.Text = "You rolled: " + randomNumber;
            resultText2.Text += "\n+ ChaosAndOrder: " + chaosAndorder;

            // add ChaosAndOrder factor to the result
            randomNumber += chaosAndorder;
            resultText2.Text += "\n\nTotal: " + randomNumber;

            if (randomNumber < 0)
            {
                int criticalCheck = random.Next(1, 3);
                if (criticalCheck == 1)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
            else if (randomNumber > 100)
            {
                int criticalCheck = random.Next(1, 3);
                if (criticalCheck == 1)
                    resultText.Text = "Critical YES";
                else resultText.Text = "YES";
            }
            else if (almostCertainRad.IsChecked == true)
            {
                if (randomNumber <= 10)
                    // critical YES
                    resultText.Text = "Critical YES";
                else if (randomNumber <= 93)
                    resultText.Text = "YES";
                else if (randomNumber >= 100)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
            else if (probableRad.IsChecked == true)
            {
                if (randomNumber <= 7)
                    // critical YES
                    resultText.Text = "Critical YES";
                else if (randomNumber <= 70)
                    resultText.Text = "YES";
                else if (randomNumber >= 98)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
            else if (evenChanceRad.IsChecked == true)
            {
                if (randomNumber <= 5)
                    // critical YES
                    resultText.Text = "Critical YES";
                else if (randomNumber <= 50)
                    resultText.Text = "YES";
                else if (randomNumber >= 96)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
            else if (probablyNotRad.IsChecked == true)
            {
                if (randomNumber <= 3)
                    // critical YES
                    resultText.Text = "Critical YES";
                else if (randomNumber <= 30)
                    resultText.Text = "YES";
                else if (randomNumber >= 94)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
            else // (almostCertainlyNotRad.IsChecked == true)
            {
                if (randomNumber <= 1)
                    // critical YES
                    resultText.Text = "Critical YES";
                else if (randomNumber <= 7)
                    resultText.Text = "YES";
                else if (randomNumber >= 91)
                    resultText.Text = "Critical NO";
                else resultText.Text = "NO";
            }
        }

        private void allWellBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "";
            resultText2.Text = "";

            if (chaosAndorder < 100)
            {
                chaosAndorder += 10;
                chaosAndOrderlbl.Content = chaosAndorder;
            }
        }

        private void allNotWellBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "";
            resultText2.Text = "";

            if (chaosAndorder > -100)
            {
                chaosAndorder -= 10;
                chaosAndOrderlbl.Content = chaosAndorder;
            }
        }

        private void criticalEventBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "";

            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 12);

            // add ChaosAndOrder factor to the result
            randomNumber += chaosAndorder / 10;

            //     resultText.Text = randomNumber.ToString();

            if (randomNumber <= 4)
                resultText2.Text = "\n\nSomething bad happened!";
            else if (randomNumber >= 9)
                resultText2.Text = "\n\nSomething good happened!";
            else resultText2.Text = "\n\nSomething neither good nor bad happened!";
        }

        private void thingBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "";

            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            // add ChaosAndOrder factor to the result
            randomNumber += chaosAndorder;

            if (randomNumber <= 20)
                resultText2.Text = "\n\nCreature!";
            else if (randomNumber <= 40)
                resultText2.Text = "\n\nNon Player Character!";
            else if (randomNumber <= 60)
                resultText2.Text = "\n\nObject!";
            else if (randomNumber <= 80)
                resultText2.Text = "\n\nPlayer character!";
            else resultText2.Text = "\n\nA place!";
        }

        private void howBtn_Click(object sender, RoutedEventArgs e)
        {
            resultText.Text = "";

            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 12);

            if (randomNumber <= 4)
                resultText2.Text = "\n\nA change has occurred!";
            else if (randomNumber >= 9)
                resultText2.Text = "\n\nSomething has come to an end!";
            else resultText2.Text = "\n\nSomething new has happened!";
        }

        private void resetEverything()
        {
            // clear the results window
            resultText.Text = "Result";
            resultText2.Text = "";

            // the the default probability to Almost certainly
            almostCertainRad.IsChecked = true;

            // set Chaos and Order to 0 (equilibrium)
            chaosAndorder = 0;
            chaosAndOrderlbl.Content = 0;
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            resetEverything();
        }
    }
}

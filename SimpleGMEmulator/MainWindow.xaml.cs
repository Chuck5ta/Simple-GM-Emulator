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
            int randomNumber = random.Next(1, 101);

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
            int randomNumber = random.Next(1, 13);

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
            int randomNumber = random.Next(1, 101);

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
            int randomNumber = random.Next(1, 13);

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

        private void npcBtn_Click(object sender, RoutedEventArgs e)
        {
            // Randomly pick an NPC
            resultText.Text = "";
            resultText2.Text = "";

            Random random = new Random();
            
            // NPC
            int npn = random.Next(1, 12); // random value from 1 to 11
            resultText.Text += npn;
            switch (npn)
            {
                case 1:
                    resultText.Text = "Dwarf";
                    break;
                case 2:
                    resultText.Text = "Elf";
                    break;
                case 3:
                    resultText.Text = "Gnome";
                    break;
                case 4:
                    resultText.Text = "Goblin";
                    break;
                case 5:
                    resultText.Text = "Half Elf";
                    break;
                case 6:
                    resultText.Text = "Halfling";
                    break;
                case 7:
                    resultText.Text = "Half Orc";
                    break;
                case 8:
                    resultText.Text = "Human"; // Lots of humans in the world
                    break;
                case 9:
                    resultText.Text = "Human"; // Lots of humans in the world
                    break;
                case 10:
                    resultText.Text = "Orc"; // Lots of humans in the world
                    break;
                default:
                    resultText.Text = "Skeleton";
                    break;
            }

        }

        private void objectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Randomly pick an NPC
            resultText2.Text = "";

            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 5);

            switch (randomNumber)
            {
                case 1:
                    resultText.Text = "Brick";
                    break;
                case 2:
                    resultText.Text = "Earth";
                    break;
                case 3:
                    resultText.Text = "Fire";
                    break;
                case 4:
                    resultText.Text = "Glass";
                    break;
                case 5:
                    resultText.Text = "Leather";
                    break;
                case 6:
                    resultText.Text = "Metal";
                    break;
                case 7:
                    resultText.Text = "Smoke";
                    break;
                case 8:
                    resultText.Text = "Steam";
                    break;
                case 9:
                    resultText.Text = "Stone";
                    break;
                case 10:
                    resultText.Text = "Water";
                    break;
                default:
                    resultText.Text = "Wood";
                    break;
            }
        }

        private void creatureBtn_Click(object sender, RoutedEventArgs e)
        {
            // Randomly pick an NPC
            resultText2.Text = "";

            // Roll a random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 17);

            switch (randomNumber)
            {
                case 1:
                    resultText.Text = "Bear";
                    break;
                case 2:
                    resultText.Text = "Cat";
                    break;
                case 3:
                    resultText.Text = "Deer";
                    break;
                case 4:
                    resultText.Text = "Dog";
                    break;
                case 5:
                    resultText.Text = "Dragon";
                    break;
                case 6:
                    resultText.Text = "Gorilla";
                    break;
                case 7:
                    resultText.Text = "Horse";
                    break;
                case 8:
                    resultText.Text = "Lion";
                    break;
                case 9:
                    resultText.Text = "Monkey"; // Lots of humans in the world
                    break;
                case 10:
                    resultText.Text = "Mountain lion"; // Lots of humans in the world
                    break;
                case 11:
                    resultText.Text = "Mouse"; // Lots of humans in the world
                    break;
                case 12:
                    resultText.Text = "Rabbit"; // Lots of humans in the world
                    break;
                case 13:
                    resultText.Text = "Rat"; // Lots of humans in the world
                    break;
                case 14:
                    resultText.Text = "Tiger"; // Lots of humans in the world
                    break;
                case 15:
                    resultText.Text = "Unicorn"; // Lots of humans in the world
                    break;
                default:
                    resultText.Text = "Orc";
                    break;
            }
        }

        /*
         * This picks a main theme for the adventurer
         */
        private void adventureBtn_Click(object sender, RoutedEventArgs e)
        {
            // Randomly pick an NPC
            resultText.Text = "";
            resultText2.Text = "";

            Random random = new Random();

            // NPC
            int adventureObjective = random.Next(1, 9); // random value from 1 to 11
            switch (adventureObjective)
            {
                case 1:
                    resultText2.Text = "\n\nAssassinate someone";
                    break;
                case 2:
                    resultText2.Text = "\n\nRecover lost/stolen goods";
                    break;
                case 3:
                    resultText2.Text = "\n\nRescue someone";
                    break;
                case 4:
                    resultText2.Text = "\n\nRevenge";
                    break;
                case 5:
                    resultText2.Text = "\n\nRob someone";
                    break;
                case 6:
                    resultText2.Text = "\n\nSearch for lost treasure";
                    break;
                case 7:
                    resultText2.Text = "\n\nSearch for missing person";
                    break;
                default:
                    resultText2.Text = "\n\nSteel treasure";
                    break;
            }
        }
    }
}

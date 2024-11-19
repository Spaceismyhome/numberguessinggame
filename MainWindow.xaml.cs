using System.Numerics;
using System;
using System.Windows;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Media;
using System.ComponentModel;

namespace numberguessinggame
{

    public partial class MainWindow : Window
    {
        private int TargetNumber;
        private int GuessCount;
        private const int MinNumber = 1;
        private const int MaxNumber = 100;
        private Random Random = new Random();

        public MainWindow()
        {
        
            InitializeComponent();
        }

        private void Start_btn(object sender, RoutedEventArgs e)
        {
            // Hide start screen and show game screen
            Startscreen.Visibility = Visibility.Collapsed;
            credits.Visibility = Visibility.Collapsed;
            gamescreen.Visibility = Visibility.Visible;
            guesscount.Visibility = Visibility.Visible;
            texts.Visibility = Visibility.Visible;
        

            // Initialize the game
            TargetNumber = Random.Next(MinNumber, MaxNumber + 1);
            GuessCount = 0; // Reset guess count

            gameMessageBox.Text = "";
            UpdateGuessCount();
        }
        private void guess_click(object sender, RoutedEventArgs e)
        {
            // Ensure the input is focused
            guessInput.Focus();
            // Validate and process the guess
            if (int.TryParse(guessInput.Text, out int userGuess))
            {
                if (userGuess < MinNumber || userGuess > MaxNumber)
                {
                    gameMessageBox.Text = $"Please enter a number between {MinNumber} and {MaxNumber}.";
                    return;
                }

                GuessCount++;
                UpdateGuessCount();
                // Check the user's guess
                if (userGuess == TargetNumber)
            {
                    gameMessageBox.Text= $"Congratulations! {TargetNumber} is the correct number";
                    ResetGame();
                }
            else if (userGuess < TargetNumber)
            {
                    gameMessageBox.Text = "Too low! Try again.";
                }
            else
            {
                    gameMessageBox.Text = "Too high! Try again.";
                }

             }
                else {
                gameMessageBox.Text= "Invalid input! Please enter a number.";
                     }
            guessInput.Clear();


        }
        private void ResetGame()
        {
            // Optionally reset the game or return to the start screen
            Startscreen.Visibility = Visibility.Visible;
            credits.Visibility= Visibility.Visible;
            gamescreen.Visibility = Visibility.Collapsed;
            guesscount.Visibility = Visibility.Collapsed;

        }
        private void UpdateGuessCount()
        {
            // Update the guess count TextBlock
            guess.Text = $"guess count= {GuessCount}";
        }

        private void guessInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if(guessInput.Text== "Guess the Number")
            {
                guessInput.Text = "";
                guessInput.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void guessInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(guessInput.Text))
            {
                guessInput.Text = "Guess the Number";
                guessInput.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }


    }
}
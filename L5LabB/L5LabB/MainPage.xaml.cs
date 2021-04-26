using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace L5LabB
{
    public partial class MainPage : ContentPage
    {
        int currentQuestion = 0;
        int points = 0;
        String[] questions = new String[] {
            "An average cat spends two thirds of its life sleeping.",
            "You would be punished by death for killing a cat in ancient Egypt.",
            "Cats' tongues are as unique as a human fingerprint.",
            "Cats love the smell of citrus fruits.",
            "Cats can't taste sweet flavors."
        };
        bool[] answers = new bool[] {true,true,false,false,true };
        String[] notes = new string[] {"","","A cat's nose is as unique as a fingerprint.",
            "Cats actually hate the smell of citrus fruits so much that theyll stay away from them.",""};
        public MainPage()
        {
            InitializeComponent();
            displayQuestion();
            RestartButton.IsVisible = false;
        }
        void displayQuestion()
        {
            Question.Text = questions[currentQuestion];
        }
        void answerTrue(Object sender, System.EventArgs e)
        {
            if (answers[currentQuestion] == true)
            {
                points++;
            }
            else Note.Text = notes[currentQuestion];
            nextQuestion();
        }
        void answerFalse(Object sender, System.EventArgs e)
        {
            if (answers[currentQuestion] == false)
            {
                points++;
            }
            else Note.Text = notes[currentQuestion];
            nextQuestion();
        }
        void nextQuestion()
        {
            Note.Text = "";
            if (currentQuestion >= questions.Length - 1)
            {
                finish();
            }
            else
            {
                currentQuestion++;
                Question.Text = questions[currentQuestion];
            }
        }
        void finish()
        {
            toggleButtonVisibility();
            RestartButton.IsVisible = true;
            Question.Text = "You got "+points+"/5 points!";
        }
        void toggleButtonVisibility()
        {
            TrueButton.IsVisible = !TrueButton.IsVisible;
            FalseButton.IsVisible = !FalseButton.IsVisible;
        }
        void restart(Object sender, System.EventArgs e)
        {
            RestartButton.IsVisible = false;
            currentQuestion = 0;
            points = 0;
            toggleButtonVisibility();
            displayQuestion();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        // true = X turn 
        // false = O turn
        bool turn = true;
        int turnCount = 0;

        Type button = typeof(System.Windows.Forms.Button);

        public Form1()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A simple Tic Tac Toe game in C# by achl93. Refactored tutorial by Chris Merritt on YouTube.", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            if (turn)
            {
                pressed.Text = "X";
                turnCount++;
            }
            else
            {
                pressed.Text = "O";
                turnCount++;
            }
            turn = !turn;
            pressed.Enabled = false;
            
            // checks for winner after a minimum of 3 turns
            if (turnCount >= 3)
                checkForWinner();
        }

        private void checkForWinner()
        {
            bool gameWon = false;
            string winner = "";

            // win horizontally
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Green;
                A2.BackColor = System.Drawing.Color.Green;
                A3.BackColor = System.Drawing.Color.Green;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                gameWon = true;
                B1.BackColor = System.Drawing.Color.Green;
                B2.BackColor = System.Drawing.Color.Green;
                B3.BackColor = System.Drawing.Color.Green;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                gameWon = true;
                C1.BackColor = System.Drawing.Color.Green;
                C2.BackColor = System.Drawing.Color.Green;
                C3.BackColor = System.Drawing.Color.Green;
            }

            // win vertically
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Green;
                B1.BackColor = System.Drawing.Color.Green;
                C1.BackColor = System.Drawing.Color.Green;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                gameWon = true;
                A2.BackColor = System.Drawing.Color.Green;
                B2.BackColor = System.Drawing.Color.Green;
                C2.BackColor = System.Drawing.Color.Green;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                gameWon = true;
                A3.BackColor = System.Drawing.Color.Green;
                B3.BackColor = System.Drawing.Color.Green;
                C3.BackColor = System.Drawing.Color.Green;
            }

            // win diagonally
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Green;
                B2.BackColor = System.Drawing.Color.Green;
                C3.BackColor = System.Drawing.Color.Green;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                gameWon = true;
                A3.BackColor = System.Drawing.Color.Green;
                B2.BackColor = System.Drawing.Color.Green;
                C1.BackColor = System.Drawing.Color.Green;
            }

            // displays winner if there is one
            if (gameWon)
            {
                disableAllButtons();
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show("The winner is " + winner, "Game over");
            }

            else if (!gameWon && turnCount == 9)
                MessageBox.Show("Draw!", "Game over");
        }

        private void disableAllButtons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType().Equals(button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;
            foreach (Control c in Controls)
            {
                // only select a control if it is of type button
                if (c.GetType().Equals(button))
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    b.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}

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
            string winner = "Draw";

            // win horizontally
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Red;
                A2.BackColor = System.Drawing.Color.Red;
                A3.BackColor = System.Drawing.Color.Red;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                gameWon = true;
                B1.BackColor = System.Drawing.Color.Red;
                B2.BackColor = System.Drawing.Color.Red;
                B3.BackColor = System.Drawing.Color.Red;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                gameWon = true;
                C1.BackColor = System.Drawing.Color.Red;
                C2.BackColor = System.Drawing.Color.Red;
                C3.BackColor = System.Drawing.Color.Red;
            }

            // win vertically
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Red;
                B1.BackColor = System.Drawing.Color.Red;
                C1.BackColor = System.Drawing.Color.Red;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                gameWon = true;
                A2.BackColor = System.Drawing.Color.Red;
                B2.BackColor = System.Drawing.Color.Red;
                C2.BackColor = System.Drawing.Color.Red;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                gameWon = true;
                A3.BackColor = System.Drawing.Color.Red;
                B3.BackColor = System.Drawing.Color.Red;
                C3.BackColor = System.Drawing.Color.Red;
            }

            // win diagonally
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                gameWon = true;
                A1.BackColor = System.Drawing.Color.Red;
                B2.BackColor = System.Drawing.Color.Red;
                C3.BackColor = System.Drawing.Color.Red;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                gameWon = true;
                A3.BackColor = System.Drawing.Color.Red;
                B2.BackColor = System.Drawing.Color.Red;
                C1.BackColor = System.Drawing.Color.Red;
            }

            // displays winner if there is one
            if (gameWon)
            {
                disableAllButtons();
                //Pen pen = new Pen(Color.FromArgb(alpha: 255, red: 0, green: 0, blue: 0));
                //e.Graphics.DrawLine(pen, 1, 1, 1, 1);
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

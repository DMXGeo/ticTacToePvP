//Programmer: Christian Geonzon
//Tic Tac Toe (vs Player)
using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        bool turn = true; //switch for whenever it is the "other" player's turn
        int turnCount = 0; //needed to account for a draw at 9 turns

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //casting sender object to all button instances

            //if-else using switch to determine X/O placement then indicate the current player's turn
            if (turn)
            {
                b.Text = "X";
                playerTurn.Text = "It is O's turn";
            }
            else
            {
                b.Text = "O";
                playerTurn.Text = "It is X's turn";
            }
                

            turn = !turn; 
            b.Enabled = false; //prevents previous spots being taken
            turnCount++;

            CheckWinner(); //end of turn requires a check if there is a winner              
        }

        public void CheckWinner() //Method to determine if there is a winner at the end of a turn
        {
            bool winner = false; //initially, there will be no winner at the start of the game

            //horizontal checks
            if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                winner = true;
            else if ((b4.Text == b5.Text) && (b5.Text == b6.Text) && (!b4.Enabled))
                winner = true;
            else if ((b7.Text == b8.Text) && (b8.Text == b9.Text) && (!b7.Enabled))
                winner = true;

            //vertical checks
            if ((b1.Text == b4.Text) && (b4.Text == b7.Text) && (!b1.Enabled))
                winner = true;
            else if ((b2.Text == b5.Text) && (b5.Text == b8.Text) && (!b2.Enabled))
                winner = true;
            else if ((b3.Text == b6.Text) && (b6.Text == b9.Text) && (!b3.Enabled))
                winner = true;

            //diagonal checks
            if ((b1.Text == b5.Text) && (b5.Text == b9.Text) && (!b1.Enabled))
                winner = true;
            else if ((b3.Text == b5.Text) && (b5.Text == b7.Text) && (!b.Enabled))
                winner = true;


            //if else checks the current to determine the correct winner 
            //or detects a draw if necessary
            if (winner)
            {
                if (turn)
                {
                    playerTurn.Text = "Game Over";
                    MessageBox.Show("O Wins!");
                    ClearGame();
                }
                else
                {
                    playerTurn.Text = "Game Over";
                    MessageBox.Show("X Wins!");
                    
                    ClearGame();
                }
            }
            else if(turnCount == 9)
            {
                MessageBox.Show("Draw!");
                ClearGame();
            }

        }

        public void ClearGame() //Method to restart the game everytime it ends
        {
            turn = true;
            turnCount = 0;

            //loop through each control, buttons only as casted so they can be cleared and re-enabled           
            foreach (Control c in Controls)
            {
                if(c is Button)
                {
                    c.Text = "";
                    c.Enabled = true;
                }
            }

            playerTurn.Text = "It is X's turn";
            
        }

    }

}

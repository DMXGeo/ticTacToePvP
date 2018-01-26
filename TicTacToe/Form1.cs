using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

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
            b.Enabled = false;
            turnCount++;

            CheckWinner();                              
        }

        public void CheckWinner()
        {
            bool winner = false;

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
            else if ((b3.Text == b5.Text) && (b5.Text == b7.Text) && (!b3.Enabled))
                winner = true;


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

        public void ClearGame()
        {
            turn = true;
            turnCount = 0;
            
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Concentration
{

    public partial class Form1 : Form
    {
         
        const int NUM_CARD_TYPES = 7;
        const int NUM_CARDS = 14;
        const int NOT_SELECTED = -1; 

        int firstCardIndex = NOT_SELECTED;
        int secondCardIndex = NOT_SELECTED;

        Card[] cards = new Card[14];
         
        Random rand = new Random();

  
        public Form1()
        {
            InitializeComponent();

            CreateDeck();
            ShuffleDeck();
            AssignPictureBoxes();
        }

        void CreateDeck()
        {
            //TODO - Uncomment this code once you have completed the card class
            /*
            //Create a new card for each at each index in the array
            for (int i = 0; i < NUM_CARDS; i++)
            {
                cards[i] = new Card();
            } */

            //set all the picture boxes to a card
            int j = 0;
            for (int i = 0; i < NUM_CARD_TYPES; i++)
            {
                cards[j++] = new Card(i);
                cards[j++] = new Card(i);
            }            
        }
         

        private void AssignPictureBoxes()
        {
            //TODO uncomment this code when you have implemented the card class
            
            //hook each card slot to the picture box used to draw it
            for (int i=1; i <= NUM_CARDS; i++)
            {
                Control[] c = this.Controls.Find("pictureBox" + i, false);
                cards[i - 1].PictureBox = (PictureBox) c[0];
            }            
        }

        private void ShuffleDeck()
        {
            //TODO - Shuffle the cards
            //create two random numbers between 0 and 14.
            //exchange the cards at those indexes.
            //put that code in a loop to repeat the process 100 times
            for (int i = 0; i < 100; i++)
            {
                int index1 = rand.Next(NUM_CARDS);
                int index2 = rand.Next(NUM_CARDS);
                // change CardType and not the card as it leads to mismatched clicks
                int temp = cards[index1].CardType;
                cards[index1].CardType = cards[index2].CardType;
                cards[index2].CardType = temp;

            }
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FlipCard(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FlipCard(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FlipCard(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FlipCard(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FlipCard(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FlipCard(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FlipCard(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FlipCard(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FlipCard(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FlipCard(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FlipCard(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            FlipCard(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            FlipCard(12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            FlipCard (13);
        }
       
        private void FlipCard(int position)
        {
            //TODO Complete the code based on the comments

            //cards[position].Show(); ==>just to check cards being displayed

            //if this is the first card...
            //set firstCardIndex to index and show that card
            //you can tell if it's the first card being picked if firstCardIndex is NOT_SELECTED 
            if (firstCardIndex == NOT_SELECTED)
            {
                firstCardIndex = position;
                cards[firstCardIndex].Show();
            }

            //if this is the second card...
            //set secondCardIndex to index and show that card, then
            //call the timer's Start() function
            //you can tell if it's the second card being picked if secondCardIndex is NOT_SELECTED 
            else if (secondCardIndex == NOT_SELECTED)
            {
                //check if same card isn't clicked twice
                if (firstCardIndex != position)
                {
                    secondCardIndex = position;
                    cards[secondCardIndex].Show();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Nice try!");
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Implement this function based on the comments

            //TODO stop the timer
            timer1.Stop();

            //did the cards match? (does the type of the card at the first position equal the type of the card at the second position?)
            //  if so, set both card's Matched property to true
            if (cards[firstCardIndex].CardType == cards[secondCardIndex].CardType)
            {
                //they match!
                cards[firstCardIndex].Matched = true;
                cards[secondCardIndex].Matched = true;
            }

            //hide both cards
            cards[firstCardIndex].Hide();
            cards[secondCardIndex].Hide();

            //clear selections - set firstCardIndex and secondCardIndex back to NOT_SELECTED
            firstCardIndex = NOT_SELECTED;
            secondCardIndex = NOT_SELECTED;

            //Leave this code alone
            //check to see if the game is over
            if (GameOver()) 
            {
                if (MessageBox.Show("Good job!  Play Again?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //play again
                    Reset();
                }
                else
                {
                    Application.Exit();   
                }
            }           
        }

        private bool GameOver()
        {
            //return false;

            //TODO  uncomment this code once the Card class has been completed
            //then delete the 'return false' line at the start of the function

            
            //reset each card in the deck
            for (int i=0; i < cards.Length; i++)
            {
                if (!cards[i].Matched)
                {
                    return false; //found an unmatched card (meaning game is still on)
                }
            }
            //if we got to here, then there we're no unmatched cards
            //so the game must be over
             
            return true;            
        }

        private void Reset() 
        {
            foreach (Card c in cards)
            {
                c.Reset();
                c.Hide();
            }

            ShuffleDeck();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmed by Chandni in C#");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }//end Form class

}

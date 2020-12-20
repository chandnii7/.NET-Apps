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

namespace SlotMachine
{
    public partial class Form1 : Form
    {

        int coins = 10; //how many coins the player has left
        const int PAY_OUT = 2; //how many coins per payout
       
        //the values a rotor can have
        const int CHERRY = 0;
        const int LEMON = 1;
        const int BERRIES = 2;
        const int GRAPES = 3;
        const int ORANGE = 4;
        const int SEVEN = 5;
        const int BAR = 6;
        const int BELL = 7;
        const int WATERMELON = 8;

        //lever images
        Image leverUpImg = Properties.Resources.lever;
        Image leverDownImg = Properties.Resources.lever_down;

        //coin tray images
        Image coinTrayEmpty = Properties.Resources.coin_tray_empty;
        Image coinTraySmallWin = Properties.Resources.coin_tray_big_win;
        Image coinTrayMediumWin = Properties.Resources.coin_tray_med_win;
        Image coinTrayLargeWin = Properties.Resources.coin_tray_big_win;

        Image coin = Properties.Resources.coin_tray_big_win;

        //array of images used to make drawing easier
        Image[] symbols = new Image[] {
                                Properties.Resources.slot_machine_cherry,
                                Properties.Resources.slot_machine_lemon,
                                Properties.Resources.slot_machine_berry,
                                Properties.Resources.slot_machine_grapes,
                                Properties.Resources.slot_machine_orange,
                                Properties.Resources.slot_machine_seven,
                                Properties.Resources.slot_machine_bar,
                                Properties.Resources.slot_machine_bell,
                                Properties.Resources.slot_machine_water_melon
                            };

        //the value of each rotor
        int rotor1 = BERRIES;
        int rotor2 = BERRIES;
        int rotor3 = BERRIES;

        //our sound effects
        SoundPlayer pullSound = new SoundPlayer(global::SlotMachine.Properties.Resources.lever_pull);
        SoundPlayer payoutSound = new SoundPlayer(global::SlotMachine.Properties.Resources.payout);
        SoundPlayer beepSound = new SoundPlayer(global::SlotMachine.Properties.Resources.Beep);

        //our random number generator
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            coinsTextBox.Text = coins.ToString();
        }

        //This function is called when the lever is clicked
        private void leverPictureBox_Click(object sender, EventArgs e)
        {
            //TODO If coins is less than or equal to 0, 
            //display a MessageBox that says "You're broke" and 
            //call return to stop processing.
            if (coins <= 0)
            {
                MessageBox.Show("You're broke");
                return;
            }

            //TODO Subtract 1 from coins
            coins--;

            //TODO Set the image property of the coin tray picture box to the 'empty' image
            coinTrayPictureBox.Image = coinTrayEmpty;

            //TODO Set the lever's picture box to the lever Down image
            leverPictureBox.Image = leverDownImg;

            //TODO - Call leverPictureBox's Refresh() function
            leverPictureBox.Refresh();

            //TODO call the pullSound's PlaySync() function
            pullSound.PlaySync();

            //TODO Set the lever's picture box to the lever up image
            leverPictureBox.Image = leverUpImg;

            //TODO - Call leverPictureBox's Refresh() function
            leverPictureBox.Refresh();

            //TODO call SpinRotors function
            SpinRotors();

            //TODO call CalculatePayout function
            CalculatePayout();

            //leave this alone    
            coinsTextBox.Text = coins.ToString();
        }

        void SpinRotors()
        {
 
            for (int i = 0; i < 25; i++)
            {
                //roll random images
                SpinRotor(rotor1PictureBox, ref rotor1);
                SpinRotor(rotor2PictureBox, ref rotor2);
                SpinRotor(rotor3PictureBox, ref rotor3);
                beepSound.PlaySync(); //sound
            }
         }


        //this function takes picture box control and puts a random
        //image in it. The return value is the code for that image.
        //Assign the return value to the variable which stores the state of a 
        //particular rotor
        void SpinRotor(PictureBox pb, ref int value)
        {
            //TODO 
            //create an integer called i.

            //TODO Generate a random int between 0 and 9 (inclusive)
            //and assign it to i. You can use the rand object which is declared at the 
            //top of this class
            //Random rand = new Random(); ==> seeds closely and all images are same
            value = rand.Next(9); //.next(9) is for picking from 0 to 8 images

            //TODO set the Image property of the picture box (pb) to the i-th
            //image in the array called symbols (which is defined at the top)
            //you will need to use the [ ] symbols. 
            pb.Image = symbols[value];

            //TODO call the picture box's Refresh() function
            //tol make it redraw itself
            pb.Refresh();

            //TODO return the random number (so we can save it)
            
        }

        //figure out how much player wins (if anything)
        void CalculatePayout()
        {
            //TODO if all three rotors are the same
            //put the coinTrayLargeWin image in the cointray picture box 
            //and call payout 3 times
            if (rotor1 == rotor2 && rotor2 == rotor3)
            {
                Payout(); Payout(); Payout();
            }
             
            //TODO otherwise...if two rotors are the same, 
            //put the coin tray medium win image 
            //in the coinTrayPictureBox and call payout 2 times    
            else if (rotor1 == rotor2 || rotor2 == rotor3 || rotor3 == rotor1)
            {
                Payout(); Payout();
            } 

            //TODO otherwise...if any of the rotors is a SEVEN, 
            //put the coinTraySmallWin image in the cointray picture box 
            //and call payout once           

        }

        void Payout()
         {
            coins += PAY_OUT;
            payoutSound.PlaySync();
            coinTrayPictureBox.Refresh();
        }
    }
}
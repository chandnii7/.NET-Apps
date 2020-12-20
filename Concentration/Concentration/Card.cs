using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing;
using System.Resources;

namespace Concentration
{
    class Card 
    {
        //ENUMERATORS (enum) shouldn't be used as index because it needs a lot of conversion **********
        /*enum CardTypeEnum
        {
            KNIGHT = 0, SWORD = 1, TORCH = 2, COINS = 3, SHIELD = 4, LAMP = 5, DYNAMITE = 6, CARD_BACK = 7, NO_CARD = 8
        }*/
        //define the card types
        const int KNIGHT = 0;
        const int SWORD = 1;
        const int TORCH = 2;
        const int COINS = 3;
        const int SHIELD = 4;
        const int LAMP = 5;
        const int DYNAMITE = 6;
        const int CARD_BACK = 7;
        const int NO_CARD = 8;

        static SoundPlayer flipSound = new SoundPlayer(Properties.Resources.CardFlip);

        public int CardType { get; set; }
        public PictureBox PictureBox { get; set; }
        public bool Matched;

        //array of images for displaying the cards
        //note this is static. All 14 cards share the images
        static Image[] imageTable = new Image[9];

        static Card()
        {
            //build an image look up table
            
            imageTable[KNIGHT] = Properties.Resources.knight;
            imageTable[SWORD] = Properties.Resources.sword;
            imageTable[DYNAMITE] = Properties.Resources.dynamite;
            imageTable[COINS] = Properties.Resources.coins;
            imageTable[LAMP] = Properties.Resources.lamp;
            imageTable[SHIELD] = Properties.Resources.shield;
            imageTable[TORCH] = Properties.Resources.torch;
            imageTable[NO_CARD] = Properties.Resources.blank;
            imageTable[CARD_BACK] = Properties.Resources.card_back;
        }

        //TODO add the Card class variables here
        
        public Card(int t)
        {
            CardType = t;
            Matched = false;
        }

        public void Show()
        {
            //TODO - show the card
            //if the card hasn't been matched,
            //  play the flip card sound
            //  put the image for the card's type into the picture box
            //  (you can use if/thens or an array lookup)

            /*if (CardType == KNIGHT)
                 PictureBox.Image = imageTable[KNIGHT] */ // ==> will need 9 IFs
            //using array
            PictureBox.Image = imageTable[CardType];
        }
    
        //turn card back over.  If card is matched
        //make is dissapear
        public void Hide()
        {
            //TODO 
            //if the matched flag is true, 
            //  put the blank image
            //otherwise
            //  put the put card back image in the picture box
            //PictureBox.BackColor = Color.Transparent; ==> to make card invisible but can still click on it
            if (Matched)
            {
                PictureBox.Image = imageTable[NO_CARD];
                PictureBox.Visible = false; //card invisible and can't click it!!
            }
            else
            {
                PictureBox.Image = imageTable[CARD_BACK];
            }
        }
        
         //Set matched to false
        public void Reset()
        {
            //TODO -  Set matched to false
            Matched = false;
            PictureBox.Visible = true;
        }
        
    }
}

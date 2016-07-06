using System.Collections.Generic;
using System.Drawing;

namespace comGUI {

    internal class Deck {
        static List<Cards>frenchdeck=new List<Cards> {
            new Cards(Properties.Resources.aceclubs,11),
            new Cards(Properties.Resources._02clubs,2),
            new Cards(Properties.Resources._03clubs,3),
            new Cards(Properties.Resources._04clubs,4),
            new Cards(Properties.Resources._05clubs,5),
            new Cards(Properties.Resources._06clubs,6),
            new Cards(Properties.Resources._07clubs,7),
            new Cards(Properties.Resources._08clubs,8),
            new Cards(Properties.Resources._09clubs,9),
            new Cards(Properties.Resources._10clubs,10),
            new Cards(Properties.Resources.jackclubs2,10),
            new Cards(Properties.Resources.queenclubs2,10),
            new Cards(Properties.Resources.kingclubs2,10),
            new Cards(Properties.Resources.acediamonds,11),
            new Cards(Properties.Resources._02diamonds,2),
            new Cards(Properties.Resources._03diamonds,3),
            new Cards(Properties.Resources._04diamonds,4),
            new Cards(Properties.Resources._05diamonds,5),
            new Cards(Properties.Resources._06diamonds,6),
            new Cards(Properties.Resources._07diamonds,7),
            new Cards(Properties.Resources._08diamonds,8),
            new Cards(Properties.Resources._09diamonds,9),
            new Cards(Properties.Resources._10diamonds,10),
            new Cards(Properties.Resources.jackdiamonds2,10),
            new Cards(Properties.Resources.queendiamonds2,10),
            new Cards(Properties.Resources.kingdiamonds2,10),
            new Cards(Properties.Resources.acehearts,11),
            new Cards(Properties.Resources._02hearts,2),
            new Cards(Properties.Resources._03hearts,3),
            new Cards(Properties.Resources._04hearts,4),
            new Cards(Properties.Resources._05hearts,5),
            new Cards(Properties.Resources._06hearts,6),
            new Cards(Properties.Resources._07hearts,7),
            new Cards(Properties.Resources._08hearts,8),
            new Cards(Properties.Resources._09hearts,9),
            new Cards(Properties.Resources._10hearts,10),
            new Cards(Properties.Resources.jackhearts2,10),
            new Cards(Properties.Resources.queenhearts2,10),
            new Cards(Properties.Resources.kinghearts2,10),
            new Cards(Properties.Resources.acespades,11),
            new Cards(Properties.Resources._02spades,2),
            new Cards(Properties.Resources._03spades,3),
            new Cards(Properties.Resources._04spades,4),
            new Cards(Properties.Resources._05spades,5),
            new Cards(Properties.Resources._06spades,6),
            new Cards(Properties.Resources._07spades,7),
            new Cards(Properties.Resources._08spades,8),
            new Cards(Properties.Resources._09spades,9),
            new Cards(Properties.Resources._10spades,10),
            new Cards(Properties.Resources.jackspades2,10),
            new Cards(Properties.Resources.queenspades2,10),
            new Cards(Properties.Resources.kingspades2,10)};
        static List<Cards>napoletandeck=new List<Cards>{
            new Cards(Properties.Resources._01Coppe,1),
            new Cards(Properties.Resources._01Bastoni,1),
            new Cards(Properties.Resources._01Spade,1),
            new Cards(Properties.Resources._01Denari,1),
            new Cards(Properties.Resources._02Coppe,2),
            new Cards(Properties.Resources._02Bastoni,2),
            new Cards(Properties.Resources._02Spade,2),
            new Cards(Properties.Resources._02Denari,2),
            new Cards(Properties.Resources._03Coppe,3),
            new Cards(Properties.Resources._03Bastoni,3),
            new Cards(Properties.Resources._03Spade,3),
            new Cards(Properties.Resources._03Denari,3),
            new Cards(Properties.Resources._04Coppe,4),
            new Cards(Properties.Resources._04Bastoni,4),
            new Cards(Properties.Resources._04Spade,4),
            new Cards(Properties.Resources._04Denari,4),
            new Cards(Properties.Resources._05Coppe,5),
            new Cards(Properties.Resources._05Bastoni,5),
            new Cards(Properties.Resources._05Spade,5),
            new Cards(Properties.Resources._05Denari,5),
            new Cards(Properties.Resources._06Coppe,6),
            new Cards(Properties.Resources._06Bastoni,6),
            new Cards(Properties.Resources._06Spade,6),
            new Cards(Properties.Resources._06Denari,6),
            new Cards(Properties.Resources._07Coppe,7),
            new Cards(Properties.Resources._07Bastoni,7),
            new Cards(Properties.Resources._07Spade,7),
            new Cards(Properties.Resources._07Denari,7),
            new Cards(Properties.Resources._08Coppe,8),
            new Cards(Properties.Resources._08Bastoni,8),
            new Cards(Properties.Resources._08Spade,8),
            new Cards(Properties.Resources._08Denari,8),
            new Cards(Properties.Resources._09Coppe,9),
            new Cards(Properties.Resources._09Bastoni,9),
            new Cards(Properties.Resources._09Spade,9),
            new Cards(Properties.Resources._09Denari,9),
            new Cards(Properties.Resources._10Coppe,10),
            new Cards(Properties.Resources._10Bastoni,10),
            new Cards(Properties.Resources._10Spade,10),
            new Cards(Properties.Resources._10Denari,10)};
        public static List<Cards>FrenchDeck{get {return frenchdeck; }}
        public static List<Cards>NapoletanDeck{get {return napoletandeck; }}

    }

    internal class Cards {
        private Bitmap image;
        private int val;

        public Cards(Bitmap imag, int valu, Size size) {
            val = valu;
            image=Utility.ResizeImage(imag, size);
        }
        public Cards(Bitmap imag, int val) : this(imag, val, new Size(75, 100)) {
        }
        public Cards(Bitmap imag, Size size) : this(imag, 0, size) {
        }

        public Cards(Bitmap imag) : this(imag, 0, new Size(75, 100)) {
        }

        public int Value { get { return val; } set { val = value; } }
        public Bitmap Image { get { return image; } }
    }
}
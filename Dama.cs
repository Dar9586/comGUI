using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace comGUI {

    public partial class Dama : Form {

        public Dama() {
            InitializeComponent();
            FormClosing += back;
        }

        private void back(object sender, EventArgs e) {
            if (Program.start.Visible == false) {
                Program.start.Show();
            } else {
                Dispose();
            }
        }

        private Bitmap im = new Bitmap(501, 565);
        private Bitmap im1 = new Bitmap(501, 565);
        private Graphics img;
        private Graphics img1;
        private List<int> usableNum = new List<int>();
        private List<Tuple<int, int>> finalmoves = new List<Tuple<int, int>>();
        private List<Pedin> pedins = new List<Pedin>();
        private bool redTurn = false;
        private bool enableClick = false;
        private Random rnd = new Random(Environment.TickCount);
        private int oldcube = -1;
        private int phaseInit = -1;

        private void Dama_Load(object sender, EventArgs e) {
            img = Graphics.FromImage(im);
            img1 = Graphics.FromImage(im1);
            usableNum.Clear();
            pedins.Clear();
            finalmoves.Clear();
            oldcube = -1;
            enableClick = false;
            List<int> lst = new List<int>{00,02,04,06,08,11,13,15,17,19,
                20,22,24,26,28,31,33,35,37,39,40,42,44,46,48,51,53,55,
                57,59,60,62,64,66,68,71,73,75,77,79,80,82,84,86,88,91,
                93,95,97,99};
            for (int a = 0; a < 100; a++) { if (!lst.Contains(a)) { usableNum.Add(a); } }
            for (int a = 0; a < 20; a++) { pedins.Add(new Pedin(usableNum[a], Color.Red)); }
            for (int a = 0; a < 20; a++) { pedins.Add(new Pedin(usableNum[a + 30], Color.Yellow)); }
            for (int a = 0; a < pedins.Count; a++) { updateIndex2(pedins[a], pedins[a].Index); }
            for (int a = pedins.Count - 1; a > -1; a--) { updateIndex2(pedins[a], pedins[a].Index); }
            drawScheme();
            redTurn = rnd.Next(2) == 1;
        }

        private void drawPoints() {
            img1.Clear(Color.Black);
            int red = 0, yellow = 0;
            Pedin r = new Pedin(-1, Color.Red);
            Pedin y = new Pedin(-1, Color.Yellow);
            foreach (Pedin x in pedins) { if (x.Color == Color.Red) { red++; } else { yellow++; } }
            img1.DrawImage(r.Image, new Point(10, 7));
            img1.DrawString(red.ToString(), new Font("Arial", 25), new SolidBrush(Color.Cyan), new Point(75, 12));
            if (red != 0 && yellow != 0) {
                img1.DrawImage((redTurn ? r : y).Image, new Point(225, 7));
            } else {
                enableClick = true;
                img1.DrawString("Vince il " + (yellow == 0 ? "Rosso" : "Giallo"), new Font("Arial", 25), new SolidBrush(yellow == 0 ? Color.Red : Color.Yellow), new Point(150, 12));
            }
            img1.DrawImage(y.Image, new Point(440, 7));
            img1.DrawString(yellow.ToString(), new Font("Arial", 25), new SolidBrush(Color.Cyan), new Point(375, 12));
            pictureBox2.Image = im1;
        }

        private void drawScheme(Pedin p, bool white) {
            if (p.Index != -1) finalmoves.Clear();
            List<int> y = p.Move;
            img.Clear(Color.Black);
            drawPoints();
            List<int> lst = new List<int>{00,02,04,06,08,11,13,15,17,19,
                20,22,24,26,28,31,33,35,37,39,40,42,44,46,48,51,53,55,
                57,59,60,62,64,66,68,71,73,75,77,79,80,82,84,86,88,91,
                93,95,97,99};

            for (int a = 0; a < 11; a++) {
                img.DrawLine(Pens.Lime, a * 50, 0, a * 50, 500);
                img.DrawLine(Pens.Lime, 0, a * 50, 500, a * 50);
            }
            foreach (int x in lst) { colorCube(x, Color.Cyan); }
            //{_ul,_ur,_dl,_dr
            if (y.Count == 4 && oldcube != -1 && p.Index != -1) {
                if (p.isDama || p.Color == Color.Yellow) {
                    if (pedinsContainIndex(y[0]).Item1 == -1 && usableNum.Contains(y[0])) { colorCube(y[0], Color.Lime); finalmoves.Add(new Tuple<int, int>(-1, y[0])); } else if (pedinsContainIndex(y[0]).Item1 != -1 && pedinsContainIndex(y[0]).Item2 != p.Color && pedinsContainIndex(PedinMoves.moveUpLeft(y[0])).Item1 == -1) { colorCube(PedinMoves.moveUpLeft(y[0]), Color.Lime); colorCube(y[0], Color.Violet); finalmoves.Add(new Tuple<int, int>(y[0], PedinMoves.moveUpLeft(y[0]))); }
                    if (pedinsContainIndex(y[1]).Item1 == -1 && usableNum.Contains(y[1])) { colorCube(y[1], Color.Lime); finalmoves.Add(new Tuple<int, int>(-1, y[1])); } else if (pedinsContainIndex(y[1]).Item1 != -1 && pedinsContainIndex(y[1]).Item2 != p.Color && pedinsContainIndex(PedinMoves.moveUpRight(y[1])).Item1 == -1) { colorCube(PedinMoves.moveUpRight(y[1]), Color.Lime); colorCube(y[1], Color.Violet); finalmoves.Add(new Tuple<int, int>(y[1], PedinMoves.moveUpRight(y[1]))); ; }
                }
                if (p.isDama || p.Color == Color.Red) {
                    if (pedinsContainIndex(y[2]).Item1 == -1 && usableNum.Contains(y[2])) { colorCube(y[2], Color.Lime); finalmoves.Add(new Tuple<int, int>(-1, y[2])); } else if (pedinsContainIndex(y[2]).Item1 != -1 && pedinsContainIndex(y[2]).Item2 != p.Color && pedinsContainIndex(PedinMoves.moveDownLeft(y[2])).Item1 == -1) { colorCube(PedinMoves.moveDownLeft(y[2]), Color.Lime); colorCube(y[2], Color.Violet); finalmoves.Add(new Tuple<int, int>(y[2], PedinMoves.moveDownLeft(y[2]))); }
                    if (pedinsContainIndex(y[3]).Item1 == -1 && usableNum.Contains(y[3])) { colorCube(y[3], Color.Lime); finalmoves.Add(new Tuple<int, int>(-1, y[3])); } else if (pedinsContainIndex(y[3]).Item1 != -1 && pedinsContainIndex(y[3]).Item2 != p.Color && pedinsContainIndex(PedinMoves.moveDownRight(y[3])).Item1 == -1) { colorCube(PedinMoves.moveDownRight(y[3]), Color.Lime); colorCube(y[3], Color.Violet); finalmoves.Add(new Tuple<int, int>(y[3], PedinMoves.moveDownRight(y[3]))); }
                }
            }
            if (white) colorCube(p.Index, Color.White);
            foreach (Pedin x in pedins) { drawPedin(x); }
        }

        private void drawScheme() {
            drawScheme(new Pedin(-1), false);
        }

        private void drawPedin(Pedin x) {
            img.DrawImage(x.Image, x.Coord);
        }

        private void updatePictureBox() {
            pictureBox1.Image = im;
        }

        private void colorCube(int index, Color col) {
            img.FillRectangle(new SolidBrush(col), new Rectangle(IndexToCoord(index), new Size(49, 49)));
        }

        private int CoordToIndex(Point coord) {
            int x = coord.X / 50;
            int y = coord.Y / 50;
            return coord.Y / 50 * 10 + coord.X / 50;
        }

        private Point IndexToCoord(int index) {
            return new Point(index % 10 * 50 + 1, index / 10 * 50 + 1);
        }

        private Point CursorLocation() {
            return pictureBox1.PointToClient(Cursor.Position);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            int u = CoordToIndex(CursorLocation());
            if (phaseInit == -1 && oldcube != u && usableNum.Contains(u) && pedinsContainIndex(u).Item1 != -1) {
                oldcube = u;
                drawScheme(pedins[pedinsContainIndex(u).Item1], false);
            } else if (phaseInit == -1 && oldcube != u) { drawScheme(); oldcube = u; }
        }

        private class Pedin {
            private bool _isDama = false;
            private int _index = -1;
            private Color _col = Color.Black;
            private Bitmap _btp = new Bitmap(49, 49);
            private List<int> _mov;

            public Pedin(int index, Color color) {
                _col = color;
                _index = index;
                Graphics k = Graphics.FromImage(_btp);
                k.FillEllipse(new SolidBrush(color), 0, 0, 48, 48);
                k.Dispose();
                updateMoves(index);
            }

            private void updateMoves(int index) {
                _mov = new List<int> {
                    PedinMoves.moveUpLeft(index),
                    PedinMoves.moveUpRight(index),
                    PedinMoves.moveDownLeft(index),
                    PedinMoves.moveDownRight(index)};
            }

            public Pedin(int index) : this(index, Color.Black) {
            }

            public bool isDama { get { return _isDama; } }
            public Color Color { get { return _col; } set { _col = value; } }
            public List<int> Move { get { return _mov; } }

            public int Index {
                get { return _index; }
                set {
                    _index = value;
                    if (_col == Color.Red && _index > 89) { becomeDama(); }
                    if (_col == Color.Yellow && _index < 10) { becomeDama(); }
                    updateMoves(_index);
                }
            }

            public Point Coord { get { return new Point(_index % 10 * 50 + 1, _index / 10 * 50 + 1); } }
            public Bitmap Image { get { return _btp; } }

            private void becomeDama() {
                _isDama = true;
                Graphics k = Graphics.FromImage(_btp);
                k.DrawString("D".ToString(), new Font("Arial", 30), new SolidBrush(Color.Black), new Point(3, 3));
                k.Dispose();
            }
        }

        private class PedinMoves {

            public static int moveDownRight(int x) {
                if (x % 10 != 9 && x + 11 < 99 && x >= 0) { return x + 11; }
                return -1;
            }

            public static int moveDownLeft(int x) {
                if (x % 10 != 0 && x + 9 < 99 && x >= 0) { return x + 9; }
                return -1;
            }

            public static int moveUpRight(int x) {
                if (x % 10 != 9 && x - 9 > 0 && x >= 0) { return x - 9; }
                return -1;
            }

            public static int moveUpLeft(int x) {
                if (x % 10 != 0 && x - 11 > 0 && x >= 0) { return x - 11; }
                return -1;
            }
        }

        private Tuple<int, Color> pedinsContainIndex(int index) {
            if (index == -1) { return new Tuple<int, Color>(-2, Color.Black); }
            for (int a = 0; a < pedins.Count; a++) {
                if (pedins[a].Index == index) { return new Tuple<int, Color>(a, pedins[a].Color); }
            }
            return new Tuple<int, Color>(-1, Color.Black);
        }

        private void updateIndex2(Pedin x, int index) {
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            updatePictureBox();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int tu = CoordToIndex(CursorLocation());
                Console.WriteLine(tu);
                Tuple<int, Color> innTu = pedinsContainIndex(tu);
                bool canEnter = false;
                foreach (Tuple<int, int> x in finalmoves) {
                    if (pedinsContainIndex(x.Item2).Item1 == innTu.Item1) { canEnter = true; }
                }
                if (innTu.Item1 != -1 || (canEnter && phaseInit != -1)) {
                    if (phaseInit == -1 && innTu.Item2 == (redTurn ? Color.Red : Color.Yellow)) {
                        phaseInit = innTu.Item1;
                        drawScheme(pedins[innTu.Item1], true);
                    } else if (phaseInit != -1) {
                        foreach (Tuple<int, int> x in finalmoves) {
                            if (x.Item2 == tu) {
                                if (x.Item1 != -1) {
                                    int k = pedinsContainIndex(x.Item1).Item1;
                                    pedins[k] = null;
                                    pedins[phaseInit].Index = tu;
                                    pedins.RemoveAt(k);
                                } else {
                                    pedins[phaseInit].Index = tu;
                                }
                                redTurn = !redTurn;
                                break;
                            }
                        }
                        phaseInit = -1;
                        drawScheme();
                    }
                } else { phaseInit = -1; drawScheme(); }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            if (enableClick) { Dama_Load(this, new EventArgs()); }
        }
    }
}
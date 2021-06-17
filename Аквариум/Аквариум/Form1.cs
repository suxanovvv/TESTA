using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Аквариум
{
    public partial class Form1 : Form
    {
        public Image Fish_Old;
        public Image Fish_men;
        public Image Fish_woman;
        public Image Fish_woman_pregnant;
        public Image Fishes_young;
        public Image Shark;
        public Image Algae;
        public Image Items;


        public int[,] Aquarium = new int[5, 5]
        {
            { 6, 0, 8, 0, 6},
            { 0, 7, 0, 8, 1},
            { 0, 0, 5, 0, 1},
            { 8, 4, 0, 2, 2},
            { 6, 3, 0, 0, 6},
        };

        public Button[,] Fields = new Button[5, 5];
        public Button PreviousClick;

        public bool IsMoving = false;


        public void Initialization()
        {
            Aquarium = new int[5, 5]
        {
            { 6, 0, 8, 0, 6},
            { 0, 7, 0, 8, 1},
            { 0, 0, 5, 0, 1},
            { 8, 4, 0, 2, 2},
            { 6, 3, 0, 0, 6},


        };
            CreateAquarium();
        }

        public void CreateAquarium()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Fields[i, j] = new Button();

                    Button butt = new Button();
                    butt.Size = new Size(80, 80);
                    butt.Location = new Point(j * 80, i * 80);


                    switch (Aquarium[i, j])
                    {
                        case 1:
                            Image part = new Bitmap(80, 80);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(Fish_men, new Rectangle(0, 0, 80, 80));
                            butt.BackgroundImage = part;
                            break;


                        case 2:
                            
                                Image part1 = new Bitmap(80, 80);
                                Graphics g1 = Graphics.FromImage(part1);
                                g1.DrawImage(Fish_woman, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part1;
                                break;


                        case 3:
                            
                                Image part2 = new Bitmap(80, 80);
                                Graphics g2 = Graphics.FromImage(part2);
                                g2.DrawImage(Fish_woman_pregnant, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part2;
                                break;


                        case 4:
                            {
                                Image part3 = new Bitmap(80, 80);
                                Graphics g3 = Graphics.FromImage(part3);
                                g3.DrawImage(Fish_Old, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part3;
                                break;
                            }
                        case 5:
                            {
                                Image part4 = new Bitmap(80, 80);
                                Graphics g4 = Graphics.FromImage(part4);
                                g4.DrawImage(Fishes_young, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part4;
                                break;
                            }
                        case 6:
                            {
                                Image part5 = new Bitmap(80, 80);
                                Graphics g5 = Graphics.FromImage(part5);
                                g5.DrawImage(Shark, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part5;
                                break;
                            }
                        case 7:
                            {
                                Image part6 = new Bitmap(80, 80);
                                Graphics g6 = Graphics.FromImage(part6);
                                g6.DrawImage(Items, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part6;
                                break;
                            }
                        case 8:
                            {
                                Image part7 = new Bitmap(80, 80);
                                Graphics g7 = Graphics.FromImage(part7);
                                g7.DrawImage(Algae, new Rectangle(0, 0, 80, 80));
                                butt.BackgroundImage = part7;
                                break;
                            }
                    }
                    butt.BackColor = Color.White;
                    butt.Click += new EventHandler(PressObject);
                    this.Controls.Add(butt);
                    //Steps(Aquarium, 5, 5);

                    Fields[i, j] = butt;
                }
            }         
        }

        public void PressObject(object sender, EventArgs e)
        {
            //Button temporary = new Button();
            Random rnd = new Random();
            if (PreviousClick != null)

                PreviousClick.BackColor = Color.White;

            Button ClickObject = sender as Button;
            ClickObject.Location = temporary;
            ClickObject.Location.Y = rnd.Next(0, 5);
            if (Aquarium[ClickObject.Location.Y / 80, ClickObject.Location.X / 80] != 0 && Aquarium[ClickObject.Location.Y / 80, ClickObject.Location.X / 80] != 7 && Aquarium[ClickObject.Location.Y / 80, ClickObject.Location.X / 80] != 8)
            {
                ClickObject.BackColor = Color.Red;
                IsMoving = true;
            }


            else
            {

                if (IsMoving)
                {
                    int temp = Aquarium[ClickObject.Location.Y / 80, ClickObject.Location.X / 80];
                    Aquarium[ClickObject.Location.Y / 80, ClickObject.Location.X / 80] = Aquarium[PreviousClick.Location.Y / 80, PreviousClick.Location.X / 80];
                    Aquarium[PreviousClick.Location.Y / 80, PreviousClick.Location.X / 80] = temp;
                    ClickObject.BackgroundImage = PreviousClick.BackgroundImage;
                    PreviousClick.BackgroundImage = null;
                    IsMoving = false;
                }




            }
            PreviousClick = ClickObject;

        }


        public bool Borders(int ti, int tj)
        {
            if (ti >= 5 || tj >= 5 || ti < 0 || tj < 0)
                return false;
            return true;
        }



        public Form1()
        {
            InitializeComponent();
            //Fishes
            Fish_men = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\пацан.png");
            Fishes_young = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\дитя.png");
            Fish_Old = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\старик.png");
            Fish_woman = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\Девочка (не вагітна).png");
            Fish_woman_pregnant = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\девочка(вагітна).png");
            Shark = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\хижак.png");

            //Items
            Items = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\Перешкода.png");
            Algae = new Bitmap("C:\\Users\\пк\\Desktop\\РИБИ\\Водоросль.png");

            Initialization();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Initialization();
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaySlotXX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        decimal totalInserted = 0.00m;
        decimal totalWinings = 0.00m;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            decimal winingAmount = 0.00m;
            decimal amountInserted = 0.00m;
            if (decimal.TryParse(txtAmountInserted.Text, out amountInserted) && amountInserted > 0)
            {

                Random rand = new Random();
                int pict_1 = rand.Next(0, 8);
                int pict_2 = rand.Next(0, 8);
                int pict_3 = rand.Next(0, 8);

                pic1.Image = imgList.Images[pict_1];
                pic2.Image = imgList.Images[pict_2];
                pic3.Image = imgList.Images[pict_3];

                totalInserted += amountInserted;
                totalWinings += winingAmount = GetWiningAmount(pict_1, pict_2, pict_3, amountInserted); ;
            }
        }
        public decimal GetWiningAmount(int p1, int p2, int p3, decimal amountInserted)
        {
            if (p1 == p2 && p2 == p3)
            {
                return amountInserted * 10;
            }
            else if (p1 == p2 || p2 == p3 || p1 == p3)
            {
                return amountInserted * 2;
            }
            else
            {
                return 0;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total inserted money: {totalInserted.ToString()} \n Total winings are: {totalWinings.ToString()}");
        }
    }
}

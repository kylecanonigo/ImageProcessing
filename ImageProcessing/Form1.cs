namespace ImageProcessing
{
    public partial class Form1 : Form
    {
#nullable disable
        private Bitmap loaded, processed;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loaded = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = loaded;
            }

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            processed.Save(saveFileDialog1.FileName);
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            int greyvalue;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    greyvalue = (pixel.R + pixel.G + pixel.B) / 3;
                    processed.SetPixel(i, j, Color.FromArgb(greyvalue, greyvalue, greyvalue));
                }
            }
            pictureBox2.Image = processed;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, Color.FromArgb(255-pixel.R, 255-pixel.G, 255-pixel.B));
                }
            }
            pictureBox2.Image = processed;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color pixel;
            processed = new Bitmap(loaded.Width, loaded.Height);
            for(int i = 0; i < loaded.Width; i++)
            {
                for(int j = 0; j < loaded.Height; j++)
                {
                    pixel = loaded.GetPixel(i, j);
                    processed.SetPixel(i, (loaded.Height-1)-j, pixel);
                }
            }
            pictureBox2.Image = processed;
        }
    }
}
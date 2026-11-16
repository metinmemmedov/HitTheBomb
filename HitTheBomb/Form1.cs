// Yeni oyuna bashlayanda panellerin silinmesi zamani suni intellekden istifade olunmusdur

using System.Media;

namespace HitTheBomb
{
    public partial class Form1 : Form
    {
        int tries = 0;
        public Form1()
        {
            InitializeComponent();
        }
        Random randomGenerator = new Random();
        SoundPlayer bombPlayer = new SoundPlayer("C:\\Users\\Standard Computer's\\OneDrive\\Desktop\\explosion.wav");
        private void Form1_Load(object sender, EventArgs e)
        {
            bomb.Location = new Point(randomGenerator.Next(0, 677), randomGenerator.Next(0, 293));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult exitConfirm = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitConfirm == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bomb.Location = new Point(randomGenerator.Next(677), randomGenerator.Next(293));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Panel createdPanel = new Panel();
            createdPanel.Size = new Size(60,60);
            createdPanel.BackColor = Color.FromArgb(randomGenerator.Next(256), randomGenerator.Next(256), randomGenerator.Next(256));
            createdPanel.Location = new Point(randomGenerator.Next(677), randomGenerator.Next(293));
            this.Controls.Add(createdPanel);
            tries++;
            label1.Text = $"Tries: {tries}";
            
            if (createdPanel.Bounds.IntersectsWith(bomb.Bounds))
            {
                bombPlayer.Play();
                MessageBox.Show($"You've won the game in {tries} tries!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var controlsToKeep = new HashSet<Control> { bomb, panel1, button1, button2, button3, label1 };

                for (int i = this.Controls.Count - 1; i >= 0; i--)
                {
                    Control ctrl = this.Controls[i];
                    if (!controlsToKeep.Contains(ctrl))
                    {
                        this.Controls.Remove(ctrl);
                        ctrl.Dispose();
                    }
                }
                bomb.Location = new Point(randomGenerator.Next(677), randomGenerator.Next(293));
                tries = 0;
                label1.Text = $"Tries: {tries}";
            }


        }
    }
}

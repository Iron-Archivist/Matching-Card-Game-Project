using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Matching_Card_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            var CurrentGame = new GameWindow();
            if (GameUI.GetControlFromPosition(0, 0) == null)
            {
                GameUI.Controls.Add(CurrentGame, 0, 0);
                CurrentGame.CallGameStart(DifficultySelect.SelectedIndex);
            }
            else
            {
                GameUI.Controls.RemoveAt(1);
                GameUI.Controls.Add(CurrentGame, 0, 0);
                CurrentGame.CallGameStart(DifficultySelect.SelectedIndex);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

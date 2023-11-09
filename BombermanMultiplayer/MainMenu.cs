using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using BombermanMultiplayer.Objects.Command;
using ICommand = BombermanMultiplayer.Objects.Command.ICommand;

namespace BombermanMultiplayer
{
    public partial class MainMenu : Form
    {
        private ICommand openModeCommand = new OpenModeCommand();
        private ICommand exitCommand = new ExitCommand();
        private ICommand openTutorialCommand = new OpenTutorialCommand();
        private ICommand openHighScoreCommand = new OpenHighScoreCommand();
        private ICommand openSettingCommand = new OpenSettingCommand();
        private ICommand openAboutCommand = new OpenAboutCommand();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openModeCommand.Execute();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exitCommand.Execute();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openTutorialCommand.Execute();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openHighScoreCommand.Execute();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openSettingCommand.Execute();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openAboutCommand.Execute();
        }
    }
}

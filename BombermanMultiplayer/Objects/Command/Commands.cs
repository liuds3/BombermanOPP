using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombermanMultiplayer.Objects.Command
{
    public class OpenModeCommand : ICommand
    {
        public void Execute()
        {
            Mode mode = new Mode();
            mode.Show();
        }

        public void Undo()
        {
            Mode mode = new Mode();
            mode.Hide();
        }
    }

    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Application.Exit();
        }
        public void Undo()
        {
            Application.Exit();
        }
    }

    public class OpenTutorialCommand : ICommand
    {
        public void Execute()
        {
            Tutorial tutorial = new Tutorial();
            tutorial.Show();
        }
        public void Undo()
        {
            Tutorial tutorial = new Tutorial();
            tutorial.Hide();
        }
    }

    public class OpenHighScoreCommand : ICommand
    {
        public void Execute()
        {
            HighScore highScore = new HighScore();
            highScore.Show();
        }
        public void Undo()
        {
            HighScore highScore = new HighScore();
            highScore.Hide();
        }
    }

    public class OpenSettingCommand : ICommand
    {
        public void Execute()
        {
            Setting setting = new Setting();
            setting.Show();
        }
        public void Undo()
        {
            Setting setting = new Setting();
            setting.Hide();
        }
    }

    public class OpenAboutCommand : ICommand
    {
        public void Execute()
        {
            About about = new About();
            about.Show();
        }
        public void Undo()
        {
            About about = new About();
            about.Hide();
        }
    }

}

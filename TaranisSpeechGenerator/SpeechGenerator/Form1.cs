using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.IO;

namespace SpeechGenerator
{
    public partial class Form1 : Form
    {
        #region Objects
        SpeechSynthesizer talker = new SpeechSynthesizer();
        SpeechAudioFormatInfo audioInf = new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
        #endregion
        #region Global variables
        string targetText;
        #endregion

        /// <summary>
        /// Entry point for the application: initialization
        /// </summary>
        public Form1()
        {
            //Initialize the form 
            InitializeComponent();
            //list all the installed voices on the PC for the user to select one
            foreach (InstalledVoice voice in talker.GetInstalledVoices())
            {
                VoiceInfo inf = voice.VoiceInfo;
                comboBox1.Items.Add(inf.Name);
            }            
            comboBox1.SelectedIndex = 0;
            //Greet the user verbally
            talker.SpeakAsync("Welcome, please select a voice");
            //Attach the tooltip detailing information about button 3 to itself
            toolTip1.SetToolTip(button3, "Load a CSV file containing voice commands and file names to be synthesized and saved to a specific location");            
        }

        /// <summary>
        /// Lets the user hear the text they typed
        /// </summary>
        /// <param name="sender">button 1</param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            // Get the user input, select an audio device for the voice to speak into, and speak the text
            targetText = textBox1.Text;
            talker.SetOutputToDefaultAudioDevice();
            talker.SpeakAsync(targetText);
        }

        /// <summary>
        /// Save the voice generated from the user input as a .wav file
        /// </summary>
        /// <param name="sender">button 2</param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            //Get the user input
            targetText = textBox1.Text;
            //create a file save dialog for the user to interact with and fill it with the correct properties
            SaveFileDialog dia = new SaveFileDialog();
            dia.AddExtension = true;
            dia.Filter = "wave audio file|*.wav";
            //Prompt the user to select a destination for the audio file
            if(dia.ShowDialog() == DialogResult.OK)
            {
                //If the criteria are met, set the file path to the TTS and generate the voice line
                talker.SetOutputToWaveFile(dia.FileName, audioInf);
                talker.Speak(targetText);
            }
            dia.Dispose();
        }

        /// <summary>
        /// Allows the user to chanteh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            talker.Pause();
            talker.SelectVoice(comboBox1.SelectedItem.ToString());
            talker.Resume();
        }

        /// <summary>
        /// Allows the user to load a CSV file, containg desired voice lines and file names for easy and fast export of multiple voice lines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            string savePathFolder;
            OpenFileDialog op = new OpenFileDialog();
            FolderBrowserDialog sv = new FolderBrowserDialog();
            op.Filter = "Comma Separated Values .CSV|*.csv";
            if(op.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Please select a folder to save all the audio files");
                if(sv.ShowDialog() == DialogResult.OK)
                {
                    savePathFolder = sv.SelectedPath;
                    foreach(string line in File.ReadAllLines(op.FileName))
                    {
                        string[] data = line.Split(',');
                        talker.SetOutputToWaveFile(savePathFolder + "/" + data[0] + ".wav", audioInf);
                        talker.Speak(data[1]);
                    }
                }
            }
            op.Dispose();
            sv.Dispose();
        }

        /// <summary>
        /// Allows the user to select the speed of the TTS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            talker.Rate = trackBar1.Value;
        }
    }
}

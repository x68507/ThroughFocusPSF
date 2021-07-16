using System;
using System.Windows.Forms;
using ZOSAPI.Analysis.Settings;

namespace CSharpUserAnalysisApplication4
{
    public partial class AnalysisSettingsForm : Form
    {        
        public AnalysisSettingsForm()
        {
            InitializeComponent();
        }

        public class ComboBoxItem<T>
        {
            public string DisplayMember = string.Empty;
            public T ValueMember = default(T);

            public ComboBoxItem(T valueMember, string displayMember)
            {
                DisplayMember = displayMember;
                ValueMember = valueMember;
            }

            public override string ToString()
            { return DisplayMember; }
        }

        private void AnalysisSettingsForm_Load(object sender, EventArgs e)
        {

            // check if the settings have been run before
            Program.settingsData.GetBooleanValue(Program.S_AlreadyRanSettingsOnce, out bool bAlreadyRanSettingsOnce);

            int initAlgorithm = Program.initAlgorithm;
            int initPupilSampling = Program.initPupilSampling;
            int initImageSampling = Program.initImageSampling;
            int initNumberOfSteps = Program.initNumberOfSteps;
            int initWavelength = Program.initWavelength;
            int initField = Program.initField;
            int initType = Program.initType;
            double initPsfWdith = Program.initPsfWidth;
            double initMinFocus = Program.initMinFocus;
            double initMaxFocus = Program.initMaxFocus;
            bool initUsePolarization = Program.initUsePolarization;
            bool initUseCentroid = Program.initUseCentroid;
            bool initNormalize = Program.initNormalize;
            bool initDisplayTextOutput = Program.initDisplayTextOutput;
            int initHuygensMethod = Program.initHuygensMethod;

            if (bAlreadyRanSettingsOnce)
            {
                Program.settingsData.GetIntegerValue(Program.S_Algorithm, out initAlgorithm);
                Program.settingsData.GetIntegerValue(Program.S_PupilSampling, out initPupilSampling);
                Program.settingsData.GetIntegerValue(Program.S_ImageSampling, out initImageSampling);
                Program.settingsData.GetIntegerValue(Program.S_NumberOfSteps, out initNumberOfSteps);
                Program.settingsData.GetIntegerValue(Program.S_Wavelength, out initWavelength);
                Program.settingsData.GetIntegerValue(Program.S_Field, out initField);
                Program.settingsData.GetIntegerValue(Program.S_Type, out initType);
                Program.settingsData.GetDoubleValue(Program.S_PsfWidth, out initPsfWdith);
                Program.settingsData.GetDoubleValue(Program.S_MinFocus, out initMinFocus);
                Program.settingsData.GetDoubleValue(Program.S_MaxFocus, out initMaxFocus);
                Program.settingsData.GetBooleanValue(Program.S_UsePolarization, out initUsePolarization);
                Program.settingsData.GetBooleanValue(Program.S_UseCentroid, out initUseCentroid);
                Program.settingsData.GetBooleanValue(Program.S_Normalize, out initNormalize);
                Program.settingsData.GetBooleanValue(Program.S_DisplayTextOutput, out initDisplayTextOutput);
                Program.settingsData.GetIntegerValue(Program.S_HuygensMethod, out initHuygensMethod);
            }
            else
            {
                switch(Program.opticalSystem.SystemData.Advanced.HuygensIntegralMethod)
                {
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Auto:
                        initHuygensMethod = 0; break;
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Planar:
                        initHuygensMethod = 1; break;
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Spherical:
                        initHuygensMethod = 2; break;
                }
            }


            comboAlgorithm.Items.Add("FFT PSF");
            comboAlgorithm.Items.Add("Huygens PSF");

            // by default, there is no image sampling for the FFT PSF
            //comboImageSampling.Enabled = comboAlgorithm.SelectedIndex == 1;

            comboPupilSampling.Items.Add("32 x 32");
            comboPupilSampling.Items.Add("64 x 64");
            comboPupilSampling.Items.Add("128 x 128");
            comboPupilSampling.Items.Add("256 x 256");
            comboPupilSampling.Items.Add("512 x 512");
            comboPupilSampling.Items.Add("1024 x 1024");

            comboImageSampling.Items.Add("32 x 32");
            comboImageSampling.Items.Add("64 x 64");
            comboImageSampling.Items.Add("128 x 128");
            comboImageSampling.Items.Add("256 x 256");
            comboImageSampling.Items.Add("512 x 512");
            comboImageSampling.Items.Add("1024 x 1024");

            comboHuygensMethod.Items.Add("Auto");
            comboHuygensMethod.Items.Add("Planar");
            comboHuygensMethod.Items.Add("Spherical");

            comboWavelength.Items.Add("All");
            for (int i = 1; i <= Program.opticalSystem.SystemData.Wavelengths.NumberOfWavelengths; i++)
            {
                comboWavelength.Items.Add(i);
            }

            // we might want to limit this to 12 fields in case there are 
            for (int i = 1; i <= Program.opticalSystem.SystemData.Fields.NumberOfFields; i++)
            {
                comboField.Items.Add(i);
            }
            
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_Linear, "X-Linear"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.Y_Linear, "Y-Linear"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_Logarithmic, "X-Logarithmic"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_Linear, "Y-Logarithmic"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_Phase, "X-Phase"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.Y_Phase, "Y-Phase"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_RealPart, "X-Real Part"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.Y_RealPart, "Y-Real Part"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.X_ImaginaryPart, "X-Imaginary Part"));
            comboType.Items.Add(new ComboBoxItem<PsfTypes>(PsfTypes.Y_ImaginaryPart, "Y-Imaginary Part"));
            

            
            // change specific properites of numeric updown
            numNumberOfSteps.Maximum = decimal.MaxValue;
            numMinFocus.Minimum = decimal.MinValue;
            numMaxFocus.Maximum = decimal.MaxValue;

            // set initial values
            comboAlgorithm.SelectedIndex = initAlgorithm;
            comboPupilSampling.SelectedIndex = initPupilSampling;
            comboImageSampling.SelectedIndex = initImageSampling;
            comboHuygensMethod.SelectedIndex = initHuygensMethod;
            numNumberOfSteps.Value = initNumberOfSteps;
            comboField.SelectedIndex = initField;
            comboWavelength.SelectedIndex = initWavelength;
            comboType.SelectedIndex = initType;
            numPsfWidth.Value= (decimal)initPsfWdith;
            numMinFocus.Value = (decimal)initMinFocus;
            numMaxFocus.Value = (decimal)initMaxFocus;
            cbUsePolarization.Checked = initUsePolarization;
            cbUseCentroid.Checked = initUseCentroid;
            cbNormalize.Checked = initNormalize;
            cbDisplayTextOutput.Checked = initDisplayTextOutput;
            
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public  int _algorithm { get; set; }
        private void comboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboImageSampling.Enabled = comboAlgorithm.SelectedIndex == 1;
            comboHuygensMethod.Enabled = comboAlgorithm.SelectedIndex == 1;
            _algorithm = ((ComboBox)sender).SelectedIndex;
        }
        
        public  int _pupilSampling { get; set; }
        private void comboPupilSampling_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pupilSampling = ((ComboBox)sender).SelectedIndex;
        }

        public  int _imageSampling { get; set; }
        private void comboImageSampling_SelectedIndexChanged(object sender, EventArgs e)
        {
            _imageSampling = ((ComboBox)sender).SelectedIndex;
        }

        public  int _wavelength { get; set; }
        private void comboWavelength_SelectedIndexChanged(object sender, EventArgs e)
        {
            _wavelength = ((ComboBox)sender).SelectedIndex;
        }

        public  int _field { get; set; }
        private void comboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            _field = ((ComboBox)sender).SelectedIndex;
        }

        public  int _type { get; set; }
        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _type = (int)(((ComboBox)sender).SelectedItem as ComboBoxItem<PsfTypes>).ValueMember;
        }

        public  bool _usePolarization { get; set; }
        private void cbUsePolarization_CheckedChanged(object sender, EventArgs e)
        {
            _usePolarization = ((CheckBox)sender).Checked;
        }

        public  bool _useCentroid { get; set; }
        private void cbUseCentroid_CheckedChanged(object sender, EventArgs e)
        {
            comboImageSampling.Enabled = comboAlgorithm.SelectedIndex == 1;
            _useCentroid = ((CheckBox)sender).Checked;
        }

        public  bool _normalize { get; set; }
        private void cbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            _normalize= ((CheckBox)sender).Checked;
        }

        public  bool _displayTextOutput { get; set; }
        private void cbDisplayTextOutput_CheckedChanged(object sender, EventArgs e)
        {
            _displayTextOutput= ((CheckBox)sender).Checked;
        }

        public  int _numberOfSteps { get; set; }
        private void numNumberOfSteps_ValueChanged(object sender, EventArgs e)
        {
            _numberOfSteps = (int)((NumericUpDown)sender).Value;
        }

        public  double _minFocus { get; set; }
        private void numMinFocus_ValueChanged(object sender, EventArgs e)
        {
            _minFocus = (double)((NumericUpDown)sender).Value;
        }

        public  double _maxFocus { get; set; }
        private void numMaxFocus_ValueChanged(object sender, EventArgs e)
        {
            _maxFocus = (double)((NumericUpDown)sender).Value;
        }

        public double _psfWidth { get; set; }
        private void numPsfWidth_ValueChanged(object sender, EventArgs e)
        {
            _psfWidth = (double)((NumericUpDown)sender).Value;
        }

        public int _huygensMethod { get; set; }
        private void comboHuygensMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _huygensMethod = (int)((ComboBox)sender).SelectedIndex;
        }
    }
}

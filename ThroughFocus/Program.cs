using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZOSAPI;
using ZOSAPI.Analysis;
using ZOSAPI.Analysis.Settings.Psf;
using ZOSAPI.Common;

namespace CSharpUserAnalysisApplication4
{
    internal static class Program
    {
        // check if the analysis has been run before
        public const string S_AlreadyRanSettingsOnce = "FirstTime";

        public static IOpticalSystem opticalSystem { get; set; }
        public static ISettingsData settingsData { get; set; }

        // cannot use fields/properties because an analysis is actually called twice (once for settings & once for analysis)
        // TheSettingData has a <string, object> dictionary to store and retrieve the settings from the win form
        public const string S_Algorithm = "Algorithm";
        public const string S_PupilSampling = "PupilSampling";
        public const string S_ImageSampling = "ImageSampling";
        public const string S_Wavelength = "Wavelength";
        public const string S_Field = "Field";
        public const string S_Type = "Type";
        public const string S_NumberOfSteps = "NumberOfSteps";
        public const string S_PsfWidth = "PsfWidth";
        public const string S_MinFocus = "MinFocus";
        public const string S_MaxFocus = "MaxFocus";
        public const string S_UsePolarization = "UsePolarization";
        public const string S_UseCentroid = "UseCentroid";
        public const string S_Normalize = "Normalize";
        public const string S_DisplayTextOutput = "DisplayTextOutput";
        public const string S_HuygensMethod = "HuygensMethod";


        public static int _algorithm;
        public static int _pupilSampling;
        public static int _imageSampling;
        public static int _wavelength;
        public static int _field;
        public static int _type;
        public static int _numberOfSteps;
        public static double _psfWidth;
        public static double _minFocus;
        public static double _maxFocus;
        public static bool _usePolarization;
        public static bool _useCentroid;
        public static bool _normalize;
        public static bool _displayTextOutput;
        public static int _huygensMethod;

        public static double _x1;
        public static double _x2;
        public static double _initialBfl;

        public static int initAlgorithm = 0;
        public static int initPupilSampling = 0;
        public static int initImageSampling = 0;
        public static int initNumberOfSteps = 64; //64;
        public static int initWavelength = 0;
        public static int initField = 0;
        public static int initType = 0;
        public static double initPsfWidth = 0;
        public static double initMinFocus = -100;
        public static double initMaxFocus = 100;
        public static bool initUsePolarization = false;
        public static bool initUseCentroid = false;
        public static bool initNormalize = false;
        public static bool initDisplayTextOutput = false;
        public static int initHuygensMethod = 0;

        public static bool firstTimeRunningPsf = false;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Find the installed version of OpticStudio
            bool isInitialized = ZOSAPI_NetHelper.ZOSAPI_Initializer.Initialize();
            // Note -- uncomment the following line to use a custom initialization path
            //bool isInitialized = ZOSAPI_NetHelper.ZOSAPI_Initializer.Initialize(@"C:\Program Files\OpticStudio\");
            if (isInitialized)
            {
                LogInfo("Found OpticStudio at: " + ZOSAPI_NetHelper.ZOSAPI_Initializer.GetZemaxDirectory());
            }
            else
            {
                HandleError("Failed to locate OpticStudio!");
                return;
            }

            BeginUserAnalysis();
        }



        private static void BeginUserAnalysis()
        {
            // Create the initial connection class
            ZOSAPI_Connection TheConnection = new ZOSAPI_Connection();

            // Attempt to connect to the existing OpticStudio instance
            IZOSAPI_Application TheApplication = null;
            try
            {
                TheApplication = TheConnection.ConnectToApplication(); // this will throw an exception if not launched from OpticStudio
            }
            catch (Exception ex)
            {
                HandleError(ex.Message);
                return;
            }
            if (TheApplication == null)
            {
                HandleError("An unknown connection error occurred!");
                return;
            }

            // Check the connection status
            if (!TheApplication.IsValidLicenseForAPI)
            {
                HandleError("Failed to connect to OpticStudio: " + TheApplication.LicenseStatus);
                return;
            }

            // save the primary optical system as a public property
            opticalSystem = TheApplication.PrimarySystem;
            settingsData = TheApplication.UserAnalysisData.UserSettings;

            switch (TheApplication.Mode)
            {
                case ZOSAPI_Mode.UserAnalysis:
                    RunUserAnalysis(TheApplication);
                    break;
                case ZOSAPI_Mode.UserAnalysisSettings:
                    ShowUserAnalysisSettings(TheApplication);
                    break;
                default:
                    HandleError("User plugin was started in the wrong mode: expected UserAnalysis, found " + TheApplication.Mode.ToString());
                    return;
            }

            // Clean up
            FinishUserAnalysis(TheApplication);
        }


        private static void RunUserAnalysis(IZOSAPI_Application TheApplication)
        {
            IOpticalSystem TheSystem = TheApplication.PrimarySystem;

            _initialBfl = TheSystem.LDE.GetSurfaceAt(TheSystem.LDE.NumberOfSurfaces - 2).Thickness;

            IUserAnalysisData TheAnalysisData = TheApplication.UserAnalysisData;
            ISettingsData TheSettings = TheAnalysisData.UserSettings;


            //Console.WriteLine("attach to process");
            //Console.ReadKey();

            // Add your custom code here...
            // get all the settings

            TheSettings.GetBooleanValue(S_AlreadyRanSettingsOnce, out bool bAlreadyRanSettingsOnce);

            if (bAlreadyRanSettingsOnce)
            {
                // get settings from user form
                TheSettings.GetIntegerValue(S_Algorithm, out _algorithm);
                TheSettings.GetIntegerValue(S_PupilSampling, out _pupilSampling);
                TheSettings.GetIntegerValue(S_ImageSampling, out _imageSampling);
                TheSettings.GetIntegerValue(S_Wavelength, out _wavelength);
                TheSettings.GetIntegerValue(S_Field, out _field);
                TheSettings.GetIntegerValue(S_Type, out _type);
                TheSettings.GetIntegerValue(S_NumberOfSteps, out _numberOfSteps);
                TheSettings.GetDoubleValue(S_PsfWidth, out _psfWidth);
                TheSettings.GetDoubleValue(S_MinFocus, out _minFocus);
                TheSettings.GetDoubleValue(S_MaxFocus, out _maxFocus);
                TheSettings.GetBooleanValue(S_UsePolarization, out _usePolarization);
                TheSettings.GetBooleanValue(S_UseCentroid, out _useCentroid);
                TheSettings.GetBooleanValue(S_Normalize, out _normalize);
                TheSettings.GetBooleanValue(S_DisplayTextOutput, out _displayTextOutput);
                TheSettings.GetIntegerValue(S_HuygensMethod, out _huygensMethod);
            }
            else
            {
                // use default initial settings
                _algorithm = initAlgorithm;
                _pupilSampling = initPupilSampling;
                _imageSampling = initImageSampling;
                _wavelength = initWavelength;
                _field = initField;
                _type = initType;
                _numberOfSteps = initNumberOfSteps;
                _psfWidth = initPsfWidth;
                _minFocus = initMinFocus;
                _maxFocus = initMaxFocus;
                _usePolarization = initUsePolarization;
                _useCentroid = initUseCentroid;
                _normalize = initNormalize;
                _displayTextOutput = initDisplayTextOutput;

                switch(opticalSystem.SystemData.Advanced.HuygensIntegralMethod)
                {
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Auto:
                        _huygensMethod = 0; break;
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Planar:
                        _huygensMethod = 1; break;
                    case ZOSAPI.SystemData.HuygensIntegralSettings.Spherical:
                        _huygensMethod = 2; break;
                }
                var textData = TheAnalysisData.MakeText();
                TheAnalysisData.WindowTitle = "Cross Section PSF";
                textData.Data = "Since this analysis can take some time to complete, please run the settings first";
                return;

            }


            // convert the focus to microns then to lens units
            double scalingFactor = 1 / 1000.0;

            switch (opticalSystem.SystemData.Units.LensUnits)
            {
                case ZOSAPI.SystemData.ZemaxSystemUnits.Centimeters:
                    scalingFactor *= 1 / 10.0;
                    break;
                case ZOSAPI.SystemData.ZemaxSystemUnits.Inches:
                    scalingFactor *= 1 / 25.4;
                    break;
                case ZOSAPI.SystemData.ZemaxSystemUnits.Meters:
                    scalingFactor *= 1 / 1000.0;
                    break;
            }
            _minFocus *= scalingFactor;
            _maxFocus *= scalingFactor;

            TheAnalysisData.WindowTitle = "Cross Section PSF: " + (_algorithm == 0 ? "FFT" : "Huygens");



            // initialize the size of the data grid
            int cols = 0;
            if (_algorithm == 0)
            {
                // for 32x32 we do a spline interpolation to 201 points; otherwise we do 2^(n+2)+1 sampling
                if (_pupilSampling == 0)
                { cols = 201; }
                else
                { cols = (int)(Math.Pow(2, _pupilSampling + 5 + 2) + 1); }
            }
            else
            {
                cols = (int)(Math.Pow(2, _imageSampling + 5) + 1);
            }

            // x = number
            double[,] dataGrid = new double[cols, _numberOfSteps];
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            firstTimeRunningPsf = true;

            int numThreads = Process.GetCurrentProcess().Threads.Count;

            if (_algorithm == 0)
            {
                //for (int i = 0; i < _numberOfSteps; i++)
                //{
                //    RunFftPsf(i, ref dataGrid);
                //}

                Parallel.For(0, _numberOfSteps, new ParallelOptions { MaxDegreeOfParallelism = Math.Min(4, numThreads) }, i => {
                    RunFftPsf(i, ref dataGrid);
                });
            }

            string strHuygensMethod = "";

            if (_algorithm == 1)
            {
                //for (int i = 0; i < _numberOfSteps; i++)
                //{
                //    RunHuygensPsf(i, ref dataGrid);
                //}

                switch (_huygensMethod)
                {
                    case 0:
                        opticalSystem.SystemData.Advanced.HuygensIntegralMethod = ZOSAPI.SystemData.HuygensIntegralSettings.Auto;
                        strHuygensMethod = " - Auto";
                        break;
                    case 1:
                        opticalSystem.SystemData.Advanced.HuygensIntegralMethod = ZOSAPI.SystemData.HuygensIntegralSettings.Planar;
                        strHuygensMethod = " - Planar";
                        break;
                    case 2:
                        opticalSystem.SystemData.Advanced.HuygensIntegralMethod = ZOSAPI.SystemData.HuygensIntegralSettings.Spherical;
                        strHuygensMethod = " - Spherical";
                        break;
                }

                

                Parallel.For(0, _numberOfSteps, new ParallelOptions { MaxDegreeOfParallelism = Math.Min(4, numThreads) }, i =>
                {
                    RunHuygensPsf(i, ref dataGrid);
                });

            }
            //var ts = watch.ElapsedMilliseconds;

            //Console.WriteLine(ts);
            //Console.ReadKey();
            // normalize the data grid
            if (_normalize)
            {
                RunNormalization(ref dataGrid);
            }

            if (_displayTextOutput)
            { RunDisplayTextOutput(dataGrid); }

            //var textData = TheAnalysisData.MakeText();
            var gridData = TheAnalysisData.MakeGridPlot("Through Focus PSF" + strHuygensMethod);
            gridData.SetDataSafe(dataGrid);
            gridData.ShowAsType = GridPlotType.FalseColor;

            double deltaStep = getBflFromStepNumber(1) - getBflFromStepNumber(0);


            //Console.WriteLine("number of x data values: " + gridData.NumberOfXDataValues);
            //Console.WriteLine("number of y data values: " + gridData.NumberOfYDataValues);
            //Console.WriteLine("aspect ratio : " + gridData.XYAspectRatio);



            // weird condition where if there are not enough data points in the x axis the ratio is off
            if (_numberOfSteps == 2)
            { gridData.XYAspectRatio = gridData.NumberOfYDataValues / (double)gridData.NumberOfXDataValues; }
            else if (_numberOfSteps < 10)
            { gridData.XYAspectRatio = (1 + gridData.NumberOfXDataValues / (double)gridData.NumberOfYDataValues); }
            else
            { gridData.XYAspectRatio = 1; }

            double deltaY = Math.Abs(_x1 - _x2);

            //Console.WriteLine("x1        : " + _x1);
            //Console.WriteLine("x2        : " + _x2);
            //Console.WriteLine("col       : " + cols);
            //Console.WriteLine("delta y   : " + deltaY);
            //Console.WriteLine("y-max     : " + (deltaY * (cols - 1) / 2));

            // need to add an extra 'deltaStep' and 'deltaY' because the API has an off-by-1 error on the top & right of the dataset
            gridData.SetXDataDimensions(_initialBfl + _minFocus, _initialBfl + _maxFocus + deltaStep + deltaStep);
            gridData.SetYDataDimensions(-deltaY * (cols - 1) / 2, deltaY * (cols - 1) / 2 + deltaY);

            gridData.InterpolateLowResolutionContours = true;

            // allow the API to automatically scale the data
            gridData.XAxisMinAuto = true;
            gridData.XAxisMaxAuto = true;
            gridData.YAxisMinAuto = true;
            gridData.YAxisMaxAuto = true;

            // 
            //gridData.XAxisMinAuto = false;
            //gridData.XAxisMaxAuto = false;
            //gridData.YAxisMinAuto = false;
            //gridData.YAxisMaxAuto = false;

            //gridData.XAxisMin = _initialBfl + _minFocus;
            //gridData.XAxisMax = _initialBfl + _maxFocus;
            //gridData.YAxisMin = -deltaY * (cols - 1) / 2;
            //gridData.YAxisMax = deltaY * (cols - 1) / 2 - deltaY;


            gridData.XLabel = $"Z Thickness ({opticalSystem.SystemData.Units.LensUnits})";
            gridData.YLabel = "PSF Distance (um)";
            if (_normalize)
            { gridData.ValueLabel = "Normalized"; }
            else
            { gridData.ValueLabel = "Strehl Ratio"; }


            //Console.WriteLine("press any key to continue");
            //Console.ReadKey();

            // Use TheAnalysisData to create a specific plot type and populate the data
            //IUser2DLineData linePlot = TheAnalysisData.Make2DLinePlot("New 2D Line Plot", 1, new double[] { 1, 2, 3 });
            //linePlot.AddSeries(...);
        }

        private static double getBflFromStepNumber(int stepNumber)
        {
            return _initialBfl + _minFocus + (_maxFocus - _minFocus) / (_numberOfSteps - 1) * stepNumber;
        }

        private static void RunDisplayTextOutput(double[,] dataGrid)
        {
            string tmpName = Path.Combine(Path.GetDirectoryName(opticalSystem.SystemFile), "Through_Focus_PSF.txt");
            using (StreamWriter file = new StreamWriter(tmpName))
            {
                for (int i = 0; i < dataGrid.GetLength(0); i++)
                {
                    for (int j = 0; j < dataGrid.GetLength(1); j++)
                    {
                        file.Write(dataGrid[i, j].ToString("e10").PadLeft(15) + "\t");
                    }
                    file.Write("\n");
                }
            }

            try
            {
                // need to move the tmpName file over to the working directory and rename so we don't keep it after we need it
                Process.Start("notepad.exe", tmpName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not file 'notepad.exe'");
            }
        }

        private static void RunFftPsf(int stepNumber, ref double[,] dataGrid)
        {
            IOpticalSystem copySystem = opticalSystem.CopySystem();
            copySystem.LDE.GetSurfaceAt(copySystem.LDE.NumberOfSurfaces - 2).Thickness = getBflFromStepNumber(stepNumber);

            var win = copySystem.Analyses.New_Analysis(AnalysisIDM.FftPsfCrossSection);
            var win_settings = win.GetSettings() as IAS_FftPsfCrossSection;
            win_settings.Field.SetFieldNumber(_field);
            if (_wavelength == 0) { win_settings.Wavelength.UseAllWavelengths(); }
            else { win_settings.Wavelength.SetWavelengthNumber(_wavelength); }
            win_settings.SampleSize = (SampleSizes)(_pupilSampling + 1);
            win_settings.Type = (ZOSAPI.Analysis.Settings.PsfTypes)_type;
            win_settings.UsePolarization = _usePolarization;
            win_settings.Normalize = false;
            win_settings.RowCol = 0;        // this should always be the center row/col
            win_settings.PlotScale = _psfWidth;

            win.ApplyAndWaitForCompletion();

            var win_results = win.GetResults();


            // if too many waves of OPD, then FFT fails (BFL was too null...need to pass this back to the user) 
            if (win_results.DataSeries.Length > 0 && win_results.DataSeries[0].YData != null)
            {
                // we don't pass the actual grid spacing in the API...need to manually calculate
                if (firstTimeRunningPsf)
                {
                    _x1 = win_results.DataSeries[0].XData.Data[0];
                    _x2 = win_results.DataSeries[0].XData.Data[1];
                    firstTimeRunningPsf = false;
                }

                var ydata = win_results.DataSeries[0].YData;
                for (int i = 0; i < ydata.Data.GetLength(0); i++)
                {
                    dataGrid[i, stepNumber] = ydata.GetValueAt(i, 0);
                }
            }
            win.Close();
            copySystem.Close(false);
        }

        private static void RunHuygensPsf(int stepNumber, ref double[,] dataGrid)
        {
            IOpticalSystem copySystem = opticalSystem.CopySystem();
            copySystem.LDE.GetSurfaceAt(copySystem.LDE.NumberOfSurfaces - 2).Thickness = getBflFromStepNumber(stepNumber);

            var hpsf = copySystem.Analyses.New_Analysis(AnalysisIDM.HuygensPsfCrossSection);
            var hpsf_settings = hpsf.GetSettings() as IAS_HuygensPsfCrossSection;
            hpsf_settings.PupilSampleSize = (SampleSizes)(_pupilSampling + 1);
            hpsf_settings.ImageSampleSize = (SampleSizes)(_imageSampling + 1);
            hpsf_settings.ImageDelta = 0;
            if (_wavelength == 0) { hpsf_settings.Wavelength.UseAllWavelengths(); }
            else { hpsf_settings.Wavelength.SetWavelengthNumber(_wavelength); }
            hpsf_settings.Field.SetFieldNumber(_field);
            hpsf_settings.Type = (ZOSAPI.Analysis.Settings.PsfTypes)_type;
            hpsf_settings.UsePolarization = _usePolarization;
            hpsf_settings.UseCentroid = _useCentroid;
            hpsf_settings.Normalize = false;
            hpsf_settings.ImageDelta = (2 * _psfWidth) / Math.Pow(2, _imageSampling + 5);

            hpsf.ApplyAndWaitForCompletion();

            var hpsf_results = hpsf.GetResults();

            if (hpsf_results.DataSeries.Length > 0 && hpsf_results.DataSeries[0].YData != null)
            {
                // we don't pass the actual grid spacing in the API...need to manually calculate
                if (firstTimeRunningPsf)
                {
                    _x1 = hpsf_results.DataSeries[0].XData.Data[0];
                    _x2 = hpsf_results.DataSeries[0].XData.Data[1];
                    firstTimeRunningPsf = false;
                }

                var ydata = hpsf_results.DataSeries[0].YData;
                for (int i = 0; i < ydata.Data.GetLength(0); i++)
                {
                    dataGrid[i, stepNumber] = ydata.GetValueAt(i, 0);
                }
            }
            hpsf.Close();
            copySystem.Close(false);
        }

        private static void RunNormalization(ref double[,] dataGrid)
        {
            var max = dataGrid.Cast<double>().Max();
            for (int i = 0; i < dataGrid.GetLength(0); i++)
            {
                for (int j = 0; j < dataGrid.GetLength(1); j++)
                {
                    dataGrid[i, j] /= max;
                }
            }
        }

        private static void ShowUserAnalysisSettings(IZOSAPI_Application TheApplication)
        {
            IOpticalSystem TheSystem = TheApplication.PrimarySystem;

            IUserAnalysisData TheAnalysisData = TheApplication.UserAnalysisData;
            ISettingsData TheSettings = TheAnalysisData.UserSettings;

            // TODO - retrieve the settings specific to your analysis here

            // This will show a form to modify your settings (currently blank)...
            AnalysisSettingsForm SettingsForm = new AnalysisSettingsForm();
            // Add your custom code here, and to the SettingsForm...
            System.Windows.Forms.Application.Run(SettingsForm);

            // TODO - write settings back to TheSettings

            if (SettingsForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

                TheSettings.SetIntegerValue(S_Algorithm, SettingsForm._algorithm);
                TheSettings.SetIntegerValue(S_PupilSampling, SettingsForm._pupilSampling);
                TheSettings.SetIntegerValue(S_ImageSampling, SettingsForm._imageSampling);
                TheSettings.SetIntegerValue(S_Wavelength, SettingsForm._wavelength);
                TheSettings.SetIntegerValue(S_Field, SettingsForm._field);
                TheSettings.SetIntegerValue(S_Type, SettingsForm._type);
                TheSettings.SetIntegerValue(S_NumberOfSteps, SettingsForm._numberOfSteps);
                TheSettings.SetDoubleValue(S_PsfWidth, SettingsForm._psfWidth);
                TheSettings.SetDoubleValue(S_MinFocus, SettingsForm._minFocus);
                TheSettings.SetDoubleValue(S_MaxFocus, SettingsForm._maxFocus);
                TheSettings.SetBooleanValue(S_UsePolarization, SettingsForm._usePolarization);
                TheSettings.SetBooleanValue(S_Normalize, SettingsForm._normalize);
                TheSettings.SetBooleanValue(S_UseCentroid, SettingsForm._useCentroid);
                TheSettings.SetBooleanValue(S_DisplayTextOutput, SettingsForm._displayTextOutput);
                TheSettings.SetIntegerValue(S_HuygensMethod, SettingsForm._huygensMethod);

                // the settings have been run at least 1 time
                TheSettings.SetBooleanValue(S_AlreadyRanSettingsOnce, true);


                TheAnalysisData.RunAnalysisOnSettingsClosed = true;
            }
            else
            {
                TheAnalysisData.RunAnalysisOnSettingsClosed = false;
            }
        }

        private static void FinishUserAnalysis(IZOSAPI_Application TheApplication)
        {
            // Note - OpticStudio will wait for the operand to complete until this application exits 
        }

        private static void LogInfo(string message)
        {
            // TODO - add custom logging
            Console.WriteLine(message);
        }

        private static void HandleError(string errorMessage)
        {
            // TODO - add custom error handling
            throw new Exception(errorMessage);
        }

    }
}

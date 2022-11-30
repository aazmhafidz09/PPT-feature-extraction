using NWaves.FeatureExtractors.Options;
using NWaves.Windows;

namespace NWaves.Playground.Util
{
    public static class MfccTemplates
    {
        const string LibrosaPythonTemplate = "import librosa\n\n" +
                           "wavData, sr = librosa.load(FILE_PATH, sr=16000)\n\n" +
                           "mfcc = librosa.feature.mfcc(\n" +
                           "    wavData,\n" +
                           "    16000,\n" +
                           "    n_mfcc={1},\n" +
                           "    dct_type={2},\n" +
                           "    norm={3},\n" +
                           "    window={4},\n" +
                           "    htk=False,\n" +
                           "    n_mels={5},\n" +
                           "    fmin={6},\n" +
                           "    fmax={7},\n" +
                           "    n_fft={8},\n" +
                           "    hop_length={9},\n" +
                           "    lifter={10},\n" +
                           "    power={11},\n" +
                           "    center=False).T\n\n" +
                           "mfcc[:, 0]   # get the first vector\n";

        const string PsfPythonTemplate = "import python_speech_features\n" +
                                   "import scipy.io.wavfile as wav\n" +
                                   "import numpy\n\n" +
                                   "sr, signal = wav.read(FILE_PATH)\n\n" +
                                   "signal = signal / 32768\n\n" +
                                   "mfcc = python_speech_features.base.mfcc(\n" +
                                   "    signal,\n" +
                                   "    samplerate={0},\n" +
                                   "    winlen={1},\n" +
                                   "    winstep={2},\n" +
                                   "    numcep={3},\n" +
                                   "    nfilt={4},\n" +
                                   "    nfft={5},\n" +
                                   "    lowfreq={6},\n" +
                                   "    highfreq={7},\n" +
                                   "    preemph={8},\n" +
                                   "    ceplifter={9},\n" +
                                   "    appendEnergy={10},\n" +
                                   "    winfunc={11}).T\n\n" +
                                   "mfcc[0]   # get the first vector\n";

        const string KaldiPythonTemplate = "import torchaudio\n" +
                                     "import torchaudio.compliance.kaldi\n\n" +
                                     "signal, sample_rate = torchaudio.load(FILE_PATH)\n\n" +
                                     "mfcc = torchaudio.compliance.kaldi.mfcc(\n" +
                                     "    signal,\n" +
                                     "    {0},\n" +
                                     "    num_ceps={1},\n" +
                                     "    num_mel_bins={2},\n" +
                                     "    frame_length={3},\n" +
                                     "    frame_shift={4},\n" +
                                     "    low_freq={5},\n" +
                                     "    high_freq={6},\n" +
                                     "    window_type={7},\n" +
                                     "    cepstral_lifter={8},\n" +
                                     "    preemphasis_coefficient={9},\n" +
                                     "    use_energy={10},\n" +
                                     "    remove_dc_offset={11}).T\n\n" +
                                     "mfcc[0]   # get the first vector\n";

        const string PytorchPythonTemplate = "import torchaudio\n" +
                                       "import torchaudio.transforms as T\n" +
                                       "import librosa\n\n" +
                                       "signal, sample_rate = torchaudio.load(FILE_PATH)\n\n" +
                                       "mfcc_transform = T.MFCC(\n" +
                                       "    sample_rate={0},\n" +
                                       "    n_mfcc={1},\n" +
                                       "    melkwargs={{\n" +
                                       "       'n_mels': {2},\n" +
                                       "       'n_fft': {3},\n" +
                                       "       'hop_length': {4},\n" +
                                       "       'f_min': {5},\n" +
                                       "       'f_max': {6},\n" +
                                       "       'power': {7},\n" +
                                       "       'center': False,\n" +
                                       "       'mel_scale': 'htk', # or 'slaney' if in librosa htk=False\n" +
                                       "       'norm': None        # or 'slaney' if in librosa norm='slaney'\n" +
                                       "       }}\n" +
                                       "    )\n\n" +
                                       "mfcc = mfcc_transform(signal)\n\n" +
                                       "#librosa: \n" +
                                       "melspec = librosa.feature.melspectrogram(\n" +
                                       "    y=signal.numpy()[0], sr={0}, n_fft={3},\n" +
                                       "    win_length={3}, hop_length={4},\n" +
                                       "    n_mels={2}, fmin={5}, fmax={6},\n" +
                                       "    power={7}, htk=True, norm=None, center=False)\n\n" +
                                       "mfcc_librosa = librosa.feature.mfcc(\n" +
                                       "    S = librosa.core.spectrum.power_to_db(melspec),\n" +
                                       "    n_mfcc={1}, dct_type=2, norm='ortho')\n\n" +
                                       "mfcc[0][:, 0]   # get the first vector\n";

        const string MelSpectrogramPythonTemplate = "import torchaudio\n" +
                               "import torchaudio.transforms as T\n" +
                               "import librosa\n\n" +
                               "wavData, sample_rate = torchaudio.load(FILE_PATH)\n\n" +                               
                               "melspec = librosa.feature.melspectrogram(\n" +
                               "    y=wavData.numpy()[0], sr={0}, n_fft={3},\n" +
                               "    win_length={1}, hop_length={2},\n" +
                               "    n_mels={5}, fmin={6}, fmax={7},\n" +
                               "    power={4}, htk={10}, norm={8}, center=False)\n\n" +
                               "melspec[:, 0]   # get the first vector\n";

        const string LibrosaCSharpTemplate = "var options = new MfccOptions\n{{\n" +
                   "    SamplingRate = {0},\n" +
                   "    FeatureCount = {1},\n" +
                   "    FrameSize = {2},\n" +
                   "    HopSize = {3},\n" +
                   "    DctType = \"{4}\",\n" +
                   "    Window = WindowType.{5},\n" +
                   "    FilterBank = FilterBanks.MelBankSlaney({6}, {7}, {0}, {8}, {9}),\n" +
                   "    LifterSize = {10},\n" +
                   "    NonLinearity = NonLinearityType.ToDecibel,\n" +
                   "    LogFloor = 1e-10f,\n" +
                   "    SpectrumType = SpectrumType.{11}\n}};\n\n" +
                   "var extractor = new MfccExtractor(options);\n" +
                   "var mfccs = extractor.ComputeFrom(signal);\n";

        const string PytorchCSharpTemplate = "var options = new MfccOptions\n{{\n" +
                   "    SamplingRate = {0},\n" +
                   "    FeatureCount = {1},\n" +
                   "    FrameSize = {2},\n" +
                   "    HopSize = {3},\n" +
                   "    FilterBankSize = {4},\n" +
                   "    LowFrequency = {5},\n" +
                   "    HighFrequency = {6},\n" +
                   "    DctType = \"{7}\",\n" +
                   "    Window = WindowType.{8},\n" +
                   "    FftSize = {9},\n" +
                   "    LifterSize = {10},\n" +
                   "    NonLinearity = NonLinearityType.ToDecibel,\n" +
                   "    LogFloor = 1e-10f,\n" +
                   "    SpectrumType = SpectrumType.{11}\n}};\n\n" +
                   "var extractor = new MfccExtractor(options);\n" +
                   "var mfccs = extractor.ComputeFrom(signal);\n";

        const string KaldiCSharpTemplate = "var options = new MfccOptions\n{{\n" +
                   "    SamplingRate = {0},\n" +
                   "    FeatureCount = {1},\n" +
                   "    FrameDuration = {2},\n" +
                   "    HopDuration = {3},\n" +
                   "    FilterBankSize = {4},\n" +
                   "    LowFrequency = {5},\n" +
                   "    HighFrequency = {6},\n" +
                   "    FftSize = {7},\n" +
                   "    DctType = \"{8}\",\n" +
                   "    Window = WindowType.{9},\n" +
                   "    LifterSize = {10},\n" +
                   "    NonLinearity = NonLinearityType.LogE,\n" +
                   "    PreEmphasis = {11},\n" +
                   "    IncludeEnergy = {12},\n" +
                   "    SpectrumType = SpectrumType.{13}\n}};\n\n" +
                   "var extractor = new MfccExtractor(options);\n" +
                   "var mfccs = extractor.ComputeFrom(signal);\n";

        const string PsfCSharpTemplate = "var options = new MfccOptions\n{{\n" +
                   "    SamplingRate = {0},\n" +
                   "    FeatureCount = {1},\n" +
                   "    FrameSize = {2},\n" +
                   "    HopSize = {3},\n" +
                   "    DctType = \"{4}\",\n" +
                   "    Window = WindowType.{5},\n" +
                   "    FilterBank = PythonSpeechFeatures.FilterBank({0}, {6}, {7}, {8}, {9}),\n" +
                   "    LifterSize = {10},\n" +
                   "    NonLinearity = NonLinearityType.LogE,\n" +
                   "    PreEmphasis = {11},\n" +
                   "    IncludeEnergy = {12},\n" +
                   "    SpectrumType = SpectrumType.PowerNormalized\n}};\n\n" +
                   "var extractor = new MfccExtractor(options);\n" +
                   "var mfccs = extractor.ComputeFrom(signal);\n";

        const string MelSpectrogramCSharpTemplate = "var options = new FilterbankOptions\n{{\n" +
                   "    SamplingRate = {0},\n" +
                   "    FrameSize = {1},\n" +
                   "    HopSize = {2},\n" +
                   "    FilterBank = {3},\n" +
                   "    FftSize = {4},\n" +
                   "    Window = WindowType.{5},\n" +
                   "    NonLinearity = NonLinearityType.{6},\n" +
                   "    SpectrumType = SpectrumType.{7}\n}};\n\n" +
                   "var extractor = new FilterbankExtractor(options);\n" +
                   "var melSpectrogram = extractor.ComputeFrom(signal);\n";


        static string LibrosaWindowString(WindowType window)
        {
            return window switch
            {
                WindowType.Hamming => "hamming",
                WindowType.Blackman => "blackman",
                _ => "hann",
            };
        }

        static string KaldiWindowString(WindowType window)
        {
            return window switch
            {
                WindowType.Hamming => "hamming",
                WindowType.Blackman => "blackman",
                WindowType.Rectangular => "rectangular",
                _ => "hanning",
            };
        }

        static string NumpyWindowString(WindowType window)
        {
            return window switch
            {
                WindowType.Hamming => "numpy.hamming",
                WindowType.Blackman => "numpy.blackman",
                _ => "numpy.hanning",
            };
        }

        public static string PythonCode(MfccMode mode, MfccOptions options, bool inSeconds = true, bool removeDcOffset = false)
        {
            return mode switch
            {
                MfccMode.Librosa => string.Format
                (
                    LibrosaPythonTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    options.DctType[0],
                    options.DctType.EndsWith("N") ? "'ortho'" : "None",
                    $"'{LibrosaWindowString(options.Window)}'",
                    options.FilterBank.Length,
                    options.LowFrequency,
                    options.HighFrequency > 0 ? options.HighFrequency : "None",
                    options.FftSize,
                    options.HopSize,
                    options.LifterSize,
                    options.SpectrumType == SpectrumType.Magnitude ||
                    options.SpectrumType == SpectrumType.MagnitudeNormalized ? 1 : 2),                   

                MfccMode.PythonSpeechFeatures => string.Format
                (
                    PsfPythonTemplate,
                    options.SamplingRate,
                    inSeconds ? options.FrameDuration : (double)options.FrameSize / options.SamplingRate,
                    inSeconds ? options.HopDuration : (double)options.HopSize / options.SamplingRate,
                    options.FeatureCount,
                    options.FilterBank.Length,
                    options.FftSize,
                    options.LowFrequency,
                    options.HighFrequency,
                    options.PreEmphasis,
                    options.LifterSize,
                    options.IncludeEnergy,
                    $"{NumpyWindowString(options.Window)}"),

                MfccMode.PyTorch => string.Format
                (
                    PytorchPythonTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    options.FilterBankSize,
                    options.FftSize,
                    options.HopSize,
                    options.LowFrequency,
                    options.HighFrequency > 0 ? options.HighFrequency : "None",
                    options.SpectrumType == SpectrumType.Magnitude ||
                    options.SpectrumType == SpectrumType.MagnitudeNormalized ? 1 : 2),

                _ => string.Format
                (
                    KaldiPythonTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    options.FilterBankSize,
                    inSeconds ? options.FrameDuration * 1000 : options.FrameSize * 1000.0 / options.SamplingRate,
                    inSeconds ? options.HopDuration * 1000 : options.HopSize * 1000.0 / options.SamplingRate,
                    options.LowFrequency,
                    options.HighFrequency,
                    $"'{KaldiWindowString(options.Window)}'",
                    options.LifterSize,
                    options.PreEmphasis,
                    options.IncludeEnergy,
                    removeDcOffset)
            };
        }

        public static string PythonCode(FilterbankOptions options, bool slaney)
        {
            return string.Format(
                MelSpectrogramPythonTemplate,
                options.SamplingRate,
                options.FrameSize,
                options.HopSize,
                options.FftSize,
                options.SpectrumType == SpectrumType.Magnitude ||
                options.SpectrumType == SpectrumType.MagnitudeNormalized ? 1 : 2,
                options.FilterBank.Length,
                options.LowFrequency,
                options.HighFrequency > 0 ? options.HighFrequency : "None",
                slaney ? "'slaney'" : "None",
                slaney ? "'slaney'" : "'htk'",
                !slaney);
        }


        public static string CSharpCode(MfccMode mode, MfccOptions options, bool inSeconds = true, bool removeDcOffset = false)
        {
            return mode switch
            {
                MfccMode.Librosa => string.Format
                (
                    LibrosaCSharpTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    options.FrameSize,
                    options.HopSize,
                    options.DctType,
                    options.Window,
                    options.FilterBank.Length,
                    options.FftSize,
                    options.LowFrequency,
                    options.HighFrequency,
                    options.LifterSize,
                    options.SpectrumType),

                MfccMode.PythonSpeechFeatures => string.Format
                (
                    PsfCSharpTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    inSeconds ? options.FrameDuration : (double)options.FrameSize / options.SamplingRate,
                    inSeconds ? options.HopDuration : (double)options.HopSize / options.SamplingRate,
                    options.DctType,
                    options.Window,
                    options.FilterBank.Length,
                    options.FftSize,
                    options.LowFrequency,
                    options.HighFrequency,
                    options.LifterSize,
                    options.PreEmphasis,
                    options.IncludeEnergy ? "true" : "false")
                .PostProcess(inSeconds)
                .AddPsfCorrection(options.IncludeEnergy),

                MfccMode.PyTorch => string.Format
                (
                    PytorchCSharpTemplate,
                    options.SamplingRate,
                    options.FeatureCount,
                    options.FrameSize,
                    options.HopSize,
                    options.FilterBankSize,
                    options.LowFrequency,
                    options.HighFrequency,
                    options.DctType,
                    options.Window,
                    options.FftSize,
                    options.LifterSize,
                    options.SpectrumType),

                _ => removeDcOffset ?
                    string.Format
                    (
                        KaldiCSharpTemplate,
                        options.SamplingRate,
                        options.FeatureCount,
                        inSeconds ? options.FrameDuration : (double)options.FrameSize / options.SamplingRate,
                        inSeconds ? options.HopDuration : (double)options.HopSize / options.SamplingRate,
                        options.FilterBankSize,
                        options.LowFrequency,
                        options.HighFrequency,
                        options.FftSize,
                        options.DctType,
                        WindowType.Rectangular,
                        options.LifterSize,
                        options.PreEmphasis,
                        options.IncludeEnergy ? "true" : "false",
                        options.SpectrumType)
                    .PostProcess(inSeconds)
                    .Replace("Extractor(options)", $"ExtractorKaldi(options, WindowType.{options.Window})")
                    :
                    string.Format
                    (
                        KaldiCSharpTemplate,
                        options.SamplingRate,
                        options.FeatureCount,
                        inSeconds ? options.FrameDuration : (double)options.FrameSize / options.SamplingRate,
                        inSeconds ? options.HopDuration : (double)options.HopSize / options.SamplingRate,
                        options.FilterBankSize,
                        options.LowFrequency,
                        options.HighFrequency,
                        options.FftSize,
                        options.DctType,
                        options.Window,
                        options.LifterSize,
                        options.PreEmphasis,
                        options.IncludeEnergy ? "true" : "false",
                        options.SpectrumType)
                    .PostProcess(inSeconds)
            };
        }

        public static string CSharpCode(FilterbankOptions options, bool slaney)
        {
            var filterbank = "var filterbank = FilterBanks.";

            if (slaney)
            {
                filterbank += $"Slaney({options.FilterBank.Length}, {options.FftSize}, {options.SamplingRate}, {options.LowFrequency}, {options.HighFrequency})\n\n";
            }
            else
            {
                var bands = $"FilterBanks.MelBands({options.FilterBank.Length}, {options.SamplingRate}, {options.LowFrequency}, {options.HighFrequency})";
                filterbank += $"Triangular({options.FilterBank.Length}, {options.SamplingRate}, {bands}, mapper: Scale.HerzToMel)\n\n";
            }

            return filterbank + string.Format
                (
                    MelSpectrogramCSharpTemplate,
                    options.SamplingRate,
                    options.FrameSize,
                    options.HopSize,
                    "filterbank",
                    options.FftSize,
                    options.Window,
                    options.NonLinearity,
                    options.SpectrumType);
        }
    }
}

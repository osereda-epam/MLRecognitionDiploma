namespace MLRecognitionDiploma.Models
{
    internal class ImageOutputModel
    {
        public float[] Score { get; set; } = Array.Empty<float>();

        public string PredictedLabel { get; set; } = string.Empty;
    }
}

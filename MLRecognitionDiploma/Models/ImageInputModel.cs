namespace MLRecognitionDiploma.Models
{
    internal class ImageInputModel
    {
        public byte[] Image { get; set; } = Array.Empty<byte>();

        public string ImagePath { get; set; } = string.Empty;

        public string Label { get; set; } = string.Empty;
    }
}

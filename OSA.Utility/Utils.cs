using Microsoft.AspNetCore.Http;

namespace OSA.Utility
{
    public static class Utils
    {
        private static readonly string empty = string.Empty;
        public static string RootPath = empty;
        public static DateTime CurrentDateTime = DateTime.Now;

        public static byte[] ConvertBase64ToByte(string base64StringRequest)
        {
            if(base64StringRequest == null || base64StringRequest.Length <= 0)
                return new byte[0];
                
            return Convert.FromBase64String(base64StringRequest);            
        }

        public static string ConvertByteToBase64(byte[] requestBytes)
        {
            if (requestBytes == null || requestBytes.Length <= 0)
                return "";

            return Convert.ToBase64String(requestBytes);
        }

        public static string ConvertIFromFileToBase64(IFormFile formFile)
        {
            if (formFile == null)
                return "";

            using (var memoryStream = new MemoryStream())
            {
                formFile.CopyTo(memoryStream);
                return ConvertByteToBase64(memoryStream.ToArray());
            }
        }
    }
}

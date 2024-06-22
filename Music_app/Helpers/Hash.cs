namespace Music_app.Helpers
{
    public class Hash
    {
        public static string GenerateShortGuid()
        {
            string fullGuid = Guid.NewGuid().ToString();
            // Chọn 15 ký tự đầu tiên từ GUID
            string shortGuid = fullGuid.Substring(0, 15);
            return shortGuid;
        }
    }
   
}
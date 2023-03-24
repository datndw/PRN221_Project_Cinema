namespace PRN221_Project_Cinema.Extensions
{
    public static class StringHandlers
    {
        public static string StringShortener(this string raw, int numberOfChar)
        {
            return !String.IsNullOrWhiteSpace(raw) 
                && raw.Length >= numberOfChar - 3
                ? raw.Substring(0, numberOfChar - 3) 
                + "..."
                : raw;
        }
    }
}

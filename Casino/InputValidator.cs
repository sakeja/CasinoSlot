namespace Casino
{
    public static class InputValidator
    {
        public static bool ValidateInput(uint a)
        {
            if (a < uint.MinValue || a > uint.MaxValue) return false;
            else return true;
        }

        public static bool ValidateInput(uint a, uint b)
        {
            if (a < b) return false;
            else return true;
        }

        public static bool ValidateInput(string a)
        {
            if (string.IsNullOrWhiteSpace(a)) return false;
            else return true;
        }
    }
}

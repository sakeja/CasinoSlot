namespace Casino
{
    public static class InputValidator
    {
        public static bool ValidateInput(uint a)
        {
            return (a < uint.MinValue || a > uint.MaxValue) ? false : true;
        }

        public static bool ValidateInput(uint a, uint b)
        {
            if (!ValidateInput(a) || !ValidateInput(b)) return false;
            else return (a < b) ? false : true;
        }

        public static bool ValidateInput(string a)
        {
            return (string.IsNullOrWhiteSpace(a)) ? false : true;
        }
    }
}

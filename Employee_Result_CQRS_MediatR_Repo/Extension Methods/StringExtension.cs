namespace Employee_Result_CQRS_MediatR_Repo.Extension_Methods
{
    public static class StringExtension
    {
        public static int GetCountWords(this string str)
        {
            return str.Split(" ").Length;
        }
    }
}

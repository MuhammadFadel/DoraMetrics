namespace Helpers.ClientServices
{
    public class SD
    {
        public static string GitlabApiBase { get; set; }
        public static string JiraApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
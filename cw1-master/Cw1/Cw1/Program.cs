using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {

        //public static void Main(string[] args)
        // {
        //     var newPerson = new Person
        //     {
        //         FirstName = "Hubert"
        //     };

        //     var path = @"C:\Users\s18989\Desktop";
        // }

        public static async Task Main(string[] args)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(args[0]))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var list = ExtractEmails(htmlContent);
                        foreach (string s in list)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }

            }

        }
        public static string[] ExtractEmails(string str)
        {
            string RegexPattern = @"\b[A-Z0-9._-]+@[A-Z0-9][A-Z0-9.-]{0,61}[A-Z0-9]\.[A-Z.]{2,6}\b";
            System.Text.RegularExpressions.MatchCollection matches = System.Text.RegularExpressions.Regex.Matches(str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string[] MatchList = new string[matches.Count];
            int c = 0;
            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                MatchList[c] = match.ToString();
                c++;
            }
            return MatchList;
        }

    }
}

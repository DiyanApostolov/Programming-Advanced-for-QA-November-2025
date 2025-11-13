
namespace _02.Article
{
    class Program
    {
        public static void Main(string[] arg)
        {
            string[] articleInfo = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            string title = articleInfo[0];
            string content = articleInfo[1];
            string autoh = articleInfo[2];

            Article article = new Article(title, content, autoh);
            
            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split(": ");
                string command = cmdArg[0];
                string newInfo = cmdArg[1];

                if (command == "Edit")
                {
                    article.Edit(newInfo);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newInfo);
                }
                else if (command == "Rename")
                {
                    article.Rename(newInfo);
                }
            }

            Console.WriteLine(article.ToString());
        }
    }
}




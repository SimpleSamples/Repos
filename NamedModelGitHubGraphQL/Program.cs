using Octokit.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedModelGitHubGraphQL
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMethod().Wait();
        }

        private static async Task AsyncMethod()
        {
            var productInformation = new ProductHeaderValue("octokit" /*, "YOUR_PRODUCT_VERSION"*/);
            var connection = new Connection(productInformation, "e79dff131a218f9ee764f8ed8a7a065af0bcc3b3");

            Octokit.GraphQL.Core.IQueryableValue<RepositoryModel> query = new Query()
                .Repository("octokit.graphql.net", "octokit")
                .Select(r => new RepositoryModel
                {
                    Name = r.Name,
                    Description = r.Description,
                    //Issues = r.Issues(100, null, null, null, null, null, null).Select(i => new IssueModel
                    //{
                    //    Number = i.Number,
                    //    Title = i.Title,
                    //}).ToList(),
                });
            try
            {
                RepositoryModel result = await connection.Run(query);
                if (result != null)
                    Console.WriteLine(result.Name + " & " + result.Description);
                else
                    Console.WriteLine("Null result");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("InnerException: {0}", ex.InnerException.Message);
            }
        }
    }

    class RepositoryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IssueModel> Issues { get; set; }
    }

    class IssueModel
    {
        public int Number { get; set; }
        public string Title { get; set; }
    }
}


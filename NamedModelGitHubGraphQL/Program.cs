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
            string token;
            Connection connection;
            token = System.Environment.GetEnvironmentVariable("GitHubTokenEX"); 
            var productInformation = new ProductHeaderValue("octokit");
            try { connection = new Connection(productInformation, token); }
            catch (Exception ex)
            {
                Console.WriteLine("Connection error: " + ex.Message);
                return;
            }
            // Repository.Issues is an IssueConnection
            Octokit.GraphQL.Core.IQueryableValue<RepositoryModel> query = new Query()
                .Repository("octokit.graphql.net", "octokit")
                .Select(r => new RepositoryModel
                {
                    Name = r.Name,
                    Description = r.Description,
                    TotalCount = r.Issues(100, null, null, null, null, null, null).TotalCount,
                    Issues = r.Issues(100, null, null, null, null, null, null)
                        .Nodes.Select(i => new IssueModel
                        {
                            Number = i.Number,
                            Title = i.Title,
                        }).ToList(),
                });
            try
            {
                RepositoryModel result = await connection.Run(query);
                if (result != null)
                {
                    Console.WriteLine($"{result.Name} ({result.Description}) has {result.TotalCount} issues");
                    foreach (IssueModel i in result.Issues)
                        Console.WriteLine($"{i.Number} {i.Title}");
                }
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
        public int TotalCount;
    }

    class IssueModel
    {
        public int Number { get; set; }
        public string Title { get; set; }
    }
}

using Octokit.GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This does not work.

namespace GitHubRepositoryCount
{
    class Program
    {

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
            // query { 
            //   viewer { 
            //     login, location, name,
            //     repositories {
            //       totalCount 
            //     }
            //   }
            // }
            Octokit.GraphQL.Core.IQueryableValue<UserModel> query = new Query()
                .Viewer
                .Select(u => new UserModel
                {
                    Login = u.Login,
                    Location = u.Location,
                    Name = u.Name,
                    // Repositories(
                    // Arg<int>? first = null
                    // Arg<string>? after = null
                    // Arg<int>? last = null
                    // Arg<string>? before = null
                    // Arg<IEnumerable<RepositoryAffiliation?>>? affiliations = null
                    // Arg<bool>? isFork = null
                    // Arg<bool>? isLocked = null
                    // Arg<RepositoryOrder>? orderBy = null
                    // Arg<IEnumerable<RepositoryAffiliation?>>? ownerAffiliations = null
                    // Arg<RepositoryPrivacy>? privacy = null
                    //)
                    Repositories = u.Repositories(9999, null, 9999, null, null, null, null, null, null, null)
                    .Select(t => new RepositoriesModel { TotalCount = t.TotalCount })
                });
            try
            {
                UserModel result = await connection.Run(query);
                if (result != null)
                {
                    Console.WriteLine($"{result.Login} in {result.Location} ({result.Name}) has {result.Repositories.TotalCount} repositories");
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

    class UserModel
    {
        public string Login { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public RepositoriesModel Repositories { get; set; }
    }

    class RepositoriesModel
    {
        public int TotalCount;
    }
}

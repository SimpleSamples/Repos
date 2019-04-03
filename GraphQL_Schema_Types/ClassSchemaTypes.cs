using Octokit.GraphQL.Core;
using Octokit.GraphQL.Core.Introspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Schema_Types
{

    public class ClassSchemaTypes
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public GitHubSchema __schema { get; set; }
    }

    public class GitHubSchema
    {
        public List<GitHubSchemaType> types { get; set; }
    }

    public class GitHubSchemaType
    {
        public string name { get; set; }
        public string kind { get; set; }
        public string description { get; set; }
        public List<Field> fields { get; set; }
        public List<GitHubSchemaType> Interfaces { get; set; }
        public List<GitHubSchemaType> PossibleTypes { get; set; }
        public List<ArgInputValue> InputFields { get; set; }
        public GitHubSchemaType OfType { get; set; }
    }

    public class Field
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ArgInputValue> Args { get; set; }
        public GitHubSchemaType Type { get; set; }
        public bool IsDeprecated { get; set; }
        public string DeprecationReason { get; set; }
    }

    public class ArgInputValue
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string GitHubSchemaType { get; set; }
        public string DefaultValue { get; set; }
    }

}

using Newtonsoft.Json;
using Octokit.GraphQL;
using Octokit.GraphQL.Core.Introspection;
using System;
using System.IO;
using System.Linq;
using System.Windows;

// This works except not the parts of the query that are commented out.

// Remember: The target framework must be > ????

namespace GraphQL_Schema_Types
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string fn = Properties.Settings.Default.FilenameSetting;
            if (fn.Length == 0)
            {
                MenuItemRefresh_Click(null, null);
            }
            fn = Properties.Settings.Default.FilenameSetting;
            string InJSON;
            try
            {
                using (StreamReader sr = new StreamReader(fn))
                {
                    InJSON = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                statusBar1.Items[0] = "Read error: " + ex.Message;
                return;
            }
            GitHubSchema Root = JsonConvert.DeserializeObject<GitHubSchema>(InJSON.ToString());
            if (Root == null)
            {
                statusBar1.Items[0] = "Null root";
                return;
            }
            if (Root.types.Count < 1)
            {
                statusBar1.Items[0] = "No data";
                return;
            }
            statusBar1.Items[0] = $"{Root.types.Count} types";
            GridItems.ItemsSource = Root.types;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void MenuItemRefresh_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = Properties.Settings.Default.FilenameSetting;
            dlg.DefaultExt = ".json"; // Default file extension
            dlg.Filter = "JSON documents (.json)|*.json";
            //Nullable<bool> sfdresult = dlg.ShowDialog();
            if (dlg.ShowDialog() == false)
                return;
            string fn = dlg.FileName;
            //
            string token = System.Environment.GetEnvironmentVariable("GitHubTokenEX");
            var productInformation = new ProductHeaderValue("octokit");
            Connection connection;
            try { connection = new Connection(productInformation, token); }
            catch (Exception ex)
            {
                statusBar1.Items[0] = "Connection error: " + ex.Message;
                return;
            }
            // query {
            //   __schema {
            //     types {
            //       name
            //       kind
            //       description
            //       fields {
            //         name
            //       }
            //     }
            //   }
            // }
            Octokit.GraphQL.Core.IQueryableValue<GitHubSchema> query =
                new IntrospectionQuery().Schema.Select(y => new GitHubSchema
                {
                    types = y.Types.Select(t => new GitHubSchemaType
                    {
                        name = t.Name,
                        kind = t.Kind.ToString(),
                        description = t.Description,
                        fields = t.Fields(true).Select(f => new Field
                        {
                            Name = f.Name,
                            Description = f.Description,
                            //Args = f.((List<InputValue>)Args.ToList<InputValue>()).Select(a => new ArgInputValue
                            //{
                            //    Name = a.Name,
                            //    Description = a.Description,
                            //    SchemaType = a.Type.ToString(),
                            //    DefaultValue = a.DefaultValue
                            //}),
                            //Type = f.Type.Select(t => new GitHubSchemaType
                            //{
                            //    name = t.Name,
                            //    kind = t.Kind.ToString(),
                            //    description = t.Description,
                            //}),
                            IsDeprecated = f.IsDeprecated,
                            DeprecationReason = f.DeprecationReason
                        }).ToList()
                    }).ToList()
                    //Issues = r.Issues(100, null, null, null, null, null, null)
                    //    .Nodes.Select(i => new IssueModel
                    //    {
                    //        Number = i.Number,
                    //        Title = i.Title,
                    //    }).ToList(),
                });
            try
            {
                GitHubSchema result = await connection.Run(query);
                if (result != null)
                {
                    StreamWriter Outfile = null;
                    try { Outfile = new StreamWriter(fn); }
                    catch (Exception ex)
                    {
                        statusBar1.Items[0] = string.Format("Output file open error {0}", ex.Message);
                        return;
                    }
                    Outfile.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
                    Outfile.Flush();
                    Outfile.Dispose();
                    Properties.Settings.Default.FilenameSetting = fn;
                    Properties.Settings.Default.Save();
                }
                else
                    statusBar1.Items[0] = "Null result";
            }
            catch (Exception ex)
            {
                statusBar1.Items[0] = "Error: " + ex.Message;
                if (ex.InnerException != null)
                    statusBar1.Items[0] = "InnerException: " + ex.InnerException.Message;
            }
        }
    }
}

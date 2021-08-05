using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# LINQ recursive query to show parent child relation - Microsoft Q&A
// https://docs.microsoft.com/en-us/answers/questions/381019/c-linq-recursive-query-to-show-parent-child-relati.html

namespace LINQrecursivequery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Comment> categories = new List<Comment>()
     {
         new Comment () { Id = 1, Text = "Item 1", ParentId = 0},
         new Comment() { Id = 2, Text = "Item 2", ParentId = 1 },
         new Comment() { Id = 3, Text = "Item 3", ParentId = 2 },
         new Comment() { Id = 4, Text = "Item 1.1", ParentId = 1 },
         new Comment() { Id = 5, Text = "Item 3.1", ParentId = 3 },
         new Comment() { Id = 6, Text = "Item 1.1.1", ParentId = 4 },
         new Comment() { Id = 7, Text = "Item 2.1", ParentId = 2 }
     };
            // List<Comment> rootlist = (from c in categories where c.ParentId == 0 select c).ToList();
            // List<Comment> hierarchy = categories.Where(c => c.ParentId == 0).ToList();
            List<Comment> hierarchy = categories
                            .Where(c => c.ParentId == 0)
                            .Select(c => new Comment()
                            {
                                Id = c.Id,
                                Text = c.Text,
                                ParentId = c.ParentId,
                                hierarchy = "0000" + c.Id,
                                Children = GetChildren(categories, c.Id)
                            })
                            .ToList();
            HieararchyWalk(hierarchy);
        }

        static public List<Comment> GetChildren(List<Comment> comments, int parentId)
        {
            return comments
                    .Where(c => c.ParentId == parentId)
                    .Select(c => new Comment
                    {
                        Id = c.Id,
                        Text = c.Text,
                        ParentId = c.ParentId,
                        hierarchy = "0000" + comments.Where(a => a.Id == parentId).FirstOrDefault().Id + ".0000" + c.Id,
                        Children = GetChildren(comments, c.Id)
                    })
                    .ToList();
        }

        static public void HieararchyWalk(List<Comment> hierarchy)
        {
            if (hierarchy != null)
            {
                foreach (var item in hierarchy)
                {
                    Console.WriteLine(string.Format("{0} {1}", item.Id, item.Text));
                    // textBox1.Text += item.Id + " " + item.Text + "Hierarchy-" + item.hierarchy + System.Environment.NewLine;
                    HieararchyWalk(item.Children);
                }
            }
        }

    }

    public class Comment
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string hierarchy { get; set; }
        public string Text { get; set; }
        public List<Comment> Children { get; set; }
    }
}

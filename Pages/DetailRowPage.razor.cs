using Blazorise.DataGrid;

namespace BlazoriseBugTestApp.Pages
{
    public partial class DetailRowPage
    {
        public List<ExampleVM> ExampleVMs { get; set; }
        public DataGrid<ExampleVM> gridRef = new DataGrid<ExampleVM>();

        public int ExpandedSubrowsForVanId = 0;

        protected override Task OnInitializedAsync()
        {
            ExampleVMs = new List<ExampleVM>
            {
                new ExampleVM
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Description 1",
                    Subject = "Subject 1",
                    Status = "Status 1",
                    VanStatusDetails = new List<DetailsVM>
                    {
                        new DetailsVM
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVM
                        {
                            Id = 2,
                            Name = "Name 2",
                            Description = "Description 2"
                        }
                    }
                },
                new ExampleVM
                {
                    Id = 2,
                    Name = "Name 2",
                    Description = "Description 2",
                    Subject = "Subject 2",
                    Status = "Status 2",
                    VanStatusDetails = new List<DetailsVM>
                    {
                        new DetailsVM
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVM
                        {
                            Id = 2,
                            Name = "Name 2",
                            Description = "Description 2"
                        }
                    }
                }
            };
            return base.OnInitializedAsync();
        }

        private bool OnDetailRowTrigger(DetailRowTriggerEventArgs<ExampleVM> context, int ExpandedSubrowsForVanId)
        {
            if (context.Item.Id == ExpandedSubrowsForVanId) // close all other main rows that are not the active one
            {
                // todo: refresh detail data
                return context.Item.VanStatusDetails?.Count > 0;
            }
            else
            {
                return false;
            }
        }

        private void OnOpenDetailRowClick(int item, ref int ExpandedSubrowsForVanId)
        {
            ExpandedSubrowsForVanId = item;
        }
    }

    public class ExampleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public List<DetailsVM> VanStatusDetails { get; set; }
    }

    public class DetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

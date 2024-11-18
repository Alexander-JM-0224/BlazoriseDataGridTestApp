using Blazorise.DataGrid;

namespace BlazoriseBugTestApp.Pages
{
    public partial class DetailRowPageDisplay
    {
        public List<ExampleVMDisplay> ExampleVMs { get; set; }
        public DataGrid<ExampleVMDisplay> gridRef = new DataGrid<ExampleVMDisplay>();

        public int ExpandedSubrowsForVanId = 0;

        protected override Task OnInitializedAsync()
        {
            ExampleVMs = new List<ExampleVMDisplay>
            {
                new ExampleVMDisplay
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Description 1",
                    Subject = "Subject 1",
                    Status = "Status 1",
                    VanStatusDetails = new List<DetailsVMDisplay>
                    {
                        new DetailsVMDisplay
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVMDisplay
                        {
                            Id = 2,
                            Name = "Name 2",
                            Description = "Description 2"
                        }
                    }
                },
                new ExampleVMDisplay
                {
                    Id = 2,
                    Name = "Name 2",
                    Description = "Description 2",
                    Subject = "Subject 2",
                    Status = "Status 2",
                    VanStatusDetails = new List<DetailsVMDisplay>
                    {
                        new DetailsVMDisplay
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVMDisplay
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

        private bool OnDetailRowTrigger(DetailRowTriggerEventArgs<ExampleVMDisplay> context, int ExpandedSubrowsForVanId)
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

    public class ExampleVMDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public List<DetailsVMDisplay> VanStatusDetails { get; set; }
    }

    public class DetailsVMDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

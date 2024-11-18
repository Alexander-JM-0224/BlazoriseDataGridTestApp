using Blazorise.DataGrid;

namespace BlazoriseBugTestApp.Pages
{
    public partial class DetailRowPageDisplayable
    {
        public List<ExampleVMDisplayable> ExampleVMs { get; set; }
        public DataGrid<ExampleVMDisplayable> gridRef = new DataGrid<ExampleVMDisplayable>();

        public int ExpandedSubrowsForVanId = 0;

        protected override Task OnInitializedAsync()
        {
            ExampleVMs = new List<ExampleVMDisplayable>
            {
                new ExampleVMDisplayable
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Description 1",
                    Subject = "Subject 1",
                    Status = "Status 1",
                    VanStatusDetails = new List<DetailsVMDisplayable>
                    {
                        new DetailsVMDisplayable
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVMDisplayable
                        {
                            Id = 2,
                            Name = "Name 2",
                            Description = "Description 2"
                        }
                    }
                },
                new ExampleVMDisplayable
                {
                    Id = 2,
                    Name = "Name 2",
                    Description = "Description 2",
                    Subject = "Subject 2",
                    Status = "Status 2",
                    VanStatusDetails = new List<DetailsVMDisplayable>
                    {
                        new DetailsVMDisplayable
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description 1"
                        },
                        new DetailsVMDisplayable
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

        private bool OnDetailRowTrigger(DetailRowTriggerEventArgs<ExampleVMDisplayable> context, int ExpandedSubrowsForVanId)
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

    public class ExampleVMDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string Status { get; set; }
        public List<DetailsVMDisplayable> VanStatusDetails { get; set; }
    }

    public class DetailsVMDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

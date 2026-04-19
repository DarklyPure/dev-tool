namespace Pure.BO.Core.Invoicing
{
    public class Invoice : Core
    {
        public string Number { get; set; } = string.Empty;
        public DateOnly IssueDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly DueDate { get; set; }

        public Address SellerAddress { get; set; } = new();
        public Address CustomerAddress { get; set; } = new();

        public List<OrderItem> Items { get; set; } = [];
        public string Comments { get; set; } = string.Empty;
    }
}

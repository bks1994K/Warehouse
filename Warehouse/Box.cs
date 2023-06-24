namespace Warehouse
{
    public class Box
    {
        private DateOnly _expirationDate;

        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double Weight { get; set; }

        public double Volume => Width * Height * Depth;

        public DateOnly? ProductionDate { get; set; }

        public DateOnly ExpirationDate => ProductionDate.HasValue ? ProductionDate.Value.AddDays(100) : _expirationDate;

        public Box(int id, double width, double height, double depth, double weight, DateOnly date, DateType dateType)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
            switch (dateType)
            {
                case DateType.ProductionDate:
                    ProductionDate = date;
                    break;

                case DateType.ExpirationDate:
                    _expirationDate = date;
                    break;

                default:
                    throw new ArgumentException("Unknown dataType");
            }
        }
    }
}

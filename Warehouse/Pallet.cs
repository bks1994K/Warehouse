namespace Warehouse
{
    public class Pallet
    {
        private const double _weightPallet = 30;

        private List<Box> _boxes = new List<Box>();

        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public double Weight => Boxes.Sum(b => b.Weight) + _weightPallet;

        public double Volume => (Width * Height * Depth) + Boxes.Sum(b => b.Volume);

        public DateOnly? ExpirationDate => Boxes.MinBy(b => b.ExpirationDate)?.ExpirationDate;

        public IReadOnlyList<Box> Boxes => _boxes;

        public Pallet(int id, double width, double height, double depth)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
        }

        public void AddBoxesToPallet(List<Box> boxes)
        {
            List<Box> dontAddedBoxes = new List<Box>();

            foreach (var box in boxes)
            {
                if (box.Width <= Width
                 && box.Height <= Height)
                {
                    _boxes.Add(box);
                }
                else
                {
                    dontAddedBoxes.Add(box);
                }
            }

            if (dontAddedBoxes.Count == boxes.Count)
            {
                throw new ArgumentException("None of the boxes are added to the pallet due to the exceeding dimensions of the box");
            }
            else if (dontAddedBoxes.Count == 0)
            {
                Console.WriteLine("All of boxes have been added to the pallet");
            }
            else if (dontAddedBoxes.Count > 0)
            {
                Console.WriteLine($"Boxes with id {string.Join(",", dontAddedBoxes.Select(b => b.Id))} were not added to the pallet due to exceeding the dimensions");
            }
        }

        public override string ToString()
        {
            return $"Id:{Id}, Width:{Width}, Height:{Height}, Depth:{Depth}, Weight:{Weight}," +
                   $" Volume:{Volume}, ExpirationDate:{ExpirationDate}, Count of boxes:{Boxes.Count}";
        }
    }
}

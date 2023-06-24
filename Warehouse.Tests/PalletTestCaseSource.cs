using System.Collections;

namespace Warehouse.Tests
{
    public class PalletTestCaseSource
    {
        public static IEnumerable AddBoxesToPalletTestCase()
        {
            List<Box> addBoxes = new List<Box>
            {
                new Box(10, 100, 200, 300, 150, new DateOnly(2023, 06, 09), DateType.ProductionDate),
                new Box(21, 11, 22, 33, 55, new DateOnly(2023, 06, 10), DateType.ExpirationDate),
            };
            List<Box> expected = new List<Box>
            {
                new Box(10, 100, 200, 300, 150, new DateOnly(2023, 06, 09), DateType.ProductionDate),
                new Box(21, 11, 22, 33, 55, new DateOnly(2023, 06, 10), DateType.ExpirationDate)
            };

            yield return new object[] { addBoxes, expected };
        }

        public static IEnumerable AddBoxesToPalletTestCase_WhenAllAddedBoxesDontAddedToPalletBecauseOfBigSizes_ShouldBeArgumentException()
        {
            List<Box> addBoxes = new List<Box>
            {
                new Box(109, 1000, 500, 800, 190, new DateOnly(2022, 06, 09), DateType.ProductionDate),
                new Box(219, 600, 400, 500, 98, new DateOnly(2023, 06, 17), DateType.ExpirationDate),
            };

            yield return new object[] { addBoxes };
        }

        public static IEnumerable AddBoxesToPalletTestCase_WhenPartOfAddedBoxesDontAddedToPalletBecauseOfBigSizes()
        {
            List<Box> addBoxes = new List<Box>
            {
                new Box(108, 1000, 800, 550, 190, new DateOnly(2023, 05, 09), DateType.ProductionDate),
                new Box(218, 110, 220, 339, 17, new DateOnly(2023, 04, 10), DateType.ExpirationDate),
            };
            List<Box> expected = new List<Box>
            {
                new Box(218, 110, 220, 339, 17, new DateOnly(2023, 04, 10), DateType.ExpirationDate)
            };

            yield return new object[] { addBoxes, expected };
        }
    }
}
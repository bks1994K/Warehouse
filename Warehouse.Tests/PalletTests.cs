using FluentAssertions;

namespace Warehouse.Tests
{
    public class PalletTests
    {
        Pallet Pallet => new Pallet(1, 500, 300, 400);

        [TestCaseSource(typeof(PalletTestCaseSource), nameof(PalletTestCaseSource.AddBoxesToPalletTestCase))]
        public void AddBoxesToPalletTest(List<Box> addBoxes, List<Box> expected)
        {
            var pallet = Pallet;
            pallet.AddBoxesToPallet(addBoxes);

            pallet.Boxes.Should().BeEquivalentTo(expected);
        }

        [TestCaseSource(typeof(PalletTestCaseSource), nameof(PalletTestCaseSource.AddBoxesToPalletTestCase_WhenAllAddedBoxesDontAddedToPalletBecauseOfBigSizes_ShouldBeArgumentException))]
        public void AddBoxesToPalletTest_WhenAllAddedBoxesDontAddedToPalletBecauseOfBigSizes_ShouldBeArgumentException(List<Box> addBoxes)
        {
            var pallet = Pallet;
            Assert.Throws<ArgumentException>(() => pallet.AddBoxesToPallet(addBoxes));
        }

        [TestCaseSource(typeof(PalletTestCaseSource), nameof(PalletTestCaseSource.AddBoxesToPalletTestCase_WhenPartOfAddedBoxesDontAddedToPalletBecauseOfBigSizes))]
        public void AddBoxesToPalletTest_WhenPartOfAddedBoxesDontAddedToPalletBecauseOfBigSizes(List<Box> addBoxes, List<Box> expected)
        {
            var pallet = Pallet;
            pallet.AddBoxesToPallet(addBoxes);

            pallet.Boxes.Should().BeEquivalentTo(expected);
        }
    }
}
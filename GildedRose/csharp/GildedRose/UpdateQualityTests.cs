using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Console 
{

	[TestFixture]
	public class UpdateQualityTests 
	{

		[Test]
		public void QualityShouldDecreaseOnEachTick() 
		{
			Program.Items = new List<Item> { new Item {Name = "No-nonsense Item", SellIn = 10, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(19, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);
		}

		[Test]
		public void QualityShouldDecreaseTwiceAsFastAfterSellInDay() 
		{
			Program.Items = new List<Item> { new Item {Name = "No-nonsense Item", SellIn = -1, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(18, Program.Items[0].Quality);
			Assert.AreEqual(-2, Program.Items[0].SellIn);

		}

		[Test]
		public void QualityCannotBeNegative() 
		{
			Program.Items = new List<Item> { new Item {Name = "No-nonsense Item", SellIn = 10, Quality = 0} };
			Program.UpdateQuality();

			Assert.AreEqual(0, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);

		}

		[Test]
		public void AgedBrieQualityShouldIncreaseOnEachTick() 
		{
			Program.Items = new List<Item> { new Item {Name = "Aged Brie", SellIn = 10, Quality = 20} };
			Program.UpdateQuality();

			Assert.AreEqual(21, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);

		}

		[Test]
		public void QualityCannotBeGreaterThan50() 
		{
			Program.Items = new List<Item> { new Item {Name = "Aged Brie", SellIn = 10, Quality = 50} };

			Program.UpdateQuality();

			Assert.AreEqual(50, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);

		}

		[Test]
		public void LegendaryItemsNeverIncreaseOrDecreaseInQualityAndSellInDayDoesNotChange() 
		{
			Program.Items = new List<Item> { new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80} };

			Program.UpdateQuality();

			Assert.AreEqual(80, Program.Items[0].Quality);
			Assert.AreEqual(0, Program.Items[0].SellIn);

		}

		[Test]
		public void BackstagePassesHaveTheirOwnVerySpecialRules() 
		{
			Program.Items = new List<Item> { new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(21, Program.Items[0].Quality);
			Assert.AreEqual(10, Program.Items[0].SellIn);

			Program.UpdateQuality();

			Assert.AreEqual(23, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);

			Program.Items = new List<Item> { new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(22, Program.Items[0].Quality);
			Assert.AreEqual(5, Program.Items[0].SellIn);

			Program.UpdateQuality();

			Assert.AreEqual(25, Program.Items[0].Quality);
			Assert.AreEqual(4, Program.Items[0].SellIn);

			Program.Items = new List<Item> { new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(0, Program.Items[0].Quality);
			Assert.AreEqual(-1, Program.Items[0].SellIn);

		}

		[Test]
		[Ignore]
		public void ConjuredItemsDegradeTwiceAsFastAsNormalItems() 
		{			
			Program.Items = new List<Item> { new Item {Name = "No-nonsense Item", SellIn = 10, Quality = 20} };

			Program.UpdateQuality();

			Assert.AreEqual(18, Program.Items[0].Quality);
			Assert.AreEqual(9, Program.Items[0].SellIn);

			
		}
	}

}
//using NUnit.Framework;
//using Sort_opdracht;

//namespace BornToMove.OrganizerTest
//{
//    public class RotateSortTest
//    {
//        [Test]
//        public void testSortEmpty()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(0).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { }));
//        }

//        [Test]
//        public void testSortOneElement()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { 32 };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(1).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { 32 }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { 32 }));
//        }

//        [Test]
//        public void testSortTwoElements()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { 32, 3 };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(2).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { 3, 32 }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { 32, 3 }));
//        }

//        [Test]
//        public void testSortThreeElements()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { 32, 3, 235 };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(3).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { 3, 32, 235 }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { 32, 3, 235 }));
//        }

//        [Test]
//        public void testSortThreeEqual()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { 3, 3, 3 };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(3).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { 3, 3, 3 }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { 3, 3, 3 }));
//        }

//        [Test]
//        public void testSortSevenElements()
//        {
//            // prepare
//            RotateSort<int> sorter = new RotateSort<int>();
//            List<int> input = new List<int>() { 32, 3, 235, 32, 32, 54, 22 };

//            // run
//            var result = sorter.Sort(input);

//            // validate
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Has.Exactly(7).Items);
//            Assert.That(result, Is.EquivalentTo(new int[] { 3, 22, 32, 32, 32, 54, 235 }));
//            // also check that our input is not modified
//            Assert.That(input, Is.EquivalentTo(new int[] { 32, 3, 235, 32, 32, 54, 22 }));
//        }
//    }
//}

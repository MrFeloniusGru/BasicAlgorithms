using Core;
using Xunit;

namespace Tests {
    public class KnuthMorrisPrattTests : SubStringFinder
    {
        public KnuthMorrisPrattTests()
        {
        }

        [Fact]
        public void FailureShouldBeEmptyArray()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var subStringPositions = finder.Failure(null);

            Assert.Empty(subStringPositions); 
        }

        [Fact]
        public void FailureSimple()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var subStringPositions = finder.Failure("s");

            Assert.Equal(subStringPositions, new int[] { 0 }); 
        }

        [Fact]
        public void FailureSimple2()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var subStringPositions = finder.Failure("ss");

            Assert.Equal(subStringPositions, new int[] { 0, 1 }); 
        }

        [Fact]
        public void FailureSimple3()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var subStringPositions = finder.Failure("sass");

            Assert.Equal(subStringPositions, new int[] { 0, 0, 1, 1 }); 
        }

        [Fact]
        public void IndexesOfTest()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var indexes = finder.IndexesOf("abababa", "aba");

            Assert.Equal(indexes, new int[]{0, 2, 4}); 
        }

        [Fact]
        public void IndexesOfTest2()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var indexes = finder.IndexesOf("aabaab", "aa");

            Assert.Equal(indexes, new int[]{0, 3}); 
        }


        
        [Fact]
        public void IndexesOfTest3()
        {
            KnuthMorrisPrattTests finder = new KnuthMorrisPrattTests();
            
            var indexes = finder.IndexesOf("мокмолооломко моло молооко молоко", "молоко");

            Assert.Equal(indexes, new int[]{27}); 
        }
    }
}
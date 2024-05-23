using RollUp;
using System.Net.Http.Headers;

namespace RollUpTest
{
    public class UnitTest1
    {
        [Fact]
        public void RollUpTest1()
        {
            List<Products> products = new List<Products>
        {
            new Products(100.00F, "P1", "V1", "G1"),
            new Products(100.00F, "P1", "V1", "G2"),
            new Products(100.00F, "P1", "V2", "G3"),
            new Products(100.00F, "P1", "V2", "G4"),
        };

            var result = RollUpMethod.RollUpControlProduct(products);

            Assert.Equal(100.00F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
        }

        [Fact]
        public void RollUpTest2()
        {
            List<Products> products = new List<Products>
        {
            new Products(100.00F, "P1", "V1", "G1"),
            new Products(100.00F, "P1", "V1", "G2"),
            new Products(100.00F, "P1", "V2", "G3"),
            new Products(100.00F, "P1", "V2", "G4"),
            new Products(100.00F, "P1", "V2", "G5"),
        };

            var result = RollUpMethod.RollUpControlProduct(products);

            Assert.Equal(100.00F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
        }

        [Fact]
        public void RollUpTest3()
        {
            List<Products> products = new List<Products>
        {
            new Products(100.00F, "P1", "V1", "G1"),
            new Products(100.00F, "P1", "V1", "G2"),
            new Products(100.00F, "P1", "V2", "G3"),
            new Products(100.00F, "P1", "V2", "G4"),
            new Products(100.00F, "P1", "V3", "G5"),
        };

            var result = RollUpMethod.RollUpControlProduct(products);

            Assert.Equal(100.00F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
        }

        [Fact]
        public void RollUpTest4()
        {
            List<Products> products = new List<Products>
        {
            new Products(100.00F, "P1", "V1", "G1"),
            new Products(100.00F, "P1", "V1", "G2"),
            new Products(100.00F, "P1", "V2", "G3"),
            new Products(100.00F, "P1", "V2", "G4"),
            new Products(100.00F, "P2", "V3", "G5"),
        };

            var result = RollUpMethod.RollUpControlProduct(products);

            Assert.Equal(100.00F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
            Assert.Equal(100.00F, result.Selected[1].Price);
            Assert.Equal("P2", result.Selected[1].Product);
        }

        [Fact]
        public void RollUpTest5()
        {
            List<Products> products = new List<Products>
        {
            new Products(null, "P1", "V1", "G1"),
            new Products(100.00F, "P1", "V1", "G2"),
            new Products(100.00F, "P1", "V2", "G3"),
            new Products(100.00F, "P1", "V2", "G4"),
        };

            var result = RollUpMethod.RollUpControlVariant(products);

            Assert.Equal(100.00F, result.Selected[0].Price);
            Assert.Equal("G2", result.Selected[0].Gtin);
            Assert.Equal(100.00F, result.Selected[1].Price);
            Assert.Equal("V2", result.Selected[1].Variant);
        }



        [Fact]
        public void RollUpTest6()
        {
            List<Products> products = new List<Products>
              {
        new Products(50, "P1", "V1", "G1"),
        new Products(100, "P1", "V1", "G2"),
        new Products(100, "P1", "V2", "G3"),
        new Products(100, "P1", "V2", "G4"),
             };

            var result = RollUpMethod.RollUpControlVariant(products);

            
            Assert.Equal(50F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
            Assert.Equal(100F, result.Discarded[0].Price);
            Assert.Equal("G2", result.Discarded[0].Gtin);
            Assert.Equal(100F, result.Discarded[1].Price);
            Assert.Equal("V2", result.Discarded[1].Variant);
        }

        [Fact]
        public void RollUpTest7()
        {
            List<Products> products = new List<Products>
              {
        new Products(50, "P1", "V1", "G1"),
        new Products(70, "P1", "V1", "G2"),
        new Products(100, "P1", "V2", "G3"),
        new Products(90, "P1", "V2", "G4"),
             };

            var result = RollUpMethod.RollUpControlProduct(products);


            Assert.Equal(50F, result.Selected[0].Price);
            Assert.Equal("P1", result.Selected[0].Product);
            Assert.Equal(90F, result.Discarded[0].Price);
            Assert.Equal("V2", result.Discarded[0].Variant);
            Assert.Equal(70F, result.Discarded[1].Price);
            Assert.Equal("G2", result.Discarded[1].Gtin);
            Assert.Equal(100F, result.Discarded[2].Price);
            Assert.Equal("G3", result.Discarded[2].Gtin);
        }

    }
}
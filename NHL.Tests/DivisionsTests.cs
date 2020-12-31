//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NHL.Core.Extensions;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NHL.Tests
//{
//    [TestClass]
//    public class DivisionsTests : BaseNHLTest
//    {
//        [TestMethod]
//        public async Task GetDivisions()
//        {
//            var divisions = await Client.GetDivisions().ExecuteAsync();

//            Assert.IsTrue(divisions.SafeAny());
//            Assert.AreEqual(divisions.Count, 4);
//        }

//        [TestMethod]
//        public async Task GetDivisionById()
//        {
//            var divisionRequest = Client.GetDivisions();
//            divisionRequest.SetId(17);

//            var divisions = await divisionRequest.ExecuteAsync();

//            bool hasResponce = divisions.SafeAny();

//            Assert.IsTrue(hasResponce);

//            if (!hasResponce)
//            {
//                Assert.Fail("empty division responce");
//                return;
//            }

//            Assert.AreEqual(divisions.Count, 1);

//            var divisionToCompare = divisions.First();


//            Assert.AreEqual(divisionToCompare.Abbreviation, "A");
//            Assert.AreEqual(divisionToCompare.Name, "Atlantic");
//            Assert.AreEqual(divisionToCompare.Id, 17);
//            Assert.AreEqual(divisionToCompare.Conference.Id, 6);
//        }
//    }
//}

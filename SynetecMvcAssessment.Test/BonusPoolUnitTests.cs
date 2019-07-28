using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using InterviewTestTemplatev2.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SynetecMvcAssesment.Business.Tasks;

namespace SynetecMvcAssessment.Test
{
    [TestClass]
    public class BonusPoolUnitTests
    {
       
        Mock<DbSet<HrDepartment>> mockHrDepartments;
        Mock<DbSet<HrEmployee>> mockHrEmployees;

        public BonusPoolUnitTests()
        {
            var dataHrDepartment = new List<HrDepartment>
            {
                new HrDepartment { ID = 1, BonusPoolAllocationPerc = 30 }
            }.AsQueryable();

            var dataHrEmployee = new List<HrEmployee>
            {
                new HrEmployee { ID = 1, HrDepartmentId = 1 }
            }.AsQueryable();

            mockHrDepartments = new Mock<DbSet<HrDepartment>>();
            mockHrDepartments.As<IQueryable<HrDepartment>>().Setup(m => m.Provider).Returns(dataHrDepartment.Provider);
            mockHrDepartments.As<IQueryable<HrDepartment>>().Setup(m => m.Expression).Returns(dataHrDepartment.Expression);
            mockHrDepartments.As<IQueryable<HrDepartment>>().Setup(m => m.ElementType).Returns(dataHrDepartment.ElementType);
            mockHrDepartments.As<IQueryable<HrDepartment>>().Setup(m => m.GetEnumerator()).Returns(dataHrDepartment.GetEnumerator());

            mockHrEmployees = new Mock<DbSet<HrEmployee>>();
            mockHrEmployees.As<IQueryable<HrEmployee>>().Setup(m => m.Provider).Returns(dataHrEmployee.Provider);
            mockHrEmployees.As<IQueryable<HrEmployee>>().Setup(m => m.Expression).Returns(dataHrEmployee.Expression);
            mockHrEmployees.As<IQueryable<HrEmployee>>().Setup(m => m.ElementType).Returns(dataHrEmployee.ElementType);
            mockHrEmployees.As<IQueryable<HrEmployee>>().Setup(m => m.GetEnumerator()).Returns(dataHrEmployee.GetEnumerator());
        }

        [TestMethod]
        public void TestIfBonusPoolCalculationIsCorrect()
        {           

            Mock<MvcInterviewV3Entities1> dbMocked = new Mock<MvcInterviewV3Entities1>();

            dbMocked.Setup(x => x.HrDepartments).Returns(mockHrDepartments.Object);
            dbMocked.Setup(x => x.HrEmployees).Returns(mockHrEmployees.Object);

            BonusPool newBonusPool = new BonusPool(dbMocked.Object);
            var decimalVal = newBonusPool.CalculateByEmployeeId(1, 123456);

            Assert.AreEqual((decimal)37036.8, decimalVal);
        }
    }
}

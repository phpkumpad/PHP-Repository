using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using PHP.Controllers;
using PHP.Models;
using PHP.Models.ViewModels;
using Xunit;

namespace PHP.Tests
{
    public class MemberControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IMemberRepository> mock = new Mock<IMemberRepository>();
            mock.Setup(m => m.Members).Returns((new Member[]
            {
                new Member {MemberId = "1", MemberName = "M1"},
                new Member {MemberId = "2", MemberName = "M2"},
                new Member {MemberId = "3", MemberName = "M3"},
                new Member {MemberId = "4", MemberName = "M4"},
                new Member {MemberId = "5", MemberName = "M5"}
            }).AsQueryable<Member>());

            MemberController controller = new MemberController(mock.Object);
            controller.PageSize = 3;

            //Act
            MembersListViewModel result = controller.List(null,2).ViewData.Model as MembersListViewModel;

            //Assert
            Member[] membArray = result.Members.ToArray();
            Assert.True(membArray.Length == 2);
            Assert.Equal(membArray[0].MemberName, "M4");
            Assert.Equal(membArray[1].MemberName, "M5");
        }

        [Fact]
        public void Can_Send_Pagnation_View_Model()
        {
            Mock<IMemberRepository> mock = new Mock<IMemberRepository>();
            mock.Setup(m => m.Members).Returns((new Member[]
            {
                new Member {MemberId = "1", MemberName = "M1"},
                new Member {MemberId = "2", MemberName = "M2"},
                new Member {MemberId = "3", MemberName = "M3"},
                new Member {MemberId = "4", MemberName = "M4"},
                new Member {MemberId = "5", MemberName = "M5"}

            }).AsQueryable<Member>());

            // Arrange 
            MemberController controller = new MemberController(mock.Object){ PageSize = 3};

            //Act
            MembersListViewModel result = controller.List(null,2).ViewData.Model as MembersListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);




        }
    
}
}

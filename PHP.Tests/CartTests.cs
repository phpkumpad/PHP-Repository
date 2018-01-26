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
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {

            // Arrange - create some test members
            Member m1 = new Member { MemberName = "M1", FormId = "1" };
            Member m2 = new Member { MemberName = "M2", FormId = "2" };

            // Arrange - create new cart
            Cart target = new Cart();


            // Act
            target.AddItem(m1);
            target.AddItem(m2);

            Cart.CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.Equal(2, results.Length);



        }

        [Fact]
        public void Can_Remove_Lines()
        {

            // Arrange - create some test members
            Member m1 = new Member { MemberName = "M1", FormId = "1" };
            Member m2 = new Member { MemberName = "M2", FormId = "2" };
            Member m3 = new Member { MemberName = "M3", FormId = "3" };

            // Arrange - create new cart
            Cart target = new Cart();


            // Arrange - add items
            target.AddItem(m1);
            target.AddItem(m2);
            target.AddItem(m3);
            target.AddItem(m1);



            target.RemoveLine(m2);

            // Assert
            Assert.Equal(0,target.Lines.Count(m => m.Member == m2));
            Assert.Equal(2, target.Lines.Count());



        }

        [Fact]
        public void Can_Clear_Cart()
        {

            // Arrange - create some test members
            Member m1 = new Member { MemberName = "M1", FormId = "1" };
            Member m2 = new Member { MemberName = "M2", FormId = "2" };
            Member m3 = new Member { MemberName = "M3", FormId = "3" };

            // Arrange - create new cart
            Cart target = new Cart();


            // Arrange - add items
            target.AddItem(m1);
            target.AddItem(m2);
            target.AddItem(m3);
            target.AddItem(m1);



            target.Clear();

            // Assert
            Assert.Equal(0, target.Lines.Count());
            



        }
    }
    
}

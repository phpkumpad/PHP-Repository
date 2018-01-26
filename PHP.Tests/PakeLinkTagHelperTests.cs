﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using PHP.Infrastructure;
using PHP.Models.ViewModels;
using Xunit;

namespace PHP.Tests
{
    public class PakeLinkTagHelperTests
    {
        [Fact]
        public void Can_Genereate_Page_Links()
        {
            // Arrange
            var urlHelpper = new Mock<IUrlHelper>();
            urlHelpper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
                .Returns("Test/Page1")
                .Returns("Test/Page2")
                .Returns("Test/Page3");

            var urlHelpperFactory = new Mock<IUrlHelperFactory>();
            urlHelpperFactory.Setup(f => f.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelpper.Object);

            PageLinkTagHelper helper = new PageLinkTagHelper(urlHelpperFactory.Object)
            {
                PageModel = new PagingInfo
                {
                    CurrentPage = 2,
                    TotalItems = 28,
                    ItemsPerPage = 10
                },
                PageAction = "Test"

            };

            TagHelperContext ctx = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), "" );

            var content = new Mock<TagHelperContent>();
            TagHelperOutput output = new TagHelperOutput("div", new TagHelperAttributeList(),(cache,encoder) => Task.FromResult(content.Object) );

            // Act
            helper.Process(ctx,output);

            // Assert
            Assert.Equal(@"<a href=""Test/Page1"">1</a>"
                + @"<a href=""Test/Page2"">2</a>"
                + @"<a href=""Test/Page3"">3</a>",
                output.Content.GetContent());







        }
    }
}

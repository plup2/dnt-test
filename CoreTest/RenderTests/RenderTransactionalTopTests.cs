﻿using FluentAssertions;
using GoC.WebTemplate;
using Xunit;

namespace CoreTest.RenderTests
{
  public class RenderTransactionalTopTests
  {
    [Theory, AutoNSubstituteData]
    public void TopSecMenuTrueInTransactionalTopWhenLeftMenuItems(Core sut)
    {
      sut.LeftMenuItems.Add(new MenuSection
      {
        Link = "foo",
        Name = "bar"
      });
      sut.RenderTransactionalTop().ToString().Should().Contain("\"topSecMenu\":true");
    }
       
    [Theory, AutoNSubstituteData]
    public void TopSecMenuFalseInTransactionalTopWhenLeftMenuItems(Core sut)
    {
      sut.RenderTransactionalTop().ToString().Should().Contain("\"topSecMenu\":false");
    }
        
    [Theory, AutoNSubstituteData]
    public void IntranetTitleShouldNotRenderWhenNullInTransactionalTop(Core sut)
    {
      sut.IntranetTitle = null;
      sut.RenderTransactionalTop().ToString().Should().NotContain("\"intranetTitle\":[null]");

    }
    [Theory, AutoNSubstituteData]
    public void IntranetTitleTransacationalTop(Core sut)
    {
      sut.IntranetTitle = new Link {Text = "foo", Href = "bar"};
      sut.RenderTransactionalTop().ToString().Should().Contain("\"intranetTitle\":[{\"href\":\"bar\",\"text\":\"foo\"}]");
    }
        
        
  }
}
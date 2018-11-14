﻿using System;
using FluentAssertions;
using GoC.WebTemplate.Components;
using Xunit;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using GoC.WebTemplate.Components.JSONSerializationObjects;

namespace CoreTest.RenderTests
{
    public class RenderFooterTests
    {

        [Theory, AutoNSubstituteData]
        public void ContactLinksShoulNotRenderWhenNull(Core sut)
        {
            sut.ContactLink = null;
            sut.RenderFooter().ToString().Should().NotContain("\"contactLinks\"");
        }

        [Theory, AutoNSubstituteData]
        public void ContactLinksShoulNotRenderWhenEmpty(Core sut)
        {
            sut.ContactLink = new Link();
            sut.RenderFooter().ToString().Should().NotContain("\"contactLinks\"");
        }

        [Theory, AutoNSubstituteData]
        public void ContactLinksShouldNotBeEmptyWhenValueIsSet(Core sut)
        {
            sut.ContactLink = new Link
            {
                Href = "foo"
            };
            sut.RenderFooter().ToString().Should().NotContain("\"contactLinks\":[{}]")
              .And.Contain("\"contactLinks\":[{\"href\":\"foo\"}]");

        }

        [Theory, AutoNSubstituteData]
        public void HandleContactLinkSetTextAKAMAI([Frozen]IDictionary<string, ICDTSEnvironment> environments, Core sut)
        {
            var currentEnv = new CDTSEnvironment
            {
                Name = "AKAMAI"
            };
            environments[sut.Environment] = currentEnv;
            sut.ContactLink = new Link() { Text = "LinkText" };
            Action act = () => sut.RenderFooter();
            act.Should().Throw<InvalidOperationException>();
        }

        [Theory, AutoNSubstituteData]
        public void HandleContactLinkSetTextOtherEnvironment([Frozen]IDictionary<string, ICDTSEnvironment> environments, Core sut)
        {
            var currentEnv = new CDTSEnvironment
            {
                Name = "Name"
            };
            environments[sut.Environment] = currentEnv;
            sut.ContactLink = new Link() { Text = "LinkText" };
            Action act = () => sut.RenderFooter();
            act.Should().NotThrow();
        }

        [Theory, AutoNSubstituteData]
        public void HandleTransactionalFooterContactLinkSetTextAKAMAI([Frozen]IDictionary<string, ICDTSEnvironment> environments, Core sut)
        {
            var currentEnv = new CDTSEnvironment
            {
                Name = "AKAMAI"
            };
            environments[sut.Environment] = currentEnv;
            sut.ContactLink = new Link() { Text = "LinkText" };
            Action act = () => sut.RenderTransactionalFooter();
            act.Should().Throw<InvalidOperationException>();
        }

        [Theory, AutoNSubstituteData]
        public void HandleTransactionalFooterContactLinkSetTextOtherEnvironment([Frozen]IDictionary<string, ICDTSEnvironment> environments, Core sut)
        {
            var currentEnv = new CDTSEnvironment
            {
                Name = "Name"
            };
            environments[sut.Environment] = currentEnv;
            sut.ContactLink = new Link() { Text = "LinkText" };
            Action act = () => sut.RenderTransactionalFooter();
            act.Should().NotThrow();
        }

        [Theory, AutoNSubstituteData]
        public void ShouldNotEncodeURL(Core sut)
        {
            sut.ContactLink = new Link("http://localhost:8080/foo.html", string.Empty);
            var htmlstring = sut.RenderFooter();
            htmlstring.ToString().Should().Contain("http://localhost:8080/foo.html");
        }
        [Theory, AutoNSubstituteData]
        public void ExceptionWhenCallingRenderFooterLinks(Core sut)
        {
            sut.ContactLink = null;
            Action execute = () =>
            {
                var ignore = sut.RenderFooter();
            };
            execute.Should().NotThrow<NullReferenceException>();

        }

        [Theory, AutoNSubstituteData]
        public void HandleEmptyContactLinkList(Core sut)
        {
            sut.ContactLink = null;
            sut.RenderFooter().ToString().Should().NotContain("\"contactLinks\"");
        }

        [Theory, AutoNSubstituteData]
        public void HandleContactLinkValue(Core sut)
        {
            sut.ContactLink = new Link() { Href = "http://testvalue" };
            sut.RenderFooter().ToString().Should().Contain("\"contactLinks\":[{\"href\":\"http://testvalue\"}]");
        }

        [Theory, AutoNSubstituteData]
        public void RenderTransactionalFooter(Core sut)
        {
            sut.ContactLink = new Link
            {
                Href = "www.fakehref.com",
                Acronym = "accrrrnm"
            };
            sut.PrivacyLinkURL = "dummyprivacylinkurl";
            sut.TermsConditionsLinkURL = "thisIsMyFunTemrsLink";

            var result = sut.RenderTransactionalFooter();
            result.ToString().Should().Be("{\"cdnEnv\":\"\",\"subTheme\":\"\",\"showFooter\":false,\"contactLinks\":[{\"href\":\"www.fakehref.com\",\"acronym\":\"accrrrnm\"}],\"privacyLink\":\"dummyprivacylinkurl\",\"termsLink\":\"thisIsMyFunTemrsLink\",\"showFeatures\":false}");
        }
    }
}
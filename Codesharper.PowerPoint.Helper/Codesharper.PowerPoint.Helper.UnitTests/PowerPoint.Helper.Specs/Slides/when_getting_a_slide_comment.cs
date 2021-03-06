﻿namespace Codesharper.PowerPoint.Helper.Specs.PowerPoint.Helper.Specs
{
    #region Using Directives

    using System.Collections.Generic;

    using Codesharper.PowerPoint.Helper.Implementations;
    using Codesharper.PowerPoint.Helper.Objects;

    using NUnit.Framework;

    using Should;

    using SpecsFor;

    #endregion

    public class when_getting_a_slide_comment : SpecsFor<PresentationManager>
    {

        private Microsoft.Office.Interop.PowerPoint.Application powerpointHandle;

        private Microsoft.Office.Interop.PowerPoint.Presentation presentationHandle;

        private Microsoft.Office.Interop.PowerPoint.Slide slideHandle;

        private SlideManager slideManager;

        private List<SlideComment> slideComments = new List<SlideComment>();
        protected override void Given()
        {
            this.slideManager = new SlideManager();
            this.powerpointHandle = new Microsoft.Office.Interop.PowerPoint.Application();
            this.presentationHandle = this.SUT.CreatePowerPointPresentation(this.powerpointHandle,false);
            this.slideHandle = this.slideManager.AddSlideToEnd(this.presentationHandle);
            
            this.slideManager.AddComment(
                    this.slideHandle,
                    new SlideComment()
                    {
                        Author = "Test Author",
                        AuthorInitials = "TA",
                        Comment = "This is a test comment",
                        LeftPosition = 100f,
                        TopPosition = 100f
                    });

        }

        protected override void When()
        {
            slideComments = this.slideManager.GetSlideComments(this.slideHandle);
        }

        

        [Test]
        public void then_total_number_of_comments_should_increase_by_one()
        {
            this.slideComments.Count.ShouldEqual(1);

        }
    }
}

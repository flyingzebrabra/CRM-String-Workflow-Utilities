﻿using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public sealed class EndsWith : WorkFlowActivityBase
    {
        public EndsWith() : base(typeof(EndsWith)) { }

        [RequiredArgument]
        [Input("String To Search")]
        public InArgument<string> StringToSearch { get; set; }

        [RequiredArgument]
        [Input("Search For")]
        public InArgument<string> SearchFor { get; set; }

        [RequiredArgument]
        [Input("Case Sensitive")]
        [Default("false")]
        public InArgument<bool> CaseSensitive { get; set; }

        [Output("Ends With String")]
        public OutArgument<bool> EndsWithString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string stringToSearch = StringToSearch.Get(context);
            string searchFor = SearchFor.Get(context);
            bool caseSensitive = CaseSensitive.Get(context);

            bool endsWithString = stringToSearch.EndsWith(searchFor,
                (caseSensitive) ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase);

            EndsWithString.Set(context, endsWithString);
        }
    }
}
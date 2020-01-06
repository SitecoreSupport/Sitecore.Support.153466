namespace Sitecore.Support.Pipelines.GetFieldValue
{
    using Sitecore;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.GetFieldValue;
    using System;

    public class GetInheritedValue
    {
        public void Process(GetFieldValueArgs args)
        {
            if (args.AllowInheritValue)
            {
                string inheritedValue = args.Field.GetInheritedValue();
                if (inheritedValue != null)
                {
                    args.InheritsValueFromOriginalItem = true;
                    args.Value = inheritedValue;
                    args.AbortPipeline();
                }
            }

        }
    }
}

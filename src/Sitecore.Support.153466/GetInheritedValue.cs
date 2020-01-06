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
                string inheritedValue = string.Empty;
                try
                {
                    inheritedValue = args.Field.GetInheritedValue();
                }
                catch (ArgumentNullException)
                {
                    string str2 = args.Field.Item.Fields[FieldIDs.SourceItem].GetValue(false, false, false, false);
                    Log.SingleWarn($"Source item is not found. Value skipped. {str2} .", this);
                    args.Field.Item.Editing.BeginEdit();
                    args.Field.Item.Fields[FieldIDs.SourceItem].Value = null;
                    args.Field.Item.Editing.EndEdit();
                    args.AbortPipeline();
                }
                if (!string.IsNullOrEmpty(inheritedValue))
                {
                    args.InheritsValueFromOriginalItem = true;
                    args.Value = inheritedValue;
                    args.AbortPipeline();
                }
            }
        }
    }
}
